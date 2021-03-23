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
    class BringAll : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "admin.teleport" };
        public string Description => "Bring all users to you";
        public string Name => "bringall";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
            {
                player.Key.transform.position = invoker.transform.position;
            }

            response = CommandResponse.Create(true, "Brought all players to your position!");
            return;
        }
    }
}
