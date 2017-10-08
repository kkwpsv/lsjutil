using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// Section
    /// </summary>
    public class Section
    {
        private Microsoft.Office.Interop.Word.Section section;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Office.Word.Section"/> class
        /// </summary>
        /// <param name="section"></param>
        public Section(Microsoft.Office.Interop.Word.Section section)
        {
            this.section = section;
        }
        /// <summary>
        /// AddPageNumberAtFooter
        /// </summary>
        public void AddPageNumberAtFooter()
        {
            var footer = section.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
            footer.LinkToPrevious = false;
            var x = footer.PageNumbers;

            x.RestartNumberingAtSection = true;
            x.StartingNumber = 1;
            x.Add(WdPageNumberAlignment.wdAlignPageNumberCenter);
        }
    }
}
