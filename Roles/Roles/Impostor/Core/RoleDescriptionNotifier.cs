namespace ModRyon.Core
{
    public static class RoleDescriptionNotifier
    {
        public static void Show(CustomRole role)
        {
            if (PlayerControl.LocalPlayer == null)
                return;

            string message = RoleDescriptionFormatter.Create(role);

            DestroyableSingleton<HudManager>
                .Instance.Chat.AddChat(
                    PlayerControl.LocalPlayer,
                    message
                );
        }
    }
}
