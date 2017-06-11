﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lsj.Util.Office.Word;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;

namespace Lsj.Util.Debugger
{
    class Program
    {
        public static void Main()
        {
            //	IntPtr a = Marshal.AllocHGlobal(1000000000);
            //	Console.ReadLine();
            //using (var doc = new WordDocument())
            //{
            //   doc.SetDocPaper(WdPaperSize.wdPaperA4);
            //    doc.SetDocMargin(doc.MillimetersToPoints(38.1), doc.MillimetersToPoints(31.9), doc.MillimetersToPoints(27), doc.MillimetersToPoints(19.4));
            //    doc.SetAppendStyle(size: 28, alignment: eParagraphAlignment.Center);
            //    doc.AppendLine();
            //    doc.AppendLine();

            //    doc.SetAppendStyle(size: 22, fontname: "华文中宋", alignment: eParagraphAlignment.Center, fontcolor: Color.FromArgb(68, 84, 106));
            //    doc.AppendLine("中小学生学业诊断分析系统");
            //    doc.AppendLine("学业支持子系统个体测评报告");

            //    doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Center);
            //    doc.AppendBlankLine(9);

            //    doc.SetAppendStyle(size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, underline: eUnderline.Single);
            //    doc.AppendLine("学校： 	远东仁民");

            //    doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Center);
            //    doc.AppendLine();

            //    doc.SetAppendStyle(size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, underline: eUnderline.Single);
            //    doc.AppendLine("姓名： 	  李端沐");
            //    doc.AppendPage();

            //    doc.SetAppendStyle(size: 24, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.FromArgb(46, 116, 181));
            //    doc.AppendLine("目    录");

            //    doc.SetAppendStyle(size: 14, fontname: "宋体", alignment: eParagraphAlignment.Left, fontcolor: Color.Black);
            //    doc.AppendTableOfContents();

            //    doc.AppendSection();
            //    var section = doc.Sections[1];
            //    section.AddPageNumberAtFooter();

            //    doc.SetAppendStyle(style: eBuiltinStyle.Heading1);
            //    doc.AppendLine("a");
            //    doc.SetAppendStyle(style: eBuiltinStyle.Heading2);
            //    doc.AppendLine("a");


            //    doc.TablesOfContents[0].Update();
            //    doc.TablesOfContents[0].Select();
            //    doc.SetSelectionStyle(size: 14, fontname: "宋体", alignment: eParagraphAlignment.Left, fontcolor: Color.Black);

            //    doc.SetAppendStyle(size: 24, fontname: "华文中宋", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, backgroundcolor: Color.AliceBlue, bold: true, style: eBuiltinStyle.Heading1);
            //    doc.AppendLine("心理测评知识普及");
            //    doc.TablesOfContents[0].Update();

            //    doc.SetAppendStyle(style: eBuiltinStyle.BodyText);
            //    doc.AddTable(3, 3);
            //    doc.Tables[0].AddTableBorder(Color.Red, Color.Red);
            //    doc.Tables[0].SetTitle("table1");
            //    doc.Tables[0].SetRowStyle(1, Color.AliceBlue);

            //    doc.AddTable(3, 4);
            //    Console.WriteLine(doc.Tables.Count());
            //    doc.Tables[1].MergeCell(1, 1, 1, 2);
            //    doc.Tables[1].AddTableBorder();
            //    doc.Tables[1].CellText(1, 1, "test");
            //    doc.Tables[1].SetCellStyle(1, 1, backgroundcolor: Color.AliceBlue, bold: true);

            //    using (var chart = doc.AddChart(XlChartType.xlColumnClustered))
            //    {
            //        string[] names = { "公司A", "公司B", "公司C", "公司D", "公司E" }; // 数据名称
            //        double[] values = { 10.0, 32.5, 22.4, 34.1, 15.9 }; // 对应数据
            //        double[] values1 = { 5, 5, 5, 5, 5 }; // 对应数据
            //        double[] values2 = { 5, 5, 3, 5, 5 }; // 对应数据
            //        double[] values3 = { 5, 4, 5, 2, 5 }; // 对应数据
            //        double[] values4 = { 0, 1, 1, 2, 2 }; // 对应数据
            //        chart.SetData(names, "123", values);
            //        chart.AddNewSeries(XlChartType.xlLine, "456111", values1);
            //        chart.AddNewSeries(XlChartType.xlLine, "45611", values2);
            //        chart.AddNewSeries(XlChartType.xlLine, "45611111", values3);
            //        chart.AddNewSeries(XlChartType.xlLine, "4561111", values4);
            //    }
            //    doc.SaveAs(@"R:\temp.docx");
            //    Console.ReadLine();
            //    doc.Close();

            //}


            using (var doc1 = new WordDocument())
            {
                doc1.AppendLine("test");
                doc1.SaveAs(@"R:\temp.doc");
            }
            using (var doc = new WordDocument())
            {
                doc.SetDocPaper(ePaperSize.PaperA4);
                doc.SetDocMargin(doc.MillimetersToPoints(38.1), doc.MillimetersToPoints(31.9), doc.MillimetersToPoints(27), doc.MillimetersToPoints(19.4));
                doc.SetAppendStyle(size: 28, alignment: eParagraphAlignment.Center);
                doc.AppendLine();
                doc.AppendLine();

                doc.SetAppendStyle(size: 22, fontname: "华文中宋", alignment: eParagraphAlignment.Center, fontcolor: Color.FromArgb(68, 84, 106));
                doc.AppendLine("中小学生学业诊断分析系统");
                doc.AppendLine("学业支持子系统个体测评报告");

                doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Center);
                doc.AppendBlankLine(9);

                doc.SetAppendStyle(size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, underline: eUnderline.Single);
                doc.AppendLine("学校： 	远东仁民");

                doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Center);
                doc.AppendLine();

