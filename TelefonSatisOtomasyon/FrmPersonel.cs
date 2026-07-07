using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing; // Renk ayarları için

namespace TelefonSatisOtomasyon
{
    public partial class FrmPersonel : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmPersonel()
        {
            InitializeComponent();

            // --- TABLO (DataGridView) ÖZEL AYARLARI ---
            dgvPersonel.ReadOnly = true;
            dgvPersonel.AllowUserToAddRows = false;
            dgvPersonel.AllowUserToDeleteRows = false;
            dgvPersonel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonel.MultiSelect = false;
            dgvPersonel.RowHeadersVisible = false;
            dgvPersonel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonel.BackgroundColor = Color.White;
            dgvPersonel.BorderStyle = BorderStyle.None;
            dgvPersonel.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Olay Bağlantıları - TextChanged gerçek zamanlı arama için
            txtAramaAdSoyad.TextChanged += (s, e) => FiltreUygula();
            txtAramaGorev.TextChanged += (s, e) => FiltreUygula();
            mskAramaTel.TextChanged += mskAramaTel_TextChanged;

            // ComboBox değişince de filtrele
            cmbAdSoyadModu.SelectedIndexChanged += (s, e) => FiltreUygula();
            cmbGorevModu.SelectedIndexChanged += (s, e) => FiltreUygula();
            cmbTelModu.SelectedIndexChanged += (s, e) => FiltreUygula();

            // Temizle butonu
            btnOzelAra.Click += (s, e) =>
            {
                txtAramaAdSoyad.Clear();
                txtAramaGorev.Clear();
                mskAramaTel.Clear();
                cmbAdSoyadModu.SelectedIndex = 0;
                cmbGorevModu.SelectedIndex = 0;
                cmbTelModu.SelectedIndex = 0;
                FiltreUygula();
            };

            // CRUD İşlemleri Buton Bağlantıları
            btnEkle.Click += BtnEkle_Click;
            btnSil.Click += BtnSil_Click;
            btnGuncelle.Click += BtnGuncelle_Click;
            btnTemizle.Click += (s, e) => Temizle();

            // Giriş Alanlarında Kızartma Sıfırlama olayları
            txtAd.TextChanged += (s, e) => txtAd.BackColor = Color.White;
            cmbGorev.SelectedIndexChanged += (s, e) => cmbGorev.BackColor = Color.White;
            mskTel.TextChanged += (s, e) => mskTel.BackColor = Color.White;
            txtMaas.TextChanged += (s, e) => txtMaas.BackColor = Color.White;

            dgvPersonel.CellClick += DgvPersonel_CellClick;
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            GorevDoldur();
            Listele();
            Temizle();
        }

        void GorevDoldur()
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
            catch (Exception ex) { MessageBox.Show("Görevler listesi yüklenemedi: " + ex.Message); }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            bool boslukVar = false;
            if (string.IsNullOrWhiteSpace(txtAd.Text)) { txtAd.BackColor = Color.MistyRose; boslukVar = true; }
            if (cmbGorev.SelectedIndex == -1) { cmbGorev.BackColor = Color.MistyRose; boslukVar = true; }
            if (!mskTel.MaskFull) { mskTel.BackColor = Color.MistyRose; boslukVar = true; }
            if (string.IsNullOrWhiteSpace(txtMaas.Text)) { txtMaas.BackColor = Color.MistyRose; boslukVar = true; }

            if (boslukVar)
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = txtAd.Text.Trim().ToUpper();
            if (PersonelVarMi(ad))
            {
                txtAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' isminde bir personel zaten kayıtlı!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Personeller (AdSoyad, Gorev, Telefon, Maas) VALUES (@p1, @p2, @p3, @p4)", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.Parameters.AddWithValue("@p2", cmbGorev.Text);
                    cmd.Parameters.AddWithValue("@p3", mskTel.Text);
                    decimal maas = 0;
                    decimal.TryParse(txtMaas.Text.Replace(".", ","), out maas);
                    cmd.Parameters.AddWithValue("@p4", maas);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Personel başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            catch (Exception ex) { MessageBox.Show("Ekleme hatası: " + ex.Message); }
        }

        private bool PersonelVarMi(string ad)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Personeller WHERE UPPER(AdSoyad) = UPPER(@p1)", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvPersonel.CurrentRow == null) { MessageBox.Show("Lütfen güncellenecek personeli seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            FrmPersonelGuncelle frm = new FrmPersonelGuncelle();
            frm.personelID = Convert.ToInt32(dgvPersonel.CurrentRow.Cells["PersonelID"].Value);
            frm.txtAdSoyad.Text = dgvPersonel.CurrentRow.Cells["Personel"].Value?.ToString() ?? "";
            
