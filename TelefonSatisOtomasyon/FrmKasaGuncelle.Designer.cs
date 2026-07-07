namespace TelefonSatisOtomasyon
{
    partial class FrmKasaGuncelle
    {
        private System.ComponentModel.IContainer components = null;
        // HOCA KURALI: PUBLIC NESNELER
        public System.Windows.Forms.TextBox txtTutar;
        public System.Windows.Forms.RichTextBox rchAciklama; // Uygun nesne: Detaylı açıklama
        public System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lbl1, lbl2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.rchAciklama = new System.Windows.Forms.RichTextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(120, 27);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(180, 22);
            this.txtTutar.TabIndex = 1;
            // 
            // rchAciklama
            // 
            this.rchAciklama.Location = new System.Drawing.Point(120, 67);
            this.rchAciklama.Name = "rchAciklama";
            this.rchAciklama.Size = new System.Drawing.Size(180, 80);
            this.rchAciklama.TabIndex = 3;
            this.rchAciklama.Text = "";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Location = new System.Drawing.Point(20, 165);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(280, 45);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "GİDERİ GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(94, 23);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Gider Tutarı:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 70);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(94, 23);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Açıklama:";
            // 
            // FrmKasaGuncelle
            // 
            this.ClientSize = new System.Drawing.Size(330, 230);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.rchAciklama);
            this.Controls.Add(this.btnGuncelle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmKasaGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kasa Gider Düzenleme";
            this.Load += new System.EventHandler(this.FrmKasaGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}