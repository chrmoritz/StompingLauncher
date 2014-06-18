using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace TheStompingLandLauncher
{
    public partial class mainForm : Form
    {
        public Dictionary<String, serverSetting> serverSettings;
        public string[] serverSaveLines;
        public int copiedSaveLine;

        public mainForm()
        {
            InitializeComponent();
            //Load stored Settings
            TBjoinIP.Text = (string)Properties.Settings.Default["lastConnected"];
            string serverHistory = (string)Properties.Settings.Default["ServerHistory"];

            string[] history = serverHistory.Split('|');
            if (history.Length > 1 || !String.IsNullOrEmpty(history[0]))
            {
                LBserverHistory.Items.AddRange(history);
            }

            string settings = (string)Properties.Settings.Default["ServerSettings"];
            if (String.IsNullOrEmpty(settings))
            {
                this.serverSettings = new Dictionary<String, serverSetting>();
            }
            else
            {
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(settings));
                BinaryFormatter bf = new BinaryFormatter();
                this.serverSettings = (Dictionary<String, serverSetting>)bf.Deserialize(ms);
                ms.Close();
            }
            foreach (string config in this.serverSettings.Keys)
            {
                CBserverConfig.Items.Add(config);
            }
            if (CBserverConfig.Items.Count > 0)
            {
                CBserverConfig.SelectedIndex = 0;
            }

            CBsoloTpList.SelectedIndex = 0;
            CBserverTpList.SelectedIndex = 0;

            string TSLpath = (string)Properties.Settings.Default["TSLpath"];
            if (Directory.Exists(TSLpath))
            {
                TBpath.Text = TSLpath;
            }
            else
            {
                //try to detect TSLpath via steams registry entry
                string steamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
                string path = steamPath.Replace("/", "\\") + "\\steamapps\\common\\the stomping land";
                if (Directory.Exists(path))
                {
                    TBpath.Text = path;
                }
                else
                {
                    MessageBox.Show(GlobalStrings.SLfolderPathBody, GlobalStrings.SLfolderPathHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        TBpath.Text = folderBrowserDialog1.SelectedPath;
                        Properties.Settings.Default["TSLpath"] = TBpath.Text;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        private void BselectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = TBpath.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TBpath.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default["TSLpath"] = TBpath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e) { }

        private void tabControll_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTab = tabControll.SelectedIndex;
            switch (selectedTab)
            {
                case 2:
                    this.BreloadSoloSave_Click(null, null);
                    break;
                case 3:
                    this.BreloadServerSave_Click(null, null);
                    break;
            }
        }

        // ############################################### JOIN SERVER TAB ###############################################

        private void BjoinServer_Click(object sender, EventArgs e)
        {
            string server = TBjoinIP.Text;
            //Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
            //Match match = rgx.Match(server);
            //if (match.Success && int.Parse(match.Groups[1].Value) < 257 && int.Parse(match.Groups[2].Value) < 257 && int.Parse(match.Groups[3].Value) < 257 && int.Parse(match.Groups[4].Value) < 257 && int.Parse(match.Groups[5].Value) < 65536 && int.Parse(match.Groups[5].Value) > 0)
            //{
                Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", server);
                Properties.Settings.Default["lastConnected"] = TBjoinIP.Text;
                addToServerList(server);
            //}
            //else
            //{
            //    MessageBox.Show(GlobalStrings.ServerAddressBody, GlobalStrings.ServerAddressHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BconnectSL_Click(object sender, EventArgs e)
        {
            if (LBserverHistory.SelectedIndex == -1)
            {
                return;
            }
            string server = (string)LBserverHistory.SelectedItem;
            //Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
            //Match match = rgx.Match(server);
            //if (match.Success && int.Parse(match.Groups[1].Value) < 257 && int.Parse(match.Groups[2].Value) < 257 && int.Parse(match.Groups[3].Value) < 257 && int.Parse(match.Groups[4].Value) < 257 && int.Parse(match.Groups[5].Value) < 65536 && int.Parse(match.Groups[5].Value) > 0)
            //{
            Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", server);
            Properties.Settings.Default["lastConnected"] = TBjoinIP.Text;
            addToServerList(server);
            Properties.Settings.Default.Save();
            //}
            //else
            //{
            //    LBserverHistory.Items.RemoveAt(LBserverHistory.SelectedIndex);
            //}
        }

        private void BaddSL_Click(object sender, EventArgs e)
        {
            addHistoryServerForm addForm = new addHistoryServerForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                string addIP = addForm.TBaddServerIP.Text;
                //Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
                //Match match = rgx.Match(addIP);
                //if (match.Success && int.Parse(match.Groups[1].Value) < 257 && int.Parse(match.Groups[2].Value) < 257 && int.Parse(match.Groups[3].Value) < 257 && int.Parse(match.Groups[4].Value) < 257 && int.Parse(match.Groups[5].Value) < 65536 && int.Parse(match.Groups[5].Value) > 0)
                //{
                addToServerList(addIP);
                //}
                //else
                //{
                //    MessageBox.Show(GlobalStrings.ServerAddressBody, GlobalStrings.ServerAddressHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                addForm.Dispose();
            }
        }

        private void BeditSL_Click(object sender, EventArgs e)
        {
            // ToDo
            return;
        }

        private void BremoveSL_Click(object sender, EventArgs e)
        {
            if (LBserverHistory.SelectedIndex == -1)
            {
                return;
            }
            LBserverHistory.Items.RemoveAt(LBserverHistory.SelectedIndex);
            saveServerHistory();
        }

        private void BupSL_Click(object sender, EventArgs e)
        {
            int i = LBserverHistory.SelectedIndex;
            if (i < 1)
            {
                return;
            }
            string tmp = LBserverHistory.Items[i].ToString();
            LBserverHistory.Items[i] = LBserverHistory.Items[i - 1].ToString();
            LBserverHistory.Items[i - 1] = tmp;
            saveServerHistory();
            LBserverHistory.SelectedIndex = i - 1;
        }

        private void BdownSL_Click(object sender, EventArgs e)
        {
            int i = LBserverHistory.SelectedIndex;
            if (i == LBserverHistory.Items.Count - 1 || i == -1)
            {
                return;
            }
            string tmp = LBserverHistory.Items[i].ToString();
            LBserverHistory.Items[i] = LBserverHistory.Items[i + 1].ToString();
            LBserverHistory.Items[i + 1] = tmp;
            saveServerHistory();
            LBserverHistory.SelectedIndex = i + 1;
        }

        private void saveServerHistory()
        {
            string serverHistory = "";
            for (int i = 0; i < LBserverHistory.Items.Count; i++)
            {
                serverHistory += LBserverHistory.Items[i].ToString() + (i == LBserverHistory.Items.Count - 1 ? "" : "|");
            }
            Properties.Settings.Default["ServerHistory"] = serverHistory;
            Properties.Settings.Default.Save();
        }

        private void addToServerList(string ip)
        {
            if (LBserverHistory.Items.Contains(ip))
            {
                LBserverHistory.Items.Remove(ip);
            }
            LBserverHistory.Items.Insert(0, ip);
            saveServerHistory();
            LBserverHistory.SelectedIndex = 0;
        }

        // ############################################### HOST SERVER TAB ###############################################

        private void BhostServer_Click(object sender, EventArgs e)
        {
            if (int.Parse(TBport.Text) < 1 || int.Parse(TBport.Text) > 65535)
            {
                MessageBox.Show(GlobalStrings.PortBody, GlobalStrings.PortHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(TBqueryPort.Text) < 1 || int.Parse(TBqueryPort.Text) > 65535)
            {
                MessageBox.Show(GlobalStrings.SteamQueryPortBody, GlobalStrings.SteamQueryPortHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBhostname.Text))
            {
                MessageBox.Show(GlobalStrings.HostnameBody, GlobalStrings.HostnameHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBconfigDir.Text))
            {
                MessageBox.Show(GlobalStrings.ConfigdirBody, GlobalStrings.ConfigdirHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string cmd = "Server Capa_Island";
            if (CBsteamQuery.Checked)
            {
                cmd += "?steamsockets?ServerName=\"" + TBhostname.Text + "\"?Maxplayers=" + TBslots.Text;
            }
            cmd += (CBfriendlyFire.Checked ? "" : "?NoFriendlyFire=True") + ( CBplayerNames.Checked ? "?ShowAllPlayerNames=True" : "");
            cmd += (CBremoveDinos.Checked ? "?NoDinosaurs=True" : "") + " -Port=" + TBport.Text;
            if (CBsteamQuery.Checked){
                cmd += " -QueryPort=" + TBqueryPort.Text;
            }
            if (CBconfigDir.Checked)
            {
                cmd += " --configsubdir=" + TBconfigDir.Text;
            }
            Process[] pname = Process.GetProcessesByName("udk");
            if (pname.Length > 0)
            {
                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry && pname.Length > 0)
                {
                    result = MessageBox.Show(GlobalStrings.ServerAlreadyRunningBody, GlobalStrings.ServerAlreadyRunningHeader, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    Console.WriteLine(result);
                    if (result == DialogResult.Abort)
                    {
                        return;
                    }
                    pname = Process.GetProcessesByName("udk");
                }
            }
            Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", cmd);
            if (CBautoJoin.Checked)
            {
                System.Threading.Thread.Sleep(5000);
                Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", "127.0.0.1:" + TBport.Text);
            }
        }

        private void BloadSC_Click(object sender, EventArgs e)
        {
            if (CBserverConfig.SelectedIndex == -1)
            {
                return;
            }
            serverSetting ss = this.serverSettings[(string)CBserverConfig.SelectedItem];
            CBfriendlyFire.Checked = ss.friendlyFire;
            CBplayerNames.Checked = ss.playerNames;
            CBremoveDinos.Checked = ss.removeDinos;
            CBsteamQuery.Checked = ss.steamQuery;
            TBhostname.Text = ss.hostName;
            TBslots.Text = ss.slots;
            TBport.Text = ss.port;
            TBqueryPort.Text = ss.QueryPort;
            CBconfigDir.Checked = ss.customConfig;
            TBconfigDir.Text = ss.configDir;
            CBautoJoin.Checked = ss.autoJoin;
        }

        private void BsaveSC_Click(object sender, EventArgs e)
        {
            if (CBserverConfig.SelectedIndex == -1)
            {
                return;
            }
            if (int.Parse(TBport.Text) < 1 || int.Parse(TBport.Text) > 65535)
            {
                MessageBox.Show(GlobalStrings.PortBody, GlobalStrings.PortHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(TBqueryPort.Text) < 1 || int.Parse(TBqueryPort.Text) > 65535)
            {
                MessageBox.Show(GlobalStrings.SteamQueryPortBody, GlobalStrings.SteamQueryPortHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBhostname.Text))
            {
                MessageBox.Show(GlobalStrings.HostnameBody, GlobalStrings.HostnameHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBconfigDir.Text))
            {
                MessageBox.Show(GlobalStrings.ConfigdirBody, GlobalStrings.ConfigdirHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string config = (string)CBserverConfig.SelectedItem;
            this.serverSettings[config].friendlyFire = CBfriendlyFire.Checked;
            this.serverSettings[config].playerNames = CBplayerNames.Checked;
            this.serverSettings[config].removeDinos = CBremoveDinos.Checked;
            this.serverSettings[config].steamQuery = CBsteamQuery.Checked;
            this.serverSettings[config].hostName = TBhostname.Text;
            this.serverSettings[config].slots = TBslots.Text;
            this.serverSettings[config].port = TBport.Text;
            this.serverSettings[config].QueryPort = TBqueryPort.Text;
            this.serverSettings[config].customConfig = CBconfigDir.Checked;
            this.serverSettings[config].configDir = TBconfigDir.Text;
            this.serverSettings[config].autoJoin = CBautoJoin.Checked;
            saveServerConfigToSettings();
        }

        private void BnewSC_Click(object sender, EventArgs e)
        {
            addNewServerConfig addForm = new addNewServerConfig();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                string configName = addForm.TBconfigName.Text;
                if (!String.IsNullOrEmpty(configName))
                {
                    CBserverConfig.Items.Insert(0, configName);
                    CBserverConfig.SelectedIndex = 0;
                    this.serverSettings.Add(configName, new serverSetting(CBfriendlyFire.Checked, CBplayerNames.Checked, CBremoveDinos.Checked,
                        CBsteamQuery.Checked, TBhostname.Text, TBslots.Text, TBport.Text, TBqueryPort.Text, CBconfigDir.Checked, TBconfigDir.Text, CBautoJoin.Checked));
                    saveServerConfigToSettings();
                }
                else
                {
                    MessageBox.Show(GlobalStrings.ConfigurationNameBody, GlobalStrings.ConfigurationNameHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                addForm.Dispose();
            }
        }

        private void CBsteamQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (CBsteamQuery.Checked)
            {
                TBhostname.Enabled = true;
                TBqueryPort.Enabled = true;
            }
            else
            {
                TBhostname.Enabled = false;
                TBqueryPort.Enabled = false;
            }
        }

        private void CBconfigDir_CheckedChanged(object sender, EventArgs e)
        {
            if (CBconfigDir.Checked)
            {
                TBconfigDir.Enabled = true;
            }
            else
            {
                TBconfigDir.Enabled = false;
            }
        }

        private void TBsoloHunger_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(TBsoloHunger.Text, out i) && i >= 3000)
            {
                TBsoloHunger.BackColor = Color.LightCoral;
            }
            else
            {
                TBsoloHunger.BackColor = Color.White;
            }
        }

        private void saveServerConfigToSettings()
        {
            MemoryStream ms = new MemoryStream();
            StreamReader sr = new StreamReader(ms);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this.serverSettings);
            ms.Position = 0;
            byte[] buffer = new byte[(int)ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            sr.Close();
            ms.Close();
            Properties.Settings.Default["ServerSettings"] = Convert.ToBase64String(buffer);
            Properties.Settings.Default.Save();
        }

        // ############################################### SOLO SAVEFILE EDITOR ###############################################

        private void BreloadSoloSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Solo.ini"))
            {
                MessageBox.Show(GlobalStrings.SoloSaveNotExistBody, GlobalStrings.SoloSaveNotExistHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process[] pname = Process.GetProcessesByName("udk");
            if (pname.Length > 0)
            {
                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry && pname.Length > 0)
                {
                    result = MessageBox.Show(GlobalStrings.GameStillRunningBody, GlobalStrings.GameStillRunningHeader, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    Console.WriteLine(result);
                    if (result == DialogResult.Abort)
                    {
                        return;
                    }
                    pname = Process.GetProcessesByName("udk");
                }
            }
            string[] soloSaveLines = System.IO.File.ReadAllLines(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Solo.ini");
            Regex rgx = new Regex(@"^SoloData=\(MapName=""capa_island"",Location=\(X=(.*?),Y=(.*?),Z=(.*?)\),Rotation=\(Pitch=(.*?),Yaw=(.*?),Roll=(.*?)\),Stat_Expertise=(.*?),N_Hunger=(.*?),N_Thirst=(.*?),R_Arrows=(.*?),R_Rope=(.*?),R_Herbs=(.*?),.*?,ItemSlot\[0\]=.*?,ItemSlot\[1\]=(.*?),ItemSlot\[2\]=(.*?),ItemSlot\[3\]=(.*?),ItemSlot\[4\]=(.*?),ItemSlot\[5\]=(.*?),ItemSlot\[6\]=(.*?),ItemSlot\[7\]=(.*?),ItemSlot\[8\]=(.*?),ItemSlot\[9\]=(.*?)\)");
            for (int i = 0; i < soloSaveLines.Length; i++)
            {
                Match match = rgx.Match(soloSaveLines[i]);
                if (match.Success)
                {
                    TBsoloX.Text = match.Groups[1].Value;
                    TBsoloY.Text = match.Groups[2].Value;
                    TBsoloZ.Text = match.Groups[3].Value;
                    TBsoloPitch.Text = match.Groups[4].Value;
                    TBsoloYaw.Text = match.Groups[5].Value;
                    TBsoloRoll.Text = match.Groups[6].Value;
                    TBsoloExpertise.Text = match.Groups[7].Value;
                    TBsoloHunger.Text = match.Groups[8].Value;
                    TBsoloThirst.Text = match.Groups[9].Value;
                    TBsoloArrows.Text = match.Groups[10].Value;
                    TBsoloRope.Text = match.Groups[11].Value;
                    TBsoloHerbs.Text = match.Groups[12].Value;
                    CBsoloItemSlot1.SelectedIndex = this.itemToCBindex(match.Groups[13].Value);
                    CBsoloItemSlot2.SelectedIndex = this.itemToCBindex(match.Groups[14].Value);
                    CBsoloItemSlot3.SelectedIndex = this.itemToCBindex(match.Groups[15].Value);
                    CBsoloItemSlot4.SelectedIndex = this.itemToCBindex(match.Groups[16].Value);
                    CBsoloItemSlot5.SelectedIndex = this.itemToCBindex(match.Groups[17].Value);
                    CBsoloItemSlot6.SelectedIndex = this.itemToCBindex(match.Groups[18].Value);
                    CBsoloItemSlot7.SelectedIndex = this.itemToCBindex(match.Groups[19].Value);
                    CBsoloItemSlot8.SelectedIndex = this.itemToCBindex(match.Groups[20].Value);
                    CBsoloItemSlot9.SelectedIndex = this.itemToCBindex(match.Groups[21].Value);
                    return;
                }
            }
        }

        private void BwriteSoloSave_Click(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(TBsoloX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out d) || !Double.TryParse(TBsoloY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out d) || !Double.TryParse(TBsoloZ.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out d))
            {
                MessageBox.Show(GlobalStrings.InvalidPositionBody, GlobalStrings.InvalidPositionHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Solo.ini"))
            {
                MessageBox.Show(GlobalStrings.SoloSaveNotExistBody, GlobalStrings.SoloSaveNotExistHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process[] pname = Process.GetProcessesByName("udk");
            if (pname.Length > 0)
            {
                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry && pname.Length > 0)
                {
                    result = MessageBox.Show(GlobalStrings.GameStillRunningBody, GlobalStrings.GameStillRunningHeader, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    Console.WriteLine(result);
                    if (result == DialogResult.Abort)
                    {
                        return;
                    }
                    pname = Process.GetProcessesByName("udk");
                }
            }
            bool t = true;
            int i;
            string[] soloSaveLines = System.IO.File.ReadAllLines(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Solo.ini");
            Regex rgx = new Regex(@"^SoloData=\(MapName=""capa_island"",Location=");
            for (i = 0; i < soloSaveLines.Length; i++)
            {
                if (rgx.IsMatch(soloSaveLines[i]))
                {
                    if (t)
                    {
                        soloSaveLines[i] = "SoloData=(MapName=\"capa_island\",Location=(X=" + TBsoloX.Text + ",Y=" + TBsoloY.Text + ",Z=" + TBsoloZ.Text
                            + "),Rotation=(Pitch=" + TBsoloPitch.Text + ",Yaw=" + TBsoloYaw.Text + ",Roll=" + TBsoloRoll.Text
                            + "),Stat_Expertise=" + TBsoloExpertise.Text + ",N_Hunger=" + TBsoloHunger.Text + ",N_Thirst=" + TBsoloThirst.Text
                            + ",R_Arrows=" + TBsoloArrows.Text + ",R_Rope=" + TBsoloRope.Text + ",R_Herbs=" + TBsoloHerbs.Text + ",MyTeepee=None,MyTotem=None,MyCage=None,MyCatapult=None,ItemSlot[0]=\"Tomahawk\""
                            + ",ItemSlot[1]=" + this.CBindexToItem(CBsoloItemSlot1.SelectedIndex) + ",ItemSlot[2]=" + this.CBindexToItem(CBsoloItemSlot2.SelectedIndex) + ",ItemSlot[3]=" + this.CBindexToItem(CBsoloItemSlot3.SelectedIndex)
                            + ",ItemSlot[4]=" + this.CBindexToItem(CBsoloItemSlot4.SelectedIndex) + ",ItemSlot[5]=" + this.CBindexToItem(CBsoloItemSlot5.SelectedIndex) + ",ItemSlot[6]=" + this.CBindexToItem(CBsoloItemSlot6.SelectedIndex)
                            + ",ItemSlot[7]=" + this.CBindexToItem(CBsoloItemSlot7.SelectedIndex) + ",ItemSlot[8]=" + this.CBindexToItem(CBsoloItemSlot8.SelectedIndex) + ",ItemSlot[9]=" + this.CBindexToItem(CBsoloItemSlot9.SelectedIndex) + ")";
                        t = false;
                    }
                    else
                    {
                        soloSaveLines[i] = "";
                    }
                }
            }
            if (t && String.IsNullOrEmpty(soloSaveLines[i - 1]))
            {
                soloSaveLines[i - 1] = "SoloData=(MapName=\"capa_island\",Location=(X=" + TBsoloX.Text + ",Y=" + TBsoloY.Text + ",Z=" + TBsoloZ.Text
                    + "),Rotation=(Pitch=" + TBsoloPitch.Text + ",Yaw=" + TBsoloYaw.Text + ",Roll=" + TBsoloRoll.Text
                    + "),Stat_Expertise=" + TBsoloExpertise.Text + ",N_Hunger=" + TBsoloHunger.Text + ",N_Thirst=" + TBsoloThirst.Text
                    + ",R_Arrows=" + TBsoloArrows.Text + ",R_Rope=" + TBsoloRope.Text + ",R_Herbs=" + TBsoloHerbs.Text + ",MyTeepee=None,MyTotem=None,MyCage=None,MyCatapult=None,ItemSlot[0]=\"Tomahawk\""
                    + ",ItemSlot[1]=" + this.CBindexToItem(CBsoloItemSlot1.SelectedIndex) + ",ItemSlot[2]=" + this.CBindexToItem(CBsoloItemSlot2.SelectedIndex) + ",ItemSlot[3]=" + this.CBindexToItem(CBsoloItemSlot3.SelectedIndex)
                    + ",ItemSlot[4]=" + this.CBindexToItem(CBsoloItemSlot4.SelectedIndex) + ",ItemSlot[5]=" + this.CBindexToItem(CBsoloItemSlot5.SelectedIndex) + ",ItemSlot[6]=" + this.CBindexToItem(CBsoloItemSlot6.SelectedIndex)
                    + ",ItemSlot[7]=" + this.CBindexToItem(CBsoloItemSlot7.SelectedIndex) + ",ItemSlot[8]=" + this.CBindexToItem(CBsoloItemSlot8.SelectedIndex) + ",ItemSlot[9]=" + this.CBindexToItem(CBsoloItemSlot9.SelectedIndex) + ")";
                t = false;
            }
            System.IO.File.WriteAllLines(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Solo.ini", soloSaveLines);
            if (CBsoloAutoStart.Checked)
            {
                Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", "capa_island");
            }
        }

        private void BsoloTp_Click(object sender, EventArgs e)
        {
            int selectedWP = CBsoloTpList.SelectedIndex;
            switch (selectedWP)
            {
                case 0:
                    TBsoloX.Text = "89.725906";
                    TBsoloY.Text = "-34004.398438";
                    TBsoloZ.Text = "113.925491";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "10833";
                    TBsoloRoll.Text = "0";
                    break;
                case 1:
                    TBsoloX.Text = "-48754.703125";
                    TBsoloY.Text = "-8867.308594";
                    TBsoloZ.Text = "1724.750244";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "17271";
                    TBsoloRoll.Text = "0";
                    break;
                case 2:
                    TBsoloX.Text = "-35461.242188";
                    TBsoloY.Text = "-21397.582031";
                    TBsoloZ.Text = "918.003479";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "10137";
                    TBsoloRoll.Text = "0";
                    break;
                case 3:
                    TBsoloX.Text = "-19371.386719";
                    TBsoloY.Text = "21350.605469";
                    TBsoloZ.Text = "5841.007813";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "-19733";
                    TBsoloRoll.Text = "0";
                    break;
                case 4:
                    TBsoloX.Text = "-22653.009766";
                    TBsoloY.Text = "23101.542969";
                    TBsoloZ.Text = "3110.780518";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "17315";
                    TBsoloRoll.Text = "0";
                    break;
                case 5:
                    TBsoloX.Text = "21226.568359";
                    TBsoloY.Text = "28516.144531";
                    TBsoloZ.Text = "913.588501";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "14213";
                    TBsoloRoll.Text = "0";
                    break;
                case 6:
                    TBsoloX.Text = "46529.703125";
                    TBsoloY.Text = "-19490.609375";
                    TBsoloZ.Text = "151.390274";
                    TBsoloPitch.Text = "0";
                    TBsoloYaw.Text = "5135";
                    TBsoloRoll.Text = "0";
                    break;
            }
        }

        private void BsoloAddWP_Click(object sender, EventArgs e)
        {
            // ToDo
            return;
        }

        private void BsoloDisableHunger_Click(object sender, EventArgs e)
        {
            TBsoloHunger.Text = "-2147483648";
            TBsoloThirst.Text = "-2147483648";
        }

        private void BsoloUnlimitedAmmo_Click(object sender, EventArgs e)
        {
            TBsoloExpertise.Text = "2147000000";
            TBsoloHerbs.Text = "2147483647";
            TBsoloArrows.Text = "2147483647";
            TBsoloRope.Text = "2147483647";
            CBsoloItemSlot1.SelectedIndex = 1;
            CBsoloItemSlot2.SelectedIndex = 2;
            CBsoloItemSlot3.SelectedIndex = 3;
            CBsoloItemSlot4.SelectedIndex = 4;
            CBsoloItemSlot5.SelectedIndex = 4;
            CBsoloItemSlot6.SelectedIndex = 4;
            CBsoloItemSlot7.SelectedIndex = 4;
            CBsoloItemSlot8.SelectedIndex = 4;
            CBsoloItemSlot9.SelectedIndex = 4;
        }

        private int itemToCBindex(string item)
        {
            switch (item)
            {
                case "\"Bow\"":
                    return 1;
                case "\"Spear\"":
                    return 2;
                case "\"Bolas\"":
                    return 3;
                case "\"Shield\"":
                    return 4;
                default:
                    return 0;
            }
        }

        private string CBindexToItem(int index)
        {
            switch (index)
            {
                case 1:
                    return "\"Bow\"";
                case 2:
                    return "\"Spear\"";
                case 3:
                    return "\"Bolas\"";
                case 4:
                    return "\"Shield\"";
                default:
                    return "";
            }
        }

        // ############################################### SERVER SAVEFILE EDITOR ###############################################

        private void BreloadServerSave_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("udk");
            if (pname.Length > 0)
            {
                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry && pname.Length > 0)
                {
                    result = MessageBox.Show(GlobalStrings.ServerStillRunningBody, GlobalStrings.ServerStillRunningHeader, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    Console.WriteLine(result);
                    if (result == DialogResult.Abort)
                    {
                        return;
                    }
                    pname = Process.GetProcessesByName("udk");
                }
            }
            if (!File.Exists(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Server.ini"))
            {
                MessageBox.Show(GlobalStrings.ServerSaveNotExistBody, GlobalStrings.ServerSaveNotExistHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<PlayerSave> serverSave = new List<PlayerSave>();
            this.serverSaveLines = System.IO.File.ReadAllLines(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Server.ini");
            Regex rgx = new Regex(@"^PlayerData=\(SteamID=(.*?),Location=\(X=(.*?),Y=(.*?),Z=(.*?)\),Rotation=\(Pitch=(.*?),Yaw=(.*?),Roll=(.*?)\),Stat_Expertise=(.*?),N_Hunger=(.*?),N_Thirst=(.*?),R_Arrows=(.*?),R_Rope=(.*?),R_Herbs=(.*?),.*?,ItemSlot\[0\]=.*?,ItemSlot\[1\]=(.*?),ItemSlot\[2\]=(.*?),ItemSlot\[3\]=(.*?),ItemSlot\[4\]=(.*?),ItemSlot\[5\]=(.*?),ItemSlot\[6\]=(.*?),ItemSlot\[7\]=(.*?),ItemSlot\[8\]=(.*?),ItemSlot\[9\]=(.*?)\)");
            for (int i = 0; i < this.serverSaveLines.Length; i++)
            {
                Match match = rgx.Match(this.serverSaveLines[i]);
                if (match.Success)
                {
                    serverSave.Add(new PlayerSave(i, match.Groups[1].Value, double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture), double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture), double.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture),
                        int.Parse(match.Groups[5].Value), int.Parse(match.Groups[6].Value), int.Parse(match.Groups[7].Value), int.Parse(match.Groups[8].Value), int.Parse(match.Groups[9].Value), int.Parse(match.Groups[10].Value), int.Parse(match.Groups[11].Value), int.Parse(match.Groups[12].Value), int.Parse(match.Groups[13].Value),
                        match.Groups[14].Value, match.Groups[15].Value, match.Groups[16].Value, match.Groups[17].Value, match.Groups[18].Value, match.Groups[19].Value, match.Groups[20].Value, match.Groups[21].Value, match.Groups[22].Value));
                }
            }
            DGVserverSave.DataSource = serverSave;
        }

        private void BwriteServerSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Server.ini"))
            {
                MessageBox.Show(GlobalStrings.ServerSaveNotExistBody, GlobalStrings.ServerSaveNotExistHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<PlayerSave> serverSave = (List<PlayerSave>)DGVserverSave.DataSource;
            if (serverSave.Count == 0)
            {
                return;
            }
            Process[] pname = Process.GetProcessesByName("udk");
            if (pname.Length > 0)
            {
                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry && pname.Length > 0)
                {
                    result = MessageBox.Show(GlobalStrings.ServerStillRunningBody, GlobalStrings.ServerStillRunningHeader, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    Console.WriteLine(result);
                    if (result == DialogResult.Abort)
                    {
                        return;
                    }
                    pname = Process.GetProcessesByName("udk");
                }
            }
            foreach (PlayerSave save in serverSave)
            {
                this.serverSaveLines[save.index] = "PlayerData=(SteamID=" + save.id + ",Location=(X=" + save.x.ToString(CultureInfo.InvariantCulture) + ",Y=" + save.y.ToString(CultureInfo.InvariantCulture) + ",Z=" + save.z.ToString(CultureInfo.InvariantCulture)
                    + "),Rotation=(Pitch=" + save.pitch + ",Yaw=" + save.yaw + ",Roll=" + save.roll
                    + "),Stat_Expertise=" + save.expertise + ",N_Hunger=" + save.hunger + ",N_Thirst=" + save.thirst + ",R_Arrows=" + save.arrows + ",R_Rope=" + save.ropes + ",R_Herbs=" + save.herbs + ",MyTeepee=None,MyTotem=None,MyCage=None,MyCatapult=None,ItemSlot[0]=,"
                    + "ItemSlot[1]=" + save.itemSlot1 + ",ItemSlot[2]=" + save.itemSlot2 + ",ItemSlot[3]=" + save.itemSlot3 + ",ItemSlot[4]=" + save.itemSlot4 + ",ItemSlot[5]=" + save.itemSlot5
                    + ",ItemSlot[6]=" + save.itemSlot6 + ",ItemSlot[7]=" + save.itemSlot7 + ",ItemSlot[8]=" + save.itemSlot8 + ",ItemSlot[9]=" + save.itemSlot9 + ")";
            }
            System.IO.File.WriteAllLines(TBpath.Text + "\\UDKGame\\Config\\UDK_TheStompingLand_Server.ini", this.serverSaveLines);
        }

        private void BCopySaveLine_Click(object sender, EventArgs e)
        {
            this.copiedSaveLine = DGVserverSave.CurrentRow.Index;
            BPasteSaveLine.Enabled = true;
        }

        private void BPasteSaveLine_Click(object sender, EventArgs e)
        {
            int line = DGVserverSave.CurrentRow.Index;
            if (CBpasteOnlyPos.Checked)
            {
                for (int i = 1; i < 7; i++)
                {
                    DGVserverSave.Rows[line].Cells[i].Value = DGVserverSave.Rows[this.copiedSaveLine].Cells[i].Value;
                }
            }
            else
            {
                for (int i = 1; i < DGVserverSave.ColumnCount; i++)
                {
                    DGVserverSave.Rows[line].Cells[i].Value = DGVserverSave.Rows[this.copiedSaveLine].Cells[i].Value;
                }
            }
        }

        private void BserverTp_Click(object sender, EventArgs e)
        {
            int line = DGVserverSave.CurrentRow.Index;
            int selectedWP = CBserverTpList.SelectedIndex;
            switch (selectedWP)
            {
                case 0:
                    DGVserverSave.Rows[line].Cells[1].Value = 89.725906;
                    DGVserverSave.Rows[line].Cells[2].Value = -34004.398438;
                    DGVserverSave.Rows[line].Cells[3].Value = 113.925491;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = 10833;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
                case 1:
                    DGVserverSave.Rows[line].Cells[1].Value = -48754.703125;
                    DGVserverSave.Rows[line].Cells[2].Value = -8867.308594;
                    DGVserverSave.Rows[line].Cells[3].Value = 1724.750244;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = 17271;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
                case 2:
                    DGVserverSave.Rows[line].Cells[1].Value = -35461.242188;
                    DGVserverSave.Rows[line].Cells[2].Value = -21397.582031;
                    DGVserverSave.Rows[line].Cells[3].Value = 918.003479;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = 10137;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
                case 3:
                    DGVserverSave.Rows[line].Cells[1].Value = -19371.386719;
                    DGVserverSave.Rows[line].Cells[2].Value = 21350.605469;
                    DGVserverSave.Rows[line].Cells[3].Value = 5841.007813;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = -19733;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
                case 4:
                    DGVserverSave.Rows[line].Cells[1].Value = -22653.009766;
                    DGVserverSave.Rows[line].Cells[2].Value = 23101.542969;
                    DGVserverSave.Rows[line].Cells[3].Value = 3110.780518;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = 17315;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
                case 5:
                    DGVserverSave.Rows[line].Cells[1].Value = 21226.568359;
                    DGVserverSave.Rows[line].Cells[2].Value = 28516.144531;
                    DGVserverSave.Rows[line].Cells[3].Value = 913.588501;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = 14213;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
                case 6:
                    DGVserverSave.Rows[line].Cells[1].Value = 46529.703125;
                    DGVserverSave.Rows[line].Cells[2].Value = -19490.609375;
                    DGVserverSave.Rows[line].Cells[3].Value = 151.390274;
                    DGVserverSave.Rows[line].Cells[4].Value = 0;
                    DGVserverSave.Rows[line].Cells[5].Value = 5135;
                    DGVserverSave.Rows[line].Cells[6].Value = 0;
                    break;
            }
        }

        private void BserverAddWP_Click(object sender, EventArgs e)
        {
            // ToDo
            return;
        }

        // ############################################### HELPER FUNCTION ###############################################

        private void validateNumberInput(object sender, KeyPressEventArgs e)
        {
            int i;
            TextBox tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar) && (!int.TryParse(tb.Text + e.KeyChar, out i) || !(i >= 0)))
            {
                e.Handled = true;
            }
        }

        private void validateNegNumberInput(object sender, KeyPressEventArgs e)
        {
            int i;
            TextBox tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar) && !int.TryParse(tb.Text + e.KeyChar, out i))
            {
                e.Handled = true;
            }
        }

        private void validateDouble(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void validatePort(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar) && !(int.Parse(tb.Text + e.KeyChar) < 65536))
            {
                e.Handled = true;
            }
        }
    }

    // ############################################### HELPER CLASSES ###############################################

    [Serializable()]
    public class serverSetting
    {
        public bool friendlyFire, playerNames, removeDinos, steamQuery, customConfig, autoJoin;
        public string hostName, slots, port, QueryPort, configDir;
        public serverSetting(bool ff, bool pn, bool rd, bool sq, string hn, string sl, string p, string qp, bool cc, string cd, bool aj)
        {
            this.friendlyFire = ff;
            this.playerNames = pn;
            this.removeDinos = rd;
            this.steamQuery = sq;
            this.hostName = hn;
            this.slots = sl;
            this.port = p;
            this.QueryPort = qp;
            this.customConfig = cc;
            this.configDir = cd;
            this.autoJoin = aj;
        }
    }

    class PlayerSave
    {
        public int index;
        public string id { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public int pitch { get; set; }
        public int yaw { get; set; }
        public int roll { get; set; }
        public int expertise { get; set; }
        public int hunger { get; set; }
        public int thirst { get; set; }
        public int herbs { get; set; }
        public int arrows { get; set; }
        public int ropes { get; set; }
        public string itemSlot1 { get; set; }
        public string itemSlot2 { get; set; }
        public string itemSlot3 { get; set; }
        public string itemSlot4 { get; set; }
        public string itemSlot5 { get; set; }
        public string itemSlot6 { get; set; }
        public string itemSlot7 { get; set; }
        public string itemSlot8 { get; set; }
        public string itemSlot9 { get; set; }
        
        public PlayerSave(int index, string id, double x, double y, double z, int pitch, int yaw, int roll, int expertise, int hunger, int thirst, int arrows, int ropes, int herbs,
            string itemSlot1, string itemSlot2, string itemSlot3, string itemSlot4, string itemSlot5, string itemSlot6, string itemSlot7, string itemSlot8, string itemSlot9)
        {
            this.index = index;
            this.id = id;
            this.x = x;
            this.y = y;
            this.z = z;
            this.pitch = pitch;
            this.yaw = yaw;
            this.roll = roll;
            this.expertise = expertise;
            this.hunger = hunger;
            this.thirst = thirst;
            this.arrows = arrows;
            this.ropes = ropes;
            this.herbs = herbs;
            this.itemSlot1 = itemSlot1;
            this.itemSlot2 = itemSlot2;
            this.itemSlot3 = itemSlot3;
            this.itemSlot4 = itemSlot4;
            this.itemSlot5 = itemSlot5;
            this.itemSlot6 = itemSlot6;
            this.itemSlot7 = itemSlot7;
            this.itemSlot8 = itemSlot8;
            this.itemSlot9 = itemSlot9;
        }
    }
}
