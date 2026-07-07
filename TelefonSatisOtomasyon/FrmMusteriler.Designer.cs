namespace TelefonSatisOtomasyon
{
    partial class FrmMusteriler
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMusteriler;
        private System.Windows.Forms.TextBox txtAdSoyad, txtEmail, txtAdres, txtArama;
        private System.Windows.Forms.MaskedTextBox mskTelefon, mskAramaTelefon;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5, lblOzelArama;
        private System.Windows.Forms.Button btnKaydet, btnGuncelle, btnSil, btnTemizle;
        private System.Windows.Forms.CheckBox chkDetayliArama;
        private System.Windows.Forms.ComboBox cmbAdSoyadModu, cmbTelefonModu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.mskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.mskAramaTelefon = new System.Windows.Forms.MaskedTextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lblOzelArama = new System.Windows.Forms.Label();
            this.chkDetayliArama = new System.Windows.Forms.CheckBox();
            this.cmbAdSoyadModu = new System.Windows.Forms.ComboBox();
            this.cmbTelefonModu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMusteriler
            // 
            this.dgvMusteriler.AllowUserToAddRows = false;
            this.dgvMusteriler.AllowUserToDeleteRows = false;
            this.dgvMusteriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMusteriler.BackgroundColor = System.Drawing.Color.White;
            this.dgvMusteriler.ColumnHeadersHeight = 29;
            this.dgvMusteriler.Location = new System.Drawing.Point(310, 115);
            this.dgvMusteriler.Name = "dgvMusteriler";
            this.dgvMusteriler.ReadOnly = true;
            this.dgvMusteriler.RowHeadersWidth = 51;
            this.dgvMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusteriler.Size = new System.Drawing.Size(630, 250);
            this.dgvMusteriler.TabIndex = 9;
            this.dgvMusteriler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusteriler_CellContentClick);
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(110, 20);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(170, 22);
            this.txtAdSoyad.TabIndex = 0;
            // 
            // mskTelefon
            // 
            this.mskTelefon.Location = new System.Drawing.Point(110, 55);
            this.mskTelefon.Mask = "(999) 000-0000";
            this.mskTelefon.Name = "mskTelefon";
            this.mskTelefon.Size = new System.Drawing.Size(170, 22);
            this.mskTelefon.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(170, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(110, 125);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(170, 60);
            this.txtAdres.TabIndex = 3;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(415, 20);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(150, 22);
            this.txtArama.TabIndex = 8;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // mskAramaTelefon
            // 
            this.mskAramaTelefon.Location = new System.Drawing.Point(415, 58);
            this.mskAramaTelefon.Mask = "(999) 000-0000";
            this.mskAramaTelefon.Name = "mskAramaTelefon";
            this.mskAramaTelefon.Size = new System.Drawing.Size(150, 22);
            this.mskAramaTelefon.TabIndex = 19;
            this.mskAramaTelefon.TextChanged += new System.EventHandler(this.mskAramaTelefon_TextChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(110, 200);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(80, 30);
            this.btnKaydet.TabIndex = 26;
            this.btnKaydet.Text = "Ekle";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(200, 200);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(80, 30);
            this.btnGuncelle.TabIndex = 27;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(110, 235);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(80, 30);
            this.btnSil.TabIndex = 28;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(200, 235);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 30);
            this.btnTemizle.TabIndex = 29;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(84, 23);
            this.lbl1.TabIndex = 21;
            this.lbl1.Text = "Ad Soyad:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 55);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(84, 23);
            this.lbl2.TabIndex = 22;
            this.lbl2.Text = "Telefon:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 90);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(84, 23);
            this.lbl3.TabIndex = 23;
            this.lbl3.Text = "E-Posta:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(20, 125);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(84, 23);
            this.lbl4.TabIndex = 24;
            this.lbl4.Text = "Adres:";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl5.Location = new System.Drawing.Point(301, 22);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(108, 20);
            this.lbl5.TabIndex = 25;
            this.lbl5.Text = "Ad Soyad Ara:";
            // 
            // lblOzelArama
            // 
            this.lblOzelArama.AutoSize = true;
            this.lblOzelArama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOzelArama.Location = new System.Drawing.Point(299, 59);
            this.lblOzelArama.Name = "lblOzelArama";
            this.lblOzelArama.Size = new System.Drawing.Size(110, 20);
            this.lblOzelArama.TabIndex = 20;
            this.lblOzelArama.Text = "Telefon Sorgu:";
            // 
            // chkDetayliArama
            // 
            this.chkDetayliArama.AutoSize = true;
            this.chkDetayliArama.Location = new System.Drawing.Point(700, 59);
            this.chkDetayliArama.Name = "chkDetayliArama";
            this.chkDetayliArama.Size = new System.Drawing.Size(130, 21);
            this.chkDetayliArama.TabIndex = 15;
            this.chkDetayliArama.Text = "Çoklu Filtreleme";
            this.chkDetayliArama.CheckedChanged += new System.EventHandler(this.chkDetayliArama_CheckedChanged);
            // 
            // cmbAdSoyadModu
            // 
            this.cmbAdSoyadModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdSoyadModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbAdSoyadModu.Location = new System.Drawing.Point(572, 19);
            this.cmbAdSoyadModu.Name = "cmbAdSoyadModu";
            this.cmbAdSoyadModu.Size = new System.Drawing.Size(115, 24);
            this.cmbAdSoyadModu.TabIndex = 14;
            this.cmbAdSoyadModu.SelectedIndexChanged += new System.EventHandler(this.KriterDegisti);
            // 
            // cmbTelefonModu
            // 
            this.cmbTelefonModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTelefonModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbTelefonModu.Location = new System.Drawing.Point(572, 57);
            this.cmbTelefonModu.Name = "cmbTelefonModu";
            this.cmbTelefonModu.Size = new System.Drawing.Size(115, 24);
            this.cmbTelefonModu.TabIndex = 16;
            this.cmbTelefonModu.SelectedIndexChanged += new System.EventHandler(this.KriterDegisti);
            // 
            // FrmMusteriler
            // 
            this.ClientSize = new System.Drawing.Size(960, 390);
            this.Controls.Add(this.mskAramaTelefon);
            this.Controls.Add(this.lblOzelArama);
            this.Controls.Add(this.cmbTelefonModu);
            this.Controls.Add(this.cmbAdSoyadModu);
            this.Controls.Add(this.chkDetayliArama);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.mskTelefon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgvMusteriler);
            this.Name = "FrmMusteriler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Yönetim Paneli";
            this.Load += new System.EventHandler(this.FrmMusteriler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}