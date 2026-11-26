using System.Collections.Generic;

namespace ModRyon.Core
{
    public static class BatRuntimeState
    {
        private static readonly Dictionary<byte, float> PendingDeaths = new();
        private static readonly Dictionary<byte, float> GlowTimers = new();

        public static bool MarkTarget(byte targetId, int delay)
        {
            if (PendingDeaths.ContainsKey(targetId))
                return false;

            PendingDeaths[targetId] = delay;
            return true;
        }

        public static List<byte> TickDeaths(float deltaTime, bool meeting)
        {
            var expired = new List<byte>();

            if (meeting)
            {
                PendingDeaths.Clear();
                return expired;
            }

            var targets = new List<byte>(PendingDeaths.Keys);

            foreach (byte targetId in targets)
            {
                PendingDeaths[targetId] -= deltaTime;

                if (PendingDeaths[targetId] <= 0f)
                {
                    expired.Add(targetId);
                    PendingDeaths.Remove(targetId);
                }
            }

            return expired;
        }

        public static void StartGlow(byte playerId, int duration)
        {
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

            if (inVent)
                return expired;

            var players = new List<byte>(GlowTimers.Keys);

            foreach (byte playerId in players)
            {
                if (GlowTimers[playerId] < 0f)
                    continue;

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
            PendingDeaths.Clear();
            GlowTimers.Clear();
        }
    }
}
