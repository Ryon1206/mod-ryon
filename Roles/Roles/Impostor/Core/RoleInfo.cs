using System.Collections.Generic;

namespace ModRyon.Core
{
    public sealed class RoleInfo
    {
        public CustomRole Role { get; }
        public string Name { get; }
        public string Faction { get; }
        public string Description { get; }
        public string FlavorText { get; }

        public RoleInfo(
            CustomRole role,
            string name,
            string faction,
            string description,
            string flavorText)
        {
            Role = role;
            Name = name;
            Faction = faction;
            Description = description;
            FlavorText = flavorText;
        }
    }

    public static class RoleInfoManager
    {
        private static readonly Dictionary<CustomRole, RoleInfo> Roles = new()
        {
            {
                CustomRole.Bat,
                new RoleInfo(
                    CustomRole.Bat,
                    "こうもり",
                    "インポスター",
                    "距離に関係なく対象を指定し、設定した時間の後に死亡させる。",
                    "どこにいても、死は近づく。"
                )
            },
            {
                CustomRole.Bombardier,
                new RoleInfo(
                    CustomRole.Bombardier,
                    "爆弾魔",
                    "インポスター",
                    "爆弾を設置し、タスクを行ったプレイヤーに爆弾を仕掛ける。",
                    "タスクのご褒美よ"
                )
            }
        };

        public static RoleInfo Get(CustomRole role)
        {
            return Roles.TryGetValue(role, out var info)
                ? info
                : null;
        }

        public static IEnumerable<RoleInfo> GetAll()
        {
            return Roles.Values;
        }
    }
}
