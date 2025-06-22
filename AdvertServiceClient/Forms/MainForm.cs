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
            btnMyProfile.Visible = _currentUserId > 0;
            btnMyAds.Visible = _currentUserId > 0;
            btnModeration.Visible = _isModerator;
            btnChats.Visible = _currentUserId > 0;
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
            flowLayoutPanel1.Controls.Clear();

            try
            {
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@Status", "Active"),
            new SqlParameter("@PageSize", 20) // Добавляем явное ограничение
                };

                var adsData = _dbHelper.ExecuteStoredProcedure("sp_SearchAdvertisements", parameters);

                if (adsData == null || adsData.Rows.Count == 0)
                {
                    MessageBox.Show("Нет активных объявлений для отображения.",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in adsData.Rows)
                {
                    try
                    {
                        // Безопасное получение значений с обработкой NULL
                        var advertId = row["AdvertID"] != DBNull.Value ? Convert.ToInt32(row["AdvertID"]) : 0;
                        var title = row["Title"] != DBNull.Value ? row["Title"].ToString() : "Без названия";
                        var description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "Описание отсутствует";
                        var price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0m;
                        var sellerName = row["Username"] != DBNull.Value ? row["Username"].ToString() : "Неизвестный";
                        var sellerRating = row["SellerRating"] != DBNull.Value ? Convert.ToDecimal(row["SellerRating"]) : 0m;
                        var categoryName = row["CategoryName"] != DBNull.Value ? row["CategoryName"].ToString() : "Без категории";
                        var city = row["City"] != DBNull.Value ? row["City"].ToString() : "Не указано";
                        var favoritesCount = row["FavoritesCount"] != DBNull.Value ? Convert.ToInt32(row["FavoritesCount"]) : 0;
                        var sellerId = row["SellerID"] != DBNull.Value ? Convert.ToInt32(row["SellerID"]) : 0;

                        var tile = new AdvertTile(
                            advertId, title, description, price, sellerName,
                            sellerRating, categoryName, city,
                            favoritesCount, _currentUserId, sellerId);

                        tile.MessageClicked += (sender, e) =>
                        {
                            var chatForm = new ChatForm(_currentUserId, e);
                            chatForm.ShowDialog();
                        };

                        tile.ProfileClicked += (sender, sellerIdParam) =>
                        {
                            // Передаем sellerIdParam как ID профиля для просмотра
                            // и _currentUserId как ID просматривающего пользователя
                            var profileForm = new ProfileForm(sellerIdParam, _currentUserId);
                            profileForm.ShowDialog();
                        };

                        flowLayoutPanel1.Controls.Add(tile);
                    }
                    catch (Exception ex)
                    {
                        // Логируем ошибку для конкретного объявления, но продолжаем загрузку остальных
                        Console.WriteLine($"Ошибка при создании плитки объявления: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке объявлений: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileForm(_currentUserId, _currentUserId);
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

        private void btnChats_Click(object sender, EventArgs e)
        {
            var chatsForm = new ChatsListForm(_currentUserId);
            chatsForm.ShowDialog();
            LoadAdvertisements(); 
        }
    }
}