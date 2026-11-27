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
                    "対象のプレイヤーに一時的な発光マークを付ける。",
                    "暗闇の中でも、目印を見逃さない。"
                )
            },
            {
                CustomRole.Bombardier,
                new RoleInfo(
                    CustomRole.Bombardier,
                    "爆弾魔",
                    "インポスター",
                    "タスク開始時に特別な通知を発生させる。",
                    "いつものタスクに、少し違う知らせを。"
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
