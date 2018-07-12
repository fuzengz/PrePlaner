using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionPrePlaner
{
    public class Timetracking
    {
        public string originalEstimate { get; set; }
        public string remainingEstimate { get; set; }
        public string originalEstimateSeconds { get; set; }
        public string remainingEstimateSeconds { get; set; }
    }

    public class Customfield
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class StatusCategory
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }

    public class Fields
    {
        public string customfield_29790 { get; set; }
        public string customfield_38719 { get; set; }
        public string customfield_38693 { get; set; }
        public string customfield_38694 { get; set; }
        public Customfield customfield_38751 { get; set; }
        public string customfield_37381 { get; set; }
        public string customfield_38702 { get; set; }
        public Timetracking timetracking { get; set; }
        public List<Customfield> customfield_38725 { get; set; }
        public Status status { get; set; }
    }

    public class Issues
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class RootObject
    {
        public string expand { get; set; }
        public string startAt { get; set; }
        public string maxResults { get; set; }
        public string total { get; set; }
        public List<Issues> issues { get; set; }
    }

    class TableObject
    {
        public string Key = null;
        public string FP = null;
        public string ItemID = null;
        public string UnifiedPriority = null;
        public string ScrumTeamOwner = null;
    
        public string Status = null;
        public string LeadRelease = null;
        public string StartFB = null;
        public string EndFB = null;
        public string TargetFB = null;

        public string OriginalEffort = null;
        public string RemWorkEffort = null;


        public TableObject(Issues issue)
        {

            Key = issue.key;
            if(issue.fields != null){
                FP = issue.fields.customfield_37381;
                ItemID = issue.fields.customfield_38702;
                UnifiedPriority = issue.fields.customfield_38719;
                ScrumTeamOwner = issue.fields.customfield_29790;
                Status = issue.fields.status.name;
                StartFB = issue.fields.customfield_38694; ;
                EndFB = issue.fields.customfield_38693;
                TargetFB = issue.fields.customfield_38751.value;

                if(isssue.fields.timetracking != null){
                    OriginalEffort = issue.fields.timetracking.originalEstimate;
                    RemWorkEffort = issue.fields.timetracking.remainingEstimate;
                }

                try
                {
                    LeadRelease = issue.fields.customfield_38725[0].value;//sometimes many 
                }
                catch
                {
                    LeadRelease = null;
                }
            }
            
        }
    }
}
