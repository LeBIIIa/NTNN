using System.Configuration;

namespace NTNN.Helpers
{
    public static class SettingsHelper
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static ConfigurationSection GetSection(string section)
        {
            return (ConfigurationSection)ConfigurationManager.GetSection(section);
        }

        public static ConfigurationSectionCollection GetSections(string sectionGroup)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.GetSectionGroup(sectionGroup).Sections;
        }
    }
}
