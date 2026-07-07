namespace TelefonSatisOtomasyon
{
    partial class FrmStokYonetimi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStok;
        private System.Windows.Forms.Panel pnlUst, pnlAlt;
        private System.Windows.Forms.Button btnYeniUrun, btnHizliGuncelle, btnSil, btnYenile;
        private System.Windows.Forms.TextBox txtArama, txtArama2;
        private System.Windows.Forms.Label lblArama, lblArama2, lblIstatistik, lblModArama, lblModIMEI;
        private System.Windows.Forms.ComboBox cmbModelModu, cmbIMEIModu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStok = new System.Windows.Forms.DataGridView();
            this.pnlUst = new System.Windows.Forms.Panel();
            this.cmbModelModu = new System.Windows.Forms.ComboBox();
            this.cmbIMEIModu = new System.Windows.Forms.ComboBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.lblModArama = new System.Windows.Forms.Label();
            this.lblModIMEI = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblArama2 = new System.Windows.Forms.Label();
            this.txtArama2 = new System.Windows.Forms.TextBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.lblIstatistik = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnHizliGuncelle = new System.Windows.Forms.Button();
            this.btnYeniUrun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStok)).BeginInit();
            this.pnlUst.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStok
            // 
            this.dgvStok.BackgroundColor = System.Drawing.Color.White;
            this.dgvStok.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStok.ColumnHeadersHeight = 35;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStok.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStok.Location = new System.Drawing.Point(0, 95);
            this.dgvStok.Name = "dgvStok";
            this.dgvStok.RowHeadersWidth = 51;
            this.dgvStok.Size = new System.Drawing.Size(1000, 455);
            this.dgvStok.TabIndex = 0;
            this.dgvStok.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStok_CellContentClick);
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlUst.Controls.Add(this.cmbModelModu);
            this.pnlUst.Controls.Add(this.cmbIMEIModu);
            this.pnlUst.Controls.Add(this.lblArama);
            this.pnlUst.Controls.Add(this.lblModArama);
            this.pnlUst.Controls.Add(this.lblModIMEI);
            this.pnlUst.Controls.Add(this.txtArama);
            this.pnlUst.Controls.Add(this.lblArama2);
            this.pnlUst.Controls.Add(this.txtArama2);
            this.pnlUst.Controls.Add(this.btnYenile);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(1000, 95);
            this.pnlUst.TabIndex = 1;
            // 
            // cmbModelModu
            // 
            this.cmbModelModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelModu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModelModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbModelModu.Location = new System.Drawing.Point(86, 59);
            this.cmbModelModu.Name = "cmbModelModu";
            this.cmbModelModu.Size = new System.Drawing.Size(115, 24);
            this.cmbModelModu.TabIndex = 4;
            this.cmbModelModu.SelectedIndexChanged += new System.EventHandler(this.TxtArama_TextChanged);
            // 
            // cmbIMEIModu
            // 
            this.cmbIMEIModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIMEIModu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIMEIModu.Items.AddRange(new object[] {
            "İçeren",
            "İle Başlayan",
            "İle Biten",
            "Birebir"});
            this.cmbIMEIModu.Location = new System.Drawing.Point(340, 60);
            this.cmbIMEIModu.Name = "cmbIMEIModu";
            this.cmbIMEIModu.Size = new System.Drawing.Size(115, 24);
            this.cmbIMEIModu.TabIndex = 5;
            this.cmbIMEIModu.SelectedIndexChanged += new System.EventHandler(this.TxtArama_TextChanged);
            // 
            // lblArama
            // 
            this.lblArama.ForeColor = System.Drawing.Color.White;
            this.lblArama.Location = new System.Drawing.Point(65, 9);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(120, 20);
            this.lblArama.TabIndex = 2;
            this.lblArama.Text = "Model / Marka:";
            // 
            // lblModArama
            // 
            this.lblModArama.ForeColor = System.Drawing.Color.White;
            this.lblModArama.Location = new System.Drawing.Point(20, 62);
            this.lblModArama.Name = "lblModArama";
            this.lblModArama.Size = new System.Drawing.Size(60, 20);
            this.lblModArama.TabIndex = 9;
            this.lblModArama.Text = "Arama:";
            // 
            // lblModIMEI
            // 
            this.lblModIMEI.ForeColor = System.Drawing.Color.White;
            this.lblModIMEI.Location = new System.Drawing.Point(280, 62);
            this.lblModIMEI.Name = "lblModIMEI";
            this.lblModIMEI.Size = new System.Drawing.Size(60, 20);
            this.lblModIMEI.TabIndex = 10;
            this.lblModIMEI.Text = "Arama:";
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(51, 34);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(150, 22);
            this.txtArama.TabIndex = 3;
            this.txtArama.TextChanged += new System.EventHandler(this.TxtArama_TextChanged);
            // 
            // lblArama2
            // 
            this.lblArama2.ForeColor = System.Drawing.Color.White;
            this.lblArama2.Location = new System.Drawing.Point(320, 9);
            this.lblArama2.Name = "lblArama2";
            this.lblArama2.Size = new System.Drawing.Size(100, 20);
            this.lblArama2.TabIndex = 6;
            this.lblArama2.Text = "IMEI No:";
            // 
            // txtArama2
            // 
            this.txtArama2.Location = new System.Drawing.Point(305, 34);
            this.txtArama2.Name = "txtArama2";
            this.txtArama2.Size = new System.Drawing.Size(150, 22);
            this.txtArama2.TabIndex = 7;
            this.txtArama2.TextChanged += new System.EventHandler(this.TxtArama_TextChanged);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(500, 30);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(130, 35);
            this.btnYenile.TabIndex = 8;
            this.btnYenile.Text = "Filtreyi Temizle";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlAlt.Controls.Add(this.lblIstatistik);
            this.pnlAlt.Controls.Add(this.btnSil);
            this.pnlAlt.Controls.Add(this.btnHizliGuncelle);
            this.pnlAlt.Controls.Add(this.btnYeniUrun);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 550);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(1000, 80);
            this.pnlAlt.TabIndex = 2;
            // 
            // lblIstatistik
            // 
            this.lblIstatistik.Location = new System.Drawing.Point(20, 25);
            this.lblIstatistik.Name = "lblIstatistik";
            this.lblIstatistik.Size = new System.Drawing.Size(400, 30);
            this.lblIstatistik.TabIndex = 0;
            this.lblIstatistik.Text = "Yükleniyor...";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(830, 20);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(150, 40);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Seçiliyi Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnHizliGuncelle
            // 
            this.btnHizliGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnHizliGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHizliGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnHizliGuncelle.Location = new System.Drawing.Point(670, 20);
            this.btnHizliGuncelle.Name = "btnHizliGuncelle";
            this.btnHizliGuncelle.Size = new System.Drawing.Size(150, 40);
            this.btnHizliGuncelle.TabIndex = 2;
            this.btnHizliGuncelle.Text = "Düzenle";
            this.btnHizliGuncelle.UseVisualStyleBackColor = false;
            this.btnHizliGuncelle.Click += new System.EventHandler(this.btnHizliGuncelle_Click);
            // 
            // btnYeniUrun
            // 
            this.btnYeniUrun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYeniUrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniUrun.ForeColor = System.Drawing.Color.White;
            this.btnYeniUrun.Location = new System.Drawing.Point(510, 20);
            this.btnYeniUrun.Name = "btnYeniUrun";
            this.btnYeniUrun.Size = new System.Drawing.Size(150, 40);
            this.btnYeniUrun.TabIndex = 3;
            this.btnYeniUrun.Text = "+ Yeni Kayıt";
            this.btnYeniUrun.UseVisualStyleBackColor = false;
            this.btnYeniUrun.Click += new System.EventHandler(this.btnYeniUrun_Click);
            // 
            // FrmStokYonetimi
            // 
            this.ClientSize = new System.Drawing.Size(1000, 630);
            this.Controls.Add(this.dgvStok);
            this.Controls.Add(this.pnlUst);
            this.Controls.Add(this.pnlAlt);
            this.Name = "FrmStokYonetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takip Sistemi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStok)).EndInit();
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            this.pnlAlt.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}