using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;

namespace Lsj.Util.SQLBuilder.Statement
{
    public class Insert :SQLStatement
    {
        public string TableName
        {
            get;
            set;
        }
        SafeStringToStringDirectionary data;
        public Insert(string TableName) : this(TableName, new SafeStringToStringDirectionary())
        {
        }
        public Insert(string TableName, SafeStringToStringDirectionary data)
        {
            this.TableName = TableName;
            this.data = data;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($@"INSERT INTO {TableName} (");
            foreach (var key in data.Keys)
            {
                sb.Append($@"[{key}],");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") VALUES (");
            foreach (var value in data.Values)
            {
                sb.Append($@"'{value.Replace("'", "''")}',");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
