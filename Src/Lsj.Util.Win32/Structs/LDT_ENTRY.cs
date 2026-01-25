using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an entry in the descriptor table.
    /// This structure is valid only on x86-based systems.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-ldt_entry"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="GetThreadSelectorEntry"/> function fills this structure with information from an entry in the descriptor table.
    /// You can use this information to convert a segment-relative address to a linear virtual address.
    /// </para>
    /// <para>
    /// The base address of a segment is the address of offset 0 in the segment.
    /// To calculate this value, combine the <see cref="BaseLow"/>, <see cref="LDT_ENTRY_HighWord_Bytes.BaseMid"/>,
    /// and <see cref="LDT_ENTRY_HighWord_Bytes.BaseHi"/> members.
    /// </para>
    /// <para>
    /// The limit of a segment is the address of the last byte that can be addressed in the segment.
    /// To calculate this value, combine the <see cref="LimitLow"/> and <see cref="LDT_ENTRY_HighWord_Bits.LimitHi"/> members.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LDT_ENTRY
    {
        /// <summary>
        /// The low-order part of the address of the last byte in the segment.
        /// </summary>
        public WORD LimitLow;

        /// <summary>
        /// The low-order part of the base address of the segment.
        /// </summary>
        public WORD BaseLow;

        /// <summary>
        /// The high-order portion of the descriptor.
        /// This member may be interpreted as bytes or collections of bits, depending on the level of detail required.
        /// </summary>
        public LDT_ENTRY_HighWord HighWord;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct LDT_ENTRY_HighWord
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public LDT_ENTRY_HighWord_Bytes Bytes;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public LDT_ENTRY_HighWord_Bits Bits;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LDT_ENTRY_HighWord_Bytes
        {
            /// <summary>
            /// Middle bits (16–23) of the base address of the segment.
            /// </summary>
            public BYTE BaseMid;

            /// <summary>
            /// Values of the <see cref="LDT_ENTRY_HighWord_Bits.Type"/>, <see cref="LDT_ENTRY_HighWord_Bits.Dpl"/>,
            /// and <see cref="LDT_ENTRY_HighWord_Bits.Pres"/> members in the <see cref="LDT_ENTRY_HighWord_Bits"/> structure.
            /// </summary>
            public BYTE Flags1;

            /// <summary>
            /// Values of the <see cref="LDT_ENTRY_HighWord_Bits.LimitHi"/>, <see cref="LDT_ENTRY_HighWord_Bits.Sys"/>,
            /// <see cref="LDT_ENTRY_HighWord_Bits.Reserved0"/>, <see cref="LDT_ENTRY_HighWord_Bits.DefaultBig"/>,
            /// and <see cref="LDT_ENTRY_HighWord_Bits.Granularity "/> members in the <see cref="LDT_ENTRY_HighWord_Bits"/> structure.
            /// </summary>
            public BYTE Flags2;

            /// <summary>
            /// High bits (24–31) of the base address of the segment.
            /// </summary>
            public BYTE BaseHi;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LDT_ENTRY_HighWord_Bits
        {
            private uint _value;

            /// <summary>
            /// The middle bits (16–23) of the base address of the segment.
            /// </summary>
            public DWORD BaseMid
            {
                get => (_value >> 0) & 0xFFu;
                set => _value = (_value & ~0x000000FFu) | (value & 0xFFu);
            }

            /// <summary>
            /// The type of segment.
            /// This member can be one of the following values:
            /// </summary>
            public DWORD Type
            {
                get => (_value >> 8) & 0x1Fu;
                set => _value = (_value & ~0x00001F00u) | ((value & 0x1Fu) << 8);
            }

            /// <summary>
            /// The privilege level of the descriptor.
            /// This member is an integer value in the range 0 (most privileged) through 3 (least privileged).
            /// </summary>
            public DWORD Dpl
            {
                get => (_value >> 13) & 0x03u;
                set => _value = (_value & ~0x00006000u) | ((value & 0x03u) << 13);
            }

            /// <summary>
            /// The present flag.
            /// This member is 1 if the segment is present in physical memory or 0 if it is not.
            /// </summary>
            public DWORD Pres
            {
                get => (_value >> 15) & 0x01u;
                set => _value = (_value & ~0x00008000u) | ((value & 0x01u) << 15);
            }

            /// <summary>
            /// The high bits (16–19) of the address of the last byte in the segment.
            /// </summary>
            public DWORD LimitHi
            {
                get => (_value >> 16) & 0x0Fu;
                set => _value = (_value & ~0x000F0000u) | ((value & 0x0Fu) << 16);
            }

            /// <summary>
            /// The space that is available to system programmers.
            /// This member might be used for marking segments in some system-specific way.
            /// </summary>
            public DWORD Sys
            {
                get => (_value >> 20) & 0x01u;
                set => _value = (_value & ~0x00100000u) | ((value & 0x01u) << 20);
            }

            /// <summary>
            /// Reserved.
            /// </summary>
            public DWORD Reserved0
            {
                get => (_value >> 21) & 0x01u;
                set => _value = (_value & ~0x00200000u) | ((value & 0x01u) << 21);
            }

            /// <summary>
            /// <para>
            /// The size of segment.
            /// If the segment is a data segment,
            /// this member contains 1 if the segment is larger than 64 kilobytes (K) or 0 if the segment is smaller than or equal to 64K.
            /// </para>
            /// <para>
            /// If the segment is a code segment, 
            /// this member contains 1 if the segment is a code segment and runs with the default (native mode) instruction set.
            /// This member contains 0 if the code segment is an 80286 code segment
            /// and runs with 16-bit offsets and the 80286-compatible instruction set.
            /// </para>
            /// </summary>
            public DWORD DefaultBig
            {
                get => (_value >> 22) & 0x01u;
                set => _value = (_value & ~0x00400000u) | ((value & 0x01u) << 22);
            }

            /// <summary>
            /// The granularity.
            /// This member contains 0 if the segment is byte granular, 1 if the segment is page granular.
            /// </summary>
            public DWORD Granularity
            {
                get => (_value >> 23) & 0x01u;
                set => _value = (_value & ~0x00800000u) | ((value & 0x01u) << 23);
            }

            /// <summary>
            /// The high bits (24–31) of the base address of the segment.
            /// </summary>
            public DWORD BaseHi
            {
                get => (_value >> 24) & 0xFFu;
                set => _value = (_value & ~0xFF000000u) | ((value & 0xFFu) << 24);
            }
        }
    }
}
