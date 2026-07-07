using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmMusteriler : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmMusteriler()
        {
            InitializeComponent();

            // --- FORM AYARLARI ---
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // --- KARAKTER KISITLAMALARI ---
            this.txtAdSoyad.KeyPress += SadeceHarf_KeyPress;
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
            GridFormatla();

            // Başlangıçta gelişmiş arama alanlarını gizliyoruz
            GelismisAramaPaneliniGuncelle(false);
        }

        // --- GELİŞMİŞ ARAMA MANTIĞI (TELEFON İÇİN) ---

        private void chkDetayliArama_CheckedChanged(object sender, EventArgs e)
        {
            GelismisAramaPaneliniGuncelle(chkDetayliArama.Checked);
        }

        private void GelismisAramaPaneliniGuncelle(bool aktif)
        {
            cmbTelefonModu.Visible = aktif;
            lblOzelArama.Visible = aktif;
            mskAramaTelefon.Visible = aktif;

            if (!aktif)
            {
                mskAramaTelefon.Clear();
                cmbTelefonModu.SelectedIndex = 0;
                Filtrele(); // Paneli kapatınca filtreyi sıfırla
            }
        }

        // Telefon kutusuna yazıldığında veya ComboBox değiştiğinde çalışır
        private void mskAramaTelefon_TextChanged(object sender, EventArgs e) => Filtrele();
        private void KriterDegisti(object sender, EventArgs e) => Filtrele();

        // --- ANA FİLTRELEME MOTORU ---
        private void Filtrele()
        {
            try
            {
                if (dgvMusteriler.DataSource is DataTable dt)
                {
                    string adAranan = txtArama.Text.Replace("'", "''").Trim();

                    mskAramaTelefon.TextChanged -= mskAramaTelefon_TextChanged;
                    mskAramaTelefon.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string rawTel = mskAramaTelefon.Text.Replace("'", "''").Trim();
                    mskAramaTelefon.TextMaskFormat = MaskFormat.IncludeLiterals;
                    string formattedTel = mskAramaTelefon.Text.Replace("'", "''").Trim();
                    mskAramaTelefon.TextChanged += mskAramaTelefon_TextChanged;

                    string filtre = "";

                    // 1. Ad Soyad Filtresi - ComboBox moduna göre
                    if (!string.IsNullOrEmpty(adAranan))
                    {
                        filtre = AramaKosulu("[Müşteri]", adAranan, cmbAdSoyadModu.SelectedIndex);
                    }

                    // 2. Telefon Filtresi - Çoklu filtreleme aktifse
                    if (chkDetayliArama.Checked && !string.IsNullOrEmpty(rawTel))
                    {
                        string telFiltre = "";
                        int mod = cmbTelefonModu.SelectedIndex;

                        if (mod == 3) // Birebir
                        {
                            telFiltre = string.Format("(Telefon = '{0}' OR Telefon = '{1}')", formattedTel, rawTel);
                        }
                        else if (mod == 1) // İle Başlayan
                        {
                            telFiltre = string.Format("(Telefon LIKE '{0}%' OR Telefon LIKE '{1}%')", formattedTel, rawTel);
                        }
                        else if (mod == 2) // İle Biten
                        {
                            telFiltre = string.Format("(Telefon LIKE '%{0}' OR Telefon LIKE '%{1}')", formattedTel, rawTel);
                        }
                        else // İçeren (varsayılan)
                        {
                            telFiltre = string.Format("(Telefon LIKE '%{0}%' OR Telefon LIKE '%{1}%')", formattedTel, rawTel);
                        }

                        if (!string.IsNullOrEmpty(filtre))
                            filtre += " AND " + telFiltre;
                        else
                            filtre = telFiltre;
                    }

                    dt.DefaultView.RowFilter = filtre;
                }
            }
            catch { }
        }

        /// <summary>
        /// Verilen sütun adı, aranan metin ve mod indeksine göre RowFilter koşulu üretir.
        /// mod: 0=İçeren, 1=İle Başlayan, 2=İle Biten, 3=Birebir
        /// </summary>
        private string AramaKosulu(string sutun, string aranan, int mod)
        {
            switch (mod)
            {
                case 1: return string.Format("{0} LIKE '{1}%'", sutun, aranan);   // İle Başlayan
                case 2: return string.Format("{0} LIKE '%{1}'", sutun, aranan);   // İle Biten
                case 3: return string.Format("{0} = '{1}'", sutun, aranan);       // Birebir
                default: return string.Format("{0} LIKE '%{1}%'", sutun, aranan); // İçeren
            }
        }

        // Ad Soyad Hızlı Arama Kutusu
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        // --- CRUD İŞLEMLERİ ---

        void Listele()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MusteriID as [ID], AdSoyad as [Müşteri], Telefon, Email, Adres FROM Musteriler ORDER BY AdSoyad", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMusteriler.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Denetle()) return;

            string ad = txtAdSoyad.Text.Trim().ToUpper();
            if (MusteriVarMi(ad))
            {
                txtAdSoyad.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' isminde bir müşteri zaten kayıtlı!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"{txtAdSoyad.Text} isimli müşteriyi kaydetmek istiyor musunuz?", "Kayıt Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = bgl.baglanti())
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Musteriler (AdSoyad, Telefon, Email, Adres) VALUES (@p1,@p2,@p3,@p4)", conn);
                        cmd.Parameters.AddWithValue("@p1", txtAdSoyad.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@p2", mskTelefon.Text);
                        cmd.Parameters.AddWithValue("@p3", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@p4", txtAdres.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele();
                        Temizle();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.CurrentRow == null) return;

            FrmMusteriGuncelle frm = new FrmMusteriGuncelle();
            frm.musteriID = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells["ID"].Value);
            frm.txtAdSoyad.Text = dgvMusteriler.CurrentRow.Cells["Müşteri"].Value.ToString();
            frm.mskTelefon.Text = dgvMusteriler.CurrentRow.Cells["Telefon"].Value.ToString();
            frm.txtEmail.Text = dgvMusteriler.CurrentRow.Cells["Email"].Value.ToString();
            frm.rchAdres.Text = dgvMusteriler.CurrentRow.Cells["Adres"].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Listele();
                Temizle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.CurrentRow == null) return;

            FrmMusteriSilOnay frmSil = new FrmMusteriSilOnay();
            frmSil.musteriID = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells["ID"].Value);
            frmSil.txtAdSoyad.Text = dgvMusteriler.CurrentRow.Cells["Müşteri"].Value.ToString();
            frmSil.txtTelefon.Text = dgvMusteriler.CurrentRow.Cells["Telefon"].Value.ToString();

            if (frmSil.ShowDialog() == DialogResult.OK)
            {
                Listele();
                Temizle();
            }
        }

        // --- YARDIMCI ARAÇLAR ---

        private void dgvMusteriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMusteriler.CurrentRow == null) return;
            txtAdSoyad.Text = dgvMusteriler.CurrentRow.Cells["Müşteri"].Value.ToString();
            mskTelefon.Text = dgvMusteriler.CurrentRow.Cells["Telefon"].Value.ToString();
            txtEmail.Text = dgvMusteriler.CurrentRow.Cells["Email"].Value.ToString();
            txtAdres.Text = dgvMusteriler.CurrentRow.Cells["Adres"].Value.ToString();

            ResetColors();
        }

        private void btnTemizle_Click(object sender, EventArgs e) => Temizle();

        void Temizle()
        {
            txtAdSoyad.Clear();
            mskTelefon.Clear();
            txtEmail.Clear();
            txtAdres.Clear();
            txtArama.Clear();
            mskAramaTelefon.Clear();
            cmbAdSoyadModu.SelectedIndex = 0;
            cmbTelefonModu.SelectedIndex = 0;
            ResetColors();
        }

        void ResetColors()
        {
            txtAdSoyad.BackColor = Color.White;
            mskTelefon.BackColor = Color.White;
            txtAdres.BackColor = Color.White;
        }

        private bool Denetle()
        {
            bool hataVar = false;
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text)) { txtAdSoyad.BackColor = Color.MistyRose; hataVar = true; }
            if (!mskTelefon.MaskFull) { mskTelefon.BackColor = Color.MistyRose; hataVar = true; }
            if (string.IsNullOrWhiteSpace(txtAdres.Text)) { txtAdres.BackColor = Color.MistyRose; hataVar = true; }

            if (hataVar)
                MessageBox.Show("Lütfen kırmızı alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return hataVar;
        }

        void GridFormatla()
        {
            dgvMusteriler.ReadOnly = true;
            dgvMusteriler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SadeceHarf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private bool MusteriVarMi(string ad)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Musteriler WHERE UPPER(AdSoyad) = @p1", conn);
                    cmd.Parameters.AddWithValue("@p1", ad.ToUpper());
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }
    }
}