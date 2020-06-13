using GN3_API.events;

using GNS3_API;
using GNS3_API.Helpers;

using Newtonsoft.Json;

using NTNN.Helpers;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

using WebSocketSharp;

namespace NTNN
{
    public partial class Form1 : Form
    {
        List<RegisteredDevice> registeredDevices;

        readonly BackgroundWorkerObjectGNS bwoGNS;
        readonly BackgroundWorkerObject bwo;
        readonly BackgroundWorkerChecker checker = BackgroundWorkerChecker.Instance;

        public static readonly string StartText = "Start";
        public static readonly string StopText = "Stop";

        public Form1()
        {
            InitializeComponent();

            UpdateRegisteredDevices();

            (bwo, bwoGNS) = CreateBackgroundWorker();

            btnReloadStatus.Enabled = false;
            btnStartStop.Enabled = false;
            lstNodes.Enabled = false;
            btnGraphics.Enabled = false;

            if (!CheckSettings(out _))
            {
                Settings_Click(null, null);
            }
            else
            {
                ConfigureDeviceChecker();
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
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
        }

        private bool CheckSettings(out string failMessage)
        {
            bool result = true;
            try
            {
                failMessage = "Settings incomplete.  Please setup the settings for: \n";
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
                if (Properties.Settings.Default.HighCPULoad < Helper.CPULoadMin ||
                    Properties.Settings.Default.HighCPULoad > Helper.CPULoadMax)
                {
                    failMessage += " CPU Load \n";
                    result = false;
                }
                if (Properties.Settings.Default.HighRAMLoad < Helper.RAMLoadMin &&
                    Properties.Settings.Default.HighRAMLoad > Helper.RAMLoadMax)
                {
                    failMessage += " RAM Load \n";
                    result = false;
                }
                if (!ValidationHelper.IsEmail(Properties.Settings.Default.NotifyEmail))
                {
                    failMessage += " Notify Email \n";
                    result = false;
                }
                if (result)
                    failMessage = "";
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                result = false;
                failMessage = "Internal Error! Check log file";
            }
            return result;
        }
        private (BackgroundWorkerObject, BackgroundWorkerObjectGNS) CreateBackgroundWorker()
        {
            BackgroundWorkerObject obj = new BackgroundWorkerObject(SynchronizationContext.Current);
            obj.InitProgressBar += InitProgressBar;
            obj.SetTextLabel1 += SetTextLabel1;
            obj.SetTextLabel2 += SetTextLabel2;
            obj.UpdateProgressBar += UpdateProgressBar;
            obj.SetAutoIP += SetAutoIP;
            obj.AddDevice += AddDevice;
            obj.ShowMessageBox += ShowMessageBox;

            BackgroundWorkerObjectGNS gns = new BackgroundWorkerObjectGNS(SynchronizationContext.Current, bwListener);
            gns.SetTextLabel1 += SetTextLabel1;
            gns.ShowMessageBoxWithResult += ShowMessageBoxWithResult;
            gns.SetNodeStatus += SetNodeStatus;
            gns.UpdateNodesTable += UpdateNodesTable;
            gns.StartProject += StartProject;
            gns.StopProject += StopProject;
            gns.GetSelectedNodeName += GetSelectedNodeName;

            return (obj, gns);
        }
        private bool IsWorkingBW(bool showMsg = true)
        {
            if (backgroundWorker.IsBusy || bwGNS3_API.IsBusy || bwListener.IsBusy)
            {
                if (showMsg)
                    MessageBox.Show("There is running operation!");
                return true;
            }
            return false;
        }

        #region Tab1
        private void Scan_Click(object sender, EventArgs e)
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
        private void Stop_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            bwo.Cancel();
        }
        private void StatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsWorkingBW())
                return;

