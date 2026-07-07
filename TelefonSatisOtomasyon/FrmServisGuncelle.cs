using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmServisGuncelle : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int servisID = 0;

        public FrmServisGuncelle()
        {
            InitializeComponent();
            EtkinlikleriBagla();
        }

        private void EtkinlikleriBagla()
        {
            // --- HOCA KURALI: TÜR KISITLAMALARI (KeyPress) ---

            // IMEI sadece sayı girişi
            this.txtIMEI.KeyPress += (s, e) => {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };

            // Fiyat sadece sayı ve tek virgül girişi (Hata düzelten versiyon)
            this.txtFiyat.KeyPress += (s, e) => {
                TextBox txt = (TextBox)s; // s parametresini TextBox'a çeviriyoruz
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }

                // Zaten bir virgül varsa ikinciye izin verme
                if ((e.KeyChar == ',') && (txt.Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }
            };
        }

        private void FrmServisGuncelle_Load(object sender, EventArgs e)
        {
            MusteriDoldur();

            DurumlariYukle();

            // --- HOCA KURALI: TAB İNDEX SIRALAMASI ---
            cmbMusteri.TabIndex = 0;
            txtCihaz.TabIndex = 1;
            txtIMEI.TabIndex = 2;
            rchAriza.TabIndex = 3;
            cmbDurum.TabIndex = 4;
            txtFiyat.TabIndex = 5;
            btnGuncelle.TabIndex = 6;

            RenkleriSifirla();
        }

        void MusteriDoldur()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MusteriID, AdSoyad FROM Musteriler ORDER BY AdSoyad", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbMusteri.DisplayMember = "AdSoyad";
                    cmbMusteri.ValueMember = "MusteriID";
                    cmbMusteri.DataSource = dt;
                }
            }
            catch { /* Hata durumunda sessiz geç */ }
        }

        void DurumlariYukle()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT DurumAd FROM ServisDurumlari ORDER BY DurumAd", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDurum.DisplayMember = "DurumAd";
                    cmbDurum.ValueMember = "DurumAd";
                    cmbDurum.DataSource = dt;
                }
            }
            catch { }
        }

        void RenkleriSifirla()
        {
            Control[] kontroller = { cmbMusteri, txtCihaz, txtIMEI, rchAriza, cmbDurum, txtFiyat };
            foreach (var c in kontroller) c.BackColor = Color.White;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // --- HOCA KURALI: BOŞ ALANLARI KIZARTMA ---
            bool hataVar = false;
            Control[] zorunluAlanlar = { cmbMusteri, txtCihaz, txtIMEI, rchAriza, cmbDurum, txtFiyat };

            foreach (var c in zorunluAlanlar)
            {
                if (string.IsNullOrWhiteSpace(c.Text) || c.Text == "0")
                {
                    c.BackColor = Color.MistyRose; // Kırmızımsı uyarı
                    hataVar = true;
                }
                else { c.BackColor = Color.White; }
            }

            if (hataVar)
            {
                // UYARI İKONU
                MessageBox.Show("İşaretli alanlar boş geçilemez!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- HOCA KURALI: İŞLEM ONAYI (SORU İKONU) ---
            if (MessageBox.Show("Servis kaydı güncellenecek. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE TeknikServis SET 
                        MusteriID=@p1, CihazModel=@p2, IMEI=@p3, ArizaDetay=@p4, Durum=@p5, TahminiFiyat=@p6 
                        WHERE ServisID=@p7", conn);

                    cmd.Parameters.AddWithValue("@p1", cmbMusteri.SelectedValue);
                    cmd.Parameters.AddWithValue("@p2", txtCihaz.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@p3", txtIMEI.Text.Trim());
                    cmd.Parameters.AddWithValue("@p4", rchAriza.Text.Trim());
                    cmd.Parameters.AddWithValue("@p5", cmbDurum.Text);

                    // Fiyat dönüşümü (Nokta virgül uyumu için)
                    decimal fiyat = 0;
                    decimal.TryParse(txtFiyat.Text.Replace(".", ","), out fiyat);
                    cmd.Parameters.AddWithValue("@p6", fiyat);
                    cmd.Parameters.AddWithValue("@p7", servisID);

                    cmd.ExecuteNonQuery();

                    // BİLGİ İKONU
                    MessageBox.Show("Servis kaydı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // HATA İKONU
                MessageBox.Show("Sistem Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}