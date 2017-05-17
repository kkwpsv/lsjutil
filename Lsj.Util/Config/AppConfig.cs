using System.Collections.Specialized;

#if NETCOREAPP1_1
#else
namespace Lsj.Util.Config
{
    /// <summary>
    /// App config.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets the app settings.
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