using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    /// <summary>
    /// Tüm raporlar için ortak PrintDocument tabanlı yazdırıcı.
    /// Expand/Collapse yoktur — düz profesyonel tablo formatı.
    /// Logo, başlık, grup başlıkları, hesaplama satırları ve footer içerir.
    /// </summary>
    public class RaporYazdirici
    {
        // ── Dışarıdan set edilen özellikler ──────────────────────────────
        public string RaporBasligi      { get; set; } = "RAPOR";
        public string AltBaslik         { get; set; } = "";
        public DataTable Veri           { get; set; }
        public List<string> GizlenecekSutunlar { get; set; } = new List<string>();

        // ── İç değişkenler ───────────────────────────────────────────────
        private int _sayfa    = 1;
        private int _satirIdx = 0;
        private DataTable _dt;

        // Sütun genişlikleri (oransal — toplam 1.0)
        private float[] _sutunOranlar;
        private string[] _sutunlar;

        // Baskı ayarları
        private const int SOL_KENAR  = 40;
        private const int UST_KENAR  = 40;
        private const int SAG_KENAR  = 40;
        private const int SATIR_Y    = 22;
        private const int BASLIK_Y   = 130; // logo+başlık bloğu yüksekliği

        // Renkler
        private readonly Color _renkBaslik   = Color.FromArgb(41, 53, 65);    // koyu lacivert
        private readonly Color _renkAltBand  = Color.FromArgb(240, 248, 255); // açık mavi
        private readonly Color _renkGrup     = Color.FromArgb(229, 126, 49);  // turuncu
        private readonly Color _renkBordur   = Color.FromArgb(200, 210, 220);

        // ── Genel Başlat ─────────────────────────────────────────────────
        public void OnizlemeGoster()
        {
            if (Veri == null || Veri.Rows.Count == 0)
            {
                MessageBox.Show("Görüntülenecek veri yok!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _dt = Veri;
            HazirlanSutunlar();

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 1169, 827);
            pd.PrintPage += PrintPage;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document  = pd;
            ppd.Width     = 1100;
            ppd.Height    = 750;
            ppd.Text      = "Rapor Önizleme — " + RaporBasligi;

            // Expand/Collapse toolbar'ını tamamen gizle
            ToolStrip ts = ppd.Controls[1] as ToolStrip;
            if (ts != null) ts.Visible = false;

            _sayfa    = 1;
            _satirIdx = 0;

            ppd.ShowDialog();
        }

        // ── Sütunları hazırla ─────────────────────────────────────────────
        private void HazirlanSutunlar()
        {
            var cols = new List<string>();
            foreach (DataColumn c in _dt.Columns)
                if (!GizlenecekSutunlar.Contains(c.ColumnName))
                    cols.Add(c.ColumnName);
            _sutunlar = cols.ToArray();

            // Her sütun eşit genişlik (basit yaklaşım)
            _sutunOranlar = new float[_sutunlar.Length];
            for (int i = 0; i < _sutunlar.Length; i++)
                _sutunOranlar[i] = 1f / _sutunlar.Length;
        }

        // ── Ana Baskı Metodu ─────────────────────────────────────────────
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int pageW = e.PageBounds.Width;
            int pageH = e.PageBounds.Height;
            int y     = UST_KENAR;
            int x     = SOL_KENAR;
            int w     = pageW - SOL_KENAR - SAG_KENAR;

            // ── Logo + Başlık ────────────────────────────────────────────
            if (_satirIdx == 0)
            {
                LogoVeBaslik(g, x, y, w);
                y += BASLIK_Y;
            }
            else
            {
                y += 10;
                // Sayfa numarası + küçük başlık
                using (var fntSmall = new Font("Segoe UI", 8))
                    g.DrawString(RaporBasligi + " | Sayfa " + _sayfa,
                        fntSmall, Brushes.Gray, x, y);
                y += 22;
            }

            // ── Tablo Başlık Satırı ──────────────────────────────────────
            y = SutunBasliklari(g, x, y, w);

            // ── Veri Satırları ───────────────────────────────────────────
            bool altBand = false;
            while (_satirIdx < _dt.Rows.Count)
            {
                if (y + SATIR_Y > pageH - 60) break;  // sayfa bitti

                DataRow row = _dt.Rows[_satirIdx];

                // Grup satırı (ilk sütun boşsa ve BU satır bir gruplama satırıysa)
                bool grupSatiri = row[0].ToString().StartsWith("▶");
                if (grupSatiri)
                {
                    y = GrupSatiriCiz(g, row, x, y, w);
                    _satirIdx++;
                    altBand = false;
                    continue;
                }

                // Toplam / Özet satırı
                bool toplamSatir = row[0].ToString().StartsWith("TOPLAM") ||
                                   row[0].ToString().StartsWith("GENEL") ||
                                   row[0].ToString().StartsWith("NET");
                if (toplamSatir)
                {
                    y = ToplamSatiriCiz(g, row, x, y, w);
                    _satirIdx++;
                    altBand = false;
                    continue;
                }

                // Normal veri satırı
                Color bgColor = altBand ? _renkAltBand : Color.White;
                y = VeriSatiriCiz(g, row, x, y, w, bgColor);
                altBand = !altBand;
                _satirIdx++;
            }

            // ── Footer ──────────────────────────────────────────────────
            Footer(g, x, pageW, pageH, _sayfa);

            if (_satirIdx < _dt.Rows.Count)
            {
                e.HasMorePages = true;
                _sayfa++;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        // ── Logo ve Başlık Bloğu ─────────────────────────────────────────
        private void LogoVeBaslik(Graphics g, int x, int y, int w)
        {
            // Logo kutusu (programatik çizim)
            Rectangle logoRect = new Rectangle(x, y, 90, 90);
            using (var brush = new SolidBrush(_renkBaslik))
                g.FillRectangle(brush, logoRect);

            // Logo içi metin
            using (var fntLogo = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
                g.DrawString("📱", new Font("Segoe UI", 20), Brushes.White,
                    new RectangleF(x + 5, y + 5, 80, 50), sf);
                g.DrawString("TELEFON", fntLogo, Brushes.White,
                    new RectangleF(x + 5, y + 52, 80, 20), sf);
                g.DrawString("TAKİP", fntLogo, Brushes.White,
                    new RectangleF(x + 5, y + 68, 80, 20), sf);
            }

            // Başlık metni
            int tx = x + 105;
            using (var fntTitle = new Font("Segoe UI", 20, FontStyle.Bold))
            using (var brushT = new SolidBrush(_renkBaslik))
                g.DrawString(RaporBasligi, fntTitle, brushT, tx, y + 5);

            if (!string.IsNullOrWhiteSpace(AltBaslik))
            {
                using (var fntSub = new Font("Segoe UI", 11))
                    g.DrawString(AltBaslik, fntSub, Brushes.Gray, tx, y + 48);
            }

            using (var fntDate = new Font("Segoe UI", 9))
                g.DrawString("Oluşturma Tarihi: " + DateTime.Now.ToString("dd MMMM yyyy, HH:mm"),
                    fntDate, Brushes.DimGray, tx, y + 70);

            // Alt çizgi
            using (var pen = new Pen(_renkGrup, 2))
                g.DrawLine(pen, x, y + 100, x + w, y + 100);
        }

        // ── Sütun Başlık Satırı ───────────────────────────────────────────
        private int SutunBasliklari(Graphics g, int x, int y, int w)
        {
            using (var brush = new SolidBrush(_renkBaslik))
                g.FillRectangle(brush, x, y, w, SATIR_Y);

            using (var fnt = new Font("Segoe UI", 9, FontStyle.Bold))
            using (var pen = new Pen(_renkBordur))
            {
                int cx = x;
                for (int i = 0; i < _sutunlar.Length; i++)
                {
                    int cw = (int)(w * _sutunOranlar[i]);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(_sutunlar[i], fnt, Brushes.White,
                        new RectangleF(cx + 2, y + 2, cw - 4, SATIR_Y - 4), sf);
                    g.DrawLine(pen, cx + cw, y, cx + cw, y + SATIR_Y);
                    cx += cw;
                }
            }
            return y + SATIR_Y;
        }

        // ── Normal Veri Satırı ────────────────────────────────────────────
        private int VeriSatiriCiz(Graphics g, DataRow row, int x, int y, int w, Color bg)
        {
            using (var bgBrush = new SolidBrush(bg))
                g.FillRectangle(bgBrush, x, y, w, SATIR_Y);

            using (var fnt = new Font("Segoe UI", 8.5f))
            using (var pen = new Pen(_renkBordur, 0.5f))
            {
                int cx = x;
                for (int i = 0; i < _sutunlar.Length; i++)
                {
                    int cw = (int)(w * _sutunOranlar[i]);
                    string val = row[_sutunlar[i]]?.ToString() ?? "";

                    // Sayısal sütunları sağa hizala
                    bool isNum = IsNumeric(val);
                    var sf = new StringFormat
                    {
                        Alignment = isNum ? StringAlignment.Far : StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter
                    };

                    g.DrawString(val, fnt, Brushes.Black,
                        new RectangleF(cx + 4, y + 2, cw - 8, SATIR_Y - 4), sf);
                    g.DrawLine(pen, cx + cw, y, cx + cw, y + SATIR_Y);
                    cx += cw;
                }
                g.DrawLine(pen, x, y + SATIR_Y, x + w, y + SATIR_Y);
            }
            return y + SATIR_Y;
        }

        // ── Grup Başlık Satırı ────────────────────────────────────────────
        private int GrupSatiriCiz(Graphics g, DataRow row, int x, int y, int w)
        {
            using (var brush = new SolidBrush(_renkGrup))
                g.FillRectangle(brush, x, y, w, SATIR_Y + 2);

            using (var fnt = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            {
                string label = row[0].ToString().Replace("▶ ", "");
                g.DrawString("  ▶  " + label, fnt, Brushes.White, x + 8, y + 4);
            }
            return y + SATIR_Y + 2;
        }

        // ── Toplam/Özet Satırı ────────────────────────────────────────────
        private int ToplamSatiriCiz(Graphics g, DataRow row, int x, int y, int w)
        {
            using (var brush = new SolidBrush(Color.FromArgb(220, 230, 241)))
                g.FillRectangle(brush, x, y, w, SATIR_Y);

            using (var fnt = new Font("Segoe UI", 9, FontStyle.Bold))
            using (var pen = new Pen(_renkBaslik, 1))
            {
                g.DrawLine(pen, x, y, x + w, y);

                int cx = x;
                for (int i = 0; i < _sutunlar.Length; i++)
                {
                    int cw = (int)(w * _sutunOranlar[i]);
                    string val = row[_sutunlar[i]]?.ToString() ?? "";
                    bool isNum = IsNumeric(val);
                    var sf = new StringFormat
                    {
                        Alignment = isNum || i > 0 ? StringAlignment.Far : StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };
                    using (var br = new SolidBrush(_renkBaslik))
                        g.DrawString(val, fnt, br,
                            new RectangleF(cx + 4, y + 2, cw - 8, SATIR_Y - 4), sf);
                    cx += cw;
                }

                g.DrawLine(pen, x, y + SATIR_Y, x + w, y + SATIR_Y);
            }
            return y + SATIR_Y + 4;
        }

        // ── Footer ───────────────────────────────────────────────────────
        private void Footer(Graphics g, int x, int pageW, int pageH, int sayfa)
        {
            int fy = pageH - 35;
            using (var pen = new Pen(_renkGrup, 1f))
                g.DrawLine(pen, x, fy, pageW - 40, fy);

            using (var fnt = new Font("Segoe UI", 8))
            {
                g.DrawString("Telefon Satış Otomasyon Sistemi  —  Gizli",
                    fnt, Brushes.Gray, x, fy + 5);
                string pageStr = "Sayfa " + sayfa;
                SizeF sz = g.MeasureString(pageStr, fnt);
                g.DrawString(pageStr, fnt, Brushes.Gray, pageW - 40 - sz.Width, fy + 5);
            }
        }

        // ── Yardımcı: Sayısal mı? ─────────────────────────────────────────
        private bool IsNumeric(string s)
        {
            decimal d;
            return decimal.TryParse(s.Replace(" ₺", "").Replace(",", "."), out d);
        }

        // ── Raporu Masaüstüne PDF Olarak Kaydet ───────────────────────────
        public void MasaustunePDFKaydet(string dosyaAdi)
        {
            if (Veri == null || Veri.Rows.Count == 0)
            {
                MessageBox.Show("Görüntülenecek veri yok!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _dt = Veri;
            HazirlanSutunlar();

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 1169, 827);
            pd.PrintPage += PrintPage;

            // Masaüstü yolu
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = System.IO.Path.Combine(desktopPath, dosyaAdi + ".pdf");

            // PDF yazıcı bul (Microsoft Print to PDF vb.)
            string pdfPrinter = "";
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.ToUpper().Contains("PDF") || printer.ToUpper().Contains("WRITER"))
                {
                    pdfPrinter = printer;
                    break;
                }
            }

            if (string.IsNullOrEmpty(pdfPrinter))
            {
                MessageBox.Show("Sistemde 'Microsoft Print to PDF' veya benzeri bir PDF yazıcı bulunamadı!\nLütfen sisteminizde bir PDF yazıcının yüklü olduğundan emin olun.", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pd.PrinterSettings.PrinterName = pdfPrinter;
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = fullPath;

            _sayfa    = 1;
            _satirIdx = 0;

            try
            {
                pd.Print();
                MessageBox.Show($"Rapor başarıyla PDF olarak masaüstüne kaydedildi:\n{dosyaAdi}.pdf", 
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Kaydedilirken bir hata oluştu:\n" + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
