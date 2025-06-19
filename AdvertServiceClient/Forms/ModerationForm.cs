using System;
using System.Data;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ModerationForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _moderatorId;

        public ModerationForm(int moderatorId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _moderatorId = moderatorId;
            LoadComplaints();
        }

        private void LoadComplaints()
        {
            try
            {
                var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Status", "Pending")
                };

                var complaintsData = _dbHelper.ExecuteStoredProcedure("sp_GetComplaintsForModeration", parameters);
                dgvComplaints.DataSource = complaintsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке жалоб: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComplaints_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dgvComplaints.Rows[e.RowIndex].Cells["ComplainerID"].Value);
                int advertId = Convert.ToInt32(dgvComplaints.Rows[e.RowIndex].Cells["AdvertID"].Value);

                var processForm = new ProcessComplaintForm(userId, advertId, _moderatorId);
                if (processForm.ShowDialog() == DialogResult.OK)
                {
                    LoadComplaints();
                }
            }
        }
    }
}