using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utilities
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        public static string ToNumeric(this int value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value)
        {
            return value.ToString("N0");
        }

        public static string ToCurrency(this int value)
        {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C0");
        }

        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");//.Replace("ئ", "ی");
        }

        public static string CleanString(this string str)
        {
            return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
        }

        public static string NullIfEmpty(this string str)
        {
            return str?.Length == 0 ? null : str;
        }

        

        public static string RemoveHtmlTags(string source)
        {
            var array = new char[source.Length];
            var arrayIndex = 0;
            var inside = false;

            for (var i = 0; i < source.Length; i++)
            {
                var let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }

                if (let == '>')
                {
                    inside = false;
                    continue;
                }

                if (inside) continue;

                array[arrayIndex] = let;
                arrayIndex++;
            }

            return new string(array, 0, arrayIndex);
        }

        public static string DisableHtmlTags(string source)
        {
            return (source.Replace("<", "&lt;")).Replace(">", "gt;");
        }

        public static string DisableScriptTag(string source)
        {
            Regex.Replace(
                source,
                @"(<script>).*(</script>)", string.Empty,
                RegexOptions.IgnoreCase);
            return source;
        }

        public static string ShowLFinHtml(string source)
        {
            return source.Replace("\n", "<br />");
        }

        public static string FixForUrl(string text)
        {
            
            var sb = new StringBuilder();
            var wasHyphen = true;

            foreach (var c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLower(c));
                    wasHyphen = false;
                }

                else if (char.IsWhiteSpace(c) && !wasHyphen)
                {
                    sb.Append('-');
                    wasHyphen = true;
                }
            }

            // Avoid trailing hyphens
            if (wasHyphen && sb.Length > 0)
            {
                sb.Length--;
            }

            return sb.ToString().Replace("--", "-");
        }

        public static string GetFileRawName(string fullname)
        {
            var extIndex = fullname.LastIndexOf(".");
            return fullname.Substring(0, extIndex < 0 ? fullname.Length : extIndex);
        }

       
        public static string Short(string source, int totalCharacters, string moreCharachters)
        {
            if (source.Length > totalCharacters)
            {
                source = ShowLFinHtml(source.Substring(0, System.Math.Min(source.Length, totalCharacters)));
                source = source.Remove(source.Remove(source.Length - 1).LastIndexOf(' ') + 1) + moreCharachters;
            }
            return source;
        }


        public static string spliterNumberString(string num)
        {
            num = string.Format("{0:n0}", num);
            return num;
        }
        public static string spliterNumber(string num)
        {
            var a = Enumerable.Range(0, num.Length / 3).Select(i => num.Substring(i * 3, 3));
            num = string.Join(",", a);
            return num;
        }
    }
}
