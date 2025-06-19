namespace AdvertServiceClient
{
    partial class ProcessComplaintForm
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
            this.lblAdDescription = new System.Windows.Forms.Label();
            this.lblAdSeller = new System.Windows.Forms.Label();
            this.lblAdStatus = new System.Windows.Forms.Label();
            this.lblComplaintReason = new System.Windows.Forms.Label();
            this.txtComplaintReason = new System.Windows.Forms.TextBox();
            this.lblResolutionComment = new System.Windows.Forms.Label();
            this.txtResolutionComment = new System.Windows.Forms.TextBox();
            this.chkBanAd = new System.Windows.Forms.CheckBox();
            this.chkBanUser = new System.Windows.Forms.CheckBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
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
            // lblAdDescription
            // 
            this.lblAdDescription.AutoSize = true;
            this.lblAdDescription.Location = new System.Drawing.Point(20, 50);
            this.lblAdDescription.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblAdDescription.Name = "lblAdDescription";
            this.lblAdDescription.Size = new System.Drawing.Size(35, 13);
            this.lblAdDescription.TabIndex = 1;
            this.lblAdDescription.Text = "label2";
            // 
            // lblAdSeller
            // 
            this.lblAdSeller.AutoSize = true;
            this.lblAdSeller.Location = new System.Drawing.Point(20, 100);
            this.lblAdSeller.Name = "lblAdSeller";
            this.lblAdSeller.Size = new System.Drawing.Size(35, 13);
            this.lblAdSeller.TabIndex = 2;
            this.lblAdSeller.Text = "label3";
            // 
            // lblAdStatus
            // 
            this.lblAdStatus.AutoSize = true;
            this.lblAdStatus.Location = new System.Drawing.Point(20, 130);
            this.lblAdStatus.Name = "lblAdStatus";
            this.lblAdStatus.Size = new System.Drawing.Size(35, 13);
            this.lblAdStatus.TabIndex = 3;
            this.lblAdStatus.Text = "label4";
            // 
            // lblComplaintReason
            // 
            this.lblComplaintReason.AutoSize = true;
            this.lblComplaintReason.Location = new System.Drawing.Point(20, 160);
            this.lblComplaintReason.Name = "lblComplaintReason";
            this.lblComplaintReason.Size = new System.Drawing.Size(98, 13);
            this.lblComplaintReason.TabIndex = 4;
            this.lblComplaintReason.Text = "Текст жалобы:";
            // 
            // txtComplaintReason
            // 
            this.txtComplaintReason.Location = new System.Drawing.Point(20, 180);
            this.txtComplaintReason.Multiline = true;
            this.txtComplaintReason.Name = "txtComplaintReason";
            this.txtComplaintReason.ReadOnly = true;
            this.txtComplaintReason.Size = new System.Drawing.Size(400, 60);
            this.txtComplaintReason.TabIndex = 5;
            // 
            // lblResolutionComment
            // 
            this.lblResolutionComment.AutoSize = true;
            this.lblResolutionComment.Location = new System.Drawing.Point(20, 250);
            this.lblResolutionComment.Name = "lblResolutionComment";
            this.lblResolutionComment.Size = new System.Drawing.Size(144, 13);
            this.lblResolutionComment.TabIndex = 6;
            this.lblResolutionComment.Text = "Комментарий модератора:";
            // 
            // txtResolutionComment
            // 
            this.txtResolutionComment.Location = new System.Drawing.Point(20, 270);
            this.txtResolutionComment.Multiline = true;
            this.txtResolutionComment.Name = "txtResolutionComment";
            this.txtResolutionComment.Size = new System.Drawing.Size(400, 60);
            this.txtResolutionComment.TabIndex = 7;
            // 
            // chkBanAd
            // 
            this.chkBanAd.AutoSize = true;
            this.chkBanAd.Location = new System.Drawing.Point(20, 340);
            this.chkBanAd.Name = "chkBanAd";
            this.chkBanAd.Size = new System.Drawing.Size(167, 17);
            this.chkBanAd.TabIndex = 8;
            this.chkBanAd.Text = "Заблокировать объявление";
            this.chkBanAd.UseVisualStyleBackColor = true;
            // 
            // chkBanUser
            // 
            this.chkBanUser.AutoSize = true;
            this.chkBanUser.Location = new System.Drawing.Point(20, 370);
            this.chkBanUser.Name = "chkBanUser";
            this.chkBanUser.Size = new System.Drawing.Size(151, 17);
            this.chkBanUser.TabIndex = 9;
            this.chkBanUser.Text = "Заблокировать пользователя";
            this.chkBanUser.UseVisualStyleBackColor = true;
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(100, 400);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(120, 30);
            this.btnApprove.TabIndex = 10;
            this.btnApprove.Text = "Одобрить жалобу";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(240, 400);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 30);
            this.btnReject.TabIndex = 11;
            this.btnReject.Text = "Отклонить жалобу";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // ProcessComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.chkBanUser);
            this.Controls.Add(this.chkBanAd);
            this.Controls.Add(this.txtResolutionComment);
            this.Controls.Add(this.lblResolutionComment);
            this.Controls.Add(this.txtComplaintReason);
            this.Controls.Add(this.lblComplaintReason);
            this.Controls.Add(this.lblAdStatus);
            this.Controls.Add(this.lblAdSeller);
            this.Controls.Add(this.lblAdDescription);
            this.Controls.Add(this.lblAdTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessComplaintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработка жалобы";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAdTitle;
        private System.Windows.Forms.Label lblAdDescription;
        private System.Windows.Forms.Label lblAdSeller;
        private System.Windows.Forms.Label lblAdStatus;
        private System.Windows.Forms.Label lblComplaintReason;
        private System.Windows.Forms.TextBox txtComplaintReason;
        private System.Windows.Forms.Label lblResolutionComment;
        private System.Windows.Forms.TextBox txtResolutionComment;
        private System.Windows.Forms.CheckBox chkBanAd;
        private System.Windows.Forms.CheckBox chkBanUser;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
    }
}