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
    public class Gravity : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.gravity" };
        public string Description => "Set the gravity";
        public string Name => "gravity";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length < 1)
            {
                response = CommandResponse.Create(false, "Usage : gravity (value)");
                return;
            }

            float gravity;
            // Contrarary to previous methods of doing this with Census, this grabs the actual playercontroller, and sets their gravity. Less errors, happier people
            if (float.TryParse(args[0], out gravity))
            {
                foreach(KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                {
                    setGravity(player.Key, gravity);
                }

                response = CommandResponse.Create(true, $"Set the Gravity to : {gravity}");
            }
            else if (args.ElementAt(0).Equals("get"))
            {
                response = CommandResponse.Create(true, $"Current Gravity : {invoker.gravity}");
                return;
            }
            else
            {
                foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                {
                    setGravity(player.Key, (float)-19.62f);
                }
                response = CommandResponse.Create(true, "Gravity has been reset");
                return;
            }

        }

        private static void setGravity(PlayerController player, float Value)
        {
            player.gravity = Value;
        }
    }
}
