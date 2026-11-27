namespace ModRyon.Core
{
    public static class RoleListNotifier
    {
        public static void Show()
        {
            if (PlayerControl.LocalPlayer == null)
                return;

            var hud = DestroyableSingleton<HudManager>.Instance;

            if (hud == null || hud.Chat == null)
                return;

            string message = RoleListFormatter.Create();

            if (string.IsNullOrWhiteSpace(message))
                return;

            hud.Chat.AddChat(
                PlayerControl.LocalPlayer,
                message
            );
        }
    }
}
