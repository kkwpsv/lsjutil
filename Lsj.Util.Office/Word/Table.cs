using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Drawing;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// Table
    /// </summary>
    public class Table
    {
        private Microsoft.Office.Interop.Word.Table table;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Office.Word.Table"/> class
        /// </summary>
        /// <param name="table"></param>
        public Table(Microsoft.Office.Interop.Word.Table table)
        {
            this.table = table;
        }
        /// <summary>
        /// Add Table Border
        /// </summary>
        /// <param name="insideColor"></param>
        /// <param name="outsideColor"></param>
        /// <param name="outsideLineStyle"></param>
        /// <param name="insideLineStyle"></param>
        public void AddTableBorder(Color? insideColor = null, Color? outsideColor = null, LineStyle? outsideLineStyle = LineStyle.wdLineStyleSingle, LineStyle? insideLineStyle = LineStyle.wdLineStyleSingle)
        {
            var border = table.Borders;
            if (outsideLineStyle != null)
            {
                border.OutsideLineStyle = (WdLineStyle)outsideLineStyle;
            }
            if (insideLineStyle != null)
            {
                border.InsideLineStyle = (WdLineStyle)insideLineStyle;
            }
            if (insideColor != null)
            {
                border.InsideColor = (WdColor)(insideColor.Value.R + insideColor.Value.G * 0x100 + insideColor.Value.B * 0x10000);
            }
            if (outsideColor != null)
            {
                border.OutsideColor = (WdColor)(outsideColor.Value.R + outsideColor.Value.G * 0x100 + outsideColor.Value.B * 0x10000);
            }

        }
        /// <summary>
        /// Set Row Style
        /// </summary>
        /// <param name="row"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="size"></param>
        /// <param name="fontName"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        /// <param name="fontColor"></param>
        /// <param name="bold"></param>
        /// <param name="italic"></param>
        /// <param name="underline"></param>
        /// <param name="style"></param>
        public void SetRowStyle(int row, Color? backgroundColor = null, Color? foregroundColor = null, float? height = null, float? width = null, int? size = null, string fontName = null, HorizontalAlignment? horizontalAlignment = null, VerticalAlignment? verticalAlignment = null, Color? fontColor = null, bool? bold = null, bool? italic = null, Underline? underline = null, BuiltinStyle? style = null)
        {
            foreach (var cell in table.Rows[row].Cells)
            {
                SetCellStyle((Cell)cell, backgroundColor, foregroundColor, height, width, size, fontName, horizontalAlignment, verticalAlignment, fontColor, bold, italic, underline, style);
            }
        }
        /// <summary>
        /// Set Cell Style
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="size"></param>
        /// <param name="fontname"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        /// <param name="fontColor"></param>
        /// <param name="bold"></param>
        /// <param name="italic"></param>
        /// <param name="underline"></param>
        /// <param name="style"></param>
        public void SetCellStyle(int row, int column, Color? backgroundColor = null, Color? foregroundColor = null, float? height = null, float? width = null, int? size = null, string fontname = null, HorizontalAlignment? horizontalAlignment = null, VerticalAlignment? verticalAlignment = null, Color? fontColor = null, bool? bold = null, bool? italic = null, Underline? underline = null, BuiltinStyle? style = null) => SetCellStyle(table.Cell(row, column), backgroundColor, foregroundColor, height, width, size, fontname, horizontalAlignment, verticalAlignment, fontColor, bold, italic, underline, style);
        private void SetCellStyle(Cell cell, Color? backgroundcolor = null, Color? foregroundcolor = null, float? height = null, float? width = null, int? size = null, string fontname = null, HorizontalAlignment? horizontalalignment = null, VerticalAlignment? verticalalignment = null, Color? fontcolor = null, bool? bold = null, bool? italic = null, Underline? underline = null, BuiltinStyle? style = null)
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
        /// <summary>
        /// Merge Cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="mergeRow"></param>
        /// <param name="mergeColumn"></param>
        public void MergeCell(int row, int column, int mergeRow, int mergeColumn)
        {
            var cell = table.Cell(row, column);
            cell.Merge(table.Cell(mergeRow, mergeColumn));
        }
        /// <summary>
        /// Set Title
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            table.Title = title;
        }
        /// <summary>
        /// Cell Text
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="text"></param>
        /// <param name="alignment"></param>
        public void CellText(int row, int column, string text, ParagraphAlignment? alignment = null)
        {
            table.Cell(row, column).Range.Text = text;
            if (alignment != null)
            {
                table.Cell(row, column).Range.ParagraphFormat.Alignment = (WdParagraphAlignment)alignment.Value;
            }
        }
        /// <summary>
        /// Auto Fit Wieth
        /// </summary>
        public void AutoFitWidth()
        {
            table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
        }

    }
}
