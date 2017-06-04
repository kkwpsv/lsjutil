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
        private System.Data.DataTable data;

        public Chart(Microsoft.Office.Interop.Word.Chart chart)
        {
            this.chart = chart;
            this.workbook = chart.ChartData.Workbook;
            this.application = workbook.Application;
            this.worksheet = workbook.Worksheets["Sheet1"];
        }

        public void SetData(string[] catagory, string datatitle, double[] data)
        {
            if (this.data != null)
            {
                throw new InvalidOperationException("Already Set Data");
            }
            else
            {
                this.data = new System.Data.DataTable();
                var column = this.data.Columns.Add();
                column.DataType = typeof(string);
                var column2 = this.data.Columns.Add();
                column2.ColumnName = datatitle;
                column2.DataType = typeof(double);
                int i = 0;
                foreach (var x in catagory)
                {
                    var row = this.data.NewRow();
                    row[0] = catagory[i];
                    row[1] = data[i];
                    this.data.Rows.Add(row);
                    i++;
                }
            }
            WriteToWorkSheet();
        }

        public void AddNewSeries(Microsoft.Office.Core.XlChartType type, string datatitle, double[] data)
        {
            var x = this.data.Columns.Count;
            var column = this.data.Columns.Add();
            column.ColumnName = datatitle;
            int l = Math.Min(this.data.Rows.Count, data.Length);
            for (int i = 0; i < l; i++)
            {
                this.data.Rows[i][x] = data[i];
            }
            WriteToWorkSheet();
            chart.SeriesCollection(this.data.Columns.Count - 1).Type = type;
        }

        private void WriteToWorkSheet()
        {
            for (int i = 1; i < data.Columns.Count; i++)
            {
                worksheet.Range[$"{(char)(ASCIIChar.A + i)}{1}"].FormulaR1C1 = data.Columns[i].ColumnName;
            }

            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    worksheet.Range[$"{(char)(ASCIIChar.A + j)}{i + 2}"].FormulaR1C1 = this.data.Rows[i][j];
                }
            }
            chart.SetSourceData($@"='Sheet1'!$A$1:${(char)(ASCIIChar.A + data.Columns.Count - 1)}${data.Rows.Count + 1}");
        }

        protected override void CleanUpUnmanagedResources()
        {
            this.application.Quit();
        }
    }
}
