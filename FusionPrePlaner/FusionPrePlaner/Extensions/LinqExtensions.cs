using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T without)
        {
            return source.Except(new[] { without });
        }

        public static StringBuilder TrimEnd(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0) return sb;

            int i = sb.Length - 1;
            for (; i >= 0; i--)
                if (!char.IsWhiteSpace(sb[i]))
                    break;

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }

        public static bool IsEqualToAny<T>(this T t, params T[] values)
        {
            return values.Contains(t);
        }

        public static IEnumerable<T> ToIEnumerable<T>(this T o)
        {
            yield return o;
        }
    }
}
