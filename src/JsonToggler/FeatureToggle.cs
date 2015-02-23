using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JsonToggler
{
    /// <summary>
    /// When we have the feature toggle information and we don't need the library to 
    /// load the feature toggle implementation use this.  e.g. When using an API this should be used.
    /// </summary>
    public class FeatureToggle : IFeatureToggle
    {
        public FeatureToggle()
            : this(JsonConfigHelper.GetPlatform(), JsonConfigHelper.GetEnvironment(), JsonConfigHelper.GetIsTestMode())
        { }

        public FeatureToggle(IJsonTogglerSection jsonTogglerSection)
            : this(jsonTogglerSection.Platform, jsonTogglerSection.Environment, jsonTogglerSection.IsTestMode)
        { }

        public FeatureToggle(PlatformEnum platform, EnvironmentEnum currentEnvironment, bool isTestMode)
        {
            _currentEnvironment = currentEnvironment;
            _currentPlatform = platform;
            _isTestMode = isTestMode;
            _togglerHelper = new JsonTogglerHelper();
        }

        protected EnvironmentEnum _currentEnvironment { get; set; }
        protected PlatformEnum _currentPlatform { get; set; }
        protected bool _isTestMode { get; set; }
        protected JsonTogglerHelper _togglerHelper { get; set; }

        public string Name { get; set; }

        public EnvironmentEnum Environment { get; set; }

        public PlatformEnum Platform { get; set; }

        public virtual CommandTypeEnum? CommandType { get; set; }

        /// <summary>
        /// If this is a SQL query it will need to return True or False only.
        /// </summary>
        public string Command { get; set; }

        public string ConnectionStringName { get; set; }

        public List<string> FilterValues { get; set; }

        [JsonIgnore]
        public bool IsSubFeature { get { return false; } }

        public virtual List<SubFeatureToggle> SubFeatureToggles { get; set; }

        public virtual List<string> SpecificEntities { get; set; }



        /// <summary>
        /// Determines if the feature toggle is enabled.
        /// </summary>
        /// <param name="featureToggle"></param>
        /// <returns></returns>
        public virtual bool IsEnabled()
        {
            return this.IsEnabled(null);
        }

        public virtual bool IsEnabled(string specificEntityId)
        {
            if(_currentEnvironment == 0)
                _currentEnvironment = JsonConfigHelper.GetEnvironment();

            return _togglerHelper.IsEnabled(this, _currentEnvironment, _currentPlatform, specificEntityId, _isTestMode);
        }

        /// <summary>
        /// Filters a dataset based upon the column and feature toggle.
        /// </summary>
        /// <returns></returns>
        public virtual DataSet FilterDataSet<TFilterType>(DataSet data, string columnName, IFeature featureToggle, bool showOnlyItemsSpecified = false)
        {
            return _togglerHelper.FilterDataSet<TFilterType>(data, columnName, this, this.IsEnabled(), showOnlyItemsSpecified);
        }

        /// <summary>
        /// Filters a collection of a generic type based upon the provided info.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TFilterType"></typeparam>
        /// <param name="data"></param>
        /// <param name="columnName"></param>
        /// <param name="featureToggle"></param>
        /// <param name="showOnlyItemsSpecified"></param>
        /// <returns>Filtered collection of T.</returns>
        public virtual IEnumerable<T> FilterCollection<T, TFilterType>(IEnumerable<T> data, string columnName, bool showOnlyItemsSpecified = false)
        {
            return _togglerHelper.FilterCollection<T, TFilterType>(data, columnName, this, this.IsEnabled(), showOnlyItemsSpecified);
        }

        public SubFeatureToggle GetSubFeature(IJsonTogglerSection jsonTogglerSection=null)
        {
            var methodName = new System.Diagnostics.StackFrame(1).GetMethod().Name;
            return this.GetSubFeature(methodName, jsonTogglerSection);
        }

        public SubFeatureToggle GetSubFeature(string subFeatureName, IJsonTogglerSection jsonTogglerSection)
        {
            var subFeature = this.SubFeatureToggles.FirstOrDefault(w => w.Name == subFeatureName || w.Name == subFeatureName.Replace("_", " ") || w.Name == subFeatureName.Replace("_", " ").SplitCamelCase(" "));

            if(subFeature == null)
                throw new NoNullAllowedException(string.Format("SubFeature is null for '{0}'", subFeatureName));
            
            if (jsonTogglerSection != null)
            {
                var updatedSubFeature = new SubFeatureToggle(jsonTogglerSection);
                updatedSubFeature.Name = subFeature.Name;
                updatedSubFeature.Environment = subFeature.Environment;
                updatedSubFeature.Platform = subFeature.Platform;
                updatedSubFeature.Command = subFeature.Command;
                updatedSubFeature.CommandType = subFeature.CommandType;
                updatedSubFeature.ConnectionStringName = subFeature.ConnectionStringName;
                updatedSubFeature.FilterValues = subFeature.FilterValues;
                updatedSubFeature.SpecificEntities = subFeature.SpecificEntities;

                subFeature = updatedSubFeature;
            }

            return subFeature;
        }
    }
}
