using System.Collections.Specialized;

namespace Lsj.Util.Config
{    /// <summary>
     /// AppConfig������
     /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// ��ȡApp.config�е�AppSettingsSection
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