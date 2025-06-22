using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ChatsListForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _currentUserId;

        public ChatsListForm(int currentUserId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _currentUserId = currentUserId;
            LoadChats();
        }

        private void LoadChats()
        {
            listViewChats.Items.Clear();

            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _currentUserId)
                };

                var chatsData = _dbHelper.ExecuteStoredProcedure("sp_GetUserChats", parameters);

                if (chatsData == null || chatsData.Rows.Count == 0)
                {
                    MessageBox.Show("У вас пока нет чатов.", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in chatsData.Rows)
                {
                    var advertId = row["AdvertID"] != DBNull.Value ? Convert.ToInt32(row["AdvertID"]) : 0;
                    var advertTitle = row["AdvertTitle"] != DBNull.Value ? row["AdvertTitle"].ToString() : "Без названия";
                    var otherUserName = row["OtherUserName"] != DBNull.Value ? row["OtherUserName"].ToString() : "Неизвестный";
                    var lastMessage = row["LastMessage"] != DBNull.Value ? row["LastMessage"].ToString() : "";
                    var lastMessageDate = row["LastMessageDate"] != DBNull.Value ? Convert.ToDateTime(row["LastMessageDate"]) : DateTime.Now;
                    var unreadCount = row["UnreadCount"] != DBNull.Value ? Convert.ToInt32(row["UnreadCount"]) : 0;

                    var item = new ListViewItem(advertTitle);
                    item.SubItems.Add(otherUserName);
                    item.SubItems.Add(lastMessage);
                    item.SubItems.Add(lastMessageDate.ToString("g"));
                    item.SubItems.Add(unreadCount.ToString());
                    item.Tag = advertId; // Сохраняем AdvertID в Tag для использования при открытии чата

                    if (unreadCount > 0)
                    {
                        item.Font = new Font(item.Font, FontStyle.Bold);
                    }

                    listViewChats.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке чатов: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewChats_DoubleClick(object sender, EventArgs e)
        {
            if (listViewChats.SelectedItems.Count == 0) return;

            var selectedItem = listViewChats.SelectedItems[0];
            var advertId = (int)selectedItem.Tag;

            var chatForm = new ChatForm(_currentUserId, advertId);
            chatForm.ShowDialog();
            LoadChats(); // Обновляем список чатов после закрытия формы чата
        }
    }
}