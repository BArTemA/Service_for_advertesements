using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ChatForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private readonly int _currentUserId;
        private readonly int _advertId;
        private int _chatId;
        private int _otherUserId;

        public ChatForm(int currentUserId, int advertId)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _currentUserId = currentUserId;
            _advertId = advertId;
            InitializeChat();
            LoadMessages();
            timerMessages.Enabled = true;
        }

        private void InitializeChat()
        {
            try
            {
                // Получаем информацию о объявлении, чтобы определить владельца
                var adParams = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@AdvertID", _advertId),
                    new System.Data.SqlClient.SqlParameter("@IncrementViewCount", 0)
                };

                var adData = _dbHelper.ExecuteStoredProcedure("sp_GetAdvertisementDetails", adParams);
                if (adData.Rows.Count > 0)
                {
                    _otherUserId = (int)adData.Rows[0]["UserID"];
                    lblAdTitle.Text = adData.Rows[0]["Title"].ToString();
                    lblAdPrice.Text = $"{adData.Rows[0]["Price"]} руб.";

                    // Создаем или получаем чат
                    var chatParams = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@AdvertID", _advertId),
                        new System.Data.SqlClient.SqlParameter("@User1ID", _otherUserId), // владелец объявления
                        new System.Data.SqlClient.SqlParameter("@User2ID", _currentUserId), // текущий пользователь
                        new System.Data.SqlClient.SqlParameter("@ChatID", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output }
                    };

                    _dbHelper.ExecuteStoredProcedureNonQuery("sp_CreateChat", chatParams);
                    _chatId = (int)chatParams[3].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации чата: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LoadMessages()
        {
            try
            {
                var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@ChatID", _chatId),
                    new System.Data.SqlClient.SqlParameter("@UserID", _currentUserId)
                };

                var messages = _dbHelper.ExecuteStoredProcedure("sp_GetChatMessages", parameters);

                flowLayoutPanelMessages.Controls.Clear();

                foreach (DataRow row in messages.Rows)
                {
                    var messageControl = new MessageControl
                    {
                        SenderName = row["SenderName"].ToString(),
                        Content = row["Content"].ToString(),
                        SentDate = DateTime.Parse(row["SentDate"].ToString()),
                        IsOwnMessage = (bool)row["IsOwnMessage"]
                    };

                    flowLayoutPanelMessages.Controls.Add(messageControl);
                }

                // Прокрутка вниз
                flowLayoutPanelMessages.ScrollControlIntoView(
                    flowLayoutPanelMessages.Controls[flowLayoutPanelMessages.Controls.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сообщений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Введите текст сообщения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@ChatID", _chatId),
                    new System.Data.SqlClient.SqlParameter("@SenderID", _currentUserId),
                    new System.Data.SqlClient.SqlParameter("@ReceiverID", _otherUserId),
                    new System.Data.SqlClient.SqlParameter("@Content", txtMessage.Text),
                    new System.Data.SqlClient.SqlParameter("@MessageID", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output }
                };

                _dbHelper.ExecuteStoredProcedureNonQuery("sp_SendMessage", parameters);
                txtMessage.Clear();
                LoadMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке сообщения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerMessages_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerMessages.Enabled = false;
        }
    }

    public class MessageControl : Panel
    {
        private readonly Label _lblSender;
        private readonly Label _lblContent;
        private readonly Label _lblTime;

        public MessageControl()
        {
            Width = 400;
            AutoSize = true;
            Padding = new Padding(5);
            Margin = new Padding(5);

            _lblSender = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold),
                Margin = new Padding(0, 0, 0, 3)
            };

            _lblContent = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(380, 0),
                Margin = new Padding(0, 0, 0, 3)
            };

            _lblTime = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Italic),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleRight
            };

            Controls.Add(_lblSender);
            Controls.Add(_lblContent);
            Controls.Add(_lblTime);
        }

        public string SenderName
        {
            get => _lblSender.Text;
            set => _lblSender.Text = value;
        }

        public string Content
        {
            get => _lblContent.Text;
            set => _lblContent.Text = value;
        }

        public DateTime SentDate
        {
            get => DateTime.Parse(_lblTime.Text);
            set => _lblTime.Text = value.ToString("g");
        }

        public bool IsOwnMessage
        {
            set
            {
                BackColor = value ? Color.LightBlue : SystemColors.Control;
                _lblTime.Dock = value ? DockStyle.Left : DockStyle.Right;
            }
        }
    }
}