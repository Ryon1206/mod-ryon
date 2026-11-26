namespace ModRyon.Core
{
    public static class RoleDescriptionFormatter
    {
        public static string Create(CustomRole role)
        {
            RoleInfo info = RoleInfoManager.Get(role);

            if (info == null)
                return "役職情報がありません。";

            return
                $"【{info.Name}】\n" +
                $"陣営：{info.Faction}\n" +
                $"{info.FlavorText}";
        }
    }
}
