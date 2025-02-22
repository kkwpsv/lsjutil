using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Attribute
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Params Without Name
        /// </summary>
        public List<string> ParamsWithoutName { get; } = new List<string>();

        /// <summary>
        /// Params With Name
        /// </summary>
        public List<(string name, string value)> ParamsWithName { get; } = new List<(string name, string value)>();

        /// <inheritdoc/>
        public override string ToString() => ToString(0);

        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string ToString(int level)
        {
            var sb = new StringBuilder();
            sb.Append(' ', level * 4);
            sb.Append($"[{Name}");

            var paramCount = ParamsWithoutName.Count + ParamsWithName.Count;
            int i = 0;
            if (paramCount > 0)
            {
                sb.Append('(');

                foreach (var p in ParamsWithoutName)
                {
                    i++;
                    if (i != paramCount)
                    {
                        sb.Append($"{p}, ");
                    }
                    else
                    {
                        sb.Append(p);
                    }
                }

                foreach (var p in ParamsWithName)
                {
                    i++;
                    if (i != paramCount)
                    {
                        sb.Append($"{p.name} = {p.value}, ");
                    }
                    else
                    {
                        sb.Append($"{p.name} = {p.value}");
                    }
                }

                sb.Append(')');
            }


            sb.AppendLine("]");
            return sb.ToString();
        }
    }
}
