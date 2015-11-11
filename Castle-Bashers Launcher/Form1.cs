using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Castle_Bashers_Launcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                if(MessageBox.Show("Are you sure to quit the launcher?","Sure to quit?",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        

    }
}
