using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JsonToggler;

namespace JsonToggler.Api
{
    public class FeatureToggleConverter : JsonCreationConverter<IFeatureToggle>
    {
        public FeatureToggleConverter(string baseAssembly, string featureToggleAssembly)
        {
            _baseAssemblyName = baseAssembly;
            _featureToggleAssemblyName = featureToggleAssembly;
        }

        private string _baseAssemblyName { get; set; }
        private string _featureToggleAssemblyName { get; set; }

        protected override IFeatureToggle Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Name");

            var types = Assembly.Load(_baseAssemblyName).GetTypes().Where(w => w.IsClass && w.Namespace == _featureToggleAssemblyName).ToList();

            var commonType = types.Where(w => w.Name.Replace("_", " ").Equals(type, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if(commonType == null)
                commonType = types.Where(w => w.Name.SplitCamelCase(" ").Equals(type, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (commonType != null)
                return (IFeatureToggle)Activator.CreateInstance(commonType);
            else
                return new FeatureToggle();
        }
    }
}
