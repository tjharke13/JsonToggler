using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    /// <summary>
    /// This will handle a custom section in the config file for this library.
    /// <section name="JsonToggler" type="JsonToggler.JsonTogglerSection, JsonToggler"/>
    /// 
    /// <JsonToggler Environment="Dev" Platform="Web" IsDebug="true" />
    /// </summary>
    public class JsonTogglerSection : ConfigurationSection, IJsonTogglerSection
    {
        [ConfigurationProperty("Environment", IsRequired = true)]
        [TypeConverter(typeof(CaseInsensitiveEnumConfigConverter<EnvironmentEnum>))]
        public EnvironmentEnum Environment
        {
            get { return (EnvironmentEnum)this["Environment"]; }
            set { this["Environment"] = value; }
        }

        [ConfigurationProperty("JsonDirectory")]
        public string JsonDirectory
        {
            get { return (string)this["JsonDirectory"]; }
            set { this["JsonDirectory"] = value; }
        }

        [ConfigurationProperty("Platform", DefaultValue = PlatformEnum.Web, IsRequired = false)]
        [TypeConverter(typeof(CaseInsensitiveEnumConfigConverter<PlatformEnum>))]
        public PlatformEnum Platform
        {
            get { return (PlatformEnum)this["Platform"]; }
            set { this["Platform"] = value; }
        }

        [ConfigurationProperty("Applications", IsRequired = false)]
        public string Applications
        {
            get { return (string)this["Applications"]; }
            set { this["Applications"] = value; }
        }

        [ConfigurationProperty("IsTestMode", DefaultValue = false, IsRequired = false)]
        public bool IsTestMode
        {
            get { return (bool)this["IsTestMode"]; }
            set { this["IsTestMode"] = value; }
        }

        public List<string> ApplicationsList
        {
            get { return this.Applications.ToString().Split(',').Select(s => s.Trim()).ToList(); }
        }
    }
}
