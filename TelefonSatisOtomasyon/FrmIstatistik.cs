using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmIstatistik : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmIstatistik()
        {
            InitializeComponent();
        }

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            // Form açıldığında tüm verileri tazele
            VerileriYenile();
        }

        public void VerileriYenile()
        {
            GenelOzetGetir();
            GrafikDoldur();
        }

        void GenelOzetGetir()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    // 1. Toplam Müşteri Sayısı
                    SqlCommand cmd1 = new SqlCommand("SELECT COUNT(MusteriID) FROM Musteriler", conn);
                    lblMusteriSayisi.Text = cmd1.ExecuteScalar().ToString();

                    // 2. Toplam Satış Adedi (Tüm Zamanlar)
                    SqlCommand cmd2 = new SqlCommand("SELECT ISNULL(SUM(Adet),0) FROM Satislar", conn);
                    lblSatisAdedi.Text = cmd2.ExecuteScalar().ToString();

                    // 3. Kasadaki Net Nakit (Gelirler - Giderler)
                    string kasaSorgu = @"SELECT 
                        (SELECT ISNULL(SUM(Tutar),0) FROM Kasa WHERE IslemTipi IN ('Satış', 'Teknik Servis')) - 
                        (SELECT ABS(ISNULL(SUM(Tutar),0)) FROM Kasa WHERE IslemTipi IN ('Gider', 'İptal'))";

                    SqlCommand cmd3 = new SqlCommand(kasaSorgu, conn);
                    decimal netKasa = Convert.ToDecimal(cmd3.ExecuteScalar());
                    lblKasaNakit.Text = netKasa.ToString("C2"); // Para birimi formatı (₺)

                    // 4. Stoktaki Toplam Cihaz Sayısı
                    SqlCommand cmd4 = new SqlCommand("SELECT ISNULL(SUM(StokAdet),0) FROM Urunler", conn);
                    lblStokAdet.Text = cmd4.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Özet veriler çekilirken hata oluştu: " + ex.Message);
            }
        }

        void GrafikDoldur()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    // En Çok Satılan İlk 5 Marka (Analiz)
                    string sql = @"SELECT TOP 5 M.MarkaAd, SUM(S.Adet) as Toplam 
                                  FROM Satislar S 
                                  INNER JOIN Urunler U ON S.UrunID = U.UrunID 
                                  INNER JOIN Markalar M ON U.MarkaID = M.MarkaID 
                                  GROUP BY M.MarkaAd ORDER BY Toplam DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Grafik Ayarları
                    chartMarka.Series["Markalar"].Points.Clear();
                    chartMarka.Series["Markalar"].IsValueShownAsLabel = true; // Grafiğin üzerinde rakamlar görünsün
                    chartMarka.Series["Markalar"]["PieLabelStyle"] = "Outside"; // Rakamlar dilimin dışına yazılsın

                    foreach (DataRow row in dt.Rows)
                    {
                        chartMarka.Series["Markalar"].Points.AddXY(row["MarkaAd"].ToString(), row["Toplam"]);
                    }

                    // Grafik Başlığı (Opsiyonel)
                    if (chartMarka.Titles.Count == 0)
                        chartMarka.Titles.Add("En Çok Satan Markalar (Adet)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grafik oluşturulurken hata: " + ex.Message);
            }
        }

        // Fazlalık olan Load_1 metodunu silebilirsin veya boş bırakabilirsin
        private void FrmIstatistik_Load_1(object sender, EventArgs e) { }
    }
}