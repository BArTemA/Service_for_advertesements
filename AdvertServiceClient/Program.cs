using AdvertServiceClient.Forms;
using AdvertServiceClient.Models;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var authForm = new AuthForm();
            if (authForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(authForm.CurrentUser));
            }
        }
    }
}