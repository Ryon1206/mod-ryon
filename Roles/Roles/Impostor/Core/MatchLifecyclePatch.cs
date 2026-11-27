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

            // 全プレイヤーのローカル状態を初期化
            RoleListHotkeyPatch.Reset();
            TaskStartNotification.Clear();
            BatRuntimeState.Clear();
            BombardierRuntimeState.Clear();

            // 役職データの初期化はホストだけ
            if (!AmongUsClient.Instance.AmHost)
                return;

            RoleAssignmentService.ResetMatch();
        }
    }
}
