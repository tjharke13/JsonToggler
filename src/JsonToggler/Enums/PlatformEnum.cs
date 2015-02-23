using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    /// <summary>
    /// This is used as a bitwise enum.  
    /// For example if a value is set as 7 it will be enabled for all platforms
    /// </summary>
    [System.Flags]
    public enum PlatformEnum
    {
        Web=1,
        Desktop=2,
        Android=4,
        iOS=8,
        WinPhone=16,
        Mobile= Android | iOS | WinPhone,
        All = Web | Desktop | Android | iOS | WinPhone
    }
}
