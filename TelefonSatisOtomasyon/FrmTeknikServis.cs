using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace TelefonSatisOtomasyon
{
    public partial class FrmTeknikServis : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmTeknikServis()
        {
            InitializeComponent();

            // --- HOCA KURALI: FORM AUTO SIZE ---
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Olayları Bağla
            btnKaydet.Click += btnKaydet_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnTemizle.Click += (s, e) => Temizle();
            dgvServis.CellClick += dgvServis_CellClick;

            // --- ARAMA PANELİ OLAYLARI ---
            chkDetayliArama.CheckedChanged += (s, e) => { pnlGelismisArama.Visible = chkDetayliArama.Checked; Filtrele(); };
            txtArama.TextChanged += (s, e) => Filtrele();
            txtBirebirArama.TextChanged += (s, e) => { if (chkAktifFiltre.Checked) Filtrele(); };
            chkAktifFiltre.CheckedChanged += (s, e) => Filtrele();
            chkBirebir.CheckedChanged += (s, e) => { if (chkAktifFiltre.Checked) Filtrele(); };

            // Karakter Kısıtlamaları
            txtFiyat.KeyPress += SadeceSayiVeVirgul_KeyPress;
            txtIMEI.KeyPress += SadeceSayi_KeyPress;
            txtIMEI.MaxLength = 15;

            // Kızartma Temizleme
            txtCihaz.TextChanged += (s, e) => (s as TextBox).BackColor = Color.White;
            txtIMEI.TextChanged += (s, e) => (s as TextBox).BackColor = Color.White;
            txtAriza.TextChanged += (s, e) => (s as TextBox).BackColor = Color.White;
            txtFiyat.TextChanged += (s, e) => (s as TextBox).BackColor = Color.White;
        }

        private void FrmTeknikServis_Load(object sender, EventArgs e)
        {
            ServisListele();
            MusteriDoldur();
            DurumlariYukle();

            // --- HOCA KURALI: TAB SIRALAMASI ---
            cmbMusteri.TabIndex = 0;
            txtCihaz.TabIndex = 1;
            txtIMEI.TabIndex = 2;
            txtAriza.TabIndex = 3;
            cmbDurum.TabIndex = 4;
            txtFiyat.TabIndex = 5;
            btnKaydet.TabIndex = 6;
            txtArama.TabIndex = 7;

            // Liste Güvenlik Ayarları
            dgvServis.ReadOnly = true;
            dgvServis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServis.AllowUserToAddRows = false;
            dgvServis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pnlGelismisArama.Visible = false; // Başlangıçta kapalı
        }

        // --- GELİŞMİŞ FİLTRELEME MANTIĞI ---
        private void Filtrele()
        {
            try
            {
                DataTable dt = (DataTable)dgvServis.DataSource;
                if (dt == null) return;

                // Temel Filtre: Hızlı Arama (Müşteri Adı veya Cihaz Modelinde arar)
                string aranan = txtArama.Text.Trim().Replace("'", "''");
                string filtre = string.Format("([Müşteri] LIKE '%{0}%' OR [Cihaz] LIKE '%{0}%')", aranan);

                // Panel aktifse ve Aktif Filtre seçiliyse IMEI bazlı daraltma yap
                if (chkDetayliArama.Checked && chkAktifFiltre.Checked && !string.IsNullOrWhiteSpace(txtBirebirArama.Text))
                {
                    string imeiAranan = txtBirebirArama.Text.Trim().Replace("'", "''");
                    if (chkBirebir.Checked)
                        filtre += string.Format(" AND [IMEI] = '{0}'", imeiAranan);
                    else
                        filtre += string.Format(" AND [IMEI] LIKE '%{0}%'", imeiAranan);
                }

                dt.DefaultView.RowFilter = filtre;
            }
            catch { }
        }

        private void SadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SadeceSayiVeVirgul_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) e.Handled = true;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1)) e.Handled = true;
        }

        private bool BosAlanKontrolu()
        {
            bool hataVar = false;
            Control[] kontroller = { cmbMusteri, txtCihaz, txtIMEI, txtAriza, cmbDurum, txtFiyat };

            foreach (var c in kontroller)
            {
                if (string.IsNullOrWhiteSpace(c.Text) || c.Text == "0")
                {
                    c.BackColor = Color.MistyRose;
                    hataVar = true;
                }
                else { c.BackColor = Color.White; }
            }

            if (hataVar)
                MessageBox.Show("İşaretli alanlar boş bırakılamaz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return hataVar;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (BosAlanKontrolu()) return;

            string imei = txtIMEI.Text.Trim();
            string cihaz = txtCihaz.Text.Trim().ToUpper();
            if (ServisKaydiVarMi(imei, cihaz))
            {
                txtIMEI.BackColor = Color.MistyRose;
                txtCihaz.BackColor = Color.MistyRose;
                MessageBox.Show("Bu IMEI numaralı ve cihaz modelli aktif bir servis kaydı zaten mevcut!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yeni teknik servis kaydı eklenecektir. Onaylıyor musunuz?", "Kayıt Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = bgl.baglanti())
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO TeknikServis (MusteriID, CihazModel, IMEI, ArizaDetay, Durum, TahminiFiyat) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
                        cmd.Parameters.AddWithValue("@p1", cmbMusteri.SelectedValue);
                        cmd.Parameters.AddWithValue("@p2", txtCihaz.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@p3", txtIMEI.Text.Trim());
                        cmd.Parameters.AddWithValue("@p4", txtAriza.Text.Trim());
                        cmd.Parameters.AddWithValue("@p5", cmbDurum.Text);
                        cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtFiyat.Text.Replace(".", ",")));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Servis kaydı başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ServisListele(); Temizle();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvServis.CurrentRow == null)
            {
                MessageBox.Show("Lütfen düzenlenecek servis kaydını seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmServisGuncelle frm = new FrmServisGuncelle();
            frm.servisID = Convert.ToInt32(dgvServis.CurrentRow.Cells["ServisID"].Value);
            frm.cmbMusteri.Text = dgvServis.CurrentRow.Cells["Müşteri"].Value.ToString();
            frm.txtCihaz.Text = dgvServis.CurrentRow.Cells["Cihaz"].Value.ToString();
            frm.txtIMEI.Text = dgvServis.CurrentRow.Cells["IMEI"].Value.ToString();
            frm.rchAriza.Text = dgvServis.CurrentRow.Cells["Arıza"].Value.ToString();
            frm.cmbDurum.Text = dgvServis.CurrentRow.Cells["Durum"].Value.ToString();
            frm.txtFiyat.Text = dgvServis.CurrentRow.Cells["Ücret"].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ServisListele();
                Temizle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvServis.CurrentRow == null) return;

            FrmServisSilOnay frmSil = new FrmServisSilOnay();
            frmSil.servisID = Convert.ToInt32(dgvServis.CurrentRow.Cells["ServisID"].Value);
            frmSil.txtMusteri.Text = dgvServis.CurrentRow.Cells["Müşteri"].Value.ToString();
            frmSil.txtCihaz.Text = dgvServis.CurrentRow.Cells["Cihaz"].Value.ToString();
            frmSil.txtAriza.Text = dgvServis.CurrentRow.Cells["Arıza"].Value.ToString();
            frmSil.txtUcret.Text = dgvServis.CurrentRow.Cells["Ücret"].Value.ToString() + " ₺";

            if (frmSil.ShowDialog() == DialogResult.OK)
            {
                ServisListele();
                Temizle();
            }
        }

        void ServisListele()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    string sql = @"SELECT S.ServisID, M.AdSoyad as [Müşteri], S.CihazModel as [Cihaz], S.IMEI, S.ArizaDetay as [Arıza], S.Durum, S.TahminiFiyat as [Ücret] 
                                   FROM TeknikServis S INNER JOIN Musteriler M ON S.MusteriID = M.MusteriID ORDER BY S.ServisID DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvServis.DataSource = dt;
                    if (dgvServis.Columns.Contains("ServisID")) dgvServis.Columns["ServisID"].Visible = false;
                }
            }
            catch { }
        }

        void MusteriDoldur()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MusteriID, AdSoyad FROM Musteriler ORDER BY AdSoyad", bgl.baglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbMusteri.DisplayMember = "AdSoyad";
                cmbMusteri.ValueMember = "MusteriID";
                cmbMusteri.DataSource = dt;
                cmbMusteri.SelectedIndex = -1;
            }
            catch { }
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
                    cmbDurum.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private void dgvServis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServis.CurrentRow == null) return;
            txtCihaz.Text = dgvServis.CurrentRow.Cells["Cihaz"].Value.ToString();
            txtIMEI.Text = dgvServis.CurrentRow.Cells["IMEI"].Value.ToString();
            txtAriza.Text = dgvServis.CurrentRow.Cells["Arıza"].Value.ToString();
            cmbDurum.Text = dgvServis.CurrentRow.Cells["Durum"].Value.ToString();
            txtFiyat.Text = dgvServis.CurrentRow.Cells["Ücret"].Value.ToString();

            foreach (Control c in this.Controls) if (c is TextBox || c is ComboBox) c.BackColor = Color.White;
        }

        void Temizle()
        {
            txtCihaz.Clear(); txtIMEI.Clear(); txtAriza.Clear(); txtFiyat.Clear();
            txtArama.Clear(); txtBirebirArama.Clear();
            chkDetayliArama.Checked = false;
            cmbMusteri.SelectedIndex = -1; cmbDurum.SelectedIndex = -1;
            foreach (Control c in this.Controls) if (c is TextBox || c is ComboBox) c.BackColor = Color.White;
            cmbMusteri.Focus();
            Filtrele();
        }

        private bool ServisKaydiVarMi(string imei, string cihaz)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TeknikServis WHERE IMEI = @p1 AND CihazModel = @p2 AND Durum <> N'Teslim Edildi'", conn);
                    cmd.Parameters.AddWithValue("@p1", imei.Trim());
                    cmd.Parameters.AddWithValue("@p2", cihaz.Trim().ToUpper());
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }
    }
}