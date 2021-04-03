using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGWO_Server_Controller
{
    public class Config
    {
        private const string serverPathConfig = "ServerPath";
        public static string serverPath;

        private const string exportPathConfig = "ExportPath";
        public static string exportPath;

        private const string broadcast0Config = "Broadcast0";
        public static string broadcast0;

        private const string broadcastTimer0Config = "BroadcastTimer0";
        public static int broadcastTimer0;

        private const string broadcast1Config = "Broadcast1";
        public static string broadcast1;

        private const string broadcastTimer1Config = "BroadcastTimer1";
        public static int broadcastTimer1;

        private const string broadcast2Config = "Broadcast2";
        public static string broadcast2;

        private const string broadcastTimer2Config = "BroadcastTimer2";
        public static int broadcastTimer2;

        private const string onlineIgnoreConfig = "OnlineIgnore";
        public static List<string> onlineIgnores = new List<string>();

        private const string topTenIgnoreConfig = "TopTenIgnore";
        public static List<string> topTenIgnores = new List<string>();

        private const string allIgnoreConfig = "AllIgnore";
        public static List<string> allIgnores = new List<string>();

        private const string sqlIPConfig = "SQL_IP";
        public static string sqlIP;

        private const string sqlPortConfig = "SQL_Port";
        public static string sqlPort;

        private const string sqlDatabaseConfig = "SQL_Database";
        public static string sqlDatabase;

        private const string sqlUserConfig = "SQL_User";
        public static string sqlUser;

        private const string sqlPassConfig = "SQL_Pass";
        public static string sqlPass;

        public static string dataFolder = "/data/";
        public static string csvFolder = "/csv/";

        public static void InitalizeConfig()
        {
            if (!File.Exists(@"ServerControllerConfig.ini"))
            {
                MessageBox.Show("ServerControllerConfig.ini not found. One will be created. Please fill out the data");
                CreateConfig();
                Environment.Exit(0);
            }
            else
            {
                ReadConfig();
            }
        }


        public static void ReadConfig()
        {
            StreamReader file = new StreamReader(@"ServerControllerConfig.ini");
            string line;
            int defaultTimer = 1800000;

            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith(";"))
                {
                    string[] splitLine = line.Split('=');

                    switch (splitLine[0])
                    {
                        case serverPathConfig:
                            if (splitLine[1].EndsWith("/"))
                                serverPath = splitLine[1].Substring(0, splitLine[1].Length - 1);
                            else
                                serverPath = splitLine[1];
                            break;
                        case exportPathConfig:
                            if (splitLine[1].EndsWith("/"))
                                exportPath = splitLine[1].Substring(0, splitLine[1].Length - 1);
                            else
                                exportPath = splitLine[1];
                            break;
                        case broadcast0Config:
                            broadcast0 = splitLine[1];
                            break;
                        case broadcastTimer0Config:
                            int parsed;
                            if (Int32.TryParse(splitLine[1], out parsed))
                            {
                                broadcastTimer0 = parsed;
                            }
                            else
                            {
                                broadcastTimer0 = defaultTimer;
                                frmMain.Main.AddLog("ERROR: Broadcast Timer 0 invalid numerical value. Defaulted to 30 minute intervals.");
                            }
                            break;
                        case broadcast1Config:
                            broadcast1 = splitLine[1];
                            break;
                        case broadcastTimer1Config:
                            if (Int32.TryParse(splitLine[1], out parsed))
                            {
                                broadcastTimer1 = parsed;
                            }
                            else
                            {
                                broadcastTimer1 = defaultTimer;
                                frmMain.Main.AddLog("ERROR: Broadcast Timer 1 invalid numerical value. Defaulted to 30 minute intervals.");
                            }
                            break;
                        case broadcast2Config:
                            broadcast2 = splitLine[1];
                            break;
                        case broadcastTimer2Config:
                            if(Int32.TryParse(splitLine[1], out parsed))
                            {
                                broadcastTimer2 = parsed;
                            }
                            else
                            {
                                broadcastTimer2 = defaultTimer;
                                frmMain.Main.AddLog("ERROR: Broadcast Timer 2 invalid numerical value. Defaulted to 30 minute intervals.");
                            }
                            break;
                        case onlineIgnoreConfig:
                            if (!onlineIgnores.Contains(splitLine[1]))
                            {
                                onlineIgnores.Add(splitLine[1]);
                            }
                            break;
                        case topTenIgnoreConfig:
                            if (!topTenIgnores.Contains(splitLine[1]))
                            {
                                topTenIgnores.Add(splitLine[1]);
                            }
                            break;
                        case allIgnoreConfig:
                            if (!topTenIgnores.Contains(splitLine[1]))
                            {
                                topTenIgnores.Add(splitLine[1]);
                            }
                            if (!onlineIgnores.Contains(splitLine[1]))
                            {
                                onlineIgnores.Add(splitLine[1]);
                            }
                            break;
                        case sqlIPConfig:
                            sqlIP = splitLine[1];
                            break;
                        case sqlPortConfig:
                            sqlPort = splitLine[1];
                            break;
                        case sqlDatabaseConfig:
                            sqlDatabase = splitLine[1];
                            break;
                        case sqlUserConfig:
                            sqlUser = splitLine[1];
                            break;
                        case sqlPassConfig:
                            sqlPass = splitLine[1];
                            break;
                    }
                }
            }
        }

        public static void CreateConfig()
        {
            StreamWriter file = File.CreateText(@"ServerControllerConfig.ini");

            file.WriteLine(";Server Controller Config");
            file.WriteLine(";ServerPath=<string> - Folder location where the server.exe is.");
            file.WriteLine(";ExportPath=<string> - Folder location where you want all php data to save to.");
            file.WriteLine(";Broadcast0=<string> - This is used for the timer based server broadcast. 200 Character Limit. [NOT USABLE - INCOMPLETE]");
            file.WriteLine(";BroadcastTimer0=<int> - This is Broadcast0 timer settings in milliseconds 60000 milliseconds is 60 seconds. [NOT USABLE - INCOMPLETE]");
            file.WriteLine(";Broadcast1=<string> - This is used for the timer based server broadcast. 200 Character Limit. [NOT USABLE - INCOMPLETE]");
            file.WriteLine(";BroadcastTimer1=<int> - This is Broadcast1 timer settings in milliseconds 60000 milliseconds is 60 seconds. [NOT USABLE - INCOMPLETE]");
            file.WriteLine(";Broadcast2=<string> - This is used for the timer based server broadcast. 200 Character Limit. [NOT USABLE - INCOMPLETE]");
            file.WriteLine(";BroadcastTimer2=<int> - This is Broadcast2 timer settings in milliseconds 60000 milliseconds is 60 seconds. [NOT USABLE - INCOMPLETE]");
            file.WriteLine(";;;;;;;;;;");
            file.WriteLine(";Ignore List Config");
            file.WriteLine(";OnlineIgnore=<string> - Ignores account listed from the who is online list.");
            file.WriteLine(";TopTenIgnore=<string> - Ignores account listed from the top ten list.");
            file.WriteLine(";AllIgnore=<string> - Ignores account listed from the top ten AND online list.");
            file.WriteLine(";;;;;;;;;;");
            file.WriteLine(";SQL Config");
            file.WriteLine(";SQL_IP=<ip address> - This is the ip address of the MYSQL server.");
            file.WriteLine(";SQL_Port=<int> - This is the port opening of the MYSQL server.");
            file.WriteLine(";SQL_Database=<string> - This is the database where the tables are in the MYSQL server.");
            file.WriteLine(";SQL_User=<string> - This is the username that will be used to access the MYSQL server.");
            file.WriteLine(";SQL_Pass=<string> - This is the password for the user that will be used to access the MYSQL server.");
            file.WriteLine("");
            file.WriteLine("ServerPath=");
            file.WriteLine("ExportPath="); 
            file.WriteLine("Broadcast0=Thanks for playing!");
            file.WriteLine("BroadcastTimer0=60000");
            file.WriteLine("");
            file.WriteLine("SQL_IP=");
            file.WriteLine("SQL_Port=");
            file.WriteLine("SQL_Database=");
            file.WriteLine("SQL_User=");
            file.WriteLine("SQL_Pass=");
            file.Close();
        }
    }
}
