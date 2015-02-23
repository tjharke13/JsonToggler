using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace JsonToggler
{
    public static class StringExtensions
    {
        public static string ToFeatureName(this string value)
        {
            return value.Replace(" ", "_");
        }

        private static readonly Regex SplitCamelCaseRegex = new Regex(@"
            (
                (?<=[a-z])[A-Z0-9] (?# lower-to-other boundaries )
                |
                (?<=[0-9])[a-zA-Z] (?# number-to-other boundaries )
                |
                (?<=[A-Z])[0-9] (?# cap-to-number boundaries; handles a specific issue with the next condition )
                |
                (?<=[A-Z])[A-Z](?=[a-z]) (?# handles longer strings of caps like ID or CMS by splitting off the last capital )
            )"
            , RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace
        );

        public static string SplitCamelCase(this string value, string splitValue = "_")
        {
            var replaceValue = splitValue + "$1";
            return SplitCamelCaseRegex.Replace(value, replaceValue).Trim();
        }
    }
}
