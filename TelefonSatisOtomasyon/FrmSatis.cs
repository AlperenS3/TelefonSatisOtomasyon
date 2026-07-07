using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmSatis : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmSatis()
        {
            InitializeComponent();

            // --- HOCA KURALI: FORM AUTO SIZE ---
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // --- ETKİLEŞİM MÜHÜRLERİ ---
            this.btnKaydet.Click += btnKaydet_Click;
            this.btnSil.Click += btnSil_Click;
            this.btnGuncelle.Click += btnGuncelle_Click_1;
            this.btnTemizle.Click += (s, e) => Temizle();
            this.dataGridView1.CellClick += DataGridView1_CellClick;

            // NumericUpDown ve Textbox olayları (Uygun Nesne Kullanımı)
            this.nudAdet.ValueChanged += (s, e) => { RenkSifirla(nudAdet); Hesapla(); };
            this.txtFiyat.TextChanged += (s, e) => { RenkSifirla(txtFiyat); Hesapla(); };
            this.cmbTelefon.SelectedIndexChanged += (s, e) => { RenkSifirla(cmbTelefon); CmbTelefon_SelectedIndexChanged(s, e); };
            this.cmbMusteri.SelectedIndexChanged += (s, e) => RenkSifirla(cmbMusteri);

            // --- KARAKTER KORUMASI ---
            this.txtFiyat.KeyPress += (s, e) => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            VerileriYukle();
            SatislariListele();

            // --- HOCA KURALI: TAB SIRALAMASI ---
            cmbMusteri.TabIndex = 0;
            cmbTelefon.TabIndex = 1;
            nudAdet.TabIndex = 2;
            txtFiyat.TabIndex = 3;
            btnKaydet.TabIndex = 4;

            txtToplam.ReadOnly = true;
            txtToplam.BackColor = Color.LightYellow;

            // Grid Güvenlik Ayarları
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void RenkSifirla(Control c) { c.BackColor = Color.White; }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                cmbMusteri.Text = dataGridView1.CurrentRow.Cells["Müşteri"].Value.ToString();
                cmbTelefon.Text = dataGridView1.CurrentRow.Cells["Cihaz"].Value.ToString();
                nudAdet.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Adet"].Value);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!AlanlariKontrolEt()) return;

            if (dataGridView1.CurrentRow != null)
            {
                string seciliMusteri = dataGridView1.CurrentRow.Cells["Müşteri"].Value?.ToString() ?? "";
                string seciliCihaz = dataGridView1.CurrentRow.Cells["Cihaz"].Value?.ToString() ?? "";
                string seciliAdet = dataGridView1.CurrentRow.Cells["Adet"].Value?.ToString() ?? "";
                if (cmbMusteri.Text == seciliMusteri && cmbTelefon.Text == seciliCihaz && nudAdet.Value.ToString() == seciliAdet)
                {
                    MessageBox.Show("Seçili satış kaydının aynısını tekrar ekleyemezsiniz! Yeni bir satış eklemek istiyorsanız lütfen önce alanları düzenleyin veya Temizle butonuna tıklayın.", 
                        "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string onayMesaj = $"{cmbMusteri.Text} kişisine satış yapılacaktır. Onaylıyor musunuz?";
            if (MessageBox.Show(onayMesaj, "Satış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SatisYap();
            }
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen düzenlenecek satış kaydını seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmSatisGuncelle frm = new FrmSatisGuncelle();

            // --- HOCA KURALI: VERİ TAŞIMA ---
            frm.satisID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SatisID"].Value);
            frm.cmbMusteri.Text = dataGridView1.CurrentRow.Cells["Müşteri"].Value.ToString();
            frm.cmbCihaz.Text = dataGridView1.CurrentRow.Cells["Cihaz"].Value.ToString();
            frm.nudAdet.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Adet"].Value);

            decimal toplamTutar = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Toplam"].Value);
            frm.txtToplam.Text = toplamTutar.ToString("N2");

            if (frm.nudAdet.Value > 0)
                frm.txtBirimFiyat.Text = (toplamTutar / frm.nudAdet.Value).ToString("N2");

            if (frm.ShowDialog() == DialogResult.OK)
            {
                SatislariListele();
                VerileriYukle();
                MessageBox.Show("Satış başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool AlanlariKontrolEt()
        {
            bool hataVar = false;
            if (cmbMusteri.SelectedIndex == -1) { cmbMusteri.BackColor = Color.MistyRose; hataVar = true; }
            if (cmbTelefon.SelectedIndex == -1) { cmbTelefon.BackColor = Color.MistyRose; hataVar = true; }
            if (nudAdet.Value <= 0) { nudAdet.BackColor = Color.MistyRose; hataVar = true; }
            if (string.IsNullOrWhiteSpace(txtFiyat.Text) || txtFiyat.Text == "0") { txtFiyat.BackColor = Color.MistyRose; hataVar = true; }

            if (hataVar) MessageBox.Show("Lütfen kırmızı alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return !hataVar;
        }

        private void SatisYap()
        {
            using (SqlConnection baglan = bgl.baglanti())
            {
                SqlCommand cmdStok = new SqlCommand("SELECT StokAdet FROM Urunler WHERE UrunID = @id", baglan);
                cmdStok.Parameters.AddWithValue("@id", cmbTelefon.SelectedValue);
                int mevcutStok = Convert.ToInt32(cmdStok.ExecuteScalar());
                int istenen = (int)nudAdet.Value;

                if (istenen > mevcutStok)
                {
                    MessageBox.Show($"Stok yetersiz! Mevcut: {mevcutStok}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlTransaction trans = baglan.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Satislar (MusteriID, UrunID, Adet, ToplamTutar, SatisTarihi) VALUES (@p1,@p2,@p3,@p4,@p5)", baglan, trans);
                    cmd.Parameters.AddWithValue("@p1", cmbMusteri.SelectedValue);
                    cmd.Parameters.AddWithValue("@p2", cmbTelefon.SelectedValue);
                    cmd.Parameters.AddWithValue("@p3", istenen);
                    cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtToplam.Text, NumberStyles.Currency));
                    cmd.Parameters.AddWithValue("@p5", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmdUp = new SqlCommand("UPDATE Urunler SET StokAdet = StokAdet - @s1 WHERE UrunID = @s2", baglan, trans);
                    cmdUp.Parameters.AddWithValue("@s1", istenen);
                    cmdUp.Parameters.AddWithValue("@s2", cmbTelefon.SelectedValue);
                    cmdUp.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Satış kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SatislariListele(); VerileriYukle(); Temizle();
                }
                catch (Exception ex) { trans.Rollback(); MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("İptal edilecek satışı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmSatisSilOnay frmSil = new FrmSatisSilOnay();
            frmSil.satisID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SatisID"].Value);
            frmSil.txtMusteri.Text = dataGridView1.CurrentRow.Cells["Müşteri"].Value.ToString();
            frmSil.txtCihaz.Text = dataGridView1.CurrentRow.Cells["Cihaz"].Value.ToString();
            frmSil.txtAdet.Text = dataGridView1.CurrentRow.Cells["Adet"].Value.ToString();
            frmSil.txtToplam.Text = dataGridView1.CurrentRow.Cells["Toplam"].Value.ToString() + " ₺";

            if (frmSil.ShowDialog() == DialogResult.OK)
            {
                SatislariListele();
                VerileriYukle();
            }
        }

        private void CmbTelefon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTelefon.SelectedValue != null && cmbTelefon.SelectedIndex != -1)
            {
                try
                {
                    using (SqlConnection baglan = bgl.baglanti())
                    {
                        SqlCommand cmd = new SqlCommand("SELECT SatisFiyat FROM Urunler WHERE UrunID = @p1", baglan);
                        cmd.Parameters.AddWithValue("@p1", cmbTelefon.SelectedValue);
                        object sonuc = cmd.ExecuteScalar();
                        if (sonuc != null) txtFiyat.Text = Convert.ToDecimal(sonuc).ToString("N2");
                    }
                }
                catch { }
            }
        }

        private void VerileriYukle()
        {
            using (SqlConnection baglan = bgl.baglanti())
            {
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT MusteriID, AdSoyad FROM Musteriler", baglan);
                DataTable dt1 = new DataTable(); da1.Fill(dt1);
                cmbMusteri.DisplayMember = "AdSoyad"; cmbMusteri.ValueMember = "MusteriID"; cmbMusteri.DataSource = dt1;

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT UrunID, Model FROM Urunler WHERE StokAdet > 0", baglan);
                DataTable dt2 = new DataTable(); da2.Fill(dt2);
                cmbTelefon.DisplayMember = "Model"; cmbTelefon.ValueMember = "UrunID"; cmbTelefon.DataSource = dt2;
            }
        }

        private void SatislariListele()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT S.SatisID, M.AdSoyad as [Müşteri], U.Model as [Cihaz], S.Adet, S.ToplamTutar as [Toplam] FROM Satislar S INNER JOIN Musteriler M ON S.MusteriID = M.MusteriID INNER JOIN Urunler U ON S.UrunID = U.UrunID ORDER BY S.SatisID DESC", bgl.baglanti());
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Hesapla()
        {
            decimal a = nudAdet.Value;
            decimal f = 0;
            decimal.TryParse(txtFiyat.Text, out f);
            // Finansal Format mühürleme
            txtToplam.Text = (a * f).ToString("N2");
        }

        private void Temizle()
        {
            cmbMusteri.SelectedIndex = -1; cmbTelefon.SelectedIndex = -1;
            nudAdet.Value = 1; txtFiyat.Clear(); txtToplam.Clear();
            RenkSifirla(cmbMusteri); RenkSifirla(cmbTelefon); RenkSifirla(nudAdet); RenkSifirla(txtFiyat);
        }
    }
}