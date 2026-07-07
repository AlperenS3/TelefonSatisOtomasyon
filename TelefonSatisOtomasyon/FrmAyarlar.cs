using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmAyarlar : Form
    {
        private readonly SqlBaglanti bgl = new SqlBaglanti();
        private readonly ErrorProvider ep = new ErrorProvider();

        public FrmAyarlar()
        {
            InitializeComponent();
            ButonlariVeOlaylariBagla();
        }

        private void ButonlariVeOlaylariBagla()
        {
            // --- HOCA KURALI: RENK SIFIRLAMA ---
            txtMarkaAd.TextChanged += (s, e) => TxtRenkSifirla(txtMarkaAd);
            txtKategoriAd.TextChanged += (s, e) => TxtRenkSifirla(txtKategoriAd);
            txtKullaniciAd.TextChanged += (s, e) => TxtRenkSifirla(txtKullaniciAd);
            txtSifre.TextChanged += (s, e) => TxtRenkSifirla(txtSifre);

            // --- KLAVYE KISITLAMALARI ---
            txtMarkaAd.KeyPress += SadeceHarf_KeyPress;
            txtKategoriAd.KeyPress += SadeceHarf_KeyPress;
            txtKullaniciAd.KeyPress += (s, e) => { if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true; };
            txtSifre.KeyPress += (s, e) => { if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true; };

            // --- BUTON BAĞLANTILARI ---
            btnMarkaSil.Click += btnMarkaSil_Click;
            btnKategoriSil.Click += btnKategoriSil_Click;
            btnKullaniciSil.Click += btnKullaniciSil_Click;
            btnMarkaGuncelle.Click += btnMarkaGuncelle_Click;
            btnKategoriGuncelle.Click += btnKategoriGuncelle_Click;
            btnKullaniciGuncelle.Click += btnKullaniciGuncelle_Click;
            btnMarkaEkle.Click += btnMarkaEkle_Click;
            btnKategoriEkle.Click += btnKategoriEkle_Click;
            btnKullaniciEkle.Click += btnKullaniciEkle_Click;

            dgvMarkalar.CellClick += dgvMarkalar_CellClick;
            dgvKategoriler.CellClick += dgvKategoriler_CellClick;
            dgvKullanicilar.CellClick += dgvKullanicilar_CellClick;
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            // KRİTİK: Yetkileri ComboBox'a kodla ekleyelim (Eğer tasarımda eklemediysen)
            if (cmbYetki.Items.Count == 0)
            {
                cmbYetki.Items.Add("Admin");
                cmbYetki.Items.Add("Personel");
            }

            Tazele();
            GridStil(dgvMarkalar); GridStil(dgvKategoriler); GridStil(dgvKullanicilar);
        }

        private void SadeceHarf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        void GridStil(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
        }

        void Tazele()
        {
            try
            {
                MarkalariGetir(); KategorileriGetir(); KullanicilariGetir();
                txtMarkaAd.Clear(); txtKategoriAd.Clear(); txtKullaniciAd.Clear(); txtSifre.Clear();
                TxtRenkSifirla(txtMarkaAd); TxtRenkSifirla(txtKategoriAd);
                TxtRenkSifirla(txtKullaniciAd); TxtRenkSifirla(txtSifre);

                // Seçimi temizle
                if (cmbYetki.Items.Count > 0) cmbYetki.SelectedIndex = -1;
            }
            catch { }
        }

        void TxtRenkSifirla(TextBox t) { t.BackColor = Color.White; ep.SetError(t, ""); }

        bool BoslukKontrol(TextBox t, string mesaj)
        {
            if (string.IsNullOrWhiteSpace(t.Text))
            {
                t.BackColor = Color.MistyRose;
                ep.SetError(t, mesaj);
                MessageBox.Show(mesaj, "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // --- LİSTELEME ---
        void MarkalariGetir() { SqlDataAdapter da = new SqlDataAdapter("SELECT MarkaID as ID, MarkaAd as [Marka Adı] FROM Markalar", bgl.baglanti()); DataTable dt = new DataTable(); da.Fill(dt); dgvMarkalar.DataSource = dt; }
        void KategorileriGetir() { SqlDataAdapter da = new SqlDataAdapter("SELECT KategoriID as ID, KategoriAd as [Kategori Adı] FROM Kategoriler", bgl.baglanti()); DataTable dt = new DataTable(); da.Fill(dt); dgvKategoriler.DataSource = dt; }
        void KullanicilariGetir() { SqlDataAdapter da = new SqlDataAdapter("SELECT KullaniciID as ID, KullaniciAd as [Kullanıcı], Sifre, Yetki FROM Kullanicilar", bgl.baglanti()); DataTable dt = new DataTable(); da.Fill(dt); dgvKullanicilar.DataSource = dt; }

        // --- GÜNCELLEME (DEĞİŞTİR) ---
        private void btnMarkaGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvMarkalar.CurrentRow == null) return;
            FrmAyarlarGuncelleOrtak frm = new FrmAyarlarGuncelleOrtak();
            frm.tabloAdi = "Marka";
            frm.kayitID = Convert.ToInt32(dgvMarkalar.CurrentRow.Cells["ID"].Value);
            frm.txt1.Text = dgvMarkalar.CurrentRow.Cells["Marka Adı"].Value.ToString();
            frm.lbl1.Text = "Marka Adı:";
            frm.lbl2.Visible = frm.txt2.Visible = frm.lblYetki.Visible = frm.cmbYetki.Visible = false;
            if (frm.ShowDialog() == DialogResult.OK) MarkalariGetir();
        }

        private void btnKategoriGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKategoriler.CurrentRow == null) return;
            FrmAyarlarGuncelleOrtak frm = new FrmAyarlarGuncelleOrtak();
            frm.tabloAdi = "Kategori";
            frm.kayitID = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells["ID"].Value);
            frm.txt1.Text = dgvKategoriler.CurrentRow.Cells["Kategori Adı"].Value.ToString();
            frm.lbl1.Text = "Kategori Adı:";
            frm.lbl2.Visible = frm.txt2.Visible = frm.lblYetki.Visible = frm.cmbYetki.Visible = false;
            if (frm.ShowDialog() == DialogResult.OK) KategorileriGetir();
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.CurrentRow == null) return;
            FrmAyarlarGuncelleOrtak frm = new FrmAyarlarGuncelleOrtak();
            frm.tabloAdi = "Kullanici";
            frm.kayitID = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells["ID"].Value);
            frm.txt1.Text = dgvKullanicilar.CurrentRow.Cells["Kullanıcı"].Value.ToString();
            frm.txt2.Text = dgvKullanicilar.CurrentRow.Cells["Sifre"].Value.ToString();

            // ComboBox'a yetkiyi taşıma
            frm.cmbYetki.Text = dgvKullanicilar.CurrentRow.Cells["Yetki"].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK) KullanicilariGetir();
        }

        // --- SİLME ---
        private void btnMarkaSil_Click(object sender, EventArgs e)
        {
            if (dgvMarkalar.CurrentRow == null) return;
            FrmAyarlarSilOnay frm = new FrmAyarlarSilOnay();
            frm.txtBilgi1.Text = dgvMarkalar.CurrentRow.Cells[0].Value.ToString();
            frm.txtBilgi2.Text = dgvMarkalar.CurrentRow.Cells[1].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK) GercekSilme("DELETE FROM Markalar WHERE MarkaID=@p1", dgvMarkalar.CurrentRow.Cells[0].Value);
        }

        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
            if (dgvKategoriler.CurrentRow == null) return;
            FrmAyarlarSilOnay frm = new FrmAyarlarSilOnay();
            frm.txtBilgi1.Text = dgvKategoriler.CurrentRow.Cells[0].Value.ToString();
            frm.txtBilgi2.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK) GercekSilme("DELETE FROM Kategoriler WHERE KategoriID=@p1", dgvKategoriler.CurrentRow.Cells[0].Value);
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.CurrentRow == null) return;
            if (dgvKullanicilar.CurrentRow.Cells[1].Value.ToString().ToLower() == "admin") { MessageBox.Show("Admin silinemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            FrmAyarlarSilOnay frm = new FrmAyarlarSilOnay();
            frm.txtBilgi1.Text = dgvKullanicilar.CurrentRow.Cells[1].Value.ToString();
            frm.txtBilgi2.Text = dgvKullanicilar.CurrentRow.Cells[3].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK) GercekSilme("DELETE FROM Kullanicilar WHERE KullaniciID=@p1", dgvKullanicilar.CurrentRow.Cells[0].Value);
        }

        void GercekSilme(string sorgu, object id)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", id);
                    cmd.ExecuteNonQuery();
                    Tazele();
                    MessageBox.Show("Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { MessageBox.Show("Kayıt kullanımda, silinemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // --- EKLEME VE SEÇİM ---
        private void btnMarkaEkle_Click(object sender, EventArgs e) { if (BoslukKontrol(txtMarkaAd, "Marka adı!")) MarkaIslem("INSERT INTO Markalar (MarkaAd) VALUES (@p1)"); }
        private void btnKategoriEkle_Click(object sender, EventArgs e) { if (BoslukKontrol(txtKategoriAd, "Kategori adı!")) KategoriIslem("INSERT INTO Kategoriler (KategoriAd) VALUES (@p1)"); }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (BoslukKontrol(txtKullaniciAd, "Kullanıcı adı!") && BoslukKontrol(txtSifre, "Şifre!"))
            {
                if (cmbYetki.SelectedIndex == -1) { MessageBox.Show("Lütfen yetki seçin!"); return; }
                KullaniciIslem("INSERT INTO Kullanicilar (KullaniciAd, Sifre, Yetki) VALUES (@p1,@p2,@p3)");
            }
        }

        void MarkaIslem(string sorgu) { using (SqlConnection conn = bgl.baglanti()) { SqlCommand cmd = new SqlCommand(sorgu, conn); cmd.Parameters.AddWithValue("@p1", txtMarkaAd.Text.Trim().ToUpper()); cmd.ExecuteNonQuery(); Tazele(); } }
        void KategoriIslem(string sorgu) { using (SqlConnection conn = bgl.baglanti()) { SqlCommand cmd = new SqlCommand(sorgu, conn); cmd.Parameters.AddWithValue("@p1", txtKategoriAd.Text.Trim().ToUpper()); cmd.ExecuteNonQuery(); Tazele(); } }
        void KullaniciIslem(string sorgu) { using (SqlConnection conn = bgl.baglanti()) { SqlCommand cmd = new SqlCommand(sorgu, conn); cmd.Parameters.AddWithValue("@p1", txtKullaniciAd.Text.Trim()); cmd.Parameters.AddWithValue("@p2", txtSifre.Text.Trim()); cmd.Parameters.AddWithValue("@p3", cmbYetki.Text); cmd.ExecuteNonQuery(); Tazele(); } }

        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e) { if (dgvMarkalar.CurrentRow != null) txtMarkaAd.Text = dgvMarkalar.CurrentRow.Cells[1].Value.ToString(); }
        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e) { if (dgvKategoriler.CurrentRow != null) txtKategoriAd.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString(); }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKullanicilar.CurrentRow != null)
            {
                txtKullaniciAd.Text = dgvKullanicilar.CurrentRow.Cells[1].Value.ToString();
                txtSifre.Text = dgvKullanicilar.CurrentRow.Cells[2].Value.ToString();

                // KRİTİK: Yetkiyi ComboBox'ta göster
                cmbYetki.Text = dgvKullanicilar.CurrentRow.Cells[3].Value.ToString();
            }
        }
    }
}