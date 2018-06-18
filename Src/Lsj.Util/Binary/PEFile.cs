using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Binary
{
    /// <summary>
    /// PEFile
    /// </summary>
    public class PEFile : DosExeFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Binary.PEFile"/> class.
        /// </summary>
        /// <param name="path">File Path</param>
        public PEFile(string path) : base(path)
        {
        }
        /// <summary>
        /// NTHeader
        /// </summary>
        public NTHeader NTHeader
        {
            get;
            private set;
        }
        /// <summary>
        /// Read
        /// </summary>
        protected override void Read()
        {
            base.Read();
            if (this.DosHeader.HeaderParagraphs == 4)
            {
                var peoffset = dosheaderbytes.ConvertToInt(0x3c);
                file.Seek(peoffset, SeekOrigin.Begin);
                byte[] x = new byte[4];
                file.Read(x, 0, 4);
                var t = x.ConvertToInt();
                if (t != 0x4550)
                {
                    throw new ArgumentException("Error PE File");
                }
                var fileheader = new FileHeader();



                var ntheader = new NTHeader(0x4550, fileheader);

                this.NTHeader = ntheader;

            }
            else
            {
                throw new ArgumentException("Error PE File");
            }
        }
    }

    /// <summary>
    /// NTHeader
    /// </summary>
    public struct NTHeader
    {
        internal NTHeader(UInt16 signature, FileHeader fileheader)
        {
            this.Signature = signature;
            this.FileHeader = fileheader;
        }
        /// <summary>
        /// Signature
        /// </summary>
        public readonly UInt16 Signature;
        /// <summary>
        /// FileHeader
        /// </summary>
        public readonly FileHeader FileHeader;
    }

    /// <summary>
    /// FileHeader
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct FileHeader
    {
        [FieldOffset(0x00)]
        internal unsafe fixed byte buffer[20];

        /// <summary>
        /// Machine
        /// </summary>
        [FieldOffset(0x00)]
        public readonly Machine Machine;
        /// <summary>
        /// NumberOfSections
        /// </summary>
        [FieldOffset(0x02)]
        public readonly UInt16 NumberOfSections;
        /// <summary>
        /// TimeDateStamp
        /// </summary>
        [FieldOffset(0x04)]
        public readonly UInt32 TimeDateStamp;
        /// <summary>
        /// PointerToSymbolTable
        /// </summary>
        [FieldOffset(0x08)]
        public readonly UInt32 PointerToSymbolTable;
        /// <summary>
        /// NumberOfSymbols
        /// </summary>
        [FieldOffset(0x0C)]
        public readonly UInt32 NumberOfSymbols;
        /// <summary>
        /// SizeOfOptionalHeader
        /// </summary>
        [FieldOffset(0x10)]
        public readonly UInt16 SizeOfOptionalHeader;
        /// <summary>
        /// Characteristics
        /// </summary>
        [FieldOffset(0x12)]
        public readonly Characteristics Characteristics;

    }

    /// <summary>
    /// Machine
    /// </summary>
    public enum Machine : UInt16
    {
        /// <summary>
        /// Unknown
        /// </summary>
        UNKNOWN = 0,
        /// <summary>
        /// i386
        /// </summary>
        I386 = 0x014c,
        /// <summary>
        /// R3000
        /// </summary>
        R3000 = 0x0162,
        /// <summary>
        /// R4000
        /// </summary>
        R4000 = 0x0166,
        /// <summary>
        /// R10000
        /// </summary>
        R10000 = 0x0168,
        /// <summary>
        /// Windows CE 2 MIPS little endian
        /// </summary>
        WCEMIPSV2 = 0x0169,
        /// <summary>
        /// Alpha AXP
        /// </summary>
        ALPHA = 0x0184,
        /// <summary>
        /// SH3 little endian
        /// </summary>
        SH3 = 0x01a2,
        /// <summary>
        /// SH3DSP little endian
        /// </summary>
        SH3DSP = 0x01a3,
        /// <summary>
        /// SH3E little endian
        /// </summary>
        SH3E = 0x01a4,
        /// <summary>
        /// SH4 little endian
        /// </summary>
        SH4 = 0x01a6,
        /// <summary>
        /// SH5 little endian
        /// </summary>
        SH5 = 0x01a8,
        /// <summary>
        /// ARM little endian
        /// </summary>
        ARM = 0x01c0,
        /// <summary>
        /// ARM processor with Thumb decompressor
        /// </summary>
        THUMB = 0x01c2,
        /// <summary>
        /// AM33
        /// </summary>
        AM33 = 0x01d3,
        /// <summary>
        /// IBM PowerPC little endian
        /// </summary>
        POWERPC = 0x01F0,
        /// <summary>
        /// IBM PowerPC little endian with FPU
        /// </summary>
        POWERPCFP = 0x01f1,
        /// <summary>
        /// Itanium
        /// </summary>
        IA64 = 0x0200,
        /// <summary>
        /// MIPS
        /// </summary>
        MIPS16 = 0x0266,
        /// <summary>
        /// ALPHA AXP64
        /// </summary>
        ALPHA64 = 0x0284,
        /// <summary>
        /// MIPS with FPU
        /// </summary>
        MIPSFPU = 0x0366,
        /// <summary>
        /// MIPS16 with FPU
        /// </summary>
        MIPSFPU16 = 0x0466,
        /// <summary>
        /// Infineon
        /// </summary>
        TRICORE = 0x0520,
        /// <summary>
        /// CEF
        /// </summary>
        CEF = 0x0CEF,
        /// <summary>
        /// EBC
        /// </summary>
        EBC = 0x0EBC,
        /// <summary>
        /// AMD X64
        /// </summary>
        AMD64 = 0x8664,
        /// <summary>
        /// M32R little endian
        /// </summary>
        M32R = 0x9041,
        /// <summary>
        /// CEE
        /// </summary>
        CEE = 0xC0EE
    }

    /// <summary>
    /// Characteristics
    /// </summary>
    [Flags]
    public enum Characteristics : UInt16
    {
        /// <summary>
        /// RELOCS_STRIPPED
        /// </summary>
        RELOCS_STRIPPED = 0x0001,
        /// <summary>
        /// EXECUTABLE_IMAGE
        /// </summary>
        EXECUTABLE_IMAGE = 0x0002,
        /// <summary>
        /// LINE_NUMS_STRIPPED
        /// </summary>
        LINE_NUMS_STRIPPED = 0x0004,
        /// <summary>
        /// LOCAL_SYMS_STRIPPED
        /// </summary>
        LOCAL_SYMS_STRIPPED = 0x0008,
        /// <summary>
        /// AGGRESIVE_WS_TRIM
        /// </summary>
        AGGRESIVE_WS_TRIM = 0x0010,
        /// <summary>
        ///   LARGE_ADDRESS_AWARE
        /// </summary>
        LARGE_ADDRESS_AWARE = 0x0020,
        /// <summary>
        /// BYTES_REVERSED_LO
        /// </summary>
        BYTES_REVERSED_LO = 0x0080,
        /// <summary>
        /// BIT32_MACHINE
        /// </summary>
        BIT32_MACHINE = 0x0100,
        /// <summary>
        /// DEBUG_STRIPPED
        /// </summary>
        DEBUG_STRIPPED = 0x0200,
        /// <summary>
        /// REMOVABLE_RUN_FROM_SWAP
        /// </summary>
        REMOVABLE_RUN_FROM_SWAP = 0x0400,
        /// <summary>
        /// NET_RUN_FROM_SWAP
        /// </summary>
        NET_RUN_FROM_SWAP = 0x0800,
        /// <summary>
        /// SYSTEM
        /// </summary>
        SYSTEM = 0x1000,
        /// <summary>
        /// DLL
        /// </summary>
        DLL = 0x2000,
        /// <summary>
        /// UP_SYSTEM_ONLY
        /// </summary>
        UP_SYSTEM_ONLY = 0x4000,
        /// <summary>
        /// BYTES_REVERSED_HI
        /// </summary>
        BYTES_REVERSED_HI = 0x8000
    }
}
