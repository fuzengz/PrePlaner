using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comparisonOption)
        {
            return source.IndexOf(toCheck, comparisonOption) >= 0;
        }

        public static bool FuzzyEquals(this string strA, string strB, double requiredProbabilityScore = 0.75)
        {
            return strA.FuzzyMatch(strB) > requiredProbabilityScore;
        }

        public static double FuzzyMatch(this string searched, string matched)
        {
            string localA = searched.Trim().ToLower();
            string localB = matched.Trim().ToLower();

            if (localB.Contains(localA))
                return searched.Length / matched.Length + 1;

            var singleComposite = CompositeCoefficient(localA, localB);
            return singleComposite < 0.999999 ? singleComposite : 0.999999; //fudge factor
        }

        private static double CompositeCoefficient(string searched, string matched)
        {
            int leven = searched.LevenshteinDistance(matched);
            double levenCoefficient = 1.0 / (1.0 * (leven + 0.2)); //may want to tweak offset

            return levenCoefficient;
        }

        public static double ToDouble(this string value)
        {
            double result;
            double.TryParse(value, out result);
            return result;
        }

        public static int ToInt(this string value)
        {
            int result;
            Int32.TryParse(value, out result);
            return result;
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }
    }
}