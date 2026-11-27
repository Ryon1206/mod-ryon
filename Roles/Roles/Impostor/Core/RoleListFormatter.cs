using System.Text;

namespace ModRyon.Core
{
    public static class RoleListFormatter
    {
        public static string Create()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("【Mod-Ryon 役職一覧】");

            foreach (RoleInfo info in RoleInfoManager.GetAll())
            {
                builder.AppendLine();
                builder.AppendLine($"■ {info.Name}");
                builder.AppendLine($"陣営：{info.Faction}");
                builder.AppendLine($"能力：{info.Description}");
            }

            return builder.ToString();
        }
    }
}
