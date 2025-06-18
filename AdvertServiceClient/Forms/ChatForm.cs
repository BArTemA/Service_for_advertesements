using AdvertServiceClient.Models;
using AdvertServiceClient.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class ChatForm : Form
    {
        private readonly User _currentUser;
        private readonly int _chatId;
        private int _otherUserId;
        private string _otherUserName;

        public ChatForm(User currentUser, int chatId)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _chatId = chatId;
            Text = $"Чат #{chatId}";
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            LoadChatInfo();
            LoadMessages();
            timerRefresh.Interval = 5000; // Обновление каждые 5 секунд
            timerRefresh.Start();
        }

        private void LoadChatInfo()
        {
            using (var chatService = new ChatService())
            {
                var chatTable = chatService.GetChatMessages(_chatId, _currentUser.UserID, 1, 1);
                if (chatTable.Rows.Count > 0)
                {
                    var row = chatTable.Rows[0];
                    _otherUserId = (int)(_currentUser.UserID == (int)row["User1ID"] ? row["User2ID"] : row["User1ID"]);
                    _otherUserName = _currentUser.UserID == (int)row["User1ID"] ? row["User2Name"].ToString() : row["User1Name"].ToString();
                    lblChatWith.Text = $"Чат с: {_otherUserName}";
                    lblAdvertTitle.Text = row["AdvertTitle"].ToString();
                    lblAdvertPrice.Text = $"Цена: {row["Price"]}";
                    lblAdvertStatus.Text = $"Статус: {row["AdvertStatus"]}";
                }
            }
        }

        private void LoadMessages()
        {
            using (var chatService = new ChatService())
            {
                var messagesTable = chatService.GetChatMessages(_chatId, _currentUser.UserID);
                flowMessages.Controls.Clear();

                foreach (DataRow row in messagesTable.Rows)
                {
                    var messageControl = new MessageControl(
                        (int)row["SenderID"],
                        row["SenderName"].ToString(),
                        row["Content"].ToString(),
                        (DateTime)row["SentDate"],
                        (bool)row["IsRead"],
                        (bool)row["IsOwnMessage"]);

                    flowMessages.Controls.Add(messageControl);
                }

                // Прокрутка вниз
                if (flowMessages.VerticalScroll.Visible)
                {
                    flowMessages.ScrollControlIntoView(flowMessages.Controls[flowMessages.Controls.Count - 1]);
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            using (var chatService = new ChatService())
            {
                chatService.SendMessage(_chatId, _currentUser.UserID, _otherUserId, txtMessage.Text);
                txtMessage.Clear();
                LoadMessages();
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }

        private void btnCloseChat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрыть этот чат?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var chatService = new ChatService())
                {
                    chatService.CloseChat(_chatId, _currentUser.UserID);
                    Close();
                }
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop();
            using (var chatService = new ChatService())
            {
                chatService.MarkMessagesAsRead(_chatId, _currentUser.UserID);
            }
        }
    }
}