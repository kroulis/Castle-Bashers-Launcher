namespace Castle_Bashers_Launcher
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
            this.BackGround = new System.Windows.Forms.PictureBox();
            this.StartGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartGame)).BeginInit();
            this.SuspendLayout();
            // 
            // BackGround
            // 
            this.BackGround.Image = global::Castle_Bashers_Launcher.Properties.Resources.Main;
            this.BackGround.Location = new System.Drawing.Point(0, 0);
            this.BackGround.Margin = new System.Windows.Forms.Padding(0);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(1280, 720);
            this.BackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackGround.TabIndex = 0;
            this.BackGround.TabStop = false;
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.Transparent;
            this.StartGame.BackgroundImage = global::Castle_Bashers_Launcher.Properties.Resources.Button_StartGame1;
            this.StartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.StartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartGame.Location = new System.Drawing.Point(922, 180);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(200, 42);
            this.StartGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StartGame.TabIndex = 1;
            this.StartGame.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.BackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Castle Bashers Launcher";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackGround;
        private System.Windows.Forms.PictureBox StartGame;


    }
}

