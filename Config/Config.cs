using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{    /// <summary>
     /// app.config配置文件读取类
     /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 读取app.config文件的AppSettingsSection数据
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
