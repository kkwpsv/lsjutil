using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Auto Property
    /// </summary>
    public class AutoProperty : ClassMember
    {
        /// <summary>
        /// Visibility
        /// </summary>
        public Visibility Visibility
        {
            get;
            set;
        } = Visibility.None;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Return Type
        /// </summary>
        public string ReturnType
        {
            get;
            set;
        }

        /// <inheritdoc/>
        public override string ToString(int level)
        {
            var sb = new StringBuilder();
            sb.Append(' ', level * 4);
            sb.AppendLine($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType} {Name}");

            sb.Append(' ', level * 4);
            sb.AppendLine("{");

            level++;

            sb.Append(' ', level * 4);
            sb.AppendLine("get;");

            sb.Append(' ', level * 4);
            sb.AppendLine("set;");

            level--;

            sb.Append(' ', level * 4);
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
