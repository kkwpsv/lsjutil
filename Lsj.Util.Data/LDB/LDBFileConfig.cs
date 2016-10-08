using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Data.LDB
{
    /// <summary>
    /// LDBFileConfig
    /// </summary>
    public class LDBFileConfig
    {

        bool IsChange = false;


        /// <summary>
        /// Version
        /// </summary>
        public Version Version
        {
            get
            {
                return version;
            }
            internal set
            {
                if(version != value)
                {
                    version = value;
                    IsChange = true;
                }
            }
        } 

        Version version = new Version(1, 0);
        /// <summary>
        /// DBName
        /// </summary>
        public string DBName
        {
            get
            {
                return dbname;
            }
            set
            {
                var temp = value.ConvertToBytes(Encoding.UTF8);
                if (temp.Length > 28)
                {
                    throw new ArgumentException("DBName is too long");
                }
                else
                {
                    dbname = value;
                    IsChange = true;
                }
            }
        }
        string dbname;



        internal void Save(FileStream file)
        {
            if (IsChange)
            {
                file.Seek(10, SeekOrigin.Begin);
                file.WriteByte((byte)Version.Major);
                file.WriteByte((byte)Version.Minor);
                file.Write(DBName.ConvertToBytes(Encoding.UTF8));
            }
        }
    }
}
