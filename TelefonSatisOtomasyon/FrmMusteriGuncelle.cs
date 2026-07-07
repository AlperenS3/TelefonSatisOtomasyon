using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmMusteriGuncelle : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int musteriID = 0;

        public FrmMusteriGuncelle()
        {
            InitializeComponent();

            // --- HOCA KURALI: KLAVYE KISITLAMALARI ---
            // Ad Soyad kısmına sadece harf ve boşluk izni
            this.txtAdSoyad.KeyPress += (s, e) => {
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
            };

            // Butonun Click olayını mühürlüyoruz
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
        }

        private void FrmMusteriGuncelle_Load(object sender, EventArgs e)
        {
            // --- HOCA KURALI: TAB İNDEX SIRALAMASI ---
            txtAdSoyad.TabIndex = 0;
            mskTelefon.TabIndex = 1;
            txtEmail.TabIndex = 2;
            rchAdres.TabIndex = 3;
            btnGuncelle.TabIndex = 4;

            // Arka plan renklerini sıfırla (Form yüklendiğinde temiz görünsün)
            txtAdSoyad.BackColor = Color.White;
            mskTelefon.BackColor = Color.White;
            rchAdres.BackColor = Color.White;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // --- HOCA KURALI: BOŞ ALANLARI KIZARTMA ---
            bool hataVar = false;

            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text)) { txtAdSoyad.BackColor = Color.MistyRose; hataVar = true; }
            else { txtAdSoyad.BackColor = Color.White; }

            // MaskedTextBox için doluluk kontrolü
            if (!mskTelefon.MaskFull) { mskTelefon.BackColor = Color.MistyRose; hataVar = true; }
            else { mskTelefon.BackColor = Color.White; }

            if (string.IsNullOrWhiteSpace(rchAdres.Text)) { rchAdres.BackColor = Color.MistyRose; hataVar = true; }
            else { rchAdres.BackColor = Color.White; }

            if (hataVar)
            {
                // UYARI İKONU KURALI
                MessageBox.Show("Lütfen işaretli alanları eksiksiz doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- HOCA KURALI: İŞLEM ONAYI (SORU İKONU) ---
            if (MessageBox.Show("Müşteri bilgileri güncellenecek. Onaylıyor musunuz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Musteriler SET AdSoyad=@p1, Telefon=@p2, Email=@p3, Adres=@p4 WHERE MusteriID=@p5", conn);
                    cmd.Parameters.AddWithValue("@p1", txtAdSoyad.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@p2", mskTelefon.Text); // Formatlı veri (___) ___-____
                    cmd.Parameters.AddWithValue("@p3", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@p4", rchAdres.Text.Trim());
                    cmd.Parameters.AddWithValue("@p5", musteriID);
                    cmd.ExecuteNonQuery();

                    // BAŞARI İKONU KURALI
                    MessageBox.Show("Müşteri bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Ana formu yenilemek için sinyal gönder
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // HATA İKONU KURALI
                MessageBox.Show("Sistem Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}