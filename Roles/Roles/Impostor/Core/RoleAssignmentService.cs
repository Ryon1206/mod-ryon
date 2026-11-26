namespace ModRyon.Core
{
    public static class RoleAssignmentService
    {
        public static bool Assign(
            byte playerId,
            string playerName,
            CustomRole role)
        {
            if (role == CustomRole.None)
                return false;

            if (RoleInfoManager.Get(role) == null)
                return false;

            // ホスト側に役職を保存
            RoleManager.Assign(playerId, role);

            // 全プレイヤーに役職を同期
            CustomRoleRpc.Send(playerId, role);

            // 試合ログに記録
            MatchLog.RoleAssigned(playerName, role);

            return true;
        }

        public static void ResetMatch()
        {
            RoleManager.Clear();
            MatchLog.Clear();
            MatchLogPublisher.Reset();
        }
    }
}
