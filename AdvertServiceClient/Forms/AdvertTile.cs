using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class AdvertTile : UserControl
    {
        private int _advertId;
        private int _currentUserId;

        public event EventHandler<int> MessageClicked;

        public AdvertTile(int advertId, string title, string description, decimal price, string sellerName,
                        decimal sellerRating, string categoryName, string city,
                        int favoritesCount, int currentUserId)
        {
            InitializeComponent();

            _advertId = advertId;
            _currentUserId = currentUserId;

            lblTitle.Text = title;
            lblDescription.Text = description;
            lblPrice.Text = $"{price:C}";
            lblSeller.Text = $"Продавец: {sellerName} (рейтинг: {sellerRating:F1})";
            lblCategory.Text = $"Категория: {categoryName}";
            lblLocation.Text = $"Местоположение: {city}";
            lblFavorites.Text = $"В избранном: {favoritesCount}";

            if (currentUserId <= 0)
            {
                btnMessage.Visible = false;
            }
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            MessageClicked?.Invoke(this, _advertId);
        }

        private void AdvertTile_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(5);
            this.Margin = new Padding(10);
        }
    }
}