using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Lsj.Util.Xml;
using Lsj.Util.Reflection;
using Lsj.Util.Text;





namespace Lsj.Util.Config

{
    /// <summary>
    /// XML Confg File
    /// </summary>
    public class XmlConfigFile : XmlFile
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="Lsj.Util.Config.XmlConfigFile"/> class with a path
        /// </summary>
        /// <param name="path"></param>
        public XmlConfigFile(string path) : base(path)
        {
            Refresh();
        }
        /// <summary>
        /// Refresh
        /// </summary>
        public sealed override void Refresh()
        {
            base.Refresh();
#if NETCOREAPP2_0
            if (m_Document.Elements().Count() > 0)
            {
                var config = m_Document.Elements().Where(x => x.Name == "config").FirstOrDefault();
                if (config != null && config.Elements().Count() > 0)
                {
                    var fields = this.GetType().GetAllNonPublicField();
                    foreach (var field in fields)
                    {
                        if (field.FieldType.IsAssignableFrom(typeof(ConfigElement)))
                        {
                            var attribute = field.GetAttribute<ConfigElementNameAttribute>();
                            if (attribute != null)
                            {
                                var name = attribute.Name.ToSafeString();
                                if (name != "")
                                {
                                    var element = config.Elements().Where(x => x.Name == name).FirstOrDefault();
                                    if (element != null)
                                    {
                                        field.SetValue(this, new ConfigElement(element.Value));
                                    }
                                }
                            }
                        }
                    }
                }
            }
#else
            if (m_Document.HasChildNodes)
            {
                var config = m_Document.DocumentElement.SelectSingleNode("/config");
                if (config != null && config.HasChildNodes)
                {
                    var fields = this.GetType().GetAllNonPublicField();
                    foreach (var field in fields)
                    {
                        if (field.FieldType.IsAssignableFrom(typeof(ConfigElement)))
                        {
                            var attribute = field.GetAttribute<ConfigElementNameAttribute>();
                            if (attribute != null)
                            {
                                var name = attribute.Name.ToSafeString();
                                if (name != "")
                                {
                                    var element = config.SelectSingleNode(name);
                                    if (element != null)
                                    {
                                        field.SetValue(this, new ConfigElement(element.InnerText));
                                    }
                                }
                            }
                        }
                    }
                }
            }
#endif
        }
    }
}
