using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmKasaSilOnay : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int kasaID; // Ana formdan gelecek olan ID

        public FrmKasaSilOnay()
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Kasa WHERE KasaID=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", kasaID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kasa kaydı kalıcı olarak silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
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