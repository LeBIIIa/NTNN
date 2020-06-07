using log4net;

namespace GNS3_API.Helpers
{
    public static class LoggingHelper
    {
        private static log4net.Repository.ILoggerRepository _repository = LogManager.GetRepository();
        public static void LogEntry(SystemCategories[] categories, string message)
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            foreach (SystemCategories category in categories)
            {
                log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, _repository.LevelMap[category.ToString()], message, null);
            }
        }

        public static void LogEntry(SystemCategories category, string message)
        {
            LogEntry(new SystemCategories[] { category }, message);
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
}
