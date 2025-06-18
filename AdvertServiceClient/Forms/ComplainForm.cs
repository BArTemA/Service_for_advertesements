using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class ComplainForm : Form
    {
        private readonly int _userId;
        private readonly int _advertId;

        public ComplainForm(int userId, int advertId)
        {
            InitializeComponent();
            _userId = userId;
            _advertId = advertId;
        }

        private void ComplainForm_Load(object sender, EventArgs e)
        {
            // Load advertisement details
            using (var advertService = new AdvertService())
            {
                var advert = advertService.GetAdvertisementDetails(_advertId);
                if (advert.Rows.Count > 0)
                {
                    lblAdvertTitle.Text = advert.Rows[0]["Title"].ToString();
                    lblSeller.Text = advert.Rows[0]["SellerName"].ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Пожалуйста, укажите причину жалобы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return;
            }

            try
            {
                using (var complaintService = new ComplainService())
                {
                    int complaintId;
                    complaintService.CreateComplaint(
                        _userId,
                        _advertId,
                        txtReason.Text.Trim(),
                        out complaintId);

                    MessageBox.Show("Жалоба успешно отправлена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке жалобы: {ex.Message}", "Ошибка",
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