using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmPersonelGuncelle : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int personelID = 0; // Ana formdan gelen ID'yi tutar

        public FrmPersonelGuncelle()
        {
            InitializeComponent();
            GorevDoldur();
            EtkinlikleriBagla();
        }

        public void GorevDoldur()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT GorevAd FROM Gorevler ORDER BY GorevAd", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbGorev.DisplayMember = "GorevAd";
                    cmbGorev.ValueMember = "GorevAd";
                    cmbGorev.DataSource = dt;
                    cmbGorev.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private void EtkinlikleriBagla()
        {
            // --- HOCA KURALI: TÜR KISITLAMALARI ---
            // Ad Soyad sadece harf
            this.txtAdSoyad.KeyPress += (s, e) => e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            // Maaş sadece sayı ve tek virgül
            this.txtMaas.KeyPress += (s, e) => {
                TextBox txt = (TextBox)s;
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) e.Handled = true;
                if ((e.KeyChar == ',') && (txt.Text.IndexOf(',') > -1)) e.Handled = true;
            };

            // Butonun tıklama olayını mühürlüyoruz (Çalışmama sorununu çözer)
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // Giriş Alanlarında Kızartma Sıfırlama olayları
            txtAdSoyad.TextChanged += (s, e) => txtAdSoyad.BackColor = Color.White;
            cmbGorev.SelectedIndexChanged += (s, e) => cmbGorev.BackColor = Color.White;
            mskTelefon.TextChanged += (s, e) => mskTelefon.BackColor = Color.White;
            txtMaas.TextChanged += (s, e) => txtMaas.BackColor = Color.White;
        }

        private void FrmPersonelGuncelle_Load(object sender, EventArgs e)
        {
            // --- HOCA KURALI: TAB İNDEX SIRALAMASI ---
            txtAdSoyad.TabIndex = 0;
            cmbGorev.TabIndex = 1;
            mskTelefon.TabIndex = 2;
            txtMaas.TabIndex = 3;
            btnGuncelle.TabIndex = 4;

            // Renkleri sıfırla
            txtAdSoyad.BackColor = Color.White;
            cmbGorev.BackColor = Color.White;
            mskTelefon.BackColor = Color.White;
            txtMaas.BackColor = Color.White;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // --- HOCA KURALI: BOŞ ALANLARI KIZARTMA ---
            bool hataVar = false;

            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text)) { txtAdSoyad.BackColor = Color.MistyRose; hataVar = true; }
            else { txtAdSoyad.BackColor = Color.White; }

            if (cmbGorev.SelectedIndex == -1) { cmbGorev.BackColor = Color.MistyRose; hataVar = true; }
            else { cmbGorev.BackColor = Color.White; }

            if (!mskTelefon.MaskFull) { mskTelefon.BackColor = Color.MistyRose; hataVar = true; }
            else { mskTelefon.BackColor = Color.White; }

            if (string.IsNullOrWhiteSpace(txtMaas.Text)) { txtMaas.BackColor = Color.MistyRose; hataVar = true; }
            else { txtMaas.BackColor = Color.White; }

            if (hataVar)
            {
                MessageBox.Show("Lütfen işaretli alanları eksiksiz doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- HOCA KURALI: İŞLEM ONAYI (SORU İKONU) ---
            if (MessageBox.Show("Personel bilgileri güncellenecek. Onaylıyor musunuz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Personeller SET AdSoyad=@p1, Gorev=@p2, Telefon=@p3, Maas=@p4 WHERE PersonelID=@p5", conn);
                    cmd.Parameters.AddWithValue("@p1", txtAdSoyad.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@p2", cmbGorev.Text);
                    cmd.Parameters.AddWithValue("@p3", mskTelefon.Text);

                    // Maaş dönüşümü (nokta-virgül hatası almamak için)
                    decimal maas = 0;
                    decimal.TryParse(txtMaas.Text.Replace(".", ","), out maas);
                    cmd.Parameters.AddWithValue("@p4", maas);

                    cmd.Parameters.AddWithValue("@p5", personelID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Personel başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Ana formun listeyi yenilemesi için
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