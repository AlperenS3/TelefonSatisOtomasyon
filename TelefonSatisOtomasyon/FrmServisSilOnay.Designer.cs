namespace TelefonSatisOtomasyon
{
    partial class FrmServisSilOnay
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox txtMusteri, txtCihaz, txtAriza, txtUcret; // Public
        private System.Windows.Forms.Button btnOnayla, btnIptal;
        private System.Windows.Forms.Label lblUyari, lbl1, lbl2, lbl3, lbl4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMusteri = new System.Windows.Forms.TextBox();
            this.txtCihaz = new System.Windows.Forms.TextBox();
            this.txtAriza = new System.Windows.Forms.TextBox();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblUyari = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMusteri
            // 
            this.txtMusteri.Location = new System.Drawing.Point(90, 67);
            this.txtMusteri.Name = "txtMusteri";
            this.txtMusteri.ReadOnly = true;
            this.txtMusteri.Size = new System.Drawing.Size(260, 22);
            this.txtMusteri.TabIndex = 2;
            // 
            // txtCihaz
            // 
            this.txtCihaz.Location = new System.Drawing.Point(90, 97);
            this.txtCihaz.Name = "txtCihaz";
            this.txtCihaz.ReadOnly = true;
            this.txtCihaz.Size = new System.Drawing.Size(260, 22);
            this.txtCihaz.TabIndex = 4;
            // 
            // txtAriza
            // 
            this.txtAriza.Location = new System.Drawing.Point(90, 127);
            this.txtAriza.Name = "txtAriza";
            this.txtAriza.ReadOnly = true;
            this.txtAriza.Size = new System.Drawing.Size(260, 22);
            this.txtAriza.TabIndex = 6;
            // 
            // txtUcret
            // 
            this.txtUcret.Location = new System.Drawing.Point(90, 157);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.ReadOnly = true;
            this.txtUcret.Size = new System.Drawing.Size(100, 22);
            this.txtUcret.TabIndex = 8;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.Crimson;
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(90, 195);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(120, 40);
            this.btnOnayla.TabIndex = 9;
            this.btnOnayla.Text = "KAYDI SİL";
            this.btnOnayla.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Silver;
            this.btnIptal.Location = new System.Drawing.Point(230, 195);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 10;
            this.btnIptal.Text = "VAZGEÇ";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // lblUyari
            // 
            this.lblUyari.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUyari.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUyari.Location = new System.Drawing.Point(12, 12);
            this.lblUyari.Name = "lblUyari";
            this.lblUyari.Size = new System.Drawing.Size(360, 45);
            this.lblUyari.TabIndex = 0;
            this.lblUyari.Text = "BU TEKNİK SERVİS KAYDI KALICI OLARAK SİLİNECEKTİR! Onaylıyor musunuz?";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(64, 23);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Müşteri:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 100);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(64, 23);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Cihaz:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 130);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(64, 23);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "Arıza:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(20, 160);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(64, 23);
            this.lbl4.TabIndex = 7;
            this.lbl4.Text = "Ücret:";
            // 
            // FrmServisSilOnay
            // 
            this.ClientSize = new System.Drawing.Size(384, 255);
            this.Controls.Add(this.lblUyari);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtMusteri);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtCihaz);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtAriza);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmServisSilOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Teknik Servis Silme Onayı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}