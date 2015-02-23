using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FeatureToggleExample.FeatureToggles.ApiJsonToggler
{
    public class BasicFeature : FeatureToggle
    {
        public SubFeatureToggle SubFeature_1()
        {
            var methodName = MethodBase.GetCurrentMethod().Name.Replace("_", " ");

            return this.SubFeatureToggles.Where(w => w.Name == methodName).FirstOrDefault();
        }
    }
}