using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace RPGWO_Server_Controller
{
    public class ConnectionHandler
    {
        public static IntPtr serverWindow;
        public static IntPtr serverClass;
        public static bool isServerRunning;

        //Listbox MsgUints
        const int LB_GETCOUNT = 0x018B;
        const int LB_GETTEXT = 0x0189;

        public static List<string> whosOnline = new List<string>();

        public static string conServer = "Server=";
        public static string conPort = "Port=";
        public static string conDatabase = "Database=";
        public static string conUser = "Uid=";
        public static string conPass = "Password=";

        public static MySqlConnection connection;

        public static int indexCount = 0;

        public static void GetServerConnection()
        {
            var serverWindows = Interop.FindWindowsWithText("RPG World Online Server");

            serverWindow = serverWindows.FirstOrDefault();

            if (serverWindow == IntPtr.Zero)
            {
                frmMain.Main.AddLog("ERROR: Server.exe was not found. Some functions will not work.");
                return;
            }
            else
            {
                isServerRunning = true;
                frmMain.Main.UpdateServerStatus(true);
            }

            serverClass = FindWindowEx(serverWindow, "ThunderRT6ListBox");
        }

        public static void GetSQLConnection()
        {
            string conString = conServer + Config.sqlIP + ";" + conPort + Config.sqlPort + ";" + conDatabase + Config.sqlDatabase + ";" + conUser + Config.sqlUser + ";" + conPass + Config.sqlPass + ";";

            connection = new MySqlConnection(conString);

            try
            {
                connection.Open();
                frmMain.Main.UpdateSQLStatus(true);
                Debug.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                frmMain.Main.AddLog("ERROR: Can not connect to SQL Server");
                Debug.WriteLine(ex);
            }
        }

        public static IntPtr FindWindow(string title)
        {
            return Interop.FindWindow(null, title);
        }

        public static IntPtr FindWindowEx(IntPtr hWndParent, string lclassName)
        {
            return Interop.FindWindowEx(hWndParent, IntPtr.Zero, lclassName, null);
        }

        public static void GetWhosOnline(IntPtr frame)
        {
            if (!isServerRunning)
                return;

            whosOnline.Clear();

            int cnt = (int)Interop.SendMessage(frame, LB_GETCOUNT, IntPtr.Zero, null);

            for (int i = 0; i < cnt; i++)
            {
                StringBuilder sb = new StringBuilder(256);
                _ = Interop.SendMessage(frame, LB_GETTEXT, (IntPtr)i, sb);

                string[] player = sb.ToString().Split(':');

                whosOnline.Add(player[1]);
            }

            frmMain.Main.SetWhosOnline();
            SQLWriter.BuildWhosOnlineData();
        }
    }
}
