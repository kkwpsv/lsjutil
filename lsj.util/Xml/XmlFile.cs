using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Lsj.Util.Xml
{
    public class XmlFile
    {
        public XmlFile(string path)
        {
            this.path = path;
            this.m_Document = new XmlDocument();
            try
            {
                m_Document.Load(path);
            }
            catch(Exception e)
            {
                Log.Log.Default.Error("Error to Load XmlFile", e);
            }
        }
        protected XmlDocument m_Document;
        private string path;

        public virtual void Refresh()
        {
            try
            {
                m_Document.Load(path);
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Error to Load XmlFile", e);
            }
        }

    }
}
