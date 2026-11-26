using HarmonyLib;

namespace ModRyon.Core
{
    [HarmonyPatch(
        typeof(RoleManager),
        nameof(RoleManager.SelectRoles)
    )]
    public static class CustomRoleAssignmentPatch
    {
        public static void Postfix()
        {
            // ホスト以外は処理しない
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost)
                return;

            if (GameData.Instance == null)
                return;

            // インポスターを集める
            var impostors = new System.Collections.Generic.List<byte>();
            var playerNames =
                new System.Collections.Generic.Dictionary<byte, string>();

            foreach (NetworkedPlayerInfo player
                in GameData.Instance.AllPlayers)
            {
                if (player == null ||
                    player.Object == null ||
                    player.IsDead)
                    continue;

                if (player.Object.Data.Role.Role != RoleTypes.Impostor)
                    continue;

                impostors.Add(player.PlayerId);
                playerNames[player.PlayerId] = player.PlayerName;
            }

            // 役職をランダムに抽選
            var assignments =
                RoleAssignmentPlanner.CreateAssignments(impostors);

            // 抽選結果を割り当てる
            foreach (var assignment in assignments)
            {
                byte playerId = assignment.Key;
                CustomRole role = assignment.Value;

                if (!playerNames.TryGetValue(
                    playerId,
                    out string playerName))
                    playerName = "プレイヤー";

                RoleAssignmentService.Assign(
                    playerId,
                    playerName,
                    role
                );
            }

            // 試合ログを公開
            MatchLogPublisher.Publish();
        }
    }
}
