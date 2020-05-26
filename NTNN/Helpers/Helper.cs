using GN3_API.events;
using GNS3_API.Helpers;
using NTNN.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.Helpers
{
	public static class Helper
	{
		public static int AttemptsMax = 100;
		public static int AttemptsMin = 1;
		public static int TimeoutMax = 60000;
		public static int TimeoutMin = 1000;

		public static string SPLogEvent { get; private set; }
		public static double? HighLoadRAM { get; private set; }
		public static double? HighLoadCPU { get; private set; }

		static Helper()
		{
			double temp;
			SPLogEvent = ConfigurationManager.AppSettings["spLogEvent"];
			if (double.TryParse(ConfigurationManager.AppSettings["highLoadCPU"], out temp))
			{
				HighLoadCPU = temp;
			}
			if (double.TryParse(ConfigurationManager.AppSettings["highLoadRAM"], out temp))
			{
				HighLoadRAM = temp;
			}
		}

		public static void SendEmail( string To, string Subject, string Msg )
		{
			try
			{
				var smtp = new SmtpClient();
				MailAddress from = new MailAddress(( (NetworkCredential)smtp.Credentials ).UserName, "Do not reply");
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
		public static void SendDebugEmail( string Subject, string Msg )
		{
			SendEmail(ConfigurationManager.AppSettings["alertNotifyEmailTo"], Subject, Msg);

			// write to Log4Net - most Catches that implement this do not throw error 
			LoggingHelper.LogEntry(SystemCategories.GeneralError, "Debug Email Message: " + Msg);
		}

		public static void CheckHighLoad( Notification notify, string projectName )
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

		public static bool LogEvent( Notification notify, string spProcedure )
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
}