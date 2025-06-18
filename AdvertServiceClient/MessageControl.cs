using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient.Forms
{
    public partial class MessageControl : UserControl
    {
        public MessageControl(int senderId, string senderName, string content, DateTime sentDate, bool isRead, bool isOwnMessage)
        {
            InitializeComponent();

            lblSender.Text = senderName;
            lblMessage.Text = content;
            lblTime.Text = sentDate.ToString("g");

            if (isOwnMessage)
            {
                this.BackColor = Color.LightBlue;
                lblSender.Text += " (Вы)";
            }

            if (!isRead)
            {
                lblTime.Text += " (не прочитано)";
            }
        }

        private void InitializeComponent()
        {
            this.lblSender = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSender.Location = new System.Drawing.Point(3, 5);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(41, 13);
            this.lblSender.TabIndex = 0;
            this.lblSender.Text = "label1";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 22);
            this.lblMessage.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "label2";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(200, 5);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(23, 12);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "label3";
            // 
            // MessageControl
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSender);
            this.MaximumSize = new System.Drawing.Size(350, 0);
            this.MinimumSize = new System.Drawing.Size(250, 40);
            this.Name = "MessageControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Size = new System.Drawing.Size(250, 40);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTime;
    }
}