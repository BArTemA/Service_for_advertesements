namespace AdvertServiceClient.Forms
{
    partial class UserProfileForm
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.txtRegistrationDate = new System.Windows.Forms.TextBox();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.txtLastLogin = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lblAdvertsCount = new System.Windows.Forms.Label();
            this.txtAdvertsCount = new System.Windows.Forms.TextBox();
            this.lblReviewsCount = new System.Windows.Forms.Label();
            this.txtReviewsCount = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.btnViewReviews = new System.Windows.Forms.Button();
            this.btnViewAdverts = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.lblIsModerator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Имя пользователя:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(124, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 41);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(124, 38);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 67);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 13);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(124, 64);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Location = new System.Drawing.Point(12, 93);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(96, 13);
            this.lblRegistrationDate.TabIndex = 6;
            this.lblRegistrationDate.Text = "Дата регистрации:";
            // 
            // txtRegistrationDate
            // 
            this.txtRegistrationDate.Location = new System.Drawing.Point(124, 90);
            this.txtRegistrationDate.Name = "txtRegistrationDate";
            this.txtRegistrationDate.ReadOnly = true;
            this.txtRegistrationDate.Size = new System.Drawing.Size(200, 20);
            this.txtRegistrationDate.TabIndex = 7;
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Location = new System.Drawing.Point(12, 119);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(84, 13);
            this.lblLastLogin.TabIndex = 8;
            this.lblLastLogin.Text = "Последний вход:";
            // 
            // txtLastLogin
            // 
            this.txtLastLogin.Location = new System.Drawing.Point(124, 116);
            this.txtLastLogin.Name = "txtLastLogin";
            this.txtLastLogin.ReadOnly = true;
            this.txtLastLogin.Size = new System.Drawing.Size(200, 20);
            this.txtLastLogin.TabIndex = 9;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(12, 145);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(51, 13);
            this.lblRating.TabIndex = 10;
            this.lblRating.Text = "Рейтинг:";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(124, 142);
            this.txtRating.Name = "txtRating";
            this.txtRating.ReadOnly = true;
            this.txtRating.Size = new System.Drawing.Size(200, 20);
            this.txtRating.TabIndex = 11;
            // 
            // lblAdvertsCount
            // 
            this.lblAdvertsCount.AutoSize = true;
            this.lblAdvertsCount.Location = new System.Drawing.Point(12, 171);
            this.lblAdvertsCount.Name = "lblAdvertsCount";
            this.lblAdvertsCount.Size = new System.Drawing.Size(106, 13);
            this.lblAdvertsCount.TabIndex = 12;
            this.lblAdvertsCount.Text = "Объявлений создано:";
            // 
            // txtAdvertsCount
            // 
            this.txtAdvertsCount.Location = new System.Drawing.Point(124, 168);
            this.txtAdvertsCount.Name = "txtAdvertsCount";
            this.txtAdvertsCount.ReadOnly = true;
            this.txtAdvertsCount.Size = new System.Drawing.Size(200, 20);
            this.txtAdvertsCount.TabIndex = 13;
            // 
            // lblReviewsCount
            // 
            this.lblReviewsCount.AutoSize = true;
            this.lblReviewsCount.Location = new System.Drawing.Point(12, 197);
            this.lblReviewsCount.Name = "lblReviewsCount";
            this.lblReviewsCount.Size = new System.Drawing.Size(89, 13);
            this.lblReviewsCount.TabIndex = 14;
            this.lblReviewsCount.Text = "Отзывов получено:";
            // 
            // txtReviewsCount
            // 
            this.txtReviewsCount.Location = new System.Drawing.Point(124, 194);
            this.txtReviewsCount.Name = "txtReviewsCount";
            this.txtReviewsCount.ReadOnly = true;
            this.txtReviewsCount.Size = new System.Drawing.Size(200, 20);
            this.txtReviewsCount.TabIndex = 15;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 223);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(107, 13);
            this.lblLocation.TabIndex = 16;
            this.lblLocation.Text = "Местоположение:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(124, 220);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(200, 20);
            this.txtLocation.TabIndex = 17;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Location = new System.Drawing.Point(12, 246);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(100, 23);
            this.btnEditProfile.TabIndex = 18;
            this.btnEditProfile.Text = "Редактировать";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(118, 246);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(100, 23);
            this.btnChangePassword.TabIndex = 19;
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Location = new System.Drawing.Point(224, 246);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(100, 23);
            this.btnUploadPhoto.TabIndex = 20;
            this.btnUploadPhoto.Text = "Загрузить фото";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // btnViewReviews
            // 
            this.btnViewReviews.Location = new System.Drawing.Point(12, 275);
            this.btnViewReviews.Name = "btnViewReviews";
            this.btnViewReviews.Size = new System.Drawing.Size(150, 23);
            this.btnViewReviews.TabIndex = 21;
            this.btnViewReviews.Text = "Просмотреть отзывы";
            this.btnViewReviews.UseVisualStyleBackColor = true;
            this.btnViewReviews.Click += new System.EventHandler(this.btnViewReviews_Click);
            // 
            // btnViewAdverts
            // 
            this.btnViewAdverts.Location = new System.Drawing.Point(168, 275);
            this.btnViewAdverts.Name = "btnViewAdverts";
            this.btnViewAdverts.Size = new System.Drawing.Size(156, 23);
            this.btnViewAdverts.TabIndex = 22;
            this.btnViewAdverts.Text = "Просмотреть объявления";
            this.btnViewAdverts.UseVisualStyleBackColor = true;
            this.btnViewAdverts.Click += new System.EventHandler(this.btnViewAdverts_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(124, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProfilePicture.Location = new System.Drawing.Point(330, 12);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(150, 150);
            this.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfilePicture.TabIndex = 24;
            this.pbProfilePicture.TabStop = false;
            // 
            // lblIsModerator
            // 
            this.lblIsModerator.AutoSize = true;
            this.lblIsModerator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIsModerator.ForeColor = System.Drawing.Color.Green;
            this.lblIsModerator.Location = new System.Drawing.Point(330, 168);
            this.lblIsModerator.Name = "lblIsModerator";
            this.lblIsModerator.Size = new System.Drawing.Size(80, 13);
            this.lblIsModerator.TabIndex = 25;
            this.lblIsModerator.Text = "МОДЕРАТОР";
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 339);
            this.Controls.Add(this.lblIsModerator);
            this.Controls.Add(this.pbProfilePicture);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewAdverts);
            this.Controls.Add(this.btnViewReviews);
            this.Controls.Add(this.btnUploadPhoto);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtReviewsCount);
            this.Controls.Add(this.lblReviewsCount);
            this.Controls.Add(this.txtAdvertsCount);
            this.Controls.Add(this.lblAdvertsCount);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtLastLogin);
            this.Controls.Add(this.lblLastLogin);
            this.Controls.Add(this.txtRegistrationDate);
            this.Controls.Add(this.lblRegistrationDate);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UserProfileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.TextBox txtRegistrationDate;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.TextBox txtLastLogin;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label lblAdvertsCount;
        private System.Windows.Forms.TextBox txtAdvertsCount;
        private System.Windows.Forms.Label lblReviewsCount;
        private System.Windows.Forms.TextBox txtReviewsCount;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnViewReviews;
        private System.Windows.Forms.Button btnViewAdverts;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbProfilePicture;
        private System.Windows.Forms.Label lblIsModerator;
    }
}