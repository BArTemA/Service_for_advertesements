namespace AdvertServiceClient
{
    partial class AdvertTile
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.btnMessage = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 54);
            this.lblDescription.MaximumSize = new System.Drawing.Size(250, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(250, 30);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Описание";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.ForeColor = System.Drawing.Color.Green;
            this.lblPrice.Location = new System.Drawing.Point(9, 84);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 20);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Цена";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(7, 116);
            this.lblSeller.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(57, 13);
            this.lblSeller.TabIndex = 2;
            this.lblSeller.Text = "Продавец";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(7, 138);
            this.lblCategory.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 13);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Категория";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(7, 160);
            this.lblLocation.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(95, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Местоположение";
            // 
            // lblFavorites
            // 
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Location = new System.Drawing.Point(7, 182);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(73, 13);
            this.lblFavorites.TabIndex = 5;
            this.lblFavorites.Text = "В избранном";
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(7, 209);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(120, 30);
            this.btnMessage.TabIndex = 6;
            this.btnMessage.Text = "Написать";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(140, 209);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(120, 30);
            this.btnProfile.TabIndex = 8;
            this.btnProfile.Text = "Профиль";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // AdvertTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.lblFavorites);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "AdvertTile";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(280, 247);
            this.Load += new System.EventHandler(this.AdvertTile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnProfile;
    }
}