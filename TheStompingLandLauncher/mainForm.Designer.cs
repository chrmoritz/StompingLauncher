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
            this.BnewSC = new System.Windows.Forms.Button();
            this.BsaveSC = new System.Windows.Forms.Button();
            this.BloadSC = new System.Windows.Forms.Button();
            this.CBserverConfig = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.tabControll.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControll
            // 
            resources.ApplyResources(this.tabControll, "tabControll");
            this.tabControll.Controls.Add(this.tabPage1);
            this.tabControll.Controls.Add(this.tabPage2);
            this.tabControll.Controls.Add(this.tabPage3);
            this.tabControll.Name = "tabControll";
            this.tabControll.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
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
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BdownSL
            // 
            resources.ApplyResources(this.BdownSL, "BdownSL");
            this.BdownSL.Name = "BdownSL";
            this.BdownSL.UseVisualStyleBackColor = true;
            this.BdownSL.Click += new System.EventHandler(this.BdownSL_Click);
            // 
            // BupSL
            // 
            resources.ApplyResources(this.BupSL, "BupSL");
            this.BupSL.Name = "BupSL";
            this.BupSL.UseVisualStyleBackColor = true;
            this.BupSL.Click += new System.EventHandler(this.BupSL_Click);
            // 
            // BremoveSL
            // 
            resources.ApplyResources(this.BremoveSL, "BremoveSL");
            this.BremoveSL.Name = "BremoveSL";
            this.BremoveSL.UseVisualStyleBackColor = true;
            this.BremoveSL.Click += new System.EventHandler(this.BremoveSL_Click);
            // 
            // BaddSL
            // 
            resources.ApplyResources(this.BaddSL, "BaddSL");
            this.BaddSL.Name = "BaddSL";
            this.BaddSL.UseVisualStyleBackColor = true;
            this.BaddSL.Click += new System.EventHandler(this.BaddSL_Click);
            // 
            // BconnectSL
            // 
            resources.ApplyResources(this.BconnectSL, "BconnectSL");
            this.BconnectSL.Name = "BconnectSL";
            this.BconnectSL.UseVisualStyleBackColor = true;
            this.BconnectSL.Click += new System.EventHandler(this.BconnectSL_Click);
            // 
            // LBserverHistory
            // 
            resources.ApplyResources(this.LBserverHistory, "LBserverHistory");
            this.LBserverHistory.FormattingEnabled = true;
            this.LBserverHistory.Name = "LBserverHistory";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // BjoinServer
            // 
            resources.ApplyResources(this.BjoinServer, "BjoinServer");
            this.BjoinServer.Name = "BjoinServer";
            this.BjoinServer.UseVisualStyleBackColor = true;
            this.BjoinServer.Click += new System.EventHandler(this.BjoinServer_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TBjoinIP
            // 
            resources.ApplyResources(this.TBjoinIP, "TBjoinIP");
            this.TBjoinIP.Name = "TBjoinIP";
            this.TBjoinIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBjoinIP_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.BnewSC);
            this.tabPage2.Controls.Add(this.BsaveSC);
            this.tabPage2.Controls.Add(this.BloadSC);
            this.tabPage2.Controls.Add(this.CBserverConfig);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.CBautoJoin);
            this.tabPage2.Controls.Add(this.BhostServer);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BnewSC
            // 
            resources.ApplyResources(this.BnewSC, "BnewSC");
            this.BnewSC.Name = "BnewSC";
            this.BnewSC.UseVisualStyleBackColor = true;
            this.BnewSC.Click += new System.EventHandler(this.BnewSC_Click);
            // 
            // BsaveSC
            // 
            resources.ApplyResources(this.BsaveSC, "BsaveSC");
            this.BsaveSC.Name = "BsaveSC";
            this.BsaveSC.UseVisualStyleBackColor = true;
            this.BsaveSC.Click += new System.EventHandler(this.BsaveSC_Click);
            // 
            // BloadSC
            // 
            resources.ApplyResources(this.BloadSC, "BloadSC");
            this.BloadSC.Name = "BloadSC";
            this.BloadSC.UseVisualStyleBackColor = true;
            this.BloadSC.Click += new System.EventHandler(this.BloadSC_Click);
            // 
            // CBserverConfig
            // 
            resources.ApplyResources(this.CBserverConfig, "CBserverConfig");
            this.CBserverConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBserverConfig.FormattingEnabled = true;
            this.CBserverConfig.Name = "CBserverConfig";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // CBautoJoin
            // 
            resources.ApplyResources(this.CBautoJoin, "CBautoJoin");
            this.CBautoJoin.Checked = true;
            this.CBautoJoin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBautoJoin.Name = "CBautoJoin";
            this.CBautoJoin.UseVisualStyleBackColor = true;
            // 
            // BhostServer
            // 
            resources.ApplyResources(this.BhostServer, "BhostServer");
            this.BhostServer.Name = "BhostServer";
            this.BhostServer.UseVisualStyleBackColor = true;
            this.BhostServer.Click += new System.EventHandler(this.BhostServer_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.CBconfigDir);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TBconfigDir);
            this.groupBox2.Controls.Add(this.TBqueryPort);
            this.groupBox2.Controls.Add(this.TBport);
            this.groupBox2.Controls.Add(this.TBhostname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CBsteamQuery);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // CBconfigDir
            // 
            resources.ApplyResources(this.CBconfigDir, "CBconfigDir");
            this.CBconfigDir.Name = "CBconfigDir";
            this.CBconfigDir.UseVisualStyleBackColor = true;
            this.CBconfigDir.CheckedChanged += new System.EventHandler(this.CBconfigDir_CheckedChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TBconfigDir
            // 
            resources.ApplyResources(this.TBconfigDir, "TBconfigDir");
            this.TBconfigDir.Name = "TBconfigDir";
            // 
            // TBqueryPort
            // 
            resources.ApplyResources(this.TBqueryPort, "TBqueryPort");
            this.TBqueryPort.Name = "TBqueryPort";
            this.TBqueryPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBqueryPort_KeyPress);
            // 
            // TBport
            // 
            resources.ApplyResources(this.TBport, "TBport");
            this.TBport.Name = "TBport";
            this.TBport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBport_KeyPress);
            // 
            // TBhostname
            // 
            resources.ApplyResources(this.TBhostname, "TBhostname");
            this.TBhostname.Name = "TBhostname";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // CBsteamQuery
            // 
            resources.ApplyResources(this.CBsteamQuery, "CBsteamQuery");
            this.CBsteamQuery.Checked = true;
            this.CBsteamQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBsteamQuery.Name = "CBsteamQuery";
            this.CBsteamQuery.UseVisualStyleBackColor = true;
            this.CBsteamQuery.CheckedChanged += new System.EventHandler(this.CBsteamQuery_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.CBremoveDinos);
            this.groupBox1.Controls.Add(this.CBplayerNames);
            this.groupBox1.Controls.Add(this.CBfriendlyFire);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // CBremoveDinos
            // 
            resources.ApplyResources(this.CBremoveDinos, "CBremoveDinos");
            this.CBremoveDinos.Name = "CBremoveDinos";
            this.CBremoveDinos.UseVisualStyleBackColor = true;
            // 
            // CBplayerNames
            // 
            resources.ApplyResources(this.CBplayerNames, "CBplayerNames");
            this.CBplayerNames.Name = "CBplayerNames";
            this.CBplayerNames.UseVisualStyleBackColor = true;
            // 
            // CBfriendlyFire
            // 
            resources.ApplyResources(this.CBfriendlyFire, "CBfriendlyFire");
            this.CBfriendlyFire.Name = "CBfriendlyFire";
            this.CBfriendlyFire.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.BserbasedSP);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BserbasedSP
            // 
            resources.ApplyResources(this.BserbasedSP, "BserbasedSP");
            this.BserbasedSP.Name = "BserbasedSP";
            this.BserbasedSP.UseVisualStyleBackColor = true;
            this.BserbasedSP.Click += new System.EventHandler(this.BserbasedSP_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TBpath
            // 
            resources.ApplyResources(this.TBpath, "TBpath");
            this.TBpath.Name = "TBpath";
            // 
            // BselectPath
            // 
            resources.ApplyResources(this.BselectPath, "BselectPath");
            this.BselectPath.Name = "BselectPath";
            this.BselectPath.UseVisualStyleBackColor = true;
            this.BselectPath.Click += new System.EventHandler(this.BselectPath_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BselectPath);
            this.Controls.Add(this.TBpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControll);
            this.Name = "mainForm";
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
        private System.Windows.Forms.Button BdownSL;
        private System.Windows.Forms.Button BupSL;
        private System.Windows.Forms.Button BnewSC;
        private System.Windows.Forms.Button BsaveSC;
        private System.Windows.Forms.Button BloadSC;
        private System.Windows.Forms.ComboBox CBserverConfig;
        private System.Windows.Forms.Label label9;
    }
}

