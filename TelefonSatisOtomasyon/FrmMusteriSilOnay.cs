using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmMusteriSilOnay : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int musteriID; // Ana formdan gönderilecek ID

        public FrmMusteriSilOnay()
        {
            InitializeComponent();
            btnOnayla.Click += BtnOnayla_Click;
            btnIptal.Click += (s, e) => this.Close();
        }

        private void FrmMusteriSilOnay_Load(object sender, EventArgs e)
        {
            // --- HOCA KURALI: BİLGİLER PASİF OLMALI ---
            txtAdSoyad.Enabled = false;
            txtTelefon.Enabled = false; // MaskedTextBox formatlı ama müdahaleye kapalı

            // Eğer telefon formatı ana formdan gelmiyorsa mühürleme:
            txtTelefon.Mask = "(999) 000-0000";
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            // --- HOCA KURALI: İŞLEM ONAYI (SORU İKONU) ---
            if (MessageBox.Show("Müşteriyi ve bu müşteriye ait tüm satış geçmişini kalıcı olarak silmek istediğinize emin misiniz?",
                "Tehlikeli İşlem Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = bgl.baglanti())
            {
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Önce müşterinin satış geçmişini sil (Foreign Key kısıtlamasını aşmak için)
                    SqlCommand cmdSatis = new SqlCommand("DELETE FROM Satislar WHERE MusteriID=@p1", conn, trans);
                    cmdSatis.Parameters.AddWithValue("@p1", musteriID);
                    cmdSatis.ExecuteNonQuery();

                    // 2. Müşteriyi sil
                    SqlCommand cmdMusteri = new SqlCommand("DELETE FROM Musteriler WHERE MusteriID=@p1", conn, trans);
                    cmdMusteri.Parameters.AddWithValue("@p1", musteriID);
                    cmdMusteri.ExecuteNonQuery();

                    trans.Commit();

                    // --- HOCA KURALI: BİLGİ İKONU ---
                    MessageBox.Show("Müşteri ve bağlı tüm veriler başarıyla temizlendi.", "Sistem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Ana formun listeyi yenilemesi için
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    // --- HOCA KURALI: HATA İKONU ---
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}