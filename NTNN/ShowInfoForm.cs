using GNS3_API.Helpers;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

using NTNN.Helpers;

using SnmpSharpNet;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace NTNN
{
    public partial class ShowInfoForm : Form
    {
        readonly RegisteredDevice device;
        const int MAXItems = 10;
        readonly ChartValues<ObservableValue> CPUValues = new ChartValues<ObservableValue>();
        readonly ChartValues<ObservableValue> RAMValues = new ChartValues<ObservableValue>();
        static readonly string lblFormat = "{0}% / 100%";

        public ShowInfoForm(RegisteredDevice device)
        {
            InitializeComponent();

            pbCPU.Maximum = 100;
            pbCPU.Minimum = 0;
            pbRAM.Maximum = 100;
            pbRAM.Minimum = 0;
            pbDisk.Maximum = 100;
            pbDisk.Minimum = 0;

            for (int i = 0; i < MAXItems; ++i)
            {
                CPUValues.Add(new ObservableValue());
                RAMValues.Add(new ObservableValue());
            }

            CPU_RAM_usage.AxisX.Add(new Axis
            {
                Title = "Time",
                ShowLabels = false,
            });
            CPU_RAM_usage.AxisY.Add(new Axis
            {
                Title = "%, Load",
                MaxValue = 100,
                MinValue = 0
            });
            CPU_RAM_usage.LegendLocation = LiveCharts.LegendLocation.Right;
            CPU_RAM_usage.Series.Add(new LineSeries()
            {
                Values = RAMValues,
                Title = "RAM",
            });
            CPU_RAM_usage.Series.Add(new LineSeries()
            {
                Values = CPUValues,
                Title = "CPU",
            });

            this.device = device;

            switch (device.Type)
            {
                case DeviceType.PC:
                    lblPCIP.Text = device.IP;
                    lblPCHost.Text = device.Hostname;
                    tabControl.SelectedTab = tpPC;
                    break;
                case DeviceType.Router:
                    lblIPRouter.Text = device.IP;
                    lblHostRouter.Text = device.Hostname;
                    tabControl.SelectedTab = tpRouter;
                    break;
                #region Switch
                //case DeviceType.Switch:
                //    tabControl.SelectedTab = tpSwitch;
                //    break;
                #endregion
                #region Printer
                //case DeviceType.Printer:
                //    tabControl.SelectedTab = tpPrinter;
                //    break;
                #endregion
                default:
                    {
                        MessageBox.Show("Incorrect device type!");
                        DialogResult = DialogResult.Abort;
                        break;
                    }
            }
        }
        private void ShowInfoForm_Load(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }
        private void ShowInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgWorker.CancelAsync();
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Pdu bulkPdu = null;
            switch (device.Type)
            {
                #region Printer
                //case DeviceType.Printer:
                //    break;
                #endregion
                case DeviceType.Router:
                    { 
                        int index = MAXItems - 1;

                        var upTimeOid = new Oid("1.3.6.1.2.1.1.3");

                        var sysNameOid = new Oid("1.3.6.1.2.1.1.5");
                        var sysDescOid = new Oid("1.3.6.1.2.1.1.1");

                        var cpuUtilOid = new Oid("1.3.6.1.2.1.25.3.3.1.2");

                        var interDescOid = new Oid("1.3.6.1.2.1.2.2.1.2");
                        var interInOid = new Oid("1.3.6.1.2.1.2.2.1.10");
                        var interOutOid = new Oid("1.3.6.1.2.1.2.2.1.16");

                        var storageAlloc = new Oid("1.3.6.1.2.1.25.2.3.1.4");
                        var storageSize = new Oid("1.3.6.1.2.1.25.2.3.1.5");
                        var storageUsed = new Oid("1.3.6.1.2.1.25.2.3.1.6");

                        List<Oid> oids = new List<Oid>
                        {
                            upTimeOid
                            ,sysNameOid
                            ,sysDescOid
                            ,cpuUtilOid
                            ,interDescOid
                            ,interInOid
                            ,interOutOid
                            ,storageAlloc
                            ,storageSize
                            ,storageUsed
                        };

                        bulkPdu = Pdu.GetBulkPdu();
                        // We don't need any NonRepeaters
                        bulkPdu.NonRepeaters = 0;
                        // Tune MaxRepetitions to the number best suited to retrive the data
                        bulkPdu.MaxRepetitions = 40;

                        var deviceIP = device.GetIPAddress;

                        Dictionary<Oid, IEnumerable<Vb>> keys = new Dictionary<Oid, IEnumerable<Vb>>();
                        while (true)
                        {
                            keys.Clear();
                            try
                            {
                                if (bgWorker.CancellationPending)
                                    break;
                                bulkPdu.VbList.Clear();
                                oids.ForEach(oid => bulkPdu.VbList.Add(oid));

                                if (Helper.SendSNMPRequest(bulkPdu, deviceIP, out var res, timeout: 3000) && res.Pdu.VbCount > 0)
                                {
                                    var vblist = res.Pdu.VbList.ToList();
                                    var retList = vblist.DistinctBy(s => s.Oid).ToList();
                                    foreach (var oid in oids)
                                        keys[oid] = retList.Where(vb => oid.IsRootOf(vb.Oid)).ToList();

                                    var cpuUsage = keys[cpuUtilOid].Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).Single();

                                    var upTime = keys[upTimeOid].Select(s => s.Value.ToString()).Single();

                                    var sysName = keys[sysNameOid].Select(s => s.Value.ToString()).Single();
                                    var sysDesc = keys[sysDescOid].Select(s => s.Value.ToString()).Single();

                                    var interDesc = keys[interDescOid].Select(s => s.Value.ToString()).ToList();
                                    var interIn = keys[interInOid].Select(s => ValidationSNMPHelper.GetUnsignedInteger(s.Value, 0)).ToList();
                                    var interOut = keys[interOutOid].Select(s => ValidationSNMPHelper.GetUnsignedInteger(s.Value, 0)).ToList();

                                    var interZIP = new List<InterfaceObject>();

                                    for (int i = 0;i<interDesc.Count;++i)
                                    {
                                        interZIP.Add(new InterfaceObject()
                                        {
                                            Desc = interDesc[i],
                                            In = interIn[i],
                                            Out = interOut[i]
                                        });
                                    }

                                    var storAllocArr = keys[storageAlloc].Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).ToList();
                                    var storSize = new BigInteger(0);
                                    var storUsed = new BigInteger(0);
                                    var storSizeVb = keys[storageSize].ToList();
                                    var storUsedVb = keys[storageUsed].ToList();
                                    for (int i = 0; i < storAllocArr.Count; ++i)
                                    {
                                        storSize += new BigInteger(ValidationSNMPHelper.GetInteger(storSizeVb[i].Value, 0) * (double)storAllocArr[i]);
                                        storUsed += new BigInteger(ValidationSNMPHelper.GetInteger(storUsedVb[i].Value, 0) * (double)storAllocArr[i]);
                                    }
                                    var storUsage = (int)(double)BigInteger.Divide(storUsed * 100, storSize);
                                    UpdatePBandLabel(pbCPURouter, lblCPURouter, cpuUsage);
                                    UpdatePBandLabel(pbDiskRouter, lblDiskRouter, storUsage);
                                    UpdateLabel(lblUptime, upTime);
                                    UpdateLabel(lblSysInfo, $"{sysName} - {sysDesc}");
                                    UpdateInterfaces(interZIP);
                                }
                                --index;
                                if (index < 0)
                                    index = MAXItems - 1;
                                Thread.Sleep(3000);
                            }
                            catch (Exception ex)
                            {
                                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                            }
                        }
                        break;
                    }
                #region Switch
                //case DeviceType.Switch:
                //    break;
                #endregion
                case DeviceType.PC:
                    {
                        int index = MAXItems - 1;

                        var ramVariable = new Oid("1.3.6.1.4.1.2021.4");
                        var cpuVariable = new Oid("1.3.6.1.4.1.2021.11");
                        var storageAlloc = new Oid("1.3.6.1.2.1.25.2.3.1.4");
                        var storageSize = new Oid("1.3.6.1.2.1.25.2.3.1.5");
                        var storageUsed = new Oid("1.3.6.1.2.1.25.2.3.1.6");

                        List<Oid> oids = new List<Oid>
                    {
                        ramVariable,
                        cpuVariable,
                        storageAlloc,
                        storageSize,
                        storageUsed
                    };

                        bulkPdu = Pdu.GetBulkPdu();
                        // We don't need any NonRepeaters
                        bulkPdu.NonRepeaters = 0;
                        // Tune MaxRepetitions to the number best suited to retrive the data
                        bulkPdu.MaxRepetitions = 100;

                        var deviceIP = device.GetIPAddress;

                        Dictionary<Oid, IEnumerable<Vb>> keys = new Dictionary<Oid, IEnumerable<Vb>>();
                        while (true)
                        {
                            keys.Clear();
                            try
                            {
                                if (bgWorker.CancellationPending)
                                    break;
                                bulkPdu.VbList.Clear();
                                oids.ForEach(oid => bulkPdu.VbList.Add(oid));

                                if (Helper.SendSNMPRequest(bulkPdu, deviceIP, out var res, timeout: 3000) && res.Pdu.VbCount > 0)
                                {
                                    var vblist = res.Pdu.VbList.ToList();
                                    var retList = vblist.DistinctBy(s => s.Oid).ToList();
                                    foreach (var oid in oids)
                                        keys[oid] = retList.Where(vb => oid.IsRootOf(vb.Oid)).ToList();

                                    var cpuUser = keys[cpuVariable].Where(s => s.Oid.ToString() == $"{cpuVariable}.9.0").Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).Single();
                                    var cpuSystem = keys[cpuVariable].Where(s => s.Oid.ToString() == $"{cpuVariable}.10.0").Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).Single();
                                    var cpuUsage = cpuUser + cpuSystem;

                                    var ramTotal = keys[ramVariable].Where(s => s.Oid.ToString() == $"{ramVariable}.5.0").Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).Single();
                                    var ramFree = keys[ramVariable].Where(s => s.Oid.ToString() == $"{ramVariable}.6.0").Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).Single();
                                    var ramUsage = (int)(((double)(ramTotal - ramFree) / ramTotal) * 100);

                                    var storAllocArr = keys[storageAlloc].Select(s => ValidationSNMPHelper.GetInteger(s.Value, 0)).ToList();
                                    var storSize = new BigInteger(0);
                                    var storUsed = new BigInteger(0);
                                    var storSizeVb = keys[storageSize].ToList();
                                    var storUsedVb = keys[storageUsed].ToList();
                                    for (int i = 0; i < storAllocArr.Count; ++i)
                                    {
                                        storSize += new BigInteger(ValidationSNMPHelper.GetInteger(storSizeVb[i].Value, 0) * (double)storAllocArr[i]);
                                        storUsed += new BigInteger(ValidationSNMPHelper.GetInteger(storUsedVb[i].Value, 0) * (double)storAllocArr[i]);
                                    }
                                    var storUsage = (int)(double)BigInteger.Divide(storUsed * 100, storSize);
                                    UpdatePBandLabel(pbCPU, lblCPU, cpuUsage);
                                    UpdatePBandLabel(pbRAM, lblRAM, ramUsage);
                                    UpdatePBandLabel(pbDisk, lblDisk, storUsage);
                                    CPUValues[index].Value = cpuUsage;
                                    RAMValues[index].Value = ramUsage;
                                }
                                --index;
                                if (index < 0)
                                    index = MAXItems - 1;
                                Thread.Sleep(1000);
                            }
                            catch (Exception ex)
                            {
                                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                            }
                        }
                        break;
                    }
            }
        }


        private void UpdateInterfaces(List<InterfaceObject> interfaces)
        {
            lstInterfaces.ControlInvokeAction(lst => 
            {
                lst.Items.Clear();

                foreach (var item in interfaces)
                {
                    item.Deconstruct(out var collection);
                    var lstItem = new ListViewItem();
                    lstItem.SubItems.AddRange(Array.ConvertAll(collection, (KeyValuePair<string, string> i) =>
                    {
                        return new ListViewItem.ListViewSubItem() { Text = i.Value, Name = i.Key };
                    }));
                    lstItem.SubItems.RemoveAt(0);
                    lst.Items.Add(lstItem);
                }
            });
        }

        private void UpdateLabel(Label lbl, string text)
        {
            lbl.ControlInvokeAction(l =>
            {
                l.Text = text;
            });
        }

        private void UpdatePBandLabel(ProgressBar pb, Label lbl, int val)
        {
            pb.ControlInvokeAction(p =>
            {
                p.Value = val;
            });
            var strFormat = string.Format(lblFormat, val);
            UpdateLabel(lbl, strFormat);
        }
    }
}
