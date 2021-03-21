using System;
using System.Collections.Generic;
using System.Linq;
using CensusAPI.Features;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using VirtualBrightPlayz.SCP_ET.ServerGroups;
using UnityEngine;
using CensusAPI.Enums;

namespace CreativeTools.AdminCommands
{
    [AdminCommand]
    public class Give : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.give" };
        public string Description => "Give yourself an item";
        public string Name => "give";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length < 1)
            {
                response = CommandResponse.Create(false, "Usage : give (item)");
                return;
            }

            ItemType type = ItemType.Ammo;
            try
            {
                type = (ItemType)Enum.Parse(typeof(ItemType), args.GetValue(0).ToString());
            }
            catch (Exception e)
            {
                response = CommandResponse.Create(false, "Invalid Item Type");
                return;
            }

            // Item spawns in the floor
            float xPos = invoker.transform.position.x;
            float yPos = (float)(invoker.transform.position.y + 1);
            float zPos = invoker.transform.position.z;
            Vector3 fixedPos = new Vector3(xPos, yPos, zPos);
            EventHandlers.SpawnItem(type, fixedPos, invoker.transform.rotation);
            response = CommandResponse.Create(true, $"Spawned {type} at your location");
        }
    }
}
