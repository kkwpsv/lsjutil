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
    /// <summary>
    /// Word Documnet
    /// </summary>
    public class WordDocument : DisposableClass, IDisposable
    {
        Application app;
        Document doc;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Office.Word.WordDocument"/> class
        /// </summary>
        public WordDocument() : this(new Application())
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Office.Word.WordDocument"/> class
        /// </summary>
        /// <param name="filename"></param>
        public WordDocument(string filename) : this(new Application(), filename)
        {
        }
        private WordDocument(Application app) : this(app, app.Documents.Add())
        {

        }
        private WordDocument(Application app, string filename) : this(app, app.Documents.Open(filename))
        {
        }
        private WordDocument(Application app, Document doc)
        {
            this.app = app;
            this.doc = doc;
            this.app.Visible = true;
            this.Sections = new Sections(doc);
            this.TablesOfContents = new TablesOfContents(doc);
            this.Tables = new Tables(doc);
            this.Charts = new Charts(doc);
        }
        /// <summary>
        /// CleanUp Unmanaged Resources()
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            doc.Close(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            doc = null;
            app.Quit(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            base.CleanUpUnmanagedResources();
        }

        /// <summary>
        /// Sections
        /// </summary>
        public Sections Sections
        {
            get;
        }
        /// <summary>
        /// TablesOfContents
        /// </summary>
        public TablesOfContents TablesOfContents
        {
            get;
        }
        /// <summary>
        /// Tables
        /// </summary>
        public Tables Tables
        {
            get;
        }
        /// <summary>
        /// Charts
        /// </summary>
        public Charts Charts
        {
            get;
        }
        /// <summary>
        /// SetVisible
        /// </summary>
        /// <param name="isVisible"></param>
        public void SetVisible(bool isVisible)
        {
            app.Visible = isVisible;
        }
        /// <summary>
        /// Set Spell Check
        /// </summary>
        /// <param name="isOpen"></param>
        public void SetSpellCheck(bool isOpen)
        {
            if (!isOpen)
            {
                doc.SpellingChecked = false;
                doc.ShowSpellingErrors = false;
            }
            else
            {
                doc.SpellingChecked = true;
                doc.ShowSpellingErrors = true;
            }
        }
        /// <summary>
        /// Set Doc Paper
        /// </summary>
        /// <param name="size"></param>
        public void SetDocPaper(PaperSize size)
        {
            doc.PageSetup.PaperSize = (WdPaperSize)size;
        }
        /// <summary>
        /// Set Doc Margin
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
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



        /// <summary>
        /// Save as
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAs(string filename)
        {
            doc.SaveAs2(filename);
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close()
        {
            doc.Close(true);
        }

        /// <summary>
        /// Add PageNumber At Footer For FirstSection
        /// </summary>
        public void AddPageNumberAtFooterForFirstSection()
        {
            this.Sections[0].AddPageNumberAtFooter();
        }
        /// <summary>
        /// Add Table
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public Table AddTable(int rows, int columns)
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.InsertBreak(WdBreakType.wdLineBreak);
            return new Table(selection.Tables.Add(selection.Range, rows, columns));
        }
        /// <summary>
        /// Add Chart
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isInline"></param>
        /// <returns></returns>
        public Chart AddChart(ChartType type, bool isInline = true)
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            Microsoft.Office.Interop.Word.Chart chart;
            if (isInline)
            {
                chart = selection.InlineShapes.AddChart2(Type: (XlChartType)type).Chart;
            }
            else
            {
                chart = doc.Shapes.AddChart2(Type: (XlChartType)type).Chart;
            }

            return new Chart(chart);
        }
        /// <summary>
        /// Append BlankLine
        /// </summary>
        /// <param name="count"></param>
        public void AppendBlankLine(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.AppendLine();
            }
        }
        /// <summary>
        /// Append Line
        /// </summary>
        /// <param name="str"></param>
        public void AppendLine(string str = null) => Append(str + "\n");
        /// <summary>
        /// Append
        /// </summary>
        /// <param name="str"></param>
        public void Append(string str)
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.TypeText(str);
        }
        /// <summary>
        /// Append Page
        /// </summary>
        public void AppendPage()
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.InsertBreak(WdBreakType.wdPageBreak);
        }
        /// <summary>
        /// Append Section
        /// </summary>
        public void AppendSection()
        {
            app.Options.ReplaceSelection = false;
            GoToEnd();
            var selection = app.Selection;
            selection.InsertBreak(WdBreakType.wdSectionBreakNextPage);
        }
        /// <summary>
        /// Append TableOfContents
        /// </summary>
        public void AppendTableOfContents()
        {
            GoToEnd();
            var selection = app.Selection;
            doc.Fields.Add(selection.Range, WdFieldType.wdFieldTOC, @"", true);
        }

        /// <summary>
        /// SetAppendStyle
        /// </summary>
        /// <param name="size"></param>
        /// <param name="fontName"></param>
        /// <param name="alignment"></param>
        /// <param name="fontColor"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="bold"></param>
        /// <param name="italic"></param>
        /// <param name="underline"></param>
        /// <param name="style"></param>
        /// <param name="firstLineIndentCharacter"></param>
        public void SetAppendStyle(int? size = null, string fontName = null, ParagraphAlignment? alignment = null, Color? fontColor = null, Color? backgroundColor = null, Color? foregroundColor = null, bool? bold = null, bool? italic = null, Underline? underline = null, BuiltinStyle? style = null, float? firstLineIndentCharacter = null)
        {
            GoToEnd();
            SetSelectionStyle(size, fontName, alignment, fontColor, backgroundColor, foregroundColor, bold, italic, underline, style, firstLineIndentCharacter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="fontName"></param>
        /// <param name="alignment"></param>
        /// <param name="fontcolor"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="bold"></param>
        /// <param name="italic"></param>
        /// <param name="underline"></param>
        /// <param name="style"></param>
        /// <param name="firstLineIndentCharacter"></param>
        public void SetSelectionStyle(int? size = null, string fontName = null, ParagraphAlignment? alignment = null, Color? fontcolor = null, Color? backgroundColor = null, Color? foregroundColor = null, bool? bold = null, bool? italic = null, Underline? underline = null, BuiltinStyle? style = null, float? firstLineIndentCharacter = null)
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
            if (fontName != null)
            {
                selection.Font.Name = fontName;
            }
            if (alignment != null)
            {
                selection.ParagraphFormat.Alignment = (WdParagraphAlignment)alignment.Value;
            }
            if (fontcolor != null)
            {
                selection.Font.Color = (WdColor)(fontcolor.Value.R + fontcolor.Value.G * 0x100 + fontcolor.Value.B * 0x10000);
            }
            if (backgroundColor != null)
            {
                selection.ParagraphFormat.Shading.BackgroundPatternColor = (WdColor)(backgroundColor.Value.R + backgroundColor.Value.G * 0x100 + backgroundColor.Value.B * 0x10000);
            }
            if (foregroundColor != null)
            {
                selection.ParagraphFormat.Shading.ForegroundPatternColor = (WdColor)(foregroundColor.Value.R + foregroundColor.Value.G * 0x100 + foregroundColor.Value.B * 0x10000);
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
            if (firstLineIndentCharacter != null)
            {
                selection.ParagraphFormat.CharacterUnitFirstLineIndent = firstLineIndentCharacter.Value;
            }

        }
        /// <summary>
        /// CopyAllContent
        /// </summary>
        public void CopyAllContent()
        {
            doc.Content.Copy();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Paste()
        {
            GoToEnd();
            var selection = app.Selection;
            selection.Paste();
        }
        /// <summary>
        /// Paste With Original Format
        /// </summary>
        public void PasteWithOriginalFormat()
        {
            GoToEnd();
            var selection = app.Selection;
            selection.PasteAndFormat(WdRecoveryType.wdFormatOriginalFormatting);
        }
        /// <summary>
        /// Paste With Style
        /// </summary>
        public void PasteWithStyle()
        {
            GoToEnd();
            var selection = app.Selection;
            selection.PasteAndFormat(WdRecoveryType.wdUseDestinationStylesRecovery);
        }

        /// <summary>
        /// Update All TableOfContents
        /// </summary>
        public void UpdateAllTableOfContents()
        {
            foreach (var a in this.TablesOfContents)
            {
                a.Update();
            }
        }






        /// <summary>
        /// Inches To Points
        /// </summary>
        /// <param name="inch"></param>
        /// <returns></returns>
        public float InchesToPoints(double inch) => app.InchesToPoints((float)inch);
        /// <summary>
        /// Millimeters To Points
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public float MillimetersToPoints(double mm) => app.MillimetersToPoints((float)mm);
        /// <summary>
        /// Go To End
        /// </summary>
        public void GoToEnd()
        {
            var selection = app.Selection;
            selection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToLast);
            while (selection.MoveRight(WdUnits.wdCharacter) == 1) ;
        }
    }
}
