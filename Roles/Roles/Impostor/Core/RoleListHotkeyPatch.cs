using HarmonyLib;
using UnityEngine;

namespace ModRyon.Core
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class RoleListHotkeyPatch
    {
        private static float nextUseTime;

        [HarmonyPostfix]
        public static void Postfix()
        {
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.IsGameStarted)
            {
                nextUseTime = 0f;
                return;
            }

            if (Time.time < nextUseTime)
                return;

            if (!Input.GetKeyDown(KeyCode.F8))
                return;

            nextUseTime = Time.time + 1f;
            RoleListNotifier.Show();
        }

        public static void Reset()
        {
            nextUseTime = 0f;
        }
    }
}
