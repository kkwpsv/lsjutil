using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Collections;
#else
using Lsj.Util.Collections;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.CsBuilder
#else
namespace Lsj.Util.CsBuilder
#endif
{
    public class Method :ClassMember
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

        public SafeDictionary<string, Type> Params
        {
            get;
            set;
        } = new SafeDictionary<string, Type>();


        public List<Statement> Statements
        {
            get;
            set;
        } = new List<Statement>();




        public override string ToString() => ToString(0);
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.Append($@"{(Visibility == eVisibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType.Name} {Name} (");
            foreach (var param in Params)
            {
                sb.Append($@"{param.Value.Name} {param.Key} ");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");
            sb.Append(NULL, i * 4);
            sb.AppendLine("{");

            foreach (var statement in Statements)
            {
                sb.Append(statement.ToString(i + 1));
            }


            sb.Append(NULL, i * 4);
            sb.AppendLine("}");


            return sb.ToString();
        }
    }
}
