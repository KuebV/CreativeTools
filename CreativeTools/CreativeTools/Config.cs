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
        public string TargetJailMessage { get; set; } = "%target%, you have been frozen. %staff% will be with you shortly\n</color=green>%reason%</color>";
        public int TargetJailMessageDuration { get; set; } = 20;
        public string StaffJailMessage { get; set; } = "<color=red> You have jailed %target%. Do not forget to unjail them!</color>";
        public int StaffJailMessageDuration { get; set; } = 10;
    }
}
