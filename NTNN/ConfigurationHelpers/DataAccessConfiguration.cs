namespace NTNN.ConfigurationHelpers
{
    public class DataAccessConfiguration : LibraryConfiguration
    {
        private static string mDataAccessSection = "DataAccess";

        public static DataAccessConfigurationSection DataAccessSection
        {
            get { return (DataAccessConfigurationSection)GetLibrarySection(mDataAccessSection); }
        }
    }
}
