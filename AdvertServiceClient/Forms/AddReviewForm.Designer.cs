namespace AdvertServiceClient
{
    partial class AddReviewForm
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
            this.lblAdTitle = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.ratingControl1 = new AdvertServiceClient.RatingControl();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAdTitle
            // 
            this.lblAdTitle.AutoSize = true;
            this.lblAdTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAdTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAdTitle.Name = "lblAdTitle";
            this.lblAdTitle.Size = new System.Drawing.Size(52, 17);
            this.lblAdTitle.TabIndex = 0;
            this.lblAdTitle.Text = "label1";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(20, 50);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(35, 13);
            this.lblSeller.TabIndex = 1;
            this.lblSeller.Text = "label2";
            // 
            // ratingControl1
            // 
            this.ratingControl1.Location = new System.Drawing.Point(120, 90);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Size = new System.Drawing.Size(125, 25);
            this.ratingControl1.TabIndex = 2;
            this.ratingControl1.Value = 0;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(20, 90);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(45, 13);
            this.lblRating.TabIndex = 3;
            this.lblRating.Text = "Оценка:";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(20, 130);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(80, 13);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Комментарий:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(20, 150);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(300, 100);
            this.txtComment.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(120, 260);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Отправить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AddReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 310);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.ratingControl1);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.lblAdTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить отзыв";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAdTitle;
        private System.Windows.Forms.Label lblSeller;
        private RatingControl ratingControl1;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSubmit;
    }
}