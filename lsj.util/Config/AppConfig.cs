using System.Collections.Specialized;

namespace Lsj.Util.Config
{    /// <summary>
     /// AppConfig辅助类
     /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 读取App.config中的AppSettingsSection
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