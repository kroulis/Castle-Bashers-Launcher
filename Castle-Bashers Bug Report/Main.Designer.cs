namespace Castle_Bashers_Bug_Report
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.pid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ErrorID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Describe = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.Ignore = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ErrorInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Player ID:";
            // 
            // pid
            // 
            this.pid.AutoSize = true;
            this.pid.Location = new System.Drawing.Point(193, 38);
            this.pid.Name = "pid";
            this.pid.Size = new System.Drawing.Size(76, 20);
            this.pid.TabIndex = 1;
            this.pid.Text = "Unknown";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Error ID:";
            // 
            // ErrorID
            // 
            this.ErrorID.Location = new System.Drawing.Point(197, 72);
            this.ErrorID.Name = "ErrorID";
            this.ErrorID.Size = new System.Drawing.Size(644, 26);
            this.ErrorID.TabIndex = 3;
            this.ErrorID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(461, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please describe what happened when you are playing the game:";
            // 
            // Describe
            // 
            this.Describe.Location = new System.Drawing.Point(49, 175);
            this.Describe.Multiline = true;
            this.Describe.Name = "Describe";
            this.Describe.Size = new System.Drawing.Size(792, 178);
            this.Describe.TabIndex = 5;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(156, 377);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(159, 43);
            this.Submit.TabIndex = 6;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Ignore
            // 
            this.Ignore.Location = new System.Drawing.Point(572, 377);
            this.Ignore.Name = "Ignore";
            this.Ignore.Size = new System.Drawing.Size(159, 43);
            this.Ignore.TabIndex = 7;
            this.Ignore.Text = "Ignore";
            this.Ignore.UseVisualStyleBackColor = true;
            this.Ignore.Click += new System.EventHandler(this.Ignore_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Error Infomation:";
            // 
            // ErrorInfo
            // 
            this.ErrorInfo.AutoSize = true;
            this.ErrorInfo.Location = new System.Drawing.Point(197, 112);
            this.ErrorInfo.Name = "ErrorInfo";
            this.ErrorInfo.Size = new System.Drawing.Size(76, 20);
            this.ErrorInfo.TabIndex = 9;
            this.ErrorInfo.Text = "Unknown";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 433);
            this.Controls.Add(this.ErrorInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Ignore);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Describe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ErrorID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pid);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Castle-Bashers Bug Report";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ErrorID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Describe;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button Ignore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ErrorInfo;
    }
}

