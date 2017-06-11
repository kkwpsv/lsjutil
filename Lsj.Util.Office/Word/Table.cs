using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Drawing;

namespace Lsj.Util.Office.Word
{
    public class Table
    {
        private Microsoft.Office.Interop.Word.Table table;

        public Table(Microsoft.Office.Interop.Word.Table table)
        {
            this.table = table;
        }

        public void AddTableBorder(Color? insidecolor = null, Color? outsidecolor = null, eLineStyle? outsidelinestyle = eLineStyle.wdLineStyleSingle, eLineStyle? insidelinestyle = eLineStyle.wdLineStyleSingle)
        {
            var border = table.Borders;
            if (outsidelinestyle != null)
            {
                border.OutsideLineStyle = (WdLineStyle)outsidelinestyle;
            }
            if (insidelinestyle != null)
            {
                border.InsideLineStyle = (WdLineStyle)insidelinestyle;
            }
            if (insidecolor != null)
            {
                border.InsideColor = (WdColor)(insidecolor.Value.R + insidecolor.Value.G * 0x100 + insidecolor.Value.B * 0x10000);
            }
            if (outsidecolor != null)
            {
                border.OutsideColor = (WdColor)(outsidecolor.Value.R + outsidecolor.Value.G * 0x100 + outsidecolor.Value.B * 0x10000);
            }

        }
        public void SetRowStyle(int row, Color? backgroundcolor = null, Color? foregroundcolor = null, float? height = null, float? width = null, int? size = null, string fontname = null, eHorizontalAlignment? horizontalalignment = null, eVerticalAlignment? verticalalignment = null, Color? fontcolor = null, bool? bold = null, bool? italic = null, eUnderline? underline = null, eBuiltinStyle? style = null)
        {
            foreach (var cell in table.Rows[row].Cells)
            {
                SetCellStyle((Cell)cell, backgroundcolor, foregroundcolor, height, width, size, fontname, horizontalalignment, verticalalignment, fontcolor, bold, italic, underline, style);
            }
        }
        public void SetCellStyle(int row, int column, Color? backgroundcolor = null, Color? foregroundcolor = null, float? height = null, float? width = null, int? size = null, string fontname = null, eHorizontalAlignment? horizontalalignment = null, eVerticalAlignment? verticalalignment = null, Color? fontcolor = null, bool? bold = null, bool? italic = null, eUnderline? underline = null, eBuiltinStyle? style = null) => SetCellStyle(table.Cell(row, column), backgroundcolor, foregroundcolor, height, width, size, fontname, horizontalalignment, verticalalignment, fontcolor, bold, italic, underline, style);
        private void SetCellStyle(Cell cell, Color? backgroundcolor = null, Color? foregroundcolor = null, float? height = null, float? width = null, int? size = null, string fontname = null, eHorizontalAlignment? horizontalalignment = null, eVerticalAlignment? verticalalignment = null, Color? fontcolor = null, bool? bold = null, bool? italic = null, eUnderline? underline = null, eBuiltinStyle? style = null)
        {

            if (backgroundcolor != null)
            {
                cell.Shading.BackgroundPatternColor = (WdColor)(backgroundcolor.Value.R + backgroundcolor.Value.G * 0x100 + backgroundcolor.Value.B * 0x10000);
            }
            if (foregroundcolor != null)
            {
                cell.Shading.ForegroundPatternColor = (WdColor)(foregroundcolor.Value.R + foregroundcolor.Value.G * 0x100 + foregroundcolor.Value.B * 0x10000);
            }
            if (height != null)
            {
                cell.Height = (float)height;
            }
            if (width != null)
            {
                cell.Width = (float)width;
            }
            if (size != null)
            {
                cell.Range.Font.Size = size.Value;
            }
            if (fontname != null)
            {
                cell.Range.Font.Name = fontname;
            }
            if (horizontalalignment != null)
            {
                cell.Range.ParagraphFormat.Alignment = (WdParagraphAlignment)horizontalalignment.Value;
            }
            if (verticalalignment != null)
            {
                cell.VerticalAlignment = (WdCellVerticalAlignment)verticalalignment.Value;
            }
            if (fontcolor != null)
            {
                cell.Range.Font.Color = (WdColor)(fontcolor.Value.R + fontcolor.Value.G * 0x100 + fontcolor.Value.B * 0x10000);
            }
            if (bold != null)
            {
                if (bold.Value)
                {
                    cell.Range.Font.Bold = 1;
                }
                else
                {
                    cell.Range.Font.Bold = 0;
                }
            }
            if (italic != null)
            {
                if (italic.Value)
                {
                    cell.Range.Font.Italic = 1;
                }
                else
                {
                    cell.Range.Font.Italic = 0;
                }
            }
            if (underline != null)
            {
                cell.Range.Font.Underline = (WdUnderline)underline;
            }
            if (style != null)
            {
                cell.Range.set_Style(style);
            }


        }

        public void MergeCell(int row, int column, int mergerow, int mergecolumn)
        {
            var cell = table.Cell(row, column);
            cell.Merge(table.Cell(mergerow, mergecolumn));
        }

        public void SetTitle(string title)
        {
            table.Title = title;
        }

        public void CellText(int row, int column, string text, eParagraphAlignment? alignment = null)
        {
            table.Cell(row, column).Range.Text = text;
            if (alignment != null)
            {
                table.Cell(row, column).Range.ParagraphFormat.Alignment = (WdParagraphAlignment)alignment.Value;
            }
        }


    }
}
