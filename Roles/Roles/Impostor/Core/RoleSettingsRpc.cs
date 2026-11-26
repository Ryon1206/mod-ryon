using HarmonyLib;
using Hazel;

namespace ModRyon.Core
{
    public enum RoleSettingsRpcId : byte
    {
        SyncSettings = 151
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.HandleRpc))]
    public static class RoleSettingsRpc
    {
        public static void Postfix(
            [HarmonyArgument(0)] byte callId,
            [HarmonyArgument(1)] MessageReader reader)
        {
            if (callId != (byte)RoleSettingsRpcId.SyncSettings)
                return;

            RoleSettings.BatCount = reader.ReadInt32();
            RoleSettings.BatDeathDelay = reader.ReadInt32();
            RoleSettings.BatGlowDuration = reader.ReadInt32();

            RoleSettings.BombardierCount = reader.ReadInt32();
            RoleSettings.BombardierBombCount = reader.ReadInt32();
            RoleSettings.BombardierExplosionTime = reader.ReadInt32();
        }

        public static void Send()
        {
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost ||
                PlayerControl.LocalPlayer == null)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(
                PlayerControl.LocalPlayer.NetId,
                (byte)RoleSettingsRpcId.SyncSettings,
                SendOption.Reliable
            );

            writer.Write(RoleSettings.BatCount);
            writer.Write(RoleSettings.BatDeathDelay);
            writer.Write(RoleSettings.BatGlowDuration);

            writer.Write(RoleSettings.BombardierCount);
            writer.Write(RoleSettings.BombardierBombCount);
            writer.Write(RoleSettings.BombardierExplosionTime);

            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
