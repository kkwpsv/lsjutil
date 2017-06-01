using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;

namespace Lsj.Util.SQLBuilder.Statement
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
