using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using t2tDIP.Properties;

namespace t2tDIP
{
    public partial class MainForm : Form
    {

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

        public MainForm()
        {
            InitializeComponent();
        }

        private bool MsgQuestion(string question, string title = "t2tDIP")
        {
            return MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void MsgInfo(string message, string title = "t2tDIP")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            Settings.Default.SettingChanging += Default_SettingChanging;
            Settings.Default.SettingsSaving += Default_SettingsSaving;
            cmbUpdate.SelectedIndex = Settings.Default.UpdateInterval;
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
                }
                UpdateTheRemoteServer();
            } while (false);
        }

        private void UpdateTheRemoteServer()
        {
            
        }

        private void BtnNewAuth_Click(object sender, EventArgs e)
        {
            txtAuthCode.Text = GenerateNewAuthCode();
        }

        private string GenerateNewAuthCode()
        {
            Guid obj = Guid.NewGuid();
            return obj.ToString();
        }
    }
}
