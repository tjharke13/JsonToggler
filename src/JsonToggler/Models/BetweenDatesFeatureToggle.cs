using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler.Models
{
    public class DatesBetweenFeatureToggle : FeatureToggle
    {
        public override CommandTypeEnum? CommandType
        {
            get
            {
                return CommandTypeEnum.DatesBetween;
            }
            set
            {
                base.CommandType = value;
            }
        }
    }
}
