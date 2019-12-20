using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAQLBH_Devexpress.ChucNang;
using DAQLBH_Devexpress.DanhMuc;
using QLBH_DTO;

namespace DAQLBH_Devexpress
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMainBH());
        }
    }
}
