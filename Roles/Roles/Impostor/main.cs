using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using MiraAPI.Translation;
using Reactor;

namespace ModRyon
{
    [BepInPlugin("ryon.modryon", "ModRyon", "1.0.0")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(MiraApiPlugin.Id)]
    public class Main : BasePlugin, IMiraPlugin
    {
        public Main()
        {
            MiraLocaleManager.Register(
                "ryon.modryon",
                typeof(Main).Assembly
            );
        }

        public Harmony Harmony { get; } = new("ryon.modryon");

        public string OptionsTitleText => "Mod-Ryon";

        public string CustomOptionMenuNameTwo => "Mod-Ryon";

        public bool ForceRegisterEvents => false;

        public BepInEx.Configuration.ConfigFile GetConfigFile()
        {
            return Config;
        }

        public override void Load()
        {
            Harmony.PatchAll();
            Log.LogInfo("Mod-Ryon loaded!");
        }
    }
}
