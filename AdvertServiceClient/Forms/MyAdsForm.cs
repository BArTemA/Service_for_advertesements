using System;
using System.Data;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class MyAdsForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _userId;

        public MyAdsForm(int userId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _userId = userId;
            LoadMyAds();
        }

        private void LoadMyAds()
        {
            try
            {
                var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@UserID", _userId),
                    new System.Data.SqlClient.SqlParameter("@IncludeInactive", chkIncludeInactive.Checked)
                };

                var adsData = _dbHelper.ExecuteStoredProcedure("sp_GetUserAdvertisements", parameters);
                dgvMyAds.DataSource = adsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке объявлений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMyAds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int advertId = Convert.ToInt32(dgvMyAds.Rows[e.RowIndex].Cells["AdvertID"].Value);
                var adDetailsForm = new MyAdDetailsForm(advertId, _userId);
                if (adDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMyAds();
                }
            }
        }

        private void btnCreateAd_Click(object sender, EventArgs e)
        {
            var createAdForm = new CreateAdForm(_userId);
            if (createAdForm.ShowDialog() == DialogResult.OK)
            {
                LoadMyAds();
            }
        }

        private void chkIncludeInactive_CheckedChanged(object sender, EventArgs e)
        {
            LoadMyAds();
        }
    }
}