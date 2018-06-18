using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// Chart
    /// </summary>
    public class Chart : DisposableClass
    {
        private Microsoft.Office.Interop.Word.Chart chart;
        private Workbook workbook;
        private Worksheet worksheet;
        private Application application;


        private int rowcount = 0;
        private int columncount = 0;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Office.Word.Chart"/> class
        /// </summary>
        /// <param name="chart"></param>
        public Chart(Microsoft.Office.Interop.Word.Chart chart)
        {
            this.chart = chart;
            this.workbook = chart.ChartData.Workbook;
            this.application = workbook.Application;
            this.worksheet = workbook.Worksheets["Sheet1"];
        }
        /// <summary>
        /// Set Data
        /// </summary>
        /// <param name="catagory"></param>
        /// <param name="dataTitle"></param>
        /// <param name="data"></param>
        public void SetData(string[] catagory, string dataTitle, double[] data)
        {
            rowcount = catagory.Length + 1;
            for (int i = 1; i <= catagory.Length; i++)
            {
                worksheet.Cells[i + 1, 1] = catagory[i - 1];
            }
            worksheet.Cells[1, 2] = dataTitle;
            for (int i = 1; i <= data.Length && i < rowcount; i++)
            {
                worksheet.Cells[i + 1, 2] = data[i - 1];
            }
            chart.SetSourceData($@"=Sheet1!$A$1:$B${rowcount}");
            columncount = 2;
        }
        /// <summary>
        /// AddNewSeries
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dataTitle"></param>
        /// <param name="data"></param>
        public void AddNewSeries(ChartType type, string dataTitle, double[] data)
        {
            columncount++;
            worksheet.Cells[1, columncount] = dataTitle;
            for (int i = 1; i <= data.Length && i < rowcount; i++)
            {
                worksheet.Cells[i + 1, columncount] = data[i - 1];
            }


            var x = chart.SeriesCollection().Add($@"=Sheet1!${(char)(ASCIIChar.A + columncount - 1)}$2:${(char)(ASCIIChar.A + columncount - 1)}${rowcount}");
            x.Type = type;
            x.Name = dataTitle;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            worksheet = null;

            workbook.Close(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;

            application.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
            application = null;
            base.CleanUpUnmanagedResources();
        }
    }
}
