using System;
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
        private readonly string path;

        /// <summary>
        /// Initialize a new instance of <see cref="Lsj.Util.Xml.XmlFile"/> class with a path
        /// </summary>
        /// <param name="path"></param>
        public XmlFile(string path)
        {
            this.path = path;
            try
            {
#if NETSTANDARD
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
        /// The Document
        /// </summary>
#if NETSTANDARD
        protected XDocument m_Document;
#else
        protected XmlDocument m_Document;
#endif

        /// <summary>
        /// Refresh
        /// </summary>
        public virtual void Refresh()
        {
            try
            {
#if NETSTANDARD
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
