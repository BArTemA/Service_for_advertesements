namespace AdvertServiceClient
{
    partial class AdDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblViews = new System.Windows.Forms.Label();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.btnToggleFavorite = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnAddReview = new System.Windows.Forms.Button();
            this.btnComplain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(57, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "label2";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(20, 150);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 17);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "label3";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(20, 180);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(35, 13);
            this.lblSeller.TabIndex = 3;
            this.lblSeller.Text = "label4";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 210);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(35, 13);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "label5";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(20, 240);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(35, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "label6";
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Location = new System.Drawing.Point(20, 270);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(35, 13);
            this.lblViews.TabIndex = 6;
            this.lblViews.Text = "label7";
            // 
            // lblFavorites
            // 
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Location = new System.Drawing.Point(20, 300);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(35, 13);
            this.lblFavorites.TabIndex = 7;
            this.lblFavorites.Text = "label8";
            // 
            // btnToggleFavorite
            // 
            this.btnToggleFavorite.Location = new System.Drawing.Point(20, 330);
            this.btnToggleFavorite.Name = "btnToggleFavorite";
            this.btnToggleFavorite.Size = new System.Drawing.Size(150, 30);
            this.btnToggleFavorite.TabIndex = 8;
            this.btnToggleFavorite.Text = "Добавить в избранное";
            this.btnToggleFavorite.UseVisualStyleBackColor = true;
            this.btnToggleFavorite.Click += new System.EventHandler(this.btnToggleFavorite_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(180, 330);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(150, 30);
            this.btnSendMessage.TabIndex = 9;
            this.btnSendMessage.Text = "Написать сообщение";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnAddReview
            // 
            this.btnAddReview.Location = new System.Drawing.Point(20, 370);
            this.btnAddReview.Name = "btnAddReview";
            this.btnAddReview.Size = new System.Drawing.Size(150, 30);
            this.btnAddReview.TabIndex = 10;
            this.btnAddReview.Text = "Оставить отзыв";
            this.btnAddReview.UseVisualStyleBackColor = true;
            this.btnAddReview.Click += new System.EventHandler(this.btnAddReview_Click);
            // 
            // btnComplain
            // 
            this.btnComplain.Location = new System.Drawing.Point(180, 370);
            this.btnComplain.Name = "btnComplain";
            this.btnComplain.Size = new System.Drawing.Size(150, 30);
            this.btnComplain.TabIndex = 11;
            this.btnComplain.Text = "Пожаловаться";
            this.btnComplain.UseVisualStyleBackColor = true;
            this.btnComplain.Click += new System.EventHandler(this.btnComplain_Click);
            // 
            // AdDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.btnComplain);
            this.Controls.Add(this.btnAddReview);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnToggleFavorite);
            this.Controls.Add(this.lblFavorites);
            this.Controls.Add(this.lblViews);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детали объявления";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.Button btnToggleFavorite;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.Button btnComplain;
    }
}