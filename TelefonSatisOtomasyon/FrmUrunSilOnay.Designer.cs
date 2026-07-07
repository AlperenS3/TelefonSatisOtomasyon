namespace TelefonSatisOtomasyon
{
    partial class FrmUrunSilOnay
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox txtMarka, txtModel, txtIMEI; // Public olması şart
        private System.Windows.Forms.Button btnOnayla, btnIptal;
        private System.Windows.Forms.Label lblMesaj, lbl1, lbl2, lbl3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMarka
            // 
            this.txtMarka.Location = new System.Drawing.Point(126, 67);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.ReadOnly = true;
            this.txtMarka.Size = new System.Drawing.Size(224, 22);
            this.txtMarka.TabIndex = 2;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(126, 102);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(224, 22);
            this.txtModel.TabIndex = 4;
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(126, 137);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.ReadOnly = true;
            this.txtIMEI.Size = new System.Drawing.Size(224, 22);
            this.txtIMEI.TabIndex = 6;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.Crimson;
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(100, 180);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(120, 40);
            this.btnOnayla.TabIndex = 7;
            this.btnOnayla.Text = "KAYDI SİL";
            this.btnOnayla.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Gray;
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(230, 180);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 8;
            this.btnIptal.Text = "VAZGEÇ";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // lblMesaj
            // 
            this.lblMesaj.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMesaj.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMesaj.Location = new System.Drawing.Point(12, 9);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(360, 50);
            this.lblMesaj.TabIndex = 0;
            this.lblMesaj.Text = "Aşağıdaki kaydı silmek üzeresiniz. Bu işlem geri alınamaz! Onaylıyor musunuz?";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(20, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(100, 23);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Marka:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(20, 105);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 23);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Model:";
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(20, 140);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(100, 23);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "IMEI:";
            // 
            // FrmUrunSilOnay
            // 
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtMarka);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtIMEI);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUrunSilOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kayıt Silme Onayı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}