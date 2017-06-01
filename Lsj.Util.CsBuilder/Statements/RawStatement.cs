using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.CsBuilder.Statements
{
    public class RawStatement :Statement
    {

        public string RawData
        {
            get;
            set;
        } = "";

        public override string ToString() => ToString(0);

        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.AppendLine(RawData);
            return sb.ToString();
        }
    }
}
