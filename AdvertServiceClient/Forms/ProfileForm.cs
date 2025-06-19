using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ProfileForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;

        public ProfileForm(int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            LoadUserProfile();
            LoadUserReviews();
        }

        private void LoadUserProfile()
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _userId)
            };

            try
            {
                var userData = _dbHelper.ExecuteStoredProcedure("sp_GetUserDetails", parameters);
                if (userData.Rows.Count > 0)
                {
                    var row = userData.Rows[0];
                    lblUsername.Text = row["Username"].ToString();
                    lblEmail.Text = row["Email"].ToString();
                    lblPhone.Text = row["Phone"]?.ToString() ?? "не указан";
                    lblLocation.Text = $"{row["City"]}, {row["Region"]}, {row["Country"]}";
                    lblRating.Text = $"Рейтинг: {row["Rating"]}";
                    lblRegDate.Text = $"Зарегистрирован: {((DateTime)row["RegistrationDate"]).ToShortDateString()}";
                    lblLastLogin.Text = row["LastLoginDate"] != DBNull.Value ?
                        $"Последний вход: {((DateTime)row["LastLoginDate"]).ToShortDateString()}" :
                        "Последний вход: никогда";
                    lblAdsCount.Text = $"Объявлений: {row["AdvertisementsCount"]}";
                    lblReviewsCount.Text = $"Отзывов: {row["ReviewsCount"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке профиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserReviews(int page = 1, int pageSize = 5)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _userId),
                new SqlParameter("@PageNumber", page),
                new SqlParameter("@PageSize", pageSize)
            };

            try
            {
                var reviewsData = _dbHelper.ExecuteStoredProcedure("sp_GetUserReviews", parameters);
                dgvReviews.DataSource = reviewsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отзывов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var changePasswordForm = new ChangePasswordForm(_userId);
            changePasswordForm.ShowDialog();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            var updateProfileForm = new UpdateProfileForm(_userId);
            if (updateProfileForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserProfile();
            }
        }
    }
}