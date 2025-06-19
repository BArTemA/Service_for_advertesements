using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class EditAdForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;
        private readonly int _advertId;
        private bool _isNewAd;

        public EditAdForm(int userId, int advertId = 0)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            _advertId = advertId;
            _isNewAd = advertId == 0;

            LoadCategories();
            LoadLocations();

            if (!_isNewAd)
            {
                LoadAdvertData();
            }
        }

        private void LoadCategories()
        {
            try
            {
                SqlParameter[] parameters = Array.Empty<SqlParameter>();
                DataTable categories = _dbHelper.ExecuteStoredProcedure("sp_GetAllCategories", parameters);

                cmbCategory.Items.Clear();
                cmbCategory.Items.Add(new ComboBoxItem("(Не указано)", null));

                foreach (DataRow row in categories.Rows)
                {
                    string name = row["Name"].ToString();
                    cmbCategory.Items.Add(new ComboBoxItem(name, row["CategoryID"]));
                }

                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке категорий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLocations()
        {
            try
            {
                SqlParameter[] parameters = Array.Empty<SqlParameter>();
                DataTable locations = _dbHelper.ExecuteStoredProcedure("sp_GetAllLocations", parameters);

                cmbLocation.Items.Clear();
                cmbLocation.Items.Add(new ComboBoxItem("Не указано", null));

                foreach (DataRow row in locations.Rows)
                {
                    string city = row["City"].ToString();
                    string ZipCode = row["ZipCode"].ToString();
                    string region = row["Region"] != DBNull.Value ? row["Region"].ToString() : "";

                    string displayText = !string.IsNullOrEmpty(region)
                        ? $"{city}, {region}, {ZipCode}"
                        : $"{city}, {ZipCode}";

                    cmbLocation.Items.Add(new ComboBoxItem(displayText, row["LocationID"]));
                }

                cmbLocation.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке местоположений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (advertData != null && advertData.Rows.Count > 0)
                {
                    var row = advertData.Rows[0];

                    txtTitle.Text = row["Title"].ToString();
                    txtDescription.Text = row["Description"].ToString();

                    decimal price;
                    if (decimal.TryParse(row["Price"].ToString(), out price))
                    {
                        numPrice.Value = price;
                    }

                    // Set category
                    foreach (ComboBoxItem item in cmbCategory.Items)
                    {
                        if (item.Value != null && Convert.ToInt32(item.Value) == Convert.ToInt32(row["CategoryID"]))
                        {
                            cmbCategory.SelectedItem = item;
                            break;
                        }
                    }

                    // Set location
                    if (row["LocationID"] != DBNull.Value)
                    {
                        int locationId = Convert.ToInt32(row["LocationID"]);
                        foreach (ComboBoxItem item in cmbLocation.Items)
                        {
                            if (item.Value != null && Convert.ToInt32(item.Value) == locationId)
                            {
                                cmbLocation.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cmbLocation.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных объявления: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Введите название объявления", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get selected category - fixed version
                if (cmbCategory.SelectedItem == null ||
                    !(cmbCategory.SelectedItem is ComboBoxItem selectedCategory) ||
                    selectedCategory.Value == null)
                {
                    MessageBox.Show("Выберите категорию", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int categoryId = Convert.ToInt32(selectedCategory.Value);

                // Получаем ID локации (может быть null)
                int? locationId = null;
                if (cmbLocation.SelectedItem != null &&
                    cmbLocation.SelectedItem is ComboBoxItem selectedLocation &&
                    selectedLocation.Value != null)
                {
                    locationId = Convert.ToInt32(selectedLocation.Value);
                }

                // Сохранение данных
                if (_isNewAd)
                {
                    CreateNewAdvert(txtTitle.Text, txtDescription.Text, numPrice.Value,
                                   categoryId, locationId);
                }
                else
                {
                    UpdateAdvert(txtTitle.Text, txtDescription.Text, numPrice.Value,
                                categoryId, locationId);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении объявления: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewAdvert(string title, string description, decimal price, int categoryId, int? locationId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _userId),
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@LocationID", locationId ?? (object)DBNull.Value),
                new SqlParameter("@AdvertID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            _dbHelper.ExecuteStoredProcedureNonQuery("sp_CreateAdvertisement", parameters);
        }

        private void UpdateAdvert(string title, string description, decimal price, int categoryId, int? locationId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AdvertID", _advertId),
                new SqlParameter("@UserID", _userId),
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@LocationID", locationId ?? (object)DBNull.Value)
            };

            _dbHelper.ExecuteStoredProcedureNonQuery("sp_UpdateAdvertisement", parameters);
        }
    }
}