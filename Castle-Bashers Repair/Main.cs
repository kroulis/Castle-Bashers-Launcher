using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Kroulis.Verify;
using System.IO;

namespace Castle_Bashers_Repair
{
    public partial class Main : Form
    {
        Thread th;
        Repair rp = new Repair();
        private int x_axis;
        private int y_axis;
        private bool moving = false;

        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.th = new Thread(new ThreadStart(this.ThreadMethod));
            this.th.Start();

            button1.Visible = false;
            button2.Visible = false;  
        }
        private void ThreadMethod()
        {
            rp.SetVersion("2015111101");
            rp.SetWindowsInformation(this.currentp,this.entirep,this.PText);
            if (File.Exists(rp.path + "repair.dat"))
            {
                DialogResult dr = MessageBox.Show("Find the old repair data. Do you want to continue?", "Old File Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(dr==DialogResult.Yes)
                {
                    CheckSF(rp.OpenFileList(rp.path + "repair.dat"));
                }
                else
                {
                    CheckSF(rp.OpenFileListE("https://www.kroulisworld.com/programs/castlebashers/repair/repair.xml"));
                }
            }
            else
            {
                CheckSF(rp.OpenFileListE("https://www.kroulisworld.com/programs/castlebashers/repair/repair.xml"));
            }
        }  
        public void CheckSF(bool x)
        {
            if (x)
            {
                MessageBox.Show("Repair Success. You can now play the game.", "Success");
                File.Delete(rp.path + "repair.dat");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Repair Failed. Please run this tool again.", "Failed");
                Application.Exit();
            }
                
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                x_axis = MousePosition.X;
                y_axis = MousePosition.Y;
                moving = true;
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x_axis = 0;
                y_axis = 0;
                moving = false;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                this.Left += MousePosition.X - x_axis;
                this.Top += MousePosition.Y - y_axis;
                x_axis = MousePosition.X;
                y_axis = MousePosition.Y;
            }
        }
    }
}
