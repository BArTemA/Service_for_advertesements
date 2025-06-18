namespace AdvertServiceClient.Forms
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
            this.dgvAdvertisements = new System.Windows.Forms.DataGridView();
            this.btnViewAdvert = new System.Windows.Forms.Button();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnMyAdverts = new System.Windows.Forms.Button();
            this.btnMyChats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvertisements)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdvertisements
            // 
            this.dgvAdvertisements.AllowUserToAddRows = false;
            this.dgvAdvertisements.AllowUserToDeleteRows = false;
            this.dgvAdvertisements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdvertisements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdvertisements.Location = new System.Drawing.Point(12, 41);
            this.dgvAdvertisements.MultiSelect = false;
            this.dgvAdvertisements.Name = "dgvAdvertisements";
            this.dgvAdvertisements.ReadOnly = true;
            this.dgvAdvertisements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdvertisements.Size = new System.Drawing.Size(760, 408);
            this.dgvAdvertisements.TabIndex = 0;
            // 
            // btnViewAdvert
            // 
            this.btnViewAdvert.Location = new System.Drawing.Point(12, 12);
            this.btnViewAdvert.Name = "btnViewAdvert";
            this.btnViewAdvert.Size = new System.Drawing.Size(100, 23);
            this.btnViewAdvert.TabIndex = 1;
            this.btnViewAdvert.Text = "Просмотреть";
            this.btnViewAdvert.UseVisualStyleBackColor = true;
            this.btnViewAdvert.Click += new System.EventHandler(this.btnViewAdvert_Click);
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMyProfile.Location = new System.Drawing.Point(672, 12);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(100, 23);
            this.btnMyProfile.TabIndex = 2;
            this.btnMyProfile.Text = "Мой профиль";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnMyAdverts
            // 
            this.btnMyAdverts.Location = new System.Drawing.Point(118, 12);
            this.btnMyAdverts.Name = "btnMyAdverts";
            this.btnMyAdverts.Size = new System.Drawing.Size(100, 23);
            this.btnMyAdverts.TabIndex = 3;
            this.btnMyAdverts.Text = "Мои объявления";
            this.btnMyAdverts.UseVisualStyleBackColor = true;
            this.btnMyAdverts.Click += new System.EventHandler(this.btnMyAdverts_Click);
            // 
            // btnMyChats
            // 
            this.btnMyChats.Location = new System.Drawing.Point(224, 12);
            this.btnMyChats.Name = "btnMyChats";
            this.btnMyChats.Size = new System.Drawing.Size(100, 23);
            this.btnMyChats.TabIndex = 4;
            this.btnMyChats.Text = "Мои чаты";
            this.btnMyChats.UseVisualStyleBackColor = true;
            this.btnMyChats.Click += new System.EventHandler(this.btnMyChats_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnMyChats);
            this.Controls.Add(this.btnMyAdverts);
            this.Controls.Add(this.btnMyProfile);
            this.Controls.Add(this.btnViewAdvert);
            this.Controls.Add(this.dgvAdvertisements);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервис объявлений";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvertisements)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdvertisements;
        private System.Windows.Forms.Button btnViewAdvert;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnMyAdverts;
        private System.Windows.Forms.Button btnMyChats;
    }
}