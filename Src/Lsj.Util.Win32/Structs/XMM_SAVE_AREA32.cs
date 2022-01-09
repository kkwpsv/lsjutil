using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// XMM_SAVE_AREA32
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct XMM_SAVE_AREA32
    {
        /// <summary>
        /// ControlWord
        /// </summary>
        [FieldOffset(0)]
        public WORD ControlWord;

        /// <summary>
        /// StatusWord
        /// </summary>
        [FieldOffset(2)]
        public WORD StatusWord;

        /// <summary>
        /// TagWord
        /// </summary>
        [FieldOffset(4)]
        public BYTE TagWord;

        /// <summary>
        /// Reserved1
        /// </summary>
        [FieldOffset(5)]
        public BYTE Reserved1;

        /// <summary>
        /// ErrorOpcode
        /// </summary>
        [FieldOffset(6)]
        public WORD ErrorOpcode;

        /// <summary>
        /// ErrorOffset
        /// </summary>
        [FieldOffset(8)]
        public DWORD ErrorOffset;

        /// <summary>
        /// ErrorSelector
        /// </summary>
        [FieldOffset(12)]
        public WORD ErrorSelector;

        /// <summary>
        /// Reserved2
        /// </summary>
        [FieldOffset(14)]
        public WORD Reserved2;

        /// <summary>
        /// DataOffset
        /// </summary>
        [FieldOffset(16)]
        public DWORD DataOffset;

        /// <summary>
        /// DataSelector
        /// </summary>
        [FieldOffset(20)]
        public WORD DataSelector;

        /// <summary>
        /// Reserved3
        /// </summary>
        [FieldOffset(22)]
        public WORD Reserved3;

        /// <summary>
        /// MxCsr
        /// </summary>
        [FieldOffset(24)]
        public DWORD MxCsr;

        /// <summary>
        /// MxCsr_Mask
        /// </summary>
        [FieldOffset(28)]
        public DWORD MxCsr_Mask;

        /// <summary>
        /// FloatRegisters
        /// </summary>
        [FieldOffset(32)]
        public ByValM128AArrayStructForSize8 FloatRegisters;

        /// <summary>
        /// XmmRegisters
        /// </summary>
        [FieldOffset(160)]
        public ByValM128AArrayStructForSize8 XmmRegisters_x86;

        /// <summary>
        /// Reserved4
        /// </summary>
        [FieldOffset(288)]
        public ByValBYTEArrayStructForSize224 Reserved4_x86;

        /// <summary>
        /// XmmRegisters
        /// </summary>
        [FieldOffset(160)]
        public ByValM128AArrayStructForSize16 XmmRegisters_x64;

        /// <summary>
        /// Reserved4
        /// </summary>
        [FieldOffset(416)]
        public ByValBYTEArrayStructForSize96 Reserved4_x64;

    }
}
