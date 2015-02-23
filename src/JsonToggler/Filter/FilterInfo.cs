using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    class FilterInfo
    {
        public string PropertyName { get; set; }
        public OperationEnum Operation { get; set; }
        public object Value { get; set; }
    }
}
