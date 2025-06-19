using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class MainForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _currentUserId;
        private readonly bool _isModerator;

        public MainForm(int userId, bool isModerator)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _currentUserId = userId;
            _isModerator = isModerator;

            LoadUserProfile();
            LoadAdvertisements();
            UpdateUI();
        }

        private void UpdateUI()
        {
            btnCreateAd.Visible = _currentUserId > 0;
            btnMyProfile.Visible = _currentUserId > 0;
            btnMyAds.Visible = _currentUserId > 0;
            btnModeration.Visible = _isModerator;
        }

        private void LoadUserProfile()
        {
            if (_currentUserId <= 0) return;

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _currentUserId)
            };

            try
            {
                var userData = _dbHelper.ExecuteStoredProcedure("sp_GetUserDetails", parameters);
                if (userData.Rows.Count > 0)
                {
                    lblWelcome.Text = $"Добро пожаловать, {userData.Rows[0]["Username"]}!";
                    lblRating.Text = $"Рейтинг: {userData.Rows[0]["Rating"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке профиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAdvertisements()
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Status", "Active")
                };

                var adsData = _dbHelper.ExecuteStoredProcedure("sp_SearchAdvertisements", parameters);
                dgvAdvertisements.DataSource = adsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке объявлений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateAd_Click(object sender, EventArgs e)
        {
            var createAdForm = new CreateAdForm(_currentUserId);
            if (createAdForm.ShowDialog() == DialogResult.OK)
            {
                LoadAdvertisements();
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileForm(_currentUserId);
            profileForm.ShowDialog();
            LoadUserProfile();
        }

        private void btnMyAds_Click(object sender, EventArgs e)
        {
            var myAdsForm = new MyAdsForm(_currentUserId);
            myAdsForm.ShowDialog();
            LoadAdvertisements();
        }

        private void btnModeration_Click(object sender, EventArgs e)
        {
            var moderationForm = new ModerationForm(_currentUserId);
            moderationForm.ShowDialog();
        }

        private void dgvAdvertisements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int advertId = Convert.ToInt32(dgvAdvertisements.Rows[e.RowIndex].Cells["AdvertID"].Value);
                var adDetailsForm = new AdDetailsForm(advertId, _currentUserId);
                adDetailsForm.ShowDialog();
                LoadAdvertisements();
            }
        }
    }
}