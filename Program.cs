using System;
using System.Windows.Forms;

namespace VehicleManagement
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
            Application.Run(new MainForm());

            //using (LoginForm loginForm = new LoginForm())
            //{
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new MainForm());
            //    }
            //    else
            //    {
            //        // Người dùng đóng hoặc hủy đăng nhập
            //        Application.Exit();
            //    }
            //}
        }
    }
}
