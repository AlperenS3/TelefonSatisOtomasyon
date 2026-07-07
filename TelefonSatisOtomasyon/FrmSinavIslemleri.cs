using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmSinavIslemleri : Form
    {
        private readonly SqlBaglanti bgl = new SqlBaglanti();

        // Seçili satırın ID'sini hafızada tutmak için sınıf seviyesinde değişken
        private int secilenStajyerID = -1;

        // CheckBox'ların birbirini tetiklerken sonsuz döngü
        private bool isChanging = false;

        public FrmSinavIslemleri()
        {
            InitializeComponent();
            FormTasariminiKur();
            EtkinlikleriBagla();
        }

        // arayüz tasarımı kurulumu
        private void FormTasariminiKur()
        {
            this.Text = "Stajyer Kayıt ve Yönetim Paneli";
            this.Size = new Size(1020, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);

            // Üst Başlık Paneli
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.FromArgb(41, 53, 65) };
            Label lblHeader = new Label { Text = "📋 STAJYER VERİ YÖNETİM SİSTEMİ", ForeColor = Color.White, Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(15, 12), AutoSize = true };
            pnlHeader.Controls.Add(lblHeader);
            this.Controls.Add(pnlHeader);

            // Sol Veri Giriş Form Alanı (Grup Kutusu)
            GroupBox grpVeriGiris = new GroupBox { Text = "Stajyer Bilgileri Formu", Location = new Point(15, 65), Size = new Size(340, 500), Font = new Font("Segoe UI", 9, FontStyle.Bold) };

            // 0. Sistem ID (Düzenlenebilir Yapıldı)
            Label lblID = new Label { Text = "Sistem ID:", Location = new Point(15, 35), AutoSize = true };
            TextBox txtID = new TextBox { Name = "txtID", Location = new Point(130, 32), Size = new Size(180, 25), ReadOnly = false, BackColor = Color.White };

            // 1. Stajyer No
            Label lblStajyerNo = new Label { Text = "Stajyer No:", Location = new Point(15, 70), AutoSize = true };
            TextBox txtStajyerNo = new TextBox { Name = "txtStajyerNo", Location = new Point(130, 67), Size = new Size(180, 25) };

            // 2. Ad
            Label lblAd = new Label { Text = "Adı:", Location = new Point(15, 105), AutoSize = true };
            TextBox txtAd = new TextBox { Name = "txtAd", Location = new Point(130, 102), Size = new Size(180, 25) };

            // 3. Soyad
            Label lblSoyad = new Label { Text = "Soyadı:", Location = new Point(15, 140), AutoSize = true };
            TextBox txtSoyad = new TextBox { Name = "txtSoyad", Location = new Point(130, 137), Size = new Size(180, 25) };

            // 4. Cinsiyet (CheckBox Mimarisi)
            Label lblCinsiyet = new Label { Text = "Cinsiyet:", Location = new Point(15, 175), AutoSize = true };
            CheckBox chkBay = new CheckBox { Name = "chkBay", Text = "Bay", Location = new Point(130, 174), AutoSize = true };
            CheckBox chkBayan = new CheckBox { Name = "chkBayan", Text = "Bayan", Location = new Point(210, 174), AutoSize = true };

            // 5. Doğum Tarihi
            Label lblDogumTarihi = new Label { Text = "Doğum Tarihi:", Location = new Point(15, 210), AutoSize = true };
            DateTimePicker dtpDogumTarihi = new DateTimePicker { Name = "dtpDogumTarihi", Location = new Point(130, 207), Size = new Size(180, 25), Format = DateTimePickerFormat.Short };

            // 6. Bölüm
            Label lblBolum = new Label { Text = "Bölüm / Alan:", Location = new Point(15, 245), AutoSize = true };
            ComboBox cmbBolum = new ComboBox { Name = "cmbBolum", Location = new Point(130, 242), Size = new Size(180, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbBolum.Items.AddRange(new object[] { "Yazılım Geliştirme", "Donanım / Ağ", "Mobil Programlama", "Tasarım", "Pazarlama" });

            // 7. Sigorta Durumu (CheckBox Mimarisi)
            Label lblSigorta = new Label { Text = "Sigorta Durumu:", Location = new Point(15, 280), AutoSize = true };
            CheckBox chkSigortaVar = new CheckBox { Name = "chkSigortaVar", Text = "Var", Location = new Point(130, 279), AutoSize = true };
            CheckBox chkSigortaYok = new CheckBox { Name = "chkSigortaYok", Text = "Yok", Location = new Point(210, 279), AutoSize = true };

            // İşlem Butonları
            Button btnEkle = new Button { Name = "btnEkle", Text = "➕ EKLE", Location = new Point(15, 375), Size = new Size(145, 40), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnSil = new Button { Name = "btnSil", Text = "❌ SİL", Location = new Point(175, 375), Size = new Size(145, 40), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnDegistir = new Button { Name = "btnDegistir", Text = "🔄 DEĞİŞTİR", Location = new Point(15, 430), Size = new Size(145, 40), BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnRapor = new Button { Name = "btnRapor", Text = "📊 RAPOR AL", Location = new Point(175, 430), Size = new Size(145, 40), BackColor = Color.FromArgb(241, 196, 15), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            grpVeriGiris.Controls.AddRange(new Control[] {
                lblID, txtID,
                lblStajyerNo, txtStajyerNo,
                lblAd, txtAd,
                lblSoyad, txtSoyad,
                lblCinsiyet, chkBay, chkBayan,
                lblDogumTarihi, dtpDogumTarihi,
                lblBolum, cmbBolum,
                lblSigorta, chkSigortaVar, chkSigortaYok,
                btnEkle, btnSil, btnDegistir, btnRapor
            });
            this.Controls.Add(grpVeriGiris);

            // Sağ Taraf Liste Görünümü (DataGridView)
            DataGridView dgw = new DataGridView
            {
                Name = "dgvSinavlar",
                Location = new Point(375, 65),
                Size = new Size(610, 440),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgw);

            // Arama Kontrolleri Paneli
            Label lblArama = new Label { Text = "🔍 Bölüme Göre Ara:", Location = new Point(375, 525), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DarkOrange };
            TextBox txtAramaBolum = new TextBox { Name = "txtAramaBolum", Location = new Point(520, 522), Size = new Size(465, 25), BorderStyle = BorderStyle.FixedSingle };
            this.Controls.AddRange(new Control[] { lblArama, txtAramaBolum });
        }

        private void EtkinlikleriBagla()
        {
            Control[] cEkle = this.Controls.Find("btnEkle", true);
            Control[] cSil = this.Controls.Find("btnSil", true);
            Control[] cDegistir = this.Controls.Find("btnDegistir", true);
            Control[] cRapor = this.Controls.Find("btnRapor", true);
            Control[] cGrid = this.Controls.Find("dgvSinavlar", true);
            Control[] tArama = this.Controls.Find("txtAramaBolum", true);

            CheckBox chkBay = (CheckBox)this.Controls.Find("chkBay", true)[0];
            CheckBox chkBayan = (CheckBox)this.Controls.Find("chkBayan", true)[0];
            CheckBox chkSigortaVar = (CheckBox)this.Controls.Find("chkSigortaVar", true)[0];
            CheckBox chkSigortaYok = (CheckBox)this.Controls.Find("chkSigortaYok", true)[0];

            // Cinsiyet CheckBox Tekli Seçim Mantığı
            chkBay.CheckedChanged += (s, e) => {
                if (isChanging) return;
                isChanging = true;
                if (chkBay.Checked) chkBayan.Checked = false;
                isChanging = false;
            };
            chkBayan.CheckedChanged += (s, e) => {
                if (isChanging) return;
                isChanging = true;
                if (chkBayan.Checked) chkBay.Checked = false;
                isChanging = false;
            };

            // Sigorta CheckBox Tekli Seçim Mantığı
            chkSigortaVar.CheckedChanged += (s, e) => {
                if (isChanging) return;
                isChanging = true;
                if (chkSigortaVar.Checked) chkSigortaYok.Checked = false;
                isChanging = false;
            };
            chkSigortaYok.CheckedChanged += (s, e) => {
                if (isChanging) return;
                isChanging = true;
                if (chkSigortaYok.Checked) chkSigortaVar.Checked = false;
                isChanging = false;
            };

            if (cEkle.Length > 0) ((Button)cEkle[0]).Click += BtnEkle_Click;
            if (cSil.Length > 0) ((Button)cSil[0]).Click += BtnSil_Click;
            if (cDegistir.Length > 0) ((Button)cDegistir[0]).Click += BtnDegistir_Click;
            if (cRapor.Length > 0) ((Button)cRapor[0]).Click += BtnRapor_Click;
            if (cGrid.Length > 0) ((DataGridView)cGrid[0]).CellClick += dgvSinavlar_CellClick;
            if (tArama.Length > 0) ((TextBox)tArama[0]).TextChanged += TxtAramaBolum_TextChanged;

            Listele();
        }

        // --- SQL SELECT: LİSTELEME & FİLTRELEME ---
        private void Listele(string arananBolum = "")
        {
            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();

                    //  gerçek sütun isimleri ve takma adlar 
                    string query = "SELECT ID, StajyerNo, Adi, Soyadi, Cinsiyet, DogumTarihi, Bolum, SigortaDurumu FROM TblStajyerler";

                    if (!string.IsNullOrWhiteSpace(arananBolum))
                    {
                        query += " WHERE Bolum LIKE @aranan ORDER BY ID DESC";
                    }
                    else
                    {
                        query += " ORDER BY ID DESC";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, baglan);
                    if (!string.IsNullOrWhiteSpace(arananBolum))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@aranan", "%" + arananBolum.Trim() + "%");
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Control[] cGrid = this.Controls.Find("dgvSinavlar", true);
                    if (cGrid.Length > 0)
                    {
                        DataGridView dgv = (DataGridView)cGrid[0];
                        dgv.DataSource = dt;

                        // Tablo başlıklarını kullanıcı dostu yapalım (Hata vermemesi için kolon ismini değil HeaderText'ini değiştiriyoruz)
                        if (dgv.Columns.Count > 0)
                        {
                            dgv.Columns["StajyerNo"].HeaderText = "Stajyer No";
                            dgv.Columns["Adi"].HeaderText = "Adı";
                            dgv.Columns["Soyadi"].HeaderText = "Soyadı";
                            dgv.Columns["DogumTarihi"].HeaderText = "Doğum Tarihi";
                            dgv.Columns["Bolum"].HeaderText = "Bölüm";
                            dgv.Columns["SigortaDurumu"].HeaderText = "Sigorta Durumu";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtAramaBolum_TextChanged(object sender, EventArgs e)
        {
            TextBox txtArama = (TextBox)sender;
            Listele(txtArama.Text);
        }

        // --- SQL INSERT: EKLEME ---
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Control[] tNo = this.Controls.Find("txtStajyerNo", true);
            Control[] tAd = this.Controls.Find("txtAd", true);
            Control[] tSoyad = this.Controls.Find("txtSoyad", true);
            CheckBox chkBay = (CheckBox)this.Controls.Find("chkBay", true)[0];
            CheckBox chkBayan = (CheckBox)this.Controls.Find("chkBayan", true)[0];
            Control[] dtpDogum = this.Controls.Find("dtpDogumTarihi", true);
            Control[] cBol = this.Controls.Find("cmbBolum", true);
            CheckBox chkSigortaVar = (CheckBox)this.Controls.Find("chkSigortaVar", true)[0];
            CheckBox chkSigortaYok = (CheckBox)this.Controls.Find("chkSigortaYok", true)[0];

            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();

                    string cinsiyet = "";
                    if (chkBay.Checked)
                        cinsiyet = "Erkek";
                    else if (chkBayan.Checked)
                        cinsiyet = "Kadın";

                    string bolum = "";
                    if (((ComboBox)cBol[0]).SelectedItem != null)
                        bolum = ((ComboBox)cBol[0]).SelectedItem.ToString();

                    string sigorta = "";
                    if (chkSigortaVar.Checked)
                        sigorta = "Var";
                    else if (chkSigortaYok.Checked)
                        sigorta = "Yok";

                    string query =
                        "INSERT INTO TblStajyerler " +
                        "(StajyerNo, Adi, Soyadi, Cinsiyet, DogumTarihi, Bolum, SigortaDurumu) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

                    SqlCommand komut = new SqlCommand(query, baglan);

                    komut.Parameters.AddWithValue("@p1", ((TextBox)tNo[0]).Text.Trim());
                    komut.Parameters.AddWithValue("@p2", ((TextBox)tAd[0]).Text.Trim());
                    komut.Parameters.AddWithValue("@p3", ((TextBox)tSoyad[0]).Text.Trim());
                    komut.Parameters.AddWithValue("@p4", cinsiyet);
                    komut.Parameters.AddWithValue("@p5", ((DateTimePicker)dtpDogum[0]).Value);
                    komut.Parameters.AddWithValue("@p6", bolum);
                    komut.Parameters.AddWithValue("@p7", sigorta);

                    komut.ExecuteNonQuery();

                    MessageBox.Show(
                        "Stajyer kaydı başarıyla eklendi!",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    FormuTemizle();
                    Listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ekleme Hatası: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // --- SQL DELETE: SİLME ---
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (secilenStajyerID == -1)
            {
                MessageBox.Show("Lütfen silmek istediğiniz stajyer kaydını listeden seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçilen stajyer kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection baglan = bgl.baglanti())
                    {
                        if (baglan.State == ConnectionState.Closed) baglan.Open();

                        SqlCommand komut = new SqlCommand("DELETE FROM TblStajyerler WHERE ID=@p1", baglan);
                        komut.Parameters.AddWithValue("@p1", secilenStajyerID);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Stajyer kaydı sistemden kaldırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormuTemizle();
                        Listele();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Silme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // --- SQL UPDATE: DEĞİŞTİRME ---
        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            if (secilenStajyerID == -1)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz stajyer kaydını listeden seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Control[] tNo = this.Controls.Find("txtStajyerNo", true);
            Control[] tAd = this.Controls.Find("txtAd", true);
            Control[] tSoyad = this.Controls.Find("txtSoyad", true);
            CheckBox chkBay = (CheckBox)this.Controls.Find("chkBay", true)[0];
            CheckBox chkBayan = (CheckBox)this.Controls.Find("chkBayan", true)[0];
            Control[] dtpDogum = this.Controls.Find("dtpDogumTarihi", true);
            Control[] cBol = this.Controls.Find("cmbBolum", true);
            CheckBox chkSigortaVar = (CheckBox)this.Controls.Find("chkSigortaVar", true)[0];
            CheckBox chkSigortaYok = (CheckBox)this.Controls.Find("chkSigortaYok", true)[0];

            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();

                    string query = "UPDATE TblStajyerler SET StajyerNo=@p1, Adi=@p2, Soyadi=@p3, Cinsiyet=@p4, DogumTarihi=@p5, Bolum=@p6, SigortaDurumu=@p7 WHERE ID=@p8";
                    SqlCommand komut = new SqlCommand(query, baglan);
                    komut.Parameters.AddWithValue("@p1", ((TextBox)tNo[0]).Text.Trim());
                    komut.Parameters.AddWithValue("@p2", ((TextBox)tAd[0]).Text.Trim());
                    komut.Parameters.AddWithValue("@p3", ((TextBox)tSoyad[0]).Text.Trim());
                    komut.Parameters.AddWithValue("@p4", chkBay.Checked ? "Erkek" : "Kadın");
                    komut.Parameters.AddWithValue("@p5", ((DateTimePicker)dtpDogum[0]).Value);
                    komut.Parameters.AddWithValue("@p6", ((ComboBox)cBol[0]).SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p7", chkSigortaVar.Checked ? "Var" : "Yok");
                    komut.Parameters.AddWithValue("@p8", secilenStajyerID);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Stajyer bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormuTemizle();
                    Listele();
                }
            }
            catch (Exception ex) { MessageBox.Show("Güncelleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // --- SQL AGGREGATE: RAPORLAMA ---
        private void BtnRapor_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection baglan = bgl.baglanti())
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();

                    SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM TblStajyerler", baglan);
                    SqlCommand cmdSigortali = new SqlCommand("SELECT COUNT(*) FROM TblStajyerler WHERE SigortaDurumu = 'Var'", baglan);

                    int toplamStajyer = Convert.ToInt32(cmdTotal.ExecuteScalar());
                    int sigortaliStajyer = Convert.ToInt32(cmdSigortali.ExecuteScalar());

                    MessageBox.Show($"📊 Stajyer İstatistik Özeti:\n\nSistemdeki Toplam Stajyer: {toplamStajyer}\nSigortası Olan Stajyer: {sigortaliStajyer}", "Genel Rapor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex) { MessageBox.Show("Raporlama Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //  (Tablodan verileri kutulara çeker)
        private void DataGridViewGuncelle(DataGridView dgv, int secilenSatir)
        {
            secilenStajyerID = Convert.ToInt32(dgv.Rows[secilenSatir].Cells["ID"].Value);

            Control[] tID = this.Controls.Find("txtID", true);
            Control[] tNo = this.Controls.Find("txtStajyerNo", true);
            Control[] tAd = this.Controls.Find("txtAd", true);
            Control[] tSoyad = this.Controls.Find("txtSoyad", true);
            CheckBox chkBay = (CheckBox)this.Controls.Find("chkBay", true)[0];
            CheckBox chkBayan = (CheckBox)this.Controls.Find("chkBayan", true)[0];
            Control[] dtpDogum = this.Controls.Find("dtpDogumTarihi", true);
            Control[] cBol = this.Controls.Find("cmbBolum", true);
            CheckBox chkSigortaVar = (CheckBox)this.Controls.Find("chkSigortaVar", true)[0];
            CheckBox chkSigortaYok = (CheckBox)this.Controls.Find("chkSigortaYok", true)[0];

            if (tID.Length > 0) ((TextBox)tID[0]).Text = secilenStajyerID.ToString();
            if (tNo.Length > 0) ((TextBox)tNo[0]).Text = dgv.Rows[secilenSatir].Cells["StajyerNo"].Value.ToString();
            if (tAd.Length > 0) ((TextBox)tAd[0]).Text = dgv.Rows[secilenSatir].Cells["Adi"].Value.ToString();
            if (tSoyad.Length > 0) ((TextBox)tSoyad[0]).Text = dgv.Rows[secilenSatir].Cells["Soyadi"].Value.ToString();

            // Döngü kilidini açar
            isChanging = true;

            string gender = dgv.Rows[secilenSatir].Cells["Cinsiyet"].Value.ToString();
            chkBay.Checked = (gender == "Erkek" || gender == "Bay");
            chkBayan.Checked = (gender == "Kadın" || gender == "Bayan");

            if (dtpDogum.Length > 0) ((DateTimePicker)dtpDogum[0]).Value = Convert.ToDateTime(dgv.Rows[secilenSatir].Cells["DogumTarihi"].Value);
            if (cBol.Length > 0) ((ComboBox)cBol[0]).SelectedItem = dgv.Rows[secilenSatir].Cells["Bolum"].Value.ToString();

            string sigorta = dgv.Rows[secilenSatir].Cells["SigortaDurumu"].Value.ToString();
            chkSigortaVar.Checked = (sigorta == "Var");
            chkSigortaYok.Checked = (sigorta == "Yok");

            isChanging = false;
        }

        private void dgvSinavlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewGuncelle(dgv, e.RowIndex);
            }
        }

        // Form girdilerini sıfırlama işlevi
        private void FormuTemizle()
        {
            secilenStajyerID = -1;
            Control[] tID = this.Controls.Find("txtID", true);
            Control[] tNo = this.Controls.Find("txtStajyerNo", true);
            Control[] tAd = this.Controls.Find("txtAd", true);
            Control[] tSoyad = this.Controls.Find("txtSoyad", true);
            CheckBox chkBay = (CheckBox)this.Controls.Find("chkBay", true)[0];
            CheckBox chkBayan = (CheckBox)this.Controls.Find("chkBayan", true)[0];
            Control[] dtpDogum = this.Controls.Find("dtpDogumTarihi", true);
            Control[] cBol = this.Controls.Find("cmbBolum", true);
            CheckBox chkSigortaVar = (CheckBox)this.Controls.Find("chkSigortaVar", true)[0];
            CheckBox chkSigortaYok = (CheckBox)this.Controls.Find("chkSigortaYok", true)[0];
            Control[] tArama = this.Controls.Find("txtAramaBolum", true);

            if (tID.Length > 0) ((TextBox)tID[0]).Clear();
            if (tNo.Length > 0) ((TextBox)tNo[0]).Clear();
            if (tAd.Length > 0) ((TextBox)tAd[0]).Clear();
            if (tSoyad.Length > 0) ((TextBox)tSoyad[0]).Clear();

            isChanging = true;
            chkBay.Checked = false;
            chkBayan.Checked = false;
            chkSigortaVar.Checked = false;
            chkSigortaYok.Checked = false;
            isChanging = false;

            if (dtpDogum.Length > 0) ((DateTimePicker)dtpDogum[0]).Value = DateTime.Now;
            if (cBol.Length > 0) ((ComboBox)cBol[0]).SelectedIndex = -1;
            if (tArama.Length > 0) ((TextBox)tArama[0]).Clear();
        }

      
        private void dgvSinavlar_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvSinavlar_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void FrmSinavIslemleri_Load(object sender, EventArgs e) { }
        private void FrmSinavIslemleri_Load_1(object sender, EventArgs e) { }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {

        }
    }
}