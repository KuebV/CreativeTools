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
        public string TargetJailMessage { get; set; } = "<color=red>%target%, You have been jailed! %staff% will be with you soon</color>\n<color=green>Reason : %reason%</color>";
        public int TargetJailMessageDuration { get; set; } = 20;
        public string StaffJailMessage { get; set; } = "<color=red> You have jailed %target%. Do not forget to unjail them!</color>";
        public int StaffJailMessageDuration { get; set; } = 10;
        public string TargetFreezeMessage { get; set; } = "<color=red>You have been frozen!</color>\n<color=green>Reason : %reason%</color>";
        public int TargetFreezeMessageDuration { get; set; } = 10;
        public string TargetUnfreezeMessage { get; set; } = "You have been unfrozen!";
        public int TargetUnfreezeMessageDuration { get; set; } = 5;
    }
}
