using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;

namespace Lsj.Util.SQLBuilder.Statement
{
    /// <summary>
    /// Insert
    /// </summary>
    public class Insert : SQLStatement
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName
        {
            get;
            set;
        }
        SafeStringToStringDictionary data;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.SQLBuilder.Statement.Insert"/> class
        /// </summary>
        /// <param name="TableName"></param>
        public Insert(string TableName) : this(TableName, new SafeStringToStringDictionary())
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.SQLBuilder.Statement.Insert"/> class
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="data"></param>
        public Insert(string TableName, SafeStringToStringDictionary data)
        {
            this.TableName = TableName;
            this.data = data;
        }

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
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
