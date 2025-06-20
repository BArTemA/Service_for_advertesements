using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class MyAdsForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;
        private FlowLayoutPanel _flowLayoutPanel;
        private CheckBox _chkInactive;

        public MyAdsForm(int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            InitializeCustomComponents();
            LoadMyAds();
        }

        private void InitializeCustomComponents()
        {
            // Настройка основной формы
            this.Text = "Мои объявления";
            this.Size = new Size(900, 700); // Увеличим размер формы
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Панель заголовка
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.SteelBlue,
                Padding = new Padding(10)
            };

            // Заголовок
            var lblTitle = new Label
            {
                Text = "///////////////ОБЪЯВЛЕНИЯ///////////////////",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft
            };
            //Надпись
            var lblHelp = new Label
            {
                Text = "Для редактирования или удаления нажмите ПКМ",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Right,
                Height = 20,
                Width = 100,
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblTitle);

            // Панель инструментов
            var toolPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = SystemColors.Control,
                Padding = new Padding(5)
            };

            // Кнопка "Создать объявление"
            var btnCreate = new Button
            {
                Text = "Создать новое",
                Size = new Size(150, 30),
                Dock = DockStyle.Left,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Click += btnCreateAd_Click;
            toolPanel.Controls.Add(lblHelp);
            toolPanel.Controls.Add(btnCreate);
            

            // Чекбокс для показа неактивных объявлений
            _chkInactive = new CheckBox
            {
                Text = "Показать неактивные",
                AutoSize = true,
                Dock = DockStyle.Left,
                Margin = new Padding(20, 5, 0, 0)
            };
            _chkInactive.CheckedChanged += (s, e) => LoadMyAds(_chkInactive.Checked);
            toolPanel.Controls.Add(_chkInactive);

            // Добавляем панели на форму
            this.Controls.Add(toolPanel);
            this.Controls.Add(headerPanel);

            // Создаем FlowLayoutPanel для плиток объявлений
            _flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20, 120, 20, 20),
                BackColor = SystemColors.ControlLight
            };
            this.Controls.Add(_flowLayoutPanel);
        }

        private void LoadMyAds(bool includeInactive = false)
        {
            _flowLayoutPanel.Controls.Clear();

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@IncludeInactive", includeInactive)
                };

                var adsData = _dbHelper.ExecuteStoredProcedure("sp_GetUserAdvertisements", parameters);

                if (adsData == null || adsData.Rows.Count == 0)
                {
                    var lblNoAds = new Label
                    {
                        Text = "У вас нет объявлений.",
                        AutoSize = true,
                        Font = new Font("Microsoft Sans Serif", 12),
                        Margin = new Padding(20),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    _flowLayoutPanel.Controls.Add(lblNoAds);
                    return;
                }

                foreach (DataRow row in adsData.Rows)
                {
                    try
                    {
                        var advertId = row["AdvertID"] != DBNull.Value ? Convert.ToInt32(row["AdvertID"]) : 0;
                        var title = row["Title"] != DBNull.Value ? row["Title"].ToString() : "Без названия";
                        var description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "Нет описания";
                        var price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0m;
                        var status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Unknown";
                        var viewCount = row["ViewCount"] != DBNull.Value ? Convert.ToInt32(row["ViewCount"]) : 0;
                        var categoryName = row["CategoryName"] != DBNull.Value ? row["CategoryName"].ToString() : "Без категории";
                        var city = row["City"] != DBNull.Value ? row["City"].ToString() : "Не указано";
                        var messagesCount = row["MessagesCount"] != DBNull.Value ? Convert.ToInt32(row["MessagesCount"]) : 0;

                        var tile = new Panel
                        {
                            Width = 250,
                            Height = 260, // Увеличиваем высоту для добавления описания
                            Margin = new Padding(15),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = advertId
                        };

                        // Настройка внешнего вида плитки в зависимости от статуса
                        if (status == "Active")
                        {
                            tile.BackColor = Color.FromArgb(230, 255, 230);
                        }
                        else if (status == "Banned")
                        {
                            tile.BackColor = Color.FromArgb(255, 230, 230);
                        }
                        else
                        {
                            tile.BackColor = Color.FromArgb(240, 240, 240);
                        }

                        // Заголовок объявления
                        var lblTitle = new Label
                        {
                            Text = title,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            AutoSize = false,
                            Width = tile.Width - 20,
                            Height = 40,
                            Location = new Point(10, 10),
                            TextAlign = ContentAlignment.MiddleLeft
                        };
                        tile.Controls.Add(lblTitle);

                        // Описание объявления (добавляем новый Label)
                        var lblDescription = new Label
                        {
                            Text = description.Length > 50 ? description.Substring(0, 50) + "..." : description,
                            AutoSize = false,
                            Width = tile.Width - 20,
                            Height = 40,
                            Location = new Point(10, 60),
                            Font = new Font("Segoe UI", 8),
                            ForeColor = Color.Gray
                        };
                        tile.Controls.Add(lblDescription);

                        // Цена
                        var lblPrice = new Label
                        {
                            Text = $"{price:N2} ₽",
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            AutoSize = true,
                            Location = new Point(10, 100),
                            ForeColor = Color.DarkGreen
                        };
                        tile.Controls.Add(lblPrice);

                        // Категория и город
                        var lblDetails = new Label
                        {
                            Text = $"{categoryName}\n{city}",
                            AutoSize = false,
                            Width = tile.Width - 20,
                            Height = 40,
                            Location = new Point(10, 130),
                            Font = new Font("Segoe UI", 9)
                        };
                        tile.Controls.Add(lblDetails);

                        // Статистика
                        var lblStats = new Label
                        {
                            Text = $"Просмотры: {viewCount}\nСообщения: {messagesCount}",
                            AutoSize = false,
                            Width = tile.Width - 20,
                            Height = 40,
                            Location = new Point(10, 170),
                            Font = new Font("Segoe UI", 8)
                        };
                        tile.Controls.Add(lblStats);

                        // Статус
                        var lblStatus = new Label
                        {
                            Text = $"Статус: {status}",
                            AutoSize = false,
                            Width = tile.Width - 20,
                            Height = 20,
                            Location = new Point(10, 210),
                            Font = new Font("Segoe UI", 8, FontStyle.Italic)
                        };
                        tile.Controls.Add(lblStatus);

                        // Контекстное меню для плитки
                        var contextMenu = new ContextMenuStrip();

                        var editItem = new ToolStripMenuItem("Редактировать");
                        editItem.Click += (s, e) => EditAdvert(advertId);
                        contextMenu.Items.Add(editItem);

                        var deleteItem = new ToolStripMenuItem("Удалить");
                        deleteItem.Click += (s, e) => DeleteAdvert(advertId);
                        contextMenu.Items.Add(deleteItem);

                        tile.ContextMenuStrip = contextMenu;
                        tile.DoubleClick += (s, e) => EditAdvert(advertId);

                        _flowLayoutPanel.Controls.Add(tile);
                    }
                    catch (Exception ex)
                    {
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

        private void EditAdvert(int advertId)
        {
            var editForm = new EditAdForm(_userId, advertId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadMyAds();
            }
        }

        private void DeleteAdvert(int advertId)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить это объявление?", "Подтверждение",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@AdvertID", advertId),
                        new SqlParameter("@UserID", _userId)
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_DeleteAdvertisement", parameters);
                    LoadMyAds();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении объявления: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangeAdvertStatus(int advertId, string newStatus)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", advertId),
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@NewStatus", newStatus)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_ChangeAdStatus", parameters);
                LoadMyAds();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении статуса объявления: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateAd_Click(object sender, EventArgs e)
        {
            var createAdForm = new CreateAdForm(_userId);
            if (createAdForm.ShowDialog() == DialogResult.OK)
            {
                LoadMyAds();
            }
        }
    }
}