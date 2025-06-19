namespace AdvertServiceClient
{
    partial class ProfileForm
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblRegDate = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.lblAdsCount = new System.Windows.Forms.Label();
            this.lblReviewsCount = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(57, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "label1";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "label2";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 80);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(35, 13);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "label3";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(20, 110);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(35, 13);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "label4";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(20, 140);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(35, 13);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "label5";
            // 
            // lblRegDate
            // 
            this.lblRegDate.AutoSize = true;
            this.lblRegDate.Location = new System.Drawing.Point(20, 170);
            this.lblRegDate.Name = "lblRegDate";
            this.lblRegDate.Size = new System.Drawing.Size(35, 13);
            this.lblRegDate.TabIndex = 5;
            this.lblRegDate.Text = "label6";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Location = new System.Drawing.Point(20, 200);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(35, 13);
            this.lblLastLogin.TabIndex = 6;
            this.lblLastLogin.Text = "label7";
            // 
            // lblAdsCount
            // 
            this.lblAdsCount.AutoSize = true;
            this.lblAdsCount.Location = new System.Drawing.Point(20, 230);
            this.lblAdsCount.Name = "lblAdsCount";
            this.lblAdsCount.Size = new System.Drawing.Size(35, 13);
            this.lblAdsCount.TabIndex = 7;
            this.lblAdsCount.Text = "label8";
            // 
            // lblReviewsCount
            // 
            this.lblReviewsCount.AutoSize = true;
            this.lblReviewsCount.Location = new System.Drawing.Point(20, 260);
            this.lblReviewsCount.Name = "lblReviewsCount";
            this.lblReviewsCount.Size = new System.Drawing.Size(35, 13);
            this.lblReviewsCount.TabIndex = 8;
            this.lblReviewsCount.Text = "label9";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(20, 300);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(150, 30);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Location = new System.Drawing.Point(180, 300);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(150, 30);
            this.btnUpdateProfile.TabIndex = 10;
            this.btnUpdateProfile.Text = "Редактировать профиль";
            this.btnUpdateProfile.UseVisualStyleBackColor = true;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Location = new System.Drawing.Point(350, 20);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.Size = new System.Drawing.Size(400, 310);
            this.dgvReviews.TabIndex = 11;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 350);
            this.Controls.Add(this.dgvReviews);
            this.Controls.Add(this.btnUpdateProfile);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.lblReviewsCount);
            this.Controls.Add(this.lblAdsCount);
            this.Controls.Add(this.lblLastLogin);
            this.Controls.Add(this.lblRegDate);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.MinimumSize = new System.Drawing.Size(786, 389);
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мой профиль";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblRegDate;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.Label lblAdsCount;
        private System.Windows.Forms.Label lblReviewsCount;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.DataGridView dgvReviews;
    }
}