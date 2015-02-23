using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    /// <summary>
    /// This is used as a bitwise enum.  For example if a value is set as 31 it will be enabled for all environments
    /// </summary>
    [System.Flags]
    public enum EnvironmentEnum
    {
        LOCAL=1,
        DEV=2,
        QAS=4,
        STAGE=8,
        PROD=16,
        NONPROD= LOCAL | DEV | QAS | STAGE,
        ALL= LOCAL | DEV | QAS | STAGE | PROD
    }
}
