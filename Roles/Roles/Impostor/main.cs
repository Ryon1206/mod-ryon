using BepInEx;
using BepInEx.Unity.IL2CPP;
using ModRyon.Roles.Impostor;

namespace ModRyon
{
    [BepInPlugin("ryon.modryon", "ModRyon", "1.0.0")]
    public class Main : BasePlugin
    {
        public override void Load()
        {
            BatSettings.Initialize(Config);
            Log.LogInfo("ModRyon loaded!");
        }
    }
}
