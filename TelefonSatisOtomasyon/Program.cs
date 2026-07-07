using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonSatisOtomasyon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        // Program.cs
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Veritabanı tanımlama tablolarını otomatik oluştur/kontrol et
            try
            {
                new SqlBaglanti().VeritabaniTablolariOlustur();
            }
            catch { }

            Application.Run(new FrmLogin()); // Form1 yerine FrmLogin yazıyoruz!
        }
    }
}
