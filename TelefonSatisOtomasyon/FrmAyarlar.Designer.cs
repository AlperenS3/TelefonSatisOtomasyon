namespace TelefonSatisOtomasyon
{
    partial class FrmAyarlar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMarkalar, dgvKategoriler, dgvKullanicilar;
        private System.Windows.Forms.TextBox txtMarkaAd, txtKategoriAd, txtKullaniciAd, txtSifre;
        private System.Windows.Forms.ComboBox cmbYetki;
        private System.Windows.Forms.Button btnMarkaEkle, btnMarkaSil, btnKategoriEkle, btnKategoriSil, btnKullaniciEkle, btnKullaniciSil;
        private System.Windows.Forms.Button btnMarkaGuncelle, btnKategoriGuncelle, btnKullaniciGuncelle;
        private System.Windows.Forms.GroupBox grpMarka, grpKategori, grpKullanici;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMarkalar = new System.Windows.Forms.DataGridView();
            this.dgvKategoriler = new System.Windows.Forms.DataGridView();
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.txtMarkaAd = new System.Windows.Forms.TextBox();
            this.txtKategoriAd = new System.Windows.Forms.TextBox();
            this.txtKullaniciAd = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.cmbYetki = new System.Windows.Forms.ComboBox();
            this.btnMarkaEkle = new System.Windows.Forms.Button();
            this.btnMarkaSil = new System.Windows.Forms.Button();
            this.btnMarkaGuncelle = new System.Windows.Forms.Button();
            this.btnKategoriEkle = new System.Windows.Forms.Button();
            this.btnKategoriSil = new System.Windows.Forms.Button();
            this.btnKategoriGuncelle = new System.Windows.Forms.Button();
            this.btnKullaniciEkle = new System.Windows.Forms.Button();
            this.btnKullaniciSil = new System.Windows.Forms.Button();
            this.btnKullaniciGuncelle = new System.Windows.Forms.Button();
            this.grpMarka = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.grpKategori = new System.Windows.Forms.GroupBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.grpKullanici = new System.Windows.Forms.GroupBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategoriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.grpMarka.SuspendLayout();
            this.grpKategori.SuspendLayout();
            this.grpKullanici.SuspendLayout();
            this.SuspendLayout();

            // --- Ortak DataGridView Stili ---
            style.BackColor = System.Drawing.Color.White;
            style.Font = new System.Drawing.Font("Segoe UI", 9F);
            style.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            style.ForeColor = System.Drawing.Color.Black;

            // --- MARKA YÖNETİMİ ---
            this.grpMarka.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvMarkalar, this.lbl1, this.txtMarkaAd, this.btnMarkaEkle, this.btnMarkaGuncelle, this.btnMarkaSil });
            this.grpMarka.Location = new System.Drawing.Point(12, 12);
            this.grpMarka.Size = new System.Drawing.Size(380, 500);
            this.grpMarka.Text = "Marka Yönetimi";
            this.grpMarka.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpMarka.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);

            this.dgvMarkalar.Location = new System.Drawing.Point(10, 30);
            this.dgvMarkalar.Size = new System.Drawing.Size(360, 260);
            this.dgvMarkalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMarkalar.DefaultCellStyle = style;

            this.lbl1.Location = new System.Drawing.Point(10, 305);
            this.lbl1.Text = "Marka Adı:";
            this.lbl1.ForeColor = System.Drawing.Color.DimGray;

            this.txtMarkaAd.Location = new System.Drawing.Point(10, 328);
            this.txtMarkaAd.Size = new System.Drawing.Size(360, 25);

            this.btnMarkaEkle.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnMarkaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkaEkle.ForeColor = System.Drawing.Color.White;
            this.btnMarkaEkle.Location = new System.Drawing.Point(10, 370);
            this.btnMarkaEkle.Size = new System.Drawing.Size(115, 40);
            this.btnMarkaEkle.Text = "Ekle";
            this.btnMarkaEkle.FlatAppearance.BorderSize = 0;

            this.btnMarkaGuncelle.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnMarkaGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkaGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnMarkaGuncelle.Location = new System.Drawing.Point(132, 370);
            this.btnMarkaGuncelle.Size = new System.Drawing.Size(115, 40);
            this.btnMarkaGuncelle.Text = "Güncelle";
            this.btnMarkaGuncelle.FlatAppearance.BorderSize = 0;

            this.btnMarkaSil.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnMarkaSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkaSil.ForeColor = System.Drawing.Color.White;
            this.btnMarkaSil.Location = new System.Drawing.Point(255, 370);
            this.btnMarkaSil.Size = new System.Drawing.Size(115, 40);
            this.btnMarkaSil.Text = "Sil";
            this.btnMarkaSil.FlatAppearance.BorderSize = 0;

            // --- KATEGORİ YÖNETİMİ ---
            this.grpKategori.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvKategoriler, this.lbl2, this.txtKategoriAd, this.btnKategoriEkle, this.btnKategoriGuncelle, this.btnKategoriSil });
            this.grpKategori.Location = new System.Drawing.Point(405, 12);
            this.grpKategori.Size = new System.Drawing.Size(380, 500);
            this.grpKategori.Text = "Kategori Yönetimi";
            this.grpKategori.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpKategori.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);

            this.dgvKategoriler.Location = new System.Drawing.Point(10, 30);
            this.dgvKategoriler.Size = new System.Drawing.Size(360, 260);
            this.dgvKategoriler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKategoriler.DefaultCellStyle = style;

            this.lbl2.Location = new System.Drawing.Point(10, 305);
            this.lbl2.Text = "Kategori Adı:";
            this.lbl2.ForeColor = System.Drawing.Color.DimGray;

            this.txtKategoriAd.Location = new System.Drawing.Point(10, 328);
            this.txtKategoriAd.Size = new System.Drawing.Size(360, 25);

            this.btnKategoriEkle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnKategoriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriEkle.ForeColor = System.Drawing.Color.White;
            this.btnKategoriEkle.Location = new System.Drawing.Point(10, 370);
            this.btnKategoriEkle.Size = new System.Drawing.Size(115, 40);
            this.btnKategoriEkle.Text = "Ekle";
            this.btnKategoriEkle.FlatAppearance.BorderSize = 0;

            this.btnKategoriGuncelle.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnKategoriGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnKategoriGuncelle.Location = new System.Drawing.Point(132, 370);
            this.btnKategoriGuncelle.Size = new System.Drawing.Size(115, 40);
            this.btnKategoriGuncelle.Text = "Güncelle";
            this.btnKategoriGuncelle.FlatAppearance.BorderSize = 0;

            this.btnKategoriSil.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnKategoriSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriSil.ForeColor = System.Drawing.Color.White;
            this.btnKategoriSil.Location = new System.Drawing.Point(255, 370);
            this.btnKategoriSil.Size = new System.Drawing.Size(115, 40);
            this.btnKategoriSil.Text = "Sil";
            this.btnKategoriSil.FlatAppearance.BorderSize = 0;

            // --- KULLANICI YÖNETİMİ ---
            this.grpKullanici.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvKullanicilar, this.lbl3, this.txtKullaniciAd, this.lbl4, this.txtSifre, this.lbl5, this.cmbYetki, this.btnKullaniciEkle, this.btnKullaniciGuncelle, this.btnKullaniciSil });
            this.grpKullanici.Location = new System.Drawing.Point(798, 12);
            this.grpKullanici.Size = new System.Drawing.Size(390, 500);
            this.grpKullanici.Text = "Kullanıcı Yönetimi";
            this.grpKullanici.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpKullanici.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173);

            this.dgvKullanicilar.Location = new System.Drawing.Point(10, 30);
            this.dgvKullanicilar.Size = new System.Drawing.Size(370, 160);
            this.dgvKullanicilar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKullanicilar.DefaultCellStyle = style;

            this.lbl3.Location = new System.Drawing.Point(10, 200);
            this.lbl3.Text = "Kullanıcı Adı:";
            this.lbl3.ForeColor = System.Drawing.Color.DimGray;

            this.txtKullaniciAd.Location = new System.Drawing.Point(10, 223);
            this.txtKullaniciAd.Size = new System.Drawing.Size(370, 25);

            this.lbl4.Location = new System.Drawing.Point(10, 260);
            this.lbl4.Text = "Şifre:";
            this.lbl4.ForeColor = System.Drawing.Color.DimGray;

            this.txtSifre.Location = new System.Drawing.Point(10, 283);
            this.txtSifre.Size = new System.Drawing.Size(370, 25);
            this.txtSifre.UseSystemPasswordChar = true;

            this.lbl5.Location = new System.Drawing.Point(10, 315);
            this.lbl5.Text = "Yetki:";
            this.lbl5.ForeColor = System.Drawing.Color.DimGray;

            this.cmbYetki.Location = new System.Drawing.Point(10, 338);
            this.cmbYetki.Size = new System.Drawing.Size(370, 25);
            this.cmbYetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnKullaniciEkle.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnKullaniciEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciEkle.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciEkle.Location = new System.Drawing.Point(10, 385);
            this.btnKullaniciEkle.Size = new System.Drawing.Size(115, 45);
            this.btnKullaniciEkle.Text = "Ekle";
            this.btnKullaniciEkle.FlatAppearance.BorderSize = 0;

            this.btnKullaniciGuncelle.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnKullaniciGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciGuncelle.Location = new System.Drawing.Point(137, 385);
            this.btnKullaniciGuncelle.Size = new System.Drawing.Size(115, 45);
            this.btnKullaniciGuncelle.Text = "Güncelle";
            this.btnKullaniciGuncelle.FlatAppearance.BorderSize = 0;

            this.btnKullaniciSil.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnKullaniciSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciSil.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciSil.Location = new System.Drawing.Point(265, 385);
            this.btnKullaniciSil.Size = new System.Drawing.Size(115, 45);
            this.btnKullaniciSil.Text = "Sil";
            this.btnKullaniciSil.FlatAppearance.BorderSize = 0;

            // --- Form Ayarları ---
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 244);
            this.ClientSize = new System.Drawing.Size(1200, 530);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.grpMarka, this.grpKategori, this.grpKullanici });
            this.Name = "FrmAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Ayarları ve Yetkilendirme";
            this.Load += new System.EventHandler(this.FrmAyarlar_Load);

            // Olay Bağlantıları
            this.btnMarkaEkle.Click += new System.EventHandler(this.btnMarkaEkle_Click);
            this.btnMarkaGuncelle.Click += new System.EventHandler(this.btnMarkaGuncelle_Click);
            this.btnMarkaSil.Click += new System.EventHandler(this.btnMarkaSil_Click);
            this.btnKategoriEkle.Click += new System.EventHandler(this.btnKategoriEkle_Click);
            this.btnKategoriGuncelle.Click += new System.EventHandler(this.btnKategoriGuncelle_Click);
         
            this.btnKullaniciEkle.Click += new System.EventHandler(this.btnKullaniciEkle_Click);
            this.btnKullaniciGuncelle.Click += new System.EventHandler(this.btnKullaniciGuncelle_Click);
         

            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategoriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.grpMarka.ResumeLayout(false);
            this.grpMarka.PerformLayout();
            this.grpKategori.ResumeLayout(false);
            this.grpKategori.PerformLayout();
            this.grpKullanici.ResumeLayout(false);
            this.grpKullanici.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}