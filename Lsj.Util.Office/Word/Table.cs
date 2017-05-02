using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Office.Word
{
    public class Table
    {
        private Microsoft.Office.Interop.Word.Table table;

        public Table(Microsoft.Office.Interop.Word.Table table)
        {
            this.table = table;
        }

        public void AddTableBorder()
        {
            var border = table.Borders;
            border.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            border.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            
        }

        public void MergeCell(int row,int column,int mergerow,int mergecolumn)
        {
            var cell = table.Cell(row,column);
            cell.Merge(table.Cell(mergerow, mergecolumn));
        }

    }
}
