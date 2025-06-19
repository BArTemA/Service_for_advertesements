namespace AdvertServiceClient
{
    partial class MyAdsForm
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
            this.dgvMyAds = new System.Windows.Forms.DataGridView();
            this.btnCreateAd = new System.Windows.Forms.Button();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyAds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMyAds
            // 
            this.dgvMyAds.AllowUserToAddRows = false;
            this.dgvMyAds.AllowUserToDeleteRows = false;
            this.dgvMyAds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMyAds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyAds.Location = new System.Drawing.Point(20, 50);
            this.dgvMyAds.Name = "dgvMyAds";
            this.dgvMyAds.ReadOnly = true;
            this.dgvMyAds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyAds.Size = new System.Drawing.Size(700, 400);
            this.dgvMyAds.TabIndex = 0;
            this.dgvMyAds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyAds_CellDoubleClick);
            // 
            // btnCreateAd
            // 
            this.btnCreateAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAd.Location = new System.Drawing.Point(730, 50);
            this.btnCreateAd.Name = "btnCreateAd";
            this.btnCreateAd.Size = new System.Drawing.Size(120, 30);
            this.btnCreateAd.TabIndex = 1;
            this.btnCreateAd.Text = "Создать объявление";
            this.btnCreateAd.UseVisualStyleBackColor = true;
            this.btnCreateAd.Click += new System.EventHandler(this.btnCreateAd_Click);
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Location = new System.Drawing.Point(20, 20);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(152, 17);
            this.chkIncludeInactive.TabIndex = 2;
            this.chkIncludeInactive.Text = "Показывать неактивные";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            this.chkIncludeInactive.CheckedChanged += new System.EventHandler(this.chkIncludeInactive_CheckedChanged);
            // 
            // MyAdsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 470);
            this.Controls.Add(this.chkIncludeInactive);
            this.Controls.Add(this.btnCreateAd);
            this.Controls.Add(this.dgvMyAds);
            this.MinimumSize = new System.Drawing.Size(886, 509);
            this.Name = "MyAdsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мои объявления";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyAds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvMyAds;
        private System.Windows.Forms.Button btnCreateAd;
        private System.Windows.Forms.CheckBox chkIncludeInactive;
    }
}