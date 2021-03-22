using System;
using System.Collections.Generic;
using System.Linq;
using CensusAPI.Features;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using VirtualBrightPlayz.SCP_ET.ServerGroups;
using UnityEngine;
using System.Text;

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
            try
            {
                if (args.Length < 1)
                {
                    if (Plugin.JailedPlayers.Any(j => j.SteamID == currentplayer.steamId.ToString()))
                    {
                        AdminUnjail(invoker, currentplayer);
                        response = CommandResponse.Create(true, $"{currentplayer.playerName} has been unjailed");
                        Log.Info($"{currentplayer.playerName}({currentplayer.steamId}) has been unjailed by {invoker.playerName}({invoker.steamId}) [{invoker.playerGroup}]");
                    }
                    if (!Plugin.Instance.Config.NeedReasonJail)
                    {
                        AdminJail(invoker, currentplayer, null);
                        response = CommandResponse.Create(true, $"{currentplayer.playerName} has been jailed");
                        Log.Info($"{currentplayer.playerName}({currentplayer.steamId}) has been jailed by {invoker.playerName}({invoker.steamId}) [{invoker.playerGroup}]");
                        return;
                    }
                    response = CommandResponse.Create(false, "Usage : jail (reason)");
                    return;
                }

                if (Plugin.JailedPlayers.Any(j => j.SteamID == currentplayer.steamId.ToString()))
                {
                    AdminUnjail(invoker, currentplayer);
                    response = CommandResponse.Create(true, $"{currentplayer.playerName} has been unjailed");
                    Log.Info($"{currentplayer.playerName}({currentplayer.steamId}) has been unjailed by {invoker.playerName}({invoker.steamId}) [{invoker.playerGroup}]");
                }

                string[] v = args.Skip(0).ToArray<string>();
                string reason = string.Join(" ", v);

                AdminJail(invoker, currentplayer, reason);
                response = CommandResponse.Create(true, $"{currentplayer.playerName} has been jailed");
                Log.Info($"{currentplayer.playerName}({currentplayer.steamId}) has been jailed by {invoker.playerName}({invoker.steamId}) [{invoker.playerGroup}]");
                return;
            }
            catch(Exception e)
            {
                Log.Error(e);
                response = CommandResponse.Create(false, "An error has occured, use Freeze");
                return;
            }
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

            Plugin.JailedPlayers.Add(new Jailed
            {
                Health = staff.Health,
                Position = invoker.transform.position,
                Nickname = staff.Nickname,
                SteamID = staff.SteamID
            });

            Vector3 jailPos = new Vector3((float)-98.64979, (float)3019.510, (float)216.9918);
            if (Plugin.Instance.Config.DisplayJailMessage)
            {
                target.Broadcast(EventHandlers.MessageFormatter(player, staff, Reason, Plugin.Instance.Config.TargetJailMessage), Plugin.Instance.Config.TargetJailMessageDuration);
                invoker.Broadcast(EventHandlers.MessageFormatter(player, staff, Reason, Plugin.Instance.Config.StaffJailMessage), Plugin.Instance.Config.StaffJailMessageDuration);
            }

            target.movementController.ForceSetPos(jailPos);
            invoker.movementController.ForceSetPos(jailPos);

        }

        private static void AdminUnjail(PlayerController invoker, PlayerController target)
        {
            Jailed jail = Plugin.JailedPlayers.Find(j => j.SteamID == target.steamId.ToString());
            target.ClearBroadcasts();
            Player.Get(target).Health = jail.Health;

            Jailed staff = Plugin.JailedPlayers.Find(j => j.SteamID == invoker.steamId.ToString());
            invoker.ClearBroadcasts();
            Player.Get(invoker).Health = staff.Health;

            // Less terrible
            Vector3 fixedPos = elevatedVector3(jail.Position.x, jail.Position.y, jail.Position.z);
            Vector3 fixedStaff = elevatedVector3(staff.Position.x, staff.Position.y, staff.Position.z);
            target.movementController.ForceSetPos(fixedPos);
            invoker.movementController.ForceSetPos(fixedStaff);

            Plugin.JailedPlayers.Remove(jail);
            Plugin.JailedPlayers.Remove(staff);
        }

        private static Vector3 elevatedVector3(float X, float Y, float Z)
        {
            Vector3 pos = new Vector3(X, (float)(Y + 0.5), Z);
            return pos;
        }
    }
}
