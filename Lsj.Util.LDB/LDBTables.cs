using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.LDB
{
    /// <summary>
    /// LDBTables
    /// </summary>
    public class LDBTables
    {


        bool IsChange = false;


        /// <summary>
        /// 
        /// </summary>
        public LDBTables(LDBFile ldb)
        {
            this.dic = new SafeDictionary<string, LDBTable>();
            this.ldb = ldb;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public LDBTables(LDBFile ldb,byte[] buffer)
        {
            this.dic = new SafeDictionary<string, LDBTable>();
            this.ldb = ldb;
            this.Init(buffer);         
        }

        private void Init(byte[] buffer)
        {
            var stream = new MemoryStream(buffer);
            stream.Seek(0, SeekOrigin.Begin);
            if (stream.ReadByte() != 2 && stream.ReadByte() != 0)
            {
                throw new InvalidDataException("Error Table Index");
            }
            else
            {
                while(ReadOne(stream))
                {
                    continue;
                }
                stream.Seek(195, SeekOrigin.Begin);
                if (stream.ReadByte() != 3)
                {
                    throw new InvalidDataException("Error Table Index");
                }
                else
                {

                }
            }
        }

        private bool ReadOne(MemoryStream stream)
        {
            if (stream.Position == 192)
            {
                return false;
            }
            var buffer = new byte[12];
            stream.Read(buffer, 0, 12);
            unsafe
            {
                fixed (byte* x = buffer)
                {
                    var position = *(long*)x;
                    if (position == 0)
                    {
                        return false;
                    }
                    var length = *((int*)x + 2);
                    var table = new LDBTable(position, length, ldb);
                    dic.Add(table.Name, table);
                    return true;
                }
            }
        }

        SafeDictionary<string,LDBTable> dic;
        LDBFile ldb;



        internal void Save(FileStream file)
        {
            if (IsChange)
            {

            }
        }
    }
}
