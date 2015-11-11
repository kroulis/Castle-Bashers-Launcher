using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Security.Cryptography;
using System.IO;
using Kroulis.Verify;
using System.Runtime.InteropServices;


namespace Launcher_Active
{
    public interface ILauncher
    {
        bool WriteConfig(int solution, int full_screen); //When there is no Config, Write the config.
        bool ChangeConfig(int solution, int full_screen);//When the user changed the Config, use this method.
        string GetSolution();// Get the Screen Solution from the config.
        string GetFullScreenMode();// Get the Full Screen Mode from the config.
        void CreateNewCharacter(string player_id, string class_id, string player_name);//When there is no character data, create a new player.
        string GetPlayerID();// Get the Character ID from the config.
        bool ImportData(int solution, int full_screen, string player_id, string filename);//When the user import the saved data, use this method.
        bool CheckDataExist();// Check if the Save Data Exist
        string GetFileName();// Get the save file name from the config
        
    }
    [ClassInterface(ClassInterfaceType.None)]
    public class Launcher : ILauncher
    {
        public bool WriteConfig(int solution,int full_screen)
        {
            XmlDocument Config = new XmlDocument();
            //Create Declare
            XmlDeclaration vs= Config.CreateXmlDeclaration("1.0","UTF-8",null);
            Config.AppendChild(vs);
            //Create Solution
            XmlNode root = Config.CreateElement("config");
            Config.AppendChild(root);
            XmlNode screen_resolution = Config.CreateElement("screen_resolution");
            screen_resolution.InnerText = solution.ToString();
            root.AppendChild(screen_resolution);
            XmlNode fullscreen = Config.CreateElement("full_screen");
            fullscreen.InnerText = full_screen.ToString();
            root.AppendChild(fullscreen);
            XmlNode RefreshRate = Config.CreateElement("RefreshRate");
            fullscreen.InnerText = "0";
            root.AppendChild(RefreshRate);
            XmlNode playerid = Config.CreateElement("playerid");
            playerid.InnerText = "0";
            root.AppendChild(playerid);
            XmlNode savefile = Config.CreateElement("savefile");
            savefile.InnerText = "null";
            root.AppendChild(savefile);
            Config.Save(Directory.GetCurrentDirectory() + "/config.xml");
            if(File.Exists(Directory.GetCurrentDirectory() + "/config.xml"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangeConfig(int solution,int full_screen)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                return false;
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if(xl.Name=="screen_resolution")
                {
                    xl.InnerText = solution.ToString();
                    continue;
                }
                if(xl.Name=="full_screen")
                {
                    xl.InnerText = full_screen.ToString();
                    continue;
                }
            }
            Config.Save(Directory.GetCurrentDirectory() + "/config.xml");
            return true;
        }
        public string GetSolution()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                return "Load:" + Directory.GetCurrentDirectory() + "/config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "screen_resolution")
                {
                    return xl.InnerText;
                }
            }
            return "No Result.";
        }

