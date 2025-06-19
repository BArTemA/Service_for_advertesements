using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class CreateAdForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;

        public CreateAdForm(int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _dbHelper.ExecuteStoredProcedure("sp_SearchCategories", new SqlParameter[0]);
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке категорий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Укажите корректную цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", _userId),
                new SqlParameter("@Title", txtTitle.Text),
                new SqlParameter("@Description", txtDescription.Text),
                new SqlParameter("@Price", price),
                new SqlParameter("@CategoryID", cmbCategory.SelectedValue),
                new SqlParameter("@LocationID", string.IsNullOrWhiteSpace(txtLocationId.Text) ? (object)DBNull.Value : int.Parse(txtLocationId.Text)),
                new SqlParameter("@ExpirationDate", dtpExpiration.Checked ? (object)dtpExpiration.Value : DBNull.Value),
                new SqlParameter("@AdvertID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                _dbHelper.ExecuteStoredProcedureNonQuery("sp_CreateAdvertisement", parameters);
                int advertId = (int)parameters[7].Value;

                MessageBox.Show($"Объявление успешно создано! ID: {advertId}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании объявления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}