            // Gorev ComboBox yüklemesi ve seçilmesi
            frm.cmbGorev.Text = dgvPersonel.CurrentRow.Cells["Görev"].Value?.ToString() ?? "";
            frm.mskTelefon.Text = dgvPersonel.CurrentRow.Cells["Telefon"].Value?.ToString() ?? "";
            frm.txtMaas.Text = dgvPersonel.CurrentRow.Cells["Maaş"].Value?.ToString() ?? "";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Listele();
                Temizle();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (dgvPersonel.CurrentRow == null) { MessageBox.Show("Lütfen silinecek personeli seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            FrmPersonelSilOnay frm = new FrmPersonelSilOnay();
            frm.personelID = Convert.ToInt32(dgvPersonel.CurrentRow.Cells["PersonelID"].Value);
            frm.txtAdSoyad.Text = dgvPersonel.CurrentRow.Cells["Personel"].Value?.ToString() ?? "";
            frm.txtGorev.Text = dgvPersonel.CurrentRow.Cells["Görev"].Value?.ToString() ?? "";
            frm.txtMaas.Text = dgvPersonel.CurrentRow.Cells["Maaş"].Value?.ToString() ?? "";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Listele();
                Temizle();
            }
        }

        void Temizle()
        {
            txtAd.Clear();
            cmbGorev.SelectedIndex = -1;
            mskTel.Clear();
            txtMaas.Clear();
            txtAd.BackColor = Color.White;
            cmbGorev.BackColor = Color.White;
            mskTel.BackColor = Color.White;
            txtMaas.BackColor = Color.White;
        }

        // Tablodan bir satıra tıklayınca verileri sol taraftaki kutulara aktarır
        private void DgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPersonel.Rows[e.RowIndex];
                txtAd.Text = row.Cells["Personel"].Value?.ToString() ?? "";
                cmbGorev.Text = row.Cells["Görev"].Value?.ToString() ?? "";
                mskTel.Text = row.Cells["Telefon"].Value?.ToString() ?? "";
                txtMaas.Text = row.Cells["Maaş"].Value?.ToString() ?? "";
            }
        }

        void Listele()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    string sorgu = "SELECT PersonelID, AdSoyad as [Personel], Gorev as [Görev], Telefon, Maas as [Maaş] FROM Personeller";
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPersonel.DataSource = dt;

                    dgvPersonel.Columns["PersonelID"].Visible = false;
                    dgvPersonel.Columns["Personel"].HeaderText = "PERSONEL AD SOYAD";
                    dgvPersonel.Columns["Görev"].HeaderText = "GÖREVİ";
                    dgvPersonel.Columns["Telefon"].HeaderText = "İLETİŞİM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablo ayarları sırasında hata: " + ex.Message);
            }
        }

        /// <summary>
        /// Verilen sütun adı, aranan metin ve ComboBox indeksine göre RowFilter koşulu üretir.
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

        private void FiltreUygula()
        {
            if (!(dgvPersonel.DataSource is DataTable dt)) return;

            try
            {
                string adAranan   = txtAramaAdSoyad.Text.Replace("'", "''").Trim();
                string gorevAranan = txtAramaGorev.Text.Replace("'", "''").Trim();

                // MaskedTextBox re-entrancy koruması
                mskAramaTel.TextChanged -= mskAramaTel_TextChanged;
                mskAramaTel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string rawTel = mskAramaTel.Text.Replace("'", "''").Trim();
                mskAramaTel.TextMaskFormat = MaskFormat.IncludeLiterals;
                string formattedTel = mskAramaTel.Text.Replace("'", "''").Trim();
                mskAramaTel.TextChanged += mskAramaTel_TextChanged;

                string filtre = "";

                // 1. Ad Soyad Filtresi
                if (!string.IsNullOrEmpty(adAranan))
                {
                    filtre = AramaKosulu("Personel", adAranan, cmbAdSoyadModu.SelectedIndex);
                }

                // 2. Görev Filtresi
                if (!string.IsNullOrEmpty(gorevAranan))
                {
                    string gorevFiltre = AramaKosulu("[Görev]", gorevAranan, cmbGorevModu.SelectedIndex);

                    if (!string.IsNullOrEmpty(filtre))
                        filtre += " AND " + gorevFiltre;
                    else
                        filtre = gorevFiltre;
                }

                // 3. Telefon Filtresi
                if (!string.IsNullOrEmpty(rawTel))
                {
                    string telFiltre;
                    int mod = cmbTelModu.SelectedIndex;

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
            catch { }
        }

        private void mskAramaTel_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void txtAramaGorev_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}