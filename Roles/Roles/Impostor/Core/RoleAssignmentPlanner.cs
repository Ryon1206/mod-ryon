using System;
using System.Collections.Generic;

namespace ModRyon.Core
{
    public static class RoleAssignmentPlanner
    {
        public static Dictionary<byte, CustomRole> CreateAssignments(
            IList<byte> impostorPlayerIds)
        {
            var result = new Dictionary<byte, CustomRole>();

            if (impostorPlayerIds == null ||
                impostorPlayerIds.Count == 0)
                return result;

            var candidates = new List<byte>(impostorPlayerIds);
            var random = new Random();

            // 抽選順をランダムにする
            for (int i = candidates.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                byte temp = candidates[i];
                candidates[i] = candidates[j];
                candidates[j] = temp;
            }

            int index = 0;

            // こうもりを抽選
            for (int i = 0;
                 i < RoleSettings.BatCount &&
                 index < candidates.Count;
                 i++)
            {
                result[candidates[index++]] = CustomRole.Bat;
            }

            // 爆弾魔を抽選
            for (int i = 0;
                 i < RoleSettings.BombardierCount &&
                 index < candidates.Count;
                 i++)
            {
                result[candidates[index++]] = CustomRole.Bombardier;
            }

            return result;
        }
    }
}
