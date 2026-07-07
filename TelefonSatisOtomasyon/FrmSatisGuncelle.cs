using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmSatisGuncelle : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int satisID = 0;

        public FrmSatisGuncelle()
        {
            InitializeComponent();
            EtkinlikleriBagla();
        }

        private void FrmSatisGuncelle_Load(object sender, EventArgs e)
        {
            ListeleriDoldur();

            // Tab sırası (Hoca Kuralı: Sırayla İlerleme)
            cmbMusteri.TabIndex = 0;
            cmbCihaz.TabIndex = 1;
            nudAdet.TabIndex = 2;
            txtBirimFiyat.TabIndex = 3;
            btnGuncelle.TabIndex = 4;
        }

        private void EtkinlikleriBagla()
        {
            // Olayları ve kısıtlamaları bağlıyoruz
            this.nudAdet.ValueChanged += (s, e) => { RenkSifirla(nudAdet); Hesapla(); };
            this.txtBirimFiyat.TextChanged += (s, e) => { RenkSifirla(txtBirimFiyat); Hesapla(); };
            this.cmbMusteri.SelectedIndexChanged += (s, e) => RenkSifirla(cmbMusteri);
            this.cmbCihaz.SelectedIndexChanged += (s, e) => RenkSifirla(cmbCihaz);

            // HOCA KURALI: Sadece Sayı ve Virgül Kısıtlaması (Fiyat Kutusu İçin)
            this.txtBirimFiyat.KeyPress += SayiVeVirgul_KeyPress;
            this.btnGuncelle.Click += btnGuncelle_Click;
        }

        // --- KLAVYE KORUMASI ---
        private void SayiVeVirgul_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayı, backspace ve virgül izni
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Mükerrer virgül engelleme
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        void ListeleriDoldur()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT MusteriID, AdSoyad FROM Musteriler", conn);
                    DataTable dt1 = new DataTable(); da1.Fill(dt1);
                    cmbMusteri.DisplayMember = "AdSoyad"; cmbMusteri.ValueMember = "MusteriID"; cmbMusteri.DataSource = dt1;

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT UrunID, Model FROM Urunler", conn);
                    DataTable dt2 = new DataTable(); da2.Fill(dt2);
                    cmbCihaz.DisplayMember = "Model"; cmbCihaz.ValueMember = "UrunID"; cmbCihaz.DataSource = dt2;
                }
            }
            catch (Exception ex) { MessageBox.Show("Listeler yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void Hesapla()
        {
            decimal adet = nudAdet.Value;
            // Bölgesel ayar farklarını (nokta/virgül) yönetmek için replace
            decimal.TryParse(txtBirimFiyat.Text.Replace(".", ","), out decimal fiyat);
            txtToplam.Text = (adet * fiyat).ToString("N2");
        }

        private void RenkSifirla(Control c) { c.BackColor = Color.White; }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1. BOŞ ALAN KONTROLÜ VE KIRMIZI İŞARETLEME
            bool hataVar = false;
            if (cmbMusteri.SelectedIndex == -1) { cmbMusteri.BackColor = Color.MistyRose; hataVar = true; }
            if (cmbCihaz.SelectedIndex == -1) { cmbCihaz.BackColor = Color.MistyRose; hataVar = true; }
            if (string.IsNullOrEmpty(txtBirimFiyat.Text) || txtBirimFiyat.Text == "0") { txtBirimFiyat.BackColor = Color.MistyRose; hataVar = true; }

            if (hataVar)
            {
                MessageBox.Show("Lütfen işaretli alanları uygun şekilde doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. İŞLEM ONAYI
            if (MessageBox.Show("Satış kaydı güncellenecektir. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            using (SqlConnection baglan = bgl.baglanti())
            {
                SqlTransaction trans = baglan.BeginTransaction();
                try
                {
                    // 1. Eski stoğu iade et
                    SqlCommand cmdEski = new SqlCommand("SELECT UrunID, Adet FROM Satislar WHERE SatisID=@id", baglan, trans);
                    cmdEski.Parameters.AddWithValue("@id", satisID);
                    SqlDataReader dr = cmdEski.ExecuteReader();
                    int eskiUrunID = 0, eskiAdet = 0;
                    if (dr.Read()) { eskiUrunID = (int)dr["UrunID"]; eskiAdet = (int)dr["Adet"]; }
                    dr.Close();

                    SqlCommand cmdIade = new SqlCommand("UPDATE Urunler SET StokAdet = StokAdet + @adet WHERE UrunID = @id", baglan, trans);
                    cmdIade.Parameters.AddWithValue("@adet", eskiAdet);
                    cmdIade.Parameters.AddWithValue("@id", eskiUrunID);
                    cmdIade.ExecuteNonQuery();

                    // 2. Satışı güncelle
                    SqlCommand cmdUp = new SqlCommand("UPDATE Satislar SET MusteriID=@p1, UrunID=@p2, Adet=@p3, ToplamTutar=@p4 WHERE SatisID=@id", baglan, trans);
                    cmdUp.Parameters.AddWithValue("@p1", cmbMusteri.SelectedValue);
                    cmdUp.Parameters.AddWithValue("@p2", cmbCihaz.SelectedValue);
                    cmdUp.Parameters.AddWithValue("@p3", nudAdet.Value);
                    // Toplam tutarı çekerken formatlı metni temizleyip decimal'e çeviriyoruz
                    decimal toplam = decimal.Parse(txtToplam.Text.Replace("₺", "").Trim());
                    cmdUp.Parameters.AddWithValue("@p4", toplam);
                    cmdUp.Parameters.AddWithValue("@id", satisID);
                    cmdUp.ExecuteNonQuery();

                    // 3. Yeni stoğu düş
                    SqlCommand cmdDus = new SqlCommand("UPDATE Urunler SET StokAdet = StokAdet - @adet WHERE UrunID = @id", baglan, trans);
                    cmdDus.Parameters.AddWithValue("@adet", nudAdet.Value);
                    cmdDus.Parameters.AddWithValue("@id", cmbCihaz.SelectedValue);
                    cmdDus.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Satış kaydı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}