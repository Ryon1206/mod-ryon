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

            RoleManager.Assign(playerId, role);
            MatchLog.RoleAssigned(playerName, role);

            return true;
        }

        public static void ResetMatch()
        {
            RoleManager.Clear();
            MatchLog.Clear();
        }
    }
}
