namespace CipherUtils
{
    partial class InitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitForm));
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tUserName = new System.Windows.Forms.TextBox();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tEncrypt = new System.Windows.Forms.TextBox();
            this.lbEncrypt = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(38, 18);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(53, 12);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "管理员：";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(26, 39);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(65, 12);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "登录密码：";
            // 
            // tUserName
            // 
            this.tUserName.Enabled = false;
            this.tUserName.Location = new System.Drawing.Point(86, 14);
            this.tUserName.Name = "tUserName";
            this.tUserName.Size = new System.Drawing.Size(123, 21);
            this.tUserName.TabIndex = 2;
            this.tUserName.Text = "administrator";
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(86, 36);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(123, 21);
            this.tPassword.TabIndex = 3;
            this.tPassword.Text = "111111";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(125, 97);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(191, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tEncrypt
            // 
            this.tEncrypt.Location = new System.Drawing.Point(86, 58);
            this.tEncrypt.Name = "tEncrypt";
            this.tEncrypt.PasswordChar = '*';
            this.tEncrypt.Size = new System.Drawing.Size(123, 21);
            this.tEncrypt.TabIndex = 8;
            this.tEncrypt.TextChanged += new System.EventHandler(this.tEncrypt_TextChanged);
            // 
            // lbEncrypt
            // 
            this.lbEncrypt.AutoSize = true;
            this.lbEncrypt.Location = new System.Drawing.Point(14, 61);
            this.lbEncrypt.Name = "lbEncrypt";
            this.lbEncrypt.Size = new System.Drawing.Size(77, 12);
            this.lbEncrypt.TabIndex = 7;
            this.lbEncrypt.Text = "加解密密码：";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.ForeColor = System.Drawing.Color.Red;
            this.lbMsg.Location = new System.Drawing.Point(213, 61);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(41, 12);
            this.lbMsg.TabIndex = 9;
            this.lbMsg.Text = "(*8位)";
            // 
            // InitForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(290, 132);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.tEncrypt);
            this.Controls.Add(this.lbEncrypt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.tUserName);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "管理员初始化";
            this.Load += new System.EventHandler(this.InitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tUserName;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tEncrypt;
        private System.Windows.Forms.Label lbEncrypt;
        private System.Windows.Forms.Label lbMsg;
    }
}