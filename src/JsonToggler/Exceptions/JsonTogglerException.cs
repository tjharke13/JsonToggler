using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler
{
    public class JsonTogglerException : Exception
    {
        public JsonTogglerException(string exceptionMessage) : base(exceptionMessage)
        { }

        public JsonTogglerException(string exceptionMessage, Exception ex)
            : base(exceptionMessage, ex)
        { }
    }
}
