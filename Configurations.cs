using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ProcessMash
{
    public static class Configurations
    {
        #region Declarations
        private const string AppSettingsRegion = "appSettings";
        #endregion

        #region Properties
        public static readonly Configuration Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static int? Key
        {
            get
            {
                var key = ConfigurationManager.AppSettings[nameof(Key)];

                return string.IsNullOrEmpty(key) ? default(int?) : int.Parse(key);
            }

            set => SetValue(nameof(Key), value.ToString());
        }

        public static IEnumerable<int> Modifiers
        {
            get
            {
                var config = ConfigurationManager.AppSettings[nameof(Modifiers)];

                if (string.IsNullOrEmpty(config))
                {
                    yield break;
                }

                foreach (var key in config.Split(';'))
                {
                    yield return int.Parse(key);
                }
            }

            set => SetValue(nameof(Modifiers), string.Join(";", value));
        }

        public static bool MinimizeOnStartup
        {
            get
            {
                var config = ConfigurationManager.AppSettings[nameof(MinimizeOnStartup)];

                return Convert.ToBoolean(string.IsNullOrEmpty(config) ? default : int.Parse(config));
            }

            set => SetValue(nameof(MinimizeOnStartup), Convert.ToInt32(value).ToString());
        }
        #endregion

        #region Methods
        private static void SetValue(string keyName, string value)
        {
            if (Configuration.AppSettings.Settings[keyName] == null)
            {
                Configuration.AppSettings.Settings.Add(keyName, value);
            }
            else
            {
                Configuration.AppSettings.Settings[keyName].Value = value;
            }
        }

        public static void Save()
        {
            Configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(AppSettingsRegion);
        }

        public static void Reset() 
            => File.Delete(Configuration.FilePath);
        #endregion
    }
}
