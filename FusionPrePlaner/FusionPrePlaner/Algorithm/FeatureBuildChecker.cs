using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FusionPrePlaner.Algorithm
{
    public class FeatureBuildChecker
    {
        public bool isValid(string featureBuild)
        {
            if (string.IsNullOrEmpty(featureBuild))
                return false;
            return Regex.IsMatch(featureBuild, @"^fb\d{2}[.](0[1-9]|1[0-2])$");
        }

        public bool isParked(String featureBuild)
        {
            return featureBuild.Contains("park");
        }

        public bool isHeld(String featureBuild)
        {
            return featureBuild.Contains("hold");
        }

        public bool isParkedOrHeld(String featureBuild)
        {
            return isHeld(featureBuild) || isParked(featureBuild);
        }

        public virtual bool isFromPast(String featureBuild)
        {
            ValidateExistenceOfFbIfNotThrow(featureBuild);
 
            return FeatureBuildDate.featureBuildDates[featureBuild].EndTime < DateTime.Now;
        }

        public virtual bool isCurrent(String featureBuild)
        {
            return !isFromPast(featureBuild) && !isFromFuture(featureBuild);
        }

        public virtual bool isFromFuture(String featureBuild)
        {
            ValidateExistenceOfFbIfNotThrow(featureBuild);

            return FeatureBuildDate.featureBuildDates[featureBuild].StartTime > DateTime.Now;
        }

        public bool isEarlier(String featureBuild, String earlierThan)
        {
            ValidateExistenceOfFbIfNotThrow(featureBuild);
            ValidateExistenceOfFbIfNotThrow(earlierThan);

            return FeatureBuildDate.featureBuildDates[featureBuild].StartTime < FeatureBuildDate.featureBuildDates[earlierThan].StartTime;
        }

        public bool isLater(String featureBuild, String laterThan)
        {
            ValidateExistenceOfFbIfNotThrow(featureBuild);
            ValidateExistenceOfFbIfNotThrow(laterThan);

            return FeatureBuildDate.featureBuildDates[featureBuild].StartTime > FeatureBuildDate.featureBuildDates[laterThan].StartTime;
        }

        public String AddFbs(String featureBuild, int shiftBy)
        {
            var fb = featureBuild;
            if (shiftBy > 0)
            {
                for (int i = 0; i < shiftBy; i++)
                    fb = GetNextFb(fb);
            }
            else
            {
                for (int i = shiftBy; i < 0; i++)
                    fb = GetPreviousFb(fb);
            }
            return fb;
        }

        public virtual string GetCurrentFeatureBuild()
        {
            return GetFbFromDate(DateTime.Now);
        }

        public virtual IEnumerable<string> GetNextFbs(int count)
        {
            var fb = GetCurrentFeatureBuild();
            for (int i = 0; i < count; i++)
            {
                fb = GetNextFb(fb);
                yield return fb;
            }
        }

        public virtual string GetFbFromDate(DateTime date)
        {
            string possibleFb = FbFromDate(date);

            if (isCurrent(possibleFb))
                return possibleFb;
            if (isFromFuture(possibleFb))
                return GetPreviousFb(possibleFb);

            return GetNextFb(possibleFb);
        }

        public bool InRange(string lowerBound, string upperBound, string fb)
        {
            if (isValid(lowerBound) && isValid(upperBound))
                return !isEarlier(fb, lowerBound) && !isLater(fb, upperBound);

            return false;
        }

        public string GetNextFb(string fb)
        {
            int month = int.Parse(fb.Substring(fb.Length - 2));
            int year = int.Parse(fb.Substring(0, 2));

            ++month;
            if (month == 13)
            {
                ++year;
                month = 1;
            }

            return FbFromNumbers(month, year);
        }

        public string GetPreviousFb(string fb)
        {
            int month = int.Parse(fb.Substring(fb.Length - 2));
            int year = int.Parse(fb.Substring(0, 2));

            --month;
            if (month == 0)
            {
                --year;
                month = 12;
            }

            return FbFromNumbers(month, year);
        }

        public IEnumerable<string> EnumerateFbRange(string startFb, string endFb)
        {
            if (startFb == endFb)
                yield return startFb;
            else if (isEarlier(startFb, endFb))
            {
                for (string fb = startFb; fb != endFb; fb = GetNextFb(fb))
                    yield return fb;
                yield return endFb;
            }
            else
            {
                for (string fb = startFb; fb != endFb; fb = GetPreviousFb(fb))
                    yield return fb;
                yield return endFb;
            }
        }

        public int GetStartYear(string fb)
        {
            return FeatureBuildDate.featureBuildDates[fb].StartTime.Year;
        }

        public int GetEndYear(string fb)
        {
            return FeatureBuildDate.featureBuildDates[fb].EndTime.Year;
        }

        public int GetFirstWeekOfFb(string fb)
        {
            var fbStartDate = FeatureBuildDate.featureBuildDates[fb].StartTime;
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(fbStartDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }

        public int GetLastWeekOfFb(string fb)
        {
            var fbStartDate = FeatureBuildDate.featureBuildDates[fb].EndTime;
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(fbStartDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }

        public bool IsDateAfterFb(DateTime date, string fb)
        {
            return FeatureBuildDate.featureBuildDates[fb].EndTime < date;
        }

        public bool IsFbAfterDate(string fb, DateTime date)
        {
            return FeatureBuildDate.featureBuildDates[fb].EndTime > date;
        }

        public String PickEarlierValidFb(String left, String right)
        {
            if (!isValid(left) && isValid(right))
                return right;
            if (isValid(left) && isValid(right))
            {
                if (isEarlier(left, right))
                    return left;
                else
                    return right;
            }

            return left;
        }

        public String PickLaterValidFb(String left, String right)
        {
            if (!isValid(left) && isValid(right))
                return right;
            if (isValid(left) && isValid(right))
            {
                if (isLater(left, right))
                    return left;
                else
                    return right;
            }

            return left;
        }

        public virtual int DaysUntilFbStart(DateTime currentDate, string targetFb)
        {
            return (FeatureBuildDate.featureBuildDates[targetFb].StartTime - currentDate).Days;
        }

        public virtual string GetParkedFbForThisYear()
        {
            var year = DateTime.Now.Year.ToString();
            return  year.Substring(year.Length - 2) + "." + "park";
            //return "fb" + year.Substring(year.Length - 2) + "." + "park";
        }

        public string FbFromNumbers(int month, int year)
        {
            return year + month.ToString("00");
            //return "fb" + year + "." + month.ToString("00");
        }

        public int GetShortYearFromFb(string fb)
        {
            //var s = fb.Substring(2, 2);
            var s = fb.Substring(0, 2);
            int y = 0;
            int.TryParse(s, out y);
            return y;
        }

        public int Diff(string begin, string end)
        {
            int diff = 0;

            if (isEarlier(begin, end))
            {
                for (; begin != end; begin = GetNextFb(begin))
                    ++diff;
            }
            else if (isEarlier(end, begin))
            {
                for (; end != begin; end = GetNextFb(end))
                    --diff;
            }
            return diff;
        }

        public string GetLatestFb(IEnumerable<string> collection)
        {
            string latestFb = collection.FirstOrDefault();
            foreach (var fb in collection)
            {
                if (!isValid(latestFb) || (isValid(fb) && isLater(fb, latestFb)))
                    latestFb = fb;
            }
            return latestFb;
        }

        public bool IsInvalidOrNotEarlier(string fb, string notEarlierThan) => !isValid(fb) || !isEarlier(fb, notEarlierThan);

        private String FbFromDate(DateTime date)
        {
            var year = date.Year.ToString();
            var month = date.Month.ToString("00");
            return year.Substring(year.Length - 2)  + month;
            //return "fb" + year.Substring(year.Length - 2) + "." + month;
        }

        private void ValidateExistenceOfFbIfNotThrow(string featureBuild)
        {
            
            
            if (!FeatureBuildDate.featureBuildDates.ContainsKey(featureBuild))
                throw new Exception("Feature build: " + featureBuild + " is not specified in featurebuilddates");
            
        }
    }
}
