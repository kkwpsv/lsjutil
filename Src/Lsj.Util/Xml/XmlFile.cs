using System;
using System.Xml;
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
                this.m_Document = new XmlDocument();
                m_Document.Load(path);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error("Error to Load XmlFile", e);
            }
        }

        /// <summary>
        /// The Document
        /// </summary>
        protected XmlDocument m_Document;

        /// <summary>
        /// Refresh
        /// </summary>
        public virtual void Refresh()
        {
            try
            {
                m_Document.Load(path);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error("Error to Load XmlFile", e);
            }
        }
    }
}
