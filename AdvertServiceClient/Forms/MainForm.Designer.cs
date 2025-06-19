namespace AdvertServiceClient
{
    partial class MainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.dgvAdvertisements = new System.Windows.Forms.DataGridView();
            this.btnCreateAd = new System.Windows.Forms.Button();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnMyAds = new System.Windows.Forms.Button();
            this.btnModeration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvertisements)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(115, 17);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Добро пожаловать!";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(20, 50);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(52, 13);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Рейтинг:";
            // 
            // dgvAdvertisements
            // 
            this.dgvAdvertisements.AllowUserToAddRows = false;
            this.dgvAdvertisements.AllowUserToDeleteRows = false;
            this.dgvAdvertisements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdvertisements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdvertisements.Location = new System.Drawing.Point(20, 80);
            this.dgvAdvertisements.Name = "dgvAdvertisements";
            this.dgvAdvertisements.ReadOnly = true;
            this.dgvAdvertisements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdvertisements.Size = new System.Drawing.Size(760, 400);
            this.dgvAdvertisements.TabIndex = 2;
            this.dgvAdvertisements.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdvertisements_CellDoubleClick);
            // 
            // btnCreateAd
            // 
            this.btnCreateAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAd.Location = new System.Drawing.Point(800, 80);
            this.btnCreateAd.Name = "btnCreateAd";
            this.btnCreateAd.Size = new System.Drawing.Size(120, 30);
            this.btnCreateAd.TabIndex = 3;
            this.btnCreateAd.Text = "Создать объявление";
            this.btnCreateAd.UseVisualStyleBackColor = true;
            this.btnCreateAd.Click += new System.EventHandler(this.btnCreateAd_Click);
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMyProfile.Location = new System.Drawing.Point(800, 120);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(120, 30);
            this.btnMyProfile.TabIndex = 4;
            this.btnMyProfile.Text = "Мой профиль";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnMyAds
            // 
            this.btnMyAds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMyAds.Location = new System.Drawing.Point(800, 160);
            this.btnMyAds.Name = "btnMyAds";
            this.btnMyAds.Size = new System.Drawing.Size(120, 30);
            this.btnMyAds.TabIndex = 5;
            this.btnMyAds.Text = "Мои объявления";
            this.btnMyAds.UseVisualStyleBackColor = true;
            this.btnMyAds.Click += new System.EventHandler(this.btnMyAds_Click);
            // 
            // btnModeration
            // 
            this.btnModeration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModeration.Location = new System.Drawing.Point(800, 200);
            this.btnModeration.Name = "btnModeration";
            this.btnModeration.Size = new System.Drawing.Size(120, 30);
            this.btnModeration.TabIndex = 6;
            this.btnModeration.Text = "Модерация";
            this.btnModeration.UseVisualStyleBackColor = true;
            this.btnModeration.Click += new System.EventHandler(this.btnModeration_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.btnModeration);
            this.Controls.Add(this.btnMyAds);
            this.Controls.Add(this.btnMyProfile);
            this.Controls.Add(this.btnCreateAd);
            this.Controls.Add(this.dgvAdvertisements);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblWelcome);
            this.MinimumSize = new System.Drawing.Size(950, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервис объявлений";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvertisements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.DataGridView dgvAdvertisements;
        private System.Windows.Forms.Button btnCreateAd;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnMyAds;
        private System.Windows.Forms.Button btnModeration;
    }
}