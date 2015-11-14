namespace Castle_Bashers_Repair
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
            this.currentp = new System.Windows.Forms.ProgressBar();
            this.process1 = new System.Diagnostics.Process();
            this.entirep = new System.Windows.Forms.ProgressBar();
            this.PText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentp
            // 
            this.currentp.BackColor = System.Drawing.SystemColors.Control;
            this.currentp.Location = new System.Drawing.Point(6, 584);
            this.currentp.Name = "currentp";
            this.currentp.Size = new System.Drawing.Size(617, 23);
            this.currentp.TabIndex = 0;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // entirep
            // 
            this.entirep.Location = new System.Drawing.Point(6, 626);
            this.entirep.Name = "entirep";
            this.entirep.Size = new System.Drawing.Size(617, 23);
            this.entirep.TabIndex = 1;
            // 
            // PText
            // 
            this.PText.AutoSize = true;
            this.PText.BackColor = System.Drawing.Color.Transparent;
            this.PText.ForeColor = System.Drawing.Color.Lime;
            this.PText.Location = new System.Drawing.Point(2, 550);
            this.PText.Name = "PText";
            this.PText.Size = new System.Drawing.Size(127, 20);
            this.PText.TabIndex = 2;
            this.PText.Text = "Wait for Repair...";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.Location = new System.Drawing.Point(151, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 86);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start To Repair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(148, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(336, 86);
            this.button2.TabIndex = 4;
            this.button2.Text = "Quit the program";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(632, 717);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PText);
            this.Controls.Add(this.entirep);
            this.Controls.Add(this.currentp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Castal-Bashers Repair";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar currentp;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ProgressBar entirep;
        private System.Windows.Forms.Label PText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

