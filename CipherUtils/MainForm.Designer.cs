namespace CipherUtils
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.llbDbManager = new System.Windows.Forms.LinkLabel();
            this.lbPassword = new System.Windows.Forms.LinkLabel();
            this.llbUserManager = new System.Windows.Forms.LinkLabel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageEncrypt = new System.Windows.Forms.TabPage();
            this.btnEncryptImport = new System.Windows.Forms.Button();
            this.tEncryptPath = new System.Windows.Forms.TextBox();
            this.lbEncryptPath = new System.Windows.Forms.Label();
            this.btnEncryptSelect = new System.Windows.Forms.Button();
            this.groupBoxEncrypt = new System.Windows.Forms.GroupBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxEncrypt = new System.Windows.Forms.CheckedListBox();
            this.dataGridViewEncrypt = new System.Windows.Forms.DataGridView();
            this.tabPageDecrypt = new System.Windows.Forms.TabPage();
            this.btnDecryptImport = new System.Windows.Forms.Button();
            this.tDecryptPath = new System.Windows.Forms.TextBox();
            this.lbDecryptPath = new System.Windows.Forms.Label();
            this.btnDecryptSelect = new System.Windows.Forms.Button();
            this.groupBoxDecrypt = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxDecrypt = new System.Windows.Forms.CheckedListBox();
            this.dataGridViewDecrypt = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageEncrypt.SuspendLayout();
            this.groupBoxEncrypt.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEncrypt)).BeginInit();
            this.tabPageDecrypt.SuspendLayout();
            this.groupBoxDecrypt.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDecrypt)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.llbDbManager);
            this.panelTop.Controls.Add(this.lbPassword);
            this.panelTop.Controls.Add(this.llbUserManager);
            this.panelTop.Controls.Add(this.lbTitle);
            this.panelTop.Controls.Add(this.pictureBoxMain);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(627, 71);
            this.panelTop.TabIndex = 0;
            // 
            // llbDbManager
            // 
            this.llbDbManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbDbManager.AutoSize = true;
            this.llbDbManager.Location = new System.Drawing.Point(464, 53);
            this.llbDbManager.Name = "llbDbManager";
            this.llbDbManager.Size = new System.Drawing.Size(41, 12);
            this.llbDbManager.TabIndex = 4;
            this.llbDbManager.TabStop = true;
            this.llbDbManager.Text = "数据库";
            this.llbDbManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDbManager_LinkClicked);
            // 
            // lbPassword
            // 
            this.lbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(562, 53);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 12);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.TabStop = true;
            this.lbPassword.Text = "修改密码";
            this.lbPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbPassword_LinkClicked);
            // 
            // llbUserManager
            // 
            this.llbUserManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbUserManager.AutoSize = true;
            this.llbUserManager.Location = new System.Drawing.Point(508, 53);
            this.llbUserManager.Name = "llbUserManager";
            this.llbUserManager.Size = new System.Drawing.Size(53, 12);
            this.llbUserManager.TabIndex = 2;
            this.llbUserManager.TabStop = true;
            this.llbUserManager.Text = "用户管理";
            this.llbUserManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbUserManager_LinkClicked);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.lbTitle.Location = new System.Drawing.Point(90, 24);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(152, 27);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "加解密工具";
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMain.Image")));
            this.pictureBoxMain.Location = new System.Drawing.Point(18, 2);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(67, 64);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lbStatus);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnRun);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 359);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(627, 39);
            this.panelBottom.TabIndex = 1;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(13, 15);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(11, 12);
            this.lbStatus.TabIndex = 2;
            this.lbStatus.Text = ".";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(525, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(444, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "执行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.tabPageEncrypt);
            this.tabControlMain.Controls.Add(this.tabPageDecrypt);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.ItemSize = new System.Drawing.Size(40, 100);
            this.tabControlMain.Location = new System.Drawing.Point(0, 71);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(627, 288);
            this.tabControlMain.TabIndex = 2;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            this.tabControlMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlMain_Selecting);
            // 
            // tabPageEncrypt
            // 
            this.tabPageEncrypt.Controls.Add(this.btnEncryptImport);
            this.tabPageEncrypt.Controls.Add(this.tEncryptPath);
            this.tabPageEncrypt.Controls.Add(this.lbEncryptPath);
            this.tabPageEncrypt.Controls.Add(this.btnEncryptSelect);
            this.tabPageEncrypt.Controls.Add(this.groupBoxEncrypt);
            this.tabPageEncrypt.Location = new System.Drawing.Point(104, 4);
            this.tabPageEncrypt.Name = "tabPageEncrypt";
            this.tabPageEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEncrypt.Size = new System.Drawing.Size(519, 280);
            this.tabPageEncrypt.TabIndex = 0;
            this.tabPageEncrypt.Text = "加密";
            // 
            // btnEncryptImport
            // 
            this.btnEncryptImport.Location = new System.Drawing.Point(431, 5);
            this.btnEncryptImport.Name = "btnEncryptImport";
            this.btnEncryptImport.Size = new System.Drawing.Size(65, 23);
            this.btnEncryptImport.TabIndex = 4;
            this.btnEncryptImport.Text = "导入";
            this.btnEncryptImport.UseVisualStyleBackColor = true;
            this.btnEncryptImport.Click += new System.EventHandler(this.btnEncryptImport_Click);
            // 
            // tEncryptPath
            // 
            this.tEncryptPath.Location = new System.Drawing.Point(79, 6);
            this.tEncryptPath.Name = "tEncryptPath";
            this.tEncryptPath.Size = new System.Drawing.Size(275, 21);
            this.tEncryptPath.TabIndex = 3;
            this.tEncryptPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tEncryptPath_MouseDoubleClick);
            // 
            // lbEncryptPath
            // 
            this.lbEncryptPath.AutoSize = true;
            this.lbEncryptPath.Location = new System.Drawing.Point(8, 12);
            this.lbEncryptPath.Name = "lbEncryptPath";
            this.lbEncryptPath.Size = new System.Drawing.Size(65, 12);
            this.lbEncryptPath.TabIndex = 2;
            this.lbEncryptPath.Text = "文件路径：";
            // 
            // btnEncryptSelect
            // 
            this.btnEncryptSelect.Location = new System.Drawing.Point(360, 5);
            this.btnEncryptSelect.Name = "btnEncryptSelect";
            this.btnEncryptSelect.Size = new System.Drawing.Size(65, 23);
            this.btnEncryptSelect.TabIndex = 1;
            this.btnEncryptSelect.Text = "选择";
            this.btnEncryptSelect.UseVisualStyleBackColor = true;
            this.btnEncryptSelect.Click += new System.EventHandler(this.btnEncryptSelect_Click);
            // 
            // groupBoxEncrypt
            // 
            this.groupBoxEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEncrypt.Controls.Add(this.splitContainerMain);
            this.groupBoxEncrypt.Location = new System.Drawing.Point(7, 36);
            this.groupBoxEncrypt.Name = "groupBoxEncrypt";
            this.groupBoxEncrypt.Size = new System.Drawing.Size(506, 238);
            this.groupBoxEncrypt.TabIndex = 0;
            this.groupBoxEncrypt.TabStop = false;
            this.groupBoxEncrypt.Text = "加密数据";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 17);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.checkedListBoxEncrypt);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dataGridViewEncrypt);
            this.splitContainerMain.Size = new System.Drawing.Size(500, 218);
            this.splitContainerMain.SplitterDistance = 117;
            this.splitContainerMain.TabIndex = 1;
            // 
            // checkedListBoxEncrypt
            // 
            this.checkedListBoxEncrypt.CheckOnClick = true;
            this.checkedListBoxEncrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxEncrypt.FormattingEnabled = true;
            this.checkedListBoxEncrypt.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxEncrypt.Name = "checkedListBoxEncrypt";
            this.checkedListBoxEncrypt.Size = new System.Drawing.Size(117, 218);
            this.checkedListBoxEncrypt.TabIndex = 0;
            this.checkedListBoxEncrypt.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxEncrypt_ItemCheck);
            // 
            // dataGridViewEncrypt
            // 
            this.dataGridViewEncrypt.AllowUserToAddRows = false;
            this.dataGridViewEncrypt.AllowUserToDeleteRows = false;
            this.dataGridViewEncrypt.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEncrypt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEncrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEncrypt.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEncrypt.Name = "dataGridViewEncrypt";
            this.dataGridViewEncrypt.ReadOnly = true;
            this.dataGridViewEncrypt.RowHeadersWidth = 21;
            this.dataGridViewEncrypt.RowTemplate.Height = 23;
            this.dataGridViewEncrypt.Size = new System.Drawing.Size(379, 218);
            this.dataGridViewEncrypt.TabIndex = 0;
            // 
            // tabPageDecrypt
            // 
            this.tabPageDecrypt.Controls.Add(this.btnDecryptImport);
            this.tabPageDecrypt.Controls.Add(this.tDecryptPath);
            this.tabPageDecrypt.Controls.Add(this.lbDecryptPath);
            this.tabPageDecrypt.Controls.Add(this.btnDecryptSelect);
            this.tabPageDecrypt.Controls.Add(this.groupBoxDecrypt);
            this.tabPageDecrypt.Location = new System.Drawing.Point(104, 4);
            this.tabPageDecrypt.Name = "tabPageDecrypt";
            this.tabPageDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDecrypt.Size = new System.Drawing.Size(519, 280);
            this.tabPageDecrypt.TabIndex = 1;
            this.tabPageDecrypt.Text = "解密";
            // 
            // btnDecryptImport
            // 
            this.btnDecryptImport.Location = new System.Drawing.Point(431, 5);
            this.btnDecryptImport.Name = "btnDecryptImport";
            this.btnDecryptImport.Size = new System.Drawing.Size(65, 23);
            this.btnDecryptImport.TabIndex = 9;
            this.btnDecryptImport.Text = "导入";
            this.btnDecryptImport.UseVisualStyleBackColor = true;
            this.btnDecryptImport.Click += new System.EventHandler(this.btnDecryptImport_Click);
            // 
            // tDecryptPath
            // 
            this.tDecryptPath.Location = new System.Drawing.Point(79, 6);
            this.tDecryptPath.Name = "tDecryptPath";
            this.tDecryptPath.Size = new System.Drawing.Size(275, 21);
            this.tDecryptPath.TabIndex = 8;
            this.tDecryptPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tDecryptPath_MouseDoubleClick);
            // 
            // lbDecryptPath
            // 
            this.lbDecryptPath.AutoSize = true;
            this.lbDecryptPath.Location = new System.Drawing.Point(8, 12);
            this.lbDecryptPath.Name = "lbDecryptPath";
            this.lbDecryptPath.Size = new System.Drawing.Size(65, 12);
            this.lbDecryptPath.TabIndex = 7;
            this.lbDecryptPath.Text = "文件路径：";
            // 
            // btnDecryptSelect
            // 
            this.btnDecryptSelect.Location = new System.Drawing.Point(360, 5);
            this.btnDecryptSelect.Name = "btnDecryptSelect";
            this.btnDecryptSelect.Size = new System.Drawing.Size(65, 23);
            this.btnDecryptSelect.TabIndex = 6;
            this.btnDecryptSelect.Text = "选择";
            this.btnDecryptSelect.UseVisualStyleBackColor = true;
            this.btnDecryptSelect.Click += new System.EventHandler(this.btnDecryptSelect_Click);
            // 
            // groupBoxDecrypt
            // 
            this.groupBoxDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDecrypt.Controls.Add(this.splitContainer1);
            this.groupBoxDecrypt.Location = new System.Drawing.Point(7, 36);
            this.groupBoxDecrypt.Name = "groupBoxDecrypt";
            this.groupBoxDecrypt.Size = new System.Drawing.Size(506, 238);
            this.groupBoxDecrypt.TabIndex = 5;
            this.groupBoxDecrypt.TabStop = false;
            this.groupBoxDecrypt.Text = "解密数据";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxDecrypt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewDecrypt);
            this.splitContainer1.Size = new System.Drawing.Size(500, 218);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabIndex = 1;
            // 
            // checkedListBoxDecrypt
            // 
            this.checkedListBoxDecrypt.CheckOnClick = true;
            this.checkedListBoxDecrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxDecrypt.FormattingEnabled = true;
            this.checkedListBoxDecrypt.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxDecrypt.Name = "checkedListBoxDecrypt";
            this.checkedListBoxDecrypt.Size = new System.Drawing.Size(117, 218);
            this.checkedListBoxDecrypt.TabIndex = 0;
            this.checkedListBoxDecrypt.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDecrypt_ItemCheck);
            // 
            // dataGridViewDecrypt
            // 
            this.dataGridViewDecrypt.AllowUserToAddRows = false;
            this.dataGridViewDecrypt.AllowUserToDeleteRows = false;
            this.dataGridViewDecrypt.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDecrypt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDecrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDecrypt.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDecrypt.Name = "dataGridViewDecrypt";
            this.dataGridViewDecrypt.ReadOnly = true;
            this.dataGridViewDecrypt.RowHeadersWidth = 21;
            this.dataGridViewDecrypt.RowTemplate.Height = 23;
            this.dataGridViewDecrypt.Size = new System.Drawing.Size(379, 218);
            this.dataGridViewDecrypt.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 398);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加解密工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageEncrypt.ResumeLayout(false);
            this.tabPageEncrypt.PerformLayout();
            this.groupBoxEncrypt.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEncrypt)).EndInit();
            this.tabPageDecrypt.ResumeLayout(false);
            this.tabPageDecrypt.PerformLayout();
            this.groupBoxDecrypt.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDecrypt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.LinkLabel llbUserManager;
        private System.Windows.Forms.LinkLabel lbPassword;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageEncrypt;
        private System.Windows.Forms.TabPage tabPageDecrypt;
        private System.Windows.Forms.GroupBox groupBoxEncrypt;
        private System.Windows.Forms.Button btnEncryptSelect;
        private System.Windows.Forms.Label lbEncryptPath;
        private System.Windows.Forms.TextBox tEncryptPath;
        private System.Windows.Forms.Button btnEncryptImport;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.CheckedListBox checkedListBoxEncrypt;
        private System.Windows.Forms.DataGridView dataGridViewEncrypt;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMain;
        private System.Windows.Forms.Button btnDecryptImport;
        private System.Windows.Forms.TextBox tDecryptPath;
        private System.Windows.Forms.Label lbDecryptPath;
        private System.Windows.Forms.Button btnDecryptSelect;
        private System.Windows.Forms.GroupBox groupBoxDecrypt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox checkedListBoxDecrypt;
        private System.Windows.Forms.DataGridView dataGridViewDecrypt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.LinkLabel llbDbManager;
    }
}

