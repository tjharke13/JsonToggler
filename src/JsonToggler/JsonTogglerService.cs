using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using JsonToggler;


namespace JsonToggler
{
    public class JsonTogglerService
    {
        public JsonTogglerService() : this(JsonConfigHelper.GetJsonFileDirectory())
        { }

        public JsonTogglerService(string jsonFileDirectory)
        {
            _jsonDirectory = jsonFileDirectory;

            if (string.IsNullOrEmpty(_jsonDirectory))
                throw new MissingFieldException("JsonDirectory field doesn't exist in app settings.");
        }

        private string _jsonDirectory { get; set; }

        /// <summary>
        /// Get a list of all the Feature Toggles.  
        /// This will read in and de-serialize all JSON files into objects.
        /// </summary>
        /// <returns>Collection of FeatureToggle objects.</returns>
        public List<IFeatureToggle> GetAllFeatureToggles()
        {
            var jsonFiles = GetJsonFiles();

            var result = new List<IFeatureToggle>();
            foreach (var jsonFile in jsonFiles)
            {
                var featureToggle = GetFeatureToggleFromJson(jsonFile);

                result.Add(featureToggle);
            }

            return result;
        }

        /// <summary>
        /// Get's all Feature Toggles from the JSON files that exist for the provided environment.
        /// </summary>
        /// <param name="environment">EnvironmentEnum e.g. Local, Dev, QAS, Stage, Prod</param>
        /// <returns>A collection of FeatureToggles for the environment.</returns>
        public List<FeatureToggle> GetAllFeatureTogglesForEnvironment(EnvironmentEnum environment)
        {
            var jsonFiles = GetJsonFiles();

            var result = new List<FeatureToggle>();
            foreach (var jsonFile in jsonFiles)
            {
                var featureToggle = GetFeatureToggleFromJson(jsonFile);

                if (environment.Has<EnvironmentEnum>(featureToggle.Environment) || featureToggle.SubFeatureToggles.Where(w => environment.Has<EnvironmentEnum>(w.Environment) == true).Count() > 0)
                    result.Add(featureToggle);
            }

            return result;
        }

        /// <summary>
        /// Get all Feature Toggles for the provided platform.  
        /// This should be called for the specific application.
        /// </summary>
        /// <param name="platform">PlatformEnum e.g. Web, Android, iOS, etc..</param>
        /// <returns>A collection of FeatureToggles for the platform.</returns>
        public List<FeatureToggle> GetAllFeatureTogglesForPlatform(PlatformEnum platform)
        {
            var jsonFiles = GetJsonFiles();

            var result = new List<FeatureToggle>();
            foreach (var jsonFile in jsonFiles)
            {
                var featureToggle = GetFeatureToggleFromJson(jsonFile);

                if (platform.Has<PlatformEnum>(featureToggle.Platform) || featureToggle.SubFeatureToggles.Where(w => w.Platform != 0 && platform.Has<PlatformEnum>(w.Platform)).Count() > 0)
                    result.Add(featureToggle);
            }

            return result;
        }

        /// <summary>
        /// Get all Feature Toggles for the provided platform.  
        /// This should be called for the specific application.
        /// </summary>
        /// <param name="platform">PlatformEnum e.g. Web, Android, iOS, etc..</param>
        /// <returns>A collection of FeatureToggles for the platform.</returns>
        public List<FeatureToggle> GetAllFeatureTogglesForPlatformAndApplication(PlatformEnum platform, string application)
        {
            var jsonFiles = GetJsonFiles();

            var result = new List<FeatureToggle>();
            foreach (var jsonFile in jsonFiles)
            {
                var featureToggle = GetFeatureToggleFromJson(jsonFile);

                if ((application.ToUpper() == "ALL" || string.IsNullOrEmpty(featureToggle.Application) || featureToggle.Application.ToUpper() == "ALL" || featureToggle.Application == application) &&
                    (platform.Has<PlatformEnum>(featureToggle.Platform) ||
                    featureToggle.SubFeatureToggles.Where(w => w.Platform != 0 && platform.Has<PlatformEnum>(w.Platform)).Count() > 0))
                {
                    result.Add(featureToggle);
                }
            }

            return result;
        }

        public List<FeatureToggle> GetAllFeatureTogglesForPlatformAndEnvironment(PlatformEnum platform, EnvironmentEnum environment)
        {
            var jsonFiles = GetJsonFiles();

            var result = new List<FeatureToggle>();
            foreach (var jsonFile in jsonFiles)
            {
                var featureToggle = GetFeatureToggleFromJson(jsonFile);

                if (platform.Has<PlatformEnum>(featureToggle.Platform) &&
                    (environment.Has<EnvironmentEnum>(featureToggle.Environment) ||
                    featureToggle.SubFeatureToggles.Where(w => w.Platform != 0 && platform.Has<PlatformEnum>(w.Platform) && environment.Has<EnvironmentEnum>(w.Environment)).Count() > 0))
                {
                    result.Add(featureToggle);
                }
            }

            return result;
        }

        /// <summary>
        /// Reads in JSON file defining the Feature Toggle information.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>A Feature Toggle object defined in the JSON file.</returns>
        public FeatureToggle GetFeatureToggleFromJson(string fileName)
        {
            var feature = new FeatureToggle();
            var filePath = string.Empty;

            if (!fileName.EndsWith(".json"))
                fileName += ".json";

            filePath = Path.Combine(_jsonDirectory, fileName.Replace(" ", "_"));

            if(!File.Exists(filePath))
                filePath = Path.Combine(_jsonDirectory, fileName.Replace(" ", ""));

            if (!File.Exists(filePath))
                filePath = Path.Combine(_jsonDirectory, fileName.Replace("_", ""));

            if (!File.Exists(filePath))
                filePath = Path.Combine(_jsonDirectory, fileName.SplitCamelCase());

            if (!File.Exists(filePath))
            {
                var file = fileName.SplitCamelCase();
                var splitFileName = file.Split('_'); 

                if(splitFileName.Count() > 2)
                {
                    for(int i = 0; i <= splitFileName.Count(); i++)
                    {
                        fileName = file.Replace(splitFileName[i] + "_", splitFileName[i]);
                        filePath = Path.Combine(_jsonDirectory, fileName);

                        if (File.Exists(filePath))
                            break;
                    }
                }
            }
                

            if (File.Exists(filePath))
            {
                using (var re = new StreamReader(filePath))
                {
                    var reader = new JsonTextReader(re);
                    var jsonSerializer = new JsonSerializer();
                    feature = jsonSerializer.Deserialize<FeatureToggle>(reader);

                    if (feature != null && string.IsNullOrEmpty(feature.Name))
                    {
                        var toggleName = Path.GetFileNameWithoutExtension(filePath);
                        feature.Name = toggleName.Replace("_", " ").SplitCamelCase(" ");
                    }
                }
            }
            
            return feature;
        }

        #region Private Helper Methods

        /// <summary>
        /// Get all JSON files that exist in the specified directory.  
        /// This should be where all of the Feature Toggles exist.
        /// </summary>
        /// <returns></returns>
        public List<string> GetJsonFiles()
        {
            // Process the list of files found in the directory. 
            var jsonFiles = Directory.GetFiles(_jsonDirectory, "*.json");

            return jsonFiles.ToList();
        }

        #endregion
    }
}
