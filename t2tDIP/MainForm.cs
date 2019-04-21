using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using t2tDIP.Properties;
using static t2tDIP.Logging;

namespace t2tDIP
{
    public partial class MainForm : Form
    {

        private static readonly HttpClient client = new HttpClient();
        private static Logging log = new Logging();

        private readonly List<int> updateIntervals = new List<int>()
        {
            10,
            30,
            60,
            120,
            720,
            1440
        };

        private bool settingsChanged = false;
        private bool fromMenu = false;
        private string latestIp = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private bool MsgQuestion(string question, string title = "t2tDIP")
        {
            return (MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private void MsgInfo(string message, string title = "t2tDIP")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MsgError(string message, string title = "t2tDIP")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.github.com/tip2tail/t2tDIP");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (Settings.Default.AuthCode.Equals(string.Empty))
            {
                // Need a new code!
                txtAuthCode.Text = GenerateNewAuthCode();
                Settings.Default.Save();
            }

            latestIp = GetIPAddress();
            notifyIcon.Text = "t2tDIP - IP: " + latestIp;

            Settings.Default.SettingChanging += Default_SettingChanging;
            Settings.Default.SettingsSaving += Default_SettingsSaving;
            cmbUpdate.SelectedIndex = Settings.Default.UpdateInterval;

            if (!Settings.Default.UpdateServiceURL.Equals(string.Empty))
            {
                // We are already setup!  Hide me!
                WindowState = FormWindowState.Minimized;
                UpdateTheRemoteServerAsync(true);
                StartTimer();
            }

        }

        private void StartTimer()
        {
            timerUpdate.Enabled = false;
            timerUpdate.Interval = ToInterval(updateIntervals[Settings.Default.UpdateInterval]);
            timerUpdate.Enabled = true;
        }

        private int ToInterval(int minutes)
        {
            return (60 * minutes) * 1000;
        }

        private void Default_SettingsSaving(object sender, CancelEventArgs e)
        {
            settingsChanged = false;
        }

        private void Default_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            settingsChanged = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            MsgInfo("Settings Saved!", "Settings");
            StartTimer();
        }

        private void BtnUpdateNow_Click(object sender, EventArgs e)
        {
            do
            {
                if (settingsChanged)
                {
                    if (!MsgQuestion("You must save the settings before you can update the service.  Update now?", "Settings Changed"))
                    {
                        break;
                    }
                    Settings.Default.Save();
                }
                UpdateTheRemoteServerAsync();

                // Restart the timer seeing as we just updated!
                StartTimer();
            } while (false);
        }

        private async void UpdateTheRemoteServerAsync(bool silentFail = false)
        {
            do
            {

                if (Settings.Default.UpdateServiceURL.Equals(string.Empty))
                {
                    if (!silentFail)
                    {
                        MsgError("Invalid update service URL.  Please check!");
                    }
                    log.Log(LogClass.Error, "Invalid update service URL.");
                    log.Log(LogClass.Debug, Settings.Default.UpdateServiceURL);
                    break;
                }

                // Update it!
                bool outcome = await PostHTTPUpdate();

                if (!silentFail)
                {
                    if (outcome)
                    {
                        MsgInfo("Remote server has been updated OK.");
                    }
                    else
                    {
                        MsgError("The remote server update failed. Check the log file for more details.");
                    }
                }
                else
                {
                    if (!outcome)
                    {
                        // Show a balloon tip!
                        notifyIcon.ShowBalloonTip(3000, "t2tDIP", "Remote IP update failed - check log file for details.", ToolTipIcon.Error);
                    }
                }

            } while (false);
        }

        private void BtnNewAuth_Click(object sender, EventArgs e)
        {
            txtAuthCode.Text = GenerateNewAuthCode();
        }

        private string GenerateNewAuthCode()
        {
            return Guid.NewGuid().ToString();
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateTheRemoteServerAsync(true);
        }

        private async Task<bool> PostHTTPUpdate()
        {
            var values = new Dictionary<string, string>
            {
               { "AuthCode", Settings.Default.AuthCode },
               { "IPAddress", GetIPAddress() }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(Settings.Default.UpdateServiceURL, content);
            bool outcome = response.IsSuccessStatusCode;

            // Log the response!
            if (!outcome)
            {
                log.Log(LogClass.Error, "Failed to update the remote server");
            }
            log.Log((outcome ? LogClass.Info : LogClass.Debug), await response.Content.ReadAsStringAsync());

            return outcome;
        }

        private string GetIPAddress()
        {
            latestIp = new WebClient().DownloadString("https://ipv4.icanhazip.com/").Trim();
            notifyIcon.Text = "t2tDIP - IP: " + latestIp;
            return latestIp;
        }

        private void BtnLogs_Click(object sender, EventArgs e)
        {
            Process.Start(log.LogFile);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fromMenu)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromMenu = true;
            Application.Exit();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
