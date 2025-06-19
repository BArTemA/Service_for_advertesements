using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ChangePasswordForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;

        public ChangePasswordForm(int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@OldPassword", txtOldPassword.Text),
                    new SqlParameter("@NewPassword", txtNewPassword.Text)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_ChangePassword", parameters);

                MessageBox.Show("Пароль успешно изменен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}