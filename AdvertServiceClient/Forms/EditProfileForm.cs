using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class EditProfileForm : Form
    {
        private readonly User _currentUser;

        public EditProfileForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            using (var userService = new UserService())
            {
                var user = userService.GetUserDetails(_currentUser.UserID);

                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtCity.Text = user.City;
                txtRegion.Text = user.Region;
                txtCountry.Text = user.Country;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var userService = new UserService())
                {
                    // В реальном приложении здесь нужно получить LocationID из введенных данных
                    int? locationId = null;

                    userService.UpdateUserProfile(
                        _currentUser.UserID,
                        txtEmail.Text,
                        txtPhone.Text,
                        locationId,
                        null); // Можно добавить загрузку фото

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}