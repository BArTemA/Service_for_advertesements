using System;
using System.Windows.Forms;

namespace AdvertServiceClient
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

            // Показываем форму входа
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Если авторизация успешна, запускаем главную форму
                Application.Run(new MainForm(loginForm.CurrentUserId, loginForm.IsModerator));
            }
        }
    }
}