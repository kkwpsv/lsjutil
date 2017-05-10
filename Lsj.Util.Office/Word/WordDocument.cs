using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop;
using Lsj.Util;
using System.Drawing;
using Microsoft.Office.Core;

namespace Lsj.Util.Office.Word
{
    public class WordDocument :DisposableClass, IDisposable
    {
        Application app;
        Document doc;
       

        public WordDocument()
        {
            app = new Application();
            doc = app.Documents.Add();
            app.Visible = true;
            this.Sections = new Sections(doc);
            this.TablesOfContents = new TablesOfContents(doc);
            this.Tables = new Tables(doc);
        }
        protected override void CleanUpUnmanagedResources()
        {
            app.Quit(true);
            base.CleanUpUnmanagedResources();
        }


        public Sections Sections
        {
            get;
        }
        public TablesOfContents TablesOfContents
        {
            get;
        }
        public Tables Tables
        {
            get;
        }

        public void SetDocPaper(WdPaperSize size)
        {
            doc.PageSetup.PaperSize = size;
        }
        public void SetDocMargin(float? left, float? right, float? top, float? bottom)
        {
            if (left != null)
            {
                doc.PageSetup.LeftMargin = left.Value;
            }
            if (right != null)
            {
                doc.PageSetup.RightMargin = right.Value;
            }
            if (top != null)
            {
                doc.PageSetup.TopMargin = top.Value;
            }
            if (bottom != null)
            {
                doc.PageSetup.BottomMargin = bottom.Value;
            }

        }




        public void SaveAs(string filename)
        {
            doc.SaveAs2(filename);
        }
        public void Close()
        {
            doc.Close(true);
        }


        public void AddPageNumberAtFooterForFirstSection()
        {
            this.Sections[0].AddPageNumberAtFooter();
        }

        public void AddTable(int rows,int columns)
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.InsertBreak(WdBreakType.wdLineBreak);
            selection.Tables.Add(selection.Range, rows, columns);
        }

        public void AddChart(XlChartType type)
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            var chart=selection.InlineShapes.AddChart2(Type:type).Chart;
            var chartdate=chart.ChartData;
            Microsoft.Office.Interop.Excel.Worksheet workbook= chart.ChartData.Workbook.Worksheets["Sheet1"];

            string[] names = { "公司A", "公司B", "公司C", "公司D", "公司E" }; // 数据名称
            double[] values = { 10.0, 32.5, 22.4, 34.1, 15.9 }; // 对应数据
            int count = names.Length;
            var data = new object[count, 2];
            string title = "市场份额-饼图";
            Enumerable.Range(0, count).ToList().ForEach(i => { data[i, 0] = names[i]; data[i, 1] = values[i]; });
            workbook.get_Range("A2", "B" + (count + 1)).Value = data;
            workbook.get_Range("B1").Value = title;

        }

        public void AppendBlankLine(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.AppendLine();
            }
        }
        public void AppendLine(string str = null) => Append(str + "\n");
        public void Append(string str)
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.TypeText(str);
        }
        public void AppendPage()
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.InsertBreak(WdBreakType.wdPageBreak);
            selection.Delete(WdUnits.wdCharacter, -1);
        }
        public void AppendSection()
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.InsertBreak(WdBreakType.wdSectionBreakNextPage);
        }
        public void AppendTableOfContents()
        {
            GoToEnd();
            var selection = app.Selection;
            doc.Fields.Add(selection.Range, WdFieldType.wdFieldTOC, @"", true);
        }

        public void SetAppendStyle(int? size = null, string fontname = null, eParagraphAlignment? alignment = null, Color? fontcolor = null, Color? backgroundcolor = null, Color? foregroundcolor = null, bool? bold = null, bool? italic = null, eUnderline? underline = null, eBuiltinStyle? style = null)
        {
            GoToEnd();
            SetSelectionStyle(size, fontname, alignment, fontcolor, backgroundcolor, foregroundcolor, bold, italic, underline, style);
        }


        public void SetSelectionStyle(int? size = null, string fontname = null, eParagraphAlignment? alignment = null, Color? fontcolor = null,Color? backgroundcolor=null, Color? foregroundcolor = null, bool? bold = null, bool? italic = null, eUnderline? underline = null, eBuiltinStyle? style = null)
        {
            var selection = app.Selection;
            if (style != null)
            {
                selection.set_Style(style);
            }
            if (size != null)
            {
                selection.Font.Size = size.Value;
            }
            if (fontname != null)
            {
                selection.Font.Name = fontname;
            }
            if (alignment != null)
            {
                selection.ParagraphFormat.Alignment = (WdParagraphAlignment)alignment.Value;
            }
            if (fontcolor != null)
            {
                selection.Font.Color = (WdColor)(fontcolor.Value.R + fontcolor.Value.G * 0x100 + fontcolor.Value.B * 0x10000);
            }
            if (backgroundcolor != null)
            {
                selection.ParagraphFormat.Shading.BackgroundPatternColor = (WdColor)(backgroundcolor.Value.R + backgroundcolor.Value.G * 0x100 + backgroundcolor.Value.B * 0x10000);
            }
            if(foregroundcolor!=null)
            {
                selection.ParagraphFormat.Shading.ForegroundPatternColor = (WdColor)(foregroundcolor.Value.R + foregroundcolor.Value.G * 0x100 + foregroundcolor.Value.B * 0x10000); 
            }
            if (bold != null)
            {
                if (bold.Value)
                {
                    selection.Font.Bold = 1;
                }
                else
                {
                    selection.Font.Bold = 0;
                }
            }
            if (italic != null)
            {
                if (italic.Value)
                {
                    selection.Font.Italic = 1;
                }
                else
                {
                    selection.Font.Italic = 0;
                }
            }
            if (underline != null)
            {
                selection.Font.Underline = (WdUnderline)underline;
            }
            
        }

        public void UpdateAllTableOfContents()
        {
            foreach (var a in this.TablesOfContents)
            {
                a.Update();
            }
        }



        public float InchesToPoints(double inch) => app.InchesToPoints((float)inch);
        public float MillimetersToPoints(double mm) => app.MillimetersToPoints((float)mm);

        public void GoToEnd()
        {
            var selection = app.Selection;
            selection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToLast);
            while (selection.MoveRight(WdUnits.wdCharacter) == 1)
            {
            }

        }

    }
}
