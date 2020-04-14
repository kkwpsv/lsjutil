using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains processor-specific register data.
    /// The system uses <see cref="CONTEXT"/> structures to perform various internal operations.
    /// Refer to the header file WinNT.h for definitions of this structure for each processor architecture.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-context
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONTEXT
    {
        /// <summary>
        /// P1Home
        /// </summary>
        public DWORD64 P1Home;

        /// <summary>
        /// P2Home
        /// </summary>
        public DWORD64 P2Home;

        /// <summary>
        /// P3Home
        /// </summary>
        public DWORD64 P3Home;

        /// <summary>
        /// P4Home
        /// </summary>
        public DWORD64 P4Home;

        /// <summary>
        /// P5Home
        /// </summary>
        public DWORD64 P5Home;

        /// <summary>
        /// P6Home
        /// </summary>
        public DWORD64 P6Home;

        /// <summary>
        /// ContextFlags
        /// </summary>
        public DWORD ContextFlags;

        /// <summary>
        /// MxCsr
        /// </summary>
        public DWORD MxCsr;

        /// <summary>
        /// SegCs
        /// </summary>
        public WORD SegCs;

        /// <summary>
        /// SegDs
        /// </summary>
        public WORD SegDs;

        /// <summary>
        /// SegEs
        /// </summary>
        public WORD SegEs;

        /// <summary>
        /// SegFs
        /// </summary>
        public WORD SegFs;

        /// <summary>
        /// SegGs
        /// </summary>
        public WORD SegGs;

        /// <summary>
        /// SegSs
        /// </summary>
        public WORD SegSs;

        /// <summary>
        /// EFlags
        /// </summary>
        public DWORD EFlags;

        /// <summary>
        /// Dr0
        /// </summary>
        public DWORD64 Dr0;

        /// <summary>
        /// Dr1
        /// </summary>
        public DWORD64 Dr1;

        /// <summary>
        /// Dr2
        /// </summary>
        public DWORD64 Dr2;

        /// <summary>
        /// Dr3
        /// </summary>
        public DWORD64 Dr3;

        /// <summary>
        /// Dr6
        /// </summary>
        public DWORD64 Dr6;

        /// <summary>
        /// Dr7
        /// </summary>
        public DWORD64 Dr7;

        /// <summary>
        /// Rax
        /// </summary>
        public DWORD64 Rax;

        /// <summary>
        /// Rcx
        /// </summary>
        public DWORD64 Rcx;

        /// <summary>
        /// Rdx
        /// </summary>
        public DWORD64 Rdx;

        /// <summary>
        /// Rbx
        /// </summary>
        public DWORD64 Rbx;

        /// <summary>
        /// Rsp
        /// </summary>
        public DWORD64 Rsp;

        /// <summary>
        /// Rbp
        /// </summary>
        public DWORD64 Rbp;

        /// <summary>
        /// Rsi
        /// </summary>
        public DWORD64 Rsi;

        /// <summary>
        /// Rdi
        /// </summary>
        public DWORD64 Rdi;

        /// <summary>
        /// R8
        /// </summary>
        public DWORD64 R8;

        /// <summary>
        /// R9
        /// </summary>
        public DWORD64 R9;

        /// <summary>
        /// R10
        /// </summary>
        public DWORD64 R10;

        /// <summary>
        /// R11
        /// </summary>
        public DWORD64 R11;

        /// <summary>
        /// R12
        /// </summary>
        public DWORD64 R12;

        /// <summary>
        /// R13
        /// </summary>
        public DWORD64 R13;

        /// <summary>
        /// R14
        /// </summary>
        public DWORD64 R14;

        /// <summary>
        /// R15
        /// </summary>
        public DWORD64 R15;

        /// <summary>
        /// Rip
        /// </summary>
        public DWORD64 Rip;

        /// <summary>
        /// 
        /// </summary>
        public UnionStruct DUMMYUNIONNAME;

        /// <summary>
        /// VectorRegister
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public M128A[] VectorRegister;

        /// <summary>
        /// VectorControl
        /// </summary>
        public DWORD64 VectorControl;

        /// <summary>
        /// DebugControl
        /// </summary>
        public DWORD64 DebugControl;

        /// <summary>
        /// LastBranchToRip
        /// </summary>
        public DWORD64 LastBranchToRip;

        /// <summary>
        /// LastBranchFromRip
        /// </summary>
        public DWORD64 LastBranchFromRip;

        /// <summary>
        /// LastExceptionToRip
        /// </summary>
        public DWORD64 LastExceptionToRip;

        /// <summary>
        /// LastExceptionFromRip
        /// </summary>
        public DWORD64 LastExceptionFromRip;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct UnionStruct
        {
            [FieldOffset(0)]
            public XMM_SAVE_AREA32 FltSave;

            //NEON128 Q[16];

            /// <summary>
            /// D
            /// </summary>
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ULONGLONG[] D;

            /// <summary>
            /// DUMMYSTRUCTNAME
            /// </summary>
            [FieldOffset(0)]
            public InternalStruct DUMMYSTRUCTNAME;


            /// <summary>
            /// S
            /// </summary>
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public DWORD[] S;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct InternalStruct
        {
            /// <summary>
            /// Header
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public M128A[] Header;

            /// <summary>
            /// Legacy
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public M128A[] Legacy;

            /// <summary>
            /// Xmm0
            /// </summary>
            public M128A Xmm0;

            /// <summary>
            /// Xmm1
            /// </summary>
            public M128A Xmm1;

            /// <summary>
            /// Xmm2
            /// </summary>
            public M128A Xmm2;

            /// <summary>
            /// Xmm3
            /// </summary>
            public M128A Xmm3;

            /// <summary>
            /// Xmm4
            /// </summary>
            public M128A Xmm4;

            /// <summary>
            /// Xmm5
            /// </summary>
            public M128A Xmm5;

            /// <summary>
            /// Xmm6
            /// </summary>
            public M128A Xmm6;

            /// <summary>
            /// Xmm7
            /// </summary>
            public M128A Xmm7;

            /// <summary>
            /// Xmm8
            /// </summary>
            public M128A Xmm8;

            /// <summary>
            /// Xmm9
            /// </summary>
            public M128A Xmm9;

            /// <summary>
            /// Xmm10
            /// </summary>
            public M128A Xmm10;

            /// <summary>
            /// Xmm11
            /// </summary>
            public M128A Xmm11;

            /// <summary>
            /// Xmm12
            /// </summary>
            public M128A Xmm12;

            /// <summary>
            /// Xmm13
            /// </summary>
            public M128A Xmm13;

            /// <summary>
            /// Xmm14
            /// </summary>
            public M128A Xmm14;

            /// <summary>
            /// Xmm15
            /// </summary>
            public M128A Xmm15;
        }

    }
}
