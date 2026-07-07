using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmUrunSilOnay : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int silinecekID; // Ana formdan gelecek ID

        public FrmUrunSilOnay()
        {
            InitializeComponent();
            btnOnayla.Click += BtnOnayla_Click;
            btnIptal.Click += (s, e) => this.Close();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Urunler WHERE UrunID=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", silinecekID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Başarılı kapandı sinyali
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}