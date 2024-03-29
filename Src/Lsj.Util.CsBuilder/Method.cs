﻿using Lsj.Util.Collections;
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
        /// Param
        /// </summary>
        public SafeDictionary<string, string> Params
        {
            get;
            set;
        } = new SafeDictionary<string, string>();

        /// <summary>
        /// Statements
        /// </summary>
        public List<Statement> Statements
        {
            get;
            set;
        } = new List<Statement>();

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(0);

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.Append($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType} {Name} (");
            foreach (var param in Params)
            {
                sb.Append($@"{param.Value} {param.Key} ");
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
