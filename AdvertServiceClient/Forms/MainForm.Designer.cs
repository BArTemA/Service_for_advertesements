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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateAd = new System.Windows.Forms.Button();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnMyAds = new System.Windows.Forms.Button();
            this.btnModeration = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 350);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCreateAd
            // 
            this.btnCreateAd.Location = new System.Drawing.Point(10, 10);
            this.btnCreateAd.Name = "btnCreateAd";
            this.btnCreateAd.Size = new System.Drawing.Size(120, 30);
            this.btnCreateAd.TabIndex = 1;
            this.btnCreateAd.Text = "Создать объявление";
            this.btnCreateAd.UseVisualStyleBackColor = true;
            this.btnCreateAd.Click += new System.EventHandler(this.btnCreateAd_Click);
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Location = new System.Drawing.Point(140, 10);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(120, 30);
            this.btnMyProfile.TabIndex = 2;
            this.btnMyProfile.Text = "Мой профиль";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnMyAds
            // 
            this.btnMyAds.Location = new System.Drawing.Point(270, 10);
            this.btnMyAds.Name = "btnMyAds";
            this.btnMyAds.Size = new System.Drawing.Size(120, 30);
            this.btnMyAds.TabIndex = 3;
            this.btnMyAds.Text = "Мои объявления";
            this.btnMyAds.UseVisualStyleBackColor = true;
            this.btnMyAds.Click += new System.EventHandler(this.btnMyAds_Click);
            // 
            // btnModeration
            // 
            this.btnModeration.Location = new System.Drawing.Point(400, 10);
            this.btnModeration.Name = "btnModeration";
            this.btnModeration.Size = new System.Drawing.Size(120, 30);
            this.btnModeration.TabIndex = 4;
            this.btnModeration.Text = "Модерация";
            this.btnModeration.UseVisualStyleBackColor = true;
            this.btnModeration.Click += new System.EventHandler(this.btnModeration_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWelcome.Location = new System.Drawing.Point(10, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(57, 20);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "label1";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRating.Location = new System.Drawing.Point(10, 40);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(46, 17);
            this.lblRating.TabIndex = 6;
            this.lblRating.Text = "label2";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnCreateAd);
            this.panelMenu.Controls.Add(this.btnMyProfile);
            this.panelMenu.Controls.Add(this.btnMyAds);
            this.panelMenu.Controls.Add(this.btnModeration);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMenu.Location = new System.Drawing.Point(0, 450);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(800, 50);
            this.panelMenu.TabIndex = 7;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblRating);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 100);
            this.panelHeader.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.Text = "Сервис объявлений";
            this.panelMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCreateAd;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnMyAds;
        private System.Windows.Forms.Button btnModeration;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelHeader;
    }
}