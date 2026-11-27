using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI.PluginLoading;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;

namespace ModRyon
{
    [BepInPlugin("ryon.modryon", "ModRyon", "1.0.0")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(MiraApiPlugin.Id)]
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Main : BasePlugin, IMiraPlugin
    {
        public Harmony Harmony { get; } =
            new("ryon.modryon");

        public string OptionsTitleText =>
            "Mod-Ryon";

        public string CustomOptionMenuNameTwo =>
            "役職設定";

        public bool ForceRegisterEvents => false;

        public ConfigFile GetConfigFile()
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
