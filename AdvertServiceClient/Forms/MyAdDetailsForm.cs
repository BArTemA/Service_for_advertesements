using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class MyAdDetailsForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _advertId;
        private readonly int _userId;

        public MyAdDetailsForm(int advertId, int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _advertId = advertId;
            _userId = userId;
            LoadAdDetails();
        }

        private void LoadAdDetails()
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AdvertID", _advertId),
                new SqlParameter("@IncrementViewCount", 0)
            };

            try
            {
                var adData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);
                if (adData.Rows.Count > 0)
                {
                    var row = adData.Rows[0];
                    lblTitle.Text = row["Title"].ToString();
                    txtDescription.Text = row["Description"].ToString();
                    txtPrice.Text = row["Price"].ToString();
                    cmbStatus.Text = row["Status"].ToString();
                    lblViews.Text = $"Просмотров: {row["ViewCount"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке объявления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Укажите корректную цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", _advertId),
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@Description", txtDescription.Text),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Status", cmbStatus.Text)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_UpdateAdvertisement", parameters);

                MessageBox.Show("Объявление успешно обновлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении объявления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить это объявление?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@AdvertID", _advertId),
                        new SqlParameter("@UserID", _userId)
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_DeleteAdvertisement", parameters);

                    MessageBox.Show("Объявление успешно удалено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении объявления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}