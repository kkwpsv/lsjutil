using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Office.Word
{
    public class Chart
    {
        private Microsoft.Office.Interop.Word.InlineShape chart;

        public Chart(Microsoft.Office.Interop.Word.InlineShape chart)
        {
            this.chart = chart;
        }

        public void Resize(string cell1,string cell2)
        {
            Microsoft.Office.Interop.Excel.Worksheet worksheet =chart.Chart.ChartData.Workbook.Worksheets["Sheet1"];
            worksheet.ListObjects.Item[1].Resize(worksheet.get_Range(cell1, cell2));
        }

        public void 


    }
}
