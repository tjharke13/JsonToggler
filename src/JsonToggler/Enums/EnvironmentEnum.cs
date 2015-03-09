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
        NONE=0,
        LOCAL=1,
        DEV=2,
        QAS=4,
        STAGE=8,
        BETA=16,
        PILOT=32,
        PROD=64,
        NONPROD= LOCAL | DEV | QAS | STAGE,
        ALL= LOCAL | DEV | QAS | STAGE | BETA | PILOT | PROD
    }
}
