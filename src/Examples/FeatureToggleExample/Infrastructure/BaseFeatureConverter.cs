using FeatureToggleExample.FeatureToggles.Disconnected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace FeatureToggleExample.Infrastructure
{
    public class BaseFeatureConverter : JsonCreationConverter<IFeatureToggle>
    {
        protected override IFeatureToggle Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Name");

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == "FeatureToggleExample.FeatureToggles.Disconnected").ToList();

            var commonType = types.Where(w => w.Name.Replace("_", " ").Equals(type, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (commonType == null)
                commonType = types.Where(w => w.Name.SplitCamelCase(" ").Equals(type, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();


            if (commonType != null)
                return (IFeatureToggle)Activator.CreateInstance(commonType);
            else
                return new BaseFeatureToggle();
        }
    }

    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


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