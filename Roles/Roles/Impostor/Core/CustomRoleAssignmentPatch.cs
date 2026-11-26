using System.Collections.Generic;
using AmongUs.GameOptions;
using HarmonyLib;

namespace ModRyon.Core
{
    [HarmonyPatch(typeof(global::RoleManager), nameof(global::RoleManager.SelectRoles))]
    public static class CustomRoleAssignmentPatch
    {
        public static void Postfix()
        {
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost ||
                GameData.Instance == null)
                return;

            // 全員に役職設定を同期
            RoleSettingsRpc.Send();

            var impostors = new List<byte>();
            var playerNames = new Dictionary<byte, string>();

            foreach (NetworkedPlayerInfo data in GameData.Instance.AllPlayers)
            {
                if (data == null || data.Object == null || data.IsDead)
                    continue;

                RoleTypes role = data.Role.Role;

                if (role != RoleTypes.Impostor &&
                    role != RoleTypes.Shapeshifter &&
                    role != RoleTypes.Phantom &&
                    role != RoleTypes.Viper)
                    continue;

                impostors.Add(data.PlayerId);
                playerNames[data.PlayerId] = data.PlayerName;
            }

            var assignments =
                RoleAssignmentPlanner.CreateAssignments(impostors);

            foreach (var pair in assignments)
            {
                string name = playerNames.TryGetValue(
                    pair.Key, out var playerName)
                    ? playerName
                    : $"Player {pair.Key}";

                RoleAssignmentService.Assign(
                    pair.Key,
                    name,
                    pair.Value
                );
            }

            MatchLogPublisher.Publish();
        }
    }
}
