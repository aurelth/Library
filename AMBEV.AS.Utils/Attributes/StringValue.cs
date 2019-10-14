using System;
using AMBEV.AS.Utils.Extensions;

namespace AMBEV.AS.Utils.Attributes
{
    public class StringValue : Attribute
    {
        public StringValue(string value, string abbreviatedValue = null)
        {
            Value = value;
            AbbreviatedValue = abbreviatedValue;
        }

        public StringValue(string value, string color, string abbreviatedValue = null)
        {
            Color = color;
            Value = value;
            AbbreviatedValue = abbreviatedValue;
        }

        public string Value { get; }
        public string AbbreviatedValue { get; }
        public string Color { get; }
        public static string GetStringValue(System.Enum value) => value.TryGetTypeAttributeProperty<StringValue>(sv => sv.Value);
        public static string GetAbbreviatedStringValue(System.Enum value) => value.TryGetTypeAttributeProperty<StringValue>(sv => sv.AbbreviatedValue);
        public static string GetColorValue(System.Enum value) => value.TryGetTypeAttributeProperty<StringValue>(sv => sv.Color);
    }
}