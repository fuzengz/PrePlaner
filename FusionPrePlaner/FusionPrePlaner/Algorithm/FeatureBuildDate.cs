using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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


        private static Dictionary<string, FeatureBuildDate> _featureBuildDates;

        public static Dictionary<string, FeatureBuildDate> FeatureBuildDates
        {
            get
            {
                if (_featureBuildDates == null)
                {
                    _featureBuildDates = new Dictionary<string, FeatureBuildDate>();
                    foreach (DataRow row in PrePlanner.DT_FB.Rows)
                    {
                        _featureBuildDates.Add(row["FB"].ToString(), new FeatureBuildDate((DateTime)row["Start Date"], (DateTime)row["End Date"]));
                    }
                }
                return _featureBuildDates;
            }
        }

        
    }
    
}
