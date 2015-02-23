using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler.Models
{
    public class DateOnOrBeforeFeatureToggle : FeatureToggle
    {
        public override CommandTypeEnum? CommandType
        {
            get
            {
                return CommandTypeEnum.DateOnOrBefore;
            }
        }
    }
}
