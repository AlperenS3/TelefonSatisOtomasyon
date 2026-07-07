using System;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    public partial class FrmAyarlarSilOnay : Form
    {
        public FrmAyarlarSilOnay()
        {
            InitializeComponent();
        }

        private void FrmAyarlarSilOnay_Load(object sender, EventArgs e)
        {
            // Butonların DialogResult özelliklerini mühürleyelim
            btnOnayla.DialogResult = DialogResult.OK;
            btnIptal.DialogResult = DialogResult.Cancel;

            // Tıklama olaylarını bağlayalım
            btnOnayla.Click += (s, ev) => { this.Close(); };
            btnIptal.Click += (s, ev) => { this.Close(); };
        }
    }
}