using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Office.Word
{
    public class Charts : IEnumerable<Chart>
    {
        private Document doc;
        internal Charts(Document doc)
        {
            this.doc = doc;
        }
        public Chart this[int index]
        {
            get
            {
                return new Chart(doc.InlineShapes[index+1]);
            }
        }
        public IEnumerator<Chart> GetEnumerator()
        {
            for (int i = 0; i < doc.InlineShapes.Count; i++)
            {
                yield return new Chart(doc.InlineShapes[i + 1]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
