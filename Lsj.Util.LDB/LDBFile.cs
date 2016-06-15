using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.LDB
{
    


    /// <summary>
    /// LDB File
    /// </summary>
    public class LDBFile :DisposableClass, IDisposable
    {
        /// <summary>
        /// NEW FILE
        /// </summary>
        public static readonly byte[] NEWFILE = { ASCIIChar.L,ASCIIChar.D,ASCIIChar.B,          0,          0,
                                                            0,          0,          0,          0,          0,//10
                                                            1,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//20
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//30
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//40
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//50
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//60
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//70
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//80
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//90
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,        255,//100
                                                 };
        /// <summary>
        /// Inital a new instance of LDBFile
        /// </summary>
        public LDBFile()
        {
            this.Initial();
        }

        /// <summary>
        /// Inital a new instance of LDBFile from a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="CanWrite"></param>
        public LDBFile(string filename,bool CanWrite)
        {
            this.FileName = filename;
            if (!File.Exists(filename))
            {
                CreateFile(filename);
            }
            if (CanWrite)
            {
                this.file = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            }
            else
            {
                this.file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            this.IsOpenFile = true;
            this.file.Seek(0, SeekOrigin.Begin);
            if (file.ReadByte() == ASCIIChar.L && file.ReadByte() == ASCIIChar.D&&file.ReadByte()==ASCIIChar.B)
            {
                this.InitialFromFile();
            }
            else
            {
                throw new InvalidDataException("Error LDB File");
            }
        }

        private void CreateFile(string filename)
        {
            File.WriteAllBytes(filename, NEWFILE);
        }

        private void Initial()
        {
            this.Config = new LDBFileConfig();
        }
        private void InitialFromFile()
        {
            Initial();
            this.file.Seek(10, SeekOrigin.Begin);
            var major = file.ReadByte();
            var minor = file.ReadByte();
            if (major > 0 && minor > 0)
            {
                this.Config.Version = new Version(major, minor);
            }
            var buffer = new byte[28];
            file.Read(buffer, 0, 28);
            this.Config.DBName = buffer.ConvertFromBytes(Encoding.UTF8);

            this.file.Seek(99, SeekOrigin.Begin);
            if (file.ReadByte() != 255)
            {
                throw new InvalidDataException("Error LDB File");
            }
            else
            {
            }

        }

        /// <summary>
        /// CloseFile
        /// </summary>
        public void Close()
        {
            this.file.Close();
            this.IsOpenFile = false;
        }

        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            if (FileName == null)
            {
                throw new InvalidOperationException("filename not set");
            }
            if (!IsOpenFile || !file.CanWrite)
            {
                throw new IOException ("file cannot be written");
            }
            this.file.Seek(10, SeekOrigin.Begin);
            this.file.WriteByte((byte)Config.Version.Major);
            this.file.WriteByte((byte)Config.Version.Minor);
            this.file.Write(Config.DBName.ConvertToBytes(Encoding.UTF8));
            this.file.Seek(25, SeekOrigin.Begin);
            


        }




        /// <summary>
        /// Config
        /// </summary>
        public LDBFileConfig Config
        {
            get;
            private set;
        }
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                if (IsOpenFile)
                {
                    throw new InvalidOperationException("File is opening");
                }
                else
                {
                    this.filename = value;
                }
            }
        }
        private string filename;
        FileStream file;




        private bool IsOpenFile = false;



        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            if (IsOpenFile)
            {
                this.Close();
            }
            base.CleanUpManagedResources();
        }
    }
}
