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
using System.Globalization;

namespace CreativeTools.Commands
{
    [ChatCommand]
    public class Gravity : TextChat.IChatCommand
    {
        // Helpful Note : Setting gravity to 0, will disable the jump.
        public List<string> RequiredPermission => new List<string>() { "ct.gravity" };
        public string Description => "Change the Gravity for the whole server";
        public string Name => "gravity";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            if (args.Length != 1)
            {
                response = CommandResponse.Create(true, "Usage : /gravity (value / reset)");
                return;
            }

            try
            {
                if (args.GetValue(0).ToString().ToLower().Equals("reset"))
                {
                    foreach(Player player in Player.List)
                    {
                        // What the fuck
                        player.Gravity = -19.62f;
                    }
                    response = CommandResponse.Create(true, "Reset Gravity");
                    return;
                }
                else if (args.GetValue(0).ToString().ToLower().Equals("get"))
                {
                    // Initally used as a test to see what the value was, but its just helpful to keep now
                    Player player = Player.Get(invoker);
                    response = CommandResponse.Create(true, $"Current Gravity Value : {player.Gravity}");
                    return;

                }
                else
                {
                    foreach(Player player in Player.List)
                    {
                        player.Gravity = float.Parse(args.GetValue(0).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    }
                    response = CommandResponse.Create(true, $"Gravity has been set to {args.GetValue(0).ToString()}");
                    return;
                }
            }
            catch(Exception e)
            {
                Log.Error(e);
                response = CommandResponse.Create(true, "An error has occured, and cannot continue");
                return;
            }
        }
    }
}
