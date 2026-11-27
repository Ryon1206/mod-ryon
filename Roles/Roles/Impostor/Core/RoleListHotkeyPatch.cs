using HarmonyLib;
using UnityEngine;

namespace ModRyon.Core
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class RoleListHotkeyPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (AmongUsClient.Instance == null)
                return;

            if (!AmongUsClient.Instance.IsGameStarted)
                return;

            if (Input.GetKeyDown(KeyCode.F8))
            {
                RoleListNotifier.Show();
            }
        }
    }
}
