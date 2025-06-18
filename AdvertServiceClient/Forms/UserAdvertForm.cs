using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class UserAdvertsForm : Form
    {
        private readonly User _user;
        private bool _includeInactive = false;

        public UserAdvertsForm(User user)
        {
            InitializeComponent();
            _user = user;
            Text = $"Объявления пользователя: {user.Username}";
        }

        private void UserAdvertsForm_Load(object sender, EventArgs e)
        {
            LoadAdvertisements();
        }

        private void LoadAdvertisements()
        {
            using (var advertService = new AdvertService())
            {
                dgvAdvertisements.DataSource = advertService.GetUserAdvertisements(
                    _user.UserID,
                    _includeInactive);
            }
        }

        private void btnViewAdvert_Click(object sender, EventArgs e)
        {
            if (dgvAdvertisements.SelectedRows.Count == 0) return;

            var advertId = (int)dgvAdvertisements.SelectedRows[0].Cells["AdvertID"].Value;
            var advertForm = new AdvertForm(_user, advertId);
            advertForm.ShowDialog();
            LoadAdvertisements();
        }

        private void btnToggleInactive_Click(object sender, EventArgs e)
        {
            _includeInactive = !_includeInactive;
            btnToggleInactive.Text = _includeInactive ? "Только активные" : "Показать все";
            LoadAdvertisements();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}