using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ProfileForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId; // ID пользователя, чей профиль просматривается
        private readonly int _viewerId; // ID пользователя, который просматривает профиль
        private Panel _reviewsPanel;

        public ProfileForm(int userId, int viewerId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            _viewerId = viewerId;

            InitializeReviewsPanel();
            LoadUserProfile();
            LoadUserReviews();

            // Скрываем кнопки редактирования, если это не свой профиль
            btnUpdateProfile.Visible = (_userId == _viewerId);
            btnChangePassword.Visible = (_userId == _viewerId);
        }

        private void InitializeReviewsPanel()
        {
            // Создаем Panel для отзывов
            _reviewsPanel = new Panel
            {
                AutoSize = true,
                Location = new Point(20, 250),
                Size = new Size(625, 350),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Controls.Add(_reviewsPanel);

            // Добавляем заголовок
            Label reviewsLabel = new Label
            {
                Text = "Отзывы о пользователе:",
                Location = new Point(20, 220),
                AutoSize = true,
                Font = new Font(Font, FontStyle.Bold)
            };
            Controls.Add(reviewsLabel);

            // Кнопка "Написать отзыв"
            Button btnAddReview = new Button
            {
                Text = "Написать отзыв",
                Location = new Point(200, 220),
                Size = new Size(120, 25),
                Enabled = (_viewerId != _userId) // Доступна только для чужих профилей
            };
            btnAddReview.Click += BtnAddReview_Click;
            Controls.Add(btnAddReview);
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

        private void LoadUserReviews()
        {
            _reviewsPanel.Controls.Clear();
            _reviewsPanel.AutoScroll = true;

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@PageNumber", 1),
                    new SqlParameter("@PageSize", 10)
                };

                DataTable reviewsData = _dbHelper.ExecuteStoredProcedure("sp_GetUserReviews", parameters);

                if (reviewsData == null || reviewsData.Rows.Count == 0)
                {
                    ShowNoReviewsMessage();
                    return;
                }

                DisplayReviews(reviewsData);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);

                // Дополнительное логирование для диагностики
                Console.WriteLine($"Ошибка при загрузке отзывов: {ex}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Внутреннее исключение: {ex.InnerException}");
                }
            }
        }

        private void ShowNoReviewsMessage()
        {
            Label message = new Label
            {
                Text = "Пока нет отзывов",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            _reviewsPanel.Controls.Add(message);
        }

        private void ShowErrorMessage(Exception ex)
        {
            Label error = new Label
            {
                Text = $"Ошибка загрузки отзывов: {ex.Message}",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Red
            };
            _reviewsPanel.Controls.Add(error);
        }

        private void DisplayReviews(DataTable reviewsData)
        {
            int yPos = 10;

            foreach (DataRow row in reviewsData.Rows)
            {
                try
                {
                    // Безопасное получение данных
                    int reviewerId = Convert.ToInt32(row["ReviewerID"]);
                    string reviewerName = row["ReviewerName"]?.ToString() ?? "Аноним";
                    string comment = row["Comment"]?.ToString() ?? "Без комментария";
                    DateTime reviewDate = row["ReviewDate"] != DBNull.Value ? (DateTime)row["ReviewDate"] : DateTime.Now;
                    int rating = 0;

                    if (row["Rating"] != DBNull.Value)
                    {
                        if (!int.TryParse(row["Rating"].ToString(), out rating))
                        {
                            rating = Convert.ToInt32(row["Rating"]);
                        }
                    }

                    Panel reviewPanel = new Panel
                    {
                        AutoScroll = true,
                        BackColor = Color.WhiteSmoke,
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(_reviewsPanel.Width - 25, 120),
                        Location = new Point(10, yPos),
                        Padding = new Padding(10),
                        Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                    };

                    Label authorLabel = new Label
                    {
                        Text = reviewerName,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    string ratingStars = new string('★', rating);
                    Label ratingLabel = new Label
                    {
                        Text = ratingStars,
                        ForeColor = Color.Goldenrod,
                        Location = new Point(10, 35),
                        AutoSize = true
                    };

                    TextBox commentBox = new TextBox
                    {
                        Text = comment,
                        Multiline = true,
                        ReadOnly = true,
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.WhiteSmoke,
                        Location = new Point(10, 60),
                        Size = new Size(reviewPanel.Width - 30, 50),
                        ScrollBars = ScrollBars.Vertical,
                        TabStop = false
                    };

                    Label dateLabel = new Label
                    {
                        Text = reviewDate.ToString("dd.MM.yyyy"),
                        ForeColor = Color.Gray,
                        Location = new Point(reviewPanel.Width - 100, 10),
                        AutoSize = true
                    };

                    // Добавляем кнопку удаления, если это отзыв текущего пользователя или это его профиль
                    if (reviewerId == _viewerId)
                    {
                        Button btnDeleteReview = new Button
                        {
                            Text = "Удалить",
                            Tag = new Tuple<int, int>(reviewerId, _userId), // Сохраняем ID рецензента и пользователя
                            Location = new Point(reviewPanel.Width - 100, 35),
                            Size = new Size(80, 25),
                            BackColor = Color.LightCoral
                        };
                        btnDeleteReview.Click += BtnDeleteReview_Click;
                        reviewPanel.Controls.Add(btnDeleteReview);
                    }

                    reviewPanel.Controls.Add(authorLabel);
                    reviewPanel.Controls.Add(ratingLabel);
                    reviewPanel.Controls.Add(commentBox);
                    reviewPanel.Controls.Add(dateLabel);

                    _reviewsPanel.Controls.Add(reviewPanel);
                    yPos += reviewPanel.Height + 10;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обработке отзыва: {ex}");
                }
            }
        }

        private void BtnDeleteReview_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот отзыв?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Button btn = (Button)sender;
                    var ids = (Tuple<int, int>)btn.Tag;
                    int reviewerId = ids.Item1;
                    int reviewedUserId = ids.Item2;

                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@ReviewerID", reviewerId),
                        new SqlParameter("@ReviewedUserID", reviewedUserId),
                        new SqlParameter("@IsModerator", _viewerId == reviewedUserId) // Если это владелец профиля, считаем его модератором для своих отзывов
                    };

                    _dbHelper.ExecuteStoredProcedure("sp_DeleteReview", parameters);

                    // Обновляем список отзывов и рейтинг
                    LoadUserReviews();
                    LoadUserProfile();
                    MessageBox.Show("Отзыв успешно удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAddReview_Click(object sender, EventArgs e)
        {
            if (_viewerId == _userId)
            {
                MessageBox.Show("Нельзя оставить отзыв самому себе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reviewForm = new ReviewForm(_viewerId, _userId);
            if (reviewForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserReviews(); // Обновляем список отзывов
                LoadUserProfile(); // Обновляем рейтинг пользователя
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (_viewerId != _userId) return; // Дополнительная защита

            var changePasswordForm = new ChangePasswordForm(_userId);
            changePasswordForm.ShowDialog();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (_viewerId != _userId) return; // Дополнительная защита

            var updateProfileForm = new UpdateProfileForm(_userId);
            if (updateProfileForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserProfile();
            }
        }
    }
}