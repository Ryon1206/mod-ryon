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
        [HarmonyPostfix]
        public static void Postfix(
            [HarmonyArgument(0)] byte callId,
            [HarmonyArgument(1)] MessageReader reader)
        {
            if (callId != (byte)TaskStartRpcId.TaskStarted)
                return;

            uint taskId = reader.ReadUInt32();

            TaskStartNotification.Show(taskId);
        }

        public static void Send(uint taskId)
        {
            if (AmongUsClient.Instance == null ||
                PlayerControl.LocalPlayer == null)
                return;

            if (AmongUsClient.Instance.AmHost)
            {
                TaskStartNotification.Show(taskId);
                return;
            }

            var writer = AmongUsClient.Instance.StartRpcImmediately(
                PlayerControl.LocalPlayer.NetId,
                (byte)TaskStartRpcId.TaskStarted,
                SendOption.Reliable
            );

            writer.Write(taskId);

            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
