namespace TelefonSatisOtomasyon
{
    partial class FrmIstatistik
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartMarka = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMusteriSayisi = new System.Windows.Forms.Label();
            this.lblSatisAdedi = new System.Windows.Forms.Label();
            this.lblKasaNakit = new System.Windows.Forms.Label();
            this.lblStokAdet = new System.Windows.Forms.Label();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblB1 = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.lblB2 = new System.Windows.Forms.Label();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.lblB3 = new System.Windows.Forms.Label();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.lblB4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarka)).BeginInit();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartMarka
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMarka.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMarka.Legends.Add(legend1);
            this.chartMarka.Location = new System.Drawing.Point(20, 140);
            this.chartMarka.Name = "chartMarka";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Markalar";
            this.chartMarka.Series.Add(series1);
            this.chartMarka.Size = new System.Drawing.Size(800, 350);
            this.chartMarka.TabIndex = 4;
            // 
            // lblMusteriSayisi
            // 
            this.lblMusteriSayisi.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblMusteriSayisi.ForeColor = System.Drawing.Color.White;
            this.lblMusteriSayisi.Location = new System.Drawing.Point(10, 35);
            this.lblMusteriSayisi.Name = "lblMusteriSayisi";
            this.lblMusteriSayisi.Size = new System.Drawing.Size(160, 50);
            this.lblMusteriSayisi.TabIndex = 1;
            this.lblMusteriSayisi.Text = "0";
            // 
            // lblSatisAdedi
            // 
            this.lblSatisAdedi.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSatisAdedi.ForeColor = System.Drawing.Color.White;
            this.lblSatisAdedi.Location = new System.Drawing.Point(10, 35);
            this.lblSatisAdedi.Name = "lblSatisAdedi";
            this.lblSatisAdedi.Size = new System.Drawing.Size(160, 50);
            this.lblSatisAdedi.TabIndex = 1;
            this.lblSatisAdedi.Text = "0";
            // 
            // lblKasaNakit
            // 
            this.lblKasaNakit.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblKasaNakit.ForeColor = System.Drawing.Color.White;
            this.lblKasaNakit.Location = new System.Drawing.Point(5, 40);
            this.lblKasaNakit.Name = "lblKasaNakit";
            this.lblKasaNakit.Size = new System.Drawing.Size(175, 45);
            this.lblKasaNakit.TabIndex = 1;
            this.lblKasaNakit.Text = "0.00 ₺";
            // 
            // lblStokAdet
            // 
            this.lblStokAdet.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStokAdet.ForeColor = System.Drawing.Color.White;
            this.lblStokAdet.Location = new System.Drawing.Point(10, 35);
            this.lblStokAdet.Name = "lblStokAdet";
            this.lblStokAdet.Size = new System.Drawing.Size(160, 50);
            this.lblStokAdet.TabIndex = 1;
            this.lblStokAdet.Text = "0";
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnl1.Controls.Add(this.lblB1);
            this.pnl1.Controls.Add(this.lblMusteriSayisi);
            this.pnl1.Location = new System.Drawing.Point(20, 20);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(185, 100);
            this.pnl1.TabIndex = 3;
            // 
            // lblB1
            // 
            this.lblB1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblB1.ForeColor = System.Drawing.Color.White;
            this.lblB1.Location = new System.Drawing.Point(10, 10);
            this.lblB1.Name = "lblB1";
            this.lblB1.Size = new System.Drawing.Size(100, 23);
            this.lblB1.TabIndex = 0;
            this.lblB1.Text = "TOPLAM MÜŞTERİ";
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnl2.Controls.Add(this.lblB2);
            this.pnl2.Controls.Add(this.lblSatisAdedi);
            this.pnl2.Location = new System.Drawing.Point(225, 20);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(185, 100);
            this.pnl2.TabIndex = 2;
            // 
            // lblB2
            // 
            this.lblB2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblB2.ForeColor = System.Drawing.Color.White;
            this.lblB2.Location = new System.Drawing.Point(10, 10);
            this.lblB2.Name = "lblB2";
            this.lblB2.Size = new System.Drawing.Size(100, 23);
            this.lblB2.TabIndex = 0;
            this.lblB2.Text = "TOPLAM SATIŞ";
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.pnl3.Controls.Add(this.lblB3);
            this.pnl3.Controls.Add(this.lblKasaNakit);
            this.pnl3.Location = new System.Drawing.Point(430, 20);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(185, 100);
            this.pnl3.TabIndex = 1;
            // 
            // lblB3
            // 
            this.lblB3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblB3.ForeColor = System.Drawing.Color.White;
            this.lblB3.Location = new System.Drawing.Point(10, 10);
            this.lblB3.Name = "lblB3";
            this.lblB3.Size = new System.Drawing.Size(100, 23);
            this.lblB3.TabIndex = 0;
            this.lblB3.Text = "KASA DURUMU";
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnl4.Controls.Add(this.lblB4);
            this.pnl4.Controls.Add(this.lblStokAdet);
            this.pnl4.Location = new System.Drawing.Point(635, 20);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(185, 100);
            this.pnl4.TabIndex = 0;
            // 
            // lblB4
            // 
            this.lblB4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblB4.ForeColor = System.Drawing.Color.White;
            this.lblB4.Location = new System.Drawing.Point(10, 10);
            this.lblB4.Name = "lblB4";
            this.lblB4.Size = new System.Drawing.Size(100, 23);
            this.lblB4.TabIndex = 0;
            this.lblB4.Text = "STOKTAKİ ÜRÜN";
            // 
            // FrmIstatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 520);
            this.Controls.Add(this.pnl4);
            this.Controls.Add(this.pnl3);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.chartMarka);
            this.Name = "FrmIstatistik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dükkan Analiz ve İstatistik Paneli";
            this.Load += new System.EventHandler(this.FrmIstatistik_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chartMarka)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblMusteriSayisi;
        private System.Windows.Forms.Label lblSatisAdedi;
        private System.Windows.Forms.Label lblKasaNakit;
        private System.Windows.Forms.Label lblStokAdet;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Panel pnl4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarka;
        private System.Windows.Forms.Label lblB1;
        private System.Windows.Forms.Label lblB2;
        private System.Windows.Forms.Label lblB3;
        private System.Windows.Forms.Label lblB4;
    }
}