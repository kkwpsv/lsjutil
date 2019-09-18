using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using WORD = System.UInt16;
using DWORD = System.UInt32;

namespace Lsj.Util.Binary
{
    /// <summary>
    /// PEFile
    /// </summary>
    public class PEFile : DosExeFile
    {
        /// <summary>
        /// NTHeader
        /// </summary>
        public NTHeader NTHeader
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Binary.PEFile"/> class.
        /// </summary>
        /// <param name="path">File Path</param>
        public PEFile(string path) : base(path)
        {
        }

        /// <summary>
        /// Read
        /// </summary>
        protected override bool Read()
        {
            if (base.Read())
            {
                var ntHeaderOffset = DosHeader.e_lfanew;
                if (ntHeaderOffset != 0)
                {
                    var ntHeader = new NTHeader();
                    _file.Seek(ntHeaderOffset, SeekOrigin.Begin);

                    var buffer = new byte[0x18];
                    _file.Read(buffer, 0, 0x18);

                    unsafe
                    {
                        UnsafeHelper.Copy(buffer, ntHeader.buffer, 0x18);
                    }

                    if (ntHeader.Signature == 0x4550)//PE
                    {
                        if (ntHeader.FileHeader.SizeOfOptionalHeader != 0)
                        {

                        }

                        NTHeader = ntHeader;
                        return true;
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// NTHeader
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NTHeader
    {
        [FieldOffset(0x00)]
        internal unsafe fixed byte buffer[0x18];

        /// <summary>
        /// Signature
        /// </summary>
        [FieldOffset(0x00)]
        public readonly DWORD Signature;

        /// <summary>
        /// FileHeader
        /// </summary>
        [FieldOffset(0x04)]
        public readonly ImageFileHeader FileHeader;
    }

    /// <summary>
    /// FileHeader
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct ImageFileHeader
    {
        [FieldOffset(0x00)]
        internal unsafe fixed byte buffer[20];

        /// <summary>
        /// Machine
        /// </summary>
        [FieldOffset(0x00)]
        public readonly Machine Machine;

        /// <summary>
        /// Number Of Sections
        /// </summary>
        [FieldOffset(0x02)]
        public readonly WORD NumberOfSections;

        /// <summary>
        /// Time Date Stamp
        /// </summary>
        [FieldOffset(0x04)]
        public readonly DWORD TimeDateStamp;

        /// <summary>
        /// Pointer To Symbol Table
        /// </summary>
        [FieldOffset(0x08)]
        public readonly DWORD PointerToSymbolTable;

        /// <summary>
        /// Number Of Symbols
        /// </summary>
        [FieldOffset(0x0C)]
        public readonly DWORD NumberOfSymbols;

        /// <summary>
        /// Size Of Optional Header
        /// </summary>
        [FieldOffset(0x10)]
        public readonly WORD SizeOfOptionalHeader;

        /// <summary>
        /// Characteristics
        /// </summary>
        [FieldOffset(0x12)]
        public readonly Characteristics Characteristics;

    }

    /// <summary>
    /// Machine
    /// </summary>
    public enum Machine : WORD
    {
        /// <summary>
        /// Unknown
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        /// Useful for indicating we want to interact with the host and not a WoW guest.
        /// </summary>
        TARGET_HOST = 0x0001,

        /// <summary>
        /// Intel 386.
        /// </summary>
        I386 = 0x014c,

        /// <summary>
        /// MIPS little-endian, 0x160 big-endian
        /// </summary>
        R3000 = 0x0162,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R4000 = 0x0166,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R10000 = 0x0168,

        /// <summary>
        /// MIPS little-endian WCE v2
        /// </summary>
        WCEMIPSV2 = 0x0169,

        /// <summary>
        /// Alpha_AXP
        /// </summary>
        ALPHA = 0x0184,

        /// <summary>
        /// SH3 little-endian
        /// </summary>
        SH3 = 0x01a2,

        /// <summary>
        /// SH3DSP
        /// </summary>
        SH3DSP = 0x01a3,

        /// <summary>
        /// SH3E little-endian
        /// </summary>
        SH3E = 0x01a4,

        /// <summary>
        /// SH4 little-endian
        /// </summary>
        SH4 = 0x01a6,

        /// <summary>
        /// SH5
        /// </summary>
        SH5 = 0x01a8,

        /// <summary>
        /// ARM Little-Endian
        /// </summary>
        ARM = 0x01c0,

        /// <summary>
        /// ARM Thumb/Thumb-2 Little-Endian
        /// </summary>
        THUMB = 0x01c2,

        /// <summary>
        /// ARM Thumb-2 Little-Endian
        /// </summary>
        ARMNT = 0x01c4,

        /// <summary>
        /// AM33
        /// </summary>
        AM33 = 0x01d3,

        /// <summary>
        /// IBM PowerPC Little-Endian
        /// </summary>
        POWERPC = 0x01F0,

        /// <summary>
        /// IBM PowerPC Little-Endian with FPU
        /// </summary>
        POWERPCFP = 0x01f1,

        /// <summary>
        /// Intel 64
        /// </summary>
        IA64 = 0x0200,

        /// <summary>
        /// MIPS
        /// </summary>
        MIPS16 = 0x0266,

        /// <summary>
        /// ALPHA64
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
        /// AXP64
        /// </summary>
        AXP64 = ALPHA64,

        /// <summary>
        /// Infineon
        /// </summary>
        TRICORE = 0x0520,

        /// <summary>
        /// CEF
        /// </summary>
        CEF = 0x0CEF,

        /// <summary>
        /// EFI Byte Code
        /// </summary>
        EBC = 0x0EBC,

        /// <summary>
        /// AMD64 (K8)
        /// </summary>
        AMD64 = 0x8664,

        /// <summary>
        /// M32R little-endian
        /// </summary>
        M32R = 0x9041,

        /// <summary>
        /// ARM64 Little-Endian
        /// </summary>
        ARM64 = 0xAA64,

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
        /// Relocation info stripped from file.
        /// </summary>
        RELOCS_STRIPPED = 0x0001,

        /// <summary>
        ///  File is executable  (i.e. no unresolved external references).
        /// </summary>
        EXECUTABLE_IMAGE = 0x0002,

        /// <summary>
        ///  Line nunbers stripped from file.
        /// </summary>
        LINE_NUMS_STRIPPED = 0x0004,

        /// <summary>
        /// Local symbols stripped from file.
        /// </summary>
        LOCAL_SYMS_STRIPPED = 0x0008,


        /// <summary>
        /// Aggressively trim working set
        /// </summary>
        AGGRESIVE_WS_TRIM = 0x0010,

        /// <summary>
        /// App can handle >2gb addresses
        /// </summary>
        LARGE_ADDRESS_AWARE = 0x0020,

        /// <summary>
        /// Bytes of machine word are reversed.
        /// </summary>
        BYTES_REVERSED_LO = 0x0080,

        /// <summary>
        /// 32 bit word machine.
        /// </summary>
        BIT32_MACHINE = 0x0100,

        /// <summary>
        /// Debugging info stripped from file in .DBG file
        /// </summary>
        DEBUG_STRIPPED = 0x0200,

        /// <summary>
        /// If Image is on removable media, copy and run from the swap file.
        /// </summary>
        REMOVABLE_RUN_FROM_SWAP = 0x0400,

        /// <summary>
        /// If Image is on Net, copy and run from the swap file.
        /// </summary>
        NET_RUN_FROM_SWAP = 0x0800,

        /// <summary>
        /// System File.
        /// </summary>
        SYSTEM = 0x1000,

        /// <summary>
        /// File is a DLL.
        /// </summary>
        DLL = 0x2000,

        /// <summary>
        /// File should only be run on a UP machine
        /// </summary>
        UP_SYSTEM_ONLY = 0x4000,

        /// <summary>
        /// Bytes of machine word are reversed.
        /// </summary>
        BYTES_REVERSED_HI = 0x8000
    }
}
