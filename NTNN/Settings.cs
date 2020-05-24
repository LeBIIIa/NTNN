using NTNN.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
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

            LoadSettings();
        }

        
        private void LoadSettings()
        {
            Properties.Settings.Default.Reload();
            if (Properties.Settings.Default.Timeout > numericTimeout.Minimum && 
                Properties.Settings.Default.Timeout < numericTimeout.Maximum)
            {
                numericTimeout.Value = Properties.Settings.Default.Timeout;
            }
            if (Properties.Settings.Default.Attempts > numericAttempts.Minimum &&
               Properties.Settings.Default.Attempts < numericAttempts.Maximum)
            {
                numericAttempts.Value = Properties.Settings.Default.Attempts;
            }
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.Attempts = (int)numericAttempts.Value;
                Properties.Settings.Default.Timeout = (int)numericTimeout.Value;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue with saving your settings!  Error: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnExit_Click( object sender, EventArgs e )
        {
            SaveSettings();
        }
    }
}
