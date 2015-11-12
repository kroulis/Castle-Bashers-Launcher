using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Launcher_Active;
using Kroulis.Text;
using Kroulis.Error;
using System.Net;
using System.IO;

namespace Castle_Bashers_Bug_Report
{
    public partial class Main : Form
    {
        private Launcher LH=new Launcher();
        public Main()
        {
            InitializeComponent();
            pid.Text = LH.GetPlayerID();
            if(pid.Text=="" || TextControl.GetStringLeftByLength(pid.Text,4)=="Load")
            {
                Console.Write(pid.Text+"\n");
                pid.Text = "NP00000";
            }
        }

        private void Ignore_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //something empty?
            if (ErrorID.Text == "" || Describe.Text == "")
            {
                MessageBox.Show("Please fill in all the blacks.", "Failed to submit");
                return;
            }
            //Start to post
            Encoding encode = Encoding.GetEncoding("utf-8");
            byte[] arrB = encode.GetBytes("Playerid="+pid.Text+"&ErrorID="+ErrorID.Text+"&Describe="+Describe.Text);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.kroulisworld.com/programs/castlebashers/submitbug.php");
            myReq.Method = "POST";
            myReq.ContentType = "application/x-www-form-urlencoded";
            myReq.ContentLength = arrB.Length;
            Stream outStream = myReq.GetRequestStream();
            outStream.Write(arrB, 0, arrB.Length);
            outStream.Close();

            //Wait for response
            WebResponse myResp = myReq.GetResponse();
            Stream ReceiveStream = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(ReceiveStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            string str = null;
            while (count > 0)
            {
                str += new String(read, 0, count);
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            myResp.Close();
            if (str == "Submit Success.")
            {
                MessageBox.Show("Submit Success. Thank you!", "Success");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Submit Failed. Please retry it or click ignore to quit.", "Failed");
            }
            Console.Write(str);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ErrorInfo.Text = Error.GetErrorInfo(ErrorID.Text);
            if(ErrorID.Text=="B99999")
            {
                ErrorInfo.ForeColor = Color.Green;
            }
            else
            {
                ErrorInfo.ForeColor = Color.Red;
            }
        }
    }
}
