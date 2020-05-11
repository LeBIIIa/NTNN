using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.Extension
{
    public static class LoggingHelper
    {
        private static log4net.Repository.ILoggerRepository _repository = LogManager.GetRepository();
        public static void LogEntry( SystemPriority priority, SystemCategories[] categories, string message )
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            foreach (SystemCategories category in categories)
            {
                log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, _repository.LevelMap[category.ToString()], message, null);
            }
        }

        public static void LogEntry( SystemPriority priority, SystemCategories category, string message )
        {
            LogEntry(priority, new SystemCategories[] { category }, message);
        }
    }

    public enum SystemCategories
    {
        GeneralDebug,
        GeneralInformation,
        GeneralWarning,
        GeneralError,
        GeneralUnknown
    }

    public enum SystemPriority
    {
        Low,
        Medium,
        High,
        Urgent
    }
}
