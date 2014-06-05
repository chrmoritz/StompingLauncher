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

namespace TheStompingLandLauncher
{
    public partial class mainForm : Form
    {
        public Dictionary<String, serverSetting> serverSettings;

        public mainForm()
        {
            InitializeComponent();
            //Load stored Settings
            TBjoinIP.Text = (string)Properties.Settings.Default["lastConnected"];
            String serverHistory = (string)Properties.Settings.Default["ServerHistory"];

            String[] history = serverHistory.Split('|');
            if (history.Length > 1 || !String.IsNullOrEmpty(history[0]))
            {
                LBserverHistory.Items.AddRange(history);
            }

            String settings = (string)Properties.Settings.Default["ServerSettings"];
            if (String.IsNullOrEmpty(settings))
            {
                this.serverSettings = new Dictionary<String, serverSetting>();
            }
            else
            {
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(settings));
                BinaryFormatter bf = new BinaryFormatter();
                this.serverSettings = (Dictionary<String, serverSetting>)bf.Deserialize(ms);
            }
            foreach (var config in this.serverSettings.Keys)
            {
                CBserverConfig.Items.Add(config);
            }

            String TSLpath = (string)Properties.Settings.Default["TSLpath"];
            if (Directory.Exists(TSLpath))
            {
                TBpath.Text = TSLpath;
            }
            else
            {
                //try to detect TSLpath via steams registry entry
                String steamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
                String path = steamPath.Replace("/", "\\") + "\\steamapps\\common\\the stomping land";
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

        private void BjoinServer_Click(object sender, EventArgs e)
        {
            String server = TBjoinIP.Text;
            //Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
            //var match = rgx.Match(server);
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
            String cmd = "Server Capa_Island";
            if (CBsteamQuery.Checked)
            {
                cmd += "?steamsockets?ServerName=\"" + TBhostname.Text + "\"";
            }
            cmd += "?NoFriendlyFire=" + !CBfriendlyFire.Checked + "?ShowAllPlayerNames=" + CBplayerNames.Checked + (CBremoveDinos.Checked ? "?NoDinosaurs=True" : "");
            cmd += " -Port=" + TBport.Text + " -QueryPort=" + TBqueryPort.Text;
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

        private void BserbasedSP_Click(object sender, EventArgs e)
        {
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
            Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", "Server Capa_Island?NoFriendlyFire=True");
            System.Threading.Thread.Sleep(5000);
            Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", "127.0.0.1:7777");
        }

        private void CBsteamQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (CBsteamQuery.Checked)
            {
                TBhostname.Enabled = true;
            }
            else
            {
                TBhostname.Enabled = false;
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

        private void TBjoinIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ':')
            //{
            //    e.Handled = true;
            //}
        }

        private void TBport_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isInvalidPort(e.KeyChar, TBport.Text);
        }

        private void TBqueryPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isInvalidPort(e.KeyChar, TBqueryPort.Text);
        }

        private bool isInvalidPort(char key, String input)
        {
            if (!char.IsControl(key) && !char.IsDigit(key))
            {
                return true;
            }
            if (char.IsDigit(key) && !(int.Parse(input + key) < 65536))
            {
                return true;
            }
            return false;
        }

        private void BconnectSL_Click(object sender, EventArgs e)
        {
            if (LBserverHistory.SelectedIndex == -1)
            {
                return;
            }
            String server = (string) LBserverHistory.SelectedItem;
            Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
            var match = rgx.Match(server);
            if (match.Success && int.Parse(match.Groups[1].Value) < 257 && int.Parse(match.Groups[2].Value) < 257 && int.Parse(match.Groups[3].Value) < 257 && int.Parse(match.Groups[4].Value) < 257 && int.Parse(match.Groups[5].Value) < 65536 && int.Parse(match.Groups[5].Value) > 0)
            {
                Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", server);
                Properties.Settings.Default["lastConnected"] = TBjoinIP.Text;
                LBserverHistory.Items.Insert(0, server);
                LBserverHistory.SelectedIndex = 0;
                Properties.Settings.Default.Save();
            }
            else
            {
                LBserverHistory.Items.RemoveAt(LBserverHistory.SelectedIndex);
            }
        }

