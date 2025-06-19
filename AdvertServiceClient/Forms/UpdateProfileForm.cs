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
            LoadCurrentProfile();
        }

        private void LoadCurrentProfile()
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
                    txtLocationId.Text = row["LocationID"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке профиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text),
                    new SqlParameter("@LocationID", string.IsNullOrWhiteSpace(txtLocationId.Text) ? (object)DBNull.Value : int.Parse(txtLocationId.Text))
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_UpdateUserProfile", parameters);

                MessageBox.Show("Профиль успешно обновлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении профиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}