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

namespace CreativeTools.Commands
{
    [ChatCommand]
    public class Jail : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.jail", "admin.teleport" };
        public string Description => "Jail a User";
        public string Name => "jail";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>() { "freeze" };
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            string resp = "";

            try
            {
                if (args.Length < 1)
                {
                    response = CommandResponse.Create(true, "Usage : /jail {user} {reason}");
                    return;
                }
                if (args.Length < 2)
                {
                    response = CommandResponse.Create(true, "You must supply a reason!");
                    return;
                }

                string targetName = args.GetValue(0).ToString().ToLower();

                foreach (Player target in Player.List)
                {
                    if (target.Nickname.ToLower().Contains(targetName))
                    {
                        if (Plugin.Instance.JailedUsers.ContainsKey(target))
                        {
                            EventHandlers.UnjailUser(target, Player.Get(invoker));
                            response = CommandResponse.Create(true, "That user has been unjailed");
                            return;
                        }
                        resp = $"Player Found : {target.Nickname}";
                        EventHandlers.JailUser(target, Player.Get(invoker), args.GetValue(1).ToString());
                    }
                    else
                    {
                        resp = $"Player : {targetName} was not found";
                    }
                }

               

            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            response = CommandResponse.Create(true, resp);
        }
    }
}
