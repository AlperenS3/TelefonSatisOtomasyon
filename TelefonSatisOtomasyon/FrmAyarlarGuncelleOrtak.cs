using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmAyarlarGuncelleOrtak : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public string tabloAdi = "";
        public int kayitID = 0;

        public FrmAyarlarGuncelleOrtak()
        {
            InitializeComponent();
            // Buton olayını koda mühürlüyoruz
            this.btnGuncelle.Click += new EventHandler(this.btnGuncelle_Click);
        }

        private void FrmAyarlarGuncelleOrtak_Load(object sender, EventArgs e)
        {
            // Renkleri sıfırla
            txt1.BackColor = Color.White;
            txt2.BackColor = Color.White;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // --- HOCA KURALI: BOŞ ALAN KIZARTMA VE KONTROL ---
            bool hataVar = false;

            // Görünür olan kutuları denetle
            if (txt1.Visible && string.IsNullOrWhiteSpace(txt1.Text))
            {
                txt1.BackColor = Color.MistyRose;
                hataVar = true;
            }
            else { txt1.BackColor = Color.White; }

            if (txt2.Visible && string.IsNullOrWhiteSpace(txt2.Text))
            {
                txt2.BackColor = Color.MistyRose;
                hataVar = true;
            }
            else { txt2.BackColor = Color.White; }

            if (hataVar)
            {
                MessageBox.Show("Lütfen işaretli alanları doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- HOCA KURALI: İŞLEM ONAYI (SORU İKONU) ---
            if (MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (tabloAdi == "Marka")
                    {
                        cmd.CommandText = "UPDATE Markalar SET MarkaAd=@p1 WHERE MarkaID=@id";
                        cmd.Parameters.AddWithValue("@p1", txt1.Text.Trim().ToUpper());
                    }
                    else if (tabloAdi == "Kategori")
                    {
                        cmd.CommandText = "UPDATE Kategoriler SET KategoriAd=@p1 WHERE KategoriID=@id";
                        cmd.Parameters.AddWithValue("@p1", txt1.Text.Trim().ToUpper());
                    }
                    else if (tabloAdi == "Kullanici")
                    {
                        cmd.CommandText = "UPDATE Kullanicilar SET KullaniciAd=@p1, Sifre=@p2, Yetki=@p3 WHERE KullaniciID=@id";
                        cmd.Parameters.AddWithValue("@p1", txt1.Text.Trim());
                        cmd.Parameters.AddWithValue("@p2", txt2.Text.Trim());
                        cmd.Parameters.AddWithValue("@p3", cmbYetki.Text);
                    }

                    cmd.Parameters.AddWithValue("@id", kayitID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Bilgiler başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}