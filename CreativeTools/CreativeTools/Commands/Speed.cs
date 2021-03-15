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
    public class Speed : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>() { "ct.speed" };
        public string Description => "Set a players speed";
        public string Name => "speed";
        public bool ShowInHelpCmd => true;
        public List<string> Aliases => new List<string>();
        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out CommandResponse response)
        {
            if (args.Length != 3)
            {
                response = CommandResponse.Create(true, "Usage : /speed (walking/sprinting/crouching) (player name) (speed)");
                return;
            }

            try
            {
                switch (args.GetValue(0).ToString())
                {
                    case "walking":
                        if (args.GetValue(1).ToString().Equals("all"))
                        {
                            foreach (Player player in Player.List)
                            {
                                player.WalkSpeed = float.Parse(args.GetValue(2).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                response = CommandResponse.Create(true, $"Set the walking speed to {args.GetValue(2)}");
                                return;
                            }
                        }
                        foreach (Player player in Player.List)
                        {
                            if (player.Nickname.ToLower().Contains(args.GetValue(1).ToString().ToLower()))
                            {
                                player.WalkSpeed = float.Parse(args.GetValue(2).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                response = CommandResponse.Create(true, $"Set the walking speed to {args.GetValue(2)}");
                                return;
                            }
                        }

                        response = null;
                        return;
                    case "sprinting":
                        if (args.GetValue(1).ToString().Equals("all"))
                        {
                            foreach (Player player in Player.List)
                            {
                                player.SprintSpeed = float.Parse(args.GetValue(2).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                response = CommandResponse.Create(true, $"Set the sprinting speed to {args.GetValue(2)}");
                                return;
                            }
                        }
                        foreach (Player player in Player.List)
                        {
                            if (player.Nickname.ToLower().Contains(args.GetValue(1).ToString().ToLower()))
                            {
                                player.SprintSpeed = float.Parse(args.GetValue(2).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                response = CommandResponse.Create(true, $"Set the sprinting speed to {args.GetValue(2)}");
                                return;
                            }
                        }

                        response = null;
                        return;
                    case "crouching":
                        if (args.GetValue(1).ToString().Equals("all"))
                        {
                            foreach (Player player in Player.List)
                            {
                                player.CrouchSpeed = float.Parse(args.GetValue(2).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                response = CommandResponse.Create(true, $"Set the crouch speed to {args.GetValue(2)}");
                                return;
                            }
                        }
                        foreach (Player player in Player.List)
                        {
                            if (player.Nickname.ToLower().Contains(args.GetValue(1).ToString().ToLower()))
                            {
                                player.CrouchSpeed = float.Parse(args.GetValue(2).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                response = CommandResponse.Create(true, $"Set the crouch speed to {args.GetValue(2)}");
                                return;
                            }
                        }

                        response = null;
                        return;
                    default:
                        response = CommandResponse.Create(true, "Invalid Usage, Example : /speed sprinting all 5");
                        return;


                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                response = CommandResponse.Create(true, "An error has occured, and cannot continue");
                return;
            }
        }
    }
}
