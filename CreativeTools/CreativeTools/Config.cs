using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CensusAPI.Interfaces;

namespace CreativeTools
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int ConfigVersion { get; set; } = 3;
        public bool NeedReasonFreeze { get; set; } = false;
        public bool DisplayFreezeMessage { set; get; } = false;
        public string TargetFreezeMessage { get; set; } = "<color=red>You have been frozen!</color>\n<color=green>Reason : %reason%</color>";
        public int TargetFreezeMessageDuration { get; set; } = 10;
        public string TargetUnfreezeMessage { get; set; } = "You have been unfrozen!";
        public int TargetUnfreezeMessageDuration { get; set; } = 5;

    }
}
