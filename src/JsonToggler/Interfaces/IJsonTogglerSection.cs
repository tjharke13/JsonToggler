using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler
{
    public interface IJsonTogglerSection
    {
        EnvironmentEnum Environment { get; set; }
        bool IsTestMode { get; set; }
        string JsonDirectory { get; set; }
        PlatformEnum Platform { get; set; }
    }
}
