using JsonToggler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    /// <summary>
    /// This implentation should be used when loading the features from JSON files directly.
    /// </summary>
    /// <typeparam name="TFeature">The feature implemenation</typeparam>
    public class JsonFeatureToggler<TFeature> : FeatureToggle
    {
        public JsonFeatureToggler()
            : this(JsonConfigHelper.GetPlatform())
        { }

        public JsonFeatureToggler(IJsonTogglerSection jsonTogglerSection)
            : this(jsonTogglerSection.Platform, jsonTogglerSection.Environment, jsonTogglerSection.IsTestMode, jsonTogglerSection.Applications.ToSplitList())
        { }

        public JsonFeatureToggler(PlatformEnum platform)
            : this(platform, JsonConfigHelper.GetEnvironment(), JsonConfigHelper.GetIsTestMode(), JsonConfigHelper.GetApplications())
        { }

        public JsonFeatureToggler(PlatformEnum platform, EnvironmentEnum environment)
            : this(platform, environment, JsonConfigHelper.GetIsTestMode(), JsonConfigHelper.GetApplications())
        { }

        public JsonFeatureToggler(PlatformEnum platform, EnvironmentEnum currentEnvironment, bool isTestMode, List<string> applications) : base(platform, currentEnvironment, isTestMode, applications)
        {
            _featureName = typeof(TFeature).Name;

            //Call this last in the constructor
            SetFeatureToggle();
        }

        private string _featureName { get; set; }


        /// <summary>
        /// Deserialized the JSON Feature Toggle to a 'FeatureToggle' object.
        /// </summary>
        /// <returns>FeatureToggle</returns>
        private void SetFeatureToggle()
        {
            var reader = new JsonTogglerService();

            var feature = reader.GetFeatureToggleFromJson(_featureName);

            this.Name = feature.Name;
            this.Application = feature.Application;
            this.Environment = feature.Environment;
            this.Platform = feature.Platform;
            this.Command = feature.Command;
            this.CommandType = feature.CommandType;
            this.ConnectionStringName = feature.ConnectionStringName;
            this.FilterValues = feature.FilterValues;
            this.SubFeatureToggles = feature.SubFeatureToggles;
            this.SpecificEntities = feature.SpecificEntities;
        }
    }
}
