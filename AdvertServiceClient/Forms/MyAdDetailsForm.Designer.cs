namespace AdvertServiceClient
{
    partial class MyAdDetailsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblViews = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(57, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 50);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(400, 100);
            this.txtDescription.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 160);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Цена:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(120, 157);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 190);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Sold"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 187);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 21);
            this.cmbStatus.TabIndex = 5;
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Location = new System.Drawing.Point(20, 220);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(35, 13);
            this.lblViews.TabIndex = 6;
            this.lblViews.Text = "label2";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(100, 250);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(220, 250);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MyAdDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblViews);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyAdDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мое объявление";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}