using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Net;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;

namespace Kroulis.Verify
{
    class FileVerify
    {
        public static string getFileHash(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                int len = (int)fs.Length;
                byte[] data = new byte[len];
                fs.Read(data, 0, len);
                fs.Close();
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = md5.ComputeHash(data);
                string fileMD5 = "";
                foreach (byte b in result)
                {
                    fileMD5 += Convert.ToString(b, 16);
                }
                return fileMD5;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
        
    }
    public class Repair
    {
        private int Failed = 0;
        private int FileAmount = 0;
        private XmlDocument verify = new XmlDocument();
        public string path = System.AppDomain.CurrentDomain.BaseDirectory;
        private string version = "";
        private ProgressBar Currentfile_ProgressBar=new ProgressBar();
        private ProgressBar Entire_ProgressBar=new ProgressBar();
        private Label Progress_Label=new Label();


        /// <summary>
        /// Download File from a website
        /// </summary>
        /// <param name="SaveFilePath">Where to save the file.</param>
        /// <param name="UpdaterUrl">The Url of the file you want to download</param>
        /// <returns></returns>
        private bool DownFileUnContinue(string SaveFilePath, string UpdaterUrl)
        {
            if (!System.IO.Directory.Exists(Path.GetDirectoryName(SaveFilePath)))
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(SaveFilePath));

