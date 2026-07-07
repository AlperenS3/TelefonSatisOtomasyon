namespace TelefonSatisOtomasyon
{
    partial class FrmSatisGuncelle
    {
        private System.ComponentModel.IContainer components = null;
        // PUBLIC NESNELER
        public System.Windows.Forms.ComboBox cmbMusteri, cmbCihaz;
        public System.Windows.Forms.NumericUpDown nudAdet;
        public System.Windows.Forms.TextBox txtBirimFiyat, txtToplam;
        public System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.cmbCihaz = new System.Windows.Forms.ComboBox();
            this.nudAdet = new System.Windows.Forms.NumericUpDown();
            this.txtBirimFiyat = new System.Windows.Forms.TextBox();
            this.txtToplam = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Location = new System.Drawing.Point(120, 27);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(180, 24);
            this.cmbMusteri.TabIndex = 1;
            // 
            // cmbCihaz
            // 
            this.cmbCihaz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCihaz.Location = new System.Drawing.Point(120, 67);
            this.cmbCihaz.Name = "cmbCihaz";
            this.cmbCihaz.Size = new System.Drawing.Size(180, 24);
            this.cmbCihaz.TabIndex = 3;
            // 
            // nudAdet
            // 
            this.nudAdet.Location = new System.Drawing.Point(120, 107);
            this.nudAdet.Name = "nudAdet";
            this.nudAdet.Size = new System.Drawing.Size(180, 22);
            this.nudAdet.TabIndex = 5;
            // 
            // txtBirimFiyat
            // 
            this.txtBirimFiyat.Location = new System.Drawing.Point(120, 147);
            this.txtBirimFiyat.Name = "txtBirimFiyat";
            this.txtBirimFiyat.Size = new System.Drawing.Size(180, 22);
            this.txtBirimFiyat.TabIndex = 7;
            // 
            // txtToplam
            // 
            this.txtToplam.BackColor = System.Drawing.Color.LightYellow;
            this.txtToplam.Location = new System.Drawing.Point(120, 187);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.ReadOnly = true;
            this.txtToplam.Size = new System.Drawing.Size(180, 22);
            this.txtToplam.TabIndex = 9;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(20, 230);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(280, 45);
            this.btnGuncelle.TabIndex = 10;
            this.btnGuncelle.Text = "SATIŞI GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(94, 23);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Müşteri:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 70);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(74, 23);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Cihaz:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 110);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(74, 23);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Adet:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(20, 150);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(94, 23);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Birim Fiyat:";
            // 
            // lbl5
            // 
            this.lbl5.Location = new System.Drawing.Point(20, 190);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(94, 23);
            this.lbl5.TabIndex = 8;
            this.lbl5.Text = "Toplam:";
            // 
            // FrmSatisGuncelle
            // 
            this.ClientSize = new System.Drawing.Size(330, 300);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.cmbCihaz);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.nudAdet);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txtBirimFiyat);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.btnGuncelle);
            this.Name = "FrmSatisGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Satış Kaydı Düzenle";
            this.Load += new System.EventHandler(this.FrmSatisGuncelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}