using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// TableOfContents
    /// </summary>
    public class TableOfContents
    {
        private Microsoft.Office.Interop.Word.TableOfContents tableofcontents;

        internal TableOfContents(Microsoft.Office.Interop.Word.TableOfContents tableofcontents)
        {
            this.tableofcontents = tableofcontents;
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            tableofcontents.Update();
        }
        /// <summary>
        /// Select
        /// </summary>
        public void Select()
        {
            tableofcontents.Range.Select();
        }
    }
}
