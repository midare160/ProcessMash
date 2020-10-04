using ProcessMash.Properties;

namespace ProcessMash.Extensions
{
    public static class SettingsExtensions
    {
        internal static void Save(this Settings settings, bool reload)
        {
            settings.Save();
            if (reload) settings.Reload();
        }
    }
}
