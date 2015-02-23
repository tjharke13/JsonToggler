using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler
{
    public interface IFeatureToggle : IFeature
    {
        List<SubFeatureToggle> SubFeatureToggles { get; }
    }
}
