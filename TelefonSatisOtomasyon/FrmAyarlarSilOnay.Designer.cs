namespace TelefonSatisOtomasyon
{
    partial class FrmAyarlarSilOnay
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox txtBilgi1, txtBilgi2; // Public
        public System.Windows.Forms.Label lblBaslik, lbl1, lbl2; // Public
        public System.Windows.Forms.Button btnOnayla, btnIptal; // Public yaptık

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBilgi1 = new System.Windows.Forms.TextBox();
            this.txtBilgi2 = new System.Windows.Forms.TextBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBilgi1
            // 
            this.txtBilgi1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBilgi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBilgi1.Location = new System.Drawing.Point(115, 62);
            this.txtBilgi1.Name = "txtBilgi1";
            this.txtBilgi1.ReadOnly = true;
            this.txtBilgi1.Size = new System.Drawing.Size(235, 22);
            this.txtBilgi1.TabIndex = 2;
            // 
            // txtBilgi2
            // 
            this.txtBilgi2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBilgi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBilgi2.Location = new System.Drawing.Point(115, 90);
            this.txtBilgi2.Name = "txtBilgi2";
            this.txtBilgi2.ReadOnly = true;
            this.txtBilgi2.Size = new System.Drawing.Size(235, 22);
            this.txtBilgi2.TabIndex = 4;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBaslik.Location = new System.Drawing.Point(12, 12);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(360, 40);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kayıt Silme Onayı";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 64);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(85, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Bilgi 1:";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 92);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 16);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Bilgi 2:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.Crimson;
            this.btnOnayla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnayla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(115, 128);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(110, 32);
            this.btnOnayla.TabIndex = 5;
            this.btnOnayla.Text = "SİL";
            this.btnOnayla.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.DarkGray;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(240, 128);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(110, 32);
            this.btnIptal.TabIndex = 6;
            this.btnIptal.Text = "VAZGEÇ";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // FrmAyarlarSilOnay
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 180);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.txtBilgi2);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtBilgi1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAyarlarSilOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Onay Gerekli";
            this.Load += new System.EventHandler(this.FrmAyarlarSilOnay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}