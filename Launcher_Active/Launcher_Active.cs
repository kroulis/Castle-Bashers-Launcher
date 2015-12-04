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
        /// <summary>
        /// When there is no Config, Write the config.
        /// </summary>
        /// <param name="solution">1:1280*720,2:1368*768,3:1920*1080</param>
        /// <param name="full_screen">0:Normal,1:FullScreen</param>
        /// <returns></returns>
        bool WriteConfig(int solution, int full_screen); 
        /// <summary>
        /// When the user changed the Config, use this method.
        /// </summary>
        /// <param name="solution">1:1280*720,2:1368*768,3:1920*1080</param>
        /// <param name="full_screen">0:Normal,1:FullScreen</param>
        /// <returns></returns>
        bool ChangeConfig(int solution, int full_screen);
        /// <summary>
        /// Get the Screen Solution from the config.
        /// </summary>
        /// <returns></returns>
        string GetSolution();
        /// <summary>
        /// Get the Full Screen Mode from the config.
        /// </summary>
        /// <returns></returns>
        string GetFullScreenMode();
        /// <summary>
        /// When there is no character data, create a new player.
        /// </summary>
        /// <param name="player_id">The player id you got from the website.</param>
        /// <param name="class_id">The class you choose.</param>
        /// <param name="player_name">The name the user input.</param>
        void CreateNewCharacter(string player_id, string class_id, string player_name);
        /// <summary>
        /// Get the Character ID from the config.
        /// </summary>
        /// <returns></returns>
        string GetPlayerID();
        /// <summary>
        /// When the user import the saved data, use this method.
        /// </summary>
        /// <param name="solution">1:1280*720,2:1368*768,3:1920*1080</param>
        /// <param name="full_screen">0:Normal,1:FullScreen</param>
        /// <param name="player_id">The player id you want to import.</param>
        /// <param name="filename">The file path.</param>
        /// <returns></returns>
        bool ImportData(int solution, int full_screen, string player_id, string filename);
        /// <summary>
        /// Check if the Save Data Exist
        /// </summary>
        /// <returns></returns>
        bool CheckDataExist();
        /// <summary>
        /// Get the save file name from the config
        /// </summary>
        /// <returns></returns>
        string GetFileName();
        /// <summary>
        /// Get the Game's version.
        /// </summary>
        /// <returns></returns>
        string GetVersion();
        /// <summary>
        /// Create the second player
        /// </summary>
        /// <param name="player_id">The player id you got from the website.</param>
        /// <param name="class_id">The class you choose.</param>
        /// <param name="player_name">The name the user input.</param>
        void CreateSecondCharacter(string player_id, string class_id, string player_name);
        
    }
    [ClassInterface(ClassInterfaceType.None)]
    public class Launcher : ILauncher
    {
        private string path = System.IO.Directory.GetCurrentDirectory()+"/";
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
            Config.Save(path + "config.xml");
            if(File.Exists(path + "config.xml"))
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
            if (File.Exists(path + "config.xml") == false)
                return false;
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
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
            Config.Save(path + "config.xml");
            return true;
        }
        public string GetSolution()
        {
            if (File.Exists(path + "config.xml") == false)
                return "Load:" + path + "config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
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
            if (File.Exists(path + "config.xml") == false)
                return "Load:" + path + "config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
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
            if (File.Exists(path + "config.xml") == false)
                return "Load:" + path + "config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
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
            character_data.Save(path + "saving.xml");
            //encrypt
            string md5;
            md5 = FileVerify.getFileHash(path + "saving.xml");
            File.Move(path + "saving.xml", path + "CB" + md5 + "D.xml");
            if (File.Exists(path + "saving.xml"))
            {
                File.Delete(path + "saving.xml");
            }
            //Change File Infomation
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
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
            Config.Save(path + "config.xml");


        }

        public bool ImportData(int solution, int full_screen,string player_id,string filename)
        {
            if(File.Exists(path + ""+filename)==false)
                return false;
            XmlDocument Config = new XmlDocument();
            if (File.Exists(path + "config.xml") == false)
                WriteConfig(solution, full_screen);
            Config.Load(path + "config.xml");
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
            Config.Save(path + "config.xml");
            return true;
        }

        public bool CheckDataExist()
        {
            if (File.Exists(path + "config.xml") == false)
                return false;
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "savefile")
                {
                    if (xl.InnerText == "null")
                        return false;
                    if (File.Exists(path + "" + xl.InnerText) == false)
                        return false;
                    return true;
                }
            }
            return false;
        }

        public string GetFileName()
        {
            if (File.Exists(path + "config.xml") == false)
                return "Load:" + path + "config.xml failed.";
            XmlDocument Config = new XmlDocument();
            Config.Load(path + "config.xml");
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

        public string GetVersion()
        {
            XmlDocument VS = new XmlDocument();
            if (File.Exists(path + "version.xml") == false)
            {
                return "Load: " + path + "version.xml Failed.";
            }
            VS.Load(path + "version.xml");
            XmlNode root = VS.SelectSingleNode("version");
            return root.InnerText;
        }

        public void CreateSecondCharacter(string player_id,string class_id,string player_name)
        {
            XmlDocument Config=new XmlDocument();
            string filename="";
            if(CheckDataExist()==false)
            {
                CreateNewCharacter(player_id,class_id,player_name);
                return;
            }
            Config.Load(path + "config.xml");
            XmlNodeList list = Config.SelectSingleNode("config").ChildNodes;
            foreach (XmlElement xl in list)
            {
                if (xl.Name == "savefile")
                {
                    filename=xl.InnerText;
                    break;
                }
            }
            if(filename=="")
            {
                CreateNewCharacter(player_id,class_id,player_name);
                return;
            }
            XmlDocument character_data = new XmlDocument();
            character_data.Load(path + filename);
            //create root node
            XmlNode root = character_data.SelectSingleNode("datacounter");
            //create player2 node
            XmlElement data = character_data.CreateElement("data");
            data.SetAttribute("id", "2");
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
            //save file to a temporary place
            character_data.Save(path + "saving.xml");
            //encrypt
            string md5;
            md5 = FileVerify.getFileHash(path + "saving.xml");
            File.Move(path + "saving.xml", path + "CB" + md5 + "D.xml");
            if (File.Exists(path + "saving.xml"))
            {
                File.Delete(path + "saving.xml");
            }
            //Change File Infomation
            Config = new XmlDocument();
            Config.Load(path + "config.xml");
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
            Config.Save(path + "config.xml");
        }

    }

}