        public string GetFullScreenMode()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                return "Load:" + Directory.GetCurrentDirectory() + "/config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "full_screen")
                {
                    return xl.InnerText;
                }
            }
            return "No Result.";
        }

        public string GetPlayerID()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                return "Load:" + Directory.GetCurrentDirectory() + "/config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "playerid")
                {
                    return xl.InnerText;
                }
            }
            return "No Result.";
        }

        public void CreateNewCharacter(string player_id,string class_id,string player_name)
        {
            XmlDocument character_data = new XmlDocument();
            //Set Declaration
            XmlDeclaration xmldec = character_data.CreateXmlDeclaration("1.0", "UTF-8", null);
            character_data.AppendChild(xmldec);
            //create root node
            XmlElement root = character_data.CreateElement("datacounter");
            character_data.AppendChild(root);
            //create player1 node
            XmlElement data = character_data.CreateElement("data");
            data.SetAttribute("id", "1");
            root.AppendChild(data);
            //write infomation
            XmlElement pid = character_data.CreateElement("pid");
            pid.InnerText = player_id;
            XmlElement c_name = character_data.CreateElement("name");
            c_name.InnerText = player_name;
            XmlElement cid = character_data.CreateElement("cid");
            cid.InnerText = class_id;
            XmlElement lv = character_data.CreateElement("lv");
            lv.InnerText = "1";
            XmlElement exp = character_data.CreateElement("exp");
            exp.InnerText = "0";
            XmlElement gold = character_data.CreateElement("gold");
            gold.InnerText = "0";
            XmlElement weapon_level = character_data.CreateElement("weapon_level");
            weapon_level.InnerText = "0";
            XmlElement armor_level = character_data.CreateElement("armor_level");
            armor_level.InnerText = "0";
            XmlElement accessories_level = character_data.CreateElement("accessories_level");
            accessories_level.InnerText = "0";
            XmlElement atk = character_data.CreateElement("atk");
            atk.InnerText = "10";
            XmlElement def = character_data.CreateElement("def");
            def.InnerText = "10";
            XmlElement sta = character_data.CreateElement("sta");
            sta.InnerText = "10";
            XmlElement spi = character_data.CreateElement("spi");
            spi.InnerText = "10";
            XmlElement agi = character_data.CreateElement("agi");
            agi.InnerText = "10";
            XmlElement map = character_data.CreateElement("map");
            map.InnerText = "3";
            data.AppendChild(pid);
            data.AppendChild(c_name);
            data.AppendChild(cid);
            data.AppendChild(lv);
            data.AppendChild(gold);
            data.AppendChild(weapon_level);
            data.AppendChild(armor_level);
            data.AppendChild(accessories_level);
            data.AppendChild(atk);
            data.AppendChild(def);
            data.AppendChild(sta);
            data.AppendChild(spi);
            data.AppendChild(agi);
            data.AppendChild(map);
            //player2 (ignore)

            //save file to a temporary place
            character_data.Save(Directory.GetCurrentDirectory() + "/saving.xml");
            //encrypt
            string md5;
            md5 = FileVerify.getFileHash(Directory.GetCurrentDirectory() + "/saving.xml");
            File.Move(Directory.GetCurrentDirectory() + "/saving.xml", Directory.GetCurrentDirectory() + "/CB" + md5 + "D.xml");
            if (File.Exists(Directory.GetCurrentDirectory() + "/saving.xml"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/saving.xml");
            }
            //Change File Infomation
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNode config = Config.SelectSingleNode("config");
            XmlNodeList findresult = config.ChildNodes;
            foreach (XmlElement xl in findresult)
            {
                if (xl.Name == "playerid")
                {
                    xl.InnerText = player_id;
                    continue;
                }

                if (xl.Name == "savefile")
                {
                    xl.InnerText = "CB" + md5 + "D.xml";
                    continue;
                }
            }
            Config.Save(Directory.GetCurrentDirectory() + "/config.xml");


        }

        public bool ImportData(int solution, int full_screen,string player_id,string filename)
        {
            if(File.Exists(Directory.GetCurrentDirectory() + "/"+filename)==false)
                return false;
            XmlDocument Config = new XmlDocument();
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                WriteConfig(solution, full_screen);
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "playerid")
                {
                    xl.InnerText = player_id;
                    continue;
                }
                if (xl.Name == "savefile")
                {
                    xl.InnerText = filename;
                    continue;
                }
            }
            Config.Save(Directory.GetCurrentDirectory() + "/config.xml");
            return true;
        }

        public bool CheckDataExist()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                return false;
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "savefile")
                {
                    if (xl.InnerText == "null")
                        return false;
                    if (File.Exists(Directory.GetCurrentDirectory() + "/" + xl.InnerText) == false)
                        return false;
                    return true;
                }
            }
            return false;
        }

        public string GetFileName()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/config.xml") == false)
                return "Load:" + Directory.GetCurrentDirectory() + "/config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(Directory.GetCurrentDirectory() + "/config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "savefile")
                {
                    return xl.InnerText;
                }
            }
            return "No Result.";
        }
    }
}
