using JsonToggler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Tests.FeatureToggles
{
    public partial class FilterFeature : JsonFeatureToggler<FilterFeature>
    {
        public DataSet GetFilteredGuidItems(DataSet data, bool shouldReverseFilter = false)
        {
            return base.FilterDataSet<Guid>(data, "Id", shouldReverseFilter);
        }

        public IEnumerable<JsonToggler.Tests.TestFilterData.TestGuidObject> GetFilteredGuidObjects(IEnumerable<JsonToggler.Tests.TestFilterData.TestGuidObject> data, bool shouldReverseFilter = false)
        {
            return base.FilterCollection<JsonToggler.Tests.TestFilterData.TestGuidObject, Guid>(data, "Id", shouldReverseFilter);
        }
    }
}
