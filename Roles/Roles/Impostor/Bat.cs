namespace ModRyon.Roles.Impostor
{
    public static class Bat
    {
        public const string RoleName = "こうもり";
        public const string Faction = "インポスター";

        public const string Description =
            "距離に関係なく対象を指定し、時間差で死亡させる。";

        public const string FlavorText =
            "どこにいても、死は近づく。";

        public const int DefaultDeathDelay = 5;
        public const int MinDeathDelay = 3;
        public const int MaxDeathDelay = 30;

        public const int DefaultGlowDuration = 5;
        public const int MinGlowDuration = 3;
        public const int MaxGlowDuration = 30;

        public const bool CanSelectAnyDistance = true;
    }
}
