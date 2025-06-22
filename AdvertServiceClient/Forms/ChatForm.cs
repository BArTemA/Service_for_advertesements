using AdvertServiceClient.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ChatForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _currentUserId;
        private readonly int _advertId;
        private int _otherUserId;
        private int _chatId;

        public ChatForm(int currentUserId, int advertId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _currentUserId = currentUserId;
            _advertId = advertId;

            InitializeChat();
            LoadMessages();
        }

        private void InitializeChat()
        {
            // Получаем информацию об объявлении
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@AdvertID", _advertId),
        new SqlParameter("@IncrementViewCount", 0)
            };

            var adData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);

            if (adData.Rows.Count == 0)
            {
                MessageBox.Show("Объявление не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _otherUserId = Convert.ToInt32(adData.Rows[0]["UserID"]);
            lblAdvertTitle.Text = adData.Rows[0]["Title"].ToString();
            lblAdvertPrice.Text = $"{Convert.ToDecimal(adData.Rows[0]["Price"]):C}";

            // Если текущий пользователь - владелец объявления
            if (_currentUserId == _otherUserId)
            {
                // Ищем существующие чаты для этого объявления
                var chatData = _dbHelper.ExecuteStoredProcedure("sp_GetChatsByAdvert", new SqlParameter[]
                {
            new SqlParameter("@AdvertID", _advertId),
            new SqlParameter("@UserID", _currentUserId)
                });

                if (chatData.Rows.Count > 0)
                {
                    // Берем первый найденный чат
                    _chatId = Convert.ToInt32(chatData.Rows[0]["ChatID"]);
                    _otherUserId = Convert.ToInt32(chatData.Rows[0]["OtherUserID"]);
                    lblOtherUser.Text = $"Чат с {chatData.Rows[0]["OtherUserName"]}";
                    return;
                }
                else
                {
                    MessageBox.Show("Нет существующих чатов для этого объявления", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }

            // Если текущий пользователь НЕ владелец объявления
            var outputParam = new SqlParameter("@ChatID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            try
            {
                _dbHelper.ExecuteStoredProcedure("sp_CreateChat", new SqlParameter[]
                {
            new SqlParameter("@AdvertID", _advertId),
            new SqlParameter("@User1ID", _otherUserId), // Владелец объявления
            new SqlParameter("@User2ID", _currentUserId), // Текущий пользователь
            outputParam
                });

                _chatId = Convert.ToInt32(outputParam.Value);
                lblOtherUser.Text = $"Чат с {adData.Rows[0]["Username"]}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании чата: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadMessages()
        {
            flowMessages.Controls.Clear();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ChatID", _chatId),
                new SqlParameter("@UserID", _currentUserId)
            };

            var messagesData = _dbHelper.ExecuteStoredProcedure("sp_GetChatMessages", parameters);

            foreach (DataRow row in messagesData.Rows)
            {
                var messageControl = new MessageControl(
                    Convert.ToInt32(row["SenderID"]),
                    row["SenderName"].ToString(),
                    row["Content"].ToString(),
                    Convert.ToDateTime(row["SentDate"]),
                    Convert.ToBoolean(row["IsOwnMessage"]));

                flowMessages.Controls.Add(messageControl);
            }

            // Прокручиваем вниз
            flowMessages.ScrollControlIntoView(flowMessages.Controls[flowMessages.Controls.Count - 1]);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            try
            {
                var outputParam = new SqlParameter("@MessageID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                _dbHelper.ExecuteStoredProcedure("sp_SendMessage", new SqlParameter[]
                {
                    new SqlParameter("@ChatID", _chatId),
                    new SqlParameter("@SenderID", _currentUserId),
                    new SqlParameter("@ReceiverID", _otherUserId),
                    new SqlParameter("@Content", txtMessage.Text),
                    outputParam
                });

                txtMessage.Clear();
                LoadMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке сообщения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}