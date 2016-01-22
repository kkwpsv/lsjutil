using System.Collections.Specialized;

namespace Lsj.Util.Config
{    /// <summary>
     /// AppConfig Helper
     /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Read AppSettingsSection
        /// </summary>
        /// <returns></returns>
        public static NameValueCollection AppSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings;
            }
        }
    }
}