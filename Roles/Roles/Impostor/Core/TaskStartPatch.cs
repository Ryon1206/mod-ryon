using HarmonyLib;

namespace ModRyon.Core
{
    [HarmonyPatch(typeof(Minigame), nameof(Minigame.Begin))]
    public static class TaskStartPatch
    {
        [HarmonyPostfix]
        public static void Postfix(
            [HarmonyArgument(0)] PlayerTask task)
        {
            if (task == null)
                return;

            TaskStartNotification.Show(task.Id);
        }
    }
}
