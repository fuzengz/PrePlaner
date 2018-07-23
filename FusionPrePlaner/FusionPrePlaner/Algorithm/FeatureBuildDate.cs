using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FusionPrePlaner.Algorithm
{
    public class FeatureBuildDate
    {
        public FeatureBuildDate(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public static Dictionary<string, FeatureBuildDate> featureBuildDates = new Dictionary<string, FeatureBuildDate>()
        {

            {"fb18.07", new FeatureBuildDate(new DateTime(2018, 06, 20), new DateTime(2018, 07, 24))},
            {"fb18.08", new FeatureBuildDate(new DateTime(2018, 07, 25), new DateTime(2018, 08, 28))},
            {"fb18.09", new FeatureBuildDate(new DateTime(2018, 08, 29), new DateTime(2018, 09, 25))},
            {"fb18.10", new FeatureBuildDate(new DateTime(2018, 09, 26), new DateTime(2018, 10, 23))},
            {"fb18.11", new FeatureBuildDate(new DateTime(2018, 10, 24), new DateTime(2018, 11, 20))},
            {"fb18.12", new FeatureBuildDate(new DateTime(2018, 11, 21), new DateTime(2018, 12, 18))},

            {"fb19.01", new FeatureBuildDate(new DateTime(2018, 12, 19), new DateTime(2019, 01, 22))},
            {"fb19.02", new FeatureBuildDate(new DateTime(2019, 01, 23), new DateTime(2019, 02, 19))},
            {"fb19.03", new FeatureBuildDate(new DateTime(2019, 02, 20), new DateTime(2019, 03, 19))},
            {"fb19.04", new FeatureBuildDate(new DateTime(2019, 03, 20), new DateTime(2019, 04, 23))},
            {"fb19.05", new FeatureBuildDate(new DateTime(2019, 04, 24), new DateTime(2019, 05, 21))},
            {"fb19.06", new FeatureBuildDate(new DateTime(2019, 05, 22), new DateTime(2019, 06, 18))},
            {"fb19.07", new FeatureBuildDate(new DateTime(2019, 06, 19), new DateTime(2019, 07, 23))},
            {"fb19.08", new FeatureBuildDate(new DateTime(2019, 07, 24), new DateTime(2019, 08, 20))},
            {"fb19.09", new FeatureBuildDate(new DateTime(2019, 08, 21), new DateTime(2019, 09, 24))},
            {"fb19.10", new FeatureBuildDate(new DateTime(2019, 09, 25), new DateTime(2019, 10, 22))},
            {"fb19.11", new FeatureBuildDate(new DateTime(2019, 10, 23), new DateTime(2019, 11, 19))},
            {"fb19.12", new FeatureBuildDate(new DateTime(2019, 11, 20), new DateTime(2019, 12, 24))},

        };
    }
}
