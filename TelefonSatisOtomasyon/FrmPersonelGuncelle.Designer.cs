namespace TelefonSatisOtomasyon
{
    partial class FrmPersonelGuncelle
    {
        private System.ComponentModel.IContainer components = null;
        // HOCA KURALI: PUBLIC NESNELER
        public System.Windows.Forms.TextBox txtAdSoyad, txtMaas;
        public System.Windows.Forms.ComboBox cmbGorev;
        public System.Windows.Forms.MaskedTextBox mskTelefon; // Formatlı nesne
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
            this.cmbGorev = new System.Windows.Forms.ComboBox();
            this.mskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtMaas = new System.Windows.Forms.TextBox();
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
            // cmbGorev
            // 
            this.cmbGorev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorev.Location = new System.Drawing.Point(120, 67);
            this.cmbGorev.Name = "cmbGorev";
            this.cmbGorev.Size = new System.Drawing.Size(180, 24);
            this.cmbGorev.TabIndex = 3;
            // 
            // mskTelefon
            // 
            this.mskTelefon.Location = new System.Drawing.Point(120, 107);
            this.mskTelefon.Mask = "(999) 000-0000";
            this.mskTelefon.Name = "mskTelefon";
            this.mskTelefon.Size = new System.Drawing.Size(180, 22);
            this.mskTelefon.TabIndex = 5;
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(120, 147);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Size = new System.Drawing.Size(180, 22);
            this.txtMaas.TabIndex = 7;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Location = new System.Drawing.Point(25, 195);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(275, 45);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "PERSONEL GÜNCELLE";
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
            this.lbl2.Size = new System.Drawing.Size(75, 23);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Görev:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(25, 110);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(75, 23);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Telefon:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(25, 150);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(75, 23);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Maaş (₺):";
            // 
            // FrmPersonelGuncelle
            // 
            this.ClientSize = new System.Drawing.Size(330, 270);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.cmbGorev);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.mskTelefon);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txtMaas);
            this.Controls.Add(this.btnGuncelle);
            this.Name = "FrmPersonelGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personel Bilgi Düzenleme";
            this.Load += new System.EventHandler(this.FrmPersonelGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}