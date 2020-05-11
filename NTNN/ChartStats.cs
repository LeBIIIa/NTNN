using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using NTNN.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTNN
{
    public partial class ChartStats : Form
    {
        string ip;
        const int MAXItems = 21;
        ChartValues<ObservableValue> PackageValues = new ChartValues<ObservableValue>();
        ChartValues<ObservableValue> InSpeedValues = new ChartValues<ObservableValue>();

        List<PingReply> pingReplies = new List<PingReply>();

        public ChartStats()
        {
            InitializeComponent();
            for (int i = 0;i<MAXItems;++i)
            {
                PackageValues.Add(new ObservableValue());
                InSpeedValues.Add(new ObservableValue());
            }
        }

        public ChartStats(string ip) : this()
        {
            this.ip = ip;
        }

        private void ChartStats_Load( object sender, EventArgs e )
        {
            chartPackages.AxisX.Add(new Axis
            {
                Title = "Time",
                ShowLabels = false,
            });
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
            //
            chartSpeed.AxisX.Add(new Axis
            {
                Title = "Time",
                ShowLabels = false,
            });
            chartSpeed.AxisY.Add(new Axis
            {
                Title = "Speed",
                LabelFormatter = ( val ) => val.ToString("F3"),
                MinValue = 0
            });
            chartSpeed.LegendLocation = LegendLocation.Right;
            chartSpeed.Series.Add(new LineSeries()
            {
                Values = InSpeedValues,
                Title = "Speed"
                
            });
        }

        private void btnStartStop_Click( object sender, EventArgs e )
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

        private async void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            int i = 0;
            while (true)
            {
                try
                {
                    ExtendedPing ping = new ExtendedPing(i);
                    ping.On_ExtendedPing_Completed += new ExtendedPing.ExtendedPing_Completed(
                    ( obj, PingCompletedEventArgs, ident ) =>
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
                    LoggingHelper.LogEntry(SystemPriority.High, SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                }
                i = ( i + 1 ) % MAXItems;
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void ChartStats_FormClosing( object sender, FormClosingEventArgs e )
        {
            backgroundWorker.CancelAsync();
        }
    }
}
