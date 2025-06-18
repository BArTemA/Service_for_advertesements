using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class AdvertForm : Form
    {
        private readonly User _currentUser;
        private readonly int _advertId;
        private DataRow _advertData;

        public AdvertForm(User currentUser, int advertId)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _advertId = advertId;
        }

        private void AdvertForm_Load(object sender, EventArgs e)
        {
            using (var advertService = new AdvertService())
            {
                var advertTable = advertService.GetAdvertisementDetails(_advertId, true);
                if (advertTable.Rows.Count == 0)
                {
                    MessageBox.Show("Объявление не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                _advertData = advertTable.Rows[0];
                DisplayAdvertData();
            }
        }

        private void DisplayAdvertData()
        {
            txtTitle.Text = _advertData["Title"].ToString();
            txtDescription.Text = _advertData["Description"].ToString();
            txtPrice.Text = _advertData["Price"].ToString();
            txtCategory.Text = _advertData["CategoryName"].ToString();
            txtSeller.Text = _advertData["SellerName"].ToString();
            txtRating.Text = _advertData["SellerRating"].ToString();
            txtLocation.Text = $"{_advertData["City"]}, {_advertData["Region"]}, {_advertData["Country"]}";
            txtViews.Text = _advertData["ViewCount"].ToString();
            txtFavorites.Text = _advertData["FavoritesCount"].ToString();
            txtStatus.Text = _advertData["AdvertStatus"].ToString();
            txtPublicationDate.Text = Convert.ToDateTime(_advertData["PublicationDate"]).ToString("g");

            var expirationDate = _advertData["ExpirationDate"];
            if (expirationDate != DBNull.Value)
            {
                txtExpirationDate.Text = Convert.ToDateTime(expirationDate).ToString("g");
            }

            // Проверяем, является ли текущий пользователь владельцем объявления
            var sellerId = (int)_advertData["UserID"];
            btnEdit.Visible = btnDelete.Visible = _currentUser.UserID == sellerId || _currentUser.IsModerator;
            btnComplain.Visible = _currentUser.UserID != sellerId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editForm = new EditAdvertForm(_currentUser, _advertId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем данные объявления
                using (var advertService = new AdvertService())
                {
                    var advertTable = advertService.GetAdvertisementDetails(_advertId);
                    if (advertTable.Rows.Count > 0)
                    {
                        _advertData = advertTable.Rows[0];
                        DisplayAdvertData();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить это объявление?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var advertService = new AdvertService())
                {
                    advertService.DeleteAdvertisement(_advertId, _currentUser.UserID);
                    MessageBox.Show("Объявление удалено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnComplain_Click(object sender, EventArgs e)
        {
            var complainForm = new ComplainForm(_currentUser.UserID, _advertId);
            complainForm.ShowDialog();
        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {
            var sellerId = (int)_advertData["UserID"];
            if (_currentUser.UserID == sellerId)
            {
                MessageBox.Show("Нельзя начать чат с самим собой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var chatService = new ChatService())
            {
                int chatId = chatService.CreateChat(_advertId, sellerId, _currentUser.UserID);
                var chatForm = new ChatForm(_currentUser, chatId);
                chatForm.ShowDialog();
            }
        }
    }
}