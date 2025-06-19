namespace AdvertServiceClient
{
    partial class ModerationForm
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
            this.dgvComplaints = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComplaints
            // 
            this.dgvComplaints.AllowUserToAddRows = false;
            this.dgvComplaints.AllowUserToDeleteRows = false;
            this.dgvComplaints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComplaints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaints.Location = new System.Drawing.Point(20, 20);
            this.dgvComplaints.Name = "dgvComplaints";
            this.dgvComplaints.ReadOnly = true;
            this.dgvComplaints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaints.Size = new System.Drawing.Size(800, 450);
            this.dgvComplaints.TabIndex = 0;
            this.dgvComplaints.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComplaints_CellDoubleClick);
            // 
            // ModerationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 490);
            this.Controls.Add(this.dgvComplaints);
            this.MinimumSize = new System.Drawing.Size(856, 529);
            this.Name = "ModerationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Модерация жалоб";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvComplaints;
    }
}