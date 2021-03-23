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
    class JumpHeight : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.jump" };
        public string Description => "Change the jump height";
        public string Name => "jumpheight";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length != 1)
            {
                response = CommandResponse.Create(false, "Usage : jumpheight (value / reset)");
                return;
            }
            float value;

            if (float.TryParse(args[0], out value))
            {
                foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                {
                    player.Key.jumpHeight = value;
                }
                response = CommandResponse.Create(true, $"Set jump height to {value}");
            }
            else if (args[0].Equals("reset"))
            {
                foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                {
                    player.Key.jumpHeight = 1;
                }
                response = CommandResponse.Create(true, "Reset everyones jump height");
            }
            else
            {
                response = CommandResponse.Create(false, $"Invalid Entry at : {args[0]}");
                return;
            }
        }
    }
}
