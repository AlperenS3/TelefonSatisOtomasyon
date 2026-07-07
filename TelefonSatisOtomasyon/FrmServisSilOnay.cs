using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmServisSilOnay : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int servisID; // Ana formdan gönderilecek

        public FrmServisSilOnay()
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM TeknikServis WHERE ServisID=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", servisID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teknik servis kaydı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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