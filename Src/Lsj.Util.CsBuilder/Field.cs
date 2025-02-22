using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Field
    /// </summary>
    public class Field : ClassMember
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
            sb.AppendLine($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType} {Name};");
            return sb.ToString();
        }
    }
}
