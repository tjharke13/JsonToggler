using JsonToggler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    public static class JsonConfigHelper
    {
        public static EnvironmentEnum GetEnvironment()
        {
            var section = GetJsonSection();

            return section.Environment;
        }

        public static PlatformEnum GetPlatform()
        {
            var section = GetJsonSection();

            return section.Platform;
        }

        public static bool GetIsTestMode()
        {
            var section = GetJsonSection();

            return section.IsTestMode;
        }

        public static List<string> GetApplications()
        {
            var section = GetJsonSection();

            return section.Applications.ToSplitList();
        }

        public static string GetJsonFileDirectory()
        {
            var section = GetJsonSection();

            var result = section.JsonDirectory;
            if (result.StartsWith("..") || result.StartsWith("~"))
            {
                var binPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                var dirUri = new UriBuilder(binPath);
                //Remove file:// fron string.
                var websiteDir = Uri.UnescapeDataString(dirUri.Path);

                var path = Path.Combine(websiteDir, result);
                result = Path.GetFullPath(path);
            }

            return result;
        }

        private static IJsonTogglerSection GetJsonSection()
        {
            var section = ConfigurationManager.GetSection("JsonToggler") as JsonTogglerSection;

            if (section == null)
                section = new JsonTogglerSection();

            return section;
        }
    }
}
