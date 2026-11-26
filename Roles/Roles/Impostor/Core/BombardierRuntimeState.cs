using System.Collections.Generic;

namespace ModRyon.Core
{
    public static class BombardierRuntimeState
    {
        private static readonly HashSet<uint> PlacedBombs = new();
        private static readonly Dictionary<byte, float> ActiveBombs = new();

        public static bool PlaceBomb(uint taskId)
        {
            return PlacedBombs.Add(taskId);
        }

        public static bool OnTaskStarted(
            uint taskId,
            byte playerId,
            int explosionTime)
        {
            if (!PlacedBombs.Remove(taskId))
                return false;

            if (ActiveBombs.ContainsKey(playerId))
                return false;

            ActiveBombs[playerId] = explosionTime;
            return true;
        }

        public static List<byte> Tick(float deltaTime)
        {
            var expired = new List<byte>();
            var players = new List<byte>(ActiveBombs.Keys);

            foreach (byte playerId in players)
            {
                ActiveBombs[playerId] -= deltaTime;

                if (ActiveBombs[playerId] <= 0f)
                {
                    expired.Add(playerId);
                    ActiveBombs.Remove(playerId);
                }
            }

            return expired;
        }

        public static bool HasBomb(byte playerId)
        {
            return ActiveBombs.ContainsKey(playerId);
        }

        public static void Clear()
        {
            PlacedBombs.Clear();
            ActiveBombs.Clear();
        }
    }
}
