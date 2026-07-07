using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmPersonelSilOnay : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int personelID; // Ana formdan gelecek

        public FrmPersonelSilOnay()
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Personeller WHERE PersonelID=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", personelID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel kaydı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}