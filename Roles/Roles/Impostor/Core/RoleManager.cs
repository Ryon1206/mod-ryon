using System.Collections.Generic;

namespace ModRyon.Core
{
    public enum CustomRole
    {
        None,
        Bat,
        Bombardier
    }

    public static class RoleManager
    {
        private static readonly Dictionary<byte, CustomRole> Roles = new();

        public static void Assign(byte playerId, CustomRole role)
        {
            Roles[playerId] = role;
        }

        public static CustomRole GetRole(byte playerId)
        {
            return Roles.TryGetValue(playerId, out var role)
                ? role
                : CustomRole.None;
        }

        public static void Clear()
        {
            Roles.Clear();
        }

        public static bool HasRole(byte playerId)
        {
            return GetRole(playerId) != CustomRole.None;
        }
    }
}
