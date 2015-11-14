using Lsj.Util.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    var properties = this.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        if (property.PropertyType.IsAssignableFrom(typeof(ConfigElement)))
                        {
                            var element = config.SelectSingleNode(property.Name);
                            if(element!=null)
                            {
                                property.SetValue(this, new ConfigElement(element.InnerText), null);
                            }
                        }
                    }
                }
            }
        }

    }
}
