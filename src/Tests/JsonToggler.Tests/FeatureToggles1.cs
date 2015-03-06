using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JsonToggler;

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class ApplicationAllFeature : JsonFeatureToggler<ApplicationAllFeature>
	{
		public ApplicationAllFeature()
        { }

		public ApplicationAllFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class ApplicationAllFeature  : FeatureToggle
	{
		public ApplicationAllFeature()
        { }

		public ApplicationAllFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class ApplicationFeature : JsonFeatureToggler<ApplicationFeature>
	{
		public ApplicationFeature()
        { }

		public ApplicationFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class ApplicationFeature  : FeatureToggle
	{
		public ApplicationFeature()
        { }

		public ApplicationFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class BasicFeature : JsonFeatureToggler<BasicFeature>
	{
		public BasicFeature()
        { }

		public BasicFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class BasicFeature  : FeatureToggle
	{
		public BasicFeature()
        { }

		public BasicFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class DateTimeFeature : JsonFeatureToggler<DateTimeFeature>
	{
		public DateTimeFeature()
        { }

		public DateTimeFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class DateTimeFeature  : FeatureToggle
	{
		public DateTimeFeature()
        { }

		public DateTimeFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class DateFeature : JsonFeatureToggler<DateFeature>
	{
		public DateFeature()
        { }

		public DateFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class DateFeature  : FeatureToggle
	{
		public DateFeature()
        { }

		public DateFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class EntitySpecificFeature : JsonFeatureToggler<EntitySpecificFeature>
	{
		public EntitySpecificFeature()
        { }

		public EntitySpecificFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class EntitySpecificFeature  : FeatureToggle
	{
		public EntitySpecificFeature()
        { }

		public EntitySpecificFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_3()
		{
			return base.GetSubFeature("SubFeature 3", null);
		}

		public SubFeatureToggle  SubFeature_3(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 3", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class FilterFeature : JsonFeatureToggler<FilterFeature>
	{
		public FilterFeature()
        { }

		public FilterFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class FilterFeature  : FeatureToggle
	{
		public FilterFeature()
        { }

		public FilterFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

		public virtual SubFeatureToggle SubFeature_2()
		{
			return base.GetSubFeature("SubFeature 2", null);
		}

		public SubFeatureToggle  SubFeature_2(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 2", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.FeatureToggles
{
	public partial class SQLFeature : JsonFeatureToggler<SQLFeature>
	{
		public SQLFeature()
        { }

		public SQLFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

	}
}

namespace JsonToggler.Tests.ApiFeatureToggles
{

	public partial class SQLFeature  : FeatureToggle
	{
		public SQLFeature()
        { }

		public SQLFeature(IJsonTogglerSection jsonTogglerSection) : base(jsonTogglerSection)
        { }

		public virtual SubFeatureToggle SubFeature_1()
		{
			return base.GetSubFeature("SubFeature 1", null);
		}

		public SubFeatureToggle  SubFeature_1(IJsonTogglerSection jsonTogglerSection)
        {
            return base.GetSubFeature("SubFeature 1", jsonTogglerSection);
        }

	}
}


