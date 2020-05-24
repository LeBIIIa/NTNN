using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NTNN.Helpers;

namespace NTNN.ConfigurationHelpers
{
    public class LibraryConfiguration
    {
        private static string mLibraryGroup = "NTNN";

        public static string LibraryGroup
        {
            get { return LibraryConfiguration.mLibraryGroup; }
        }

        public static LibraryConfigurationSection GetLibrarySection(string librarySection)
        {
            return (LibraryConfigurationSection)SettingsHelper.GetSection(mLibraryGroup + "/" + librarySection);
        }
    }
}
