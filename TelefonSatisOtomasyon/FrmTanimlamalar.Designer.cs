namespace TelefonSatisOtomasyon
{
    partial class FrmTanimlamalar
    {
        private System.ComponentModel.IContainer components = null;

        // --- GÖREVLER ---
        private System.Windows.Forms.GroupBox grpGorevler;
        private System.Windows.Forms.DataGridView dgvGorevler;
        private System.Windows.Forms.Label lblGorevAd;
        private System.Windows.Forms.TextBox txtGorevAd;
        private System.Windows.Forms.Button btnGorevEkle, btnGorevGuncelle, btnGorevSil;

        // --- ÖDEME TİPLERİ ---
        private System.Windows.Forms.GroupBox grpOdemeTipleri;
        private System.Windows.Forms.DataGridView dgvOdemeTipleri;
        private System.Windows.Forms.Label lblOdemeAd;
        private System.Windows.Forms.TextBox txtOdemeAd;
        private System.Windows.Forms.Button btnOdemeEkle, btnOdemeGuncelle, btnOdemeSil;

        // --- SERVİS DURUMLARI ---
        private System.Windows.Forms.GroupBox grpServisDurumlari;
        private System.Windows.Forms.DataGridView dgvServisDurumlari;
        private System.Windows.Forms.Label lblServisAd;
        private System.Windows.Forms.TextBox txtServisAd;
        private System.Windows.Forms.Button btnServisEkle, btnServisGuncelle, btnServisSil;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Görevler ──
            this.grpGorevler        = new System.Windows.Forms.GroupBox();
            this.dgvGorevler        = new System.Windows.Forms.DataGridView();
            this.lblGorevAd         = new System.Windows.Forms.Label();
            this.txtGorevAd         = new System.Windows.Forms.TextBox();
            this.btnGorevEkle       = new System.Windows.Forms.Button();
            this.btnGorevGuncelle   = new System.Windows.Forms.Button();
            this.btnGorevSil        = new System.Windows.Forms.Button();

            // ── Ödeme Tipleri ──
            this.grpOdemeTipleri    = new System.Windows.Forms.GroupBox();
            this.dgvOdemeTipleri    = new System.Windows.Forms.DataGridView();
            this.lblOdemeAd         = new System.Windows.Forms.Label();
            this.txtOdemeAd         = new System.Windows.Forms.TextBox();
            this.btnOdemeEkle       = new System.Windows.Forms.Button();
            this.btnOdemeGuncelle   = new System.Windows.Forms.Button();
            this.btnOdemeSil        = new System.Windows.Forms.Button();

            // ── Servis Durumları ──
            this.grpServisDurumlari = new System.Windows.Forms.GroupBox();
            this.dgvServisDurumlari = new System.Windows.Forms.DataGridView();
            this.lblServisAd        = new System.Windows.Forms.Label();
            this.txtServisAd        = new System.Windows.Forms.TextBox();
            this.btnServisEkle      = new System.Windows.Forms.Button();
            this.btnServisGuncelle  = new System.Windows.Forms.Button();
            this.btnServisSil       = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGorevler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdemeTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisDurumlari)).BeginInit();
            this.grpGorevler.SuspendLayout();
            this.grpOdemeTipleri.SuspendLayout();
            this.grpServisDurumlari.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════
            //  GÖREVLER GroupBox
            // ══════════════════════════════════════════════════════
            this.grpGorevler.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvGorevler, this.lblGorevAd, this.txtGorevAd,
                this.btnGorevEkle, this.btnGorevGuncelle, this.btnGorevSil
            });
            this.grpGorevler.Location = new System.Drawing.Point(12, 12);
            this.grpGorevler.Size     = new System.Drawing.Size(370, 480);
            this.grpGorevler.Text     = "👔  Görev Tanımları";
            this.grpGorevler.Font     = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpGorevler.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);

            this.dgvGorevler.Location  = new System.Drawing.Point(10, 30);
            this.dgvGorevler.Size      = new System.Drawing.Size(350, 270);
            this.dgvGorevler.Name      = "dgvGorevler";
            this.dgvGorevler.TabIndex  = 0;

            this.lblGorevAd.Location   = new System.Drawing.Point(10, 315);
            this.lblGorevAd.Size       = new System.Drawing.Size(200, 20);
            this.lblGorevAd.Text       = "Görev Adı:";
            this.lblGorevAd.ForeColor  = System.Drawing.Color.DimGray;
            this.lblGorevAd.Font       = new System.Drawing.Font("Segoe UI", 9F);

            this.txtGorevAd.Location   = new System.Drawing.Point(10, 338);
            this.txtGorevAd.Size       = new System.Drawing.Size(350, 25);
            this.txtGorevAd.Name       = "txtGorevAd";
            this.txtGorevAd.Font       = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGorevAd.MaxLength  = 100;
            this.txtGorevAd.TabIndex   = 1;

            YapilandirilmisButon(this.btnGorevEkle,     "✚  Ekle",     System.Drawing.Color.FromArgb(46, 204, 113),  10, 380, 105, 42, 2);
            YapilandirilmisButon(this.btnGorevGuncelle, "✎  Güncelle", System.Drawing.Color.FromArgb(241, 196, 15), 127, 380, 105, 42, 3);
            YapilandirilmisButon(this.btnGorevSil,      "✕  Sil",      System.Drawing.Color.FromArgb(231, 76, 60),  255, 380, 105, 42, 4);

            // ══════════════════════════════════════════════════════
            //  ÖDEME TİPLERİ GroupBox
            // ══════════════════════════════════════════════════════
            this.grpOdemeTipleri.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvOdemeTipleri, this.lblOdemeAd, this.txtOdemeAd,
                this.btnOdemeEkle, this.btnOdemeGuncelle, this.btnOdemeSil
            });
            this.grpOdemeTipleri.Location = new System.Drawing.Point(397, 12);
            this.grpOdemeTipleri.Size     = new System.Drawing.Size(370, 480);
            this.grpOdemeTipleri.Text     = "💳  Ödeme Tipi Tanımları";
            this.grpOdemeTipleri.Font     = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpOdemeTipleri.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);

            this.dgvOdemeTipleri.Location  = new System.Drawing.Point(10, 30);
            this.dgvOdemeTipleri.Size      = new System.Drawing.Size(350, 270);
            this.dgvOdemeTipleri.Name      = "dgvOdemeTipleri";
            this.dgvOdemeTipleri.TabIndex  = 5;

            this.lblOdemeAd.Location   = new System.Drawing.Point(10, 315);
            this.lblOdemeAd.Size       = new System.Drawing.Size(200, 20);
            this.lblOdemeAd.Text       = "Ödeme Tipi Adı:";
            this.lblOdemeAd.ForeColor  = System.Drawing.Color.DimGray;
            this.lblOdemeAd.Font       = new System.Drawing.Font("Segoe UI", 9F);

            this.txtOdemeAd.Location   = new System.Drawing.Point(10, 338);
            this.txtOdemeAd.Size       = new System.Drawing.Size(350, 25);
            this.txtOdemeAd.Name       = "txtOdemeAd";
            this.txtOdemeAd.Font       = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOdemeAd.MaxLength  = 100;
            this.txtOdemeAd.TabIndex   = 6;

            YapilandirilmisButon(this.btnOdemeEkle,     "✚  Ekle",     System.Drawing.Color.FromArgb(46, 204, 113),  10, 380, 105, 42, 7);
            YapilandirilmisButon(this.btnOdemeGuncelle, "✎  Güncelle", System.Drawing.Color.FromArgb(241, 196, 15), 127, 380, 105, 42, 8);
            YapilandirilmisButon(this.btnOdemeSil,      "✕  Sil",      System.Drawing.Color.FromArgb(231, 76, 60),  255, 380, 105, 42, 9);

            // ══════════════════════════════════════════════════════
            //  SERVİS DURUMLARI GroupBox
            // ══════════════════════════════════════════════════════
            this.grpServisDurumlari.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvServisDurumlari, this.lblServisAd, this.txtServisAd,
                this.btnServisEkle, this.btnServisGuncelle, this.btnServisSil
            });
            this.grpServisDurumlari.Location = new System.Drawing.Point(782, 12);
            this.grpServisDurumlari.Size     = new System.Drawing.Size(370, 480);
            this.grpServisDurumlari.Text     = "🔧  Servis Durum Tanımları";
            this.grpServisDurumlari.Font     = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpServisDurumlari.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173);

            this.dgvServisDurumlari.Location  = new System.Drawing.Point(10, 30);
            this.dgvServisDurumlari.Size      = new System.Drawing.Size(350, 270);
            this.dgvServisDurumlari.Name      = "dgvServisDurumlari";
            this.dgvServisDurumlari.TabIndex  = 10;

            this.lblServisAd.Location   = new System.Drawing.Point(10, 315);
            this.lblServisAd.Size       = new System.Drawing.Size(200, 20);
            this.lblServisAd.Text       = "Durum Adı:";
            this.lblServisAd.ForeColor  = System.Drawing.Color.DimGray;
            this.lblServisAd.Font       = new System.Drawing.Font("Segoe UI", 9F);

            this.txtServisAd.Location   = new System.Drawing.Point(10, 338);
            this.txtServisAd.Size       = new System.Drawing.Size(350, 25);
            this.txtServisAd.Name       = "txtServisAd";
            this.txtServisAd.Font       = new System.Drawing.Font("Segoe UI", 10F);
            this.txtServisAd.MaxLength  = 100;
            this.txtServisAd.TabIndex   = 11;

            YapilandirilmisButon(this.btnServisEkle,     "✚  Ekle",     System.Drawing.Color.FromArgb(46, 204, 113),  10, 380, 105, 42, 12);
            YapilandirilmisButon(this.btnServisGuncelle, "✎  Güncelle", System.Drawing.Color.FromArgb(241, 196, 15), 127, 380, 105, 42, 13);
            YapilandirilmisButon(this.btnServisSil,      "✕  Sil",      System.Drawing.Color.FromArgb(231, 76, 60),  255, 380, 105, 42, 14);

            // ── Form Genel Ayarları ──
            this.BackColor      = System.Drawing.Color.FromArgb(240, 243, 244);
            this.ClientSize     = new System.Drawing.Size(1168, 510);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpGorevler, this.grpOdemeTipleri, this.grpServisDurumlari
            });
            this.Name           = "FrmTanimlamalar";
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text           = "Tanımlama Yönetimi — Görev | Ödeme Tipi | Servis Durumu";
            this.Font           = new System.Drawing.Font("Segoe UI", 9F);
            this.Load          += new System.EventHandler(this.FrmTanimlamalar_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvGorevler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdemeTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisDurumlari)).EndInit();
            this.grpGorevler.ResumeLayout(false);
            this.grpOdemeTipleri.ResumeLayout(false);
            this.grpServisDurumlari.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        /// <summary>Tekrar kullanılabilir buton yapılandırıcı yardımcı metot</summary>
        private static void YapilandirilmisButon(
            System.Windows.Forms.Button btn,
            string metin,
            System.Drawing.Color renk,
            int x, int y, int genislik, int yukseklik, int tabIndex)
        {
            btn.Text                       = metin;
            btn.BackColor                  = renk;
            btn.ForeColor                  = System.Drawing.Color.White;
            btn.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize  = 0;
            btn.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            btn.Location                   = new System.Drawing.Point(x, y);
            btn.Size                       = new System.Drawing.Size(genislik, yukseklik);
            btn.TabIndex                   = tabIndex;
            btn.UseVisualStyleBackColor    = false;
            btn.Cursor                     = System.Windows.Forms.Cursors.Hand;
        }
    }
}
