namespace ModRyon.Core
{
    public static class RoleListNotifier
    {
        public static void Show()
        {
            if (PlayerControl.LocalPlayer == null)
                return;

            if (DestroyableSingleton<HudManager>.Instance == null)
                return;

            string message = RoleListFormatter.Create();

            DestroyableSingleton<HudManager>
                .Instance.Chat.AddChat(
                    PlayerControl.LocalPlayer,
                    message
                );
        }
    }
}
