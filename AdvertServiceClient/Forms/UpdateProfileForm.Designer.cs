namespace AdvertServiceClient
{
    partial class UpdateProfileForm
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblLocationId = new System.Windows.Forms.Label();
            this.txtLocationId = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 50);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 13);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 47);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(160, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // lblLocationId
            // 
            this.lblLocationId.AutoSize = true;
            this.lblLocationId.Location = new System.Drawing.Point(20, 80);
            this.lblLocationId.Name = "lblLocationId";
            this.lblLocationId.Size = new System.Drawing.Size(104, 13);
            this.lblLocationId.TabIndex = 4;
            this.lblLocationId.Text = "ID местоположения:";
            // 
            // txtLocationId
            // 
            this.txtLocationId.Location = new System.Drawing.Point(120, 77);
            this.txtLocationId.Name = "txtLocationId";
            this.txtLocationId.Size = new System.Drawing.Size(100, 20);
            this.txtLocationId.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(120, 110);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // UpdateProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 160);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtLocationId);
            this.Controls.Add(this.lblLocationId);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование профиля";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblLocationId;
        private System.Windows.Forms.TextBox txtLocationId;
        private System.Windows.Forms.Button btnUpdate;
    }
}