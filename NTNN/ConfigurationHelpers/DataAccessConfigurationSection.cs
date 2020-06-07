using System.Configuration;

namespace NTNN.ConfigurationHelpers
{
    public class DataAccessConfigurationSection : LibraryConfigurationSection
    {
        [ConfigurationProperty("connectionString")]
        public string ConnectionString
        {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }
    }
}
