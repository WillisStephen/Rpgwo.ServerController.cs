using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGWO_Server_Controller
{
    public partial class frmMain : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static frmMain Main;

        public frmMain()
        {
            Config.InitalizeConfig();
            InitializeComponent();
            InitializeCustomComponent();
            ConnectionHandler.GetServerConnection();
            ConnectionHandler.GetSQLConnection();
            INIReader.BuildDictionaries();
            AddLog("RPGWO v2 Server Controller v0.8");

            if(ConnectionHandler.isServerRunning)
                ConnectionHandler.GetWhosOnline(ConnectionHandler.serverClass);

            SQLWriter.BuildSQLTables();
        }

        private void InitializeCustomComponent()
        {
            this.MouseDown += frmMain_MouseDown;
            listWhosOnline.DrawItem += listWhosOnline_DrawItem;
            listWhosOnline.DrawMode = DrawMode.OwnerDrawFixed;
            Main = this;
            Main.Shown += new EventHandler(frmMain_Shown);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
        }

        private void frmMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Interop.ReleaseCapture();
                Interop.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void listWhosOnline_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < listWhosOnline.Items.Count)
            {
                Graphics g = e.Graphics;

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.DarkRed : Color.DarkGray);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                string itemText = listWhosOnline.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, listWhosOnline.GetItemRectangle(itemIndex).Location);

                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        public void AddLog(string msg)
        {
            textLog.AppendText("[" + DateTime.Now + "] " + msg);
            textLog.AppendText(Environment.NewLine);
        }

        public void SetWhosOnline()
        {
            listWhosOnline.DataSource = ConnectionHandler.whosOnline;

            AddLog("Who's online has been updated.");
        }

        public void UpdateServerStatus(bool status)
        {
            if (status)
            {
                labelServerStatus.Text = "Connected";
                labelServerStatus.ForeColor = Color.Green;
            }
            else
            {
                labelServerStatus.Text = "Disconnected";
                labelServerStatus.ForeColor = Color.Red;
            }
        }

        public void UpdateSQLStatus(bool status)
        {
            if (status)
            {
                labelSQLStatus.Text = "Connected";
                labelSQLStatus.ForeColor = Color.Green;
            }
            else
            {
                labelSQLStatus.Text = "Disconnected";
                labelSQLStatus.ForeColor = Color.Red;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if(int.TryParse(updateTime.Text.ToString(), out int updateInt))
            {
                if (DateTime.Now.Hour == updateInt)
                {
                    DATReader.ReadPlayers();
                }
            }
            else
            {
                if (DateTime.Now.Hour == 0)
                {
                    DATReader.ReadPlayers();
                }
            }
        }

        private void updateTopTen_Click(object sender, EventArgs e)
        {
            DATReader.ReadPlayers();
        }
    }
}
