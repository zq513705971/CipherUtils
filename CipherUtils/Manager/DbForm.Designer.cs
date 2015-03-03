namespace CipherUtils
{
    partial class DbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxSQLInput = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxSQL = new System.Windows.Forms.GroupBox();
            this.groupBoxTableList = new System.Windows.Forms.GroupBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxSQL.SuspendLayout();
            this.groupBoxTableList.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupBoxSQL);
            this.panelTop.Controls.Add(this.btnRun);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(594, 138);
            this.panelTop.TabIndex = 0;
            // 
            // textBoxSQLInput
            // 
            this.textBoxSQLInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSQLInput.Location = new System.Drawing.Point(3, 17);
            this.textBoxSQLInput.Multiline = true;
            this.textBoxSQLInput.Name = "textBoxSQLInput";
            this.textBoxSQLInput.Size = new System.Drawing.Size(582, 80);
            this.textBoxSQLInput.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(507, 109);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "执行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // listBoxTables
            // 
            this.listBoxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.ItemHeight = 12;
            this.listBoxTables.Location = new System.Drawing.Point(3, 17);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(123, 210);
            this.listBoxTables.TabIndex = 3;
            this.listBoxTables.SelectedIndexChanged += new System.EventHandler(this.listBoxTables_SelectedIndexChanged);
            this.listBoxTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxTables_MouseDoubleClick);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.RowHeadersWidth = 21;
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.Size = new System.Drawing.Size(455, 210);
            this.dataGridViewMain.TabIndex = 4;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 138);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxTableList);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxResult);
            this.splitContainerMain.Size = new System.Drawing.Size(594, 230);
            this.splitContainerMain.SplitterDistance = 129;
            this.splitContainerMain.TabIndex = 5;
            // 
            // groupBoxSQL
            // 
            this.groupBoxSQL.Controls.Add(this.textBoxSQLInput);
            this.groupBoxSQL.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSQL.Name = "groupBoxSQL";
            this.groupBoxSQL.Size = new System.Drawing.Size(588, 100);
            this.groupBoxSQL.TabIndex = 2;
            this.groupBoxSQL.TabStop = false;
            this.groupBoxSQL.Text = "请在此框输入SQL语句";
            // 
            // groupBoxTableList
            // 
            this.groupBoxTableList.Controls.Add(this.listBoxTables);
            this.groupBoxTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTableList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTableList.Name = "groupBoxTableList";
            this.groupBoxTableList.Size = new System.Drawing.Size(129, 230);
            this.groupBoxTableList.TabIndex = 0;
            this.groupBoxTableList.TabStop = false;
            this.groupBoxTableList.Text = "系统表";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.dataGridViewMain);
            this.groupBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Location = new System.Drawing.Point(0, 0);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(461, 230);
            this.groupBoxResult.TabIndex = 5;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "查询结果";
            // 
            // DbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库管理";
            this.Load += new System.EventHandler(this.DbForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxSQL.ResumeLayout(false);
            this.groupBoxSQL.PerformLayout();
            this.groupBoxTableList.ResumeLayout(false);
            this.groupBoxResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox textBoxSQLInput;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxSQL;
        private System.Windows.Forms.GroupBox groupBoxTableList;
        private System.Windows.Forms.GroupBox groupBoxResult;
    }
}