namespace AdvertServiceClient
{
    partial class ChatForm
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
            this.components = new System.ComponentModel.Container();
            this.lblAdTitle = new System.Windows.Forms.Label();
            this.lblAdPrice = new System.Windows.Forms.Label();
            this.flowLayoutPanelMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.timerMessages = new System.Windows.Forms.Timer(this.components);
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
            // lblAdPrice
            // 
            this.lblAdPrice.AutoSize = true;
            this.lblAdPrice.Location = new System.Drawing.Point(20, 50);
            this.lblAdPrice.Name = "lblAdPrice";
            this.lblAdPrice.Size = new System.Drawing.Size(35, 13);
            this.lblAdPrice.TabIndex = 1;
            this.lblAdPrice.Text = "label2";
            // 
            // flowLayoutPanelMessages
            // 
            this.flowLayoutPanelMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMessages.AutoScroll = true;
            this.flowLayoutPanelMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMessages.Location = new System.Drawing.Point(20, 80);
            this.flowLayoutPanelMessages.Name = "flowLayoutPanelMessages";
            this.flowLayoutPanelMessages.Size = new System.Drawing.Size(460, 300);
            this.flowLayoutPanelMessages.TabIndex = 2;
            this.flowLayoutPanelMessages.WrapContents = false;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(20, 390);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(360, 60);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(390, 390);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 60);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // timerMessages
            // 
            this.timerMessages.Interval = 5000;
            this.timerMessages.Tick += new System.EventHandler(this.timerMessages_Tick);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 470);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.flowLayoutPanelMessages);
            this.Controls.Add(this.lblAdPrice);
            this.Controls.Add(this.lblAdTitle);
            this.MinimumSize = new System.Drawing.Size(516, 509);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAdTitle;
        private System.Windows.Forms.Label lblAdPrice;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer timerMessages;
    }
}