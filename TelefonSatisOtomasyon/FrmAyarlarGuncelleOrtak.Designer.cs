namespace TelefonSatisOtomasyon
{
    partial class FrmAyarlarGuncelleOrtak
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbl1 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.lblYetki = new System.Windows.Forms.Label();
            this.cmbYetki = new System.Windows.Forms.ComboBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1.Location = new System.Drawing.Point(25, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(55, 20);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "Bilgi 1:";
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(130, 27);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(180, 27);
            this.txt1.TabIndex = 0;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl2.Location = new System.Drawing.Point(25, 75);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(55, 20);
            this.lbl2.TabIndex = 11;
            this.lbl2.Text = "Bilgi 2:";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(130, 72);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(180, 27);
            this.txt2.TabIndex = 1;
            // 
            // lblYetki
            // 
            this.lblYetki.AutoSize = true;
            this.lblYetki.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYetki.Location = new System.Drawing.Point(25, 120);
            this.lblYetki.Name = "lblYetki";
            this.lblYetki.Size = new System.Drawing.Size(48, 20);
            this.lblYetki.TabIndex = 12;
            this.lblYetki.Text = "Yetki:";
            // 
            // cmbYetki
            // 
            this.cmbYetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYetki.FormattingEnabled = true;
            this.cmbYetki.Items.AddRange(new object[] {
            "Admin",
            "Personel"});
            this.cmbYetki.Location = new System.Drawing.Point(130, 117);
            this.cmbYetki.Name = "cmbYetki";
            this.cmbYetki.Size = new System.Drawing.Size(180, 28);
            this.cmbYetki.TabIndex = 2;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Location = new System.Drawing.Point(25, 170);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(285, 45);
            this.btnGuncelle.TabIndex = 3;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // FrmAyarlarGuncelleOrtak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 240);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.cmbYetki);
            this.Controls.Add(this.lblYetki);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAyarlarGuncelleOrtak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bilgi Düzenle";
            this.Load += new System.EventHandler(this.FrmAyarlarGuncelleOrtak_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.TextBox txt1;
        public System.Windows.Forms.Label lbl2;
        public System.Windows.Forms.TextBox txt2;
        public System.Windows.Forms.Label lblYetki;
        public System.Windows.Forms.ComboBox cmbYetki;
        public System.Windows.Forms.Button btnGuncelle;
    }
}