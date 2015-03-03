namespace CipherUtils
{
    partial class UserForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISADMIN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ENCRYPT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ENCRYPTDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DECRYPT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DECRYPTDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.btnOutputKey = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(302, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(367, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(93, 242);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.USERNAME,
            this.PASSWORD,
            this.ISADMIN,
            this.ENCRYPT,
            this.ENCRYPTDATE,
            this.DECRYPT,
            this.DECRYPTDATE});
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.RowHeadersWidth = 20;
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(428, 216);
            this.dataGridViewMain.TabIndex = 3;
            this.dataGridViewMain.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellContentDoubleClick);
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "用户名";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 90;
            // 
            // PASSWORD
            // 
            this.PASSWORD.DataPropertyName = "PASSWORD";
            this.PASSWORD.HeaderText = "密码";
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.ReadOnly = true;
            this.PASSWORD.Visible = false;
            // 
            // ISADMIN
            // 
            this.ISADMIN.DataPropertyName = "ISADMIN";
            this.ISADMIN.HeaderText = "管理员";
            this.ISADMIN.Name = "ISADMIN";
            this.ISADMIN.ReadOnly = true;
            this.ISADMIN.Width = 50;
            // 
            // ENCRYPT
            // 
            this.ENCRYPT.DataPropertyName = "ENCRYPT";
            this.ENCRYPT.HeaderText = "加密";
            this.ENCRYPT.Name = "ENCRYPT";
            this.ENCRYPT.ReadOnly = true;
            this.ENCRYPT.Width = 40;
            // 
            // ENCRYPTDATE
            // 
            this.ENCRYPTDATE.DataPropertyName = "ENCRYPTDATE";
            dataGridViewCellStyle1.NullValue = null;
            this.ENCRYPTDATE.DefaultCellStyle = dataGridViewCellStyle1;
            this.ENCRYPTDATE.HeaderText = "加密有效期";
            this.ENCRYPTDATE.Name = "ENCRYPTDATE";
            this.ENCRYPTDATE.ReadOnly = true;
            this.ENCRYPTDATE.Width = 90;
            // 
            // DECRYPT
            // 
            this.DECRYPT.DataPropertyName = "DECRYPT";
            this.DECRYPT.HeaderText = "解密";
            this.DECRYPT.Name = "DECRYPT";
            this.DECRYPT.ReadOnly = true;
            this.DECRYPT.Width = 40;
            // 
            // DECRYPTDATE
            // 
            this.DECRYPTDATE.DataPropertyName = "DECRYPTDATE";
            this.DECRYPTDATE.HeaderText = "解密有效期";
            this.DECRYPTDATE.Name = "DECRYPTDATE";
            this.DECRYPTDATE.ReadOnly = true;
            this.DECRYPTDATE.Width = 90;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.dataGridViewMain);
            this.groupBoxMain.Location = new System.Drawing.Point(3, 0);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(434, 236);
            this.groupBoxMain.TabIndex = 4;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "用户列表";
            // 
            // btnOutputKey
            // 
            this.btnOutputKey.Location = new System.Drawing.Point(12, 242);
            this.btnOutputKey.Name = "btnOutputKey";
            this.btnOutputKey.Size = new System.Drawing.Size(75, 23);
            this.btnOutputKey.TabIndex = 3;
            this.btnOutputKey.Text = "导出密钥";
            this.btnOutputKey.UseVisualStyleBackColor = true;
            this.btnOutputKey.Click += new System.EventHandler(this.btnOutputKey_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(158, 242);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(59, 23);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // UserForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(439, 275);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnOutputKey);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.groupBoxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASSWORD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISADMIN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ENCRYPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENCRYPTDATE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DECRYPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DECRYPTDATE;
        private System.Windows.Forms.Button btnOutputKey;
        private System.Windows.Forms.Button btnDel;
    }
}