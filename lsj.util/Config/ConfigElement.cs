using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{
    /// <summary>
    /// 配置元素
    /// </summary>
    public class ConfigElement
    {
        string value;

        /// <summary>
        /// 初始化一个<see cref="ConfigElement"/> 
        /// </summary>
        public ConfigElement()
        {
        }
        /// <summary>
        /// 初始化一个<see cref="ConfigElement"/> 
        /// </summary>
        /// <param name="value">值</param>
        public ConfigElement(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value => value.ToSafeString();
        /// <summary>
        /// 返回<see cref="string"/>数组
        /// </summary>
        public string[] StringArrayValue => Value.Split(',');
        /// <summary>
        /// 返回<see cref="bool"/>值
        /// </summary>
        public bool BoolValue => Value == "True";
        /// <summary>
        /// 返回<see cref="int"/>值
        /// </summary>
        public int IntValue => Value.ConvertToInt(0);



        /// <summary>
        /// NullConfigElemnet
        /// </summary>
        public static ConfigElement Null = new ConfigElement("");
    }
}
