using HarmonyLib;
using MiraAPI.GameOptions;
using ModRyon.Options;
using UnityEngine;

namespace ModRyon.Core
{
    [HarmonyPatch(
        typeof(global::RoleManager),
        nameof(global::RoleManager.SelectRoles)
    )]
    public static class RoleSettingsApplyPatch
    {
        [HarmonyPrefix]
        public static void Prefix()
        {
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost)
                return;

            var options =
                OptionGroupSingleton<ModRyonOptions>.Instance;

            if (options == null)
                return;

            RoleSettings.BatCount =
                Mathf.RoundToInt(options.BatCount);

            RoleSettings.BatGlowDuration =
                Mathf.RoundToInt(options.BatGlowDuration);

            RoleSettings.BombardierCount =
                Mathf.RoundToInt(options.BombardierCount);

            RoleSettings.TaskNoticeDuration =
                Mathf.RoundToInt(options.TaskNoticeDuration);
        }
    }
}
