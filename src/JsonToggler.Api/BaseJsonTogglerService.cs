using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler.Api
{
    public class BaseJsonTogglerService
    {
        protected List<IFeatureToggle> _featureToggles;

        public T GetFeatureToggle<T>() where T : FeatureToggle, new()
        {
            string name = typeof(T).Name;

            var feature = _featureToggles.Where(w => w.GetType() == typeof(T)).FirstOrDefault();

            if (feature == null)
                feature = new T() { Name = name.Replace("_", " ").SplitCamelCase(" ") };

            return (T)feature;
        }
    }
}
