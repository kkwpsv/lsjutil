using System.Text;

namespace Lsj.Util.CsBuilder.Statements
{
    /// <summary>
    /// Raw Statement
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

        /// <inheritdoc/>
        public override string ToString(int level)
        {
            var sb = new StringBuilder();
            sb.Append(' ', level * 4);
            sb.AppendLine(RawData);
            return sb.ToString();
        }
    }
}
