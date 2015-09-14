using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{    /// <summary>
     /// app.config
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