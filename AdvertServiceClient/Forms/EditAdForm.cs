using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdvertServiceClient
{
    public partial class EditAdForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;
        private readonly int _advertId;
        private ComboBox _cmbCategory;
        private ComboBox _cmbLocation;
        private NumericUpDown _numPrice;

        public EditAdForm(int userId, int advertId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            _advertId = advertId;

            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            // Настройка формы
            this.Text = "Редактирование объявления";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Название
            var lblTitle = new Label
            {
                Text = "Название:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            var txtTitle = new TextBox
            {
                Name = "txtTitle",
                Location = new Point(150, 20),
                Size = new Size(400, 20),
                MaxLength = 200
            };
            this.Controls.Add(txtTitle);

            // Категория
            var lblCategory = new Label
            {
                Text = "Категория:",
                Location = new Point(20, 60),
                AutoSize = true
            };
            this.Controls.Add(lblCategory);

            _cmbCategory = new ComboBox
            {
                Name = "cmbCategory",
                Location = new Point(150, 60),
                Size = new Size(400, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(_cmbCategory);

            // Локация
            var lblLocation = new Label
            {
                Text = "Местоположение:",
                Location = new Point(20, 100),
                AutoSize = true
            };
            this.Controls.Add(lblLocation);

            _cmbLocation = new ComboBox
            {
                Name = "cmbLocation",
                Location = new Point(150, 100),
                Size = new Size(400, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cmbLocation.Items.Add(new ComboBoxItem("Не указано", null));
            this.Controls.Add(_cmbLocation);

            // Цена
            var lblPrice = new Label
            {
                Text = "Цена:",
                Location = new Point(20, 140),
                AutoSize = true
            };
            this.Controls.Add(lblPrice);

            _numPrice = new NumericUpDown
            {
                Name = "numPrice",
                Location = new Point(150, 140),
                Size = new Size(200, 20),
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = decimal.MaxValue // Увеличиваем максимальное значение
            };
            this.Controls.Add(_numPrice);

            // Описание
            var lblDescription = new Label
            {
                Text = "Описание:",
                Location = new Point(20, 180),
                AutoSize = true
            };
            this.Controls.Add(lblDescription);

            var txtDescription = new TextBox
            {
                Name = "txtDescription",
                Location = new Point(150, 180),
                Size = new Size(400, 100),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                MaxLength = 4000
            };
            this.Controls.Add(txtDescription);

            // Кнопки
            var btnSave = new Button
            {
                Text = "Сохранить",
                Location = new Point(350, 400),
                Size = new Size(100, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            var btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(460, 400),
                Size = new Size(100, 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }

        private void LoadData()
        {
            try
            {
                LoadCategories();
                LoadLocations();
                LoadAdvertData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _dbHelper.ExecuteStoredProcedure("sp_GetAllCategories", null);

                if (categories == null || categories.Rows.Count == 0)
                {
                    throw new Exception("Не удалось загрузить категории или список пуст");
                }

                _cmbCategory.Items.Clear();

                foreach (DataRow row in categories.Rows)
                {
                    if (row["Name"] == null || row["CategoryID"] == null)
                        continue;

                    _cmbCategory.Items.Add(new ComboBoxItem(
                        row["Name"].ToString(),
                        row["CategoryID"]
                    ));
                }

                if (_cmbCategory.Items.Count == 0)
                {
                    throw new Exception("Нет доступных категорий для отображения");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки категорий: {ex.Message}");
            }
        }

        private void LoadLocations()
        {
            try
            {
                var locations = _dbHelper.ExecuteStoredProcedure("sp_GetAllLocations", null);

                if (locations == null || locations.Rows.Count == 0)
                {
                    throw new Exception("Не удалось загрузить местоположения или список пуст");
                }

                _cmbLocation.Items.Clear();
                _cmbLocation.Items.Add(new ComboBoxItem("Не указано", null));

                foreach (DataRow row in locations.Rows)
                {
                    if (row["City"] == null || row["ZipCode"] == null || row["LocationID"] == null)
                        continue;

                    string city = row["City"].ToString();
                    string zipCode = row["ZipCode"].ToString();
                    string region = row["Region"] != DBNull.Value ? row["Region"].ToString() : "";

                    string displayText = !string.IsNullOrEmpty(region)
                        ? $"{city}, {region}, {zipCode}"
                        : $"{city}, {zipCode}";

                    _cmbLocation.Items.Add(new ComboBoxItem(displayText, row["LocationID"]));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки местоположений: {ex.Message}");
            }
        }

        private void LoadAdvertData()
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", _advertId),
                    new SqlParameter("@IncrementViewCount", false)
                };

                var advertData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);

                if (advertData == null || advertData.Rows.Count == 0)
                {
                    throw new Exception("Не удалось загрузить данные объявления");
                }

                var row = advertData.Rows[0];

                // Заполняем поля данными
                this.Controls["txtTitle"].Text = row["Title"].ToString();
                this.Controls["txtDescription"].Text = row["Description"].ToString();

                // Безопасное преобразование цены
                if (decimal.TryParse(row["Price"].ToString(), out decimal price))
                {
                    _numPrice.Value = price;
                }
                else
                {
                    _numPrice.Value = 0;
                }

                // Устанавливаем категорию
                if (row["CategoryID"] != DBNull.Value)
                {
                    foreach (ComboBoxItem item in _cmbCategory.Items)
                    {
                        if (item.Value.ToString() == row["CategoryID"].ToString())
                        {
                            _cmbCategory.SelectedItem = item;
                            break;
                        }
                    }
                }

                // Устанавливаем локацию
                if (row["LocationID"] != DBNull.Value)
                {
                    foreach (ComboBoxItem item in _cmbLocation.Items)
                    {
                        if (item.Value != null && item.Value.ToString() == row["LocationID"].ToString())
                        {
                            _cmbLocation.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    _cmbLocation.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки данных объявления: {ex.Message}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var title = this.Controls["txtTitle"].Text;
                var description = this.Controls["txtDescription"].Text;
                var price = _numPrice.Value;
                var categoryId = ((ComboBoxItem)_cmbCategory.SelectedItem).Value;
                var locationItem = (ComboBoxItem)_cmbLocation.SelectedItem;
                var locationId = locationItem.Value;

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", _advertId),
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@Title", title),
                    new SqlParameter("@Description", description),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@CategoryID", categoryId),
                    new SqlParameter("@LocationID", locationId ?? DBNull.Value)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_UpdateAdvertisement", parameters);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения объявления: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(this.Controls["txtTitle"].Text))
            {
                MessageBox.Show("Введите название объявления", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите категорию", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_numPrice.Value <= 0)
            {
                MessageBox.Show("Укажите корректную цену", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}