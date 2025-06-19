using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class AdDetailsForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _advertId;
        private readonly int _currentUserId;

        public AdDetailsForm(int advertId, int currentUserId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _advertId = advertId;
            _currentUserId = currentUserId;
            LoadAdDetails();
            CheckIsFavorite();
        }

        private void LoadAdDetails()
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AdvertID", _advertId),
                new SqlParameter("@IncrementViewCount", 1)
            };

            try
            {
                var adData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);
                if (adData.Rows.Count > 0)
                {
                    var row = adData.Rows[0];
                    lblTitle.Text = row["Title"].ToString();
                    lblDescription.Text = row["Description"].ToString();
                    lblPrice.Text = $"{row["Price"]} руб.";
                    lblSeller.Text = $"Продавец: {row["Username"]} (рейтинг: {row["SellerRating"]})";
                    lblCategory.Text = $"Категория: {row["CategoryName"]}";
                    lblLocation.Text = $"Местоположение: {row["City"]}, {row["Region"]}, {row["Country"]}";
                    lblViews.Text = $"Просмотров: {row["ViewCount"]}";
                    lblFavorites.Text = $"В избранном: {row["FavoritesCount"]}";

                    btnSendMessage.Visible = _currentUserId > 0 && (int)row["UserID"] != _currentUserId;
                    btnAddReview.Visible = _currentUserId > 0 && (int)row["UserID"] != _currentUserId;
                    btnComplain.Visible = _currentUserId > 0 && (int)row["UserID"] != _currentUserId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке объявления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckIsFavorite()
        {
            if (_currentUserId <= 0)
            {
                btnToggleFavorite.Visible = false;
                return;
            }

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _currentUserId),
                new SqlParameter("@AdvertID", _advertId),
                new SqlParameter("@IsFavorite", SqlDbType.Bit) { Direction = ParameterDirection.Output }
            };

            try
            {
                _dbHelper.ExecuteStoredProcedureNonQuery("sp_IsInFavorites", parameters);
                bool isFavorite = (bool)parameters[2].Value;

                btnToggleFavorite.Text = isFavorite ? "Удалить из избранного" : "Добавить в избранное";
                btnToggleFavorite.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке избранного: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnToggleFavorite.Text == "Добавить в избранное")
                {
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", _currentUserId),
                        new SqlParameter("@AdvertID", _advertId)
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_AddToFavorites", parameters);
                    MessageBox.Show("Объявление добавлено в избранное", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", _currentUserId),
                        new SqlParameter("@AdvertID", _advertId)
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_RemoveFromFavorites", parameters);
                    MessageBox.Show("Объявление удалено из избранного", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CheckIsFavorite();
                LoadAdDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с избранным: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var chatForm = new ChatForm(_currentUserId, _advertId);
            chatForm.ShowDialog();
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {
            var reviewForm = new AddReviewForm(_currentUserId, _advertId);
            if (reviewForm.ShowDialog() == DialogResult.OK)
            {
                LoadAdDetails();
            }
        }

        private void btnComplain_Click(object sender, EventArgs e)
        {
            var complainForm = new ComplainForm(_currentUserId, _advertId);
            complainForm.ShowDialog();
        }
    }
}