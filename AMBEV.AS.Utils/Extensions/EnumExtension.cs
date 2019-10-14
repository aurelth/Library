
using AMBEV.AS.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AMBEV.AS.Utils.Extensions
{
    public static class EnumExtension
    {
        public static string GetIntStringValue(this System.Enum en) => Convert.ToInt32(en).ToString();
        public static string GetStringValue(this System.Enum en) => StringValue.GetStringValue(en);
        public static string GetAbbreviatedStringValue(this System.Enum en) => StringValue.GetAbbreviatedStringValue(en);

        public static string TryGetTypeAttributeProperty<T>(this System.Enum value, Func<T, string> valueFunc)
        {
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            if (fi == null)
                return string.Empty;

            var attrs = fi.GetCustomAttributes(typeof(T), false) as T[];
            if (attrs.Length > 0)
                return valueFunc(attrs[0]);

            return null;
        }

        public static bool IsIn(this System.Enum value, params System.Enum[] possibles) => possibles.Contains(value);

        public static IEnumerable<T> TryGetAttributesByFilter<T>(this System.Enum value, Func<T, bool> filterFunc)
        {
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            if (fi == null)
                return null;

            var attrs = fi.GetCustomAttributes(typeof(T), false) as T[];
            return attrs?.Where(a => filterFunc(a));
        }
    }
}
