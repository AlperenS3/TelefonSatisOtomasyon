namespace TelefonSatisOtomasyon
{
    partial class FrmUrunEkle
    {
        private System.ComponentModel.IContainer components = null;

        // Nesne Tanımlamaları
        public System.Windows.Forms.ComboBox cmbMarka;
        public System.Windows.Forms.ComboBox cmbKategori;
        public System.Windows.Forms.TextBox txtModel;
        public System.Windows.Forms.TextBox txtIMEI;
        public System.Windows.Forms.TextBox txtRenk;
        public System.Windows.Forms.TextBox txtAlisFiyat;
        public System.Windows.Forms.TextBox txtSatisFiyat;
        public System.Windows.Forms.NumericUpDown nudStok; // TextBox yerine NumericUpDown mühürlendi
        public System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbMarka = new System.Windows.Forms.ComboBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.txtRenk = new System.Windows.Forms.TextBox();
            this.txtAlisFiyat = new System.Windows.Forms.TextBox();
            this.txtSatisFiyat = new System.Windows.Forms.TextBox();
            this.nudStok = new System.Windows.Forms.NumericUpDown();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudStok)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1 (Marka)
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(100, 23);
            this.lbl1.Text = "Marka:";
            // 
            // cmbMarka
            // 
            this.cmbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarka.Location = new System.Drawing.Point(130, 18);
            this.cmbMarka.Name = "cmbMarka";
            this.cmbMarka.Size = new System.Drawing.Size(180, 24);
            this.cmbMarka.TabIndex = 0;
            // 
            // lbl2 (Kategori)
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 55);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 23);
            this.lbl2.Text = "Kategori:";
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.Location = new System.Drawing.Point(130, 53);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(180, 24);
            this.cmbKategori.TabIndex = 1;
            // 
            // lbl3 (Model)
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 90);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(100, 23);
            this.lbl3.Text = "Model Adı:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(130, 88);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(180, 22);
            this.txtModel.TabIndex = 2;
            // 
            // lbl4 (IMEI)
            // 
            this.lbl4.Location = new System.Drawing.Point(20, 125);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(100, 23);
            this.lbl4.Text = "IMEI No:";
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(130, 123);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.Size = new System.Drawing.Size(180, 22);
            this.txtIMEI.TabIndex = 3;
            // 
            // lbl5 (Renk)
            // 
            this.lbl5.Location = new System.Drawing.Point(20, 160);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(100, 23);
            this.lbl5.Text = "Cihaz Rengi:";
            // 
            // txtRenk
            // 
            this.txtRenk.Location = new System.Drawing.Point(130, 158);
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Size = new System.Drawing.Size(180, 22);
            this.txtRenk.TabIndex = 4;
            // 
            // lbl6 (Alış)
            // 
            this.lbl6.Location = new System.Drawing.Point(20, 195);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(100, 23);
            this.lbl6.Text = "Alış Fiyatı:";
            // 
            // txtAlisFiyat
            // 
            this.txtAlisFiyat.Location = new System.Drawing.Point(130, 193);
            this.txtAlisFiyat.Name = "txtAlisFiyat";
            this.txtAlisFiyat.Size = new System.Drawing.Size(180, 22);
            this.txtAlisFiyat.TabIndex = 5;
            // 
            // lbl7 (Satış)
            // 
            this.lbl7.Location = new System.Drawing.Point(20, 230);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(100, 23);
            this.lbl7.Text = "Satış Fiyatı:";
            // 
            // txtSatisFiyat
            // 
            this.txtSatisFiyat.Location = new System.Drawing.Point(130, 228);
            this.txtSatisFiyat.Name = "txtSatisFiyat";
            this.txtSatisFiyat.Size = new System.Drawing.Size(180, 22);
            this.txtSatisFiyat.TabIndex = 6;
            // 
            // lbl8 (Stok)
            // 
            this.lbl8.Location = new System.Drawing.Point(20, 265);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(100, 23);
            this.lbl8.Text = "Stok Adedi:";
            // 
            // nudStok
            // 
            this.nudStok.Location = new System.Drawing.Point(130, 263);
            this.nudStok.Name = "nudStok";
            this.nudStok.Size = new System.Drawing.Size(180, 22);
            this.nudStok.TabIndex = 7;
            this.nudStok.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(20, 310);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(290, 45);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // FrmUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // HOCA KURALI: AutoSize ve GrowAndShrink mühürlendi
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(340, 380);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cmbMarka);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txtIMEI);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.txtRenk);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.txtAlisFiyat);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.txtSatisFiyat);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.nudStok);
            this.Controls.Add(this.btnKaydet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmUrunEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Ürün Kaydı";
            this.Load += new System.EventHandler(this.FrmUrunEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudStok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}