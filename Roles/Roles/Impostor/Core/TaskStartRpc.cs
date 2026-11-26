using HarmonyLib;
using Hazel;

namespace ModRyon.Core
{
    public enum TaskStartRpcId : byte
    {
        TaskStarted = 152
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.HandleRpc))]
    public static class TaskStartRpc
    {
        public static void Postfix(
            [HarmonyArgument(0)] byte callId,
            [HarmonyArgument(1)] MessageReader reader)
        {
            if (callId != (byte)TaskStartRpcId.TaskStarted)
                return;

            uint taskId = reader.ReadUInt32();
            byte playerId = reader.ReadByte();

            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost)
                return;

            BombardierRuntimeState.OnTaskStarted(
                taskId,
                playerId,
                RoleSettings.BombardierExplosionTime
            );
        }

        public static void Send(uint taskId, byte playerId)
        {
            if (AmongUsClient.Instance == null ||
                PlayerControl.LocalPlayer == null)
                return;

            if (AmongUsClient.Instance.AmHost)
            {
                BombardierRuntimeState.OnTaskStarted(
                    taskId,
                    playerId,
                    RoleSettings.BombardierExplosionTime
                );
                return;
            }

            var writer = AmongUsClient.Instance.StartRpcImmediately(
                PlayerControl.LocalPlayer.NetId,
                (byte)TaskStartRpcId.TaskStarted,
                SendOption.Reliable
            );

            writer.Write(taskId);
            writer.Write(playerId);

            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
