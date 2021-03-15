using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CensusAPI.Features;
using CensusCore.Events;
using CensusCore.Harmony.Events.Player;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using PluginFramework.Classes;

namespace CreativeTools.Commands
{
    [ChatCommand]
    public class Noclip : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>() { "admin.noclip" };
        public string Description => "Easier way of Noclip";
        public string Name => "noclip";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>() { "nc" };
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            string resp = "";

            if (args.Length < 1)
            {
                Player target = Player.Get(invoker);
                if (target.NoclipEnabled)
                {
                    target.NoclipEnabled = false;
                    response = CommandResponse.Create(true, "Disabled NoClip");
                    return;
                }
                else
                {
                    target.NoclipEnabled = true;
                    response = CommandResponse.Create(true, "Enabled NoClip");
                    return;
                }
            }
            string player = args.GetValue(0).ToString().ToLower();

            foreach (Player ply in Player.List)
            {
                if (ply.Nickname.ToLower().Contains(player))
                {
                    if (ply.NoclipEnabled)
                    {
                        ply.NoclipEnabled = false;
                        resp = $"Disabled NoClip for {ply.Nickname}";
                    }
                    else
                    {
                        ply.NoclipEnabled = true;
                        resp = $"Enabled NoClip for {ply.Nickname}";
                    }
                }
            }

            response = CommandResponse.Create(true, resp);
        }
    }
}
