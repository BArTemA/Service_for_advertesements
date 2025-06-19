namespace AdvertServiceClient
{
    partial class ReviewTile
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
            this.lblReviewer = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReviewer
            // 
            this.lblReviewer.AutoSize = true;
            this.lblReviewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblReviewer.Location = new System.Drawing.Point(10, 10);
            this.lblReviewer.Name = "lblReviewer";
            this.lblReviewer.Size = new System.Drawing.Size(41, 13);
            this.lblReviewer.TabIndex = 0;
            this.lblReviewer.Text = "label1";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(10, 30);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(41, 13);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "label2";
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(10, 50);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(280, 60);
            this.lblComment.TabIndex = 2;
            this.lblComment.Text = "label3";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(10, 120);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "label4";
            // 
            // ReviewTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblReviewer);
            this.Name = "ReviewTile";
            this.Size = new System.Drawing.Size(300, 150);
            this.Load += new System.EventHandler(this.ReviewTile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReviewer;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblDate;
    }
}