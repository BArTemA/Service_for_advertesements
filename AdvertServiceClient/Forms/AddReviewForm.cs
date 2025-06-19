using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvertServiceClient
{
    public partial class AddReviewForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _reviewerId;
        private readonly int _advertId;
        private int _reviewedUserId;

        public AddReviewForm(int reviewerId, int advertId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _reviewerId = reviewerId;
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
                    _reviewedUserId = (int)adData.Rows[0]["UserID"];
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
            if (ratingControl1.Value == 0)
            {
                MessageBox.Show("Пожалуйста, поставьте оценку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ReviewerID", _reviewerId),
                    new SqlParameter("@ReviewedUserID", _reviewedUserId),
                    new SqlParameter("@Rating", ratingControl1.Value),
                    new SqlParameter("@Comment", string.IsNullOrWhiteSpace(txtComment.Text) ? (object)DBNull.Value : txtComment.Text)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_AddReview", parameters);

                MessageBox.Show("Отзыв успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class RatingControl : UserControl
    {
        private int _value = 0;
        private readonly Label[] _stars;

        public RatingControl()
        {
            _stars = new Label[5];
            for (int i = 0; i < 5; i++)
            {
                _stars[i] = new Label
                {
                    Text = "☆", // Empty star
                    Font = new Font("Segoe UI", 16),
                    AutoSize = true,
                    Location = new Point(i * 25, 0),
                    Tag = i + 1
                };
                _stars[i].Click += Star_Click;
                Controls.Add(_stars[i]);
            }
            Height = _stars[0].Height;
            Width = _stars[4].Right;
        }

        private void Star_Click(object sender, EventArgs e)
        {
            Value = (int)((Label)sender).Tag;
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                for (int i = 0; i < 5; i++)
                {
                    _stars[i].Text = i < value ? "★" : "☆"; // Filled and empty stars
                }
                OnValueChanged(EventArgs.Empty);
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}