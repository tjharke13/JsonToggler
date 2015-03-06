using JsonToggler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$.FeatureToggles
{
    public class FilterFeature : JsonFeatureToggler<FilterFeature>
    {
        public FilterFeature()
        { }

        public FilterFeature(IJsonTogglerSection jsonTogglerSection)
            : base(jsonTogglerSection)
        { }

        public DataSet GetFilteredGuidItems(DataSet data, bool shouldReverseFilter = false)
        {
            return base.FilterDataSet<Guid>(data, "Id", this, shouldReverseFilter);
        }

        public IEnumerable<SomeObject> GetFilteredGuidObjects(IEnumerable<SomeObject> data, bool shouldReverseFilter = false)
        {
            return base.FilterCollection<SomeObject, Guid>(data, "Id", shouldReverseFilter);
        }
    }

	public class SomeObject
	{
		public Guid Id { get; set; }

		public string SomeValue { get; set; }
	}
}
