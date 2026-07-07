using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class Form1 : Form
    {
        private readonly SqlBaglanti bgl = new SqlBaglanti();

        public Form1()
        {
            InitializeComponent();
            ButonlariBagla();

            // --- HOCA KURALI: KLAVYE KISAYOL DESTEĞİ ---
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // X'e basınca arka planda açık kalmaması için uygulamayı tamamen kapatır
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                txtArama.Focus();
                txtArama.SelectAll();
                e.SuppressKeyPress = true; // Bip sesini engeller
            }
        }

        private void ButonlariBagla()
        {
            // === ÇİFT AÇILMA VE KAYMA HATASINI ENGELLEYEN EN KRİTİK DOKUNUŞ ===
            // Hem designer hem kod tarafındaki eski tüm click event'lerini tamamen sıfırlıyoruz.
            btnSinavIslemleri.Click -= btnSinavIslemleri_Click;

            // Sol Panel Buton Olayları
            btnDashboard.Click += (s, e) => ListeleVeGuncelle();
            btnAyarlar.Click += btnAyarlar_Click;
            btnKasa.Click += btnKasa_Click;
            btnMusteriler.Click += btnMusteriler_Click;
            btnSatislar.Click += btnSatislar_Click;
            btnStok.Click += btnStok_Click;
            btnTeknikServis.Click += btnTeknikServis_Click;
            btnPersonel.Click += btnPersonel_Click;
            btnTanimlamalar.Click += btnTanimlamalar_Click;
            btnRaporlar.Click += btnRaporlar_Click;

            // Şimdi sadece tek ve temiz bir bağlantı yapıyoruz
            btnSinavIslemleri.Click += btnSinavIslemleri_Click;
            btnCikis.Click += btnCikis_Click;

            // --- GENEL ARAMA ---
            txtArama.TextChanged += TxtArama_TextChanged;

            // --- GELİŞMİŞ FİLTRELEME: Gelişmiş Filtrele Checkbox ---
            chkDetayliArama.CheckedChanged += (s, e) =>
            {
                bool aktif = chkDetayliArama.Checked;
                chkMarkaArama.Visible = aktif;
                txtAramaMarka.Visible = aktif;
                cmbMarkaModu.Visible = aktif;
                chkModelArama.Visible = aktif;
                txtAramaModel.Visible = aktif;
                cmbModelModu.Visible = aktif;

                if (!aktif)
                {
                    chkMarkaArama.Checked = false;
                    chkModelArama.Checked = false;
                    txtAramaMarka.Clear();
                    txtAramaModel.Clear();
                    if (dataGridView1.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";
                }
            };

            // --- GELİŞMİŞ FİLTRELEME: Olayları bağla ---
            chkMarkaArama.CheckedChanged += (s, e) =>
            {
                txtAramaMarka.Enabled = chkMarkaArama.Checked;
                cmbMarkaModu.Enabled = chkMarkaArama.Checked;
                GelismisFiltrele();
            };
            chkModelArama.CheckedChanged += (s, e) =>
            {
                txtAramaModel.Enabled = chkModelArama.Checked;
                cmbModelModu.Enabled = chkModelArama.Checked;
                GelismisFiltrele();
            };

            txtAramaMarka.TextChanged += (s, e) => GelismisFiltrele();
            txtAramaModel.TextChanged += (s, e) => GelismisFiltrele();
            cmbMarkaModu.SelectedIndexChanged += (s, e) => GelismisFiltrele();
            cmbModelModu.SelectedIndexChanged += (s, e) => GelismisFiltrele();

            // --- TABLO MÜHÜRLEME AYARLARI ---
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void GelismisFiltrele()
        {
            try
            {
                if (!(dataGridView1.DataSource is DataTable dt)) return;
                if (!chkDetayliArama.Checked)
                {
                    dt.DefaultView.RowFilter = "";
                    return;
                }

                bool markaAktif = chkMarkaArama.Checked && !string.IsNullOrWhiteSpace(txtAramaMarka.Text);
                bool modelAktif = chkModelArama.Checked && !string.IsNullOrWhiteSpace(txtAramaModel.Text);

                string markaFiltre = markaAktif ? FiltreOlustur("Marka", txtAramaMarka.Text.Replace("'", "''"), cmbMarkaModu.SelectedIndex) : "";
                string modelFiltre = modelAktif ? FiltreOlustur("Model", txtAramaModel.Text.Replace("'", "''"), cmbModelModu.SelectedIndex) : "";

                string kombinFiltre = "";
                if (markaAktif && modelAktif)
                    kombinFiltre = $"({markaFiltre}) AND ({modelFiltre})";
                else if (markaAktif)
                    kombinFiltre = markaFiltre;
                else if (modelAktif)
                    kombinFiltre = modelFiltre;

                dt.DefaultView.RowFilter = kombinFiltre;
            }
            catch { }
        }

        private string FiltreOlustur(string sutun, string deger, int mod)
        {
            switch (mod)
            {
                case 1: return $"{sutun} LIKE '{deger}%'";
                case 2: return $"{sutun} LIKE '%{deger}'";
                case 3: return $"{sutun} = '{deger}'";
                default: return $"{sutun} LIKE '%{deger}%'";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListeleVeGuncelle();

            // Kontrolleri başlangıçta gizle
            chkMarkaArama.Visible = false;
            txtAramaMarka.Visible = false;
            cmbMarkaModu.Visible = false;
            chkModelArama.Visible = false;
            txtAramaModel.Visible = false;
            cmbModelModu.Visible = false;

            cmbMarkaModu.SelectedIndex = 0;
            cmbModelModu.SelectedIndex = 0;

            txtAramaMarka.Enabled = false;
            cmbMarkaModu.Enabled = false;
            txtAramaModel.Enabled = false;
            cmbModelModu.Enabled = false;
        }

        public void ListeleVeGuncelle()
        {
            string sorgu = @"SELECT U.UrunID, M.MarkaAd as [Marka], K.KategoriAd as [Kategori], 
                             U.Model, U.IMEI, U.StokAdet as [Stok], U.SatisFiyat as [Fiyat]
                             FROM Urunler U
                             INNER JOIN Markalar M ON U.MarkaID = M.MarkaID
                             INNER JOIN Kategoriler K ON U.KategoriID = K.KategoriID";

            VerileriGetir(sorgu, "Güncel Stok Durumu");
            IstatistikleriGuncelle();
        }

        public void VerileriGetir(string sorgu, string baslik)
        {
            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    lblStatus.Text = baslik + " | Toplam Kayıt: " + dt.Rows.Count;
                }
            }
            catch (Exception ex) { MessageBox.Show("Veri getirme hatası: " + ex.Message); }
        }

        private void IstatistikleriGuncelle()
        {
            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();

                    SqlCommand cmd1 = new SqlCommand("SELECT ISNULL(SUM(StokAdet), 0) FROM Urunler", baglan);
                    lblToplamStokAdet.Text = cmd1.ExecuteScalar().ToString();

                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Satislar WHERE CAST(SatisTarihi AS DATE) = CAST(GETDATE() AS DATE)", baglan);
                    lblToplamSatisAdet.Text = cmd2.ExecuteScalar().ToString();

                    SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Urunler WHERE StokAdet <= 2", baglan);
                    lblKritikStokAdet.Text = cmd3.ExecuteScalar().ToString();
                }
            }
            catch { }
        }

        private void TxtArama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource is DataTable dt)
                {
                    string aranan = txtArama.Text.Replace("'", "''");
                    if (string.IsNullOrWhiteSpace(aranan))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = string.Format(
                            "Marka LIKE '%{0}%' OR Model LIKE '%{0}%' OR IMEI LIKE '%{0}%' OR Kategori LIKE '%{0}%'",
                            aranan);
                    }
                    if (chkDetayliArama.Checked)
                    {
                        chkDetayliArama.Checked = false;
                    }
                }
            }
            catch { }
        }

        private void btnAyarlar_Click(object sender, EventArgs e) { cmsAyarlar.Show(btnAyarlar, new Point(btnAyarlar.Width, 0)); }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sistemden çıkış yapmak istiyor musunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        // ASIL VE TEK ÇALIŞACAK METOT
        private void btnSinavIslemleri_Click(object sender, EventArgs e)
        {
            FrmSinavIslemleri fr = new FrmSinavIslemleri();
            fr.ShowDialog();
        }

        private void btnKasa_Click(object sender, EventArgs e) { FrmKasa fr = new FrmKasa(); fr.ShowDialog(); IstatistikleriGuncelle(); }
        private void btnMusteriler_Click(object sender, EventArgs e) { FrmMusteriler fr = new FrmMusteriler(); fr.ShowDialog(); }
        private void btnSatislar_Click(object sender, EventArgs e) { FrmSatis fr = new FrmSatis(); fr.ShowDialog(); ListeleVeGuncelle(); }
        private void btnStok_Click(object sender, EventArgs e) { FrmStokYonetimi fr = new FrmStokYonetimi(); fr.ShowDialog(); ListeleVeGuncelle(); }
        private void btnTeknikServis_Click(object sender, EventArgs e) { FrmTeknikServis fr = new FrmTeknikServis(); fr.ShowDialog(); }
        private void btnPersonel_Click(object sender, EventArgs e) { FrmPersonel fr = new FrmPersonel(); fr.ShowDialog(); }
        private void btnTanimlamalar_Click(object sender, EventArgs e) { FrmTanimlamalar fr = new FrmTanimlamalar(); fr.ShowDialog(); }
        private void btnRaporlar_Click(object sender, EventArgs e) { FrmRaporlar fr = new FrmRaporlar(); fr.ShowDialog(); }
    }
}