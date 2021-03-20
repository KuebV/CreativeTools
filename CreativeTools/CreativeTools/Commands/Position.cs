using System;
using System.Collections.Generic;
using CensusAPI.Features;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Player;
using UnityEngine;
using Mirror;

namespace CreativeTools.Commands
{
    [ChatCommand]
    public class Position : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>();
        public string Description => "Get the Players Position";
        public string Name => "position";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        private Coroutine coroutine;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            Player player = Player.Get(invoker);
            response = CommandResponse.Create(true, getPosition(player.GameObject));
            return;
        }

        private static string getPosition(GameObject obj)
        {
            NetworkIdentity identity = obj.GetComponent<NetworkIdentity>();
            string pos = $"X:{identity.transform.position.x} Y:{identity.transform.position.y} Z:{identity.transform.position.z}";
            return pos;
        }

        private void showPosition(string Position)
        {
            if (this.coroutine != null)
            {
                base.StopCoroutine(this.coroutine)
            }
        }
    }
}
