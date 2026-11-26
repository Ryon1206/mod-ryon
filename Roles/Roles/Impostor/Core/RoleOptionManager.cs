namespace ModRyon.Core
{
    public static class RoleOptionManager
    {
        public static int GetValue(int id)
        {
            return id switch
            {
                RoleOptionDefinitions.BatCountId => RoleSettings.BatCount,
                RoleOptionDefinitions.BatDeathDelayId => RoleSettings.BatDeathDelay,
                RoleOptionDefinitions.BatGlowDurationId => RoleSettings.BatGlowDuration,
                RoleOptionDefinitions.BombardierCountId => RoleSettings.BombardierCount,
                RoleOptionDefinitions.BombardierBombCountId => RoleSettings.BombardierBombCount,
                RoleOptionDefinitions.BombardierExplosionTimeId => RoleSettings.BombardierExplosionTime,
                _ => -1
            };
        }

        public static bool SetValue(int id, int value)
        {
            switch (id)
            {
                case RoleOptionDefinitions.BatCountId:
                    if (value < 0 || value > 15) return false;
                    RoleSettings.BatCount = value;
                    return true;

                case RoleOptionDefinitions.BatDeathDelayId:
                    if (value < 3 || value > 30) return false;
                    RoleSettings.BatDeathDelay = value;
                    return true;

                case RoleOptionDefinitions.BatGlowDurationId:
                    if (value != -1 && (value < 3 || value > 30)) return false;
                    RoleSettings.BatGlowDuration = value;
                    return true;

                case RoleOptionDefinitions.BombardierCountId:
                    if (value < 0 || value > 15) return false;
                    RoleSettings.BombardierCount = value;
                    return true;

                case RoleOptionDefinitions.BombardierBombCountId:
                    if (value < 1 || value > 15) return false;
                    RoleSettings.BombardierBombCount = value;
                    return true;

                case RoleOptionDefinitions.BombardierExplosionTimeId:
                    if (value < 1 || value > 60) return false;
                    RoleSettings.BombardierExplosionTime = value;
                    return true;

                default:
                    return false;
            }
        }
    }
}
