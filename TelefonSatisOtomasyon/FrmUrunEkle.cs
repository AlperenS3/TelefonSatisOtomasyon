using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmUrunEkle : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int urunID = 0;
        ErrorProvider ep = new ErrorProvider();

        public FrmUrunEkle()
        {
            InitializeComponent();
            EtkinlikleriBagla();
        }

        private void EtkinlikleriBagla()
        {
            // --- KRİTİK: KAYDET BUTONUNUN KODLA BAĞLANMASI ---
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // Klavye Kısıtlamaları
            txtRenk.KeyPress += SadeceHarf_KeyPress;
            txtIMEI.KeyPress += SadeceSayi_KeyPress;
            txtAlisFiyat.KeyPress += SayiVeVirgul_KeyPress;
            txtSatisFiyat.KeyPress += SayiVeVirgul_KeyPress;

            // Yazmaya başlayınca uyarıları temizle
            txtModel.TextChanged += (s, e) => TemizleUyarı(txtModel);
            txtIMEI.TextChanged += (s, e) => TemizleUyarı(txtIMEI);
            txtRenk.TextChanged += (s, e) => TemizleUyarı(txtRenk);
            txtAlisFiyat.TextChanged += (s, e) => TemizleUyarı(txtAlisFiyat);
            txtSatisFiyat.TextChanged += (s, e) => TemizleUyarı(txtSatisFiyat);
        }

        private void FrmUrunEkle_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            KombolariDoldur();

            // Tab Sırası
            cmbMarka.TabIndex = 0; cmbKategori.TabIndex = 1; txtModel.TabIndex = 2;
            txtIMEI.TabIndex = 3; txtRenk.TabIndex = 4; txtAlisFiyat.TabIndex = 5;
            txtSatisFiyat.TabIndex = 6; nudStok.TabIndex = 7; btnKaydet.TabIndex = 8;

            if (urunID > 0)
            {
                VerileriGetir();
                this.Text = "Ürün Bilgilerini Güncelle";
                btnKaydet.Text = "GÜNCELLE";
                btnKaydet.BackColor = Color.SkyBlue;
            }
        }

        private void TemizleUyarı(Control c)
        {
            c.BackColor = Color.White;
            ep.SetError(c, "");
        }

        private void SadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SadeceHarf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void SayiVeVirgul_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) e.Handled = true;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1)) e.Handled = true;
        }

        void KombolariDoldur()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT MarkaID, MarkaAd FROM Markalar ORDER BY MarkaAd", conn);
                    DataTable dt1 = new DataTable(); da1.Fill(dt1);
                    cmbMarka.ValueMember = "MarkaID"; cmbMarka.DisplayMember = "MarkaAd"; cmbMarka.DataSource = dt1;

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT KategoriID, KategoriAd FROM Kategoriler ORDER BY KategoriAd", conn);
                    DataTable dt2 = new DataTable(); da2.Fill(dt2);
                    cmbKategori.ValueMember = "KategoriID"; cmbKategori.DisplayMember = "KategoriAd"; cmbKategori.DataSource = dt2;
                }
            }
            catch (Exception ex) { MessageBox.Show("Kombo Hatası: " + ex.Message); }
        }

        void VerileriGetir()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler WHERE UrunID=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", urunID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        cmbMarka.SelectedValue = dr["MarkaID"];
                        cmbKategori.SelectedValue = dr["KategoriID"];
                        txtModel.Text = dr["Model"].ToString();
                        txtIMEI.Text = dr["IMEI"].ToString();
                        txtRenk.Text = dr["Renk"].ToString();
                        txtAlisFiyat.Text = Convert.ToDecimal(dr["AlisFiyat"]).ToString("N2");
                        txtSatisFiyat.Text = Convert.ToDecimal(dr["SatisFiyat"]).ToString("N2");
                        nudStok.Value = Convert.ToDecimal(dr["StokAdet"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Veri Getirme Hatası: " + ex.Message); }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // --- BOŞ ALAN DENETİMİ ---
            Control[] zorunluAlanlar = { txtModel, txtIMEI, txtRenk, txtAlisFiyat, txtSatisFiyat };
            bool bosVarMi = false;
            ep.Clear();

            foreach (Control c in zorunluAlanlar)
            {
                if (string.IsNullOrWhiteSpace(c.Text) || c.Text == "0,00" || c.Text == "0")
                {
                    c.BackColor = Color.MistyRose;
                    ep.SetError(c, "Bu alan zorunludur!");
                    bosVarMi = true;
                }
            }

            if (bosVarMi)
            {
                MessageBox.Show("İşaretli alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // IMEI Çakışması Kontrolü (Sadece Yeni Kayıtlarda)
            if (urunID == 0 && IMEIExists(txtIMEI.Text))
            {
                txtIMEI.BackColor = Color.MistyRose;
                ep.SetError(txtIMEI, "Bu IMEI numarası zaten kayıtlı!");
                MessageBox.Show("Bu IMEI numarasına sahip bir ürün zaten mevcut!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- ONAY VE KAYIT ---
            string onayMesaj = urunID == 0 ? "Ürün eklensin mi?" : "Ürün güncellensin mi?";
            if (MessageBox.Show(onayMesaj, "İşlem Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    string sorgu = (urunID == 0)
                        ? "INSERT INTO Urunler (MarkaID,KategoriID,Model,IMEI,Renk,AlisFiyat,SatisFiyat,StokAdet) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)"
                        : "UPDATE Urunler SET MarkaID=@p1,KategoriID=@p2,Model=@p3,IMEI=@p4,Renk=@p5,AlisFiyat=@p6,SatisFiyat=@p7,StokAdet=@p8 WHERE UrunID=@p9";

                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", cmbMarka.SelectedValue);
                    cmd.Parameters.AddWithValue("@p2", cmbKategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@p3", txtModel.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@p4", txtIMEI.Text.Trim());
                    cmd.Parameters.AddWithValue("@p5", txtRenk.Text.Trim());
                    cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyat.Text.Replace(".", ",")));
                    cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyat.Text.Replace(".", ",")));
                    cmd.Parameters.AddWithValue("@p8", (int)nudStok.Value);

                    if (urunID > 0) cmd.Parameters.AddWithValue("@p9", urunID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Kayıt işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IMEIExists(string imei)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Urunler WHERE IMEI = @p1", conn);
                    cmd.Parameters.AddWithValue("@p1", imei.Trim());
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }
    }
}