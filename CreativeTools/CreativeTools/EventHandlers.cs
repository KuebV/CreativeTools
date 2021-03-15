using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CensusAPI.Features;
using CensusCore.Events;
using CensusCore.Harmony.Events.Player;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using PluginFramework.Classes;
using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
using UnityEngine;
using Mirror;

namespace CreativeTools
{
    public class EventHandlers
    {
        public static void JailUser(Player target, Player invoker, string Reason)
        {
            target.WalkSpeed = 0;
            target.CrouchSpeed = 0;
            target.SprintSpeed = 0;
            target.GodModeEnabled = true;
            target.NotargetEnabled = true;
            target.Broadcast(MessageFormatter(target, invoker, Reason, Plugin.Instance.Config.TargetJailMessage), Plugin.Instance.Config.TargetJailMessageDuration);

            invoker.GodModeEnabled = true;
            invoker.NotargetEnabled = true;
            invoker.Broadcast(MessageFormatter(target, invoker, Reason, Plugin.Instance.Config.StaffJailMessage), Plugin.Instance.Config.StaffJailMessageDuration);
            invoker.Position = target.Position;

            Plugin.Instance.JailedUsers.Add(target, invoker);

        }

        public static void UnjailUser(Player target, Player invoker)
        {
            target.WalkSpeed = 4;
            target.CrouchSpeed = 2;
            target.SprintSpeed = 8;
            target.GodModeEnabled = false;
            target.NotargetEnabled = false;
            target.Broadcast("<color=green> You have been unfrozen. Continue playing as usual! </color>", 5);

            invoker.Inventory.ClearInv();
            invoker.Kill();

            Plugin.Instance.JailedUsers.Remove(target);
        }

        private static string MessageFormatter(Player target, Player staff, string Reason, string Config) =>
            string.IsNullOrEmpty(Config) ? string.Empty : Config.Replace("%target%", target.Nickname).Replace("%staff%", staff.Nickname).Replace("%reason%", Reason);


        public static void TpX(Player first, Player second)
        {

        }

    }
}
