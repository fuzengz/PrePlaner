using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionPrePlaner
{
    enum STO_RUN_STAT
    {
      TO_RUN,
      RUNNING,
    };
    
    class ScrumTeamOwner
    {


        public string Name { get; set; }
        public string Code { get; set; }
        public string Squad { get; set; }
        public string Ca { get; set; }
        public bool Selected { get; set; }
        //public STO_RUN_STAT Run_Stat { get; set; }
        /*
        public string Str_Run_Stat
        {
            get
            {
                switch (Run_Stat)
                {
                    case STO_RUN_STAT.TO_RUN:
                        return "Run";
                    case STO_RUN_STAT.RUNNING:
                        return "Running";
                    default:
                        return "NA";
                }
            }
        }
        */
        public string Str_Run_Stat { get; set; }
        //public ScrumTeamOwner(string name, string squad, string ca, bool selected = true, STO_RUN_STAT run_stat = STO_RUN_STAT.TO_RUN)
        public ScrumTeamOwner(string name, string squad, string ca, bool selected = true, string runstr = "Run")
        {
            Name = name;
            Squad = squad;
            Ca = ca;
            Selected = selected;
            Str_Run_Stat = runstr;
            try
            {
                Code = DicTeamToCode[Name];
            }
            catch
            {
                Code = null;
            }
            
        }

        public static readonly List<string> FzmTeams = new List<string>()
        {
            "FZ01", "FZ02", "FZ03", "FZ04", "FZ05", "FZ06", "FZ07", "FZ08", "FZ09", "FZ10",
            "FZ11", "FZ12", "FZ14", "FZ15", "FZ16", "FZ17", "FZ18", "FZ21", "FZ22", "FZ23", "FZ30"
        };

        public static readonly List<string> WcdmaTeams = new List<string>() {
            "FZ50", "FZ51", "FZ52", "FZ53", "FZ54", "FZ55", "FZ56"
        };

        public static readonly List<string> MultifireTeams = new List<string>() {
            "FZ40", "FZ41", "FZ42"
        };
        public static readonly List<string> ScTrsTeams = new List<string>() {
            "FZ60"
        };
       

        private static readonly HashSet<string> apTeams = new HashSet<string>
        {
            "FZ01", "FZ05", "FZ09", "FZ12", "FZ15", "FZ30", "FZ14", "FZ07", "FZ16", "FZ18"
        };

        private static readonly HashSet<string> rtTeams = new HashSet<string>
        {
            "FZ03", "FZ04", "FZ10", "FZ11", "FZ21", "FZ22", "FZ23"
        };

        private static readonly HashSet<string> trTeams = new HashSet<string>
        {
           "FZ60"
        };

        private static readonly HashSet<string> ciTeams = new HashSet<string>
        {
            "FZ02", "FZ08", "FZ06", "FZ17"
        };

        private static readonly HashSet<string> mfTeams = new HashSet<string>
        {
            "FZ40", "FZ41", "FZ42"
        };

        private static Dictionary<string, string> _dicTeamToCode;
     
        public static Dictionary<string, string> DicTeamToCode
        {
            get
            {
                if(_dicTeamToCode == null)
                {
                    _dicTeamToCode = new Dictionary<string, string>();
                    _dicTeamToCode.Add("FZ18", "1312");
                    _dicTeamToCode.Add("FZ40", "1412");
                }
                return _dicTeamToCode;
            }
        }


        public static List<string> ValidFzTeams => FzmTeams.Union(WcdmaTeams).Union(MultifireTeams).Union(ScTrsTeams).ToList();

        public static string GetSquadBasedOnSto(String sto)
        {
            if (FzmTeams.Contains(sto))
                return "FZM";
            if (WcdmaTeams.Contains(sto))
                return "WCDMA";
            if (MultifireTeams.Contains(sto))
                return "Multefire";
            if (ScTrsTeams.Contains(sto))
                return "SCTRS";
            return null;
        }
        public static string GetCaBasedOnSto(String sto)
        {
            if (apTeams.Contains(sto))
                return "FZAP";
            if (rtTeams.Contains(sto))
                return "FZRT";
            if (trTeams.Contains(sto))
                return "FZTR";
            if (ciTeams.Contains(sto))
                return "FZCI";
            if (mfTeams.Contains(sto))
                return "FZMF";

            return null;
        }
       

        private static List<ScrumTeamOwner> sto_full_list;
        public static List<ScrumTeamOwner> STO_FULL_LIST
        {
            get
            {
                if(sto_full_list == null)
                {
                    sto_full_list = new List<ScrumTeamOwner>();
                    foreach (var sto in ValidFzTeams)
                    {
                        sto_full_list.Add(new ScrumTeamOwner(sto, ScrumTeamOwner.GetSquadBasedOnSto(sto), GetCaBasedOnSto(sto)));
                    }
                }
                return sto_full_list;
            }
        }
        public static ScrumTeamOwner GetSTO(string sto_name) => STO_FULL_LIST.First(sto => sto.Name == sto_name);
        
       
    }
}
