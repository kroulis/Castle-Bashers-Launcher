using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Kroulis.Error
{
    
    class Error
    {
        public static string GetErrorInfo(string ErrorID)
        {
            if(ErrorID=="E10001")
            {
                return "Config do not Exist. Please run Launcher first.";
            }
            else if(ErrorID=="E10002")
            {
                return "Character Data do not Exist. Please Create the character first.";
            }
            else if(ErrorID=="E10003")
            {
                return "Verify the character data failed. Did you change the data?";
            }
            else if(ErrorID=="E10004")
            {
                return "Runtime Error. Please describe what happened and click submit.";
            }
            else if(ErrorID=="E10005")
            {
                return "File missing. Please run the repair tool to repair the game.";
            }
            else if(ErrorID=="E10006")
            {
                return "System Error. Please check if your system meet the prerequire.";
            }
            else if(ErrorID=="B99999")
            {
                return "Welcome to submit the bug you think. Please remember to attach you email in the describe.";
            }

            return "Unknown Error. Please describe what happened and click submit.";

        }
    }

    class ErrorData
    {
        private XmlDocument ErrorEX = new XmlDocument();
        public string path = System.AppDomain.CurrentDomain.BaseDirectory;
        private string ErrorID="";
        private string LogInfo="";
        private string Stack = "";
        private string SystemInfo = "";

        public bool ReadErrorData()
        {
            if (File.Exists(path + "/error.dat") == false)
                return false;
            ErrorEX.Load(path+"/error.dat");
            //Create Root
            XmlNode root = ErrorEX.SelectSingleNode("errorcatch");
            if (root == null)
                return false;
            XmlNodeList list = root.ChildNodes;
            foreach(XmlElement xl in list)
            {
                if(xl.Name=="eid")
                {
                    ErrorID = xl.InnerText;
                    continue;
                }
                if (xl.Name == "log")
                {
                    LogInfo = xl.InnerText;
                    continue;
                }
                if (xl.Name == "detail")
                {
                    Stack = xl.InnerText;
                    continue;
                }
                if (xl.Name == "info")
                {
                    SystemInfo = xl.InnerText;
                    continue;
                }
            }
            return true;
        }

        public string GetErrorID()
        {
            return ErrorID;
        }

        public string GetDescribe()
        {
            return "Log info:\n" + LogInfo + "\nStack:\n"+Stack+"\nSystem info:\n"+SystemInfo;
        }

        public void DeleteData()
        {
            File.Delete(path + "/error.dat");
        }
    }
}
