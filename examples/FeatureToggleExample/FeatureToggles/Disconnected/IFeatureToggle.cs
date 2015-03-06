using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureToggleExample.FeatureToggles.Disconnected
{
    public interface IFeatureToggle
    {
        string Name { get; set; }

        int? CommandType { get; set; }

        string Command { get; set; }

        List<string> FilterValues { get; set; }

        bool IsEnabled();
        
    }
}
