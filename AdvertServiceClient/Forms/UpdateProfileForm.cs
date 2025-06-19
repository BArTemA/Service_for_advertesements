using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class UpdateProfileForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;

        public UpdateProfileForm(int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            LoadLocations();
            LoadUserData();
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
                    string zipCode = row["ZipCode"].ToString();
                    string region = row["Region"] != DBNull.Value ? row["Region"].ToString() : "";

                    string displayText = !string.IsNullOrEmpty(region)
                        ? $"{city}, {region}, {zipCode}"
                        : $"{city}, {zipCode}";

                    cmbLocation.Items.Add(new ComboBoxItem(displayText, row["LocationID"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке местоположений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserData()
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
                    txtEmail.Text = row["Email"].ToString();
                    txtPhone.Text = row["Phone"]?.ToString();

                    // Безопасная проверка наличия столбца LocationID
                    if (userData.Columns.Contains("LocationID") && row["LocationID"] != DBNull.Value)
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
                        cmbLocation.SelectedIndex = 0; // Устанавливаем "Не указано"
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных профиля: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email является обязательным полем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранное местоположение
            object locationId = (cmbLocation.SelectedItem as ComboBoxItem)?.Value ?? DBNull.Value;

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _userId),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text.Trim()),
                new SqlParameter("@LocationID", locationId)
            };

            try
            {
                _dbHelper.ExecuteStoredProcedureNonQuery("sp_UpdateUserProfile", parameters);
                MessageBox.Show("Профиль успешно обновлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении профиля: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}