using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.CsBuilder.Statements
{
    /// <summary>
    /// 
    /// </summary>
    public class RawStatement : Statement
    {
        /// <summary>
        /// Raw data
        /// </summary>
        public string RawData
        {
            get;
            set;
        } = "";

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(0);
        /// <summary>
        /// Convert To String
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(BLANK, i * 4);
            sb.AppendLine(RawData);
            return sb.ToString();
        }
    }
}