                doc.SetAppendStyle(size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, underline: eUnderline.Single);
                doc.AppendLine("姓名： 	  李端沐");
                doc.AppendPage();

                doc.SetAppendStyle(size: 24, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.FromArgb(46, 116, 181));
                doc.AppendLine("目    录");

                doc.SetAppendStyle(size: 14, fontname: "宋体", alignment: eParagraphAlignment.Left, fontcolor: Color.Black);
                doc.AppendTableOfContents();

                doc.AppendSection();
                var section = doc.Sections[1];
                section.AddPageNumberAtFooter();

                doc.SetAppendStyle(style: eBuiltinStyle.Heading1);
                doc.AppendLine("a");
                doc.SetAppendStyle(style: eBuiltinStyle.Heading2);
                doc.AppendLine("a");


                doc.TablesOfContents[0].Update();
                doc.TablesOfContents[0].Select();
                doc.SetSelectionStyle(size: 14, fontname: "宋体", alignment: eParagraphAlignment.Left, fontcolor: Color.Black);

                doc.SetAppendStyle(size: 24, fontname: "华文中宋", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, backgroundcolor: Color.AliceBlue, bold: true, style: eBuiltinStyle.Heading1);
                doc.AppendLine("心理测评知识普及");
                doc.TablesOfContents[0].Update();

                doc.SetAppendStyle(style: eBuiltinStyle.BodyText);
                doc.AddTable(3, 3);
                doc.Tables[0].AddTableBorder(Color.Red, Color.Red);
                doc.Tables[0].SetTitle("table1");
                doc.Tables[0].SetRowStyle(1, Color.AliceBlue);

                doc.AddTable(3, 4);
                Console.WriteLine(doc.Tables.Count());
                doc.Tables[1].MergeCell(1, 1, 1, 2);
                doc.Tables[1].AddTableBorder();
                doc.Tables[1].CellText(1, 1, "test");
                doc.Tables[1].SetCellStyle(1, 1, backgroundcolor: Color.AliceBlue, bold: true);
                doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Left, firstlineindentcharacter: 2);
                doc.AppendLine("该学生学业支持系统的整体情况为");
                doc.SetAppendStyle(size: 12, alignment: eParagraphAlignment.Left);
                doc.AppendLine("该生的师生关系类型是平淡顺应型，属于普通型师生关系。该生对教师有一定程度的敬重和信任，平时可以与教师进行较好的沟通与互动，遇到问题时也能接受教师的帮助，极少与教师发生思想和行为上冲突。但是该生对师生关系的进一步发展与提高没有积极的期待，师生关系较为平稳。 ");
                using (var chart = doc.AddChart(eChartType.xlColumnClustered))
                {
                    string[] names = { "公司A", "公司B", "公司C", "公司D", "公司E" }; // 数据名称
                    double[] values = { 10.0, 32.5, 22.4, 34.1, 15.9 }; // 对应数据
                    double[] values1 = { 5, 5, 5, 5, 5 }; // 对应数据
                    double[] values2 = { 5, 5, 3, 5, 5 }; // 对应数据
                    double[] values3 = { 5, 4, 5, 2, 5 }; // 对应数据
                    double[] values4 = { 0, 1, 1, 2, 2 }; // 对应数据
                    chart.SetData(names, "123", values);
                    chart.AddNewSeries(eChartType.xlLine, "456111", values1);
                    chart.AddNewSeries(eChartType.xlLine, "45611", values2);
                    chart.AddNewSeries(eChartType.xlLine, "45611111", values3);
                    chart.AddNewSeries(eChartType.xlLine, "4561111", values4);
                }
                doc.SaveAs(@"R:\temp.docx");
                Console.ReadLine();
                doc.Close();

            }


            //using (var doc1 = new WordDocument())
            //{
            //    doc1.AppendLine("test");

            //    using (var doc2 = new WordDocument())
            //    {
            //        doc1.fuck.Content.Copy();
            //        doc2.fuck.Application.Selection.Paste();
            //    }
            //}

        }

    }
}

