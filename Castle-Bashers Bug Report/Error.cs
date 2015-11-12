using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
