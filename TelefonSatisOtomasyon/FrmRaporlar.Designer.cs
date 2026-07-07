using System.Drawing;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    partial class FrmRaporlar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSol        = new Panel();
            this.panelSolBaslik  = new Panel();
            this.lblMenu         = new Label();
            this.btnSatis        = new Button();
            this.btnStok         = new Button();
            this.btnServis       = new Button();
            this.btnGelirGider   = new Button();
            this.btnPersonel     = new Button();
            this.btnMusteri      = new Button();

            this.panelUst        = new Panel();
            this.lblRaporBaslik  = new Label();
            this.lblTarihBas     = new Label();
            this.dtpBaslangic    = new DateTimePicker();
            this.lblTarihBit     = new Label();
            this.dtpBitis        = new DateTimePicker();
            this.btnFiltrele     = new Button();
            this.btnYazdir       = new Button();
            this.btnMasaustuKaydet = new Button();
            this.btnTemizle      = new Button();

            this.panelAlt        = new Panel();
            this.lblOzet1        = new Label();
            this.lblOzet2        = new Label();
            this.lblOzet3        = new Label();
            this.lblOzet4        = new Label();

            this.dgvRapor        = new DataGridView();

            this.panelSol.SuspendLayout();
            this.panelSolBaslik.SuspendLayout();
            this.panelUst.SuspendLayout();
            this.panelAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).BeginInit();
            this.SuspendLayout();

            // ── panelSol ────────────────────────────────────────────────
            this.panelSol.BackColor = Color.FromArgb(41, 53, 65);
            this.panelSol.Dock      = DockStyle.Left;
            this.panelSol.Width     = 200;
            this.panelSol.Controls.AddRange(new Control[] {
                panelSolBaslik, btnSatis, btnStok, btnServis,
                btnGelirGider, btnPersonel, btnMusteri
            });

            // ── panelSolBaslik ──────────────────────────────────────────
            this.panelSolBaslik.BackColor = Color.FromArgb(229, 126, 49);
            this.panelSolBaslik.Dock      = DockStyle.Top;
            this.panelSolBaslik.Height    = 64;
            this.panelSolBaslik.Controls.Add(this.lblMenu);

            this.lblMenu.Text      = "📊  RAPORLAR";
            this.lblMenu.Font      = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblMenu.ForeColor = Color.White;
            this.lblMenu.Dock      = DockStyle.Fill;
            this.lblMenu.TextAlign = ContentAlignment.MiddleCenter;

            // ── Sol Panel Butonları ─────────────────────────────────────
            SolButonAyarla(btnSatis,      "💰  Satış Raporu",      64);
            SolButonAyarla(btnStok,       "📦  Stok Raporu",       112);
            SolButonAyarla(btnServis,     "🔧  Teknik Servis",     160);
            SolButonAyarla(btnGelirGider, "💵  Gelir/Gider",       208);
            SolButonAyarla(btnPersonel,   "👤  Personel/Maaş",    256);
            SolButonAyarla(btnMusteri,    "🏆  Müşteri Özet",      304);

            // ── panelUst ────────────────────────────────────────────────
            this.panelUst.BackColor = Color.White;
            this.panelUst.Dock      = DockStyle.Top;
            this.panelUst.Height    = 60;
            this.panelUst.Padding   = new Padding(10, 0, 10, 0);
            this.panelUst.Controls.AddRange(new Control[] {
                lblRaporBaslik, lblTarihBas, dtpBaslangic,
                lblTarihBit, dtpBitis, btnFiltrele, btnYazdir, btnMasaustuKaydet, btnTemizle
            });

            this.lblRaporBaslik.Text      = "Bir rapor seçin...";
            this.lblRaporBaslik.Font      = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblRaporBaslik.ForeColor = Color.FromArgb(41, 53, 65);
            this.lblRaporBaslik.Location  = new Point(10, 15);
            this.lblRaporBaslik.AutoSize  = true;

            this.lblTarihBas.Text      = "Başlangıç:";
            this.lblTarihBas.Font      = new Font("Segoe UI", 9);
            this.lblTarihBas.Location  = new Point(290, 20);
            this.lblTarihBas.AutoSize  = true;

            this.dtpBaslangic.Format   = DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new Point(365, 16);
            this.dtpBaslangic.Width    = 110;
            this.dtpBaslangic.Value    = System.DateTime.Now.AddMonths(-1);

            this.lblTarihBit.Text      = "Bitiş:";
            this.lblTarihBit.Font      = new Font("Segoe UI", 9);
            this.lblTarihBit.Location  = new Point(488, 20);
            this.lblTarihBit.AutoSize  = true;

            this.dtpBitis.Format   = DateTimePickerFormat.Short;
            this.dtpBitis.Location = new Point(530, 16);
            this.dtpBitis.Width    = 110;
            this.dtpBitis.Value    = System.DateTime.Now;

            UstButonAyarla(btnFiltrele, "🔍 Filtrele", 655,  Color.FromArgb(52, 152, 219));
            UstButonAyarla(btnYazdir,   "🖨️ Yazdır",   748,  Color.FromArgb(46, 204, 113));
            UstButonAyarla(btnMasaustuKaydet, "💾 Kaydet", 841, Color.FromArgb(155, 89, 182));
            UstButonAyarla(btnTemizle,  "✖ Temizle",  934,  Color.FromArgb(231, 76, 60));

            // ── panelAlt ────────────────────────────────────────────────
            this.panelAlt.BackColor = Color.FromArgb(41, 53, 65);
            this.panelAlt.Dock      = DockStyle.Bottom;
            this.panelAlt.Height    = 40;
            this.panelAlt.Controls.AddRange(new Control[] {
                lblOzet1, lblOzet2, lblOzet3, lblOzet4
            });

            OzetLabelAyarla(lblOzet1, "", 10);
            OzetLabelAyarla(lblOzet2, "", 260);
            OzetLabelAyarla(lblOzet3, "", 510);
            OzetLabelAyarla(lblOzet4, "", 760);

            // ── dgvRapor ────────────────────────────────────────────────
            this.dgvRapor.Dock                         = DockStyle.Fill;
            this.dgvRapor.ReadOnly                     = true;
            this.dgvRapor.AllowUserToAddRows           = false;
            this.dgvRapor.AllowUserToDeleteRows        = false;
            this.dgvRapor.AllowUserToResizeRows        = false;
            this.dgvRapor.SelectionMode                = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRapor.MultiSelect                  = false;
            this.dgvRapor.RowHeadersVisible            = false;
            this.dgvRapor.AutoSizeColumnsMode          = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRapor.BackgroundColor              = Color.White;
            this.dgvRapor.BorderStyle                  = BorderStyle.None;
            this.dgvRapor.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(41, 53, 65);
            this.dgvRapor.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            this.dgvRapor.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9, FontStyle.Bold);
            this.dgvRapor.ColumnHeadersHeight          = 32;
            this.dgvRapor.ColumnHeadersHeightSizeMode  = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRapor.DefaultCellStyle.Font        = new Font("Segoe UI", 9);
            this.dgvRapor.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            this.dgvRapor.GridColor                    = Color.FromArgb(200, 215, 230);

            // ── Form ────────────────────────────────────────────────────
            this.ClientSize    = new Size(1100, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text          = "Raporlama Merkezi — Telefon Satış Pro";
            this.BackColor     = Color.WhiteSmoke;
            this.MinimumSize   = new Size(960, 600);
            this.Controls.Add(this.dgvRapor);
            this.Controls.Add(this.panelAlt);
            this.Controls.Add(this.panelUst);
            this.Controls.Add(this.panelSol);
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);

            this.panelSol.ResumeLayout(false);
            this.panelSolBaslik.ResumeLayout(false);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelAlt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Yardımcı: Sol buton ─────────────────────────────────────────
        private void SolButonAyarla(Button btn, string text, int top)
        {
            btn.Text      = text;
            btn.Dock      = DockStyle.Top;
            btn.Height    = 48;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.Font      = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding   = new Padding(12, 0, 0, 0);
            btn.Cursor    = Cursors.Hand;
        }

        // ── Yardımcı: Üst buton ─────────────────────────────────────────
        private void UstButonAyarla(Button btn, string text, int left, Color color)
        {
            btn.Text      = text;
            btn.Location  = new Point(left, 13);
            btn.Size      = new Size(88, 32);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor    = Cursors.Hand;
        }

        // ── Yardımcı: Özet label ────────────────────────────────────────
        private void OzetLabelAyarla(Label lbl, string text, int left)
        {
            lbl.Text      = text;
            lbl.Location  = new Point(left, 0);
            lbl.Size      = new Size(245, 40);
            lbl.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
        }

        // ── Kontrol Tanımları ────────────────────────────────────────────
        private Panel    panelSol, panelSolBaslik, panelUst, panelAlt;
        private Label    lblMenu, lblRaporBaslik;
        private Label    lblTarihBas, lblTarihBit;
        private DateTimePicker dtpBaslangic, dtpBitis;
        private Button   btnSatis, btnStok, btnServis, btnGelirGider, btnPersonel, btnMusteri;
        private Button   btnFiltrele, btnYazdir, btnMasaustuKaydet, btnTemizle;
        private Label    lblOzet1, lblOzet2, lblOzet3, lblOzet4;
        private DataGridView dgvRapor;
    }
}