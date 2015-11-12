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
            Repair rp=new Repair();
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
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Repair Failed. Please run this tool again.", "Failed");
                Application.Exit();
            }
                
        }
    }
}
