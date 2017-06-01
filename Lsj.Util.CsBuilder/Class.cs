using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.CsBuilder
#else
namespace Lsj.Util.CsBuilder
#endif
{
    public class Class :ClassMember
    {
        public string Namespace
        {
            get;
            set;
        }
        public eVisibility Visibility
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public List<ClassMember> Members
        {
            get;
        } = new List<ClassMember>();

        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            if (this.Namespace != null)
            {
                sb.Append(NULL, i * 4);
                sb.AppendLine($@"namespace {this.Namespace}");
                sb.Append(NULL, i * 4);
                sb.AppendLine("{");
                i++;
            }
            sb.Append(NULL, i * 4);
            sb.AppendLine($@"{(Visibility == eVisibility.None ? "" : Visibility.ToString().ToLower())} class {Name}");
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
            if (this.Namespace != null)
            {
                i--;
                sb.Append(NULL, i * 4);
                sb.AppendLine("}");
            }
            return sb.ToString();
        }

        public override string ToString() => ToString(0);
    }
}
