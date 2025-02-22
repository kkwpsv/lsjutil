using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Enum item
    /// </summary>
    public class EnumItem : Statement
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }

        /// <inheritdoc/>
        public override string ToString(int level)
        {
            var sb = new StringBuilder();

            if (Comments != null)
            {
                sb.Append(' ', level * 4);
                sb.AppendLine("/// <summary>");
                sb.Append(' ', level * 4);
                sb.Append("/// ");
                sb.AppendLine(Comments);
                sb.Append(' ', level * 4);
                sb.AppendLine("/// </summary>");
            }


            sb.Append(' ', level * 4);
            sb.Append(Name);

            if (Value != null)
            {
                sb.Append($" = {Value}");
            }
            sb.AppendLine(",");
            return sb.ToString();
        }
    }
}
