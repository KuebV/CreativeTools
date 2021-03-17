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
using VirtualBrightPlayz.SCP_ET.NetworkAuth;
using UnityEngine;
using Mirror;
using CensusAPI.Enums;

namespace CreativeTools
{
    public class EventHandlers
    {

        public static string MessageFormatter(Player target, Player staff, string Reason, string Config) =>
            string.IsNullOrEmpty(Config) ? string.Empty : Config.Replace("%target%", target.Nickname).Replace("%staff%", staff.Nickname).Replace("%reason%", Reason);

        public static Vector3 getPosition(PlayerController controller)
        {
            return controller.transform.position;
        }

        public static void changeNickname(Player player, string Value)
        {
            player.Nickname = Value;
        }

        public static void changeJumpHeight(Player player, float Value)
        {
            player.JumpHeight = Value;
        }

        public static void SpawnItem(ItemType itemType, Vector3 pos, Quaternion rot)
        {
            Map.SpawnItem(itemType, pos, rot);
        }
    }
}
