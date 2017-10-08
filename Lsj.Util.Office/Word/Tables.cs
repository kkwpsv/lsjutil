using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// Tables
    /// </summary>
    public class Tables : IEnumerable<Table>
    {
        private Document doc;

        internal Tables(Document doc)
        {
            this.doc = doc;
        }
        /// <summary>
        /// Get Table by specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Table this[int index]
        {
            get
            {
                return new Table(doc.Tables[index + 1]);
            }
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Table> GetEnumerator()
        {
            for (int i = 0; i < doc.Tables.Count; i++)
            {
                yield return new Table(doc.Tables[i + 1]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
