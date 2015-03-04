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
    public class SubFeatureToggle : IFeature
    {
        public SubFeatureToggle()
            : this(JsonConfigHelper.GetPlatform(), JsonConfigHelper.GetEnvironment(), JsonConfigHelper.GetIsTestMode(), JsonConfigHelper.GetApplications())
        { }

        public SubFeatureToggle(IJsonTogglerSection jsonTogglerSection)
            : this(jsonTogglerSection.Platform, jsonTogglerSection.Environment, jsonTogglerSection.IsTestMode, jsonTogglerSection.Applications.ToSplitList())
        { }

        public SubFeatureToggle(PlatformEnum platform, EnvironmentEnum currentEnvironment, bool isTestMode, List<string> applications)
        {
            _applications = applications;
            _currentEnvironment = currentEnvironment;
            _currentPlatform = platform;
            _isTestMode = isTestMode;
            _togglerHelper = new JsonTogglerHelper();
        }

        protected List<string> _applications { get; set; }
        protected EnvironmentEnum _currentEnvironment { get; set; }
        protected PlatformEnum _currentPlatform { get; set; }
        protected bool _isTestMode { get; set; }
        protected JsonTogglerHelper _togglerHelper { get; set; }

        public string Name { get; set; }

        public string Application { get; set; }

        public EnvironmentEnum Environment { get; set; }

        public PlatformEnum Platform { get; set; }

        /// <summary>
        /// If this is a SQL query it will need to return True or False only.
        /// </summary>
        public string Command { get; set; }

        public CommandTypeEnum? CommandType { get; set; }

        public string ConnectionStringName { get; set; }

        public List<string> FilterValues { get; set; }

        [JsonIgnore]
        public bool IsSubFeature { get { return true; } }

        [JsonIgnore]
        public FeatureToggle FeatureToggle { get; set; }

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

        public virtual bool IsEnabled(string companyId)
        {
            return _togglerHelper.IsEnabled(this, _currentEnvironment, _currentPlatform, companyId, _isTestMode, _applications);
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
    }
}
