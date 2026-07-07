using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmStokYonetimi : Form
    {
        private readonly SqlBaglanti bgl = new SqlBaglanti();

        public FrmStokYonetimi()
        {
            InitializeComponent();
            this.Load += FrmStokYonetimi_Load;
        }

        private void FrmStokYonetimi_Load(object sender, EventArgs e)
        {
            GridAyarlariniYap();
            StokListele();

            // IMEI Arama kutusuna sadece sayı ve kontrol tuşları girilebilsin
            this.txtArama2.KeyPress += (s, ev) => {
                ev.Handled = !char.IsDigit(ev.KeyChar) && !char.IsControl(ev.KeyChar);
            };
        }

        private void GridAyarlariniYap()
        {
            dgvStok.ReadOnly = true;
            dgvStok.AllowUserToAddRows = false;
            dgvStok.AllowUserToDeleteRows = false;
            dgvStok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStok.MultiSelect = false;
            dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStok.RowHeadersVisible = false;
            dgvStok.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvStok.BackgroundColor = System.Drawing.Color.White;
            dgvStok.EnableHeadersVisualStyles = false;
            dgvStok.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgvStok.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvStok.ColumnHeadersHeight = 35;
        }

        public void StokListele()
        {
            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    string sql = @"SELECT U.UrunID, M.MarkaAd as [Marka], K.KategoriAd as [Kategori], 
                                  U.Model, U.IMEI, U.StokAdet as [Stok], U.SatisFiyat as [Fiyat]
                                  FROM Urunler U 
                                  INNER JOIN Markalar M ON U.MarkaID = M.MarkaID 
                                  INNER JOIN Kategoriler K ON U.KategoriID = K.KategoriID";

                    SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStok.DataSource = null;
                    dgvStok.DataSource = dt;

                    if (dgvStok.Columns["UrunID"] != null)
                        dgvStok.Columns["UrunID"].Visible = false;

                    IstatistikGuncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IstatistikGuncelle()
        {
            if (dgvStok.DataSource is DataTable dt)
            {
                var view = dt.DefaultView;
                object toplamStok = dt.Compute("Sum(Stok)", view.RowFilter);
                lblIstatistik.Text = $"Sonuç: {view.Count} Kayıt | Toplam Stok: {(toplamStok == DBNull.Value ? 0 : toplamStok)}";
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

        // Hem txtArama hem txtArama2 TextChanged'e, hem de ComboBox SelectedIndexChanged'e bağlı
        private void TxtArama_TextChanged(object sender, EventArgs e)
        {
            if (!(dgvStok.DataSource is DataTable dt)) return;

            string modelMarkaFilter = txtArama.Text.Trim().Replace("'", "''");
            string imeiFilter = txtArama2.Text.Trim().Replace("'", "''");

            string rowFilter = "";
            int modelMod = cmbModelModu.SelectedIndex;
            int imeiMod  = cmbIMEIModu.SelectedIndex;

            // Model / Marka Filtresi
            if (!string.IsNullOrEmpty(modelMarkaFilter))
            {
                // Model veya Marka sütunlarından herhangi birinde ara
                string modelKosul = AramaKosulu("Model", modelMarkaFilter, modelMod);
                string markaKosul = AramaKosulu("Marka", modelMarkaFilter, modelMod);
                rowFilter = string.Format("({0} OR {1})", modelKosul, markaKosul);
            }

            // IMEI Filtresi
            if (!string.IsNullOrEmpty(imeiFilter))
            {
                string imeiCond = AramaKosulu("IMEI", imeiFilter, imeiMod);

                if (!string.IsNullOrEmpty(rowFilter))
                    rowFilter += " AND " + imeiCond;
                else
                    rowFilter = imeiCond;
            }

            try
            {
                dt.DefaultView.RowFilter = rowFilter;
            }
            catch { }

            IstatistikGuncelle();
        }

        private void btnYeniUrun_Click(object sender, EventArgs e)
        {
            FrmUrunEkle fr = new FrmUrunEkle { urunID = 0 };
            if (fr.ShowDialog() == DialogResult.OK)
            {
                StokListele();
            }
        }

        private void btnHizliGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvStok.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek satırı seçin.");
                return;
            }

            FrmUrunEkle fr = new FrmUrunEkle();
            var row = dgvStok.CurrentRow;

            fr.urunID = Convert.ToInt32(row.Cells["UrunID"].Value);
            fr.cmbMarka.Text = row.Cells["Marka"].Value.ToString();
            fr.cmbKategori.Text = row.Cells["Kategori"].Value.ToString();
            fr.txtModel.Text = row.Cells["Model"].Value.ToString();
            fr.txtIMEI.Text = row.Cells["IMEI"].Value.ToString();
            fr.txtSatisFiyat.Text = row.Cells["Fiyat"].Value.ToString();
            fr.nudStok.Value = Convert.ToDecimal(row.Cells["Stok"].Value);

            fr.Text = "Ürün Güncelleme";
            fr.btnKaydet.Text = "GÜNCELLE";

            if (fr.ShowDialog() == DialogResult.OK) StokListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvStok.CurrentRow == null) return;

            FrmUrunSilOnay fr = new FrmUrunSilOnay();
            var row = dgvStok.CurrentRow;

            fr.silinecekID = Convert.ToInt32(row.Cells["UrunID"].Value);
            fr.txtMarka.Text = row.Cells["Marka"].Value?.ToString() ?? "";
            fr.txtModel.Text = row.Cells["Model"].Value?.ToString() ?? "";
            fr.txtIMEI.Text = row.Cells["IMEI"].Value?.ToString() ?? "";

            if (fr.ShowDialog() == DialogResult.OK)
            {
                StokListele();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            txtArama2.Clear();
            cmbModelModu.SelectedIndex = 0;
            cmbIMEIModu.SelectedIndex = 0;
            StokListele();
        }

        private void dgvStok_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}