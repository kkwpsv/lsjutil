using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// XMM_SAVE_AREA32
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 16)]
    public struct XMM_SAVE_AREA32
    {
        /// <summary>
        /// ControlWord
        /// </summary>
        public WORD ControlWord;

        /// <summary>
        /// StatusWord
        /// </summary>
        public WORD StatusWord;

        /// <summary>
        /// TagWord
        /// </summary>
        public BYTE TagWord;

        /// <summary>
        /// Reserved1
        /// </summary>
        public BYTE Reserved1;

        /// <summary>
        /// ErrorOpcode
        /// </summary>
        public WORD ErrorOpcode;

        /// <summary>
        /// ErrorOffset
        /// </summary>
        public DWORD ErrorOffset;

        /// <summary>
        /// ErrorSelector
        /// </summary>
        public WORD ErrorSelector;

        /// <summary>
        /// Reserved2
        /// </summary>
        public WORD Reserved2;

        /// <summary>
        /// DataOffset
        /// </summary>
        public DWORD DataOffset;

        /// <summary>
        /// DataSelector
        /// </summary>
        public WORD DataSelector;

        /// <summary>
        /// Reserved3
        /// </summary>
        public WORD Reserved3;

        /// <summary>
        /// MxCsr
        /// </summary>
        public DWORD MxCsr;

        /// <summary>
        /// MxCsr_Mask
        /// </summary>
        public DWORD MxCsr_Mask;

        /// <summary>
        /// FloatRegisters
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public M128A[] FloatRegisters;

        private UnionStruct<UnionStructx86, UnionStructx64> unionStruct;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct UnionStructx86
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public M128A[] XmmRegisters;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
            public BYTE[] Reserved4;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct UnionStructx64
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public M128A[] XmmRegisters;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
            public BYTE[] Reserved4;
        }
    }
}
