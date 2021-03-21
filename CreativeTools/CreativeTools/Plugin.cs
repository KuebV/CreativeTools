using CensusAPI.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreativeTools
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CreativeTools";

        public override Version Version => new Version(1, 2, 1);

        public override string Author => "KuebV";

        public static Plugin Instance { get; private set; }

        public static int RequiredConfigVersion => 2;

        public static List<Jailed> JailedPlayers = new List<Jailed>();

        public override void Disable()
        {
            Instance = null;
        }

        public override void Enable()
        {
            Instance = this;
            // Check the most recent config is being used
            if (Config.ConfigVersion != RequiredConfigVersion)
                Log.Error("Your config file is out of date! Delete the old one and reboot the server");
            CensusCore.CensusCore.InjectEvents();
            Log.Info("CreativeTools has been enabled!");
        }
    }
}
