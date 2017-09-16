using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Binary
{
    /// <summary>
    /// Binary File
    /// </summary>
    public class BaseBinaryFile
    {
        /// <summary>
        /// File Stream
        /// </summary>
        protected FileStream file;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Binary.BaseBinaryFile"/> class.
        /// </summary>
        /// <param name="path">File Path</param>
        public BaseBinaryFile(string path)
        {
            this.file = new FileStream(path, FileMode.Open, FileAccess.Read);
            Read();
        }
        /// <summary>
        /// Read
        /// </summary>
        protected virtual void Read()
        {

        }
    }
}
