using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ProcessComplaintForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;
        private readonly int _advertId;
        private readonly int _moderatorId;

        public ProcessComplaintForm(int userId, int advertId, int moderatorId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            _advertId = advertId;
            _moderatorId = moderatorId;
            LoadComplaintInfo();
        }

        private void LoadComplaintInfo()
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
                    var row = adData.Rows[0];
                    lblAdTitle.Text = row["Title"].ToString();
                    lblAdDescription.Text = row["Description"].ToString();
                    lblAdSeller.Text = $"Продавец: {row["Username"]} (рейтинг: {row["SellerRating"]})";
                    lblAdStatus.Text = $"Статус: {row["Status"]}";
                }

                // Загружаем текст жалобы
                var complaintParams = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@AdvertID", _advertId)
                };

                var complaintData = _dbHelper.ExecuteStoredProcedure("sp_GetComplaintDetails", complaintParams);
                if (complaintData.Rows.Count > 0)
                {
                    txtComplaintReason.Text = complaintData.Rows[0]["ReasonText"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке информации о жалобе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ProcessComplaint("Resolved", chkBanAd.Checked, chkBanUser.Checked);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            ProcessComplaint("Rejected", false, false);
        }

        private void ProcessComplaint(string status, bool banAd, bool banUser)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@AdvertID", _advertId),
                    new SqlParameter("@UserID", _userId),
                    new SqlParameter("@ModeratorID", _moderatorId),
                    new SqlParameter("@NewStatus", status),
                    new SqlParameter("@ResolutionComment", txtResolutionComment.Text),
                    new SqlParameter("@BanAdvertisement", banAd),
                    new SqlParameter("@BanUser", banUser)
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_ProcessComplaint", parameters);

                MessageBox.Show($"Жалоба успешно обработана (статус: {status})", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке жалобы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}