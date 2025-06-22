using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvertServiceClient
{
    public partial class ReviewForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _reviewerId;
        private readonly int _reviewedUserId;

        public ReviewForm(int reviewerId, int reviewedUserId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _reviewerId = reviewerId;
            _reviewedUserId = reviewedUserId;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text) && numRating.Value == 0)
            {
                MessageBox.Show("Пожалуйста, укажите рейтинг или комментарий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ReviewerID", _reviewerId),
                    new SqlParameter("@ReviewedUserID", _reviewedUserId),
                    new SqlParameter("@Rating", numRating.Value),
                    new SqlParameter("@Comment", txtComment.Text)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_AddReview", parameters);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Error executing stored procedure sp_AddReview: Можно оставлять отзыв только после взаимодействия через сообщения")
                {
                    MessageBox.Show($"Вы не можете оставить отзыв человеку, которому Вы не написали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else { 
                MessageBox.Show($"Ошибка при сохранении отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}