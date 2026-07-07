namespace TelefonSatisOtomasyon
{
    partial class FrmServisGuncelle
    {
        private System.ComponentModel.IContainer components = null;

        // HOCA KURALI: PUBLIC NESNELER (Dışarıdan veri taşımak için)
        public System.Windows.Forms.ComboBox cmbMusteri, cmbDurum;
        public System.Windows.Forms.TextBox txtCihaz, txtIMEI, txtFiyat;
        public System.Windows.Forms.RichTextBox rchAriza;
        public System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5, lbl6;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.txtCihaz = new System.Windows.Forms.TextBox();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.rchAriza = new System.Windows.Forms.RichTextBox();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Label 1: Müşteri
            this.lbl1.Text = "Müşteri:";
            this.lbl1.Location = new System.Drawing.Point(30, 30);
            this.lbl1.AutoSize = true;

            this.cmbMusteri.Location = new System.Drawing.Point(130, 27);
            this.cmbMusteri.Size = new System.Drawing.Size(180, 25);
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Label 2: Cihaz
            this.lbl2.Text = "Cihaz Model:";
            this.lbl2.Location = new System.Drawing.Point(30, 65);
            this.lbl2.AutoSize = true;

            this.txtCihaz.Location = new System.Drawing.Point(130, 62);
            this.txtCihaz.Size = new System.Drawing.Size(180, 22);

            // Label 3: IMEI
            this.lbl3.Text = "IMEI No:";
            this.lbl3.Location = new System.Drawing.Point(30, 100);
            this.lbl3.AutoSize = true;

            this.txtIMEI.Location = new System.Drawing.Point(130, 97);
            this.txtIMEI.Size = new System.Drawing.Size(180, 22);

            // Label 4: Arıza Detayı
            this.lbl4.Text = "Arıza Detayı:";
            this.lbl4.Location = new System.Drawing.Point(30, 135);
            this.lbl4.AutoSize = true;

            this.rchAriza.Location = new System.Drawing.Point(130, 132);
            this.rchAriza.Size = new System.Drawing.Size(180, 80);

            // Label 5: Durum
            this.lbl5.Text = "Servis Durumu:";
            this.lbl5.Location = new System.Drawing.Point(30, 225);
            this.lbl5.AutoSize = true;

            this.cmbDurum.Location = new System.Drawing.Point(130, 222);
            this.cmbDurum.Size = new System.Drawing.Size(180, 25);
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Label 6: Fiyat
            this.lbl6.Text = "Tahmini Ücret:";
            this.lbl6.Location = new System.Drawing.Point(30, 260);
            this.lbl6.AutoSize = true;

            this.txtFiyat.Location = new System.Drawing.Point(130, 257);
            this.txtFiyat.Size = new System.Drawing.Size(180, 22);

            // Button: Güncelle
            this.btnGuncelle.Text = "KAYDI GÜNCELLE";
            this.btnGuncelle.Location = new System.Drawing.Point(30, 310);
            this.btnGuncelle.Size = new System.Drawing.Size(280, 45);
            this.btnGuncelle.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // FrmServisGuncelle
            this.ClientSize = new System.Drawing.Size(350, 390);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lbl1, cmbMusteri, lbl2, txtCihaz, lbl3, txtIMEI,
                lbl4, rchAriza, lbl5, cmbDurum, lbl6, txtFiyat, btnGuncelle
            });
            this.Name = "FrmServisGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Teknik Servis Kaydı Düzenle";
            this.Load += new System.EventHandler(this.FrmServisGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}