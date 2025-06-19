using System;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class MyAdTile : AdvertTile
    {
        private int _advertId;
        private int _userId;

        public event EventHandler<int> EditClicked;
        public event EventHandler<int> DeleteClicked;

        public MyAdTile(int advertId, string title, decimal price, string categoryName,
                        int viewCount, int messagesCount, int userId)
            : base(advertId, title, price, "", 0, categoryName, city, 0, userId)
        {
            _advertId = advertId;
            _userId = userId;

            InitializeComponent();
            InitializeAdditionalComponents();
        }

        private void InitializeAdditionalComponents()
        {
            // Увеличиваем высоту контрола
            this.Height += 50;

            // Перемещаем кнопку сообщения (если она есть)
            if (btnMessage != null)
            {
                btnMessage.Top = this.Height - 90;
                btnMessage.Text = "Сообщения (" + ((Label)this.Controls.Find("lblMessagesCount", true)[0]).Text + ")";
            }

            // Настраиваем кнопки
            btnEdit.Top = this.Height - 40;
            btnDelete.Top = this.Height - 40;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, _advertId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, _advertId);
        }
    }
}