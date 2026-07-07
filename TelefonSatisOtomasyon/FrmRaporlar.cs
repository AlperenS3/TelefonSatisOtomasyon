using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmRaporlar : Form
    {
        private readonly SqlBaglanti bgl = new SqlBaglanti();
        private string _aktifRapor = "";    // Hangi rapor seçili
        private Button _aktifButon = null;  // Seçili buton rengi için

        // ── Kurucu ──────────────────────────────────────────────────────
        public FrmRaporlar()
        {
            InitializeComponent();
            OlaylariVeAyarlariYap();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // Başlangıçta satış raporunu yükle
            RaporYukle("satis");
            SecilenButonVurgula(btnSatis);
        }

        // ── Olay Bağlantıları ────────────────────────────────────────────
        private void OlaylariVeAyarlariYap()
        {
            btnSatis.Click        += (s, e) => { RaporYukle("satis");      SecilenButonVurgula(btnSatis);      };
            btnStok.Click         += (s, e) => { RaporYukle("stok");       SecilenButonVurgula(btnStok);       };
            btnServis.Click       += (s, e) => { RaporYukle("servis");     SecilenButonVurgula(btnServis);     };
            btnGelirGider.Click   += (s, e) => { RaporYukle("gelirGider"); SecilenButonVurgula(btnGelirGider); };
            btnPersonel.Click     += (s, e) => { RaporYukle("personel");   SecilenButonVurgula(btnPersonel);   };
            btnMusteri.Click      += (s, e) => { RaporYukle("musteri");    SecilenButonVurgula(btnMusteri);    };

            btnFiltrele.Click     += (s, e) => RaporYukle(_aktifRapor);
            btnTemizle.Click      += (s, e) => {
                dgvRapor.DataSource = null;
                OzetleriTemizle();
                lblRaporBaslik.Text = "Bir rapor seçin...";
            };
            btnYazdir.Click       += BtnYazdir_Click;

            ContextMenuStrip menuKaydet = new ContextMenuStrip();
            menuKaydet.Items.Add("PDF Olarak Kaydet (.pdf)", null, (s, e) => RaporKaydetPDF());
            menuKaydet.Items.Add("HTML Web Raporu Olarak Kaydet (.html)", null, (s, e) => RaporKaydetHTML());
            menuKaydet.Items.Add("Excel/CSV Verisi Olarak Kaydet (.csv)", null, (s, e) => RaporKaydetCSV());
            btnMasaustuKaydet.Click += (s, e) => menuKaydet.Show(btnMasaustuKaydet, new Point(0, btnMasaustuKaydet.Height));

            // DataGridView — grup/toplam satırlarını renklendir
            dgvRapor.CellFormatting += DgvRapor_CellFormatting;
            dgvRapor.DataBindingComplete += (s, e) => SutunlariBicimlendir();
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR YÜKLE — merkezi dağıtıcı
        // ════════════════════════════════════════════════════════════════
        private void RaporYukle(string rapor)
        {
            if (string.IsNullOrWhiteSpace(rapor)) return;
            _aktifRapor = rapor;

            try
            {
                switch (rapor)
                {
                    case "satis":      SatisRaporuYukle();      break;
                    case "stok":       StokRaporuYukle();       break;
                    case "servis":     TeknikServisRaporuYukle(); break;
                    case "gelirGider": GelirGiderRaporuYukle(); break;
                    case "personel":   PersonelRaporuYukle();   break;
                    case "musteri":    MusteriRaporuYukle();    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor yüklenemedi:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR 1 — SATIŞ RAPORU
        // ════════════════════════════════════════════════════════════════
        private void SatisRaporuYukle()
        {
            lblRaporBaslik.Text = "💰  Satış Raporu — Markaya Göre Gruplandı";

            string sorgu = @"
                SELECT
                    M.MarkaAd          AS [Marka],
                    U.Model            AS [Model],
                    MU.AdSoyad         AS [Müşteri],
                    S.Adet             AS [Adet],
                    S.ToplamTutar      AS [Toplam Tutar (₺)],
                    CONVERT(varchar,S.SatisTarihi,104) AS [Tarih]
                FROM Satislar S
                INNER JOIN Urunler  U  ON S.UrunID    = U.UrunID
                INNER JOIN Markalar M  ON U.MarkaID   = M.MarkaID
                INNER JOIN Musteriler MU ON S.MusteriID = MU.MusteriID
                WHERE CAST(S.SatisTarihi AS DATE) BETWEEN @bas AND @bit
                ORDER BY M.MarkaAd, S.SatisTarihi DESC";

            DataTable raw = VerileriGetir(sorgu);
            if (raw == null) return;

            // Markaya göre grupla + toplam satırları ekle
            DataTable dt = new DataTable();
            dt.Columns.Add("Marka");
            dt.Columns.Add("Model");
            dt.Columns.Add("Müşteri");
            dt.Columns.Add("Adet");
            dt.Columns.Add("Toplam Tutar (₺)");
            dt.Columns.Add("Tarih");

            string sonMarka = "";
            decimal grupToplam = 0, grupAdet = 0, genelToplam = 0, genelAdet = 0;

            foreach (DataRow r in raw.Rows)
            {
                string marka = r["Marka"].ToString();
                if (marka != sonMarka)
                {
                    if (sonMarka != "")
                    {
                        // Önceki grubun toplamı
                        dt.Rows.Add("TOPLAM → " + sonMarka, "", "",
                            grupAdet.ToString("N0"),
                            grupToplam.ToString("N2") + " ₺", "");
                        grupToplam = 0; grupAdet = 0;
                    }
                    // Grup başlığı
                    dt.Rows.Add("▶ " + marka, "", "", "", "", "");
                    sonMarka = marka;
                }
                dt.Rows.Add(
                    r["Marka"], r["Model"], r["Müşteri"],
                    r["Adet"], Convert.ToDecimal(r["Toplam Tutar (₺)"]).ToString("N2") + " ₺",
                    r["Tarih"]);
                grupToplam += Convert.ToDecimal(r["Toplam Tutar (₺)"]);
                grupAdet   += Convert.ToInt32(r["Adet"]);
                genelToplam += Convert.ToDecimal(r["Toplam Tutar (₺)"]);
                genelAdet   += Convert.ToInt32(r["Adet"]);
            }
            if (sonMarka != "")
                dt.Rows.Add("TOPLAM → " + sonMarka, "", "",
                    grupAdet.ToString("N0"), grupToplam.ToString("N2") + " ₺", "");

            // Genel toplam
            dt.Rows.Add("GENEL TOPLAM", "", "",
                genelAdet.ToString("N0"), genelToplam.ToString("N2") + " ₺", "");

            dgvRapor.DataSource = dt;

            // Özet panel
            OzetGoster(
                $"📦 Toplam Satış: {raw.Rows.Count} Adet",
                $"💰 Toplam Ciro: {genelToplam:N2} ₺",
                $"📊 Ortalama Tutar: {(raw.Rows.Count > 0 ? genelToplam / raw.Rows.Count : 0):N2} ₺",
                $"📅 Tarih: {dtpBaslangic.Value:dd.MM.yyyy} – {dtpBitis.Value:dd.MM.yyyy}"
            );
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR 2 — STOK DURUM RAPORU
        // ════════════════════════════════════════════════════════════════
        private void StokRaporuYukle()
        {
            lblRaporBaslik.Text = "📦  Stok Durum Raporu — Kategoriye Göre Gruplandı";

            string sorgu = @"
                SELECT
                    K.KategoriAd       AS [Kategori],
                    M.MarkaAd          AS [Marka],
                    U.Model            AS [Model],
                    U.IMEI             AS [IMEI],
                    U.StokAdet         AS [Stok],
                    U.SatisFiyat       AS [Birim Fiyat (₺)],
                    (U.StokAdet * U.SatisFiyat) AS [Stok Değeri (₺)],
                    CASE WHEN U.StokAdet = 0 THEN 'TÜKENDİ'
                         WHEN U.StokAdet <= 2 THEN 'KRİTİK'
                         ELSE 'NORMAL' END AS [Durum]
                FROM Urunler U
                INNER JOIN Markalar   M ON U.MarkaID   = M.MarkaID
                INNER JOIN Kategoriler K ON U.KategoriID = K.KategoriID
                ORDER BY K.KategoriAd, U.StokAdet ASC";

            DataTable raw = VerileriGetirSorgu(sorgu);
            if (raw == null) return;

            DataTable dt = new DataTable();
            foreach (DataColumn c in raw.Columns) dt.Columns.Add(c.ColumnName);

            string sonKat = ""; decimal grupDeger = 0, genelDeger = 0;
            int grupStok = 0, genelStok = 0;

            foreach (DataRow r in raw.Rows)
            {
                string kat = r["Kategori"].ToString();
                if (kat != sonKat)
                {
                    if (sonKat != "")
                        dt.Rows.Add("TOPLAM → " + sonKat, "", "", "",
                            grupStok.ToString("N0"),
                            grupDeger.ToString("N2") + " ₺",
                            grupDeger.ToString("N2") + " ₺", "");
                    dt.Rows.Add("▶ " + kat, "", "", "", "", "", "", "");
                    sonKat = kat; grupDeger = 0; grupStok = 0;
                }
                dt.Rows.Add(r["Kategori"], r["Marka"], r["Model"], r["IMEI"],
                    r["Stok"],
                    Convert.ToDecimal(r["Birim Fiyat (₺)"]).ToString("N2") + " ₺",
                    Convert.ToDecimal(r["Stok Değeri (₺)"]).ToString("N2") + " ₺",
                    r["Durum"]);
                grupDeger  += Convert.ToDecimal(r["Stok Değeri (₺)"]);
                grupStok   += Convert.ToInt32(r["Stok"]);
                genelDeger += Convert.ToDecimal(r["Stok Değeri (₺)"]);
                genelStok  += Convert.ToInt32(r["Stok"]);
            }
            if (sonKat != "")
                dt.Rows.Add("TOPLAM → " + sonKat, "", "", "",
                    grupStok.ToString("N0"), grupDeger.ToString("N2") + " ₺",
                    grupDeger.ToString("N2") + " ₺", "");

            dt.Rows.Add("GENEL TOPLAM", "", "", "",
                genelStok.ToString("N0"), "",
                genelDeger.ToString("N2") + " ₺", "");

            dgvRapor.DataSource = dt;

            int kritik = 0;
            foreach (DataRow r in raw.Rows)
                if (r["Durum"].ToString() == "KRİTİK" || r["Durum"].ToString() == "TÜKENDİ") kritik++;

            OzetGoster(
                $"📦 Toplam Ürün Çeşidi: {raw.Rows.Count}",
                $"🔢 Toplam Stok Adedi: {genelStok}",
                $"💰 Toplam Stok Değeri: {genelDeger:N2} ₺",
                $"⚠️ Kritik/Tükenen: {kritik} Ürün"
            );
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR 3 — TEKNİK SERVİS RAPORU
        // ════════════════════════════════════════════════════════════════
        private void TeknikServisRaporuYukle()
        {
            lblRaporBaslik.Text = "🔧  Teknik Servis Raporu — Duruma Göre Gruplandı";

            string sorgu = @"
                SELECT
                    S.Durum            AS [Durum],
                    MU.AdSoyad         AS [Müşteri],
                    S.CihazModel       AS [Cihaz],
                    S.IMEI             AS [IMEI],
                    S.ArizaDetay       AS [Arıza],
                    S.TahminiFiyat     AS [Ücret (₺)]
                FROM TeknikServis S
                INNER JOIN Musteriler MU ON S.MusteriID = MU.MusteriID
                ORDER BY S.Durum, S.ServisID DESC";

            DataTable raw = VerileriGetirSorgu(sorgu);
            if (raw == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Durum"); dt.Columns.Add("Müşteri");
            dt.Columns.Add("Cihaz"); dt.Columns.Add("IMEI");
            dt.Columns.Add("Arıza"); dt.Columns.Add("Ücret (₺)");

            string sonDurum = ""; decimal grupUcret = 0, genelUcret = 0;
            int grupSayi = 0, genelSayi = 0;

            foreach (DataRow r in raw.Rows)
            {
                string durum = r["Durum"].ToString();
                if (durum != sonDurum)
                {
                    if (sonDurum != "")
                        dt.Rows.Add("TOPLAM → " + sonDurum, "", "", "", "",
                            grupUcret.ToString("N2") + " ₺ (" + grupSayi + " kayıt)");
                    dt.Rows.Add("▶ " + durum, "", "", "", "", "");
                    sonDurum = durum; grupUcret = 0; grupSayi = 0;
                }
                dt.Rows.Add(r["Durum"], r["Müşteri"], r["Cihaz"], r["IMEI"], r["Arıza"],
                    Convert.ToDecimal(r["Ücret (₺)"]).ToString("N2") + " ₺");
                grupUcret  += Convert.ToDecimal(r["Ücret (₺)"]);
                grupSayi++;
                genelUcret += Convert.ToDecimal(r["Ücret (₺)"]);
                genelSayi++;
            }
            if (sonDurum != "")
                dt.Rows.Add("TOPLAM → " + sonDurum, "", "", "", "",
                    grupUcret.ToString("N2") + " ₺ (" + grupSayi + " kayıt)");

            dt.Rows.Add("GENEL TOPLAM", "", "", "", "",
                genelUcret.ToString("N2") + " ₺ (" + genelSayi + " kayıt)");

            dgvRapor.DataSource = dt;
            OzetGoster(
                $"🔧 Toplam Servis: {genelSayi}",
                $"💰 Toplam Ücret: {genelUcret:N2} ₺",
                $"📊 Ortalama Ücret: {(genelSayi > 0 ? genelUcret / genelSayi : 0):N2} ₺",
                $"📅 {dtpBaslangic.Value:dd.MM.yyyy} – {dtpBitis.Value:dd.MM.yyyy}"
            );
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR 4 — GELİR-GİDER RAPORU
        // ════════════════════════════════════════════════════════════════
        private void GelirGiderRaporuYukle()
        {
            lblRaporBaslik.Text = "💵  Gelir / Gider Raporu — İşlem Tipine Göre Gruplandı";

            string sorgu = @"
                SELECT
                    IslemTipi          AS [İşlem Tipi],
                    Aciklama           AS [Açıklama],
                    Tutar              AS [Tutar (₺)],
                    CONVERT(varchar,Tarih,104) AS [Tarih]
                FROM Kasa
                WHERE CAST(Tarih AS DATE) BETWEEN @bas AND @bit
                ORDER BY IslemTipi, Tarih DESC";

            DataTable raw = VerileriGetir(sorgu);
            if (raw == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("İşlem Tipi"); dt.Columns.Add("Açıklama");
            dt.Columns.Add("Tutar (₺)");  dt.Columns.Add("Tarih");

            string sonTip = ""; decimal grupToplam = 0;
            decimal topGelir = 0, topGider = 0;

            foreach (DataRow r in raw.Rows)
            {
                string tip = r["İşlem Tipi"].ToString();
                if (tip != sonTip)
                {
                    if (sonTip != "")
                        dt.Rows.Add("TOPLAM → " + sonTip, "",
                            grupToplam.ToString("N2") + " ₺", "");
                    dt.Rows.Add("▶ " + tip, "", "", "");
                    sonTip = tip; grupToplam = 0;
                }
                decimal tutar = Convert.ToDecimal(r["Tutar (₺)"]);
                dt.Rows.Add(r["İşlem Tipi"], r["Açıklama"],
                    tutar.ToString("N2") + " ₺", r["Tarih"]);
                grupToplam += tutar;
                if (tip == "Gider" || tip == "İptal") topGider += tutar;
                else topGelir += tutar;
            }
            if (sonTip != "")
                dt.Rows.Add("TOPLAM → " + sonTip, "",
                    grupToplam.ToString("N2") + " ₺", "");

            decimal net = topGelir - topGider;
            dt.Rows.Add("NET KASA DURUMU", "",
                net.ToString("N2") + " ₺", "");

            dgvRapor.DataSource = dt;
            OzetGoster(
                $"💚 Toplam Gelir: {topGelir:N2} ₺",
                $"❌ Toplam Gider: {topGider:N2} ₺",
                $"💰 Net Kasa: {net:N2} ₺",
                net >= 0 ? "✅ KAR — Olumlu Durum" : "⚠️ ZARAR — Dikkat!"
            );
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR 5 — PERSONEL / MAAŞ RAPORU
        // ════════════════════════════════════════════════════════════════
        private void PersonelRaporuYukle()
        {
            lblRaporBaslik.Text = "👤  Personel ve Maaş Raporu — Göreve Göre Gruplandı";

            string sorgu = @"
                SELECT
                    Gorev              AS [Görev],
                    AdSoyad            AS [Ad Soyad],
                    Telefon            AS [Telefon],
                    Maas               AS [Maaş (₺)]
                FROM Personeller
                ORDER BY Gorev, AdSoyad";

            DataTable raw = VerileriGetirSorgu(sorgu);
            if (raw == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Görev"); dt.Columns.Add("Ad Soyad");
            dt.Columns.Add("Telefon"); dt.Columns.Add("Maaş (₺)");
            dt.Columns.Add("Kümülatif");

            string sonGorev = ""; decimal grupMaas = 0, genelMaas = 0;
            int grupSayi = 0, genelSayi = 0; decimal kumul = 0;

            foreach (DataRow r in raw.Rows)
            {
                string gorev = r["Görev"].ToString();
                if (gorev != sonGorev)
                {
                    if (sonGorev != "")
                        dt.Rows.Add("TOPLAM → " + sonGorev, grupSayi + " Personel",
                            "", grupMaas.ToString("N2") + " ₺", "");
                    dt.Rows.Add("▶ " + gorev, "", "", "", "");
                    sonGorev = gorev; grupMaas = 0; grupSayi = 0;
                }
                decimal maas = Convert.ToDecimal(r["Maaş (₺)"]);
                kumul += maas;
                dt.Rows.Add(r["Görev"], r["Ad Soyad"], r["Telefon"],
                    maas.ToString("N2") + " ₺",
                    kumul.ToString("N2") + " ₺");
                grupMaas  += maas; grupSayi++;
                genelMaas += maas; genelSayi++;
            }
            if (sonGorev != "")
                dt.Rows.Add("TOPLAM → " + sonGorev, grupSayi + " Personel",
                    "", grupMaas.ToString("N2") + " ₺", "");

            dt.Rows.Add("GENEL TOPLAM", genelSayi + " Personel",
                "", genelMaas.ToString("N2") + " ₺", "");

            dgvRapor.DataSource = dt;
            OzetGoster(
                $"👤 Toplam Personel: {genelSayi}",
                $"💰 Toplam Maaş Gideri: {genelMaas:N2} ₺",
                $"📊 Ortalama Maaş: {(genelSayi > 0 ? genelMaas / genelSayi : 0):N2} ₺",
                $"📅 Rapor: {DateTime.Now:dd.MM.yyyy}"
            );
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR 6 — MÜŞTERİ ÖZET RAPORU
        // ════════════════════════════════════════════════════════════════
        private void MusteriRaporuYukle()
        {
            lblRaporBaslik.Text = "🏆  Müşteri Özet Raporu — En Çok Alışveriş Yapanlar";

            string sorgu = @"
                SELECT
                    MU.AdSoyad         AS [Müşteri],
                    MU.Telefon         AS [Telefon],
                    COUNT(S.SatisID)   AS [Satın Alma Sayısı],
                    SUM(S.Adet)        AS [Toplam Adet],
                    SUM(S.ToplamTutar) AS [Toplam Harcama (₺)],
                    MAX(S.ToplamTutar) AS [En Yüksek İşlem (₺)],
                    CONVERT(varchar,MAX(S.SatisTarihi),104) AS [Son Alım]
                FROM Satislar S
                INNER JOIN Musteriler MU ON S.MusteriID = MU.MusteriID
                WHERE CAST(S.SatisTarihi AS DATE) BETWEEN @bas AND @bit
                GROUP BY MU.AdSoyad, MU.Telefon
                ORDER BY SUM(S.ToplamTutar) DESC";

            DataTable raw = VerileriGetir(sorgu);
            if (raw == null) return;

            // Oran hesapla
            decimal genelToplam = 0;
            foreach (DataRow r in raw.Rows)
                genelToplam += Convert.ToDecimal(r["Toplam Harcama (₺)"]);

            DataTable dt = new DataTable();
            dt.Columns.Add("Sıra"); dt.Columns.Add("Müşteri");
            dt.Columns.Add("Telefon"); dt.Columns.Add("Satın Alma Sayısı");
            dt.Columns.Add("Toplam Adet"); dt.Columns.Add("Toplam Harcama (₺)");
            dt.Columns.Add("Pay (%)"); dt.Columns.Add("Son Alım");

            int sira = 1;
            decimal genelAdet = 0, genelSayi = 0;
            foreach (DataRow r in raw.Rows)
            {
                decimal harcama = Convert.ToDecimal(r["Toplam Harcama (₺)"]);
                double pay = genelToplam > 0 ? (double)(harcama / genelToplam * 100) : 0;
                dt.Rows.Add(
                    sira == 1 ? "🥇 " + sira : sira == 2 ? "🥈 " + sira : sira == 3 ? "🥉 " + sira : sira.ToString(),
                    r["Müşteri"], r["Telefon"],
                    r["Satın Alma Sayısı"],
                    r["Toplam Adet"],
                    harcama.ToString("N2") + " ₺",
                    pay.ToString("N1") + "%",
                    r["Son Alım"]
                );
                genelSayi += Convert.ToInt32(r["Satın Alma Sayısı"]);
                genelAdet += Convert.ToInt32(r["Toplam Adet"]);
                sira++;
            }
            dt.Rows.Add("GENEL TOPLAM", raw.Rows.Count + " Müşteri", "",
                genelSayi.ToString("N0"), genelAdet.ToString("N0"),
                genelToplam.ToString("N2") + " ₺", "100%", "");

            dgvRapor.DataSource = dt;
            OzetGoster(
                $"🏆 Aktif Müşteri: {raw.Rows.Count}",
                $"💰 Toplam Ciro: {genelToplam:N2} ₺",
                $"📦 Toplam Satış Adedi: {genelAdet}",
                $"📅 {dtpBaslangic.Value:dd.MM.yyyy} – {dtpBitis.Value:dd.MM.yyyy}"
            );
        }

        // ════════════════════════════════════════════════════════════════
        // YAZDIR — RaporYazdirici ile önizle
        // ════════════════════════════════════════════════════════════════
        private void BtnYazdir_Click(object sender, EventArgs e)
        {
            if (dgvRapor.DataSource == null)
            {
                MessageBox.Show("Önce bir rapor seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yazdir = new RaporYazdirici
            {
                RaporBasligi = lblRaporBaslik.Text.Length > 3
                    ? lblRaporBaslik.Text.Substring(3).Trim()
                    : lblRaporBaslik.Text,
                AltBaslik = dtpBaslangic.Value.ToString("dd MMMM yyyy") +
                            " — " + dtpBitis.Value.ToString("dd MMMM yyyy"),
                Veri = (DataTable)dgvRapor.DataSource
            };

            yazdir.OnizlemeGoster();
        }

        // ════════════════════════════════════════════════════════════════
        // VERİ ÇEKME YARDIMCILARI
        // ════════════════════════════════════════════════════════════════
        private DataTable VerileriGetir(string sorgu)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@bas", dtpBaslangic.Value.Date);
                    cmd.Parameters.AddWithValue("@bit", dtpBitis.Value.Date);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorgu hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private DataTable VerileriGetirSorgu(string sorgu)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorgu hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ════════════════════════════════════════════════════════════════
        // UI YARDIMCILARI
        // ════════════════════════════════════════════════════════════════
        private void SecilenButonVurgula(Button secilen)
        {
            Button[] butonlar = { btnSatis, btnStok, btnServis, btnGelirGider, btnPersonel, btnMusteri };
            foreach (var b in butonlar)
            {
                b.BackColor = Color.FromArgb(41, 53, 65);
                b.ForeColor = Color.FromArgb(180, 190, 200);
            }
            secilen.BackColor = Color.FromArgb(229, 126, 49);
            secilen.ForeColor = Color.White;
            _aktifButon = secilen;
        }

        private void OzetGoster(string s1, string s2, string s3, string s4)
        {
            lblOzet1.Text = s1;
            lblOzet2.Text = s2;
            lblOzet3.Text = s3;
            lblOzet4.Text = s4;
        }

        private void OzetleriTemizle()
        {
            lblOzet1.Text = lblOzet2.Text = lblOzet3.Text = lblOzet4.Text = "";
        }

        // ════════════════════════════════════════════════════════════════
        // GRID BİÇİMLENDİRME
        // ════════════════════════════════════════════════════════════════
        private void SutunlariBicimlendir()
        {
            if (dgvRapor.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvRapor.Columns)
            {
                string name = col.HeaderText.ToUpper();
                // Tutar/Fiyat sütunlarını sağa hizala
                if (name.Contains("TUTAR") || name.Contains("FİYAT") ||
                    name.Contains("₺") || name.Contains("MAAŞ") ||
                    name.Contains("ÜCRET") || name.Contains("HARCAMA"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                // Sayısal sütunları ortala
                else if (name.Contains("ADET") || name.Contains("SIRA") ||
                         name.Contains("SAYI") || name.Contains("PAY"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void DgvRapor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvRapor.Rows[e.RowIndex].Cells[0].Value == null) return;

            string ilkDeger = dgvRapor.Rows[e.RowIndex].Cells[0].Value.ToString();

            // Grup başlığı satırları — turuncu arka plan
            if (ilkDeger.StartsWith("▶"))
            {
                dgvRapor.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 126, 49);
                dgvRapor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dgvRapor.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
            // Toplam / özet satırları — koyu mavi
            else if (ilkDeger.StartsWith("TOPLAM") || ilkDeger.StartsWith("GENEL") ||
                     ilkDeger.StartsWith("NET"))
            {
                dgvRapor.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(41, 53, 65);
                dgvRapor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dgvRapor.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
            // KRİTİK stok — kırmızı
            else if (dgvRapor.Columns.Contains("Durum") && e.ColumnIndex == dgvRapor.Columns["Durum"].Index)
            {
                string durum = e.Value?.ToString() ?? "";
                if (durum == "KRİTİK")      { e.CellStyle.BackColor = Color.OrangeRed;   e.CellStyle.ForeColor = Color.White; }
                else if (durum == "TÜKENDİ"){ e.CellStyle.BackColor = Color.DarkRed;     e.CellStyle.ForeColor = Color.White; }
                else if (durum == "NORMAL")  { e.CellStyle.BackColor = Color.LightGreen;  e.CellStyle.ForeColor = Color.DarkGreen; }
            }
        }

        // ════════════════════════════════════════════════════════════════
        // RAPOR KAYDETME METOTLARI (MASAÜSTÜ)
        // ════════════════════════════════════════════════════════════════
        private void RaporKaydetPDF()
        {
            if (dgvRapor.DataSource == null)
            {
                MessageBox.Show("Önce bir rapor seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string baslik = lblRaporBaslik.Text.Length > 3
                ? lblRaporBaslik.Text.Substring(3).Trim()
                : lblRaporBaslik.Text;

            string dosyaAdi = TemizDosyaAdi(baslik) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            var yazdir = new RaporYazdirici
            {
                RaporBasligi = baslik,
                AltBaslik = dtpBaslangic.Value.ToString("dd MMMM yyyy") +
                            " — " + dtpBitis.Value.ToString("dd MMMM yyyy"),
                Veri = (DataTable)dgvRapor.DataSource
            };

            yazdir.MasaustunePDFKaydet(dosyaAdi);
        }

        private void RaporKaydetHTML()
        {
            if (dgvRapor.DataSource == null)
            {
                MessageBox.Show("Önce bir rapor seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = (DataTable)dgvRapor.DataSource;
            string baslik = lblRaporBaslik.Text.Length > 3
                ? lblRaporBaslik.Text.Substring(3).Trim()
                : lblRaporBaslik.Text;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dosyaAdi = TemizDosyaAdi(baslik) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html";
            string fullPath = System.IO.Path.Combine(desktopPath, dosyaAdi);

            System.Text.StringBuilder html = new System.Text.StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='utf-8'/>");
            html.AppendLine($"<title>{baslik}</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; background-color: #f5f7f8; color: #333; margin: 0; padding: 20px; }");
            html.AppendLine(".container { max-width: 1000px; margin: 0 auto; background: white; padding: 30px; border-radius: 8px; box-shadow: 0 4px 15px rgba(0,0,0,0.05); }");
            html.AppendLine(".header-container { display: flex; align-items: center; border-bottom: 3px solid #e57e31; padding-bottom: 20px; margin-bottom: 20px; }");
            html.AppendLine(".logo { width: 80px; height: 80px; background-color: #293541; color: white; display: flex; flex-direction: column; justify-content: center; align-items: center; font-weight: bold; border-radius: 4px; margin-right: 20px; }");
            html.AppendLine(".logo-icon { font-size: 28px; margin-bottom: 2px; }");
            html.AppendLine(".logo-text { font-size: 10px; text-transform: uppercase; }");
            html.AppendLine(".title-area h1 { margin: 0 0 5px 0; color: #293541; font-size: 24px; }");
            html.AppendLine(".title-area p { margin: 0; color: #7f8c8d; font-size: 14px; }");
            html.AppendLine(".meta-info { margin-left: auto; text-align: right; color: #7f8c8d; font-size: 12px; }");
            html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; background: white; }");
            html.AppendLine("th, td { padding: 10px 12px; text-align: left; font-size: 13px; border-bottom: 1px solid #e2e8f0; }");
            html.AppendLine("th { background-color: #293541; color: white; font-weight: bold; text-transform: uppercase; font-size: 12px; }");
            html.AppendLine("tr:nth-child(even) { background-color: #f8fafc; }");
            html.AppendLine(".row-group { background-color: #e57e31 !important; color: white !important; font-weight: bold; font-size: 14px; }");
            html.AppendLine(".row-total { background-color: #dce6f1 !important; color: #293541 !important; font-weight: bold; }");
            html.AppendLine(".row-genel { background-color: #293541 !important; color: white !important; font-weight: bold; }");
            html.AppendLine(".status-kritik { background-color: #ff4500; color: white; padding: 2px 6px; border-radius: 4px; font-weight: bold; font-size: 11px; }");
            html.AppendLine(".status-tuken { background-color: #8b0000; color: white; padding: 2px 6px; border-radius: 4px; font-weight: bold; font-size: 11px; }");
            html.AppendLine(".status-normal { background-color: #98fb98; color: #006400; padding: 2px 6px; border-radius: 4px; font-weight: bold; font-size: 11px; }");
            html.AppendLine(".align-right { text-align: right; }");
            html.AppendLine(".align-center { text-align: center; }");
            html.AppendLine(".footer { border-top: 1px solid #e2e8f0; margin-top: 30px; padding-top: 15px; font-size: 11px; color: #94a3b8; display: flex; justify-content: space-between; }");
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<div class='container'>");
            
            // Header
            html.AppendLine("  <div class='header-container'>");
            html.AppendLine("    <div class='logo'>");
            html.AppendLine("      <span class='logo-icon'>📱</span>");
            html.AppendLine("      <span class='logo-text'>TELEFON</span>");
            html.AppendLine("    </div>");
            html.AppendLine("    <div class='title-area'>");
            html.AppendLine($"      <h1>{baslik}</h1>");
            html.AppendLine($"      <p>{dtpBaslangic.Value:dd MMMM yyyy} &mdash; {dtpBitis.Value:dd MMMM yyyy}</p>");
            html.AppendLine("    </div>");
            html.AppendLine("    <div class='meta-info'>");
            html.AppendLine($"      <p>Oluşturma Tarihi:<br/><strong>{DateTime.Now:dd MMMM yyyy, HH:mm}</strong></p>");
            html.AppendLine("    </div>");
            html.AppendLine("  </div>");

            // Ozetler
            if (!string.IsNullOrEmpty(lblOzet1.Text))
            {
                html.AppendLine("  <div style='background-color: #f1f5f9; padding: 12px; border-radius: 6px; margin-bottom: 20px; font-size: 13px; font-weight: bold; color: #334155; display: flex; gap: 20px;'>");
                if (!string.IsNullOrEmpty(lblOzet1.Text)) html.AppendLine($"    <span>{lblOzet1.Text}</span>");
                if (!string.IsNullOrEmpty(lblOzet2.Text)) html.AppendLine($"    <span>| &nbsp; {lblOzet2.Text}</span>");
                if (!string.IsNullOrEmpty(lblOzet3.Text)) html.AppendLine($"    <span>| &nbsp; {lblOzet3.Text}</span>");
                if (!string.IsNullOrEmpty(lblOzet4.Text)) html.AppendLine($"    <span>| &nbsp; {lblOzet4.Text}</span>");
                html.AppendLine("  </div>");
            }

            // Table
            html.AppendLine("  <table>");
            
            // Headers
            html.AppendLine("    <thead>");
            html.AppendLine("      <tr>");
            foreach (DataColumn col in dt.Columns)
            {
                html.AppendLine($"        <th>{col.ColumnName}</th>");
            }
            html.AppendLine("      </tr>");
            html.AppendLine("    </thead>");

            // Body
            html.AppendLine("    <tbody>");
            foreach (DataRow row in dt.Rows)
            {
                string firstCellVal = row[0]?.ToString() ?? "";
                string rowClass = "";
                if (firstCellVal.StartsWith("▶")) rowClass = " class='row-group'";
                else if (firstCellVal.StartsWith("TOPLAM")) rowClass = " class='row-total'";
                else if (firstCellVal.StartsWith("GENEL")) rowClass = " class='row-genel'";
                else if (firstCellVal.StartsWith("NET")) rowClass = " class='row-total'";

                html.AppendLine($"      <tr{rowClass}>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string val = row[i]?.ToString() ?? "";
                    string cellClass = "";
                    
                    // Alignments
                    string colName = dt.Columns[i].ColumnName.ToUpper();
                    if (colName.Contains("TUTAR") || colName.Contains("FİYAT") || colName.Contains("₺") || colName.Contains("MAAŞ") || colName.Contains("ÜCRET") || colName.Contains("HARCAMA"))
                    {
                        cellClass = " class='align-right'";
                    }
                    else if (colName.Contains("ADET") || colName.Contains("SIRA") || colName.Contains("SAYI") || colName.Contains("PAY"))
                    {
                        cellClass = " class='align-center'";
                    }

                    // Format status
                    if (colName == "DURUM")
                    {
                        if (val == "KRİTİK") val = "<span class='status-kritik'>KRİTİK</span>";
                        else if (val == "TÜKENDİ") val = "<span class='status-tuken'>TÜKENDİ</span>";
                        else if (val == "NORMAL") val = "<span class='status-normal'>NORMAL</span>";
                    }

                    if (rowClass != "")
                    {
                        html.AppendLine($"        <td>{val}</td>");
                    }
                    else
                    {
                        html.AppendLine($"        <td{cellClass}>{val}</td>");
                    }
                }
                html.AppendLine("      </tr>");
            }
            html.AppendLine("    </tbody>");
            html.AppendLine("  </table>");

            // Footer
            html.AppendLine("  <div class='footer'>");
            html.AppendLine("    <span>Telefon Satış Otomasyon Sistemi &mdash; Rapor Çıktısı</span>");
            html.AppendLine("    <span>Tüm Hakları Saklıdır &copy; 2026</span>");
            html.AppendLine("  </div>");

            html.AppendLine("</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            try
            {
                System.IO.File.WriteAllText(fullPath, html.ToString(), System.Text.Encoding.UTF8);
                MessageBox.Show($"Rapor başarıyla HTML web raporu olarak masaüstüne kaydedildi:\n{dosyaAdi}", 
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fullPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("HTML Kaydedilirken bir hata oluştu:\n" + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RaporKaydetCSV()
        {
            if (dgvRapor.DataSource == null)
            {
                MessageBox.Show("Önce bir rapor seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = (DataTable)dgvRapor.DataSource;
            string baslik = lblRaporBaslik.Text.Length > 3
                ? lblRaporBaslik.Text.Substring(3).Trim()
                : lblRaporBaslik.Text;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dosyaAdi = TemizDosyaAdi(baslik) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            string fullPath = System.IO.Path.Combine(desktopPath, dosyaAdi);

            System.Text.StringBuilder csv = new System.Text.StringBuilder();
            
            string[] headers = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                headers[i] = "\"" + dt.Columns[i].ColumnName.Replace("\"", "\"\"") + "\"";
            }
            csv.AppendLine(string.Join(";", headers));

            foreach (DataRow row in dt.Rows)
            {
                string[] fields = new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    fields[i] = "\"" + (row[i]?.ToString() ?? "").Replace("\"", "\"\"") + "\"";
                }
                csv.AppendLine(string.Join(";", fields));
            }

            try
            {
                System.IO.File.WriteAllText(fullPath, csv.ToString(), System.Text.Encoding.UTF8);
                MessageBox.Show($"Rapor verileri başarıyla CSV (Excel uyumlu) olarak masaüstüne kaydedildi:\n{dosyaAdi}", 
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fullPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV Kaydedilirken bir hata oluştu:\n" + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TemizDosyaAdi(string name)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name.Replace(" ", "_");
        }
    }
}