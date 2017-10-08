using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// Charts
    /// </summary>
    public class Charts : IEnumerable<Chart>
    {
        private Document doc;
        internal Charts(Document doc)
        {
            this.doc = doc;
        }
        /// <summary>
        /// Get Chart with specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chart this[int index]
        {
            get
            {
                return this.Skip(index - 1)?.First() ?? throw new IndexOutOfRangeException();
            }
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Chart> GetEnumerator()
        {
            for (int i = 0; i < doc.Shapes.Count; i++)
            {
                var result = doc.Shapes[i + 1];
                if (result.HasChart == MsoTriState.msoTrue)
                {
                    yield return new Chart(result.Chart);
                }
            }
            for (int i = 0; i < doc.InlineShapes.Count; i++)
            {
                var result = doc.InlineShapes[i + 1];
                if (result.HasChart == MsoTriState.msoTrue)
                {
                    yield return new Chart(result.Chart);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
