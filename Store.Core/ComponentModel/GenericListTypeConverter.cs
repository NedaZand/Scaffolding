using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.ComponentModel
{
    public class GenericListTypeConverter<T> : TypeConverter
    {
        private readonly TypeConverter _converter;
        public GenericListTypeConverter()
        {
            _converter = TypeDescriptor.GetConverter(typeof(T));
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                var result = GetStringArray(sourceType.ToString());
                return result.Any();
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] items = GetStringArray((string)value);
                var result = new List<T>();
                Array.ForEach(items, c =>
                {
                    object item = _converter.ConvertFromInvariantString(c);
                    if (item != null)
                    {
                        result.Add((T)item);
                    }
                });
                return result;
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var result = string.Empty;
                foreach (var item in ((List<T>)value).Select((i, v) => new { index = i, value = v }))
                {
                    result += Convert.ToString(item.value, CultureInfo.InvariantCulture);
                    if (int.Parse(item.index.ToString()) != ((List<T>)value).Count - 1)
                    {
                        result += ",";
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public string[] GetStringArray(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var result = input.Split(',');
                Array.ForEach(result, x => x.Trim());
                return result;
            }
            return new string[0];
        }
    }
}