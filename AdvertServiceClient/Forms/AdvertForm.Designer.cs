namespace AdvertServiceClient.Forms
{
    partial class AdvertForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblSeller = new System.Windows.Forms.Label();
            this.txtSeller = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblViews = new System.Windows.Forms.Label();
            this.txtViews = new System.Windows.Forms.TextBox();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.txtFavorites = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblPublicationDate = new System.Windows.Forms.Label();
            this.txtPublicationDate = new System.Windows.Forms.TextBox();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.txtExpirationDate = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnComplain = new System.Windows.Forms.Button();
            this.btnStartChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 25);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(360, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Название:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 48);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 64);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(360, 100);
            this.txtDescription.TabIndex = 2;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 167);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Цена:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(12, 183);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 4;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(118, 167);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Категория:";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(118, 183);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(150, 20);
            this.txtCategory.TabIndex = 6;
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(12, 206);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(72, 13);
            this.lblSeller.TabIndex = 9;
            this.lblSeller.Text = "Продавец:";
            // 
            // txtSeller
            // 
            this.txtSeller.Location = new System.Drawing.Point(12, 222);
            this.txtSeller.Name = "txtSeller";
            this.txtSeller.ReadOnly = true;
            this.txtSeller.Size = new System.Drawing.Size(150, 20);
            this.txtSeller.TabIndex = 8;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(168, 206);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(51, 13);
            this.lblRating.TabIndex = 11;
            this.lblRating.Text = "Рейтинг:";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(168, 222);
            this.txtRating.Name = "txtRating";
            this.txtRating.ReadOnly = true;
            this.txtRating.Size = new System.Drawing.Size(100, 20);
            this.txtRating.TabIndex = 10;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 245);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(107, 13);
            this.lblLocation.TabIndex = 13;
            this.lblLocation.Text = "Местоположение:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(12, 261);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(360, 20);
            this.txtLocation.TabIndex = 12;
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Location = new System.Drawing.Point(12, 284);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(89, 13);
            this.lblViews.TabIndex = 15;
            this.lblViews.Text = "Просмотров:";
            // 
            // txtViews
            // 
            this.txtViews.Location = new System.Drawing.Point(12, 300);
            this.txtViews.Name = "txtViews";
            this.txtViews.ReadOnly = true;
            this.txtViews.Size = new System.Drawing.Size(100, 20);
            this.txtViews.TabIndex = 14;
            // 
            // lblFavorites
            // 
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Location = new System.Drawing.Point(118, 284);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(93, 13);
            this.lblFavorites.TabIndex = 17;
            this.lblFavorites.Text = "В избранном:";
            // 
            // txtFavorites
            // 
            this.txtFavorites.Location = new System.Drawing.Point(118, 300);
            this.txtFavorites.Name = "txtFavorites";
            this.txtFavorites.ReadOnly = true;
            this.txtFavorites.Size = new System.Drawing.Size(100, 20);
            this.txtFavorites.TabIndex = 16;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(224, 284);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Статус:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(224, 300);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 18;
            // 
            // lblPublicationDate
            // 
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Location = new System.Drawing.Point(12, 323);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new System.Drawing.Size(96, 13);
            this.lblPublicationDate.TabIndex = 21;
            this.lblPublicationDate.Text = "Дата публикации:";
            // 
            // txtPublicationDate
            // 
            this.txtPublicationDate.Location = new System.Drawing.Point(12, 339);
            this.txtPublicationDate.Name = "txtPublicationDate";
            this.txtPublicationDate.ReadOnly = true;
            this.txtPublicationDate.Size = new System.Drawing.Size(150, 20);
            this.txtPublicationDate.TabIndex = 20;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(168, 323);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(116, 13);
            this.lblExpirationDate.TabIndex = 23;
            this.lblExpirationDate.Text = "Дата окончания:";
            // 
            // txtExpirationDate
            // 
            this.txtExpirationDate.Location = new System.Drawing.Point(168, 339);
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.ReadOnly = true;
            this.txtExpirationDate.Size = new System.Drawing.Size(150, 20);
            this.txtExpirationDate.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(297, 365);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(12, 365);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 25;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(93, 365);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnComplain
            // 
            this.btnComplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComplain.Location = new System.Drawing.Point(174, 365);
            this.btnComplain.Name = "btnComplain";
            this.btnComplain.Size = new System.Drawing.Size(75, 23);
            this.btnComplain.TabIndex = 27;
            this.btnComplain.Text = "Пожаловаться";
            this.btnComplain.UseVisualStyleBackColor = true;
            this.btnComplain.Click += new System.EventHandler(this.btnComplain_Click);
            // 
            // btnStartChat
            // 
            this.btnStartChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartChat.Location = new System.Drawing.Point(12, 394);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(150, 23);
            this.btnStartChat.TabIndex = 28;
            this.btnStartChat.Text = "Начать чат с продавцом";
            this.btnStartChat.UseVisualStyleBackColor = true;
            this.btnStartChat.Click += new System.EventHandler(this.btnStartChat_Click);
            // 
            // AdvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 429);
            this.Controls.Add(this.btnStartChat);
            this.Controls.Add(this.btnComplain);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblExpirationDate);
            this.Controls.Add(this.txtExpirationDate);
            this.Controls.Add(this.lblPublicationDate);
            this.Controls.Add(this.txtPublicationDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblFavorites);
            this.Controls.Add(this.txtFavorites);
            this.Controls.Add(this.lblViews);
            this.Controls.Add(this.txtViews);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.txtSeller);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр объявления";
            this.Load += new System.EventHandler(this.AdvertForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.TextBox txtSeller;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.TextBox txtViews;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.TextBox txtFavorites;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblPublicationDate;
        private System.Windows.Forms.TextBox txtPublicationDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.TextBox txtExpirationDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnComplain;
        private System.Windows.Forms.Button btnStartChat;
    }
}