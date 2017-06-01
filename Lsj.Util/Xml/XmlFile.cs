using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Lsj.Util.Logs;



namespace Lsj.Util.Xml
{
    /// <summary>
    /// XML File
    /// </summary>
    public class XmlFile
    {
        /// <summary>
        /// Initialize a new instance with a path
        /// </summary>
        /// <param name="path"></param>
        public XmlFile(string path)
        {
            this.path = path;
            try
            {
#if NETCOREAPP1_1
                this.m_Document = XDocument.Load(path);
#else
                this.m_Document = new XmlDocument();
                m_Document.Load(path);
#endif
            }
            catch (Exception e)
            {
                LogProvider.Default.Error("Error to Load XmlFile", e);
            }
        }

        /// <summary>
        /// The document.
        /// </summary>
#if NETCOREAPP1_1
        protected XDocument m_Document;
#else
        protected XmlDocument m_Document;
#endif


        private readonly string path;
        /// <summary>
        /// Refresh file
        /// </summary>
        public virtual void Refresh()
        {
            try
            {
#if NETCOREAPP1_1
                this.m_Document = XDocument.Load(path);
#else
                m_Document.Load(path);
#endif
            }
            catch (Exception e)
            {
                LogProvider.Default.Error("Error to Load XmlFile", e);
            }
        }

    }
}
