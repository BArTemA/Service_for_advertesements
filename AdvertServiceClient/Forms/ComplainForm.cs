using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ComplainForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;
        private readonly int _advertId;

        public ComplainForm(int userId, int advertId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            _advertId = advertId;
            LoadAdInfo();
        }

        private void LoadAdInfo()
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", _advertId),
                    new SqlParameter("@IncrementViewCount", 0)
                };

                var adData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);
                if (adData.Rows.Count > 0)
                {
                    lblAdTitle.Text = adData.Rows[0]["Title"].ToString();
                    lblSeller.Text = $"Продавец: {adData.Rows[0]["Username"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке информации об объявлении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Пожалуйста, укажите причину жалобы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@AdvertID", _advertId),
                    new SqlParameter("@ReasonText", txtReason.Text),
                    new SqlParameter("@ComplaintID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_CreateComplaint", parameters);

                MessageBox.Show("Жалоба успешно отправлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке жалобы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}