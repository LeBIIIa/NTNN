﻿using GN3_API.events;

using GNS3_API.Helpers;

using NTNN.DAL;

using SnmpSharpNet;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace NTNN.Helpers
{
    public static class Helper
    {
        public static int AttemptsMax = 100;
        public static int AttemptsMin = 1;
        public static int TimeoutMax = 60000;
        public static int TimeoutMin = 1000;

        public static readonly string DefaultHost = "notIdentify";

        public static string SPLogEventGNS3 { get; private set; }
        public static double? HighLoadRAM { get; private set; }
        public static double? HighLoadCPU { get; private set; }

        static Helper()
        {
            SPLogEventGNS3 = ConfigurationManager.AppSettings["spLogEventGNS3"];
            if (double.TryParse(ConfigurationManager.AppSettings["highLoadCPU"], out double temp))
            {
                HighLoadCPU = temp;
            }
            if (double.TryParse(ConfigurationManager.AppSettings["highLoadRAM"], out temp))
            {
                HighLoadRAM = temp;
            }
        }

        public static void SendEmail(string To, string Subject, string Msg)
        {
            try
            {
                var smtp = new SmtpClient();
                MailAddress from = new MailAddress(((NetworkCredential)smtp.Credentials).UserName, "Do not reply");
                // кому отправляем
                MailAddress to = new MailAddress(To);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to)
                {
                    Subject = Subject,
                    Body = Msg,
                    IsBodyHtml = true
                };
                smtp.Send(m);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }

        }
        public static void SendDebugEmail(string Subject, string Msg)
        {
            SendEmail(ConfigurationManager.AppSettings["alertNotifyEmailTo"], Subject, Msg);

            // write to Log4Net - most Catches that implement this do not throw error 
            LoggingHelper.LogEntry(SystemCategories.GeneralError, "Debug Email Message: " + Msg);
        }

        public static void CheckHighLoad(Notification notify, string projectName)
        {
            if (HighLoadCPU.HasValue && HighLoadRAM.HasValue)
            {
                PingEvent pr = (PingEvent)notify.Event;
                if (pr.CPULoad >= HighLoadCPU.Value && pr.RAMLoad >= HighLoadRAM.Value)
                    SendDebugEmail($"ALERT! HIGH RAM and CPU USAGE of {projectName} GNS3", $@"
						<b>cpu_usage_percent: {pr.CPULoad}<br>
						memory_usage_percent: {pr.RAMLoad}</b>");
                else if (pr.CPULoad >= HighLoadCPU.Value)
                {
                    SendDebugEmail($"ALERT! HIGH CPU USAGE of {projectName} GNS3", $@"
					<b>cpu_usage_percent: {pr.CPULoad}</b><br>
					memory_usage_percent: {pr.RAMLoad}");
                }
                else if (pr.RAMLoad >= HighLoadRAM.Value)
                {
                    SendDebugEmail($"ALERT! HIGH RAM USAGE of {projectName} GNS3", $@"
						cpu_usage_percent: {pr.CPULoad}<br>
						<b>memory_usage_percent: {pr.RAMLoad}</b>");
                }
            }
            else
            {
                if (!HighLoadCPU.HasValue)
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, "HighLoadCPU variable isn't set or is incorrect");
                else if (HighLoadRAM.HasValue)
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, "HighLoadRAM variable isn't set or is incorrect");
            }
        }

        public static void CheckHighLoad(RegisteredDevice device, int curLoadCPU, int curLoadRAM)
        {
            if (HighLoadCPU.HasValue && HighLoadRAM.HasValue)
            {
                if (curLoadCPU >= HighLoadCPU.Value && curLoadRAM >= HighLoadRAM.Value)
                    SendDebugEmail($"ALERT! HIGH RAM and CPU USAGE of {device.IP}", $@"
                        Device:<br>
                        Name: <b>{device.Name}</b><br>                        
                        Hostname: <b>{device.Hostname}</b><br>
                        IP: <b>{device.IP}</b><br>
                        Device type: <b>{device.Type}</b><br>
						<b>CPU Load: {curLoadCPU}%<br>
						RAM Load: {curLoadRAM}</b>");
                else if (curLoadCPU >= HighLoadCPU.Value)
                {
                    SendDebugEmail($"ALERT! HIGH CPU USAGE of {device.IP}", $@"
                        Device:<br>
                        Name: <b>{device.Name}</b><br>                        
                        Hostname: <b>{device.Hostname}</b><br>
                        IP: <b>{device.IP}</b><br>
                        Device type: <b>{device.Type}</b><br>
					    <b>CPU Load: {curLoadCPU}</b><br>
					    RAM Load: {curLoadRAM}");
                }
                else if (curLoadRAM >= HighLoadRAM.Value)
                {
                    SendDebugEmail($"ALERT! HIGH RAM USAGE of {device.IP}", $@"
                        Device:<br>
                        Name: <b>{device.Name}</b><br>                        
                        Hostname: <b>{device.Hostname}</b><br>
                        IP: <b>{device.IP}</b><br>
                        Device type: <b>{device.Type}</b><br>
						CPU Load: {curLoadCPU}<br>
						<b>RAM Load: {curLoadRAM}</b>");
                }
            }
            else
            {
                if (!HighLoadCPU.HasValue)
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, "HighLoadCPU variable isn't set or is incorrect");
                else if (HighLoadRAM.HasValue)
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, "HighLoadRAM variable isn't set or is incorrect");
            }
        }

        public static void DeviceNotResponse(RegisteredDevice device)
        {
            SendDebugEmail($"ALERT! Device {device.IP} doesn't response!", $@"
						Device:<br>
                        Name: <b>{device.Name}</b><br>                        
                        Hostname: <b>{device.Hostname}</b><br>
                        IP: <b>{device.IP}</b><br>
                        Device type: <b>{device.Type}</b><br>
                        <b>DOESN'T RESPONSE!<b>");
        }

        public static bool LogEvent(Notification notify, string spProcedure)
        {
            bool ret = false;
            try
            {
                using (SqlCommand sql = new SqlCommand(spProcedure))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@EventName", notify.Action);
                    sql.Parameters.AddWithValue("@EventJSON", notify.EventJson);
                    DataAccess.ExecuteNonQuery(sql);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return ret;
        }

        public static bool SendSNMPRequest(Pdu pdu, IPAddress ip, out SnmpPacket packet, SnmpVersion version = SnmpVersion.Ver2, string community = "public", int port = 161, int timeout = 1000, int retry = 1)
        {
            // Define agent parameters class
            AgentParameters agentParams = new AgentParameters(new OctetString(community))
            {
                Version = version,
            };
            packet = null;
            try
            {
                UdpTarget target = new UdpTarget(ip, port, timeout, retry);
                SnmpPacket res;
                // Keep looping through results until end of table
                try
                {
                    res = target.Request(pdu, agentParams);
                }
                catch (Exception ex)
                {
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                    target.Close();
                    return false;
                }

                #region Validate request
                if (res.Version != version)
                {
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, "Received wrong SNMP version response packet.");
                    target.Close();
                    return false;
                }
                if (res.Pdu.ErrorStatus != 0)
                {
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, $"SNMP agent returned error {res.Pdu.ErrorStatus} for request Vb index {res.Pdu.ErrorIndex}");
                    target.Close();
                    return false;
                }
                #endregion

                target.Close();

                packet = res;
                return true;
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
            return false;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
    public class Container
    {
        public int Attempts { get; }
        public int Timeout { get; }
        public string SelectedAdapter { get; }
        public Container()
        {
            Attempts = Properties.Settings.Default.Attempts;
            Timeout = Properties.Settings.Default.Timeout;
            SelectedAdapter = Properties.Settings.Default.SelectedAdapter;
        }
    }

    public enum TypeOfGraph
    {
        Unknown,
        RealSimulation,
        GNS3Simulation
    }

    public enum Status
    {
        Up,
        Down,
        Unstable
    }

    public enum TypeOfWork
    {
        FromScannedDevice,
        AddDevice,
        UpdateDevice,
    }
}