            if (listVAddr.SelectedItems.Count > 0)
            {
                var item = listVAddr.SelectedItems[0].SubItems[0].Text;
                using (ChartStats chart = new ChartStats(item, TypeOfGraph.RealSimulation))
                {
                    chart.ShowDialog();
                }
            }
        }
        #endregion

        #region Tab2
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
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
                bwoGNS.SetGns3Data(projectName, projectId, host, port);
                bwGNS3_API.RunWorkerAsync(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error occur! Check log file.");
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
        }
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            bwGNS3_API.RunWorkerAsync(sender);
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (lstNodes.SelectedItems.Count > 0)
            {
                bwGNS3_API.RunWorkerAsync(e.ClickedItem);
            }
        }
        private void btnReloadStatus_Click(object sender, EventArgs e)
        {
            bwGNS3_API.RunWorkerAsync(sender);
        }
        private void btnGraphics_Click(object sender, EventArgs e)
        {
            using (ChartStats chart = new ChartStats(bwoGNS.Handler.NotificationUrlListener, TypeOfGraph.GNS3Simulation))
            {
                chart.ShowDialog();
            }
        }
        #endregion

        #region Updating UI
        private void SetTextLabel1(SystemCategories category, string text)
        {
            lblStatus1.ToolStripStatusInvokeAction(t => t.Text = text);
            LoggingHelper.LogEntry(category, text);
        }
        private void SetTextLabel1(string text)
        {
            lblStatus1.ToolStripStatusInvokeAction(t => t.Text = text);
        }
        private void SetTextLabel2(string text)
        {
            lblStatus2.ToolStripStatusInvokeAction(t => t.Text = text);
        }
        private void SetAutoIP(string text)
        {
            txtIP.ControlInvokeAction(t => t.Text = text);
        }
        private void InitProgressBar(int total)
        {
            toolStripProgressBar.ToolStripStatusInvokeAction(t =>
            {
                toolStripProgressBar.Minimum = 0;
                toolStripProgressBar.Maximum = total;
                toolStripProgressBar.Value = 0;
            });
        }
        private void UpdateProgressBar(int curVal)
        {
            toolStripProgressBar.ToolStripStatusInvokeAction(t =>
            {
                toolStripProgressBar.Value = curVal;
            });

        }
        private void AddDevice(KeyValuePair<string, string>[] items)
        {
            listVAddr.ControlInvokeAction(l =>
            {
                var item = new ListViewItem();
                item.SubItems.AddRange(Array.ConvertAll(items, (KeyValuePair<string, string> i) =>
                {
                    return new ListViewItem.ListViewSubItem() { Text = i.Value, Name = i.Key };
                }));
                item.SubItems.RemoveAt(0);
                l.Items.Add(item);
            });
        }

        private void ShowMessageBox(string text)
        {
            MessageBox.Show(text);
        }
        private bool ShowMessageBoxWithResult(string text)
        {
            return MessageBox.Show(text, "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        }

        #region TAB2
        private void UpdateNodesTable()
        {
            lstNodes.ControlInvokeAction(lst => lst.Items.Clear());
            if (bwoGNS.Handler != null)
                foreach (Node n in bwoGNS.Handler.Nodes)
                {
                    lstNodes.ControlInvokeAction(lst => lst.Items.Add(new ListViewItem(new[] { n.ConsoleHost, n.Port?.ToString(), n.Name, n.GetType().Name.ToString(), n.GetStatus })));
                }
        }
        private void SetNodeStatus(string status)
        {
            lstNodes.ControlInvokeAction(lst => lst.SelectedItems[0].SubItems[4].Text = status);
        }
        private string GetSelectedNodeName()
        {
            string name = null;
            this.Invoke(new MethodInvoker(() => name = lstNodes.SelectedItems[0].SubItems[2].Text));
            return name;
        }

        private void StartProject(Button btn)
        {
            btn.ControlInvokeAction(b =>
            {
                b.BackColor = Color.IndianRed;
                b.Text = StopText;
                rtbConsole.Visible = true;
            });
        }
        private void StopProject(Button btn)
        {
            btn.ControlInvokeAction(b =>
            {
                b.BackColor = Color.LightGreen;
                b.Text = StartText;
                rtbConsole.Visible = false;
            });
        }

        private void AddLine(string text)
        {
            rtbConsole.ControlInvokeAction(console => console.AppendText($"{text}\r\n"));
        }
        #endregion

        private void UpdateRegisteredDevices()
        {
            registeredDevices = RegisteredDevice.GetRegisteredDevices();
            lstRegisterDevices.Items.Clear();

            foreach (var item in registeredDevices)
            {
                item.Deconstruct(out var collection);
                var lstItem = new ListViewItem();
                lstItem.SubItems.AddRange(Array.ConvertAll(collection, (KeyValuePair<string, string> i) =>
                {
                    return new ListViewItem.ListViewSubItem() { Text = i.Value, Name = i.Key };
                }));
                lstItem.SubItems.RemoveAt(0);
                lstRegisterDevices.Items.Add(lstItem);
            }
            checker.UpdateDevices(registeredDevices);
        }
        #endregion

        #region background workers

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
        private void bwGNS3_API_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnFind.Enabled = true;
            if (bwoGNS.Handler == null)
            {
                btnReloadStatus.Enabled = false;
                btnStartStop.Enabled = false;
                lstNodes.Enabled = false;
                btnGraphics.Enabled = false;
            }
            else
            {
                btnReloadStatus.Enabled = true;
                btnStartStop.Enabled = true;
                lstNodes.Enabled = true;
                btnGraphics.Enabled = true;
            }
        }

        private void bwGNS3_API_DoWork(object sender, DoWorkEventArgs e)
        {
            btnFind.ControlInvokeAction(b => b.Enabled = false);
            btnReloadStatus.ControlInvokeAction(b => b.Enabled = false);
            btnStartStop.ControlInvokeAction(b => b.Enabled = false);
            bwoGNS.DoWork(e.Argument);
        }

        private void bwListener_DoWork(object sender, DoWorkEventArgs e)
        {
            btnFind.ControlInvokeAction(b => b.Enabled = false);
            Regex regex = new Regex("{|}|\"", RegexOptions.Compiled);
            WebSocket ws = null;
            var wait = TimeSpan.FromSeconds(5);
            try
            {
                using (ws = new WebSocket($"ws://{bwoGNS.Handler.NotificationUrlListener}"))
                {
                    Notification notify;
                    ws.WaitTime = wait;
                    ws.OnMessage += (s, ev) =>
                    {
                        notify = JsonConvert.DeserializeObject<Notification>(ev.Data);
                        if (notify.Event is PingEvent)
                            Helper.CheckHighLoad(notify, !string.IsNullOrEmpty(bwoGNS.ProjectName) ? bwoGNS.ProjectName : bwoGNS.Handler.ProjectID);
                        Helper.LogEvent(notify, Helper.SPLogEventGNS3);
                        var text = regex.Replace(ev.Data, "");
                        AddLine($"> {text}");
                    };
                    ws.Connect();
                    while (true)
                    {
                        if (bwListener.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        Thread.Sleep(wait);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message);
            }
        }
        private void bwListener_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnFind.ControlInvokeAction(b => b.Enabled = true);
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var isClosing = false;
            if (IsWorkingBW(false))
            {
                var result = MessageBox.Show("Are you sure want to close program when operation is running?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                isClosing = result == DialogResult.No;
            }

            if (isClosing && bwCheckDevices.IsBusy)
                checker.Cancel();
            e.Cancel = isClosing;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsWorkingBW())
                    return;
                using (Settings settings = new Settings())
                {
                    DialogResult dialogResult = settings.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                        ConfigureDeviceChecker();
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
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                MessageBox.Show("Internal error! Check log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = IsWorkingBW();
        }

        private void contextMenuScannedDevices_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listVAddr.Items.Count == 0 || backgroundWorker.IsBusy || listVAddr.SelectedItems.Count == 0;
            if (sender is ContextMenuStrip strip)
            {
                foreach (ToolStripItem item in strip.Items)
                    item.Enabled = !bwo.IsCancelled
                        || !(bwo.IsCancelled && listVAddr.Items.Count > 0);
            }
        }

        private void lstRegisterDevices_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = lstRegisterDevices.Columns[e.ColumnIndex].Width;
            }
        }

        private void bwCheckDevices_DoWork(object sender, DoWorkEventArgs e)
        {
            checker.StartCheckDevices(registeredDevices);
            while (true)
            {
                if (bwCheckDevices.CancellationPending)
                {
                    checker.Cancel();
                    break;
                }
            }
        }

        private void ConfigureDeviceChecker()
        {
            var enableMonitoring = Properties.Settings.Default.EnableMonitoring;
            if (!enableMonitoring && bwCheckDevices.IsBusy)
                bwCheckDevices.CancelAsync();
            else if (enableMonitoring && !bwCheckDevices.IsBusy)
                bwCheckDevices.RunWorkerAsync();
        }

        private void ToolBtnsForRegisteredDevices_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsWorkingBW())
                {
                    MessageBox.Show("Some of the workers are load. Please wait...");
                    return;
                }
                if ( !(new object[] { addToRegisteredDeviceListToolStripMenuItem, btnAddDevice }.Any(s => s == sender)) &&
                    lstRegisterDevices.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Before perform operations with devices, select one!", "Error", MessageBoxButtons.OK);
                    return;
                }

                TypeOfWork? work = null;
                NameValueCollection nameValue = new NameValueCollection();
                if (sender == addToRegisteredDeviceListToolStripMenuItem)
                {
                    var sel = listVAddr.SelectedItems[0];
                    nameValue.Add("IP", sel.SubItems["IP"].Text);
                    nameValue.Add("Hostname", sel.SubItems["Hostname"].Text);
                    work = TypeOfWork.FromScannedDevice;
                }
                else if (sender == btnAddDevice)
                {
                    work = TypeOfWork.AddDevice;
                }
                else if (sender == btnShowDeviceInf)
                {
                    var registeredDevicePK = int.Parse(lstRegisterDevices.SelectedItems[0].SubItems["RegisteredDevicePK"].Text);
                    var registeredDevice = registeredDevices.Find(r => r.RegisteredDevicePK == registeredDevicePK);
                    using (var form = new ShowInfoForm(registeredDevice))
                    {
                        form.ShowDialog();
                    }
                    return;
                }
                else if (sender == btnUpdDevice)
                {
                    var sel = lstRegisterDevices.SelectedItems[0];
                    nameValue.Add("RegisteredDevicePK", sel.SubItems["RegisteredDevicePK"].Text);
                    nameValue.Add("IP", sel.SubItems["IP"].Text);
                    nameValue.Add("Hostname", sel.SubItems["Hostname"].Text);
                    nameValue.Add("Name", sel.SubItems["Name"].Text);
                    nameValue.Add("Type", sel.SubItems["Type"].Text);
                    nameValue.Add("Port", sel.SubItems["Port"].Text);
                    work = TypeOfWork.UpdateDevice;
                }
                else if (sender == btnDelDevice)
                {
                    var registeredDevicePK = int.Parse(lstRegisterDevices.SelectedItems[0].SubItems["RegisteredDevicePK"].Text);
                    var ret = RegisteredDevice.RemoveRegisteredDevice(registeredDevicePK);
                    if (ret)
                        UpdateRegisteredDevices();
                    else
                        MessageBox.Show("Internal error! Could not remove this device!");
                    return;
                }

                if (!work.HasValue)
                {
                    return;
                }

                using (var form = new RegisterForm(work.Value, nameValue))
                {
                    var ret = form.ShowDialog();
                    if (ret == DialogResult.OK)
                        UpdateRegisteredDevices();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Internal error occur! {ex.Message}");
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
        }
    }
}
