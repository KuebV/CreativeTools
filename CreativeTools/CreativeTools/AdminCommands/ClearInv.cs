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
    public class ClearInv : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.inventory" };
        public string Description => "Clear a chosen members inventory";
        public string Name => "clearinv";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            currentplayer.ClearInv();
            response = CommandResponse.Create(true, $"Done, Cleared {currentplayer.playerName}'s Inventory");
        }
    }
}
