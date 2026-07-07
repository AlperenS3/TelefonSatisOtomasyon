namespace TelefonSatisOtomasyon
{
    partial class FrmKasaSilOnay
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox txtTur, txtTutar, txtAciklama; // Public olması şart
        private System.Windows.Forms.Button btnOnayla, btnIptal;
        private System.Windows.Forms.Label lblMesaj, lbl1, lbl2, lbl3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTur = new System.Windows.Forms.TextBox();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTur
            // 
            this.txtTur.Location = new System.Drawing.Point(100, 67);
            this.txtTur.Name = "txtTur";
            this.txtTur.ReadOnly = true;
            this.txtTur.Size = new System.Drawing.Size(250, 22);
            this.txtTur.TabIndex = 2;
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(100, 102);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.ReadOnly = true;
            this.txtTutar.Size = new System.Drawing.Size(250, 22);
            this.txtTutar.TabIndex = 4;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(100, 137);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ReadOnly = true;
            this.txtAciklama.Size = new System.Drawing.Size(250, 22);
            this.txtAciklama.TabIndex = 6;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.Firebrick;
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(100, 185);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(120, 40);
            this.btnOnayla.TabIndex = 7;
            this.btnOnayla.Text = "KAYDI SİL";
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
            this.lblMesaj.Text = "BU FİNANSAL KAYIT SİLİNECEKTİR! Kasadaki bakiyeniz değişebilir. Onaylıyor musunuz" +
    "?";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(12, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(82, 23);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "İşlem Türü:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 105);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(74, 23);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Tutar (₺):";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 140);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(74, 23);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "Açıklama:";
            // 
            // FrmKasaSilOnay
            // 
            this.ClientSize = new System.Drawing.Size(384, 250);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtTur);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmKasaSilOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kasa Kaydı Silme Onayı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}