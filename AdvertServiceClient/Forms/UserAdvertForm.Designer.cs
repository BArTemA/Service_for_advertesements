namespace AdvertServiceClient.Forms
{
    partial class UserAdvertsForm
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
            this.btnToggleInactive = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
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
            // btnToggleInactive
            // 
            this.btnToggleInactive.Location = new System.Drawing.Point(118, 12);
            this.btnToggleInactive.Name = "btnToggleInactive";
            this.btnToggleInactive.Size = new System.Drawing.Size(100, 23);
            this.btnToggleInactive.TabIndex = 2;
            this.btnToggleInactive.Text = "Показать все";
            this.btnToggleInactive.UseVisualStyleBackColor = true;
            this.btnToggleInactive.Click += new System.EventHandler(this.btnToggleInactive_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(672, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UserAdvertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnToggleInactive);
            this.Controls.Add(this.btnViewAdvert);
            this.Controls.Add(this.dgvAdvertisements);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "UserAdvertsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UserAdvertsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvertisements)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdvertisements;
        private System.Windows.Forms.Button btnViewAdvert;
        private System.Windows.Forms.Button btnToggleInactive;
        private System.Windows.Forms.Button btnClose;
    }
}