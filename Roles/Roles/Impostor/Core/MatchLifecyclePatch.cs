using HarmonyLib;

namespace ModRyon.Core
{
    [HarmonyPatch(
        typeof(AmongUsClient),
        nameof(AmongUsClient.CoStartGame)
    )]
    public static class MatchLifecyclePatch
    {
        public static void Prefix()
        {
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost)
                return;

            RoleAssignmentService.ResetMatch();
            BatRuntimeState.Clear();
            BombardierRuntimeState.Clear();
        }
    }
}
