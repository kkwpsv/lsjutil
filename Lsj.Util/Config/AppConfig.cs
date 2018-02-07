using System.Collections.Specialized;

#if NETCOREAPP2_0
#else
namespace Lsj.Util.Config
{
    /// <summary>
    /// AppConfig
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// AppSettings
        /// </summary>
        /// <value>The app settings.</value>
        public static NameValueCollection AppSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings;
            }
        }
    }
}
#endif