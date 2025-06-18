using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            Text = $"Сервис объявлений - {(_currentUser.IsModerator ? "Модератор" : "Пользователь")}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAdvertisements();
        }

        private void LoadAdvertisements()
        {
            using (var advertService = new AdvertService())
            {
                var adverts = advertService.SearchAdvertisements();
                dgvAdvertisements.DataSource = adverts;
            }
        }

        private void btnViewAdvert_Click(object sender, EventArgs e)
        {
            if (dgvAdvertisements.SelectedRows.Count == 0) return;

            var advertId = (int)dgvAdvertisements.SelectedRows[0].Cells["AdvertID"].Value;
            var advertForm = new AdvertForm(_currentUser, advertId);
            advertForm.ShowDialog();
            LoadAdvertisements();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            var profileForm = new UserProfileForm(_currentUser);
            profileForm.ShowDialog();
        }

        private void btnMyAdverts_Click(object sender, EventArgs e)
        {
            var myAdvertsForm = new UserAdvertsForm(_currentUser);
            myAdvertsForm.ShowDialog();
        }

        private void btnMyChats_Click(object sender, EventArgs e)
        {
            var chatsForm = new UserChatsForm(_currentUser);
            chatsForm.ShowDialog();
        }
    }
}