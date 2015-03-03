namespace CipherUtils
{
    partial class PasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            this.lbOldPassword = new System.Windows.Forms.Label();
            this.tOldPassword = new System.Windows.Forms.TextBox();
            this.tNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tNewPassword2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbOldPassword
            // 
            this.lbOldPassword.AutoSize = true;
            this.lbOldPassword.Location = new System.Drawing.Point(30, 13);
            this.lbOldPassword.Name = "lbOldPassword";
            this.lbOldPassword.Size = new System.Drawing.Size(53, 12);
            this.lbOldPassword.TabIndex = 0;
            this.lbOldPassword.Text = "旧密码：";
            // 
            // tOldPassword
            // 
            this.tOldPassword.Location = new System.Drawing.Point(89, 10);
            this.tOldPassword.Name = "tOldPassword";
            this.tOldPassword.PasswordChar = '*';
            this.tOldPassword.Size = new System.Drawing.Size(142, 21);
            this.tOldPassword.TabIndex = 1;
            // 
            // tNewPassword
            // 
            this.tNewPassword.Location = new System.Drawing.Point(89, 33);
            this.tNewPassword.Name = "tNewPassword";
            this.tNewPassword.PasswordChar = '*';
            this.tNewPassword.Size = new System.Drawing.Size(142, 21);
            this.tNewPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "新密码：";
            // 
            // tNewPassword2
            // 
            this.tNewPassword2.Location = new System.Drawing.Point(89, 56);
            this.tNewPassword2.Name = "tNewPassword2";
            this.tNewPassword2.PasswordChar = '*';
            this.tNewPassword2.Size = new System.Drawing.Size(142, 21);
            this.tNewPassword2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "确认密码：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(156, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PasswordForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 118);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tNewPassword2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tNewPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tOldPassword);
            this.Controls.Add(this.lbOldPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOldPassword;
        private System.Windows.Forms.TextBox tOldPassword;
        private System.Windows.Forms.TextBox tNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tNewPassword2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
    }
}