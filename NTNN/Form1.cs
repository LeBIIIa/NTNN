using GNS3_API;
using GNS3_API.Helpers;
using NTNN.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace NTNN
{
    public partial class Form1 : Form
    {
        BackgroundWorkerObject bwo;
        GNS3sharp handler;

        string projectId, host;
        ushort port;

        private static readonly string StartText = "Start";
        private static readonly string StopText = "Stop";

        public Form1()
        {
            InitializeComponent();
            bwo = CreateBackgroundWorker();

            btnStartStop.Enabled = false;
            lstNodes.Enabled = false;

            if (!CheckSettings(out _))
            {
                Settings_Click(null, null);
            }
            else
            {
                lblError.Text = "";
                lblError.Visible = false;
            }

            try
            {
                txtHost.Text = ConfigurationManager.AppSettings["Default-Host"];
                txtPort.Text = ConfigurationManager.AppSettings["Default-Port"];
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
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
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
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

        #region Tab1
        private void Scan_Click( object sender, EventArgs e )
        {
            if (txtIP.AnyBlank && !txtIP.Blank)
            {
                MessageBox.Show("Fill subnet", "Error", MessageBoxButtons.OK);
                return;
            }
            bwo.Subnet = txtIP.ToString();
            bwo.Container = new Helpers.Container();
            listVAddr.Items.Clear();
            backgroundWorker.RunWorkerAsync(bwo);
        }
        private void Stop_Click( object sender, EventArgs e )
        {
            backgroundWorker.CancelAsync();
            bwo.Cancel();
        }
        private void StatsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (IsWorkingBW())
                return;

            if (listVAddr.SelectedItems.Count > 0)
            {
                var item = listVAddr.SelectedItems[0].SubItems[0].Text;
                using (ChartStats chart = new ChartStats(item))
                {
                    chart.ShowDialog();
                }
            }
        }
        #endregion

        #region Tab2
        private void btnFind_Click( object sender, EventArgs e )
        {
            try
            {
                btnStartStop.Enabled = true;
                lstNodes.Enabled = true;
                btnStartStop.Text = StartText;
                lstNodes.Items.Clear();
                var projectName = txtProjectName.Text;
                var host = txtHost.Text;
                var textPort = txtPort.Text;
                var user = txtUserName.Text;
                var password = txtPassword.Text;
                if (string.IsNullOrEmpty(projectName.Trim()))
                {
                    MessageBox.Show("Project name field cannot be empty!");
                    return;
                }
                if (!ushort.TryParse(textPort, out ushort port))
                {
                    MessageBox.Show("Port must be numeric and in range [0; 65535]!");
                    return;
                }
                GNS3sharp.SetCredentials(user, password);
                var projectId = ServerProjects.GetProjectIDByName(projectName, host, port);
                if (string.IsNullOrEmpty(projectId))
                {
                    MessageBox.Show($"Project with name {projectName} isn't found!");
                    return;
                }
                this.host = host;
                this.port = port;
                this.projectId = projectId;
                bwGNS3_API.RunWorkerAsync(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error occur! Check log file.");
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
        }
        private void btnStartStop_Click( object sender, EventArgs e )
        {
            bwGNS3_API.RunWorkerAsync(sender);
        }
        private void contextMenuStrip1_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
        {
            if (lstNodes.SelectedItems.Count > 0)
            {
                bwGNS3_API.RunWorkerAsync(e.ClickedItem);
            }
        }
        private void btnReloadStatus_Click( object sender, EventArgs e )
        {
            bwGNS3_API.RunWorkerAsync(sender);
        }
        private void UpdateNodesTable()
        {
            lstNodes.ControlInvokeAction(lst => lst.Items.Clear());
            if (handler != null)
                foreach (Node n in handler.Nodes)
                {
                    lstNodes.ControlInvokeAction(lst => lst.Items.Add(new ListViewItem(new[] { n.ConsoleHost, n.Port.ToString(), n.Name, n.GetType().Name.ToString(), n.GetStatus })));
                }
        }
        #endregion

        #region Updating UI
        private void SetTextLabel1( SystemCategories category, string text )
        {
            lblStatus1.ToolStripStatusInvokeAction(t => t.Text = text);
            LoggingHelper.LogEntry(category, text);
        }
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
        private void AddDevice( string[] items )
        {
            listVAddr.ControlInvokeAction(l => l.Items.Add(new ListViewItem(items)));
        }
        private void ShowMessageBox( string text )
        {
            MessageBox.Show(text);
        }

        private void AddLine(string text)
        {
            rtbConsole.ControlInvokeAction(console => console.AppendText($"{text}\r\n"));
        }
        #endregion

        private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            if (e.Argument is BackgroundWorkerObject bwo)
            {
                btnScan.ControlInvokeAction(c => c.Enabled = false);
                btnStop.ControlInvokeAction(c => c.Enabled = true);
                bwo.Scan();
            }
            if (sender is BackgroundWorker worker && worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }
        private void backgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            btnScan.Enabled = true;
            btnStop.Enabled = false;
            if (e.Cancelled)
            {
                SetTextLabel1("Cancelled by user");
                SetTextLabel2("");
                InitProgressBar(0);
            }
        }

        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (IsWorkingBW(false))
            {
                var result = MessageBox.Show("Are you sure want to close program when operation is running?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                e.Cancel = result == DialogResult.No;
            }
        }

        private void Settings_Click( object sender, EventArgs e )
        {
            try
            {
                if (IsWorkingBW())
                    return;
                using (Settings settings = new Settings())
                {
                    DialogResult dialogResult = settings.ShowDialog();
                    if (!CheckSettings(out string message))
                    {
                        lblError.Visible = true;
                        lblError.Text = message;
                        btnScan.Enabled = false;
                    }
                    else
                    {
                        lblError.Text = "";
                        lblError.Visible = false;
                        btnScan.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                MessageBox.Show("Internal error! Check log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl_Selecting( object sender, TabControlCancelEventArgs e )
        {
            e.Cancel = IsWorkingBW();
        }

        private bool IsWorkingBW( bool showMsg = true )
        {
            if (backgroundWorker.IsBusy || bwGNS3_API.IsBusy || bwListener.IsBusy)
            {
                if (showMsg)
                    MessageBox.Show("There is running operation!");
                return true;
            }
            return false;
        }

        private void bwGNS3_API_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            btnFind.Enabled = true;
            if (handler == null)
            {
                btnReloadStatus.Enabled = false;
                btnStartStop.Enabled = false;
                lstNodes.Enabled = false;
            }
            else
            {
                btnReloadStatus.Enabled = true;
                btnStartStop.Enabled = true;
                lstNodes.Enabled = true;
            }
        }

        private void bwGNS3_API_DoWork( object sender, DoWorkEventArgs e )
        {
            btnFind.ControlInvokeAction(b => b.Enabled = false);
            btnReloadStatus.ControlInvokeAction(b => b.Enabled = false);
            btnStartStop.ControlInvokeAction(b => b.Enabled = false);
            if (e.Argument is Button btn)
            {
                switch (btn.Name)
                {
                    case "btnFind":
                        handler = new GNS3sharp(projectId, SetTextLabel1, host, port);
                        UpdateNodesTable();
                        break;
                    case "btnReloadStatus":
                        handler.UpdateProject();
                        UpdateNodesTable();
                        break;
                    case "btnStartStop":
                        string text = "";
                        this.Invoke(new MethodInvoker(() => text = btn.Text));
                        if (text == StartText)
                        {
                            handler.StartProject();
                            btn.ControlInvokeAction(b =>
                            {
                                b.BackColor = Color.IndianRed;
                                b.Text = StopText;
                                rtbConsole.Visible = true;
                            });
                            bwListener.RunWorkerAsync();
                        }
                        else if (text == StopText)
                        {
                            handler.StopProject();
                            btn.ControlInvokeAction(b =>
                            {
                                b.BackColor = Color.LightGreen;
                                b.Text = StartText;
                                rtbConsole.Visible = false;
                            });
                            bwListener.CancelAsync();
                        }
                        UpdateNodesTable();
                        break;
                }
            }
            else if (e.Argument is ToolStripItem tsi)
            {
                string item = "";
                this.Invoke(new MethodInvoker(() => item = lstNodes.SelectedItems[0].SubItems[2].Text ));
                var selectedNode = handler.GetNodeByName(item);
                switch (tsi.Name)
                {
                    case "tsStart":
                        handler.StartNode(selectedNode);
                        break;
                    case "tsStop":
                        handler.StopNode(selectedNode);
                        break;
                    case "tsReload":
                        handler.ReloadNode(selectedNode);
                        break;
                    case "tsSuspend":
                        handler.SuspendNode(selectedNode);
                        break;
                    default:
                        MessageBox.Show("Incorrect menu item selected!");
                        break;
                }
                lstNodes.ControlInvokeAction(lst => lst.SelectedItems[0].SubItems[4].Text = selectedNode.GetStatus);
            }
        }

        private void bwListener_DoWork( object sender, DoWorkEventArgs e )
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var token = source.Token;
            WebSocket ws = null;
            try
            {
                using (ws = new WebSocket($"ws://{handler.NotificationUrlListener}"))
                {
                    ws.OnMessage += ( s, ev ) =>
                    {
                        var text = Regex.Replace(ev.Data, "{|}|\"", "");
                        AddLine($"> {text}");
                    };
                    ws.Connect();
                    while (true)
                    {
                        if (bwListener.CancellationPending)
                            source.Cancel();
                        token.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message);
            }
            finally
            {
                if (ws?.IsAlive == true)
                    ws.Close();
            }
        }
    }
}
