using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Binary
{
    /// <summary>
    /// Dos Executable File
    /// </summary>
    public class DosExeFile : BaseBinaryFile
    {
        /// <summary>
        /// Dos Header
        /// </summary>
        public DosHeader DosHeader
        {
            get;
            private set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Binary.DosExeFile"/> class.
        /// </summary>
        /// <param name="path">File Path</param>
        public DosExeFile(string path) : base(path)
        {
        }

        /// <summary>
        /// DosHeader Byte Array
        /// </summary>
        protected byte[] dosheaderbytes;

        /// <summary>
        /// Read
        /// </summary>
        protected override void Read()
        {
            byte[] headers = new byte[28];
            if (file.Read(headers, 0, 28) == 28 && headers[0] == 0x4d && headers[1] == 0x5a)
            {
                var headersize = (headers[0x08] | headers[0x09] << 8) << 4;
                if (headersize >= 28)
                {
                    Array.Resize(ref headers, headersize);
                    file.Read(headers, 28, headersize - 28);
                    this.dosheaderbytes = headers;

                    unsafe
                    {
                        var dosheader = new DosHeader();
                        fixed (byte* headerptr = dosheaderbytes)
                        {
                            UnsafeHelper.Copy(headerptr, dosheader.buffer, 28);
                        }
                        this.DosHeader = dosheader;
                    }



                }
                else
                {
                    throw new ArgumentException("Error Dos Exe File");
                }
            }
            else
            {
                throw new ArgumentException("Error Dos Exe File");
            }
        }
        /// <summary>
        /// RelocationTable
        /// </summary>
        /// <returns></returns>
        public RelocationItem[] GetRelocationTable()
        {
            var result = new RelocationItem[DosHeader.NumRelocs];
            var size = DosHeader.NumRelocs * 4;

            unsafe
            {

                fixed (byte* x = this.dosheaderbytes)
                {
                    var src = x + DosHeader.reloc_table_offset;
                    fixed (RelocationItem* dst = result)
                    {
                        UnsafeHelper.Copy(src, (byte*)dst, size);
                    }
                }
            }

            return result;


        }
    }
    /// <summary>
    /// Dos Header
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DosHeader
    {
        [FieldOffset(0x00)]
        internal unsafe fixed byte buffer[28];

        [FieldOffset(0x00)]
        public readonly UInt16 Signature;

        [FieldOffset(0x02)]
        public readonly UInt16 BytesInLastBlock;

        [FieldOffset(0x04)]
        public readonly UInt16 BlocksInFile;

        [FieldOffset(0x06)]
        public readonly UInt16 NumRelocs;

        [FieldOffset(0x08)]
        public readonly UInt16 HeaderParagraphs;

        [FieldOffset(0x0A)]
        public readonly UInt16 MinExtraParagraphs;

        [FieldOffset(0x0C)]
        public readonly UInt16 MaxExtraParagraphs;

        [FieldOffset(0x0E)]
        public readonly UInt16 ss;

        [FieldOffset(0x10)]
        public readonly UInt16 sp;

        [FieldOffset(0x12)]
        public readonly UInt16 checksum;

        [FieldOffset(0x14)]
        public readonly UInt16 ip;

        [FieldOffset(0x16)]
        public readonly UInt16 cs;

        [FieldOffset(0x18)]
        public readonly UInt16 reloc_table_offset;

        [FieldOffset(0x1A)]
        public readonly UInt16 overlay_number;



    }

    [StructLayout(LayoutKind.Explicit, Size = 0x04)]
    public struct RelocationItem
    {
        [FieldOffset(0x00)]
        public readonly UInt16 offset;
        [FieldOffset(0x02)]
        public readonly UInt16 segment;
    };
}
