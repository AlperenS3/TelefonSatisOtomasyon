using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmKasa : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        ErrorProvider ep = new ErrorProvider();

        public FrmKasa()
        {
            InitializeComponent();
            EtkinlikleriBagla();
        }

        private void EtkinlikleriBagla()
        {
            // Olayları bağlama
            this.Load += new EventHandler(FrmKasa_Load);
            this.btnGiderEkle.Click += btnGiderEkle_Click;
            this.btnGelirEkle.Click += btnGelirEkle_Click;
            this.btnGuncelle.Click += btnGuncelle_Click;
            this.btnSil.Click += btnSil_Click;
            this.btnTemizle.Click += (s, e) => Temizle();
            this.dgvKasa.CellClick += dgvKasa_CellClick;

            // --- HOCA KURALI: TAB SIRASI ---
            txtGiderTutar.TabIndex = 0;
            txtGiderAciklama.TabIndex = 1;
            btnGiderEkle.TabIndex = 2;
            btnGelirEkle.TabIndex = 3;

            // Yazmaya başlayınca kırmızı rengi temizleme
            txtGiderTutar.TextChanged += (s, e) => RenkTemizle(txtGiderTutar);
            txtGiderAciklama.TextChanged += (s, e) => RenkTemizle(txtGiderAciklama);

            // --- HOCA KURALI: SAYISAL ALAN FORMATI VE KONTROLÜ ---
            this.txtGiderTutar.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) e.Handled = true;
                // Sadece bir virgül izni
                if ((e.KeyChar == ',') && ((s as TextBox).Text.IndexOf(',') > -1)) e.Handled = true;
            };
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            OdemeTipleriniYukle();
            KasaVerileriniYukle();
            GridFormatla();
        }

        private void GridFormatla()
        {
            // --- HOCA KURALI: SATIR KOMPLE SEÇİLMELİ VE MANUEL DEĞİŞTİRME PASİF OLMALI ---
            dgvKasa.ReadOnly = true;
            dgvKasa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKasa.AllowUserToAddRows = false;
            dgvKasa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // --- ÖDEME TİPLERİ YÜKLEME ---
        private void OdemeTipleriniYukle()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT OdemeTipiAd FROM OdemeTipleri ORDER BY OdemeTipiAd", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbOdemeTipi.DisplayMember = "OdemeTipiAd";
                    cmbOdemeTipi.ValueMember = "OdemeTipiAd";
                    cmbOdemeTipi.DataSource = dt;
                    cmbOdemeTipi.SelectedIndex = -1;
                }
            }
            catch { /* OdemeTipleri tablosu henüz oluşturulmamış olabilir */ }
        }

        // --- HOCA KURALI: BOŞLUK KONTROLÜ, FOKUSLAMA VE KIZARTMA ---
        private bool KontrolEt()
        {
            bool durum = true;
            ep.Clear();

            if (string.IsNullOrWhiteSpace(txtGiderTutar.Text))
            {
                txtGiderTutar.BackColor = Color.MistyRose;
                ep.SetError(txtGiderTutar, "Tutar alanı boş bırakılamaz! (*)");
                txtGiderTutar.Focus();
                durum = false;
            }

            if (string.IsNullOrWhiteSpace(txtGiderAciklama.Text))
            {
                txtGiderAciklama.BackColor = Color.MistyRose;
                ep.SetError(txtGiderAciklama, "Açıklama alanı boş bırakılamaz! (*)");
                if (durum) txtGiderAciklama.Focus();
                durum = false;
            }

            if (!durum)
            {
                MessageBox.Show("Yıldızlı (*) ve kırmızı alanlar boş bırakılamaz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return durum;
        }

        private void RenkTemizle(TextBox txt)
        {
            if (!string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.White;
                ep.SetError(txt, "");
            }
        }

        public void KasaVerileriniYukle()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    string sql = "SELECT KasaID, IslemTipi as [Tür], Tutar, Aciklama, Tarih FROM Kasa ORDER BY KasaID DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKasa.DataSource = dt;
                    if (dgvKasa.Columns.Contains("KasaID")) dgvKasa.Columns["KasaID"].Visible = false;

                    // Dinamik Hesaplamalar
                    SqlCommand cmdGelir = new SqlCommand("SELECT ISNULL(SUM(Tutar), 0) FROM Kasa WHERE IslemTipi IN ('Satış', 'Teknik Servis', 'Gelir')", conn);
                    decimal gelir = Convert.ToDecimal(cmdGelir.ExecuteScalar());

                    SqlCommand cmdGider = new SqlCommand("SELECT ISNULL(SUM(Tutar), 0) FROM Kasa WHERE IslemTipi IN ('Gider', 'İptal')", conn);
                    decimal gider = Math.Abs(Convert.ToDecimal(cmdGider.ExecuteScalar()));

                    decimal netKasa = gelir - gider;

                    lblToplamGelir.Text = "GELİR: " + gelir.ToString("C2");
                    lblToplamGider.Text = "GİDER: " + gider.ToString("C2");
                    lblNetKasa.Text = "KASA: " + netKasa.ToString("C2");

                    lblNetKasa.ForeColor = netKasa >= 0 ? Color.DarkGreen : Color.DarkRed;
                }
            }
            catch (Exception ex) { MessageBox.Show("Veri Yükleme Hatası: " + ex.Message); }
        }

        private void btnGiderEkle_Click(object sender, EventArgs e)
        {
            if (KontrolEt())
            {
                if (dgvKasa.CurrentRow != null)
                {
                    string seciliTutar = dgvKasa.CurrentRow.Cells["Tutar"].Value?.ToString() ?? "";
                    string seciliAciklama = dgvKasa.CurrentRow.Cells["Aciklama"].Value?.ToString() ?? "";
                    if (txtGiderTutar.Text.Trim() == seciliTutar.Trim() && txtGiderAciklama.Text.Trim() == seciliAciklama.Trim())
                    {
                        MessageBox.Show("Seçili kasa kaydının aynısını tekrar ekleyemezsiniz! Yeni bir kayıt eklemek istiyorsanız lütfen önce alanları düzenleyin veya Temizle butonuna tıklayın.", 
                            "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (MessageBox.Show("Gider kaydı eklemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    KasaIslemiYap("INSERT INTO Kasa (IslemTipi, Tutar, Aciklama, Tarih) VALUES ('Gider', @p1, @p2, GETDATE())", false);
            }
        }

        private void btnGelirEkle_Click(object sender, EventArgs e)
        {
            if (KontrolEt())
            {
                if (dgvKasa.CurrentRow != null)
                {
                    string seciliTutar = dgvKasa.CurrentRow.Cells["Tutar"].Value?.ToString() ?? "";
                    string seciliAciklama = dgvKasa.CurrentRow.Cells["Aciklama"].Value?.ToString() ?? "";
                    if (txtGiderTutar.Text.Trim() == seciliTutar.Trim() && txtGiderAciklama.Text.Trim() == seciliAciklama.Trim())
                    {
                        MessageBox.Show("Seçili kasa kaydının aynısını tekrar ekleyemezsiniz! Yeni bir kayıt eklemek istiyorsanız lütfen önce alanları düzenleyin veya Temizle butonuna tıklayın.", 
                            "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (MessageBox.Show("Gelir kaydı eklemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    KasaIslemiYap("INSERT INTO Kasa (IslemTipi, Tutar, Aciklama, Tarih) VALUES ('Gelir', @p1, @p2, GETDATE())", false);
            }
        }

        // --- HOCA KURALI: AYRI SAYFADA DÜZENLEME VE VERİ GÖNDERME ---
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKasa.CurrentRow == null) return;

            string tur = dgvKasa.CurrentRow.Cells["Tür"].Value.ToString();
            if (tur != "Gider" && tur != "Gelir")
            {
                MessageBox.Show("Sadece manuel kayıtlar düzenlenebilir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmKasaGuncelle frm = new FrmKasaGuncelle();
            // Veri taşıma
            frm.kasaID = Convert.ToInt32(dgvKasa.CurrentRow.Cells["KasaID"].Value);
            frm.txtTutar.Text = dgvKasa.CurrentRow.Cells["Tutar"].Value.ToString();
            frm.rchAciklama.Text = dgvKasa.CurrentRow.Cells["Aciklama"].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                KasaVerileriniYukle();
                Temizle();
            }
        }

        // --- HOCA KURALI: AYRI SAYFADA SİLME ONAYI VE VERİ GÖNDERME ---
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKasa.CurrentRow == null) return;

            FrmKasaSilOnay frmSil = new FrmKasaSilOnay();
            // Veri taşıma (Metin kutuları pasif olmalı kuralı FrmKasaSilOnay tasarımında yapılmalı)
            frmSil.kasaID = Convert.ToInt32(dgvKasa.CurrentRow.Cells["KasaID"].Value);
            frmSil.txtTur.Text = dgvKasa.CurrentRow.Cells["Tür"].Value.ToString();
            frmSil.txtTutar.Text = dgvKasa.CurrentRow.Cells["Tutar"].Value.ToString() + " ₺";
            frmSil.txtAciklama.Text = dgvKasa.CurrentRow.Cells["Aciklama"].Value.ToString();

            if (frmSil.ShowDialog() == DialogResult.OK)
            {
                KasaVerileriniYukle();
                Temizle();
            }
        }

        void KasaIslemiYap(string sorgu, bool isUpdate)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", decimal.Parse(txtGiderTutar.Text));
                    cmd.Parameters.AddWithValue("@p2", txtGiderAciklama.Text.Trim());
                    if (isUpdate) cmd.Parameters.AddWithValue("@pID", dgvKasa.CurrentRow.Cells["KasaID"].Value);
                    cmd.ExecuteNonQuery();
                    KasaVerileriniYukle();
                    Temizle();
                    MessageBox.Show("İşlem başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void Temizle()
        {
            ep.Clear();
            txtGiderTutar.Clear();
            txtGiderAciklama.Clear();
            cmbOdemeTipi.SelectedIndex = -1;
            txtGiderTutar.BackColor = Color.White;
            txtGiderAciklama.BackColor = Color.White;
        }

        private void dgvKasa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKasa.CurrentRow != null)
            {
                txtGiderTutar.Text = dgvKasa.CurrentRow.Cells["Tutar"].Value.ToString();
                txtGiderAciklama.Text = dgvKasa.CurrentRow.Cells["Aciklama"].Value.ToString();
                RenkTemizle(txtGiderTutar);
                RenkTemizle(txtGiderAciklama);
            }
        }

        private void FrmKasa_Load_1(object sender, EventArgs e)
        {
            
        }
    }
}