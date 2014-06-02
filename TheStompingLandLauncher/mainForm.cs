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

            //ToDo: fix this:
            String settings = (string)Properties.Settings.Default["ServerSettings"];
            Console.WriteLine("loading settings: " + settings);
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
                    MessageBox.Show("Sorry, we couldn't detect your Stomping Land folder :( Please select your Stomping Land Folder (the one containing Binaries, Engine and UDKGame) in the next dialog.", "Couldn't detect The Stomping Land folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
            var match = rgx.Match(server);
            if (match.Success && int.Parse(match.Groups[1].Value) < 257 && int.Parse(match.Groups[2].Value) < 257 && int.Parse(match.Groups[3].Value) < 257 && int.Parse(match.Groups[4].Value) < 257 && int.Parse(match.Groups[5].Value) < 65536 && int.Parse(match.Groups[5].Value) > 0)
            {
                Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", server);
                Properties.Settings.Default["lastConnected"] = TBjoinIP.Text;
                addToServerList(server);
            }
            else
            {
                MessageBox.Show("Please enter a valid server address. (eg. if you want to connect to a local server enter 127.0.0.1:7777)", "Error: Invalid server address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BhostServer_Click(object sender, EventArgs e)
        {
            if (int.Parse(TBport.Text) < 1 || int.Parse(TBport.Text) > 65535)
            {
                MessageBox.Show("Please enter a valid port. (between 1 and 65535)", "Error: Invalid port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(TBqueryPort.Text) < 1 || int.Parse(TBqueryPort.Text) > 65535)
            {
                MessageBox.Show("Please enter a valid SteamQueryPort. (between 1 and 65535)", "Error: Invalid SteamQueryPort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBhostname.Text))
            {
                MessageBox.Show("Please enter a valid (not empty) hostname.", "Error: Invalid hostname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBconfigDir.Text))
            {
                MessageBox.Show("Please enter a valid (not empty) configdir.", "Error: Invalid configdir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String cmd = "Server Capa_Island";
            if (CBsteamQuery.Checked)
            {
                cmd += "?steamsockets?ServerName=\"" + TBhostname.Text + "\"";
            }
            cmd += "?NoFriendlyFire=" + !CBfriendlyFire.Checked + "?ShowAllPlayerNames=" + CBplayerNames.Checked + "?NoDinosaurs=" + CBremoveDinos.Checked;
            cmd += " -Port=" + TBport.Text + " -QueryPort=" + TBqueryPort.Text;
            if (CBconfigDir.Checked)
            {
                cmd += " --configsubdir=" + TBconfigDir.Text;
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
            Process.Start(TBpath.Text + "\\Binaries\\Win32\\UDK.exe", "Server Capa_Island");
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ':')
            {
                e.Handled = true;
            }
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
                Regex rgx = new Regex(@"^(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?)\.(\d\d?\d?):(\d\d?\d?\d?\d?)$");
                var match = rgx.Match(addIP);
                if (match.Success && int.Parse(match.Groups[1].Value) < 257 && int.Parse(match.Groups[2].Value) < 257 && int.Parse(match.Groups[3].Value) < 257 && int.Parse(match.Groups[4].Value) < 257 && int.Parse(match.Groups[5].Value) < 65536 && int.Parse(match.Groups[5].Value) > 0)
                {
                    addToServerList(addIP);
                }
                else
                {
                    MessageBox.Show("Please enter a valid server address. (eg. if you want to connect to a local server enter 127.0.0.1:7777)", "Error: Invalid server address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            LBserverHistory.Items.Insert(0, ip);
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
                MessageBox.Show("Please enter a valid port. (between 1 and 65535)", "Error: Invalid port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(TBqueryPort.Text) < 1 || int.Parse(TBqueryPort.Text) > 65535)
            {
                MessageBox.Show("Please enter a valid SteamQueryPort. (between 1 and 65535)", "Error: Invalid SteamQueryPort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBhostname.Text))
            {
                MessageBox.Show("Please enter a valid (not empty) hostname.", "Error: Invalid hostname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TBconfigDir.Text))
            {
                MessageBox.Show("Please enter a valid (not empty) configdir.", "Error: Invalid configdir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Please enter a valid (not empty) configuration name.", "Error: Invalid Configuration Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Console.WriteLine("base64: " + Convert.ToBase64String(buffer));
            Properties.Settings.Default["ServerSettings"] = Convert.ToBase64String(buffer);
            Properties.Settings.Default.Save();
        }
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
