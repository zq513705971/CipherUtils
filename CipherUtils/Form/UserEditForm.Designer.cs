namespace CipherUtils
{
    partial class UserEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tUserName = new System.Windows.Forms.TextBox();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.checkBoxEncrypt = new System.Windows.Forms.CheckBox();
            this.checkBoxDecrypt = new System.Windows.Forms.CheckBox();
            this.dateTimePickerEncrypt = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDecrypt = new System.Windows.Forms.DateTimePicker();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(147, 133);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(27, 21);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(53, 12);
            this.lbUserName.TabIndex = 2;
            this.lbUserName.Text = "用户名：";
            // 
            // tUserName
            // 
            this.tUserName.Location = new System.Drawing.Point(86, 18);
            this.tUserName.Name = "tUserName";
            this.tUserName.Size = new System.Drawing.Size(110, 21);
            this.tUserName.TabIndex = 1;
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(203, 22);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(60, 16);
            this.checkBoxAdmin.TabIndex = 2;
            this.checkBoxAdmin.Text = "管理员";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBoxEncrypt
            // 
            this.checkBoxEncrypt.AutoSize = true;
            this.checkBoxEncrypt.Location = new System.Drawing.Point(86, 79);
            this.checkBoxEncrypt.Name = "checkBoxEncrypt";
            this.checkBoxEncrypt.Size = new System.Drawing.Size(48, 16);
            this.checkBoxEncrypt.TabIndex = 4;
            this.checkBoxEncrypt.Text = "加密";
            this.checkBoxEncrypt.UseVisualStyleBackColor = true;
            this.checkBoxEncrypt.CheckedChanged += new System.EventHandler(this.checkBoxEncrypt_CheckedChanged);
            // 
            // checkBoxDecrypt
            // 
            this.checkBoxDecrypt.AutoSize = true;
            this.checkBoxDecrypt.Location = new System.Drawing.Point(86, 102);
            this.checkBoxDecrypt.Name = "checkBoxDecrypt";
            this.checkBoxDecrypt.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDecrypt.TabIndex = 6;
            this.checkBoxDecrypt.Text = "解密";
            this.checkBoxDecrypt.UseVisualStyleBackColor = true;
            this.checkBoxDecrypt.CheckedChanged += new System.EventHandler(this.checkBoxDecrypt_CheckedChanged);
            // 
            // dateTimePickerEncrypt
            // 
            this.dateTimePickerEncrypt.Location = new System.Drawing.Point(140, 77);
            this.dateTimePickerEncrypt.Name = "dateTimePickerEncrypt";
            this.dateTimePickerEncrypt.Size = new System.Drawing.Size(122, 21);
            this.dateTimePickerEncrypt.TabIndex = 5;
            this.dateTimePickerEncrypt.Visible = false;
            // 
            // dateTimePickerDecrypt
            // 
            this.dateTimePickerDecrypt.Location = new System.Drawing.Point(140, 100);
            this.dateTimePickerDecrypt.Name = "dateTimePickerDecrypt";
            this.dateTimePickerDecrypt.Size = new System.Drawing.Size(122, 21);
            this.dateTimePickerDecrypt.TabIndex = 7;
            this.dateTimePickerDecrypt.Visible = false;
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(86, 42);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(110, 21);
            this.tPassword.TabIndex = 3;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(39, 45);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(41, 12);
            this.lbPassword.TabIndex = 9;
            this.lbPassword.Text = "密码：";
            // 
            // UserEditForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(322, 169);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.dateTimePickerDecrypt);
            this.Controls.Add(this.dateTimePickerEncrypt);
            this.Controls.Add(this.checkBoxDecrypt);
            this.Controls.Add(this.checkBoxEncrypt);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.tUserName);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户编辑";
            this.Load += new System.EventHandler(this.UserEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox tUserName;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.CheckBox checkBoxEncrypt;
        private System.Windows.Forms.CheckBox checkBoxDecrypt;
        private System.Windows.Forms.DateTimePicker dateTimePickerEncrypt;
        private System.Windows.Forms.DateTimePicker dateTimePickerDecrypt;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label lbPassword;
    }
}