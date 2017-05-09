using Lsj.Util.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
                this.m_Document = new XmlDocument();
                m_Document.Load(path);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error("Error to Load XmlFile", e);
            }
        }
        /// <summary>
        /// The m document.
        /// </summary>
        protected XmlDocument m_Document;
        private readonly string path;
        /// <summary>
        /// Refresh file
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
