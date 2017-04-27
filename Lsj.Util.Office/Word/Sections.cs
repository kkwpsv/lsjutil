using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Office.Word
{
    public class Sections :IEnumerable<Section>
    {
        private Document doc;

        internal Sections(Document doc)
        {
            this.doc = doc;
        }
        public Section this[int index]
        {
            get
            {
                return new Section(doc.Sections[index + 1]);
            }
        }

        public IEnumerator<Section> GetEnumerator()
        {
            for (int i = 0; i < doc.Sections.Count; i++)
            {
                yield return new Section(doc.Sections[i + 1]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
