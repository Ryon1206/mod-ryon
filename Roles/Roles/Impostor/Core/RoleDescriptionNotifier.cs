namespace ModRyon.Core
{
    public static class RoleDescriptionNotifier
    {
        public static void Show(CustomRole role)
        {
            if (PlayerControl.LocalPlayer == null)
                return;

            var hud = DestroyableSingleton<HudManager>.Instance;

            if (hud == null || hud.Chat == null)
                return;

            string message = RoleDescriptionFormatter.Create(role);

            if (string.IsNullOrWhiteSpace(message))
                return;

            hud.Chat.AddChat(
                PlayerControl.LocalPlayer,
                message
            );
        }
    }
}
