using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AMBEV.AS.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string InitCap(this string _this)
        {
            if (!string.IsNullOrEmpty(_this))
                return new CultureInfo("en").TextInfo.ToTitleCase(_this.ToLower());

            return string.Empty;
        }

        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string ToMD5(this string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static string Take(this string value, int count)
        {
            if (value != null && value.Length > count)
                return value.Substring(0, count);

            return value;
        }

        public static string TakeLast(this string value, int count)
        {
            if(value.Length > count)
                return value.Substring(value.Length - count);

            return value;
        }

        public static string ToStringSN(this bool value) => value ? "S" : "N";
        public static string ToStringSimNao(this bool value) => value ? "Sim" : "Não";
        public static string ToDoubleQuotedString(this string str) => "\"" + str + "\"";

        public static string Truncate(this string str, int count) => str?.Length > count ? str.Substring(0, count) : str;

        public static string TrimLastCharacter(this String str) => String.IsNullOrEmpty(str) ? str : str.Substring(0, str.Length - 1);

        public static string DuplicateTicksForSql(this string s)
        {
            return s.Replace("'", "''");
        }

        public static decimal? ParseDecimal(this string s)
        {
            decimal d;
            if (decimal.TryParse(s, out d))
                return d;

            return null;
        }

        public static DateTime? ParseDateTime(this string s)
        {
            DateTime d;
            if (DateTime.TryParse(s, out d))
                return d;

            return null;
        }

        public static string ReplaceLast(this string text, string search, string replace)
        {
            int pos = text.LastIndexOf(search);
            if (pos == -1)
                return text;

            return text.Remove(pos, search.Length).Insert(pos, replace);
        }

        public static string ObterProximaLetra(this string letraAtual)
        {
            char posicaoAnterior = letraAtual[letraAtual.Length - 1];
            if (new Regex("^[zZ]+$").IsMatch(letraAtual))
            {
                string result = String.Empty;
                for (int i = 0; i < letraAtual.Length; i++)
                    result += "A";

                return result + "A";
            }
            else if (posicaoAnterior == 'Z')
                return ObterProximaLetra(letraAtual.Remove(letraAtual.Length - 1, 1)) + "A";
            else
                return letraAtual.Remove(letraAtual.Length - 1, 1) + (++posicaoAnterior).ToString();
        }
        public static string Repeat(this string s, int n)
        {
            return new String(Enumerable.Range(0, n).SelectMany(x => s).ToArray());
        }

        public static string Repeat(this char c, int n)
        {
            return new String(c, n);
        }

        public static string ReplaceDoubleQuotedString(this string texto) => texto?.Replace("\"", "");

        public static string ToUppercase(this string value, bool capitalAfterSpecialChar = false)
        {
            char[] array = value.ToLower().ToCharArray();
            if (array.Length >= 1 && char.IsLower(array[0]))
                    array[0] = char.ToUpper(array[0]);

            for (int i = 1; i < array.Length; i++)
                if ((array[i - 1] == ' ' && char.IsLower(array[i])) 
                    || (capitalAfterSpecialChar && !char.IsLetterOrDigit(array[i - 1])))
                    array[i] = char.ToUpper(array[i]);

            return new string(array);
        }
    }
}
