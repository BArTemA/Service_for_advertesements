using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class AuthForm : Form
    {
        public User CurrentUser { get; private set; }

        public AuthForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var authService = new AuthService())
            {
                CurrentUser = authService.Authenticate(txtUsername.Text, txtPassword.Text);

                if (CurrentUser != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}