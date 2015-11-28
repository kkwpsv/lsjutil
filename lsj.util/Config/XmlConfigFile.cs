using Lsj.Util.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Reflection;

namespace Lsj.Util.Config
{
    public class XmlConfigFile : XmlFile
    {
        public XmlConfigFile(string path) : base(path)
        {
            Refresh();
        }
        public override void Refresh()
        {
            base.Refresh();
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
        }

    }
}
