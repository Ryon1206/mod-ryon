using System.Collections.Generic;
using UnityEngine;

namespace ModRyon.Core
{
    public static class TaskStartNotification
    {
        private static readonly HashSet<uint> ShownTasks = new();

        public static void Show(uint taskId)
        {
            if (!ShownTasks.Add(taskId))
                return;

            if (HudManager.Instance == null)
                return;

            Debug.Log($"[Mod-Ryon] タスク開始！ ID: {taskId}");

            HudManager.Instance.Notifier.AddItem(
                $"タスク開始！ ID: {taskId}",
                Color.white,
                false
            );
        }

        public static void Clear()
        {
            ShownTasks.Clear();
        }
    }
}
