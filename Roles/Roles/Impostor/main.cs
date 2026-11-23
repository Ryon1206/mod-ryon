using BepInEx;
using BepInEx.Unity.IL2CPP;

namespace ModRyon
{
    [BepInPlugin("ryon.modryon", "ModRyon", "1.0.0")]
    public class Main : BasePlugin
    {
        public override void Load()
        {
            Log.LogInfo("ModRyon loaded!");
        }
    }
}
