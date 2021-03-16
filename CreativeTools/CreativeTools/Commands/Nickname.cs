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
    public class Nickname : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>();
        public string Description => "Change a user's Username";
        public string Name => "nickname";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            if (args.Length != 2)
            {
                response = CommandResponse.Create(true, "Usage : /nickname (player / all) (name)");
                return;
            }

            string ply = args.GetValue(0).ToString();
            string name = args.GetValue(1).ToString();
            if (ply.ToLower().Equals("all"))
            {
                foreach(Player player in Player.List)
                {
                    EventHandlers.changeNickname(player, name);
                }
                response = CommandResponse.Create(true, $"Set all Nicknames to {name}");
                return;
            }
            else
            {
                foreach(Player player in Player.List)
                {
                    if (player.Nickname.ToLower().Contains(ply))
                    {
                        EventHandlers.changeNickname(player, name);
                        response = CommandResponse.Create(true, $"Set Nickname to {name}");
                        return;
                    }
                }
            }
            response = null;
            return;
        }
    }
}
