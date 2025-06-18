using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class EditAdvertForm : Form
    {
        private readonly User _currentUser;
        private readonly int _advertId;
        private DataRow _advertData;
        private DataTable _categories;
        private DataTable _locations;

        public EditAdvertForm(User currentUser, int advertId)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _advertId = advertId;
        }

        private void EditAdvertForm_Load(object sender, EventArgs e)
        {
            // Load advertisement data
            using (var advertService = new AdvertService())
            {
                _advertData = advertService.GetAdvertisementDetails(_advertId).Rows[0];
                LoadCategories();
                LoadLocations();
                DisplayAdvertData();
            }
        }

        private void LoadCategories()
        {
            using (var categoryService = new CategoryService())
            {
                _categories = categoryService.GetAllCategories();
                cmbCategory.DataSource = _categories;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryID";
            }
        }

        private void LoadLocations()
        {
            using (var locationService = new LocationService())
            {
                _locations = locationService.GetAllLocations();
                _locations.Rows.Add(DBNull.Value, "Не указано", "", ""); // Add null option
                cmbLocation.DataSource = _locations;
                cmbLocation.DisplayMember = "City";
                cmbLocation.ValueMember = "LocationID";
            }
        }

        private void DisplayAdvertData()
        {
            txtTitle.Text = _advertData["Title"].ToString();
            txtDescription.Text = _advertData["Description"].ToString();
            txtPrice.Text = _advertData["Price"].ToString();

            // Set category
            var categoryId = (int)_advertData["CategoryID"];
            foreach (DataRow row in _categories.Rows)
            {
                if ((int)row["CategoryID"] == categoryId)
                {
                    cmbCategory.SelectedItem = row;
                    break;
                }
            }

            // Set location
            var locationId = _advertData["LocationID"];
            if (locationId != DBNull.Value)
            {
                foreach (DataRow row in _locations.Rows)
                {
                    if (row["LocationID"] != DBNull.Value && (int)row["LocationID"] == (int)locationId)
                    {
                        cmbLocation.SelectedItem = row;
                        break;
                    }
                }
            }
            else
            {
                cmbLocation.SelectedIndex = cmbLocation.Items.Count - 1; // Select "Не указано"
            }

            // Set expiration date
            var expirationDate = _advertData["ExpirationDate"];
            if (expirationDate != DBNull.Value)
            {
                dtpExpirationDate.Value = (DateTime)expirationDate;
                chkSetExpiration.Checked = true;
            }
            else
            {
                dtpExpirationDate.Value = DateTime.Now.AddDays(30);
                chkSetExpiration.Checked = false;
            }
        }

        private void chkSetExpiration_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpirationDate.Enabled = chkSetExpiration.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var advertService = new AdvertService())
                {
                    // Prepare parameters
                    var title = txtTitle.Text.Trim();
                    var description = txtDescription.Text.Trim();
                    var price = decimal.Parse(txtPrice.Text);
                    var categoryId = (int)cmbCategory.SelectedValue;
                    var locationId = cmbLocation.SelectedValue == DBNull.Value ? null : (int?)cmbLocation.SelectedValue;
                    var expirationDate = chkSetExpiration.Checked ? (DateTime?)dtpExpirationDate.Value : null;

                    // Update advertisement
                    advertService.UpdateAdvertisement(
                        _advertId,
                        _currentUser.UserID,
                        title,
                        description,
                        price,
                        categoryId,
                        locationId,
                        expirationDate
                    );

                    MessageBox.Show("Объявление успешно обновлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении объявления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите заголовок объявления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание объявления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену (положительное число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }

            if (chkSetExpiration.Checked && dtpExpirationDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Дата окончания должна быть в будущем", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpirationDate.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}