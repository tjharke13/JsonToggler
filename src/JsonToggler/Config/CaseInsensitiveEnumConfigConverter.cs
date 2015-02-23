using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JsonToggler
{
    public class CaseInsensitiveEnumConfigConverter<T> : ConfigurationConverterBase
    {
        public override object ConvertFrom(
        ITypeDescriptorContext ctx, CultureInfo ci, object data)
        {
            try
            {
                var result = Enum.Parse(typeof(T), (string)data, true);
                return result;
            }
            catch(Exception)
            {
                 throw new InvalidCastException(string.Format("Invalid enum type for {0}", (string)data));
            }
        }
    }
}
