namespace RPGWO_Server_Controller
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMainSelect = new System.Windows.Forms.Panel();
            this.updateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSQLStatus = new System.Windows.Forms.Label();
            this.labelSQL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupWhosOnline = new System.Windows.Forms.GroupBox();
            this.listWhosOnline = new System.Windows.Forms.ListBox();
            this.btnData = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.updateTopTen = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelMainSelect.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panelSelection.SuspendLayout();
            this.groupWhosOnline.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelMain.Controls.Add(this.panelMainSelect);
            this.panelMain.Controls.Add(this.panelStatus);
            this.panelMain.Controls.Add(this.panelSelection);
            this.panelMain.Controls.Add(this.groupLog);
            this.panelMain.Location = new System.Drawing.Point(5, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(969, 592);
            this.panelMain.TabIndex = 0;
            // 
            // panelMainSelect
            // 
            this.panelMainSelect.Controls.Add(this.updateTopTen);
            this.panelMainSelect.Controls.Add(this.updateTime);
            this.panelMainSelect.Controls.Add(this.label2);
            this.panelMainSelect.Controls.Add(this.label1);
            this.panelMainSelect.Location = new System.Drawing.Point(223, 7);
            this.panelMainSelect.Name = "panelMainSelect";
            this.panelMainSelect.Size = new System.Drawing.Size(739, 476);
            this.panelMainSelect.TabIndex = 3;
            // 
            // updateTime
            // 
            this.updateTime.Location = new System.Drawing.Point(320, 328);
            this.updateTime.MaxLength = 2;
            this.updateTime.Name = "updateTime";
            this.updateTime.Size = new System.Drawing.Size(100, 20);
            this.updateTime.TabIndex = 2;
            this.updateTime.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(198, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hour In Which Topten Updates (0 = midnight | 12 = noon | 23 = 11:00 pm)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(93, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "More Data Coming Later..";
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.panel2);
            this.panelStatus.Controls.Add(this.panel1);
            this.panelStatus.Controls.Add(this.pictureLogo);
            this.panelStatus.Location = new System.Drawing.Point(7, 7);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(210, 198);
            this.panelStatus.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelSQLStatus);
            this.panel2.Controls.Add(this.labelSQL);
            this.panel2.Location = new System.Drawing.Point(6, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 37);
            this.panel2.TabIndex = 2;
            // 
            // labelSQLStatus
            // 
            this.labelSQLStatus.AutoSize = true;
            this.labelSQLStatus.ForeColor = System.Drawing.Color.Red;
            this.labelSQLStatus.Location = new System.Drawing.Point(104, 10);
            this.labelSQLStatus.Name = "labelSQLStatus";
            this.labelSQLStatus.Size = new System.Drawing.Size(73, 13);
            this.labelSQLStatus.TabIndex = 2;
            this.labelSQLStatus.Text = "Disconnected";
            // 
            // labelSQL
            // 
            this.labelSQL.AutoSize = true;
            this.labelSQL.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelSQL.Location = new System.Drawing.Point(28, 10);
            this.labelSQL.Name = "labelSQL";
            this.labelSQL.Size = new System.Drawing.Size(64, 13);
            this.labelSQL.TabIndex = 1;
            this.labelSQL.Text = "SQL Status:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelServerStatus);
            this.panel1.Controls.Add(this.labelServer);
            this.panel1.Location = new System.Drawing.Point(6, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 37);
            this.panel1.TabIndex = 1;
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.ForeColor = System.Drawing.Color.Red;
            this.labelServerStatus.Location = new System.Drawing.Point(104, 12);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(73, 13);
            this.labelServerStatus.TabIndex = 1;
            this.labelServerStatus.Text = "Disconnected";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelServer.Location = new System.Drawing.Point(24, 12);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(74, 13);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "Server Status:";
            // 
            // pictureLogo
            // 
            this.pictureLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureLogo.Image = global::RPGWO_Server_Controller.Properties.Resources.NewMainLogo;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(210, 108);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.btnClose);
            this.panelSelection.Controls.Add(this.groupWhosOnline);
            this.panelSelection.Controls.Add(this.btnData);
            this.panelSelection.Controls.Add(this.btnServer);
            this.panelSelection.Controls.Add(this.btnMain);
            this.panelSelection.Location = new System.Drawing.Point(7, 211);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(210, 272);
            this.panelSelection.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnClose.Location = new System.Drawing.Point(0, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(210, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupWhosOnline
            // 
            this.groupWhosOnline.Controls.Add(this.listWhosOnline);
            this.groupWhosOnline.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupWhosOnline.Location = new System.Drawing.Point(3, 155);
            this.groupWhosOnline.Name = "groupWhosOnline";
            this.groupWhosOnline.Size = new System.Drawing.Size(204, 117);
            this.groupWhosOnline.TabIndex = 0;
            this.groupWhosOnline.TabStop = false;
            this.groupWhosOnline.Text = "Who\'s Online";
            // 
            // listWhosOnline
            // 
            this.listWhosOnline.BackColor = System.Drawing.Color.DarkGray;
            this.listWhosOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listWhosOnline.FormattingEnabled = true;
            this.listWhosOnline.Location = new System.Drawing.Point(6, 19);
            this.listWhosOnline.Name = "listWhosOnline";
            this.listWhosOnline.Size = new System.Drawing.Size(192, 91);
            this.listWhosOnline.TabIndex = 0;
            // 
            // btnData
            // 
            this.btnData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnData.FlatAppearance.BorderSize = 0;
            this.btnData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnData.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnData.Location = new System.Drawing.Point(0, 76);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(210, 38);
            this.btnData.TabIndex = 2;
            this.btnData.UseVisualStyleBackColor = true;
            // 
            // btnServer
            // 
            this.btnServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServer.FlatAppearance.BorderSize = 0;
            this.btnServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServer.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnServer.Location = new System.Drawing.Point(0, 38);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(210, 38);
            this.btnServer.TabIndex = 1;
            this.btnServer.UseVisualStyleBackColor = true;
            // 
            // btnMain
            // 
            this.btnMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnMain.Location = new System.Drawing.Point(0, 0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(210, 38);
            this.btnMain.TabIndex = 0;
            this.btnMain.Text = "Main";
            this.btnMain.UseVisualStyleBackColor = true;
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.textLog);
            this.groupLog.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupLog.Location = new System.Drawing.Point(7, 489);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(955, 96);
            this.groupLog.TabIndex = 0;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "Event Log";
            // 
            // textLog
            // 
            this.textLog.BackColor = System.Drawing.Color.DarkGray;
            this.textLog.Location = new System.Drawing.Point(6, 19);
            this.textLog.MaxLength = 60000;
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(943, 71);
            this.textLog.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // updateTopTen
            // 
            this.updateTopTen.Location = new System.Drawing.Point(293, 359);
            this.updateTopTen.Name = "updateTopTen";
            this.updateTopTen.Size = new System.Drawing.Size(147, 23);
            this.updateTopTen.TabIndex = 3;
            this.updateTopTen.Text = "Manual Update Top Ten";
            this.updateTopTen.UseVisualStyleBackColor = true;
            this.updateTopTen.Click += new System.EventHandler(this.updateTopTen_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(979, 602);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.panelMain.ResumeLayout(false);
            this.panelMainSelect.ResumeLayout(false);
            this.panelMainSelect.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panelSelection.ResumeLayout(false);
            this.groupWhosOnline.ResumeLayout(false);
            this.groupLog.ResumeLayout(false);
            this.groupLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelSQL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelSQLStatus;
        private System.Windows.Forms.Panel panelMainSelect;
        private System.Windows.Forms.GroupBox groupWhosOnline;
        private System.Windows.Forms.ListBox listWhosOnline;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox updateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button updateTopTen;
    }
}

