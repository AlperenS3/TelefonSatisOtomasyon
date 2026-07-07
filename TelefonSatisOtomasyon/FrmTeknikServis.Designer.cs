namespace TelefonSatisOtomasyon
{
    partial class FrmTeknikServis
    {
        private System.ComponentModel.IContainer components = null;

        // Mevcut Nesneler
        private System.Windows.Forms.DataGridView dgvServis;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.TextBox txtCihaz;
        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.TextBox txtAriza;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5, lbl6;

        // --- Gelişmiş Arama Nesneleri (Yapı Korundu) ---
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.CheckBox chkDetayliArama;
        private System.Windows.Forms.Panel pnlGelismisArama;
        private System.Windows.Forms.TextBox txtBirebirArama;
        private System.Windows.Forms.CheckBox chkBirebir;
        private System.Windows.Forms.CheckBox chkAktifFiltre;
        private System.Windows.Forms.Label lblHizliArama;

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
            this.dgvServis = new System.Windows.Forms.DataGridView();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.txtCihaz = new System.Windows.Forms.TextBox();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.txtAriza = new System.Windows.Forms.TextBox();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lblHizliArama = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.chkDetayliArama = new System.Windows.Forms.CheckBox();
            this.pnlGelismisArama = new System.Windows.Forms.Panel();
            this.txtBirebirArama = new System.Windows.Forms.TextBox();
            this.chkAktifFiltre = new System.Windows.Forms.CheckBox();
            this.chkBirebir = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServis)).BeginInit();
            this.pnlGelismisArama.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvServis
            // 
            this.dgvServis.AllowUserToAddRows = false;
            this.dgvServis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServis.BackgroundColor = System.Drawing.Color.White;
            this.dgvServis.ColumnHeadersHeight = 29;
            this.dgvServis.Location = new System.Drawing.Point(320, 20);
            this.dgvServis.Name = "dgvServis";
            this.dgvServis.ReadOnly = true;
            this.dgvServis.RowHeadersWidth = 51;
            this.dgvServis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServis.Size = new System.Drawing.Size(540, 360);
            this.dgvServis.TabIndex = 10;
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Location = new System.Drawing.Point(111, 20);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(189, 24);
            this.cmbMusteri.TabIndex = 10;
            // 
            // txtCihaz
            // 
            this.txtCihaz.Location = new System.Drawing.Point(111, 55);
            this.txtCihaz.Name = "txtCihaz";
            this.txtCihaz.Size = new System.Drawing.Size(189, 22);
            this.txtCihaz.TabIndex = 11;
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(111, 90);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.Size = new System.Drawing.Size(189, 22);
            this.txtIMEI.TabIndex = 12;
            // 
            // txtAriza
            // 
            this.txtAriza.Location = new System.Drawing.Point(111, 125);
            this.txtAriza.Multiline = true;
            this.txtAriza.Name = "txtAriza";
            this.txtAriza.Size = new System.Drawing.Size(189, 60);
            this.txtAriza.TabIndex = 13;
            // 
            // cmbDurum
            // 
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurum.Location = new System.Drawing.Point(111, 195);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(189, 24);
            this.cmbDurum.TabIndex = 14;
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(111, 230);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(189, 22);
            this.txtFiyat.TabIndex = 15;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.LightGreen;
            this.btnKaydet.Location = new System.Drawing.Point(100, 270);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(95, 40);
            this.btnKaydet.TabIndex = 16;
            this.btnKaydet.Text = "KAYIT EKLE";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Khaki;
            this.btnGuncelle.Location = new System.Drawing.Point(205, 270);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(95, 40);
            this.btnGuncelle.TabIndex = 17;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.LightCoral;
            this.btnSil.Location = new System.Drawing.Point(100, 320);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(95, 40);
            this.btnSil.TabIndex = 18;
            this.btnSil.Text = "KAYIT SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTemizle.Location = new System.Drawing.Point(205, 320);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(95, 40);
            this.btnTemizle.TabIndex = 19;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 23);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(69, 23);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Müşteri:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 58);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 23);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Cihaz Model:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 93);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(85, 23);
            this.lbl3.TabIndex = 6;
            this.lbl3.Text = "IMEI:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(5, 128);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(100, 23);
            this.lbl4.TabIndex = 7;
            this.lbl4.Text = "Arıza Detay:";
            // 
            // lbl5
            // 
            this.lbl5.Location = new System.Drawing.Point(20, 198);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(85, 23);
            this.lbl5.TabIndex = 8;
            this.lbl5.Text = "Durum:";
            // 
            // lbl6
            // 
            this.lbl6.Location = new System.Drawing.Point(20, 233);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(85, 23);
            this.lbl6.TabIndex = 9;
            this.lbl6.Text = "Ücret (₺):";
            // 
            // lblHizliArama
            // 
            this.lblHizliArama.AutoSize = true;
            this.lblHizliArama.Location = new System.Drawing.Point(320, 395);
            this.lblHizliArama.Name = "lblHizliArama";
            this.lblHizliArama.Size = new System.Drawing.Size(153, 17);
            this.lblHizliArama.TabIndex = 3;
            this.lblHizliArama.Text = "Hızlı Arama (Ad/Cihaz):";
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(460, 392);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(160, 22);
            this.txtArama.TabIndex = 2;
            // 
            // chkDetayliArama
            // 
            this.chkDetayliArama.AutoSize = true;
            this.chkDetayliArama.Location = new System.Drawing.Point(640, 392);
            this.chkDetayliArama.Name = "chkDetayliArama";
            this.chkDetayliArama.Size = new System.Drawing.Size(102, 21);
            this.chkDetayliArama.TabIndex = 1;
            this.chkDetayliArama.Text = "IMEI Filtrele";
            // 
            // pnlGelismisArama
            // 
            this.pnlGelismisArama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGelismisArama.Controls.Add(this.txtBirebirArama);
            this.pnlGelismisArama.Controls.Add(this.chkAktifFiltre);
            this.pnlGelismisArama.Controls.Add(this.chkBirebir);
            this.pnlGelismisArama.Location = new System.Drawing.Point(320, 420);
            this.pnlGelismisArama.Name = "pnlGelismisArama";
            this.pnlGelismisArama.Size = new System.Drawing.Size(540, 40);
            this.pnlGelismisArama.TabIndex = 0;
            this.pnlGelismisArama.Visible = false;
            // 
            // txtBirebirArama
            // 
            this.txtBirebirArama.Location = new System.Drawing.Point(200, 8);
            this.txtBirebirArama.Name = "txtBirebirArama";
            this.txtBirebirArama.Size = new System.Drawing.Size(320, 22);
            this.txtBirebirArama.TabIndex = 0;
            // 
            // chkAktifFiltre
            // 
            this.chkAktifFiltre.AutoSize = true;
            this.chkAktifFiltre.Location = new System.Drawing.Point(105, 10);
            this.chkAktifFiltre.Name = "chkAktifFiltre";
            this.chkAktifFiltre.Size = new System.Drawing.Size(92, 21);
            this.chkAktifFiltre.TabIndex = 1;
            this.chkAktifFiltre.Text = "Aktif Filtre";
            // 
            // chkBirebir
            // 
            this.chkBirebir.AutoSize = true;
            this.chkBirebir.Location = new System.Drawing.Point(10, 10);
            this.chkBirebir.Name = "chkBirebir";
            this.chkBirebir.Size = new System.Drawing.Size(97, 21);
            this.chkBirebir.TabIndex = 2;
            this.chkBirebir.Text = "Birebir mi?";
            // 
            // FrmTeknikServis
            // 
            this.ClientSize = new System.Drawing.Size(880, 480);
            this.Controls.Add(this.pnlGelismisArama);
            this.Controls.Add(this.chkDetayliArama);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.lblHizliArama);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.txtCihaz);
            this.Controls.Add(this.txtIMEI);
            this.Controls.Add(this.txtAriza);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgvServis);
            this.Name = "FrmTeknikServis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teknik Servis Yönetimi";
            this.Load += new System.EventHandler(this.FrmTeknikServis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServis)).EndInit();
            this.pnlGelismisArama.ResumeLayout(false);
            this.pnlGelismisArama.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}