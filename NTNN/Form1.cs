using NTNN.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTNN
{
    public partial class Form1 : Form
    {
        BackgroundWorkerObject bwo;

        public Form1()
        {
            InitializeComponent();
            bwo = CreateBackgroundWorker();

            if (!CheckSettings(out _))
            {
                tsBtnSettings_Click(null, null);
            }
            else
            {
                lblError.Text = "";
                lblError.Visible = false;
            }

        }

        private bool CheckSettings( out string failMessage )
        {
            bool result = true;
            try
            {
                failMessage = "Settings incomplete.  Please setup the settings for: \n";
                if (string.IsNullOrEmpty(Properties.Settings.Default.SelectedAdapter))
                {
                    failMessage += " Adapter \n";
                    result = false;
                }
                if (Properties.Settings.Default.Timeout < Helper.TimeoutMin ||
                    Properties.Settings.Default.Timeout > Helper.TimeoutMax)
                {
                    failMessage += " Timeout \n";
                    result = false;
                }
                if (Properties.Settings.Default.Attempts < Helper.AttemptsMin ||
                                    Properties.Settings.Default.Attempts > Helper.AttemptsMax)
                {
                    failMessage += " Attempts \n";
                    result = false;
                }
                if (result)
                    failMessage = "";
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemPriority.High, SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                result = false;
                failMessage = "Internal Error! Check log file";
            }
            return result;
        }
        private BackgroundWorkerObject CreateBackgroundWorker()
        {
            BackgroundWorkerObject obj = new BackgroundWorkerObject(SynchronizationContext.Current);
            obj.InitProgressBar += InitProgressBar;
            obj.SetTextLabel1 += SetTextLabel1;
            obj.SetTextLabel2 += SetTextLabel2;
            obj.UpdateProgressBar += UpdateProgressBar;
            obj.SetAutoIP += SetAutoIP;
            obj.AddDevice += AddDevice;
            obj.ShowMessageBox += ShowMessageBox;
            return obj;
        }

        private void cmdScan_Click( object sender, EventArgs e )
        {
            if (txtIP.AnyBlank && !txtIP.Blank)
            {
                MessageBox.Show("Fill subnet", "Error", MessageBoxButtons.OK);
                return;
            }
            bwo.Subnet = txtIP.ToString();
            bwo.Container = new Extension.Container();
            listVAddr.Items.Clear();
            backgroundWorker.RunWorkerAsync(bwo);
        }
        private void cmdStop_Click( object sender, EventArgs e )
        {
            backgroundWorker.CancelAsync();
            bwo.Cancel();
        }
        private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            if (e.Argument is BackgroundWorkerObject bwo)
            {
                cmdScan.ControlInvokeAction(c => c.Enabled = false);
                cmdStop.ControlInvokeAction(c => c.Enabled = true);
                bwo.Scan();
            }
            if (sender is BackgroundWorker worker && worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        #region Updating UI
        private void SetTextLabel1( string text )
        {
            lblStatus1.ToolStripStatusInvokeAction(t => t.Text = text);
        }
        private void SetTextLabel2( string text )
        {
            lblStatus2.ToolStripStatusInvokeAction(t => t.Text = text);
        }
        private void SetAutoIP( string text )
        {
            txtIP.ControlInvokeAction(t => t.Text = text);
        }
        private void InitProgressBar( int total )
        {
            toolStripProgressBar.ToolStripStatusInvokeAction(t =>
            {
                toolStripProgressBar.Minimum = 0;
                toolStripProgressBar.Maximum = total;
                toolStripProgressBar.Value = 0;
            });
        }
        private void UpdateProgressBar( int curVal )
        {
            toolStripProgressBar.ToolStripStatusInvokeAction(t =>
            {
                toolStripProgressBar.Value = curVal;
            });

        }
        private void AddDevice(string[] items)
        {
            listVAddr.ControlInvokeAction(l => l.Items.Add(new ListViewItem(items)));
        }
        private void ShowMessageBox(string text)
        {
            MessageBox.Show(text);
        }
        #endregion

        private void backgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            cmdScan.Enabled = true;
            cmdStop.Enabled = false;
            if (e.Cancelled)
            {
                SetTextLabel1("Cancelled by user");
                SetTextLabel2("");
                InitProgressBar(0);
            }
        }

        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (backgroundWorker.IsBusy)
            {
                var result = MessageBox.Show("Are you sure want to close program when operation is running?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                e.Cancel = result == DialogResult.No;
            }
        }

        private void tsBtnSettings_Click( object sender, EventArgs e )
        {
            try
            {
                if (backgroundWorker.IsBusy)
                {
                    MessageBox.Show("Wait to complete the operation!");
                    return;
                }
                using (Settings settings = new Settings())
                {
                    DialogResult dialogResult = settings.ShowDialog();
                    if (!CheckSettings(out string message))
                    {
                        lblError.Text = message;
                        cmdScan.Enabled = false;
                    }
                    else
                    {
                        lblError.Text = "";
                        lblError.Visible = false;
                        cmdScan.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemPriority.High, SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                MessageBox.Show("Internal error! Check log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void statsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Wait to complete the operation!");
                return;
            }

            if (listVAddr.SelectedItems.Count > 0)
            {
                var item = listVAddr.SelectedItems[0].SubItems[0].Text;
                using (ChartStats chart = new ChartStats(item))
                {
                    chart.Show();
                }
            }
        }
    }
}
