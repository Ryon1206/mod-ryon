using System.Collections.Generic;

namespace ModRyon.Core
{
    public static class BatRuntimeState
    {
        private static readonly Dictionary<byte, float> GlowTimers = new();

        public static void StartGlow(byte playerId, float duration)
        {
            if (duration <= 0f)
                return;

            GlowTimers[playerId] = duration;
        }

        public static List<byte> TickGlow(
            float deltaTime,
            bool inVent,
            bool meeting)
        {
            var expired = new List<byte>();

            if (meeting)
            {
                GlowTimers.Clear();
                return expired;
            }

            if (inVent || deltaTime <= 0f)
                return expired;

            var players = new List<byte>(GlowTimers.Keys);

            foreach (byte playerId in players)
            {
                GlowTimers[playerId] -= deltaTime;

                if (GlowTimers[playerId] <= 0f)
                {
                    expired.Add(playerId);
                    GlowTimers.Remove(playerId);
                }
            }

            return expired;
        }

        public static bool IsGlowing(byte playerId)
        {
            return GlowTimers.ContainsKey(playerId);
        }

        public static void Clear()
        {
            GlowTimers.Clear();
        }
    }
}
