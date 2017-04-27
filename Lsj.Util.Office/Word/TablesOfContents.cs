using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Office.Word
{
    public class TablesOfContents :IEnumerable<TableOfContents>
    {
        private Document doc;

        internal TablesOfContents(Document doc)
        {
            this.doc = doc;
        }
        public TableOfContents this[int index]
        {
            get
            {
                return new TableOfContents(doc.TablesOfContents[index + 1]);
            }
        }

        public IEnumerator<TableOfContents> GetEnumerator()
        {
            for (int i = 0; i < doc.Sections.Count; i++)
            {
                yield return new TableOfContents(doc.TablesOfContents[i + 1]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
