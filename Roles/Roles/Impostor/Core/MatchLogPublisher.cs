using Hazel;

namespace ModRyon.Core
{
    public static class MatchLogPublisher
    {
        private static int publishedCount = 0;

        public static void Reset()
        {
            publishedCount = 0;
        }

        public static void Publish()
        {
            if (AmongUsClient.Instance == null ||
                !AmongUsClient.Instance.AmHost)
                return;

            if (PlayerControl.LocalPlayer == null)
                return;

            while (publishedCount < MatchLog.All.Count)
            {
                string message = MatchLog.All[publishedCount];

                DestroyableSingleton<HudManager>
                    .Instance.Chat.AddChat(
                        PlayerControl.LocalPlayer,
                        message
                    );

                var writer =
                    AmongUsClient.Instance.StartRpcImmediately(
                        PlayerControl.LocalPlayer.NetId,
                        (byte)RpcCalls.SendChat,
                        SendOption.Reliable
                    );

                writer.Write(message);

                AmongUsClient.Instance.FinishRpcImmediately(writer);

                publishedCount++;
            }
        }
    }
}
