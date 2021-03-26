using System;
using System.Collections.Generic;
using System.Linq;
using CensusAPI.Features;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using VirtualBrightPlayz.SCP_ET.ServerGroups;
using UnityEngine;
using Assets.Scripts;


namespace CreativeTools.AdminCommands
{
    [AdminCommand]
    public class HP : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.hp" };
        public string Description => "Set HP for everyone or the current player";
        public string Name => "hp";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length != 1)
            {
                response = CommandResponse.Create(false, "Usage : hp (value) [all / *]");
                return;
            }

            float health;

            if (float.TryParse(args[0], out health))
            {
                if (args[1].Equals("*") || args[1].Equals("all"))
                {
                    foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                    {
                        player.Key.healthController.Health = health;
                    }
                    response = CommandResponse.Create(true, $"Set all players HP to {health}");
                }
                else
                {
                    currentplayer.healthController.Health = health;
                    response = CommandResponse.Create(true, $"Set {currentplayer.name}'s HP to {health}");
                    return;
                }
            }
            else
            {
                response = CommandResponse.Create(false, $"Invalid Value at : {args[0]}");
            }
        }
    }
}
