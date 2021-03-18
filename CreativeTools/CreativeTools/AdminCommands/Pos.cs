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
    public class Pos : AdminMenu.IAdminCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.pos" };
        public string Description => "Read the github";
        public string Name => "pos";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, PlayerController currentplayer, string[] args, out CommandResponse response)
        {
            if (args.Length != 3)
            {
                response = CommandResponse.Create(true, "Usage : pos (x) (y) (z)");
                return;
            }
            float xPos, yPos, zPos;
            Vector3 currentPos = invoker.transform.position;
            if (float.TryParse(args[0], out xPos))
            {
                xPos = currentPos.x + xPos;
                if (float.TryParse(args[1], out yPos))
                {
                    yPos = currentPos.y + yPos;
                    if (float.TryParse(args[2], out zPos))
                    {
                        zPos = currentPos.z + zPos;
                        Vector3 teleport = new Vector3(xPos, yPos, zPos);
                        invoker.movementController.ForceSetPos(teleport);
                        response = CommandResponse.Create(true, "Done");
                        return;
                    }
                }
            }
            response = CommandResponse.Create(true, "Invalid Usage. Check the Github");
            return;
        }
    }
}
