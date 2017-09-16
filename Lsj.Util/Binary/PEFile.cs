using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Binary
{
    public class PEFile : DosExeFile
    {
        public PEFile(string path) : base(path)
        {
        }

        public NTHeader NTHeader
        {
            get;
            private set;
        }
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
    public struct NTHeader
    {
        public NTHeader(UInt16 signature, FileHeader fileheader)
        {
            this.signature = signature;
            this.FileHeader = fileheader;
        }
        public readonly UInt16 signature;
        public readonly FileHeader FileHeader;
    }
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct FileHeader
    {
        [FieldOffset(0x00)]
        unsafe fixed byte buffer[20];
        [FieldOffset(0x00)]
        Machine Machine;
        [FieldOffset(0x02)]
        UInt16 NumberOfSections;
        [FieldOffset(0x04)]
        UInt32 TimeDateStamp;
        [FieldOffset(0x08)]
        UInt32 PointerToSymbolTable;
        [FieldOffset(0x0C)]
        UInt32 NumberOfSymbols;
        [FieldOffset(0x10)]
        UInt16 SizeOfOptionalHeader;
        [FieldOffset(0x12)]
        Characteristics Characteristics;

    }
    public enum Machine : UInt16
    {
        UNKNOWN = 0,
        I386 = 0x014c,
        R3000 = 0x0162,
        R4000 = 0x0166,
        R10000 = 0x0168,
        WCEMIPSV2 = 0x0169,
        ALPHA = 0x0184,
        SH3 = 0x01a2,
        SH3DSP = 0x01a3,
        SH3E = 0x01a4,
        SH4 = 0x01a6,
        SH5 = 0x01a8,
        ARM = 0x01c0,
        THUMB = 0x01c2,
        AM33 = 0x01d3,
        POWERPC = 0x01F0,
        POWERPCFP = 0x01f1,
        IA64 = 0x0200,
        MIPS16 = 0x0266,
        ALPHA64 = 0x0284,
        MIPSFPU = 0x0366,
        MIPSFPU16 = 0x0466,
        AXP64 = 0x284,
        TRICORE = 0x0520,
        CEF = 0x0CEF,
        EBC = 0x0EBC,
        AMD64 = 0x8664,
        M32R = 0x9041,
        CEE = 0xC0EE
    }
    [Flags]
    public enum Characteristics : UInt16
    {
        RELOCS_STRIPPED = 0x0001,
        EXECUTABLE_IMAGE = 0x0002,
        LINE_NUMS_STRIPPED = 0x0004,
        LOCAL_SYMS_STRIPPED = 0x0008,
        AGGRESIVE_WS_TRIM = 0x0010,
        LARGE_ADDRESS_AWARE = 0x0020,
        BYTES_REVERSED_LO = 0x0080,
        BIT32_MACHINE = 0x0100,
        DEBUG_STRIPPED = 0x0200,
        REMOVABLE_RUN_FROM_SWAP = 0x0400,
        NET_RUN_FROM_SWAP = 0x0800,
        SYSTEM = 0x1000,
        DLL = 0x2000,
        UP_SYSTEM_ONLY = 0x4000,
        BYTES_REVERSED_HI = 0x8000
    }
}
