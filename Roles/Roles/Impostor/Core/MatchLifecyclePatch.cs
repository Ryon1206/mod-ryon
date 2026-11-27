using HarmonyLib;

namespace ModRyon.Core
{
    [HarmonyPatch(
        typeof(AmongUsClient),
        nameof(AmongUsClient.CoStartGame)
    )]
    public static class MatchLifecyclePatch
    {
        [HarmonyPrefix]
        public static void Prefix()
        {
            if (AmongUsClient.Instance == null)
                return;

            RoleListHotkeyPatch.Reset();
            TaskStartNotification.Clear();
            BatRuntimeState.Clear();

            if (!AmongUsClient.Instance.AmHost)
                return;

            RoleAssignmentService.ResetMatch();
        }
    }
}
