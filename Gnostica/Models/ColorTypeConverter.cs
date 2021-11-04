using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;

namespace Gnostica.Models
{
    public class ColorTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
        {
            if (sourceType == typeof(string) || sourceType == typeof(String))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null && (value is string) || (value is String))
            {
                return Color.ParseHex(value.ToString());
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(Color))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(string) && value is Color)
            {
                return ((Color)value).ToHex();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
