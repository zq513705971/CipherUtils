namespace CipherUtils
{
    partial class KeyLoadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyLoadForm));
            this.lbMassage = new System.Windows.Forms.Label();
            this.pictureBoxWarm = new System.Windows.Forms.PictureBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbTag = new System.Windows.Forms.Label();
            this.lbTagAdmin = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarm)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMassage
            // 
            this.lbMassage.AutoSize = true;
            this.lbMassage.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lbMassage.Location = new System.Drawing.Point(74, 15);
            this.lbMassage.Name = "lbMassage";
            this.lbMassage.Size = new System.Drawing.Size(180, 19);
            this.lbMassage.TabIndex = 0;
            this.lbMassage.Text = "未检测到可用文件!";
            // 
            // pictureBoxWarm
            // 
            this.pictureBoxWarm.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWarm.Image")));
            this.pictureBoxWarm.Location = new System.Drawing.Point(10, 13);
            this.pictureBoxWarm.Name = "pictureBoxWarm";
            this.pictureBoxWarm.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxWarm.TabIndex = 1;
            this.pictureBoxWarm.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(202, 103);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(48, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(48, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbTag
            // 
            this.lbTag.AutoSize = true;
            this.lbTag.Location = new System.Drawing.Point(76, 67);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(197, 12);
            this.lbTag.TabIndex = 4;
            this.lbTag.Text = "如果您不是管理员，请联系管理员！";
            // 
            // lbTagAdmin
            // 
            this.lbTagAdmin.AutoSize = true;
            this.lbTagAdmin.Location = new System.Drawing.Point(76, 51);
            this.lbTagAdmin.Name = "lbTagAdmin";
            this.lbTagAdmin.Size = new System.Drawing.Size(185, 12);
            this.lbTagAdmin.TabIndex = 5;
            this.lbTagAdmin.Text = "管理员初次使用请点击创建按钮！";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(153, 103);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(48, 23);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "创建";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // KeyLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 138);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.lbTagAdmin);
            this.Controls.Add(this.lbTag);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.pictureBoxWarm);
            this.Controls.Add(this.lbMassage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "警告";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMassage;
        private System.Windows.Forms.PictureBox pictureBoxWarm;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbTag;
        private System.Windows.Forms.Label lbTagAdmin;
        private System.Windows.Forms.Button btnInit;
    }
}