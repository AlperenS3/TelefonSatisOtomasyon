namespace TelefonSatisOtomasyon
{
    partial class FrmLogin
    {
        private System.Windows.Forms.TextBox txtKullanici, txtSifre;
        private System.Windows.Forms.Button btnGiris, btnIptal;
        private System.Windows.Forms.Label lbl1, lbl2, lblBaslik;

        private void InitializeComponent()
        {
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblBaslik
            this.lblBaslik.Text = "TELEFON TAKİP SİSTEMİ GİRİŞİ";
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(50, 25);
            this.lblBaslik.Size = new System.Drawing.Size(300, 30);

            // Kullanıcı Girişi Alanları
            this.lbl1.Text = "Kullanıcı Adı:";
            this.lbl1.Location = new System.Drawing.Point(50, 80);
            this.txtKullanici.Location = new System.Drawing.Point(50, 100);
            this.txtKullanici.Size = new System.Drawing.Size(250, 25);

            this.lbl2.Text = "Şifre:";
            this.lbl2.Location = new System.Drawing.Point(50, 140);
            this.txtSifre.Location = new System.Drawing.Point(50, 160);
            this.txtSifre.Size = new System.Drawing.Size(250, 25);
            this.txtSifre.UseSystemPasswordChar = true; // Şifreyi gizle (****)

            // Butonlar
            this.btnGiris.Text = "GİRİŞ YAP";
            this.btnGiris.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGiris.ForeColor = System.Drawing.Color.White;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.Location = new System.Drawing.Point(50, 210);
            this.btnGiris.Size = new System.Drawing.Size(120, 40);
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);

            this.btnIptal.Text = "İPTAL";
            this.btnIptal.BackColor = System.Drawing.Color.IndianRed;
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Location = new System.Drawing.Point(180, 210);
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // Form Ayarları
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblBaslik, lbl1, txtKullanici, lbl2, txtSifre, btnGiris, btnIptal });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Kenarlıksız modern görünüm
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}