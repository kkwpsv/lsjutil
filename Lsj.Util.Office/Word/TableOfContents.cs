using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Office.Word
{
    public class TableOfContents
    {
        private Microsoft.Office.Interop.Word.TableOfContents tableofcontents;

        internal TableOfContents(Microsoft.Office.Interop.Word.TableOfContents tableofcontents)
        {
            this.tableofcontents = tableofcontents;
        }

        public void Update()
        {
            tableofcontents.Update();
        }
        public void Select()
        {
            tableofcontents.Range.Select();
        }
    }
}
