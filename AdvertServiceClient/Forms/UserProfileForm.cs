using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class UserProfileForm : Form
    {
        private readonly User _currentUser;
        private readonly User _userData;

        public UserProfileForm(User currentUser, int? userId = null)
        {
            InitializeComponent();
            _currentUser = currentUser;

            using (var userService = new UserService())
            {
                _userData = userService.GetUserDetails(userId ?? currentUser.UserID);
            }

            if (_userData == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            Text = $"Профиль пользователя: {_userData.Username}";

            txtUsername.Text = _userData.Username;
            txtEmail.Text = _userData.Email;
            txtPhone.Text = _userData.Phone;
            txtRegistrationDate.Text = _userData.RegistrationDate.ToString("g");
            txtLastLogin.Text = _userData.LastLoginDate?.ToString("g") ?? "Никогда";
            txtRating.Text = _userData.Rating?.ToString("0.00") ?? "Нет оценок";
            txtAdvertsCount.Text = _userData.AdvertisementsCount.ToString();
            txtReviewsCount.Text = _userData.ReviewsCount.ToString();
            txtLocation.Text = $"{_userData.City}, {_userData.Region}, {_userData.Country}";
            lblIsModerator.Visible = _userData.IsModerator;

            // Настройка доступности редактирования
            bool isCurrentUser = _currentUser.UserID == _userData.UserID;
            btnEditProfile.Visible = isCurrentUser;
            btnChangePassword.Visible = isCurrentUser;
            btnUploadPhoto.Visible = isCurrentUser;
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            var editForm = new EditProfileForm(_currentUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем данные профиля
                using (var userService = new UserService())
                {
                    _userData = userService.GetUserDetails(_currentUser.UserID);
                    UserProfileForm_Load(null, null);
                }
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                        using (var userService = new UserService())
                        {
                            userService.UpdateUserProfile(_currentUser.UserID, null, null, null, imageBytes);
                            MessageBox.Show("Фото профиля обновлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки фото: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewReviews_Click(object sender, EventArgs e)
        {
            var reviewsForm = new UserReviewsForm(_userData.UserID);
            reviewsForm.ShowDialog();
        }

        private void btnViewAdverts_Click(object sender, EventArgs e)
        {
            var advertsForm = new UserAdvertsForm(_userData);
            advertsForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}