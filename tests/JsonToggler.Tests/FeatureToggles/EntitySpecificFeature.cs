using JsonToggler;
using System;

namespace JsonToggler.Tests.FeatureToggles
{
    public class EntitySpecificFeature : JsonFeatureToggler<EntitySpecificFeature>
    {
        public EntitySpecificFeature()
        { }

        public EntitySpecificFeature(IJsonTogglerSection jsonTogglerSection)
            : base(jsonTogglerSection)
        { }
    }
}
