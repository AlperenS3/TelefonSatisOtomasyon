using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmKasaGuncelle : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int kasaID = 0;

        public FrmKasaGuncelle()
        {
            InitializeComponent();
            EtkinlikleriBagla();
        }

        private void EtkinlikleriBagla()
        {
            // --- HOCA KURALI: TÜR KISITLAMASI ---
            this.txtTutar.KeyPress += (s, e) => {
                TextBox txt = (TextBox)s;
                // Sadece rakam, kontrol tuşları ve tek virgül
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) e.Handled = true;
                if ((e.KeyChar == ',') && (txt.Text.IndexOf(',') > -1)) e.Handled = true;
            };

            // KRİTİK: Butonun çalışmama hatasını burası çözer (Click olayını koda bağlıyoruz)
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
        }

        private void FrmKasaGuncelle_Load(object sender, EventArgs e)
        {
            // --- HOCA KURALI: TAB İNDEX SIRALAMASI ---
            txtTutar.TabIndex = 0;
            rchAciklama.TabIndex = 1;
            btnGuncelle.TabIndex = 2;

            // Form açıldığında renkleri beyazlat
            txtTutar.BackColor = Color.White;
            rchAciklama.BackColor = Color.White;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // --- HOCA KURALI: BOŞ ALANLARI KIZARTMA ---
            bool hata = false;

            if (string.IsNullOrWhiteSpace(txtTutar.Text) || txtTutar.Text == "0")
            {
                txtTutar.BackColor = Color.MistyRose;
                hata = true;
            }
            else { txtTutar.BackColor = Color.White; }

            if (string.IsNullOrWhiteSpace(rchAciklama.Text))
            {
                rchAciklama.BackColor = Color.MistyRose;
                hata = true;
            }
            else { rchAciklama.BackColor = Color.White; }

            if (hata)
            {
                // UYARI İKONU
                MessageBox.Show("Lütfen işaretli alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- HOCA KURALI: İŞLEM ONAYI (SORU İKONU) ---
            if (MessageBox.Show("Finansal kayıt güncellenecektir. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Kasa SET Tutar=@p1, Aciklama=@p2 WHERE KasaID=@p3", conn);

                    // Nokta/Virgül uyumu için Replace
                    decimal tutar = 0;
                    decimal.TryParse(txtTutar.Text.Replace(".", ","), out tutar);

                    cmd.Parameters.AddWithValue("@p1", tutar);
                    cmd.Parameters.AddWithValue("@p2", rchAciklama.Text.Trim());
                    cmd.Parameters.AddWithValue("@p3", kasaID);
                    cmd.ExecuteNonQuery();

                    // BİLGİ İKONU
                    MessageBox.Show("Kasa gider kaydı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Ana formun tazelenmesi için
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // HATA İKONU
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}