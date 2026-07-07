using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    partial class FrmSinavIslemleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.grpVeriGiris = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblStajyerNo = new System.Windows.Forms.Label();
            this.txtStajyerNo = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.chkErkek = new System.Windows.Forms.CheckBox();
            this.chkKadin = new System.Windows.Forms.CheckBox();
            this.lblDogumTarihi = new System.Windows.Forms.Label();
            this.dtpDogumTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblBolum = new System.Windows.Forms.Label();
            this.cmbBolum = new System.Windows.Forms.ComboBox();
            this.lblSigorta = new System.Windows.Forms.Label();
            this.chkVar = new System.Windows.Forms.CheckBox();
            this.chkYok = new System.Windows.Forms.CheckBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.btnRapor = new System.Windows.Forms.Button();
            this.lblArama = new System.Windows.Forms.Label();
            this.txtAramaBolum = new System.Windows.Forms.TextBox();
            this.dgvSinavlar = new System.Windows.Forms.DataGridView();
            this.grpVeriGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinavlar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // grpVeriGiris
            // 
            this.grpVeriGiris.BackColor = System.Drawing.Color.LightCyan;
            this.grpVeriGiris.Controls.Add(this.lblID);
            this.grpVeriGiris.Controls.Add(this.txtID);
            this.grpVeriGiris.Controls.Add(this.lblStajyerNo);
            this.grpVeriGiris.Controls.Add(this.txtStajyerNo);
            this.grpVeriGiris.Controls.Add(this.lblAd);
            this.grpVeriGiris.Controls.Add(this.txtAd);
            this.grpVeriGiris.Controls.Add(this.lblSoyad);
            this.grpVeriGiris.Controls.Add(this.txtSoyad);
            this.grpVeriGiris.Controls.Add(this.lblCinsiyet);
            this.grpVeriGiris.Controls.Add(this.chkErkek);
            this.grpVeriGiris.Controls.Add(this.chkKadin);
            this.grpVeriGiris.Controls.Add(this.lblDogumTarihi);
            this.grpVeriGiris.Controls.Add(this.dtpDogumTarihi);
            this.grpVeriGiris.Controls.Add(this.lblBolum);
            this.grpVeriGiris.Controls.Add(this.cmbBolum);
            this.grpVeriGiris.Controls.Add(this.lblSigorta);
            this.grpVeriGiris.Controls.Add(this.chkVar);
            this.grpVeriGiris.Controls.Add(this.chkYok);
            this.grpVeriGiris.Controls.Add(this.btnEkle);
            this.grpVeriGiris.Controls.Add(this.btnSil);
            this.grpVeriGiris.Controls.Add(this.btnDegistir);
            this.grpVeriGiris.Controls.Add(this.btnRapor);
            this.grpVeriGiris.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpVeriGiris.Location = new System.Drawing.Point(15, 65);
            this.grpVeriGiris.Name = "grpVeriGiris";
            this.grpVeriGiris.Size = new System.Drawing.Size(340, 460);
            this.grpVeriGiris.TabIndex = 1;
            this.grpVeriGiris.TabStop = false;
            this.grpVeriGiris.Text = "Stajyer Bilgileri Formu";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(15, 35);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 20);
            this.lblID.TabIndex = 16;
            this.lblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtID.Location = new System.Drawing.Point(130, 32);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(180, 27);
            this.txtID.TabIndex = 17;
            // 
            // lblStajyerNo
            // 
            this.lblStajyerNo.AutoSize = true;
            this.lblStajyerNo.Location = new System.Drawing.Point(15, 70);
            this.lblStajyerNo.Name = "lblStajyerNo";
            this.lblStajyerNo.Size = new System.Drawing.Size(86, 20);
            this.lblStajyerNo.TabIndex = 0;
            this.lblStajyerNo.Text = "Stajyer No:";
            // 
            // txtStajyerNo
            // 
            this.txtStajyerNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStajyerNo.Location = new System.Drawing.Point(130, 67);
            this.txtStajyerNo.Name = "txtStajyerNo";
            this.txtStajyerNo.Size = new System.Drawing.Size(180, 27);
            this.txtStajyerNo.TabIndex = 1;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(15, 105);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(37, 20);
            this.lblAd.TabIndex = 2;
            this.lblAd.Text = "Adı:";
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAd.Location = new System.Drawing.Point(130, 102);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(180, 27);
            this.txtAd.TabIndex = 3;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Location = new System.Drawing.Point(15, 140);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(59, 20);
            this.lblSoyad.TabIndex = 18;
            this.lblSoyad.Text = "Soyadı:";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoyad.Location = new System.Drawing.Point(130, 137);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(180, 27);
            this.txtSoyad.TabIndex = 19;
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Location = new System.Drawing.Point(15, 175);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(68, 20);
            this.lblCinsiyet.TabIndex = 4;
            this.lblCinsiyet.Text = "Cinsiyet:";
            // 
            // chkErkek
            // 
            this.chkErkek.AutoSize = true;
            this.chkErkek.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkErkek.Location = new System.Drawing.Point(130, 174);
            this.chkErkek.Name = "chkErkek";
            this.chkErkek.Size = new System.Drawing.Size(66, 24);
            this.chkErkek.TabIndex = 5;
            this.chkErkek.Text = "Erkek";
            this.chkErkek.UseVisualStyleBackColor = true;
            // 
            // chkKadin
            // 
            this.chkKadin.AutoSize = true;
            this.chkKadin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkKadin.Location = new System.Drawing.Point(210, 174);
            this.chkKadin.Name = "chkKadin";
            this.chkKadin.Size = new System.Drawing.Size(69, 24);
            this.chkKadin.TabIndex = 6;
            this.chkKadin.Text = "Kadın";
            this.chkKadin.UseVisualStyleBackColor = true;
            // 
            // lblDogumTarihi
            // 
            this.lblDogumTarihi.AutoSize = true;
            this.lblDogumTarihi.Location = new System.Drawing.Point(15, 210);
            this.lblDogumTarihi.Name = "lblDogumTarihi";
            this.lblDogumTarihi.Size = new System.Drawing.Size(108, 20);
            this.lblDogumTarihi.TabIndex = 7;
            this.lblDogumTarihi.Text = "Doğum Tarihi:";
            // 
            // dtpDogumTarihi
            // 
            this.dtpDogumTarihi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDogumTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDogumTarihi.Location = new System.Drawing.Point(130, 207);
            this.dtpDogumTarihi.Name = "dtpDogumTarihi";
            this.dtpDogumTarihi.Size = new System.Drawing.Size(180, 27);
            this.dtpDogumTarihi.TabIndex = 8;
            // 
            // lblBolum
            // 
            this.lblBolum.AutoSize = true;
            this.lblBolum.Location = new System.Drawing.Point(15, 245);
            this.lblBolum.Name = "lblBolum";
            this.lblBolum.Size = new System.Drawing.Size(106, 20);
            this.lblBolum.TabIndex = 9;
            this.lblBolum.Text = "Bölüm / Alan:";
            // 
            // cmbBolum
            // 
            this.cmbBolum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBolum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBolum.FormattingEnabled = true;
            this.cmbBolum.Items.AddRange(new object[] {
            "Yazılım Geliştirme",
            "Donanım / Ağ",
            "Mobil Programlama",
            "Tasarım",
            "Pazarlama"});
            this.cmbBolum.Location = new System.Drawing.Point(130, 242);
            this.cmbBolum.Name = "cmbBolum";
            this.cmbBolum.Size = new System.Drawing.Size(180, 28);
            this.cmbBolum.TabIndex = 10;
            // 
            // lblSigorta
            // 
            this.lblSigorta.AutoSize = true;
            this.lblSigorta.Location = new System.Drawing.Point(6, 290);
            this.lblSigorta.Name = "lblSigorta";
            this.lblSigorta.Size = new System.Drawing.Size(125, 20);
            this.lblSigorta.TabIndex = 11;
            this.lblSigorta.Text = "Sigorta Durumu:";
            // 
            // chkVar
            // 
            this.chkVar.AutoSize = true;
            this.chkVar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVar.Location = new System.Drawing.Point(145, 289);
            this.chkVar.Name = "chkVar";
            this.chkVar.Size = new System.Drawing.Size(52, 24);
            this.chkVar.TabIndex = 12;
            this.chkVar.Text = "Var";
            this.chkVar.UseVisualStyleBackColor = true;
            // 
            // chkYok
            // 
            this.chkYok.AutoSize = true;
            this.chkYok.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkYok.Location = new System.Drawing.Point(215, 289);
            this.chkYok.Name = "chkYok";
            this.chkYok.Size = new System.Drawing.Size(54, 24);
            this.chkYok.TabIndex = 13;
            this.chkYok.Text = "Yok";
            this.chkYok.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(15, 335);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(145, 40);
            this.btnEkle.TabIndex = 14;
            this.btnEkle.Text = "➕ EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click_1);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(175, 335);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(145, 40);
            this.btnSil.TabIndex = 15;
            this.btnSil.Text = "❌ SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            // 
            // btnDegistir
            // 
            this.btnDegistir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDegistir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDegistir.ForeColor = System.Drawing.Color.White;
            this.btnDegistir.Location = new System.Drawing.Point(15, 390);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(145, 40);
            this.btnDegistir.TabIndex = 16;
            this.btnDegistir.Text = "🔄 DEĞİŞTİR";
            this.btnDegistir.UseVisualStyleBackColor = false;
            // 
            // btnRapor
            // 
            this.btnRapor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnRapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapor.ForeColor = System.Drawing.Color.White;
            this.btnRapor.Location = new System.Drawing.Point(175, 390);
            this.btnRapor.Name = "btnRapor";
            this.btnRapor.Size = new System.Drawing.Size(145, 40);
            this.btnRapor.TabIndex = 17;
            this.btnRapor.Text = "📊 RAPOR AL";
            this.btnRapor.UseVisualStyleBackColor = false;
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblArama.Location = new System.Drawing.Point(375, 75);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(160, 20);
            this.lblArama.TabIndex = 3;
            this.lblArama.Text = "🔍 Bölüme Göre Ara:";
            // 
            // txtAramaBolum
            // 
            this.txtAramaBolum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAramaBolum.Location = new System.Drawing.Point(545, 72);
            this.txtAramaBolum.Name = "txtAramaBolum";
            this.txtAramaBolum.Size = new System.Drawing.Size(220, 27);
            this.txtAramaBolum.TabIndex = 4;
            // 
            // dgvSinavlar
            // 
            this.dgvSinavlar.AllowUserToAddRows = false;
            this.dgvSinavlar.AllowUserToDeleteRows = false;
            this.dgvSinavlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinavlar.BackgroundColor = System.Drawing.Color.White;
            this.dgvSinavlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSinavlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinavlar.Location = new System.Drawing.Point(361, 105);
            this.dgvSinavlar.MultiSelect = false;
            this.dgvSinavlar.Name = "dgvSinavlar";
            this.dgvSinavlar.ReadOnly = true;
            this.dgvSinavlar.RowHeadersVisible = false;
            this.dgvSinavlar.RowHeadersWidth = 51;
            this.dgvSinavlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinavlar.Size = new System.Drawing.Size(615, 410);
            this.dgvSinavlar.TabIndex = 2;
            this.dgvSinavlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinavlar_CellContentClick_1);
            // 
            // FrmSinavIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1020, 550);
            this.Controls.Add(this.lblArama);
            this.Controls.Add(this.txtAramaBolum);
            this.Controls.Add(this.dgvSinavlar);
            this.Controls.Add(this.grpVeriGiris);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSinavIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stajyer Kayıt ve Yönetim Paneli";
            this.Load += new System.EventHandler(this.FrmSinavIslemleri_Load_1);
            this.grpVeriGiris.ResumeLayout(false);
            this.grpVeriGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinavlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.GroupBox grpVeriGiris;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblStajyerNo;
        private System.Windows.Forms.TextBox txtStajyerNo;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label lblCinsiyet;
        private System.Windows.Forms.CheckBox chkErkek;
        private System.Windows.Forms.CheckBox chkKadin;
        private System.Windows.Forms.Label lblDogumTarihi;
        private System.Windows.Forms.DateTimePicker dtpDogumTarihi;
        private System.Windows.Forms.Label lblBolum;
        private System.Windows.Forms.ComboBox cmbBolum;
        private System.Windows.Forms.Label lblSigorta;
        private System.Windows.Forms.CheckBox chkVar;
        private System.Windows.Forms.CheckBox chkYok;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnDegistir;
        private System.Windows.Forms.Button btnRapor;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.TextBox txtAramaBolum;
        private System.Windows.Forms.DataGridView dgvSinavlar;
    }
}