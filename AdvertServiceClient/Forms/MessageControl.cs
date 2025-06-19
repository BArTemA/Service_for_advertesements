using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvertServiceClient
{
    public partial class MessageControl : UserControl
    {
        public MessageControl(int senderId, string senderName, string content, DateTime sentDate, bool isOwnMessage)
        {
            InitializeComponent();

            lblSender.Text = senderName;
            lblMessage.Text = content;
            lblTime.Text = sentDate.ToString("g");

            if (isOwnMessage)
            {
                this.BackColor = Color.LightBlue;
                lblSender.TextAlign = ContentAlignment.TopRight;
                lblMessage.TextAlign = ContentAlignment.TopRight;
                lblTime.TextAlign = ContentAlignment.TopRight;
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                lblSender.TextAlign = ContentAlignment.TopLeft;
                lblMessage.TextAlign = ContentAlignment.TopLeft;
                lblTime.TextAlign = ContentAlignment.TopLeft;
            }
        }

        private void InitializeComponent()
        {
            this.lblSender = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblSender
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSender.Location = new System.Drawing.Point(10, 10);
            this.lblSender.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(41, 13);
            this.lblSender.TabIndex = 0;
            this.lblSender.Text = "Отправитель";

            // lblMessage
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(10, 30);
            this.lblMessage.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Сообщение";

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.ForeColor = System.Drawing.Color.Gray;
            this.lblTime.Location = new System.Drawing.Point(10, 50);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Время";

            // MessageControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSender);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "MessageControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(370, 80);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTime;
    }
}