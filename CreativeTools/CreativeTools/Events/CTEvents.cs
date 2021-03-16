using CensusAPI.Enums;
using CensusAPI.Features;
using CensusCore.Events.Attributes;
using CensusCore.Events.EventArgs.Player;
using PluginFramework.Attributes;
using PluginFramework.Classes;
using PluginFramework.Events.EventsArgs;
using System.IO;
using System;

namespace CreativeTools.Events
{
    public class CTEvents : IScript
    {

        [WorldEvent(WorldEventType.OnRoundEnd)]
        public static void OnRoundEnd(RoundEndEvent ev)
        {
            Plugin.JailedPlayers.Clear();
        }

        [WorldEvent(WorldEventType.OnRoundStart)]
        public static void RoundStart()
        {
            Plugin.JailedPlayers.Clear();
        }

    }
}
