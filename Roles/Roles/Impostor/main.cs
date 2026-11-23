using System.Reflection;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using ModRyon.Roles.Impostor;

namespace ModRyon
{
    [BepInPlugin("ryon.modryon", "ModRyon", "1.0.0")]
    public class Main : BasePlugin
    {
        public override void Load()
        {
            BatSettings.Initialize(Config);

            var harmony = new Harmony("ryon.modryon");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Log.LogInfo("ModRyon loaded!");
        }
    }
}
