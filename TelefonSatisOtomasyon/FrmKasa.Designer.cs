namespace TelefonSatisOtomasyon
{
    partial class FrmKasa
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
            this.dgvKasa = new System.Windows.Forms.DataGridView();
            this.grpIslem = new System.Windows.Forms.GroupBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnGelirEkle = new System.Windows.Forms.Button();
            this.btnGiderEkle = new System.Windows.Forms.Button();
            this.txtGiderAciklama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiderTutar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOdemeTipi = new System.Windows.Forms.Label();
            this.cmbOdemeTipi = new System.Windows.Forms.ComboBox();
            this.pnlIstatistik = new System.Windows.Forms.Panel();
            this.lblNetKasa = new System.Windows.Forms.Label();
            this.lblToplamGider = new System.Windows.Forms.Label();
            this.lblToplamGelir = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKasa)).BeginInit();
            this.grpIslem.SuspendLayout();
            this.pnlIstatistik.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKasa
            // 
            this.dgvKasa.BackgroundColor = System.Drawing.Color.White;
            this.dgvKasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKasa.Location = new System.Drawing.Point(12, 115);
            this.dgvKasa.Name = "dgvKasa";
            this.dgvKasa.RowHeadersWidth = 51;
            this.dgvKasa.RowTemplate.Height = 24;
            this.dgvKasa.Size = new System.Drawing.Size(650, 420);
            this.dgvKasa.TabIndex = 0;
            // 
            // grpIslem
            // 
            this.grpIslem.Controls.Add(this.btnTemizle);
            this.grpIslem.Controls.Add(this.btnSil);
            this.grpIslem.Controls.Add(this.btnGuncelle);
            this.grpIslem.Controls.Add(this.btnGelirEkle);
            this.grpIslem.Controls.Add(this.btnGiderEkle);
            this.grpIslem.Controls.Add(this.txtGiderAciklama);
            this.grpIslem.Controls.Add(this.label2);
            this.grpIslem.Controls.Add(this.txtGiderTutar);
            this.grpIslem.Controls.Add(this.label1);
            this.grpIslem.Controls.Add(this.lblOdemeTipi);
            this.grpIslem.Controls.Add(this.cmbOdemeTipi);
            this.grpIslem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIslem.Location = new System.Drawing.Point(675, 115);
            this.grpIslem.Name = "grpIslem";
            this.grpIslem.Size = new System.Drawing.Size(300, 468);
            this.grpIslem.TabIndex = 1;
            this.grpIslem.TabStop = false;
            this.grpIslem.Text = "Finansal İşlem Paneli";
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.LightGray;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Location = new System.Drawing.Point(20, 415);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(260, 40);
            this.btnTemizle.TabIndex = 8;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.MistyRose;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Location = new System.Drawing.Point(20, 366);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(260, 40);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "KAYDI SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Location = new System.Drawing.Point(20, 318);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(260, 40);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "DEĞİŞTİR";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnGelirEkle
            // 
            this.btnGelirEkle.BackColor = System.Drawing.Color.LightGreen;
            this.btnGelirEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGelirEkle.Location = new System.Drawing.Point(155, 265);
            this.btnGelirEkle.Name = "btnGelirEkle";
            this.btnGelirEkle.Size = new System.Drawing.Size(125, 40);
            this.btnGelirEkle.TabIndex = 5;
            this.btnGelirEkle.Text = "GELİR EKLE";
            this.btnGelirEkle.UseVisualStyleBackColor = false;
            // 
            // btnGiderEkle
            // 
            this.btnGiderEkle.BackColor = System.Drawing.Color.Salmon;
            this.btnGiderEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiderEkle.Location = new System.Drawing.Point(20, 265);
            this.btnGiderEkle.Name = "btnGiderEkle";
            this.btnGiderEkle.Size = new System.Drawing.Size(125, 40);
            this.btnGiderEkle.TabIndex = 4;
            this.btnGiderEkle.Text = "GİDER EKLE";
            this.btnGiderEkle.UseVisualStyleBackColor = false;
            // 
            // txtGiderAciklama
            // 
            this.txtGiderAciklama.Location = new System.Drawing.Point(20, 115);
            this.txtGiderAciklama.Multiline = true;
            this.txtGiderAciklama.Name = "txtGiderAciklama";
            this.txtGiderAciklama.Size = new System.Drawing.Size(260, 80);
            this.txtGiderAciklama.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Açıklama:";
            // 
            // txtGiderTutar
            // 
            this.txtGiderTutar.Location = new System.Drawing.Point(20, 55);
            this.txtGiderTutar.Name = "txtGiderTutar";
            this.txtGiderTutar.Size = new System.Drawing.Size(260, 27);
            this.txtGiderTutar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tutar:";
            // 
            // lblOdemeTipi
            // 
            this.lblOdemeTipi.AutoSize = true;
            this.lblOdemeTipi.Location = new System.Drawing.Point(20, 200);
            this.lblOdemeTipi.Name = "lblOdemeTipi";
            this.lblOdemeTipi.Size = new System.Drawing.Size(93, 20);
            this.lblOdemeTipi.TabIndex = 9;
            this.lblOdemeTipi.Text = "Ödeme Tipi:";
            // 
            // cmbOdemeTipi
            // 
            this.cmbOdemeTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeTipi.Location = new System.Drawing.Point(20, 222);
            this.cmbOdemeTipi.Name = "cmbOdemeTipi";
            this.cmbOdemeTipi.Size = new System.Drawing.Size(260, 28);
            this.cmbOdemeTipi.TabIndex = 9;
            // 
            // pnlIstatistik
            // 
            this.pnlIstatistik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlIstatistik.Controls.Add(this.lblNetKasa);
            this.pnlIstatistik.Controls.Add(this.lblToplamGider);
            this.pnlIstatistik.Controls.Add(this.lblToplamGelir);
            this.pnlIstatistik.Location = new System.Drawing.Point(12, 12);
            this.pnlIstatistik.Name = "pnlIstatistik";
            this.pnlIstatistik.Size = new System.Drawing.Size(963, 85);
            this.pnlIstatistik.TabIndex = 2;
            // 
            // lblNetKasa
            // 
            this.lblNetKasa.AutoSize = true;
            this.lblNetKasa.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNetKasa.ForeColor = System.Drawing.Color.White;
            this.lblNetKasa.Location = new System.Drawing.Point(650, 25);
            this.lblNetKasa.Name = "lblNetKasa";
            this.lblNetKasa.Size = new System.Drawing.Size(156, 30);
            this.lblNetKasa.TabIndex = 0;
            this.lblNetKasa.Text = "KASA: 0,00 TL";
            // 
            // lblToplamGider
            // 
            this.lblToplamGider.AutoSize = true;
            this.lblToplamGider.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamGider.ForeColor = System.Drawing.Color.Salmon;
            this.lblToplamGider.Location = new System.Drawing.Point(340, 27);
            this.lblToplamGider.Name = "lblToplamGider";
            this.lblToplamGider.Size = new System.Drawing.Size(151, 28);
            this.lblToplamGider.TabIndex = 1;
            this.lblToplamGider.Text = "GİDER: 0,00 TL";
            // 
            // lblToplamGelir
            // 
            this.lblToplamGelir.AutoSize = true;
            this.lblToplamGelir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamGelir.ForeColor = System.Drawing.Color.LightGreen;
            this.lblToplamGelir.Location = new System.Drawing.Point(30, 27);
            this.lblToplamGelir.Name = "lblToplamGelir";
            this.lblToplamGelir.Size = new System.Drawing.Size(146, 28);
            this.lblToplamGelir.TabIndex = 2;
            this.lblToplamGelir.Text = "GELİR: 0,00 TL";
            // 
            // FrmKasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(987, 581);
            this.Controls.Add(this.pnlIstatistik);
            this.Controls.Add(this.grpIslem);
            this.Controls.Add(this.dgvKasa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmKasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa ve Finans Yönetimi";
            this.Load += new System.EventHandler(this.FrmKasa_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKasa)).EndInit();
            this.grpIslem.ResumeLayout(false);
            this.grpIslem.PerformLayout();
            this.pnlIstatistik.ResumeLayout(false);
            this.pnlIstatistik.PerformLayout();
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.DataGridView dgvKasa;
        private System.Windows.Forms.GroupBox grpIslem;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnGelirEkle;
        private System.Windows.Forms.Button btnGiderEkle;
        private System.Windows.Forms.TextBox txtGiderAciklama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiderTutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOdemeTipi;
        public System.Windows.Forms.ComboBox cmbOdemeTipi;
        private System.Windows.Forms.Panel pnlIstatistik;
        private System.Windows.Forms.Label lblNetKasa;
        private System.Windows.Forms.Label lblToplamGider;
        private System.Windows.Forms.Label lblToplamGelir;
    }
}