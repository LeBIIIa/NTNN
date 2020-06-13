using NTNN.Helpers;

using System;
using System.Windows.Forms;

namespace NTNN
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            numericTimeout.Maximum = Helper.TimeoutMax;
            numericTimeout.Minimum = Helper.TimeoutMin;
            numericAttempts.Minimum = Helper.AttemptsMin;
            numericAttempts.Maximum = Helper.AttemptsMax;

            numCPU.Maximum = Helper.CPULoadMax;
            numCPU.Minimum = Helper.CPULoadMin;

            numRAM.Maximum = Helper.RAMLoadMax;
            numRAM.Minimum = Helper.RAMLoadMin;


            LoadSettings();
        }


        private void LoadSettings()
        {
            Properties.Settings.Default.Reload();
            if (Properties.Settings.Default.Timeout > numericTimeout.Minimum &&
                Properties.Settings.Default.Timeout < numericTimeout.Maximum)
                numericTimeout.Value = Properties.Settings.Default.Timeout;

            if (Properties.Settings.Default.Attempts > numericAttempts.Minimum &&
               Properties.Settings.Default.Attempts < numericAttempts.Maximum)
                numericAttempts.Value = Properties.Settings.Default.Attempts;

            cbMonitoring.Checked = Properties.Settings.Default.EnableMonitoring;

            txtNotifyEmail.Text = Properties.Settings.Default.NotifyEmail;

            if (Properties.Settings.Default.HighCPULoad > numericTimeout.Minimum &&
                Properties.Settings.Default.HighCPULoad < numericTimeout.Maximum)
                numCPU.Value = Properties.Settings.Default.HighCPULoad;
            if (Properties.Settings.Default.HighRAMLoad > numericTimeout.Minimum &&
                Properties.Settings.Default.HighRAMLoad < numericTimeout.Maximum)
                numRAM.Value = Properties.Settings.Default.HighRAMLoad;
        }

        private void SaveSettings()
        {
            if (!ValidationHelper.IsEmail(txtNotifyEmail.Text))
            {
                MessageBox.Show("Email isn't correct!");
                return;
            }
            try
            {
                Properties.Settings.Default.Attempts = (int)numericAttempts.Value;
                Properties.Settings.Default.Timeout = (int)numericTimeout.Value;
                Properties.Settings.Default.EnableMonitoring = cbMonitoring.Checked;
                Properties.Settings.Default.NotifyEmail = txtNotifyEmail.Text;
                Properties.Settings.Default.HighCPULoad = (byte)numCPU.Value;
                Properties.Settings.Default.HighRAMLoad = (byte)numRAM.Value;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue with saving your settings!  Error: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
