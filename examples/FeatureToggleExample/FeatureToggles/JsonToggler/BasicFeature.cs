using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FeatureToggleExample.FeatureToggles.JsonToggler
{
    public class BasicFeature : JsonFeatureToggler<BasicFeature>
    {
        public SubFeatureToggle SubFeature_1()
        {
            var methodName = MethodBase.GetCurrentMethod().Name.Replace("_", " ");

            return this.SubFeatureToggles.Where(w => w.Name == methodName).FirstOrDefault();
        }
    }
}