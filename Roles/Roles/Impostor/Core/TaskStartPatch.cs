using HarmonyLib;

namespace ModRyon.Core
{
    [HarmonyPatch(typeof(Minigame), nameof(Minigame.Begin))]
    public static class TaskStartPatch
    {
        public static void Postfix(
            [HarmonyArgument(0)] PlayerTask task)
        {
            if (task == null ||
                PlayerControl.LocalPlayer == null ||
                AmongUsClient.Instance == null)
                return;

            TaskStartRpc.Send(
                task.Id,
                PlayerControl.LocalPlayer.PlayerId
            );
        }
    }
}
