using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureToggleExample.FeatureToggles.Disconnected
{
    public class Filter_Feature : BaseFeatureToggle
    {
        public List<T> FilterRecords<T>(List<T> data)
        {
            var result = data;

            if(!this.IsEnabled() && this.FilterValues != null)
            {
                result = data.Where(w => !this.FilterValues.Contains(w.ToString())).ToList();
            }

            return result;
        }
    }
}