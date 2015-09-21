using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Lsj.Util.Config;

namespace Lsj.Util
{
    /// <summary>
    /// WebHelper
    /// </summary>
    public class WebHelper
    {
     /// <summary>
     /// Read AppSettingsSection in Web.config
     /// </summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                return AppConfig.AppSettings;
            }
        }
    }
}