        private void BaddSL_Click(object sender, EventArgs e)
        {
            addHistoryServerForm addForm = new addHistoryServerForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                String addIP = addForm.TBaddServerIP.Text;
                //Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
                //var match = rgx.Match(addIP);
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

        private void BremoveSL_Click(object sender, EventArgs e)
        {
            if (LBserverHistory.SelectedIndex == -1)
            {
                return;
            }
            LBserverHistory.Items.RemoveAt(LBserverHistory.SelectedIndex);
            saveServerHistory();
        }

        private void saveServerHistory()
        {
            String serverHistory = "";
            for (int i = 0; i < LBserverHistory.Items.Count; i++)
            {
                serverHistory += LBserverHistory.Items[i].ToString() + (i==LBserverHistory.Items.Count-1 ? "" : "|");
            }
            Properties.Settings.Default["ServerHistory"] = serverHistory;
            Properties.Settings.Default.Save();
        }

        private void BupSL_Click(object sender, EventArgs e)
        {
            int i = LBserverHistory.SelectedIndex;
            if (i < 1)
            {
                return;
            }
            String tmp = LBserverHistory.Items[i].ToString();
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
            String tmp = LBserverHistory.Items[i].ToString();
            LBserverHistory.Items[i] = LBserverHistory.Items[i + 1].ToString();
            LBserverHistory.Items[i + 1] = tmp;
            saveServerHistory();
            LBserverHistory.SelectedIndex = i + 1;
        }

        private void addToServerList(String ip)
        {
            if (LBserverHistory.Items.Contains(ip))
            {
                int i = LBserverHistory.Items.IndexOf(ip);
                LBserverHistory.Items[i] = LBserverHistory.Items[0].ToString();
                LBserverHistory.Items[0] = ip;
            }
            else
            {
                LBserverHistory.Items.Insert(0, ip);
            }
            saveServerHistory();
            LBserverHistory.SelectedIndex = 0;
        }

        private void BloadSC_Click(object sender, EventArgs e)
        {
            if (CBserverConfig.SelectedIndex == -1)
            {
                return;
            }
            serverSetting ss = this.serverSettings[(string) CBserverConfig.SelectedItem];
            CBfriendlyFire.Checked = ss.friendlyFire;
            CBplayerNames.Checked = ss.playerNames;
            CBremoveDinos.Checked = ss.removeDinos;
            CBsteamQuery.Checked = ss.steamQuery;
            TBhostname.Text = ss.hostName;
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
            String config = (string)CBserverConfig.SelectedItem;
            this.serverSettings[config].friendlyFire = CBfriendlyFire.Checked;
            this.serverSettings[config].playerNames = CBplayerNames.Checked;
            this.serverSettings[config].removeDinos = CBremoveDinos.Checked;
            this.serverSettings[config].steamQuery = CBsteamQuery.Checked;
            this.serverSettings[config].hostName = TBhostname.Text;
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
                String configName = addForm.TBconfigName.Text;
                if (!String.IsNullOrEmpty(configName))
                {
                    CBserverConfig.Items.Insert(0, configName);
                    CBserverConfig.SelectedIndex = 0;
                    this.serverSettings.Add(configName, new serverSetting(CBfriendlyFire.Checked, CBplayerNames.Checked, CBremoveDinos.Checked,
                        CBsteamQuery.Checked, TBhostname.Text, TBport.Text, TBqueryPort.Text, CBconfigDir.Checked, TBconfigDir.Text, CBautoJoin.Checked));
                    saveServerConfigToSettings();
                }
                else
                {
                    MessageBox.Show(GlobalStrings.ConfigurationNameBody, GlobalStrings.ConfigurationNameHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                addForm.Dispose();
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
            Properties.Settings.Default["ServerSettings"] = Convert.ToBase64String(buffer);
            Properties.Settings.Default.Save();
        }

        private void BreloadServerSave_Click(object sender, EventArgs e)
        {
            List<PlayerSave> serverSave = new List<PlayerSave>();
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            serverSave.Add(new PlayerSave("0x011000010917387C", -1001.621460, -37301.777344, 112.390411, 904, 31936, 0, 1051, 0, 0, 1000, 1000, 1000, "Bow", "Spear", "Shield", "Bola", "Shield", "Shield", "Shield", "Shield", "Shield"));
            DGVserverSave.DataSource = serverSave;
        }

        private void BwriteServerSave_Click(object sender, EventArgs e)
        {

        }
    }

    class PlayerSave
    {
        public string id;
        public int expertise;
        public int hunger;
        public int thirst;
        public int herbs;
        public int arrows;
        public int ropes;
        public string itemSlot1;
        public string itemSlot2;
        public string itemSlot3;
        public string itemSlot4;
        public string itemSlot5;
        public string itemSlot6;
        public string itemSlot7;
        public string itemSlot8;
        public string itemSlot9;
        public double x;
        public double y;
        public double z;
        public int pitch;
        public int yaw;
        public int roll;
        public PlayerSave(string id, double x, double y, double z, int pitch, int yaw, int roll, int expertise, int hunger, int thirst, int arrows, int ropes, int herbs,
            string itemSlot1, string itemSlot2, string itemSlot3, string itemSlot4, string itemSlot5, string itemSlot6, string itemSlot7, string itemSlot8, string itemSlot9)
        {
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
        public string ID { get { return id; } }
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }
        public int Pitch { get { return pitch; } }
        public int Yaw { get { return yaw; } }
        public int Roll { get { return roll; } }
        public int Expertise { get { return expertise; } }
        public int Hunger { get { return hunger; } }
        public int Thirst { get { return thirst; } }
        public int Arrows { get { return arrows; } }
        public int Ropes { get { return ropes; } }
        public int Herbs { get { return herbs; } }
        public string ItemSlot1 { get { return itemSlot1; } }
        public string ItemSlot2 { get { return itemSlot2; } }
        public string ItemSlot3 { get { return itemSlot3; } }
        public string ItemSlot4 { get { return itemSlot4; } }
        public string ItemSlot5 { get { return itemSlot5; } }
        public string ItemSlot6 { get { return itemSlot6; } }
        public string ItemSlot7 { get { return itemSlot7; } }
        public string ItemSlot8 { get { return itemSlot8; } }
        public string ItemSlot9 { get { return itemSlot9; } }
    }

    [Serializable()]
    public class serverSetting
    {
        public bool friendlyFire, playerNames, removeDinos, steamQuery, customConfig, autoJoin;
        public String hostName, port, QueryPort, configDir;
        public serverSetting(bool ff, bool pn, bool rd, bool sq, String hn, String p, String qp, bool cc, String cd, bool aj)
        {
            this.friendlyFire = ff;
            this.playerNames = pn;
            this.removeDinos = rd;
            this.steamQuery = sq;
            this.hostName = hn;
            this.port = p;
            this.QueryPort = qp;
            this.customConfig = cc;
            this.configDir = cd;
            this.autoJoin = aj;
        }
    }
}
