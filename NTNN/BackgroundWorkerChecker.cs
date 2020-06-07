using GNS3_API.Helpers;

using NTNN.Helpers;

using SnmpSharpNet;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NTNN
{
    public class BackgroundWorkerChecker
    {
        public static BackgroundWorkerChecker Instance = new BackgroundWorkerChecker();

        private DateTime _nextRunTime;
        private CancellationTokenSource tokenSource;
        private List<RegisteredDevice> devices;
        private List<RegisteredDevice> pendingDevices = new List<RegisteredDevice>();

        private BackgroundWorkerChecker() { }

        private void CreateSource()
        {
            tokenSource = new CancellationTokenSource();
        }

        public void Cancel()
        {
            tokenSource.Cancel();
        }

        public void StartCheckDevices(List<RegisteredDevice> devices)
        {
            CreateSource();

            this.devices = devices;

            DateTime startTime = RoundCurrentToNextNMinutes(1);

            Task timerTask = RunPeriodically(CheckDevices,
                startTime, TimeSpan.FromMinutes(1), tokenSource.Token);
        }

        private void CheckDevices(List<RegisteredDevice> devices)
        {
            var ramVariable = new Oid("1.3.6.1.4.1.2021.4");
            var cpuVariable = new Oid("1.3.6.1.4.1.2021.11");
            var sysDesc = new Oid("1.3.6.1.2.1.1.1.0");

            if (pendingDevices.Count > 0)
            {
                devices = new List<RegisteredDevice>(pendingDevices);
                pendingDevices.Clear();
            }

            foreach (var device in devices)
            {
                var pdu = new Pdu(PduType.Get);
                pdu.VbList.Add(sysDesc);
                if (Helper.SendSNMPRequest(pdu, device.GetIPAddress, out _))
                {
                    if (device.Type == DeviceType.PC)
                    {
                        Pdu bulkPdu = Pdu.GetBulkPdu();                            // We don't need any NonRepeaters
                        bulkPdu.NonRepeaters = 0;
                        // Tune MaxRepetitions to the number best suited to retrive the data
                        bulkPdu.MaxRepetitions = 100;
                        bulkPdu.VbList.Add(ramVariable);
                        bulkPdu.VbList.Add(cpuVariable);
                        if (Helper.SendSNMPRequest(bulkPdu, device.GetIPAddress, out var packet) && packet.Pdu.VbCount > 0)
                        {
                            var keys = packet.Pdu.VbList;
                            var cpuUser = keys.Where(s => s.Oid.ToString() == $"{cpuVariable}.9.0").Select(s => int.Parse(s.Value.ToString())).Single();
                            var cpuSystem = keys.Where(s => s.Oid.ToString() == $"{cpuVariable}.10.0").Select(s => int.Parse(s.Value.ToString())).Single();
                            var cpuUsage = cpuUser + cpuSystem;

                            var ramTotal = keys.Where(s => s.Oid.ToString() == $"{ramVariable}.5.0").Select(s => int.Parse(s.Value.ToString())).Single();
                            var ramFree = keys.Where(s => s.Oid.ToString() == $"{ramVariable}.6.0").Select(s => int.Parse(s.Value.ToString())).Single();
                            var ramUsage = (int)(((double)(ramTotal - ramFree) / ramTotal) * 100);
                            Helper.CheckHighLoad(device, cpuUsage, ramUsage);
                        }
                    }
                }
                else
                {
                    Helper.DeviceNotResponse(device);
                }
            }
        }

        public void UpdateDevices(List<RegisteredDevice> devices)
        {
            pendingDevices = devices.ToList();
        }

        async Task RunPeriodically(Action<List<RegisteredDevice>> action,
            DateTime startTime, TimeSpan interval, CancellationToken token)
        {
            _nextRunTime = startTime;

            while (true)
            {
                TimeSpan delay = _nextRunTime - DateTime.UtcNow;

                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, token);
                }

                action.Invoke(devices);
                _nextRunTime += interval;
            }
        }

        DateTime RoundCurrentToNextNMinutes(int min = 5)
        {
            DateTime now = DateTime.UtcNow,
                result = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

            return result.AddMinutes(((now.Minute / min) + 1) * min);
        }
    }
}
