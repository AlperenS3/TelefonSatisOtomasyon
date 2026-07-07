namespace TelefonSatisOtomasyon
{
    partial class FrmMusteriSilOnay
    {
        private System.ComponentModel.IContainer components = null;

        // HOCA KURALI: Telefon için uygun nesne MaskedTextBox olarak mühürlendi
        public System.Windows.Forms.TextBox txtAdSoyad, txtEmail;
        public System.Windows.Forms.MaskedTextBox txtTelefon; // Nesne tipi güncellendi
        private System.Windows.Forms.Button btnOnayla, btnIptal;
        private System.Windows.Forms.Label lblKritikMesaj, lbl1, lbl2, lbl3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblKritikMesaj = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(100, 67);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.ReadOnly = true;
            this.txtAdSoyad.Size = new System.Drawing.Size(250, 22);
            this.txtAdSoyad.TabIndex = 2;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(100, 102);
            this.txtTelefon.Mask = "(999) 000-0000";
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.ReadOnly = true;
            this.txtTelefon.Size = new System.Drawing.Size(250, 22);
            this.txtTelefon.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 137);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(250, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.DarkRed;
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(100, 185);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(120, 40);
            this.btnOnayla.TabIndex = 7;
            this.btnOnayla.Text = "HER ŞEYİ SİL";
            this.btnOnayla.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Silver;
            this.btnIptal.Location = new System.Drawing.Point(230, 185);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 8;
            this.btnIptal.Text = "VAZGEÇ";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // lblKritikMesaj
            // 
            this.lblKritikMesaj.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKritikMesaj.ForeColor = System.Drawing.Color.Red;
            this.lblKritikMesaj.Location = new System.Drawing.Point(12, 12);
            this.lblKritikMesaj.Name = "lblKritikMesaj";
            this.lblKritikMesaj.Size = new System.Drawing.Size(360, 45);
            this.lblKritikMesaj.TabIndex = 0;
            this.lblKritikMesaj.Text = "BU MÜŞTERİYİ SİLERSENİZ TÜM SATIŞ GEÇMİŞİ DE SİLİNECEKTİR! Onaylıyor musunuz?";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(25, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(69, 23);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Müşteri:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(25, 105);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(69, 23);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Telefon:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(25, 140);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(69, 23);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "E-Mail:";
            // 
            // FrmMusteriSilOnay
            // 
            this.ClientSize = new System.Drawing.Size(384, 250);
            this.Controls.Add(this.lblKritikMesaj);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMusteriSilOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müşteri Kaydı Silme Onayı";
            this.Load += new System.EventHandler(this.FrmMusteriSilOnay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}