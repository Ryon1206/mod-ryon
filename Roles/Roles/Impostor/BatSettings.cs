using BepInEx.Configuration;

namespace ModRyon.Roles.Impostor
{
    public static class BatSettings
    {
        public static ConfigEntry<int> DeathDelay { get; private set; }
        public static ConfigEntry<string> GlowDuration { get; private set; }

        public static void Initialize(ConfigFile config)
        {
            DeathDelay = config.Bind(
                "こうもり", "指定後の死亡までの秒数", 5,
                new AcceptableValueRange<int>(3, 30)
            );

            GlowDuration = config.Bind(
                "こうもり", "発光時間", "5",
                new AcceptableValueList<string>(
                    "3", "4", "5", "6", "7", "8", "9", "10",
                    "11", "12", "13", "14", "15", "16", "17", "18",
                    "19", "20", "21", "22", "23", "24", "25", "26",
                    "27", "28", "29", "30", "無制限"
                )
            );
        }

        public static bool IsGlowUnlimited => GlowDuration.Value == "無制限";

        public static int GlowSeconds =>
            IsGlowUnlimited ? -1 : int.Parse(GlowDuration.Value);
    }
}
