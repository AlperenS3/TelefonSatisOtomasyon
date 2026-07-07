namespace TelefonSatisOtomasyon
{
    partial class FrmPersonel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPersonel;
        private System.Windows.Forms.TextBox txtAd, txtMaas, txtAramaAdSoyad, txtAramaGorev;
        public System.Windows.Forms.ComboBox cmbGorev;
        private System.Windows.Forms.MaskedTextBox mskTel, mskTC, mskAramaTel;
        private System.Windows.Forms.Button btnEkle, btnSil, btnGuncelle, btnTemizle, btnOzelAra;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lblAramaBaslik, lblAramaTuru, lblKriter, lblAramaAd;
        private System.Windows.Forms.ComboBox cmbAdSoyadModu, cmbGorevModu, cmbTelModu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.cmbGorev = new System.Windows.Forms.ComboBox();
            this.mskTel = new System.Windows.Forms.MaskedTextBox();
            this.txtMaas = new System.Windows.Forms.TextBox();
            this.txtAramaGorev = new System.Windows.Forms.TextBox();
            this.txtAramaAdSoyad = new System.Windows.Forms.TextBox();
            this.mskTC = new System.Windows.Forms.MaskedTextBox();
            this.mskAramaTel = new System.Windows.Forms.MaskedTextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnOzelAra = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lblAramaBaslik = new System.Windows.Forms.Label();
            this.lblAramaTuru = new System.Windows.Forms.Label();
            this.lblKriter = new System.Windows.Forms.Label();
            this.lblAramaAd = new System.Windows.Forms.Label();
            this.cmbAdSoyadModu = new System.Windows.Forms.ComboBox();
            this.cmbGorevModu = new System.Windows.Forms.ComboBox();
            this.cmbTelModu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonel.BackgroundColor = System.Drawing.Color.White;
            this.dgvPersonel.ColumnHeadersHeight = 29;
            this.dgvPersonel.Location = new System.Drawing.Point(23, 246);
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.RowHeadersWidth = 51;
            this.dgvPersonel.Size = new System.Drawing.Size(800, 230);
            this.dgvPersonel.TabIndex = 15;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(100, 18);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(150, 22);
            this.txtAd.TabIndex = 7;
            // 
            // cmbGorev
            // 
            this.cmbGorev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorev.Location = new System.Drawing.Point(100, 48);
            this.cmbGorev.Name = "cmbGorev";
            this.cmbGorev.Size = new System.Drawing.Size(150, 24);
            this.cmbGorev.TabIndex = 8;
            // 
            // mskTel
            // 
            this.mskTel.Location = new System.Drawing.Point(100, 78);
            this.mskTel.Mask = "(999) 000-0000";
            this.mskTel.Name = "mskTel";
            this.mskTel.Size = new System.Drawing.Size(100, 22);
            this.mskTel.TabIndex = 9;
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(100, 108);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Size = new System.Drawing.Size(150, 22);
            this.txtMaas.TabIndex = 10;
            // 
            // txtAramaGorev
            // 
            this.txtAramaGorev.Location = new System.Drawing.Point(612, 99);
            this.txtAramaGorev.Name = "txtAramaGorev";
            this.txtAramaGorev.Size = new System.Drawing.Size(130, 22);
            this.txtAramaGorev.TabIndex = 3;
            this.txtAramaGorev.TextChanged += new System.EventHandler(this.txtAramaGorev_TextChanged);
            // 
            // txtAramaAdSoyad
            // 
            this.txtAramaAdSoyad.Location = new System.Drawing.Point(612, 55);
            this.txtAramaAdSoyad.Name = "txtAramaAdSoyad";
            this.txtAramaAdSoyad.Size = new System.Drawing.Size(130, 22);
            this.txtAramaAdSoyad.TabIndex = 0;
            // 
            // mskTC
            // 
            this.mskTC.Location = new System.Drawing.Point(744, 127);
            this.mskTC.Mask = "00000000000";
            this.mskTC.Name = "mskTC";
            this.mskTC.Size = new System.Drawing.Size(170, 22);
            this.mskTC.TabIndex = 5;
            this.mskTC.Visible = false;
            // 
            // mskAramaTel
            // 
            this.mskAramaTel.Location = new System.Drawing.Point(612, 155);
            this.mskAramaTel.Mask = "(999) 000-0000";
            this.mskAramaTel.Name = "mskAramaTel";
            this.mskAramaTel.Size = new System.Drawing.Size(130, 22);
            this.mskAramaTel.TabIndex = 4;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.LightGreen;
            this.btnEkle.Location = new System.Drawing.Point(280, 18);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(140, 35);
            this.btnEkle.TabIndex = 11;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Tomato;
            this.btnSil.Location = new System.Drawing.Point(430, 18);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(140, 35);
            this.btnSil.TabIndex = 13;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Khaki;
            this.btnGuncelle.Location = new System.Drawing.Point(280, 60);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(140, 35);
            this.btnGuncelle.TabIndex = 12;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(430, 60);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(140, 35);
            this.btnTemizle.TabIndex = 14;
            this.btnTemizle.Text = "Temizle";
            // 
            // btnOzelAra
            // 
            this.btnOzelAra.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOzelAra.Location = new System.Drawing.Point(628, 197);
            this.btnOzelAra.Name = "btnOzelAra";
            this.btnOzelAra.Size = new System.Drawing.Size(248, 29);
            this.btnOzelAra.TabIndex = 6;
            this.btnOzelAra.Text = "Aramayı Temizle";
            this.btnOzelAra.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(74, 23);
            this.lbl1.TabIndex = 20;
            this.lbl1.Text = "Ad Soyad:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 50);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(74, 23);
            this.lbl2.TabIndex = 21;
            this.lbl2.Text = "Görev:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 80);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(74, 23);
            this.lbl3.TabIndex = 22;
            this.lbl3.Text = "Telefon:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(20, 110);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(74, 23);
            this.lbl4.TabIndex = 23;
            this.lbl4.Text = "Maaş:";
            // 
            // lblAramaBaslik
            // 
            this.lblAramaBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAramaBaslik.Location = new System.Drawing.Point(649, 9);
            this.lblAramaBaslik.Name = "lblAramaBaslik";
            this.lblAramaBaslik.Size = new System.Drawing.Size(248, 23);
            this.lblAramaBaslik.TabIndex = 16;
            this.lblAramaBaslik.Text = "--- GELİŞMİŞ ARAMA ---";
            // 
            // lblAramaTuru
            // 
            this.lblAramaTuru.Location = new System.Drawing.Point(625, 129);
            this.lblAramaTuru.Name = "lblAramaTuru";
            this.lblAramaTuru.Size = new System.Drawing.Size(100, 20);
            this.lblAramaTuru.TabIndex = 19;
            this.lblAramaTuru.Text = "Telefon Ara:";
            // 
            // lblKriter
            // 
            this.lblKriter.Location = new System.Drawing.Point(625, 80);
            this.lblKriter.Name = "lblKriter";
            this.lblKriter.Size = new System.Drawing.Size(100, 20);
            this.lblKriter.TabIndex = 18;
            this.lblKriter.Text = "Görev Ara:";
            // 
            // lblAramaAd
            // 
            this.lblAramaAd.Location = new System.Drawing.Point(490, 40);
            this.lblAramaAd.Name = "lblAramaAd";
            this.lblAramaAd.Size = new System.Drawing.Size(100, 20);
            this.lblAramaAd.TabIndex = 17;
            this.lblAramaAd.Text = "İsimle Ara:";
            // 
            // cmbAdSoyadModu
            // 
            this.cmbAdSoyadModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdSoyadModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbAdSoyadModu.Location = new System.Drawing.Point(787, 50);
            this.cmbAdSoyadModu.Name = "cmbAdSoyadModu";
            this.cmbAdSoyadModu.Size = new System.Drawing.Size(110, 24);
            this.cmbAdSoyadModu.TabIndex = 24;
            // 
            // cmbGorevModu
            // 
            this.cmbGorevModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorevModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbGorevModu.Location = new System.Drawing.Point(787, 97);
            this.cmbGorevModu.Name = "cmbGorevModu";
            this.cmbGorevModu.Size = new System.Drawing.Size(110, 24);
            this.cmbGorevModu.TabIndex = 25;
            // 
            // cmbTelModu
            // 
            this.cmbTelModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTelModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbTelModu.Location = new System.Drawing.Point(787, 155);
            this.cmbTelModu.Name = "cmbTelModu";
            this.cmbTelModu.Size = new System.Drawing.Size(110, 24);
            this.cmbTelModu.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(625, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Ad Soyad Ara";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmPersonel
            // 
            this.ClientSize = new System.Drawing.Size(926, 544);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAramaAdSoyad);
            this.Controls.Add(this.cmbAdSoyadModu);
            this.Controls.Add(this.cmbGorevModu);
            this.Controls.Add(this.cmbTelModu);
            this.Controls.Add(this.txtAramaGorev);
            this.Controls.Add(this.mskAramaTel);
            this.Controls.Add(this.mskTC);
            this.Controls.Add(this.btnOzelAra);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.cmbGorev);
            this.Controls.Add(this.mskTel);
            this.Controls.Add(this.txtMaas);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgvPersonel);
            this.Controls.Add(this.lblAramaBaslik);
            this.Controls.Add(this.lblAramaAd);
            this.Controls.Add(this.lblKriter);
            this.Controls.Add(this.lblAramaTuru);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Name = "FrmPersonel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Yönetim Paneli";
            this.Load += new System.EventHandler(this.FrmPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}