namespace ModRyon.Core
{
    public static class RoleOptionDefinitions
    {
        // こうもり
        public const int BatCountId = 1000;
        public const int BatDeathDelayId = 1001;
        public const int BatGlowDurationId = 1002;

        // 爆弾魔
        public const int BombardierCountId = 2000;
        public const int BombardierBombCountId = 2001;
        public const int BombardierExplosionTimeId = 2002;

        public const string BatCountName = "こうもりの人数";
        public const string BatDeathDelayName = "指定後の死亡時間";
        public const string BatGlowDurationName = "発光時間";

        public const string BombardierCountName = "爆弾魔の人数";
        public const string BombardierBombCountName = "爆弾の設置回数";
        public const string BombardierExplosionTimeName = "爆発までの時間";
    }
}
