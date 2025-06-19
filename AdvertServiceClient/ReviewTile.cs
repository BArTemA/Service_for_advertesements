using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class ReviewTile : UserControl
    {
        private int _reviewerId;
        private int _currentUserId;

        public ReviewTile(int reviewerId, string reviewerName, decimal rating,
                        string comment, DateTime reviewDate, int currentUserId)
        {
            InitializeComponent();

            _reviewerId = reviewerId;
            _currentUserId = currentUserId;

            lblReviewer.Text = reviewerName;
            lblRating.Text = $"Рейтинг: {rating:F1}";
            lblComment.Text = comment;
            lblDate.Text = reviewDate.ToString("dd.MM.yyyy");

            // Настройка внешнего вида
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(10);
            this.Margin = new Padding(10);
            this.Width = 300;

            // Настройка элементов управления
            lblComment.AutoSize = false;
            lblComment.MaximumSize = new Size(280, 0);
            lblComment.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void ReviewTile_Load(object sender, EventArgs e)
        {
            // Можно добавить дополнительные настройки при загрузке
        }
    }
}
