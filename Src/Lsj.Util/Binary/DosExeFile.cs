using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

using WORD = System.UInt16;
using LONG = System.UInt32;

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
        protected byte[] _dosHeaderBytes;

        /// <summary>
        /// Read
        /// </summary>
        protected override bool Read()
        {
            byte[] headers = new byte[28]; //Min Header Size
            _file.Seek(0, SeekOrigin.Begin);
            if (_file.Read(headers, 0, 28) == 28 && headers[0] == 0x4d && headers[1] == 0x5a)//MZ
            {
                var headerSize = headers.ConvertToShort(0x08) << 4;

                if (headerSize > 28)
                {
                    Array.Resize(ref headers, headerSize);
                    _file.Read(headers, 28, headerSize - 28);
                }

                if (headerSize >= 28)
                {
                    _dosHeaderBytes = headers;

                    unsafe
                    {
                        var dosHeader = new DosHeader();
                        fixed (byte* headerPtr = _dosHeaderBytes)
                        {
                            UnsafeHelper.Copy(headerPtr, dosHeader.buffer, headerSize > 0x40 ? 0x40 : headerSize);
                        }
                        DosHeader = dosHeader;
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// RelocationTable
        /// </summary>
        /// <returns></returns>
        public RelocationItem[] GetRelocationTable()
        {
            var result = new RelocationItem[DosHeader.e_crlc];
            var size = DosHeader.e_crlc * 4;

            _file.Seek(DosHeader.lfarlc, SeekOrigin.Begin);
            var buffer = new byte[size];
            if (_file.Read(buffer, 0, size) == size)
            {
                unsafe
                {
                    fixed (RelocationItem* items = result)
                    {
                        UnsafeHelper.Copy(buffer, items, size);
                    }
                    return result;
                }
            }

            return null;
        }
    }

    /// <summary>
    /// DOS .EXE header
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct DosHeader
    {
        [FieldOffset(0x00)]
        internal unsafe fixed byte buffer[0x40];

        /// <summary>
        /// Magic number (MZ)
        /// </summary>
        [FieldOffset(0x00)]
        public WORD e_magic;

        /// <summary>
        /// Bytes on last page of file
        /// </summary>
        [FieldOffset(0x02)]
        public WORD e_cblp;

        /// <summary>
        /// Pages in file
        /// </summary>
        [FieldOffset(0x04)]
        public WORD e_cp;

        /// <summary>
        /// Relocations
        /// </summary>
        [FieldOffset(0x06)]
        public WORD e_crlc;

        /// <summary>
        /// Size of header in paragraphs
        /// </summary>
        [FieldOffset(0x08)]
        public WORD e_cparhdr;

        /// <summary>
        /// Minimum extra paragraphs needed
        /// </summary>
        [FieldOffset(0x0A)]
        public WORD e_minalloc;

        /// <summary>
        /// Maximum extra paragraphs needed
        /// </summary>
        [FieldOffset(0x0C)]
        public WORD e_maxalloc;

        /// <summary>
        /// Initial (relative) SS value
        /// </summary>
        [FieldOffset(0x0E)]
        public WORD ss;

        /// <summary>
        /// Initial SP value
        /// </summary>
        [FieldOffset(0x10)]
        public WORD sp;

        /// <summary>
        /// CheckSum
        /// </summary>
        [FieldOffset(0x12)]
        public WORD csum;

        /// <summary>
        /// Initial IP value
        /// </summary>
        [FieldOffset(0x14)]
        public WORD ip;

        /// <summary>
        /// Initial (relative) CS value
        /// </summary>
        [FieldOffset(0x16)]
        public WORD cs;

        /// <summary>
        /// File address of relocation table
        /// </summary>
        [FieldOffset(0x18)]
        public WORD lfarlc;

        /// <summary>
        /// Overlay number
        /// </summary>
        [FieldOffset(0x1A)]
        public WORD ovno;

        /// <summary>
        /// Reserved words
        /// </summary>
        [FieldOffset(0x1C)]
        public unsafe fixed WORD e_res[4];

        /// <summary>
        /// OEM identifier (for <see cref="e_oeminfo"/>)
        /// </summary>
        [FieldOffset(0x24)]
        public WORD e_oemid;

        /// <summary>
        /// OEM information; <see cref="e_oemid"/> specific
        /// </summary>
        [FieldOffset(0x26)]
        public WORD e_oeminfo;

        /// <summary>
        /// Reserved words
        /// </summary>
        [FieldOffset(0x28)]
        public unsafe fixed WORD e_res2[10];

        /// <summary>
        /// File address of new exe header (PE header)
        /// </summary>
        [FieldOffset(0x3C)]
        public LONG e_lfanew;
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
        public readonly WORD Offset;
        /// <summary>
        /// Segment
        /// </summary>
        [FieldOffset(0x02)]
        public readonly WORD Segment;
    };
}
