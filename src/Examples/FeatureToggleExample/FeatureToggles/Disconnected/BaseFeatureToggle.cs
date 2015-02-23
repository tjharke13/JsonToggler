using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureToggleExample.FeatureToggles.Disconnected
{
    public class BaseFeatureToggle : IFeatureToggle
    {
        public string Name { get; set; }

        [JsonProperty("IsEnabled")]
        private bool IsFeatureEnabled { get; set; }

        public int? CommandType { get; set; }

        public string Command { get; set; }

        public List<string> FilterValues { get; set; }

        public bool IsEnabled()
        {
            var result = false;
            if (this.IsFeatureEnabled)
            {
                if (!this.CommandType.HasValue || this.CommandType <= 0)
                {
                    result = true;
                }
                else
                {
                    var commandType = this.CommandType.Value;
                    switch (commandType)
                    {
                        case 1: //After or on date
                            try
                            {
                                var date = Convert.ToDateTime(this.Command);

                                if (date <= DateTime.UtcNow)
                                    result = true;
                                else
                                    result = false;
                            }
                            catch (Exception)
                            {
                                //Error converting command to datetime object.
                                return false;
                            }
                            break;
                        case 2: //Before or on date
                            try
                            {
                                var date = Convert.ToDateTime(this.Command);

                                if (date >= DateTime.UtcNow)
                                    result = true;
                                else
                                    result = false;
                            }
                            catch (Exception)
                            {
                                //Error converting command to datetime object.
                                return false;
                            }
                            break;
                        case 3: //Between dates
                            try
                            {
                                var dateStrings = this.Command.Split('|');
                                var beginningDate = Convert.ToDateTime(dateStrings[0].Trim());
                                var endDate = Convert.ToDateTime(dateStrings[1].Trim());

                                if (beginningDate >= DateTime.UtcNow && endDate <= DateTime.UtcNow)
                                    result = true;
                            }
                            catch (Exception)
                            {
                                //Error converting command to datetime object.
                                return false;
                            }
                            break;
                        default:
                            result = true;    
                            //throw new NotImplementedException(string.Format("This command is not implemented. '{0}'", commandType));
                            break;
                    }
                }


                return true;
            }

            return result;
        }

        internal void SetFeature(BaseFeatureToggle toggle)
        {
            Name = toggle.Name;
            IsFeatureEnabled = toggle.IsFeatureEnabled;
            Command = toggle.Command;
            FilterValues = toggle.FilterValues;
        }
    }
}