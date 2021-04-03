using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Server_Controller
{
    public class INIReader
    {
        public static Dictionary<int, ItemIniData> items = new Dictionary<int, ItemIniData>();
        public static Dictionary<int, SkillIniData> skills = new Dictionary<int, SkillIniData>();

        private static bool loadSuccess = true;

        public static void BuildDictionaries()
        {
            if (File.Exists(Config.serverPath + "/skill.ini"))
            {
                BuildSkills();
            }
            else
            {
                frmMain.Main.AddLog("ERROR: Server Path Invalid. Check the config file.");
                loadSuccess = false;
            }

            if (File.Exists(Config.serverPath + "/item.ini"))
            {
                ReadItemIni();
            }
            else
            {
                frmMain.Main.AddLog("ERROR: Server Path Invalid. Check the config file.");
                loadSuccess = false;
            }

            if (loadSuccess)
                frmMain.Main.AddLog("Server Path Successful");
        }

        public static void BuildSkills()
        {
            const string skillIdConfig = "Skill";
            const string skillNameConfig = "Name";
            const string skillStrConfig = "Str";
            const string skillDexConfig = "Dex";
            const string skillQuickConfig = "Quick";
            const string skillIntelConfig = "Intel";
            const string skillWisdomConfig = "Wisdom";
            const string skillDivisorConfig = "Divisor";

            int skillId = 0;

            StreamReader file = new StreamReader(Config.serverPath + "/skill.ini");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith(";"))
                {
                    string[] splitLine = line.Split('=');

                    switch (splitLine[0])
                    {
                        case skillIdConfig:
                            skillId = Convert.ToInt32(splitLine[1]);
                            break;
                        case skillNameConfig:
                            if (skillId == 0)
                            {
                                frmMain.Main.AddLog("ERROR: Error in skill.ini.");
                                loadSuccess = false;
                                return;
                            }
                            skills[skillId] = new SkillIniData();
                            skills[skillId].name = splitLine[1];
                            break;
                        case skillStrConfig:
                            skills[skillId].strength = Convert.ToByte(splitLine[1]);
                            break;
                        case skillDexConfig:
                            skills[skillId].dexterity = Convert.ToByte(splitLine[1]);
                            break;
                        case skillQuickConfig:
                            skills[skillId].quickness = Convert.ToByte(splitLine[1]);
                            break;
                        case skillIntelConfig:
                            skills[skillId].intelligence = Convert.ToByte(splitLine[1]);
                            break;
                        case skillWisdomConfig:
                            skills[skillId].wisdom = Convert.ToByte(splitLine[1]);
                            break;
                        case skillDivisorConfig:
                            skills[skillId].divisor = Convert.ToByte(splitLine[1]);
                            break;
                    }
                }
            }
        }

        public static void ReadItemIni()
        {
            const string itemIdConfig = "Item";
            const string itemNameConfig = "Name";
            const string itemAnimationConfig = "Animation";
            int itemId = 0;

            StreamReader file = new StreamReader(Config.serverPath + "/item.ini");
            string line;
            int animationFrame = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith(";"))
                {
                    string[] splitLine = line.Split('=');
                    switch (splitLine[0])
                    {
                        case itemIdConfig:
                            animationFrame = 0;
                            itemId = Convert.ToInt32(splitLine[1]);
                            items[itemId] = new ItemIniData();
                            break;
                        case itemNameConfig:
                            if (itemId == 0)
                            {
                                frmMain.Main.AddLog("ERROR: Error in item.ini.");
                                loadSuccess = false;
                                return;
                            }
                            if (splitLine[1].Contains("'"))
                                splitLine[1].Replace("'", "''");
                            items[itemId].itemName = splitLine[1];
                            break;
                    }

                    //if (splitLine[0] == itemAnimationConfig + animationFrame)
                    //{
                    //    items[itemId].itemImages.Add(Convert.ToInt32(splitLine[1]));
                    //    animationFrame++;
                    //}
                }
            }

            SQLWriter.UpdateItemIniData();

        }
    }
}
