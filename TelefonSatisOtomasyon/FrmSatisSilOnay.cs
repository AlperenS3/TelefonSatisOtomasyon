using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmSatisSilOnay : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int satisID; // Ana formdan gönderilecek

        public FrmSatisSilOnay()
        {
            InitializeComponent();
            btnOnayla.Click += BtnOnayla_Click;
            btnIptal.Click += (s, e) => this.Close();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglan = bgl.baglanti())
            {
                SqlTransaction trans = baglan.BeginTransaction();
                try
                {
                    // 1. ÜrünID ve Adet bilgilerini al (Stok güncellemesi için)
                    SqlCommand cmdBul = new SqlCommand("SELECT UrunID, Adet FROM Satislar WHERE SatisID = @id", baglan, trans);
                    cmdBul.Parameters.AddWithValue("@id", satisID);
                    SqlDataReader dr = cmdBul.ExecuteReader();
                    int urunID = 0, adet = 0;
                    if (dr.Read()) { urunID = (int)dr["UrunID"]; adet = (int)dr["Adet"]; }
                    dr.Close();

                    // 2. Satışı sil
                    SqlCommand cmdSil = new SqlCommand("DELETE FROM Satislar WHERE SatisID = @id", baglan, trans);
                    cmdSil.Parameters.AddWithValue("@id", satisID);
                    cmdSil.ExecuteNonQuery();

                    // 3. Stokları iade et
                    SqlCommand cmdIade = new SqlCommand("UPDATE Urunler SET StokAdet = StokAdet + @adet WHERE UrunID = @uid", baglan, trans);
                    cmdIade.Parameters.AddWithValue("@adet", adet);
                    cmdIade.Parameters.AddWithValue("@uid", urunID);
                    cmdIade.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Satış iptal edildi ve stoklar güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("İşlem hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}