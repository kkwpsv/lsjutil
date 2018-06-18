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
                    var src = x + DosHeader.RelocationTableOffset;
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

        /// <summary>
        /// Signature
        /// </summary>
        [FieldOffset(0x00)]
        public readonly UInt16 Signature;

        /// <summary>
        /// BytesInLastBlock
        /// </summary>
        [FieldOffset(0x02)]
        public readonly UInt16 BytesInLastBlock;

        /// <summary>
        /// BlocksInFile
        /// </summary>
        [FieldOffset(0x04)]
        public readonly UInt16 BlocksInFile;

        /// <summary>
        /// NumRelocs
        /// </summary>
        [FieldOffset(0x06)]
        public readonly UInt16 NumRelocs;

        /// <summary>
        /// HeaderParagraphs
        /// </summary>
        [FieldOffset(0x08)]
        public readonly UInt16 HeaderParagraphs;

        /// <summary>
        /// MinExtraParagraphs
        /// </summary>
        [FieldOffset(0x0A)]
        public readonly UInt16 MinExtraParagraphs;

        /// <summary>
        /// MaxExtraParagraphs
        /// </summary>
        [FieldOffset(0x0C)]
        public readonly UInt16 MaxExtraParagraphs;

        /// <summary>
        /// SS
        /// </summary>
        [FieldOffset(0x0E)]
        public readonly UInt16 SS;

        /// <summary>
        /// SP
        /// </summary>
        [FieldOffset(0x10)]
        public readonly UInt16 SP;

        /// <summary>
        /// CheckSum
        /// </summary>
        [FieldOffset(0x12)]
        public readonly UInt16 CheckSum;

        /// <summary>
        /// IP
        /// </summary>
        [FieldOffset(0x14)]
        public readonly UInt16 IP;

        /// <summary>
        /// CS
        /// </summary>
        [FieldOffset(0x16)]
        public readonly UInt16 CS;

        /// <summary>
        /// RelocationTableOffset
        /// </summary>
        [FieldOffset(0x18)]
        public readonly UInt16 RelocationTableOffset;

        /// <summary>
        /// OverlayNumber
        /// </summary>
        [FieldOffset(0x1A)]
        public readonly UInt16 OverlayNumber;



    }

    /// <summary>
    /// RelocationItem
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x04)]
    public struct RelocationItem
    {
        /// <summary>
        /// Offset
        /// </summary>
        [FieldOffset(0x00)]
        public readonly UInt16 Offset;
        /// <summary>
        /// Segment
        /// </summary>
        [FieldOffset(0x02)]
        public readonly UInt16 Segment;
    };
}
