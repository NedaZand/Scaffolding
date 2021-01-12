using Store.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.CommonHelper
{
    public static class CustomTypeConverter
    {
        public static TypeConverter GetCustomeConverter(Type type)
        {
            if (type == typeof(List<string>))
            {
                return new GenericListTypeConverter<string>();
            }
            if (type == typeof(List<int>))
            {
                return new GenericListTypeConverter<int>();
            }
            if (type == typeof(List<decimal>))
            {
                return new GenericListTypeConverter<decimal>();
            }
            return TypeDescriptor.GetConverter(type);
        }
    }
}
