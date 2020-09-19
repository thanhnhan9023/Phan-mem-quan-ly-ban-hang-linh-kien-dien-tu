using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using QuanLyVatLieuXayDung.GUI;
using QuanLyVatLieuXayDung.Report;


namespace QuanLyVatLieuXayDung
{ 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool quit = false;
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            if (!quit)
            {
                Application.Run(new s());
            }
        }
    }
}