            try
            {
                WebRequest req = WebRequest.Create(UpdaterUrl);
                req.Timeout = 10000;
                req.Method = "HEAD";
                WebResponse res = req.GetResponse();
                if (res.ContentLength > 0)
                {
                    try
                    {
                        WebClient wClient = new WebClient();
                        wClient.DownloadFile(UpdaterUrl, SaveFilePath);
                        wClient.Dispose();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        res.Close();
                    }
                }
                else
                {
                    //SetRate(-1);
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetFileAmount()
        {
            return FileAmount;
        }

        public void SetVersion(string C_Version)
        {
            version = C_Version;
        }

        public bool OpenFileListE(string FilePath)
        {
            if (!DownFileUnContinue(path + "repair.dat", FilePath))
                return false;
            return OpenFileList(path + "repair.dat");
        }

        public void SetWindowsInformation(ProgressBar current,ProgressBar entire,Label text)
        {
            Currentfile_ProgressBar = current;
            Entire_ProgressBar = entire;
            Progress_Label = text;
        }

        public bool OpenFileList(string FilePath)
        {
            if (!File.Exists(FilePath))
                return false;
            verify.Load(FilePath);
            XmlNode root = verify.SelectSingleNode("repair");
            XmlNodeList filelist=root.ChildNodes;
            if (root==null)
                return false;
            XmlElement rootem=(XmlElement)root;
            if (rootem.GetAttribute("version") != version)
            {
                MessageBox.Show("The version of the game is not the same as the version in the server. Please use the Launcher to Update first then Run repair again.", "Version Verify failed");
                Application.Exit();
                return false;
            }
            FileAmount = filelist.Count;
            return StartRepair(filelist);
        }

        public int GetFailedFiles()
        {
            return Failed;
        }

        public bool StartRepair(XmlNodeList filelist)
        {
            int finish = 0;
            int trytimes = 0;
            string filename = "";
            string md5 = "";
            if (Progress_Label == null || Currentfile_ProgressBar == null || Entire_ProgressBar == null)
                return false;
            Entire_ProgressBar.Value = 0;
            foreach (XmlElement xl in filelist)
            {
                Currentfile_ProgressBar.Value = 0;
                filename = xl.GetAttribute("path");
                Progress_Label.Text = "Verifying the file: " + filename + " ...";
                md5=xl.InnerText;
                if(VerifyFile(filename,md5)==false)
                {
                    trytimes = 0;
                    while(true)
                    {
                        trytimes++;
                        if(trytimes>5)
                        {
                            Failed++;
                            Currentfile_ProgressBar.Value = 100;
                            Progress_Label.Text = "Repair the file: " + filename + " Failed!";
                            break;
                        }
                        Currentfile_ProgressBar.Value = 10;
                        Progress_Label.Text = "Downloading the file: " + filename + " ...";
                        Downloader.DownloadFile(path + "download.dat", "https://www.kroulisworld.com/programs/castlebashers/repair/" + filename, Currentfile_ProgressBar, Progress_Label);
                        if (Currentfile_ProgressBar.Value == 60)
                        {
                            if (VerifyFile("download.dat", md5))
                            {
                                Progress_Label.Text = "Repair the file: " + filename + " ...";
                                File.Move(path + "download.dat", path + filename);
                                Currentfile_ProgressBar.Value = 80;
                                if(File.Exists(path+"download.dat"))
                                {
                                    File.Delete(path + "download.dat");
                                }
                                Progress_Label.Text = "Verifying the file: " + filename + " again ...";
                                if (VerifyFile(filename, md5))
                                {
                                    Progress_Label.Text = "Repair the file: " + filename + " Success!";
                                    Currentfile_ProgressBar.Value = 100;
                                    break;
                                }

                            }
                            else
                            {
                                File.Delete(path + "download.dat");
                            }
                        }
                        else
                        {
                            File.Delete(path + "download.dat");
                        }
                    }
                    
                }
                else
                {
                    Progress_Label.Text = filename + " do not need to repair.";
                    Currentfile_ProgressBar.Value = 100;
                }
                finish = finish + 1;
                Entire_ProgressBar.Value = finish * 100 / FileAmount;
            }
            if (Failed > 0)
                MessageBox.Show("There were "+ Failed.ToString()+" files repairing failed.", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            return true;
        }

        public bool VerifyFile(string FilePath,string md5)
        {
            if (File.Exists(path + FilePath) == false)
                return false;
            string vmd5=FileVerify.getFileHash(path + FilePath);
            if (vmd5 != md5)
            {
                Console.Write("File:" + FilePath + "'s MD5 is not right: " + vmd5 + " -> " + md5 + "\n");
                return false;
            }
            return true;
                
        }


    }

    class INIReadWrite
    {
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="lpAppName">欲在其中查找关键字的节点名称</param>
        /// <param name="lpKeyName">欲获取的项名</param>
        /// <param name="lpDefault">指定的项没有找到时返回的默认值</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="def">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public static string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中写入的节点名称</param>
        /// <param name="lpKeyName">欲设置的项名</param>
        /// <param name="lpString">要写入的新字符串</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
    }

    class Downloader
    {
        static long FileLength = 0; //记录文件大小
        static long count = 0;
        static long sPosstion = 0;//本地已下载完的大小

        /// <summary>
        /// 以断点续传方式下载文件
        /// </summary>
        /// <param name="strFileName">下载文件的保存路径</param>
        /// <param name="strUrl">文件下载地址</param>
        public static void DownloadFile(string strFileName, string strUrl, ProgressBar prog, Label text)
        {
            int CompletedLength = 0;//To save the completed lengh
            FileLength = 0;
            count = 0;
            sPosstion = 0;
            string old_text = text.Text;

            FileStream FStream;
            if (File.Exists(strFileName)) //File Exist
            {
                FStream = File.OpenWrite(strFileName);
                sPosstion = FStream.Length;
                FStream.Seek(sPosstion, SeekOrigin.Current);//Move the flow to the place it ends
            }
            else
            {
                FStream = new FileStream(strFileName, FileMode.Create);
                sPosstion = 0;
            }
            //open the internet
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                if (CompletedLength > 0)
                    myRequest.AddRange((int)CompletedLength);//set the range
                //get the data from the internet
                HttpWebResponse webResponse = (HttpWebResponse)myRequest.GetResponse();
                FileLength = webResponse.ContentLength;//get file size
                Stream myStream = webResponse.GetResponseStream();
                byte[] btContent = new byte[1024];
                if (count <= 0) count += sPosstion;

                while ((CompletedLength = myStream.Read(btContent, 0, 1024)) > 0)
                {
                    FStream.Write(btContent, 0, CompletedLength);
                    count += CompletedLength;
                    prog.Value = 10 + (int)(count * 50.00 / FileLength);
                    text.Text = old_text + "  " + (count * 100.00 / FileLength).ToString() + "%";
                }
                FStream.Close();
                myStream.Close();
            }
            catch
            {
                FStream.Close();
            }
        }
    }
    
}
