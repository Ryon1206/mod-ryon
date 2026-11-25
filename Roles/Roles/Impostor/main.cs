using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace ModRyon
{
    [BepInPlugin("ryon.modryon", "ModRyon", "1.0.0")]
    [BepInProcess("Among Us.exe")]
    public class Main : BasePlugin
    {
        public Harmony Harmony { get; } = new("ryon.modryon");

        public override void Load()
        {
            Harmony.PatchAll();
            Log.LogInfo("Mod-Ryon loaded!");
        }
    }
}
