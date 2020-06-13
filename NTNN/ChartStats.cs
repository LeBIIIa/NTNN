using GN3_API.events;

using GNS3_API.Helpers;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

using Newtonsoft.Json;

using NTNN.ExtendedControls;
using NTNN.Helpers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

using WebSocketSharp;

namespace NTNN
{
    public partial class ChartStats : Form
    {
        readonly TypeOfGraph currType;
        readonly string ip;
        const int MAXItems = 21;
        readonly ChartValues<ObservableValue> PackageValues = new ChartValues<ObservableValue>();
        readonly ChartValues<ObservableValue> InSpeedValues = new ChartValues<ObservableValue>();
        readonly List<PingReply> pingReplies = new List<PingReply>();

        public ChartStats()
        {
            InitializeComponent();
            for (int i = 0; i < MAXItems; ++i)
            {
                PackageValues.Add(new ObservableValue());
                InSpeedValues.Add(new ObservableValue());
            }
        }

        public ChartStats(string ip, TypeOfGraph type) : this()
        {
            currType = type;
            this.ip = ip;
        }

        private void ChartStats_Load(object sender, EventArgs e)
        {
            chartPackages.AxisX.Add(new Axis
            {
                Title = "Time",
                ShowLabels = false,
            });
            if (currType == TypeOfGraph.RealSimulation)
            {
                chartPackages.AxisY.Add(new Axis
                {
                    Title = "Status",
                    Labels = new[] { "Failed", "Success" },
                    MaxValue = 1,
                    MinValue = 0
                });
                chartPackages.LegendLocation = LiveCharts.LegendLocation.Right;
                chartPackages.Series.Add(new LineSeries()
                {
                    Values = PackageValues,
                    Title = "Packages",
                });
            }
            else if (currType == TypeOfGraph.GNS3Simulation)
            {
                chartPackages.AxisY.Add(new Axis
                {
                    Title = "Load, %",
                    Separator = new Separator() { Step = 10 },
                    MaxValue = 100,
                    MinValue = 0
                });
                chartPackages.LegendLocation = LegendLocation.Right;
                chartPackages.Series.Add(new LineSeries()
                {
                    Values = PackageValues,
                    Title = "RAM"

                });
            }
            //
            chartSpeed.AxisX.Add(new Axis
            {
                Title = "Time",
                ShowLabels = false,
            });
            if (currType == TypeOfGraph.RealSimulation)
            {
                chartSpeed.AxisY.Add(new Axis
                {
                    Title = "Speed",
                    LabelFormatter = (val) => val.ToString("F3"),
                    MinValue = 0
                });
                chartSpeed.LegendLocation = LegendLocation.Right;
                chartSpeed.Series.Add(new LineSeries()
                {
                    Values = InSpeedValues,
                    Title = "Speed"

                });
            }
            else if (currType == TypeOfGraph.GNS3Simulation)
            {
                chartSpeed.AxisY.Add(new Axis
                {
                    Title = "Load, %",
                    Separator = new Separator() { Step = 10 },
                    MaxValue = 100,
                    MinValue = 0
                });
                chartSpeed.LegendLocation = LiveCharts.LegendLocation.Right;
                chartSpeed.Series.Add(new LineSeries()
                {
                    Values = InSpeedValues,
                    Title = "CPU",
                });
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                for (int i = 0; i < MAXItems; ++i)
                {
                    PackageValues[i].Value = 0;
                    InSpeedValues[i].Value = 0;
                }
                btnStartStop.Text = "Stop";
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                btnStartStop.Text = "Start";
                backgroundWorker.CancelAsync();
            }
        }

        private async void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = MAXItems - 1;
            if (currType == TypeOfGraph.RealSimulation)
            {
                while (true)
                {
                    try
                    {
                        ExtendedPing ping = new ExtendedPing(i);
                        ping.On_ExtendedPing_Completed += new ExtendedPing.ExtendedPing_Completed(
                        (obj, PingCompletedEventArgs, ident) =>
                        {
                            if (backgroundWorker.CancellationPending)
                                return;
                            pingReplies.Add(PingCompletedEventArgs.Reply);
                            PackageValues[i].Value = PingCompletedEventArgs.Reply.Status == IPStatus.Success ? 1 : 0;
                            double sumTime = pingReplies.Sum(v => (double)v.RoundtripTime) / 1000f;
                            double sumBytes = pingReplies.Sum(v => v.Buffer.Length);
                            InSpeedValues[i].Value = sumTime > 0 ? sumBytes / sumTime : 0;

                            if (obj is Ping p)
                            {
                                p.Dispose();
                            }
                        });
                        await ping.SendPingAsync(ip, 1000);
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                    }
                    --i;
                    if (i < 0)
                        i = MAXItems - 1;
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if (currType == TypeOfGraph.GNS3Simulation)
            {
                WebSocket ws = null;
                var wait = TimeSpan.FromSeconds(3);
                using (ws = new WebSocket($"ws://{ip}"))
                {
                    Notification notify;
                    ws.WaitTime = wait;
                    ws.OnMessage += (s, ev) =>
                    {
                        if (ev.Data.Contains("ping"))
                        {
                            notify = JsonConvert.DeserializeObject<Notification>(ev.Data);
                            if (notify.Event is PingEvent pe)
                            {
                                PackageValues[i].Value = pe.RAMLoad;
                                InSpeedValues[i].Value = pe.CPULoad;
                                --i;
                                if (i < 0)
                                    i = MAXItems - 1;
                            }
                        }
                    };
                    ws.Connect();
                    while (true)
                    {
                        if (backgroundWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        Thread.Sleep(wait);
                    }
                }
            }
        }

        private void ChartStats_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

    }
}
