using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Method
    /// </summary>
    public class Method : ClassMember
    {
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
        /// Return type
        /// </summary>
        public string ReturnType
        {
            get;
            set;
        }

        /// <summary>
        /// Param (name -> type)
        /// </summary>
        public List<(string type, string name)> Params { get; } = new List<(string type, string name)>();

        /// <summary>
        /// Statements
        /// </summary>
        public List<Statement> Statements { get; } = new List<Statement>();

        /// <inheritdoc/>
        public override string ToString(int level)
        {
            var sb = new StringBuilder();

            sb.Append(' ', level * 4);
            sb.Append($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType} {Name} (");
            var i = 0;
            foreach (var param in Params)
            {
                i++;
                if (i != Params.Count)
                {
                    sb.Append($"{param.type} {param.name}, ");
                }
                else
                {
                    sb.Append($"{param.type} {param.name}");
                }
            }
            sb.AppendLine(")");

            sb.Append(' ', i * 4);
            sb.AppendLine("{");

            foreach (var statement in Statements)
            {
                sb.AppendLine(statement.ToString(i + 1));
            }

            sb.Append(' ', i * 4);
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
