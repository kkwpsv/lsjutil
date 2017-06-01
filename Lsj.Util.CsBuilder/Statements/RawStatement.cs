using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.CsBuilder.Statements
#else
namespace Lsj.Util.CsBuilder.Statements
#endif
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
