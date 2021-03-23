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
    class PBC : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.pbc" };
        public string Description => "Private Broadcast";
        public string Name => "pbc";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length < 2)
            {
                response = CommandResponse.Create(false, "Usage : pbc (time) (message)");
                return;
            }
            string[] bc = args.Skip(1).ToArray<string>();
            string message = string.Join(" ", bc);

            float time;

            if (float.TryParse(args[0], out time))
            {
                currentplayer.Broadcast(message, time);
                response = CommandResponse.Create(true, "Done!");
                return;
            }
            else
            {
                response = CommandResponse.Create(false, $"Invalid Time of : {args[0]}");
                return;
            }



        }
    }
}
