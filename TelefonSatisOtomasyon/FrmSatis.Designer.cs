namespace TelefonSatisOtomasyon
{
    partial class FrmSatis
    {
        private System.ComponentModel.IContainer components = null;

        // Nesne Tanımlamaları - Kod tarafıyla eşleşmesi için public yapıldı
        public System.Windows.Forms.ComboBox cmbMusteri, cmbTelefon;
        public System.Windows.Forms.TextBox txtFiyat, txtToplam;
        public System.Windows.Forms.NumericUpDown nudAdet; // txtAdet yerine nudAdet eklendi
        public System.Windows.Forms.Button btnKaydet, btnSil, btnTemizle, btnGuncelle;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.cmbTelefon = new System.Windows.Forms.ComboBox();
            this.nudAdet = new System.Windows.Forms.NumericUpDown();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.txtToplam = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Location = new System.Drawing.Point(100, 20);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(200, 24);
            this.cmbMusteri.TabIndex = 0;
            // 
            // cmbTelefon
            // 
            this.cmbTelefon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTelefon.Location = new System.Drawing.Point(100, 55);
            this.cmbTelefon.Name = "cmbTelefon";
            this.cmbTelefon.Size = new System.Drawing.Size(200, 24);
            this.cmbTelefon.TabIndex = 1;
            // 
            // nudAdet
            // 
            this.nudAdet.Location = new System.Drawing.Point(100, 90);
            this.nudAdet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAdet.Name = "nudAdet";
            this.nudAdet.Size = new System.Drawing.Size(60, 22);
            this.nudAdet.TabIndex = 2;
            this.nudAdet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(230, 90);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(70, 22);
            this.txtFiyat.TabIndex = 3;
            // 
            // txtToplam
            // 
            this.txtToplam.BackColor = System.Drawing.Color.LightYellow;
            this.txtToplam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtToplam.Location = new System.Drawing.Point(100, 125);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.ReadOnly = true;
            this.txtToplam.Size = new System.Drawing.Size(200, 27);
            this.txtToplam.TabIndex = 4;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(320, 20);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 35);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Satış Yap";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.IndianRed;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(320, 100);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(115, 30);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Satışı İptal Et";
            this.btnSil.UseVisualStyleBackColor = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Gold;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Location = new System.Drawing.Point(320, 60);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(115, 35);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Değiştir";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Location = new System.Drawing.Point(320, 135);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(115, 27);
            this.btnTemizle.TabIndex = 8;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(20, 180);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(415, 190);
            this.dataGridView1.TabIndex = 9;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 23);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(59, 23);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = "Müşteri:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 58);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(74, 23);
            this.lbl2.TabIndex = 8;
            this.lbl2.Text = "Cihaz:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 93);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(59, 23);
            this.lbl3.TabIndex = 9;
            this.lbl3.Text = "Adet:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(180, 93);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(44, 23);
            this.lbl4.TabIndex = 10;
            this.lbl4.Text = "Fiyat:";
            // 
            // lbl5
            // 
            this.lbl5.Location = new System.Drawing.Point(20, 128);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(74, 23);
            this.lbl5.TabIndex = 11;
            this.lbl5.Text = "Toplam:";
            // 
            // FrmSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.cmbTelefon);
            this.Controls.Add(this.nudAdet);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmSatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kusursuz Satış Paneli";
            this.Load += new System.EventHandler(this.FrmSatis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}