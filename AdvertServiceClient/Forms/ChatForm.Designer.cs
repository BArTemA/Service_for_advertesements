namespace AdvertServiceClient.Forms
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblChatWith = new System.Windows.Forms.Label();
            this.lblAdvertTitle = new System.Windows.Forms.Label();
            this.lblAdvertPrice = new System.Windows.Forms.Label();
            this.lblAdvertStatus = new System.Windows.Forms.Label();
            this.btnCloseChat = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowMessages
            // 
            this.flowMessages.AutoScroll = true;
            this.flowMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMessages.Location = new System.Drawing.Point(0, 100);
            this.flowMessages.Name = "flowMessages";
            this.flowMessages.Size = new System.Drawing.Size(484, 361);
            this.flowMessages.TabIndex = 0;
            this.flowMessages.WrapContents = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.txtMessage);
            this.panelBottom.Controls.Add(this.btnSend);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 461);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(484, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(12, 14);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(380, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(398, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblChatWith);
            this.panelTop.Controls.Add(this.lblAdvertTitle);
            this.panelTop.Controls.Add(this.lblAdvertPrice);
            this.panelTop.Controls.Add(this.lblAdvertStatus);
            this.panelTop.Controls.Add(this.btnCloseChat);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(484, 100);
            this.panelTop.TabIndex = 2;
            // 
            // lblChatWith
            // 
            this.lblChatWith.AutoSize = true;
            this.lblChatWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChatWith.Location = new System.Drawing.Point(12, 9);
            this.lblChatWith.Name = "lblChatWith";
            this.lblChatWith.Size = new System.Drawing.Size(70, 16);
            this.lblChatWith.TabIndex = 0;
            this.lblChatWith.Text = "Чат с: ...";
            // 
            // lblAdvertTitle
            // 
            this.lblAdvertTitle.AutoSize = true;
            this.lblAdvertTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAdvertTitle.Location = new System.Drawing.Point(12, 35);
            this.lblAdvertTitle.Name = "lblAdvertTitle";
            this.lblAdvertTitle.Size = new System.Drawing.Size(39, 15);
            this.lblAdvertTitle.TabIndex = 1;
            this.lblAdvertTitle.Text = "Товар";
            // 
            // lblAdvertPrice
            // 
            this.lblAdvertPrice.AutoSize = true;
            this.lblAdvertPrice.Location = new System.Drawing.Point(12, 60);
            this.lblAdvertPrice.Name = "lblAdvertPrice";
            this.lblAdvertPrice.Size = new System.Drawing.Size(37, 13);
            this.lblAdvertPrice.TabIndex = 2;
            this.lblAdvertPrice.Text = "Цена:";
            // 
            // lblAdvertStatus
            // 
            this.lblAdvertStatus.AutoSize = true;
            this.lblAdvertStatus.Location = new System.Drawing.Point(12, 80);
            this.lblAdvertStatus.Name = "lblAdvertStatus";
            this.lblAdvertStatus.Size = new System.Drawing.Size(44, 13);
            this.lblAdvertStatus.TabIndex = 3;
            this.lblAdvertStatus.Text = "Статус:";
            // 
            // btnCloseChat
            // 
            this.btnCloseChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseChat.Location = new System.Drawing.Point(398, 9);
            this.btnCloseChat.Name = "btnCloseChat";
            this.btnCloseChat.Size = new System.Drawing.Size(75, 23);
            this.btnCloseChat.TabIndex = 4;
            this.btnCloseChat.Text = "Закрыть чат";
            this.btnCloseChat.UseVisualStyleBackColor = true;
            this.btnCloseChat.Click += new System.EventHandler(this.btnCloseChat_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.flowMessages);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(500, 550);
            this.Name = "ChatForm";
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMessages;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblChatWith;
        private System.Windows.Forms.Label lblAdvertTitle;
        private System.Windows.Forms.Label lblAdvertPrice;
        private System.Windows.Forms.Label lblAdvertStatus;
        private System.Windows.Forms.Button btnCloseChat;
        private System.Windows.Forms.Timer timerRefresh;
    }
}