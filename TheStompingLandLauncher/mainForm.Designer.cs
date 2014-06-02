namespace TheStompingLandLauncher
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tabControll = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BdownSL = new System.Windows.Forms.Button();
            this.BupSL = new System.Windows.Forms.Button();
            this.BremoveSL = new System.Windows.Forms.Button();
            this.BaddSL = new System.Windows.Forms.Button();
            this.BconnectSL = new System.Windows.Forms.Button();
            this.LBserverHistory = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BjoinServer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TBjoinIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CBautoJoin = new System.Windows.Forms.CheckBox();
            this.BhostServer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBconfigDir = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBconfigDir = new System.Windows.Forms.TextBox();
            this.TBqueryPort = new System.Windows.Forms.TextBox();
            this.TBport = new System.Windows.Forms.TextBox();
            this.TBhostname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBsteamQuery = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBremoveDinos = new System.Windows.Forms.CheckBox();
            this.CBplayerNames = new System.Windows.Forms.CheckBox();
            this.CBfriendlyFire = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.BserbasedSP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBpath = new System.Windows.Forms.TextBox();
            this.BselectPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label9 = new System.Windows.Forms.Label();
            this.CBserverConfig = new System.Windows.Forms.ComboBox();
            this.BloadSC = new System.Windows.Forms.Button();
            this.BsaveSC = new System.Windows.Forms.Button();
            this.BnewSC = new System.Windows.Forms.Button();
            this.tabControll.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControll
            // 
            this.tabControll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControll.Controls.Add(this.tabPage1);
            this.tabControll.Controls.Add(this.tabPage2);
            this.tabControll.Controls.Add(this.tabPage3);
            this.tabControll.Location = new System.Drawing.Point(6, 32);
            this.tabControll.Name = "tabControll";
            this.tabControll.SelectedIndex = 0;
            this.tabControll.Size = new System.Drawing.Size(724, 200);
            this.tabControll.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BdownSL);
            this.tabPage1.Controls.Add(this.BupSL);
            this.tabPage1.Controls.Add(this.BremoveSL);
            this.tabPage1.Controls.Add(this.BaddSL);
            this.tabPage1.Controls.Add(this.BconnectSL);
            this.tabPage1.Controls.Add(this.LBserverHistory);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.BjoinServer);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TBjoinIP);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(716, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "join Server by IP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BdownSL
            // 
            this.BdownSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BdownSL.Location = new System.Drawing.Point(659, 117);
            this.BdownSL.Name = "BdownSL";
            this.BdownSL.Size = new System.Drawing.Size(51, 23);
            this.BdownSL.TabIndex = 9;
            this.BdownSL.Text = "down";
            this.BdownSL.UseVisualStyleBackColor = true;
            this.BdownSL.Click += new System.EventHandler(this.BdownSL_Click);
            // 
            // BupSL
            // 
            this.BupSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BupSL.Location = new System.Drawing.Point(602, 117);
            this.BupSL.Name = "BupSL";
            this.BupSL.Size = new System.Drawing.Size(51, 23);
            this.BupSL.TabIndex = 8;
            this.BupSL.Text = "up";
            this.BupSL.UseVisualStyleBackColor = true;
            this.BupSL.Click += new System.EventHandler(this.BupSL_Click);
            // 
            // BremoveSL
            // 
            this.BremoveSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BremoveSL.Location = new System.Drawing.Point(602, 146);
            this.BremoveSL.Name = "BremoveSL";
            this.BremoveSL.Size = new System.Drawing.Size(108, 23);
            this.BremoveSL.TabIndex = 10;
            this.BremoveSL.Text = "remove ...";
            this.BremoveSL.UseVisualStyleBackColor = true;
            this.BremoveSL.Click += new System.EventHandler(this.BremoveSL_Click);
            // 
            // BaddSL
            // 
            this.BaddSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaddSL.Location = new System.Drawing.Point(602, 88);
            this.BaddSL.Name = "BaddSL";
            this.BaddSL.Size = new System.Drawing.Size(108, 23);
            this.BaddSL.TabIndex = 7;
            this.BaddSL.Text = "add server ...";
            this.BaddSL.UseVisualStyleBackColor = true;
            this.BaddSL.Click += new System.EventHandler(this.BaddSL_Click);
            // 
            // BconnectSL
            // 
            this.BconnectSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BconnectSL.Location = new System.Drawing.Point(602, 59);
            this.BconnectSL.Name = "BconnectSL";
            this.BconnectSL.Size = new System.Drawing.Size(108, 23);
            this.BconnectSL.TabIndex = 6;
            this.BconnectSL.Text = "connect ...";
            this.BconnectSL.UseVisualStyleBackColor = true;
            this.BconnectSL.Click += new System.EventHandler(this.BconnectSL_Click);
            // 
            // LBserverHistory
            // 
            this.LBserverHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBserverHistory.FormattingEnabled = true;
            this.LBserverHistory.Location = new System.Drawing.Point(62, 59);
            this.LBserverHistory.Name = "LBserverHistory";
            this.LBserverHistory.Size = new System.Drawing.Size(534, 108);
            this.LBserverHistory.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "History:";
            // 
            // BjoinServer
            // 
            this.BjoinServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BjoinServer.Location = new System.Drawing.Point(6, 25);
            this.BjoinServer.Name = "BjoinServer";
            this.BjoinServer.Size = new System.Drawing.Size(704, 28);
            this.BjoinServer.TabIndex = 3;
            this.BjoinServer.Text = "connect to server ...";
            this.BjoinServer.UseVisualStyleBackColor = true;
            this.BjoinServer.Click += new System.EventHandler(this.BjoinServer_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "(eg.: 127.0.0.1:7777 to connect to a locally hosted server)";
            // 
            // TBjoinIP
            // 
            this.TBjoinIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBjoinIP.Location = new System.Drawing.Point(74, 6);
            this.TBjoinIP.Name = "TBjoinIP";
            this.TBjoinIP.Size = new System.Drawing.Size(350, 20);
            this.TBjoinIP.TabIndex = 1;
            this.TBjoinIP.Text = "127.0.0.1:7777";
            this.TBjoinIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBjoinIP_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connect to:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BnewSC);
            this.tabPage2.Controls.Add(this.BsaveSC);
            this.tabPage2.Controls.Add(this.BloadSC);
            this.tabPage2.Controls.Add(this.CBserverConfig);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.CBautoJoin);
            this.tabPage2.Controls.Add(this.BhostServer);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(716, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "host your own Server";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CBautoJoin
            // 
            this.CBautoJoin.AutoSize = true;
            this.CBautoJoin.Checked = true;
            this.CBautoJoin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBautoJoin.Location = new System.Drawing.Point(6, 114);
            this.CBautoJoin.Name = "CBautoJoin";
            this.CBautoJoin.Size = new System.Drawing.Size(114, 17);
            this.CBautoJoin.TabIndex = 9;
            this.CBautoJoin.Text = "autojoin this server";
            this.CBautoJoin.UseVisualStyleBackColor = true;
            // 
            // BhostServer
            // 
            this.BhostServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BhostServer.Location = new System.Drawing.Point(126, 110);
            this.BhostServer.Name = "BhostServer";
            this.BhostServer.Size = new System.Drawing.Size(584, 23);
            this.BhostServer.TabIndex = 10;
            this.BhostServer.Text = "host server ...";
            this.BhostServer.UseVisualStyleBackColor = true;
            this.BhostServer.Click += new System.EventHandler(this.BhostServer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.CBconfigDir);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TBconfigDir);
            this.groupBox2.Controls.Add(this.TBqueryPort);
            this.groupBox2.Controls.Add(this.TBport);
            this.groupBox2.Controls.Add(this.TBhostname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CBsteamQuery);
            this.groupBox2.Location = new System.Drawing.Point(163, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 98);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Host options";
            // 
            // CBconfigDir
            // 
            this.CBconfigDir.AutoSize = true;
            this.CBconfigDir.Location = new System.Drawing.Point(220, 71);
            this.CBconfigDir.Name = "CBconfigDir";
            this.CBconfigDir.Size = new System.Drawing.Size(110, 17);
            this.CBconfigDir.TabIndex = 7;
            this.CBconfigDir.Text = "Custom config dir:";
            this.CBconfigDir.UseVisualStyleBackColor = true;
            this.CBconfigDir.CheckedChanged += new System.EventHandler(this.CBconfigDir_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "SteamQueryPort:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Port:";
            // 
            // TBconfigDir
            // 
            this.TBconfigDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBconfigDir.Enabled = false;
            this.TBconfigDir.Location = new System.Drawing.Point(336, 68);
            this.TBconfigDir.Name = "TBconfigDir";
            this.TBconfigDir.Size = new System.Drawing.Size(205, 20);
            this.TBconfigDir.TabIndex = 8;
            this.TBconfigDir.Text = "serverconfig";
            // 
            // TBqueryPort
            // 
            this.TBqueryPort.Location = new System.Drawing.Point(177, 69);
            this.TBqueryPort.Name = "TBqueryPort";
            this.TBqueryPort.Size = new System.Drawing.Size(37, 20);
            this.TBqueryPort.TabIndex = 6;
            this.TBqueryPort.Text = "27015";
            this.TBqueryPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBqueryPort_KeyPress);
            // 
            // TBport
            // 
            this.TBport.Location = new System.Drawing.Point(41, 68);
            this.TBport.Name = "TBport";
            this.TBport.Size = new System.Drawing.Size(37, 20);
            this.TBport.TabIndex = 5;
            this.TBport.Text = "7777";
            this.TBport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBport_KeyPress);
            // 
            // TBhostname
            // 
            this.TBhostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBhostname.Location = new System.Drawing.Point(70, 42);
            this.TBhostname.Name = "TBhostname";
            this.TBhostname.Size = new System.Drawing.Size(471, 20);
            this.TBhostname.TabIndex = 4;
            this.TBhostname.Text = "My Stomping Land Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hostname:";
            // 
            // CBsteamQuery
            // 
            this.CBsteamQuery.AutoSize = true;
            this.CBsteamQuery.Checked = true;
            this.CBsteamQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBsteamQuery.Location = new System.Drawing.Point(6, 19);
            this.CBsteamQuery.Name = "CBsteamQuery";
            this.CBsteamQuery.Size = new System.Drawing.Size(141, 17);
            this.CBsteamQuery.TabIndex = 3;
            this.CBsteamQuery.Text = "listed in Steam server list";
            this.CBsteamQuery.UseVisualStyleBackColor = true;
            this.CBsteamQuery.CheckedChanged += new System.EventHandler(this.CBsteamQuery_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBremoveDinos);
            this.groupBox1.Controls.Add(this.CBplayerNames);
            this.groupBox1.Controls.Add(this.CBfriendlyFire);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server configuration";
            // 
            // CBremoveDinos
            // 
            this.CBremoveDinos.AutoSize = true;
            this.CBremoveDinos.Location = new System.Drawing.Point(6, 65);
            this.CBremoveDinos.Name = "CBremoveDinos";
            this.CBremoveDinos.Size = new System.Drawing.Size(109, 17);
            this.CBremoveDinos.TabIndex = 2;
            this.CBremoveDinos.Text = "remove dinosaurs";
            this.CBremoveDinos.UseVisualStyleBackColor = true;
            // 
            // CBplayerNames
            // 
            this.CBplayerNames.AutoSize = true;
            this.CBplayerNames.Location = new System.Drawing.Point(6, 42);
            this.CBplayerNames.Name = "CBplayerNames";
            this.CBplayerNames.Size = new System.Drawing.Size(134, 17);
            this.CBplayerNames.TabIndex = 1;
            this.CBplayerNames.Text = "show all players names";
            this.CBplayerNames.UseVisualStyleBackColor = true;
            // 
            // CBfriendlyFire
            // 
            this.CBfriendlyFire.AutoSize = true;
            this.CBfriendlyFire.Location = new System.Drawing.Point(6, 19);
            this.CBfriendlyFire.Name = "CBfriendlyFire";
            this.CBfriendlyFire.Size = new System.Drawing.Size(76, 17);
            this.CBfriendlyFire.TabIndex = 0;
            this.CBfriendlyFire.Text = "friendly fire";
            this.CBfriendlyFire.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.BserbasedSP);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(716, 174);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "start serverbased singelplayer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.MaximumSize = new System.Drawing.Size(500, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // BserbasedSP
            // 
            this.BserbasedSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BserbasedSP.Location = new System.Drawing.Point(6, 52);
            this.BserbasedSP.Name = "BserbasedSP";
            this.BserbasedSP.Size = new System.Drawing.Size(706, 31);
            this.BserbasedSP.TabIndex = 0;
            this.BserbasedSP.Text = "start serverbased singelplayer ...";
            this.BserbasedSP.UseVisualStyleBackColor = true;
            this.BserbasedSP.Click += new System.EventHandler(this.BserbasedSP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stomping Land Folder:";
            // 
            // TBpath
            // 
            this.TBpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBpath.Location = new System.Drawing.Point(122, 9);
            this.TBpath.Name = "TBpath";
            this.TBpath.Size = new System.Drawing.Size(505, 20);
            this.TBpath.TabIndex = 2;
            this.TBpath.Text = "C:\\Program Files (x86)\\Steam\\SteamApps\\common\\The Stomping Land";
            // 
            // BselectPath
            // 
            this.BselectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BselectPath.Location = new System.Drawing.Point(633, 7);
            this.BselectPath.Name = "BselectPath";
            this.BselectPath.Size = new System.Drawing.Size(97, 23);
            this.BselectPath.TabIndex = 3;
            this.BselectPath.Text = "select folder";
            this.BselectPath.UseVisualStyleBackColor = true;
            this.BselectPath.Click += new System.EventHandler(this.BselectPath_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Configuration manager:";
            // 
            // CBserverConfig
            // 
            this.CBserverConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBserverConfig.FormattingEnabled = true;
            this.CBserverConfig.Location = new System.Drawing.Point(146, 139);
            this.CBserverConfig.Name = "CBserverConfig";
            this.CBserverConfig.Size = new System.Drawing.Size(223, 21);
            this.CBserverConfig.TabIndex = 11;
            // 
            // BloadSC
            // 
            this.BloadSC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BloadSC.Location = new System.Drawing.Point(375, 139);
            this.BloadSC.Name = "BloadSC";
            this.BloadSC.Size = new System.Drawing.Size(110, 23);
            this.BloadSC.TabIndex = 12;
            this.BloadSC.Text = "load configuration";
            this.BloadSC.UseVisualStyleBackColor = true;
            this.BloadSC.Click += new System.EventHandler(this.BloadSC_Click);
            // 
            // BsaveSC
            // 
            this.BsaveSC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BsaveSC.Location = new System.Drawing.Point(491, 139);
            this.BsaveSC.Name = "BsaveSC";
            this.BsaveSC.Size = new System.Drawing.Size(102, 23);
            this.BsaveSC.TabIndex = 13;
            this.BsaveSC.Text = "save configuration";
            this.BsaveSC.UseVisualStyleBackColor = true;
            this.BsaveSC.Click += new System.EventHandler(this.BsaveSC_Click);
            // 
            // BnewSC
            // 
            this.BnewSC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BnewSC.Location = new System.Drawing.Point(599, 139);
            this.BnewSC.Name = "BnewSC";
            this.BnewSC.Size = new System.Drawing.Size(111, 23);
            this.BnewSC.TabIndex = 14;
            this.BnewSC.Text = "new configuration ...";
            this.BnewSC.UseVisualStyleBackColor = true;
            this.BnewSC.Click += new System.EventHandler(this.BnewSC_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 237);
            this.Controls.Add(this.BselectPath);
            this.Controls.Add(this.TBpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControll);
            this.MinimumSize = new System.Drawing.Size(750, 275);
            this.Name = "mainForm";
            this.Text = "The Stomping Land Launcher";
            this.tabControll.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControll;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBpath;
        private System.Windows.Forms.Button BselectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BserbasedSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BjoinServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBjoinIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CBsteamQuery;
        private System.Windows.Forms.CheckBox CBremoveDinos;
        private System.Windows.Forms.CheckBox CBplayerNames;
        private System.Windows.Forms.CheckBox CBfriendlyFire;
        private System.Windows.Forms.CheckBox CBconfigDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBconfigDir;
        private System.Windows.Forms.TextBox TBqueryPort;
        private System.Windows.Forms.TextBox TBport;
        private System.Windows.Forms.TextBox TBhostname;
        private System.Windows.Forms.Button BhostServer;
        private System.Windows.Forms.CheckBox CBautoJoin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox LBserverHistory;
        private System.Windows.Forms.Button BremoveSL;
        private System.Windows.Forms.Button BaddSL;
        private System.Windows.Forms.Button BconnectSL;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button BdownSL;
        private System.Windows.Forms.Button BupSL;
        private System.Windows.Forms.Button BnewSC;
        private System.Windows.Forms.Button BsaveSC;
        private System.Windows.Forms.Button BloadSC;
        private System.Windows.Forms.ComboBox CBserverConfig;
        private System.Windows.Forms.Label label9;
    }
}

