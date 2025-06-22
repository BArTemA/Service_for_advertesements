namespace AdvertServiceClient
{
    partial class ChatsListForm
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
            this.listViewChats = new System.Windows.Forms.ListView();
            this.columnHeaderAdvert = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUnread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewChats
            // 
            this.listViewChats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAdvert,
            this.columnHeaderUser,
            this.columnHeaderMessage,
            this.columnHeaderDate,
            this.columnHeaderUnread});
            this.listViewChats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChats.FullRowSelect = true;
            this.listViewChats.GridLines = true;
            this.listViewChats.HideSelection = false;
            this.listViewChats.Location = new System.Drawing.Point(0, 0);
            this.listViewChats.Name = "listViewChats";
            this.listViewChats.Size = new System.Drawing.Size(832, 450);
            this.listViewChats.TabIndex = 0;
            this.listViewChats.UseCompatibleStateImageBehavior = false;
            this.listViewChats.View = System.Windows.Forms.View.Details;
            this.listViewChats.DoubleClick += new System.EventHandler(this.listViewChats_DoubleClick);
            // 
            // columnHeaderAdvert
            // 
            this.columnHeaderAdvert.Text = "Объявление";
            this.columnHeaderAdvert.Width = 200;
            // 
            // columnHeaderUser
            // 
            this.columnHeaderUser.Text = "Участник";
            this.columnHeaderUser.Width = 150;
            // 
            // columnHeaderMessage
            // 
            this.columnHeaderMessage.Text = "Последнее сообщение";
            this.columnHeaderMessage.Width = 250;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Дата";
            this.columnHeaderDate.Width = 120;
            // 
            // columnHeaderUnread
            // 
            this.columnHeaderUnread.Text = "Непрочитано";
            this.columnHeaderUnread.Width = 80;
            // 
            // ChatsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.listViewChats);
            this.Name = "ChatsListForm";
            this.Text = "Мои чаты";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListView listViewChats;
        private System.Windows.Forms.ColumnHeader columnHeaderAdvert;
        private System.Windows.Forms.ColumnHeader columnHeaderUser;
        private System.Windows.Forms.ColumnHeader columnHeaderMessage;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderUnread;
    }
}