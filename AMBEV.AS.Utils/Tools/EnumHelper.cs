using AMBEV.AS.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMBEV.AS.Utils.Tools
{
    public class EnumHelper
    {
        public static Dictionary<int, string> GetDictionary<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T deve ser um tipo enumerado");
            }

            var result = new Dictionary<int, string>();
            var values = System.Enum.GetValues(typeof(T));

            foreach (var value in values)
            {
                int enumValue = (int)value;
                var enumItem = (System.Enum)System.Enum.ToObject(typeof(T), enumValue);

                result.Add(enumValue, enumItem.GetStringValue());
            }

            return result;
        }
    }
}
