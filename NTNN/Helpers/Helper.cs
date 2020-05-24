using GNS3_API.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

		public static void SendEmail( string To, string From, string Subject, string Msg )
		{
			try
			{
				/*// отправитель - устанавливаем адрес и отображаемое в письме имя
				MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
				// кому отправляем
				MailAddress to = new MailAddress("somemail@yandex.ru");
				// создаем объект сообщения
				MailMessage m = new MailMessage(from, to);
				// тема письма
				m.Subject = "Тест";
				// текст письма
				m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
				// письмо представляет код html
				m.IsBodyHtml = true;
				// адрес smtp-сервера и порт, с которого будем отправлять письмо
				SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
				// логин и пароль
				smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
				smtp.EnableSsl = true;
				smtp.Send(m);
				Console.Read();*/
			}
			catch { }

		}
		//2017-02-06 #16778: #16751: Update 'From' email address in the debug emails to do-not-reply@jeunesseglobal.email
		public static void SendDebugEmail( string Subject, string Msg )
		{

			SendEmail(ConfigurationManager.AppSettings["errorNotifier_EmailTo"], "do-not-reply@jeunesseglobal.email", Subject, Msg);

			// write to Log4Net - most Catches that implement this do not throw error 
			LoggingHelper.LogEntry(SystemCategories.GeneralError, "Debug Email Message: " + Msg);
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

    public enum Status
    {
        Up,
        Down,
        Unstable
    }
}
