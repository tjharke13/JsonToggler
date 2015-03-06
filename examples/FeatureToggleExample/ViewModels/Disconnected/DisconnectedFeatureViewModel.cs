using FeatureToggleExample.FeatureToggles.Disconnected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureToggleExample.ViewModels.Disconnected
{
    public class DisconnectedFeatureViewModel
    {
        public BasicFeature BasicFeature { get; set; }

        public Filter_Feature Filter_Feature { get; set; }

        public SQL_Feature SQL_Feature { get; set; }

        public DateFeature DateFeature { get; set; }

        public List<Guid> OriginalCollection { get; set; }

        public List<Guid> UpdatedCollection { get; set; }
    }
}