namespace ModRyon.Core
{
    public static class RoleSettings
    {
        // こうもり
        public static int BatCount { get; set; } = 1;
        public static int BatDeathDelay { get; set; } = 5;
        public static int BatGlowDuration { get; set; } = 5;

        public static bool IsBatGlowUnlimited =>
            BatGlowDuration == -1;

        // 爆弾魔
        public static int BombardierCount { get; set; } = 1;
        public static int BombardierBombCount { get; set; } = 2;
        public static int BombardierExplosionTime { get; set; } = 10;
    }
}
