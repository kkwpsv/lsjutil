using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// WinForm辅助类
    /// </summary>
    public class WebHelper
    {
     /// <summary>
     /// 读取web.config文件的AppSettingsSection数据
     /// </summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings;
            }
        }
    }
}
