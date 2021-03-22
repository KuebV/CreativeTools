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
    class Speed : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.speed" };
        public string Description => "Increases the speed of players";
        public string Name => "speed";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length < 3)
            {
                response = CommandResponse.Create(false, "Usage : speed (sprinting / walking / crouching) (value / reset) [all / me]");
                return;
            }

            float speed;

            switch (args.ElementAt(0).ToLower())
            {
                case "sprinting":
                    if (float.TryParse(args[1], out speed))
                    {
                        if (args.ElementAt(2).Equals(null))
                        {
                            sprintSpeed(currentplayer, speed);
                            response = CommandResponse.Create(true, $"Set {currentplayer.name} sprinting speed to {speed}");
                            return;
                        }
                        else if (args.ElementAt(2).Equals("all"))
                        {
                            foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                            {
                                sprintSpeed(player.Key, speed);
                            }
                            response = CommandResponse.Create(true, $"Set all players sprinting speed to {speed}");
                        }
                        else
                        {
                            sprintSpeed(invoker, speed);
                            response = CommandResponse.Create(true, $"Set your sprinting speed to {speed}");
                            return;
                        }
                    }
                    response = CommandResponse.Create(false, "Incorrect Usage");
                    return;
                case "walking":
                    if (float.TryParse(args[1], out speed))
                    {
                        if (args.ElementAt(2).Equals(null))
                        {
                            walkSpeed(currentplayer, speed);
                            response = CommandResponse.Create(true, $"Set {currentplayer.name} walking speed to {speed}");
                            return;
                        }
                        else if (args.ElementAt(2).Equals("all"))
                        {
                            foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                            {
                                walkSpeed(player.Key, speed);
                            }
                            response = CommandResponse.Create(true, $"Set all players walking speed to {speed}");
                        }
                        else
                        {
                            walkSpeed(invoker, speed);
                            response = CommandResponse.Create(true, $"Set your walking speed to {speed}");
                            return;
                        }
                    }
                    response = CommandResponse.Create(false, "Incorrect Usage");
                    return;
                case "crouching":
                    if (float.TryParse(args[1], out speed))
                    {
                        if (args.ElementAt(2).Equals(null))
                        {
                            crouchSpeed(currentplayer, speed);
                            response = CommandResponse.Create(true, $"Set {currentplayer.name} crouching speed to {speed}");
                            return;
                        }
                        else if (args.ElementAt(2).Equals("all"))
                        {
                            foreach (KeyValuePair<PlayerController, PlayerListElement> player in PlayerList.List.players)
                            {
                                crouchSpeed(player.Key, speed);
                            }
                            response = CommandResponse.Create(true, $"Set all players crouching speed to {speed}");
                        }
                        else
                        {
                            crouchSpeed(invoker, speed);
                            response = CommandResponse.Create(true, $"Set your crouching speed to {speed}");
                            return;
                        }
                    }
                    response = CommandResponse.Create(false, "Incorrect Usage");
                    return;
                default:
                    response = CommandResponse.Create(false, "Usage : speed (sprinting / walking / crouching) (value / reset) [all / me]");
                    return;
            }
            // Oh no something went wrong
            response = CommandResponse.Create(false, "Usage : speed (sprinting / walking / crouching) (value / reset) [all / me]");
            return;

        }

        private static void crouchSpeed(PlayerController player, float Value)
        {
            player.crouchSpeed = Value;
            
        }

        private static void walkSpeed(PlayerController player, float Value)
        {
            player.walkSpeed = Value;
        }

        private static void sprintSpeed(PlayerController player, float Value)
        {
            player.sprintSpeed = Value;
        }
    }
}
