using HarmonyLib;
using UnityEngine;

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

            Debug.Log(
                $"[Mod-Ryon] タスク開始を検出！ ID: {task.Id}"
            );
        }
    }
}
