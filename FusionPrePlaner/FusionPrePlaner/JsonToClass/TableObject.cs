using System;
using System.Collections.Generic;
using System.Text;

namespace FusionPrePlaner
{
    class TableObject
    {
        public string id = null;
        public string key = null;
        public string FP = null;
        public string ItemID = null;
        public string UnifiedPriority = null;
        public string ScrumTeamOwner = null;
        public Status Status = null;
        public Customfield TargetFB = null;
        public string PrePlanLowerBound = null;
        public string PrePlanUpperBound = null;
        public string OriginalEffort = null;
        public string RemWorkEffort = null;
        public List<Customfield> LeakRelease = null;

        public TableObject(Issues issue)
        {
            id = issue.id;
            key = issue.key;
            if(issue.fields!=null){
                FP = issue.fields.customfield_37381;
                ItemID = issue.fields.customfield_38702;
                UnifiedPriority = issue.fields.customfield_38719;
                ScrumTeamOwner = issue.fields.customfield_29790;
                Status = issue.fields.status;
                TargetFB = issue.fields.customfield_38751;
                PrePlanLowerBound = issue.fields.customfield_38694;
                PrePlanUpperBound = issue.fields.customfield_38693;
                if(issue.fields.timetracking!=null){
                    OriginalEffort = issue.fields.timetracking.originalEstimate;
                    RemWorkEffort = issue.fields.timetracking.remainingEstimate;
                }  
                LeakRelease = issue.fields.customfield_38725;
            }
        }
    }
}
