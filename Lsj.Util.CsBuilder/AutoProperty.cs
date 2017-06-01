using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Reflection;
#else
using Lsj.Util.Reflection;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.CsBuilder
#else
namespace Lsj.Util.CsBuilder
#endif
{
    public class AutoProperty :ClassMember
    {
        public eVisibility Visibility
        {
            get;
            set;
        } = eVisibility.None;
        public string Name
        {
            get;
            set;
        } = "MethodName";
        public Type ReturnType
        {
            get;
            set;
        } = typeof(void);




        public override string ToString() => ToString(0);
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.AppendLine($@"{(Visibility == eVisibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType.GetTypeName()} {Name}");
            sb.Append(NULL, i * 4);
            sb.AppendLine("{");
            sb.Append(NULL, (i + 1) * 4);
            sb.AppendLine("get;");
            sb.Append(NULL, (i + 1) * 4);
            sb.AppendLine("set;");
            sb.Append(NULL, i * 4);
            sb.AppendLine("}");


            return sb.ToString();
        }
    }
}
