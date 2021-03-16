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
using System.Globalization;

namespace CreativeTools.Commands
{
    [ChatCommand]
    class JumpHeight : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.jump" };
        public string Description => "Change the jump height for players";
        public string Name => "jumpheight";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            if (args.Length != 1)
            {
                response = CommandResponse.Create(true, "Usage : /jumpheight (value / reset)");
                return;
            }

            try
            {
                if (args.GetValue(0).ToString().ToLower().Equals("reset"))
                {
                    foreach (Player player in Player.List)
                    {
                        EventHandlers.changeJumpHeight(player, 1);
                    }
                    response = CommandResponse.Create(true, "Reset Jump Height");
                    return;
                }
                else
                {
                    foreach (Player player in Player.List)
                    {
                        EventHandlers.changeJumpHeight(player, float.Parse(args.GetValue(0).ToString(), CultureInfo.InvariantCulture.NumberFormat));
                    }
                    response = CommandResponse.Create(true, $"Jump Height has been set to {args.GetValue(0).ToString()}");
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                response = CommandResponse.Create(true, "An error has occured, and cannot continue");
                return;
            }
        }
    }
}
