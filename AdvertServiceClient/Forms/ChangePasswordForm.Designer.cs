namespace AdvertServiceClient
{
    partial class ChangePasswordForm
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
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(20, 20);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(91, 13);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Текущий пароль:";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(120, 17);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(160, 20);
            this.txtOldPassword.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(20, 50);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(83, 13);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "Новый пароль:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(120, 47);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(160, 20);
            this.txtNewPassword.TabIndex = 3;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 80);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(100, 13);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Подтверждение:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(120, 77);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(160, 20);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(120, 110);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 30);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Сменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 160);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Смена пароля";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChange;
    }
}