namespace TelefonSatisOtomasyon
{
    partial class FrmPersonelSilOnay
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox txtAdSoyad, txtGorev, txtMaas; // Public
        private System.Windows.Forms.Button btnOnayla, btnIptal;
        private System.Windows.Forms.Label lblMesaj, lbl1, lbl2, lbl3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtGorev = new System.Windows.Forms.TextBox();
            this.txtMaas = new System.Windows.Forms.TextBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblMesaj = new System.Windows.Forms.Label();
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
            // txtGorev
            // 
            this.txtGorev.Location = new System.Drawing.Point(100, 102);
            this.txtGorev.Name = "txtGorev";
            this.txtGorev.ReadOnly = true;
            this.txtGorev.Size = new System.Drawing.Size(250, 22);
            this.txtGorev.TabIndex = 4;
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(100, 137);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.ReadOnly = true;
            this.txtMaas.Size = new System.Drawing.Size(250, 22);
            this.txtMaas.TabIndex = 6;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.Crimson;
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(100, 185);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(120, 40);
            this.btnOnayla.TabIndex = 7;
            this.btnOnayla.Text = "PERSONELİ SİL";
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
            // lblMesaj
            // 
            this.lblMesaj.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMesaj.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMesaj.Location = new System.Drawing.Point(12, 12);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(360, 45);
            this.lblMesaj.TabIndex = 0;
            this.lblMesaj.Text = "BU PERSONEL KAYDINI SİLMEK ÜZERESİNİZ! Bu işlem geri alınamaz. Onaylıyor musunuz?" +
    "";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(74, 23);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Personel:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 105);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(74, 23);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Görevi:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 140);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(74, 23);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "Maaşı:";
            // 
            // FrmPersonelSilOnay
            // 
            this.ClientSize = new System.Drawing.Size(384, 250);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtGorev);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtMaas);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPersonelSilOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personel Silme Onayı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}