using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class RegisterForm : Form
    {
        public User RegisteredUser { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Load locations for dropdown
            using (var locationService = new LocationService())
            {
                var locations = locationService.GetAllLocations();
                cmbLocation.DataSource = locations;
                cmbLocation.DisplayMember = "City";
                cmbLocation.ValueMember = "LocationID";
                cmbLocation.SelectedIndex = -1;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var userService = new UserService())
                {
                    int userId;
                    string passwordHash = HashPassword(txtPassword.Text); // You should implement proper password hashing

                    userService.RegisterUser(
                        txtUsername.Text.Trim(),
                        txtEmail.Text.Trim(),
                        passwordHash,
                        txtPhone.Text.Trim(),
                        cmbLocation.SelectedValue != null ? (int?)cmbLocation.SelectedValue : null,
                        out userId);

                    // Create user object for the registered user
                    RegisteredUser = new User
                    {
                        UserID = userId,
                        Username = txtUsername.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        RegistrationDate = DateTime.Now,
                        Phone = txtPhone.Text.Trim(),
                        LocationID = cmbLocation.SelectedValue != null ? (int?)cmbLocation.SelectedValue : null
                    };

                    MessageBox.Show("Регистрация прошла успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Введите имя пользователя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Имя пользователя должно содержать минимум 3 символа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Введите email", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Введите корректный email", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            // TODO: Implement proper password hashing (e.g., using BCrypt or PBKDF2)
            // This is just a placeholder - NEVER use this in production!
            return password; // In real app, replace with proper hashing
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}