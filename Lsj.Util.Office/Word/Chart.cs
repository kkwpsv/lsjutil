using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Lsj.Util.Office.Word
{
    public class Chart :DisposableClass
    {
        private Microsoft.Office.Interop.Word.Chart chart;
        private Workbook workbook;
        private Worksheet worksheet;
        private Application application;


        private int rowcount = 0;
        private int columncount = 0;

        public Chart(Microsoft.Office.Interop.Word.Chart chart)
        {
            this.chart = chart;
            this.workbook = chart.ChartData.Workbook;
            this.application = workbook.Application;
            this.worksheet = workbook.Worksheets["Sheet1"];
        }

        public void SetData(string[] catagory, string datatitle, double[] data)
        {
            rowcount = catagory.Length + 1;
            for (int i = 1; i <= catagory.Length; i++)
            {
                worksheet.Cells[i + 1, 1] = catagory[i - 1];
            }
            worksheet.Cells[1, 2] = datatitle;
            for (int i = 1; i <= data.Length && i < rowcount; i++)
            {
                worksheet.Cells[i + 1, 2] = data[i - 1];
            }
            chart.SetSourceData($@"=Sheet1!$A$1:$B${rowcount}");
            columncount = 2;
        }

        public void AddNewSeries(eChartType type, string datatitle, double[] data)
        {
            columncount++;
            worksheet.Cells[1, columncount] = datatitle;
            for (int i = 1; i <= data.Length && i < rowcount; i++)
            {
                worksheet.Cells[i + 1, columncount] = data[i - 1];
            }


            var x = chart.SeriesCollection().Add($@"=Sheet1!${(char)(ASCIIChar.A + columncount - 1)}$2:${(char)(ASCIIChar.A + columncount - 1)}${rowcount}");
            x.Type = type;
            x.Name = datatitle;
        }


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
