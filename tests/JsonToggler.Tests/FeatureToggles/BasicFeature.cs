using JsonToggler;
using System;
using System.Linq;
using System.Reflection;

namespace JsonToggler.Tests.FeatureToggles
{
    public class BasicFeature : JsonFeatureToggler<BasicFeature>
    {
        public BasicFeature()
        { }

        public BasicFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

        public SubFeatureToggle SubFeature_1()
        {
            return GetSubFeature();
        }

        public SubFeatureToggle SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return GetSubFeature(jsonTogglerSection);
        }

        public SubFeatureToggle SubFeature_2()
        {
            return GetSubFeature();
        }

        public SubFeatureToggle SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return GetSubFeature(jsonTogglerSection);
        }

        public SubFeatureToggle SubFeature_3()
        {
            return GetSubFeature();
        }

        public SubFeatureToggle SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return GetSubFeature(jsonTogglerSection);
        }
    }
}
