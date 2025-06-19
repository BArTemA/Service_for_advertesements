using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdvertServiceClient
{
    public partial class CreateAdForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;
        private readonly int? _advertId;
        private bool _isEditMode => _advertId.HasValue;

        public CreateAdForm(int userId, int? advertId = null)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            _advertId = advertId;

            InitializeForm();
            LoadCategories();
            LoadLocations();

            if (_isEditMode)
            {
                LoadAdvertData();
            }
        }

        private void InitializeForm()
        {
            this.Text = _isEditMode ? "Редактирование объявления" : "Создание объявления";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

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

            var cmbCategory = new ComboBox
            {
                Name = "cmbCategory",
                Location = new Point(150, 60),
                Size = new Size(400, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbCategory);

            // Локация
            var lblLocation = new Label
            {
                Text = "Местоположение:",
                Location = new Point(20, 100),
                AutoSize = true
            };
            this.Controls.Add(lblLocation);

            var cmbLocation = new ComboBox
            {
                Name = "cmbLocation",
                Location = new Point(150, 100),
                Size = new Size(400, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbLocation);

            // Цена
            var lblPrice = new Label
            {
                Text = "Цена:",
                Location = new Point(20, 140),
                AutoSize = true
            };
            this.Controls.Add(lblPrice);

            var numPrice = new NumericUpDown
            {
                Name = "numPrice",
                Location = new Point(150, 140),
                Size = new Size(150, 20),
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 1000000
            };
            this.Controls.Add(numPrice);

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
                Size = new Size(100, 30)
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            var btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(460, 400),
                Size = new Size(100, 30)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _dbHelper.ExecuteStoredProcedure("sp_GetAllCategories", null);
                var cmbCategory = (ComboBox)this.Controls["cmbCategory"];

                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLocations()
        {
            try
            {
                var locations = _dbHelper.ExecuteStoredProcedure("sp_GetAllLocations", null);
                var cmbLocation = (ComboBox)this.Controls["cmbLocation"];

                cmbLocation.DisplayMember = "City";
                cmbLocation.ValueMember = "LocationID";
                cmbLocation.DataSource = locations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки местоположений: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAdvertData()
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", _advertId.Value),
                    new SqlParameter("@IncrementViewCount", false)
                };

                var advertData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);

                if (advertData.Rows.Count > 0)
                {
                    var row = advertData.Rows[0];

                    // Заполняем поля данными
                    this.Controls["txtTitle"].Text = row["Title"].ToString();
                    this.Controls["txtDescription"].Text = row["Description"].ToString();
                    ((NumericUpDown)this.Controls["numPrice"]).Value = Convert.ToDecimal(row["Price"]);

                    // Устанавливаем категорию
                    var cmbCategory = (ComboBox)this.Controls["cmbCategory"];
                    cmbCategory.SelectedValue = row["CategoryID"];

                    // Устанавливаем локацию, если она есть
                    var cmbLocation = (ComboBox)this.Controls["cmbLocation"];
                    if (row["LocationID"] != DBNull.Value)
                    {
                        cmbLocation.SelectedValue = row["LocationID"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных объявления: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var price = ((NumericUpDown)this.Controls["numPrice"]).Value;
                var categoryId = (int)((ComboBox)this.Controls["cmbCategory"]).SelectedValue;
                var locationId = ((ComboBox)this.Controls["cmbLocation"]).SelectedValue;

                if (_isEditMode)
                {
                    // Редактирование существующего объявления
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@AdvertID", _advertId.Value),
                        new SqlParameter("@UserID", _userId),
                        new SqlParameter("@Title", title),
                        new SqlParameter("@Description", description),
                        new SqlParameter("@Price", price),
                        new SqlParameter("@CategoryID", categoryId),
                        new SqlParameter("@LocationID", locationId != null ? locationId : DBNull.Value)
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_UpdateAdvertisement", parameters);
                }
                else
                {
                    // Создание нового объявления
                    var outputParam = new SqlParameter("@AdvertID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", _userId),
                        new SqlParameter("@Title", title),
                        new SqlParameter("@Description", description),
                        new SqlParameter("@Price", price),
                        new SqlParameter("@CategoryID", categoryId),
                        new SqlParameter("@LocationID", locationId != null ? locationId : DBNull.Value),
                        outputParam
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_CreateAdvertisement", parameters);
                }

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

            if (((ComboBox)this.Controls["cmbCategory"]).SelectedIndex < 0)
            {
                MessageBox.Show("Выберите категорию", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (((NumericUpDown)this.Controls["numPrice"]).Value <= 0)
            {
                MessageBox.Show("Укажите корректную цену", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}