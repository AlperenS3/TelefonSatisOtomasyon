using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmTanimlamalar : Form
    {
        private readonly SqlBaglanti bgl = new SqlBaglanti();
        private readonly ErrorProvider ep = new ErrorProvider();

        public FrmTanimlamalar()
        {
            InitializeComponent();
            OlaylariVeAyarlariYap();
        }

        private void FrmTanimlamalar_Load(object sender, EventArgs e)
        {
            // Veritabanı tablolarını oluştur (ilk çalıştırmada)
            TabloOlustur();
            // Hepsini listele
            Tazele();
            // Grid stillerini uygula
            GridStil(dgvGorevler);
            GridStil(dgvOdemeTipleri);
            GridStil(dgvServisDurumlari);
        }

        private void OlaylariVeAyarlariYap()
        {
            // --- KLAVYE KISITLAMALARI ---
            txtGorevAd.KeyPress += SadeceHarfVeRakam_KeyPress;
            txtOdemeAd.KeyPress += SadeceHarfVeRakam_KeyPress;
            txtServisAd.KeyPress += SadeceHarfVeRakam_KeyPress;

            // --- RENK SIFIRLAMA (TextChanged) ---
            txtGorevAd.TextChanged += (s, e) => TxtRenkSifirla(txtGorevAd);
            txtOdemeAd.TextChanged += (s, e) => TxtRenkSifirla(txtOdemeAd);
            txtServisAd.TextChanged += (s, e) => TxtRenkSifirla(txtServisAd);

            // --- BUTON BAĞLANTILARI ---
            btnGorevEkle.Click += BtnGorevEkle_Click;
            btnGorevGuncelle.Click += BtnGorevGuncelle_Click;
            btnGorevSil.Click += BtnGorevSil_Click;

            btnOdemeEkle.Click += BtnOdemeEkle_Click;
            btnOdemeGuncelle.Click += BtnOdemeGuncelle_Click;
            btnOdemeSil.Click += BtnOdemeSil_Click;

            btnServisEkle.Click += BtnServisEkle_Click;
            btnServisGuncelle.Click += BtnServisGuncelle_Click;
            btnServisSil.Click += BtnServisSil_Click;

            // --- DGV SATIR SEÇİNCE TextBox'A DOLDUR ---
            dgvGorevler.CellClick += (s, e) =>
            {
                if (dgvGorevler.CurrentRow != null)
                    txtGorevAd.Text = dgvGorevler.CurrentRow.Cells["Görev Adı"].Value?.ToString() ?? "";
            };
            dgvOdemeTipleri.CellClick += (s, e) =>
            {
                if (dgvOdemeTipleri.CurrentRow != null)
                    txtOdemeAd.Text = dgvOdemeTipleri.CurrentRow.Cells["Ödeme Tipi"].Value?.ToString() ?? "";
            };
            dgvServisDurumlari.CellClick += (s, e) =>
            {
                if (dgvServisDurumlari.CurrentRow != null)
                    txtServisAd.Text = dgvServisDurumlari.CurrentRow.Cells["Durum Adı"].Value?.ToString() ?? "";
            };
        }

        // ─────────────────────────────────────────────────────────────
        //  VERİTABANI TABLO OLUŞTURMA (İLK ÇALIŞTIRMADA)
        // ─────────────────────────────────────────────────────────────
        private void TabloOlustur()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
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

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablo oluşturma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  LİSTELEME
        // ─────────────────────────────────────────────────────────────
        private void Tazele()
        {
            GorevleriGetir();
            OdemeTipleriniGetir();
            ServisDurumlariniGetir();
        }

        private void GorevleriGetir()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT GorevID as [ID], GorevAd as [Görev Adı] FROM Gorevler ORDER BY GorevAd", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvGorevler.DataSource = dt;
                    txtGorevAd.Clear();
                    TxtRenkSifirla(txtGorevAd);
                }
            }
            catch { }
        }

        private void OdemeTipleriniGetir()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT OdemeTipiID as [ID], OdemeTipiAd as [Ödeme Tipi] FROM OdemeTipleri ORDER BY OdemeTipiAd", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOdemeTipleri.DataSource = dt;
                    txtOdemeAd.Clear();
                    TxtRenkSifirla(txtOdemeAd);
                }
            }
            catch { }
        }

        private void ServisDurumlariniGetir()
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ServisDurumID as [ID], DurumAd as [Durum Adı] FROM ServisDurumlari ORDER BY DurumAd", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvServisDurumlari.DataSource = dt;
                    txtServisAd.Clear();
                    TxtRenkSifirla(txtServisAd);
                }
            }
            catch { }
        }

        // ─────────────────────────────────────────────────────────────
        //  GÖREV İŞLEMLERİ
        // ─────────────────────────────────────────────────────────────
        private void BtnGorevEkle_Click(object sender, EventArgs e)
        {
            if (!BoslukKontrol(txtGorevAd, "Görev adı boş olamaz!")) return;
            string ad = txtGorevAd.Text.Trim().ToUpper();

            if (KayitVarMi("Gorevler", "GorevAd", ad))
            {
                txtGorevAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' görevi zaten kayıtlı!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Gorevler (GorevAd) VALUES (@p1)", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Görev eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GorevleriGetir();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnGorevGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvGorevler.CurrentRow == null) { MessageBox.Show("Lütfen güncellenecek satırı seçin."); return; }
            if (!BoslukKontrol(txtGorevAd, "Görev adı boş olamaz!")) return;

            int id = Convert.ToInt32(dgvGorevler.CurrentRow.Cells["ID"].Value);
            string ad = txtGorevAd.Text.Trim().ToUpper();

            if (KayitVarMiHaricKendi("Gorevler", "GorevAd", "GorevID", ad, id))
            {
                txtGorevAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' ismiyle başka bir kayıt mevcut!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Gorevler SET GorevAd=@p1 WHERE GorevID=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.Parameters.AddWithValue("@p2", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Görev güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GorevleriGetir();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnGorevSil_Click(object sender, EventArgs e)
        {
            if (dgvGorevler.CurrentRow == null) { MessageBox.Show("Lütfen silinecek satırı seçin."); return; }
            string ad = dgvGorevler.CurrentRow.Cells["Görev Adı"].Value?.ToString() ?? "";
            if (MessageBox.Show($"'{ad}' görevini silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GercekSil("DELETE FROM Gorevler WHERE GorevID=@p1", dgvGorevler.CurrentRow.Cells["ID"].Value);
                GorevleriGetir();
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  ÖDEME TİPİ İŞLEMLERİ
        // ─────────────────────────────────────────────────────────────
        private void BtnOdemeEkle_Click(object sender, EventArgs e)
        {
            if (!BoslukKontrol(txtOdemeAd, "Ödeme tipi adı boş olamaz!")) return;
            string ad = txtOdemeAd.Text.Trim().ToUpper();

            if (KayitVarMi("OdemeTipleri", "OdemeTipiAd", ad))
            {
                txtOdemeAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' ödeme tipi zaten kayıtlı!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO OdemeTipleri (OdemeTipiAd) VALUES (@p1)", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Ödeme tipi eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OdemeTipleriniGetir();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnOdemeGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvOdemeTipleri.CurrentRow == null) { MessageBox.Show("Lütfen güncellenecek satırı seçin."); return; }
            if (!BoslukKontrol(txtOdemeAd, "Ödeme tipi adı boş olamaz!")) return;

            int id = Convert.ToInt32(dgvOdemeTipleri.CurrentRow.Cells["ID"].Value);
            string ad = txtOdemeAd.Text.Trim().ToUpper();

            if (KayitVarMiHaricKendi("OdemeTipleri", "OdemeTipiAd", "OdemeTipiID", ad, id))
            {
                txtOdemeAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' ismiyle başka bir kayıt mevcut!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE OdemeTipleri SET OdemeTipiAd=@p1 WHERE OdemeTipiID=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.Parameters.AddWithValue("@p2", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Ödeme tipi güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OdemeTipleriniGetir();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnOdemeSil_Click(object sender, EventArgs e)
        {
            if (dgvOdemeTipleri.CurrentRow == null) { MessageBox.Show("Lütfen silinecek satırı seçin."); return; }
            string ad = dgvOdemeTipleri.CurrentRow.Cells["Ödeme Tipi"].Value?.ToString() ?? "";
            if (MessageBox.Show($"'{ad}' ödeme tipini silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GercekSil("DELETE FROM OdemeTipleri WHERE OdemeTipiID=@p1", dgvOdemeTipleri.CurrentRow.Cells["ID"].Value);
                OdemeTipleriniGetir();
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  SERVİS DURUMLARI İŞLEMLERİ
        // ─────────────────────────────────────────────────────────────
        private void BtnServisEkle_Click(object sender, EventArgs e)
        {
            if (!BoslukKontrol(txtServisAd, "Durum adı boş olamaz!")) return;
            string ad = txtServisAd.Text.Trim().ToUpper();

            if (KayitVarMi("ServisDurumlari", "DurumAd", ad))
            {
                txtServisAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' durumu zaten kayıtlı!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ServisDurumlari (DurumAd) VALUES (@p1)", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Servis durumu eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ServisDurumlariniGetir();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnServisGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvServisDurumlari.CurrentRow == null) { MessageBox.Show("Lütfen güncellenecek satırı seçin."); return; }
            if (!BoslukKontrol(txtServisAd, "Durum adı boş olamaz!")) return;

            int id = Convert.ToInt32(dgvServisDurumlari.CurrentRow.Cells["ID"].Value);
            string ad = txtServisAd.Text.Trim().ToUpper();

            if (KayitVarMiHaricKendi("ServisDurumlari", "DurumAd", "ServisDurumID", ad, id))
            {
                txtServisAd.BackColor = Color.MistyRose;
                MessageBox.Show($"'{ad}' ismiyle başka bir kayıt mevcut!", "Tekrar Kayıt Engeli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ServisDurumlari SET DurumAd=@p1 WHERE ServisDurumID=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.Parameters.AddWithValue("@p2", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Servis durumu güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ServisDurumlariniGetir();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnServisSil_Click(object sender, EventArgs e)
        {
            if (dgvServisDurumlari.CurrentRow == null) { MessageBox.Show("Lütfen silinecek satırı seçin."); return; }
            string ad = dgvServisDurumlari.CurrentRow.Cells["Durum Adı"].Value?.ToString() ?? "";
            if (MessageBox.Show($"'{ad}' durumunu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GercekSil("DELETE FROM ServisDurumlari WHERE ServisDurumID=@p1", dgvServisDurumlari.CurrentRow.Cells["ID"].Value);
                ServisDurumlariniGetir();
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  YARDIMCI METODLAR
        // ─────────────────────────────────────────────────────────────

        /// <summary>Belirtilen tabloda aynı isimde kayıt var mı kontrolü</summary>
        private bool KayitVarMi(string tablo, string sutun, string deger)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    string sorgu = $"SELECT COUNT(*) FROM {tablo} WHERE UPPER({sutun}) = UPPER(@p1)";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", deger);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        /// <summary>Güncelleme sırasında — kendi ID'si hariç aynı isim var mı kontrolü</summary>
        private bool KayitVarMiHaricKendi(string tablo, string sutun, string idSutun, string deger, int kendi_id)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    string sorgu = $"SELECT COUNT(*) FROM {tablo} WHERE UPPER({sutun}) = UPPER(@p1) AND {idSutun} <> @p2";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", deger);
                    cmd.Parameters.AddWithValue("@p2", kendi_id);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        private void GercekSil(string sorgu, object id)
        {
            try
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Bu kayıt başka yerlerde kullanılıyor, silinemez!", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool BoslukKontrol(TextBox txt, string mesaj)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.MistyRose;
                ep.SetError(txt, mesaj);
                MessageBox.Show(mesaj, "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                return false;
            }
            return true;
        }

        private void TxtRenkSifirla(TextBox t)
        {
            t.BackColor = Color.White;
            ep.SetError(t, "");
        }

        private void GridStil(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
        }

        private void SadeceHarfVeRakam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Harf, rakam, boşluk ve kontrol tuşlarına izin ver
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }
    }
}
