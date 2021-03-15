using CensusAPI.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeTools
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CreativeTools";

        public override Version Version => new Version(1, 0, 1);

        public override string Author => "KuebV";

        public static Plugin Instance { get; private set; }

        public Dictionary<Player, Player> JailedUsers { get; } = new Dictionary<Player, Player>();
        public Dictionary<Player, string> BypassUsers { get; } = new Dictionary<Player, string>();

        public override void Disable()
        {
            Instance = null;
        }

        public override void Enable()
        {
            Instance = this;
            CensusCore.CensusCore.InjectEvents();
            Log.Info("CreativeTools has been enabled!");
        }
    }
}
