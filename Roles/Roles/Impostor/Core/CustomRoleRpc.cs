using HarmonyLib;
using Hazel;

namespace ModRyon.Core
{
    public enum ModRyonRpc : byte
    {
        SyncCustomRole = 150
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.HandleRpc))]
    public static class CustomRoleRpc
    {
        [HarmonyPostfix]
        public static void Postfix(
            PlayerControl __instance,
            [HarmonyArgument(0)] byte callId,
            [HarmonyArgument(1)] MessageReader reader)
        {
            if (callId != (byte)ModRyonRpc.SyncCustomRole)
                return;

            byte playerId = reader.ReadByte();
            CustomRole role = (CustomRole)reader.ReadByte();

            RoleManager.Assign(playerId, role);

            if (PlayerControl.LocalPlayer == null)
                return;

            if (PlayerControl.LocalPlayer.PlayerId != playerId)
                return;

            RoleDescriptionNotifier.Show(role);
        }

        public static void Send(byte playerId, CustomRole role)
        {
            if (AmongUsClient.Instance == null)
                return;

            if (!AmongUsClient.Instance.AmHost)
                return;

            if (PlayerControl.LocalPlayer == null)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(
                PlayerControl.LocalPlayer.NetId,
                (byte)ModRyonRpc.SyncCustomRole,
                SendOption.Reliable
            );

            writer.Write(playerId);
            writer.Write((byte)role);

            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
