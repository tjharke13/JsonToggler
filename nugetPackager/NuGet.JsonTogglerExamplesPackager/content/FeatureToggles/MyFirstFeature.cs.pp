using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace $rootnamespace$.FeatureToggles
{
    public class MyFirstFeature : JsonFeatureToggler<MyFirstFeature>
    {
        public SubFeatureToggle SubFeature_1()
        {
            var methodName = MethodBase.GetCurrentMethod().Name.Replace("_", " ");

            return this.SubFeatureToggles.Where(w => w.Name == methodName).FirstOrDefault();
        }
		
		public SubFeatureToggle SubFeature_2()
        {
            var methodName = MethodBase.GetCurrentMethod().Name.Replace("_", " ");

            return this.SubFeatureToggles.Where(w => w.Name == methodName).FirstOrDefault();
        }
    }
}