using UnityEngine;

namespace ModRyon.Core
{
    public static class TaskStartNotification
    {
        public static void Show(uint taskId)
        {
            Debug.Log($"[Mod-Ryon] タスク開始！ ID: {taskId}");
        }
    }
}
