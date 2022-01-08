using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Class
    /// </summary>
    public class Class : ClassMember
    {
        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace
        {
            get;
            set;
        }

        /// <summary>
        /// Visibility
        /// </summary>
        public Visibility Visibility
        {
            get;
            set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Members
        /// </summary>
        public List<ClassMember> Members
        {
            get;
        } = new List<ClassMember>();

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            if (Namespace != null)
            {
                sb.Append(NULL, i * 4);
                sb.AppendLine($@"namespace {Namespace}");
                sb.Append(NULL, i * 4);
                sb.AppendLine("{");
                i++;
            }
            sb.Append(NULL, i * 4);
            sb.AppendLine($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} class {Name}");
            sb.Append(NULL, i * 4);
            sb.AppendLine("{");
            i++;
            foreach (var member in Members)
            {
                sb.Append(member.ToString(i));
            }
            i--;
            sb.Append(NULL, i * 4);
            sb.AppendLine("}");
            if (Namespace != null)
            {
                i--;
                sb.Append(NULL, i * 4);
                sb.AppendLine("}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(0);
    }
}
