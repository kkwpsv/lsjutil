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
namespace Lsj.Util.Core.SQLBuilder.Statement
#else
namespace Lsj.Util.SQLBuilder.Statement
#endif
{
    public class CreateTable :SQLStatement
    {
        public string TableName
        {
            get;
            set;
        }
        SafeStringToStringDirectionary data;
        public CreateTable(string TableName) : this(TableName, new SafeStringToStringDirectionary())
        {
        }
        public CreateTable(string TableName, SafeStringToStringDirectionary data)
        {
            this.TableName = TableName;
            this.data = data;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($@"CREATE TABLE {TableName}");
            sb.AppendLine();
            sb.Append(@"(");
            sb.AppendLine();
            foreach (var x in data)
            {
                sb.AppendLine($@"[{x.Key}] {x.Value},");
            }
            sb.Remove(sb.Length - 3, 1);
            sb.Append(")");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
