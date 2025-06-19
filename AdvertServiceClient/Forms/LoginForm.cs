using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace AdvertServiceClient
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseHelper _dbHelper;

        public int CurrentUserId { get; private set; }
        public bool IsModerator { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text.ToString();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UsernameOrEmail", usernameOrEmail),
                new SqlParameter("@Password", password),
                new SqlParameter("@IsAuthenticated", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@IsModerator", SqlDbType.Bit) { Direction = ParameterDirection.Output }
            };

            try
            {
                _dbHelper.ExecuteStoredProcedure("sp_AuthenticateUser", parameters);

                bool isAuthenticated = (bool)parameters[2].Value;
                if (isAuthenticated)
                {
                    CurrentUserId = (int)parameters[3].Value;
                    IsModerator = (bool)parameters[4].Value;

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}