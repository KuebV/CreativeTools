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
    public class Freeze : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.freeze" };
        public string Description => "Freeze a user in place";
        public string Name => "freeze";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            string resp = "";
            try
            {
                if (args.Length < 1)
                {
                    response = CommandResponse.Create(true, "Usage : freeze {user} {reason}");
                    return;
                }
                if (args.Length < 2)
                {
                    if (currentplayer.sprintSpeed == 0)
                    {
                        UnfreezePlayer(invoker, currentplayer);
                        response = CommandResponse.Create(true, "User has been unfrozen");
                        return;
                    }
                    response = CommandResponse.Create(true, "You must supply a reason!");
                    return;
                }

                if (currentplayer.sprintSpeed == 0)
                {
                    UnfreezePlayer(invoker, currentplayer);
                    response = CommandResponse.Create(true, "User has been unfrozen");
                    return;
                }

                FreezePlayer(invoker, currentplayer, args.GetValue(1).ToString());
                response = CommandResponse.Create(true, "User has ben frozen");

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            response = CommandResponse.Create(true, resp);
        }

        private static void FreezePlayer(PlayerController invoker, PlayerController target, string Message)
        {

            target.crouchSpeed = 0; target.sprintSpeed = 0; target.walkSpeed = 0; target.noTarget = true; target._godMode = true;
            target.Broadcast(EventHandlers.MessageFormatter(Player.Get(target), Player.Get(invoker), Message, Plugin.Instance.Config.TargetFreezeMessage), Plugin.Instance.Config.TargetFreezeMessageDuration);

            invoker.movementController.ForceSetPos(target.transform.position);
        }

        public static void UnfreezePlayer(PlayerController invoker, PlayerController target)
        {
            target.crouchSpeed = 2; target.sprintSpeed = 8; target.walkSpeed = 4; target.noTarget = false; target._godMode = false;
            target.Broadcast(MessageFormatterWOReason(Player.Get(target), Player.Get(invoker), Plugin.Instance.Config.TargetUnfreezeMessage), Plugin.Instance.Config.TargetUnfreezeMessageDuration);

            invoker.movementController.ForceSetPos(new Vector3(0, -5, 0));
            invoker.stats.KillPlayer(PlayerStats.DeathTypes.Admin, invoker.gameObject);

        }


        public static string MessageFormatterWOReason(Player target, Player staff, string Config) =>
            string.IsNullOrEmpty(Config) ? string.Empty : Config.Replace("%target%", target.Nickname).Replace("%staff%", staff.Nickname);
    }
}
