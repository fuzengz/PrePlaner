using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NLog;
namespace FusionPrePlaner
{
    class PrePlanner
    {

        public static Logger logger = LogManager.GetLogger("PrePlan");


        private ScrumTeamOwner Sto;
        public PrePlanner(ScrumTeamOwner sto)
        {
            Sto = sto;
        }
        private delegate void ProcessSTO_delegate();

        public void AsyncProcessSTO()
        {
            ProcessSTO_delegate dele = new ProcessSTO_delegate(ProcessSTO);
            dele.BeginInvoke(null, null);
            
        }
        public void ProcessSTO()
        {
            if(Sto.Run_Stat == STO_RUN_STAT.TO_RUN)
            {
                Sto.Run_Stat = STO_RUN_STAT.RUNNING;
                Program.fmMainWindow.RefreshUI();
                
                Thread.Sleep(5000);
                logger.Info("hello i am sto");
                Sto.Run_Stat = STO_RUN_STAT.TO_RUN;
                Program.fmMainWindow.RefreshUI();
            }
            
        }

       
    }
}
