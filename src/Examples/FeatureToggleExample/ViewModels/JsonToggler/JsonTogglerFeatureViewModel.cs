using FeatureToggleExample.FeatureToggles.JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureToggleExample.ViewModels.JsonToggler
{
    public class JsonTogglerFeatureViewModel
    {
        public BasicFeature BasicFeature { get; set; }

        public Filter_Feature Filter_Feature { get; set; }

        public SQLFeature SQLFeature { get; set; }

        public DateFeature DateFeature { get; set; }

        public List<Guid> OriginalCollection { get; set; }

        public List<Guid> UpdatedCollection { get; set; }
    }
}