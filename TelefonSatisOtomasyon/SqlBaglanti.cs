using System;
using System.Data.SqlClient;

namespace TelefonSatisOtomasyon
{
    class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            // Senin bilgisayarındaki gerçek LocalDB adresi
            string yol = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TelefonSatisDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(yol);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void VeritabaniTablolariOlustur()
        {
            try
            {
                using (SqlConnection conn = baglanti())
                {
                    string sql = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Gorevler' AND xtype='U')
                        BEGIN
                            CREATE TABLE Gorevler (
                                GorevID   INT IDENTITY(1,1) PRIMARY KEY,
                                GorevAd   NVARCHAR(100) NOT NULL UNIQUE
                            );
                            INSERT INTO Gorevler (GorevAd) VALUES
                                (N'Satış Temsilcisi'),(N'Teknisyen'),(N'Müdür'),(N'Kasiyer'),(N'Muhasebeci');
                        END

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OdemeTipleri' AND xtype='U')
                        BEGIN
                            CREATE TABLE OdemeTipleri (
                                OdemeTipiID  INT IDENTITY(1,1) PRIMARY KEY,
                                OdemeTipiAd  NVARCHAR(100) NOT NULL UNIQUE
                            );
                            INSERT INTO OdemeTipleri (OdemeTipiAd) VALUES
                                (N'Nakit'),(N'Kredi Kartı'),(N'Banka Havalesi'),(N'Taksit'),(N'Diğer');
                        END

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ServisDurumlari' AND xtype='U')
                        BEGIN
                            CREATE TABLE ServisDurumlari (
                                ServisDurumID  INT IDENTITY(1,1) PRIMARY KEY,
                                DurumAd        NVARCHAR(100) NOT NULL UNIQUE
                            );
                            INSERT INTO ServisDurumlari (DurumAd) VALUES
                                (N'Beklemede'),(N'İnceleniyor'),(N'Parça Bekleniyor'),(N'Tamamlandı'),(N'Teslim Edildi');
                        END";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Veritabanı tablosu başlatma hatası: " + ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}