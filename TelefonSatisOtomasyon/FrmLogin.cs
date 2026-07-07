using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TelefonSatisOtomasyon
{
    public partial class FrmLogin : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullanici.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtKullanici.BackColor = Color.MistyRose;
                txtSifre.BackColor = Color.MistyRose;
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAd=@p1 AND Sifre=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", txtKullanici.Text.Trim());
                    cmd.Parameters.AddWithValue("@p2", txtSifre.Text.Trim());

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // Giriş Başarılı
                        Form1 anaEkran = new Form1();
                        anaEkran.Show();
                        this.Hide(); // Giriş formunu gizle
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSifre.Clear();
                        txtSifre.Focus();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Bağlantı Hatası: " + ex.Message); }
        }

        private void btnIptal_Click(object sender, EventArgs e) { Application.Exit(); }
    }
}