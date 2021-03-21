using System;
using System.Collections.Generic;
using System.Linq;
using CensusAPI.Features;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using VirtualBrightPlayz.SCP_ET.ServerGroups;
using UnityEngine;


namespace CreativeTools.AdminCommands
{
    [AdminCommand]
    public class Nickname : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.nickname" };
        public string Description => "Set a nickname for a user";
        public string Name => "nickname";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length != 2)
            {
                response = CommandResponse.Create(false, "Usage : nickname (player / all) (name)");
                return;
            }

            string[] v = args.Skip(1).ToArray<string>();
            string name = string.Join(" ", v);

            if (args.GetValue(0).ToString().ToLower().Equals("all"))
            {
                foreach (Player player in Player.List)
                {
                    EventHandlers.changeNickname(player, name);
                }
                response = CommandResponse.Create(true, $"Set all Nicknames to {name}");
                return;
            }
            else
            {
                EventHandlers.changeNickname(EventHandlers.getPlayer(currentplayer.name), name);
                response = CommandResponse.Create(true, $"Set Nickname to {name}");
                return;
            }

        }
    }
}
