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
    public class Jail : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.jail" };
        public string Description => "Jail a User";
        public string Name => "jail";
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
                    response = CommandResponse.Create(true, "Usage : jail {user} {reason}");
                    return;
                }
                if (args.Length < 2)
                {
                    if (Plugin.JailedPlayers.Any(j => j.SteamID == currentplayer.steamId.ToString()))
                    {
                        AdminUnjail(invoker, currentplayer);
                        response = CommandResponse.Create(true, "User has been unjailed");
                        return;
                    }
                    response = CommandResponse.Create(true, "You must supply a reason!");
                    return;
                }

                if (Plugin.JailedPlayers.Any(j => j.SteamID == currentplayer.steamId.ToString()))
                {
                    AdminUnjail(invoker, currentplayer);
                    response = CommandResponse.Create(true, "User has been unjailed");
                    return;
                }

                AdminJail(invoker, currentplayer, args.GetValue(1).ToString());
                response = CommandResponse.Create(true, "User has ben jailed");

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            response = CommandResponse.Create(true, resp);
        }

        private static void AdminJail(PlayerController invoker, PlayerController target, string Reason)
        {
            Player player = Player.Get(target);
            Player staff = Player.Get(invoker);
            Plugin.JailedPlayers.Add(new Jailed
            {
                Health = player.Health,
                Position = target.transform.position,
                Nickname = player.Nickname.ToLower(),
                SteamID = player.SteamID
            });
            Vector3 jailPos = new Vector3((float)-98.64979, (float)3019.510, (float)216.9918);
            target.Broadcast(EventHandlers.MessageFormatter(player, staff, Reason, Plugin.Instance.Config.TargetJailMessage), Plugin.Instance.Config.TargetJailMessageDuration);
            invoker.Broadcast(EventHandlers.MessageFormatter(player, staff, Reason, Plugin.Instance.Config.StaffJailMessage), Plugin.Instance.Config.StaffJailMessageDuration);

            target.movementController.ForceSetPos(jailPos);
            invoker.movementController.ForceSetPos(jailPos);
        }

        private static void AdminUnjail(PlayerController invoker, PlayerController target)
        {
            Jailed jail = Plugin.JailedPlayers.Find(j => j.SteamID == target.steamId.ToString());
            target.movementController.ForceSetPos(jail.Position);
            target.ClearBroadcasts();
            Player.Get(target).Health = jail.Health;
            Plugin.JailedPlayers.Remove(jail);

            //This next section is fairly stupid due to how player controller positioning works, the Player falls through the floor
            float xPos = jail.Position.x;
            float yPos = (float)(jail.Position.y + 0.05);
            float zPos = jail.Position.z;
            Vector3 fixedPos = new Vector3(xPos, yPos, zPos);
            target.Position = fixedPos;
        }
    }
}
