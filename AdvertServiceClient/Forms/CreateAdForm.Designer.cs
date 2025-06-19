namespace AdvertServiceClient
{
    partial class CreateAdForm
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblLocationId = new System.Windows.Forms.Label();
            this.txtLocationId = new System.Windows.Forms.TextBox();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Заголовок:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(120, 17);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 47);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 100);
            this.txtDescription.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 160);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Цена:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(120, 157);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 190);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(120, 187);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 7;
            // 
            // lblLocationId
            // 
            this.lblLocationId.AutoSize = true;
            this.lblLocationId.Location = new System.Drawing.Point(20, 220);
            this.lblLocationId.Name = "lblLocationId";
            this.lblLocationId.Size = new System.Drawing.Size(104, 13);
            this.lblLocationId.TabIndex = 8;
            this.lblLocationId.Text = "ID местоположения:";
            // 
            // txtLocationId
            // 
            this.txtLocationId.Location = new System.Drawing.Point(120, 217);
            this.txtLocationId.Name = "txtLocationId";
            this.txtLocationId.Size = new System.Drawing.Size(100, 20);
            this.txtLocationId.TabIndex = 9;
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(20, 250);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(77, 13);
            this.lblExpiration.TabIndex = 10;
            this.lblExpiration.Text = "Дата истечения:";
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.Checked = false;
            this.dtpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiration.Location = new System.Drawing.Point(120, 247);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.ShowCheckBox = true;
            this.dtpExpiration.Size = new System.Drawing.Size(120, 20);
            this.dtpExpiration.TabIndex = 11;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(150, 290);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 30);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // CreateAdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 340);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dtpExpiration);
            this.Controls.Add(this.lblExpiration);
            this.Controls.Add(this.txtLocationId);
            this.Controls.Add(this.lblLocationId);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateAdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание объявления";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblLocationId;
        private System.Windows.Forms.TextBox txtLocationId;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.Button btnCreate;
    }
}