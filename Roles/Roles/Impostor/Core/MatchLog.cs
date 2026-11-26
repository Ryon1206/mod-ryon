using System.Collections.Generic;

namespace ModRyon.Core
{
    public static class MatchLog
    {
        private static readonly List<string> Logs = new();

        public static IReadOnlyList<string> All => Logs;

        public static void Add(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            Logs.Add(message);
        }

        public static void RoleAssigned(
            string playerName,
            CustomRole role)
        {
            var info = RoleInfoManager.Get(role);

            if (info == null)
                return;

            Add($"{playerName} に {info.Name} が割り当てられた");
        }

        public static void Clear()
        {
            Logs.Clear();
        }
    }
}
