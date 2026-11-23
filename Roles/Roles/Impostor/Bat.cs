namespace ModRyon.Roles.Impostor
{
    public static class Bat
    {
        public const string RoleName = "こうもり";
        public const string Faction = "インポスター";
        public const string Description =
            "対象を選択し、設定した秒数後に死亡させる。";

        public const int DefaultDeathDelay = 5;
        public const int MinDeathDelay = 3;
        public const int MaxDeathDelay = 30;

        public const int DefaultGlowDuration = 5;
        public const int MinGlowDuration = 3;
        public const int MaxGlowDuration = 30;

        public const bool CanSelectAnyDistance = true;
    }
}
