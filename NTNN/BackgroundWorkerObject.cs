using GNS3_API.Helpers;

using NTNN.ExtendedControls;
using NTNN.Helpers;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NTNN
{
    public class BackgroundWorkerObject
    {
        #region events
        public event Action<int> InitProgressBar;
        public event Action<int> UpdateProgressBar;

        public event Action<string> SetTextLabel1;
        public event Action<string> SetTextLabel2;

        public event Action<string> ShowMessageBox;

        public event Action<string> SetAutoIP;

        public event Action<KeyValuePair<string, string>[]> AddDevice;
        #endregion

        public string Subnet { get; set; }
        public Container Container { get; set; }

        private readonly SynchronizationContext _synchronizationContext;
        private int currProgressVal;
        private int maxProgressVal;
        private bool useAutoIP;
        private CancellationTokenSource tokenSource;
        private int foundDevices;

        public bool IsCancelled => tokenSource != null && tokenSource.IsCancellationRequested;

        public BackgroundWorkerObject(SynchronizationContext context)
        {
            _synchronizationContext = context;
        }

        private void CreateSource()
        {
            tokenSource = new CancellationTokenSource();
        }

        public void Cancel()
        {
            tokenSource.Cancel();
        }

        private string NetworkGateway()
        {
            string ip = null;

            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                    {
                        ip = d.Address.ToString();
                    }
                }
            }

            return ip;
        }
        public void Scan()
        {
            try
            {
                CreateSource();
                List<Task> taskIPs = new List<Task>();
                if (Regex.IsMatch(Subnet, "0+.0+.0+", RegexOptions.Compiled))
                {
                    useAutoIP = true;
                    Subnet = NetworkGateway();
                }

                //Extracting and pinging all other ip's.
                string[] array = Subnet.Split('.');

                if (useAutoIP)
                    SetAutoIP(string.Format("{0}.{1}.{2}", array[0], array[1], array[2]));

                ClearProgress(InitProgressBar, SetTextLabel1, 256, "Running...");

                foundDevices = 0;
                CancellationToken ct = tokenSource.Token;
                for (int i = 0; i <= 255; i++)
                {
                    if (ct.IsCancellationRequested)
                        break;

                    string ping_var = array[0] + "." + array[1] + "." + array[2] + "." + i;

                    //time in milliseconds
                    var task = Task.Factory.StartNew(() => Ping(ping_var, Container.Attempts, Container.Timeout, ct), ct);
                    taskIPs.Add(task);
                }
                Task.WaitAll(taskIPs.ToArray(), ct);
                ClearProgress(InitProgressBar, SetTextLabel1, 0, "Finish");
                ClearProgress(InitProgressBar, SetTextLabel2, 0, $"Found {foundDevices} device(s)");
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
        }
        private void Ping(string host, int attempts, int timeout, CancellationToken ct)
        {
            List<Thread> threads = new List<Thread>();
            ConcurrentBag<KeyValuePair<ExtendedPing, PingCompletedEventArgs>> pings = new ConcurrentBag<KeyValuePair<ExtendedPing, PingCompletedEventArgs>>();
            try
            {
                int counter = 0;
                SetTextLabel2($"Pinging: {host}");
                for (int i = 0; i < attempts; i++)
                {
                    var th = new Thread(delegate ()
                    {
                        try
                        {
                            ExtendedPing ping = new ExtendedPing(i);
                            ping.PingCompleted += new PingCompletedEventHandler((obj, PingCompletedEventArgs) =>
                            {
                                pings.Add(new KeyValuePair<ExtendedPing, PingCompletedEventArgs>((ExtendedPing)obj, PingCompletedEventArgs));
                                Interlocked.Decrement(ref counter);
                            });
                            ping.SendAsync(host, timeout, host);
                        }
                        catch (Exception ex)
                        {
                            LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                        }
                    });
                    th.Start();
                    threads.Add(th);
                    Interlocked.Increment(ref counter);
                }
                while (Interlocked.CompareExchange(ref counter, 0, 0) > 0 && !ct.IsCancellationRequested)
                    Thread.Sleep(100);

                if (!ct.IsCancellationRequested)
                {
                    var status = pings.All(p => p.Value.Reply.Status == IPStatus.Success) ? Status.Up : pings.Any(p => p.Value.Reply.Status == IPStatus.Success) ? Status.Unstable : Status.Down;
                    UpdateProgress(UpdateProgressBar, SetTextLabel2, $"Status: {host} - {status}");
                    if (status != Status.Down)
                    {
                        Interlocked.Increment(ref foundDevices);
                        string hostname = GetHostName(host);
                        string macaddres = GetMacAddress(host);
                        AddDevice(new KeyValuePair<string, string>[]
                        {
                            new KeyValuePair<string, string>("IP", host),
                            new KeyValuePair<string, string>("Hostname", hostname),
                            new KeyValuePair<string, string>("Macaddress", macaddres),
                            new KeyValuePair<string, string>("Status", status.ToString()),
                        });
                    }
                }

                ct.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException) { }
            finally
            {
                if (ct.IsCancellationRequested)
                    for (int i = 0; i < threads.Count; ++i)
                        threads[i].Abort();
                foreach (var ping in pings)
                    ping.Key.Dispose();
            }
        }
        public static string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (SocketException ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }

            return null;
        }
        //Get MAC address
        public static string GetMacAddress(string ipAddress)
        {
            System.Diagnostics.Process Process = new System.Diagnostics.Process();
            Process.StartInfo.FileName = "arp";
            Process.StartInfo.Arguments = "-a " + ipAddress;
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.CreateNoWindow = true;
            Process.Start();
            string strOutput = Process.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                string macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
             + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
             + "-" + substrings[7] + "-"
             + substrings[8].Substring(0, 2);
                return macAddress;
            }

            else
            {
                return "OWN Machine";
            }
        }

        #region Synchronization progress bar/message box
        private void ClearProgress(Action<int> initPB, Action<string> lblUpdate, int total, string labelText)
        {
            currProgressVal = 0;
            maxProgressVal = total;
            initPB(total);
            lblUpdate(labelText);
        }
        private void UpdateProgress(Action<int> updPB, Action<string> lblUpdate, string labelText = "")
        {
            currProgressVal = (currProgressVal + 1) % maxProgressVal;
            updPB(currProgressVal);
            lblUpdate(labelText);
        }
        private void ShowMessage(string text)
        {
            _synchronizationContext.Send(callback => ShowMessageBox(text), null);
        }
        #endregion
    }
}
