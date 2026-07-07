namespace TelefonSatisOtomasyon
{
    partial class FrmMusteriGuncelle
    {
        private System.ComponentModel.IContainer components = null;

        // HOCA KURALI: Dışarıdan erişim için PUBLIC nesneler
        public System.Windows.Forms.TextBox txtAdSoyad, txtEmail;
        public System.Windows.Forms.MaskedTextBox mskTelefon; // Uygun nesne: Formatlı telefon
        public System.Windows.Forms.RichTextBox rchAdres; // Uygun nesne: Geniş metin
        public System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.mskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.rchAdres = new System.Windows.Forms.RichTextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(120, 27);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(180, 22);
            this.txtAdSoyad.TabIndex = 1;
            // 
            // mskTelefon
            // 
            this.mskTelefon.Location = new System.Drawing.Point(120, 67);
            this.mskTelefon.Mask = "(999) 000-0000";
            this.mskTelefon.Name = "mskTelefon";
            this.mskTelefon.Size = new System.Drawing.Size(180, 22);
            this.mskTelefon.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // rchAdres
            // 
            this.rchAdres.Location = new System.Drawing.Point(120, 147);
            this.rchAdres.Name = "rchAdres";
            this.rchAdres.Size = new System.Drawing.Size(180, 80);
            this.rchAdres.TabIndex = 7;
            this.rchAdres.Text = "";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Location = new System.Drawing.Point(25, 245);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(275, 45);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(25, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(89, 23);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Ad Soyad:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(25, 70);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(89, 23);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Telefon:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(25, 110);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(89, 23);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "E-Mail:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(25, 150);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(89, 23);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Adres:";
            // 
            // FrmMusteriGuncelle
            // 
            this.ClientSize = new System.Drawing.Size(330, 315);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.mskTelefon);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.rchAdres);
            this.Controls.Add(this.btnGuncelle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMusteriGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müşteri Düzenleme Paneli";
            this.Load += new System.EventHandler(this.FrmMusteriGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}