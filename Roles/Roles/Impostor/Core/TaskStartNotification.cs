using UnityEngine;

namespace ModRyon.Core
{
    public static class TaskStartNotification
    {
        public static void Show(uint taskId)
        {
            if (HudManager.Instance == null)
                return;

            Debug.Log($"[Mod-Ryon] タスク開始！ ID: {taskId}");

            HudManager.Instance.Notifier.AddItem(
                $"タスク開始！ ID: {taskId}",
                Color.white,
                false
            );
        }
    }
}
