using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using Lsj.Util.Win32.Marshals.ByValStructs;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains processor-specific register data.
    /// The system uses <see cref="CONTEXT"/> structures to perform various internal operations.
    /// Refer to the header file WinNT.h for definitions of this structure for each processor architecture.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-context"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CONTEXT
    {
        /// <summary>
        /// P1Home
        /// </summary>
        [FieldOffset(0)]
        public DWORD64 P1Home;

        /// <summary>
        /// P2Home
        /// </summary>
        [FieldOffset(8)]
        public DWORD64 P2Home;

        /// <summary>
        /// P3Home
        /// </summary>
        [FieldOffset(16)]
        public DWORD64 P3Home;

        /// <summary>
        /// P4Home
        /// </summary>
        [FieldOffset(24)]
        public DWORD64 P4Home;

        /// <summary>
        /// P5Home
        /// </summary>
        [FieldOffset(32)]
        public DWORD64 P5Home;

        /// <summary>
        /// P6Home
        /// </summary>
        [FieldOffset(40)]
        public DWORD64 P6Home;

        /// <summary>
        /// ContextFlags
        /// </summary>
        [FieldOffset(48)]
        public DWORD ContextFlags;

        /// <summary>
        /// MxCsr
        /// </summary>
        [FieldOffset(52)]
        public DWORD MxCsr;

        /// <summary>
        /// SegCs
        /// </summary>
        [FieldOffset(56)]
        public WORD SegCs;

        /// <summary>
        /// SegDs
        /// </summary>
        [FieldOffset(58)]
        public WORD SegDs;

        /// <summary>
        /// SegEs
        /// </summary>
        [FieldOffset(60)]
        public WORD SegEs;

        /// <summary>
        /// SegFs
        /// </summary>
        [FieldOffset(62)]
        public WORD SegFs;

        /// <summary>
        /// SegGs
        /// </summary>
        [FieldOffset(64)]
        public WORD SegGs;

        /// <summary>
        /// SegSs
        /// </summary>
        [FieldOffset(66)]
        public WORD SegSs;

        /// <summary>
        /// EFlags
        /// </summary>
        [FieldOffset(68)]
        public DWORD EFlags;

        /// <summary>
        /// Dr0
        /// </summary>
        [FieldOffset(72)]
        public DWORD64 Dr0;

        /// <summary>
        /// Dr1
        /// </summary>
        [FieldOffset(80)]
        public DWORD64 Dr1;

        /// <summary>
        /// Dr2
        /// </summary>
        [FieldOffset(88)]
        public DWORD64 Dr2;

        /// <summary>
        /// Dr3
        /// </summary>
        [FieldOffset(96)]
        public DWORD64 Dr3;

        /// <summary>
        /// Dr6
        /// </summary>
        [FieldOffset(104)]
        public DWORD64 Dr6;

        /// <summary>
        /// Dr7
        /// </summary>
        [FieldOffset(112)]
        public DWORD64 Dr7;

        /// <summary>
        /// Rax
        /// </summary>
        [FieldOffset(120)]
        public DWORD64 Rax;

        /// <summary>
        /// Rcx
        /// </summary>
        [FieldOffset(128)]
        public DWORD64 Rcx;

        /// <summary>
        /// Rdx
        /// </summary>
        [FieldOffset(132)]
        public DWORD64 Rdx;

        /// <summary>
        /// Rbx
        /// </summary>
        [FieldOffset(140)]
        public DWORD64 Rbx;

        /// <summary>
        /// Rsp
        /// </summary>
        [FieldOffset(148)]
        public DWORD64 Rsp;

        /// <summary>
        /// Rbp
        /// </summary>
        [FieldOffset(156)]
        public DWORD64 Rbp;

        /// <summary>
        /// Rsi
        /// </summary>
        [FieldOffset(164)]
        public DWORD64 Rsi;

        /// <summary>
        /// Rdi
        /// </summary>
        [FieldOffset(172)]
        public DWORD64 Rdi;

        /// <summary>
        /// R8
        /// </summary>
        [FieldOffset(180)]
        public DWORD64 R8;

        /// <summary>
        /// R9
        /// </summary>
        [FieldOffset(188)]
        public DWORD64 R9;

        /// <summary>
        /// R10
        /// </summary>
        [FieldOffset(196)]
        public DWORD64 R10;

        /// <summary>
        /// R11
        /// </summary>
        [FieldOffset(204)]
        public DWORD64 R11;

        /// <summary>
        /// R12
        /// </summary>
        [FieldOffset(212)]
        public DWORD64 R12;

        /// <summary>
        /// R13
        /// </summary>
        [FieldOffset(220)]
        public DWORD64 R13;

        /// <summary>
        /// R14
        /// </summary>
        [FieldOffset(228)]
        public DWORD64 R14;

        /// <summary>
        /// R15
        /// </summary>
        [FieldOffset(232)]
        public DWORD64 R15;

        /// <summary>
        /// Rip
        /// </summary>
        [FieldOffset(240)]
        public DWORD64 Rip;

        /// <summary>
        /// FltSave
        /// </summary>
        [FieldOffset(248)]
        public XMM_SAVE_AREA32 FltSave;

        /// <summary>
        /// Q
        /// </summary>
        [FieldOffset(248)]
        public ByValNEON128ArrayStructForSize16 Q;

        /// <summary>
        /// D
        /// </summary>
        [FieldOffset(248)]
        public ByValULONGLONGArrayStructForSize32 D;

        /// <summary>
        /// Header
        /// </summary>
        [FieldOffset(248)]
        public ByValM128AArrayStructForSize2 Header;

        /// <summary>
        /// Legacy
        /// </summary>
        [FieldOffset(280)]

        public ByValM128AArrayStructForSize8 Legacy;

        /// <summary>
        /// Xmm0
        /// </summary>
        [FieldOffset(408)]
        public M128A Xmm0;

        /// <summary>
        /// Xmm1
        /// </summary>
        [FieldOffset(424)]
        public M128A Xmm1;

        /// <summary>
        /// Xmm2
        /// </summary>
        [FieldOffset(440)]
        public M128A Xmm2;

        /// <summary>
        /// Xmm3
        /// </summary>
        [FieldOffset(456)]
        public M128A Xmm3;

        /// <summary>
        /// Xmm4
        /// </summary>
        [FieldOffset(472)]
        public M128A Xmm4;

        /// <summary>
        /// Xmm5
        /// </summary>
        [FieldOffset(488)]
        public M128A Xmm5;

        /// <summary>
        /// Xmm6
        /// </summary>
        [FieldOffset(504)]
        public M128A Xmm6;

        /// <summary>
        /// Xmm7
        /// </summary>
        [FieldOffset(520)]
        public M128A Xmm7;

        /// <summary>
        /// Xmm8
        /// </summary>
        [FieldOffset(536)]
        public M128A Xmm8;

        /// <summary>
        /// Xmm9
        /// </summary>
        [FieldOffset(552)]
        public M128A Xmm9;

        /// <summary>
        /// Xmm10
        /// </summary>
        [FieldOffset(568)]
        public M128A Xmm10;

        /// <summary>
        /// Xmm11
        /// </summary>
        [FieldOffset(584)]
        public M128A Xmm11;

        /// <summary>
        /// Xmm12
        /// </summary>
        [FieldOffset(600)]
        public M128A Xmm12;

        /// <summary>
        /// Xmm13
        /// </summary>
        [FieldOffset(616)]
        public M128A Xmm13;

        /// <summary>
        /// Xmm14
        /// </summary>
        [FieldOffset(632)]
        public M128A Xmm14;

        /// <summary>
        /// Xmm15
        /// </summary>
        [FieldOffset(648)]
        public M128A Xmm15;

        /// <summary>
        /// S
        /// </summary>
        [FieldOffset(248)]
        public ByValDWORDArrayStructForSize32 S;

        /// <summary>
        /// VectorRegister
        /// </summary>
        [FieldOffset(760)]
        public ByValM128AArrayStructForSize26 VectorRegister;

        /// <summary>
        /// VectorControl
        /// </summary>
        [FieldOffset(1176)]
        public DWORD64 VectorControl;

        /// <summary>
        /// DebugControl
        /// </summary>
        [FieldOffset(1184)]
        public DWORD64 DebugControl;

        /// <summary>
        /// LastBranchToRip
        /// </summary>
        [FieldOffset(1192)]
        public DWORD64 LastBranchToRip;

        /// <summary>
        /// LastBranchFromRip
        /// </summary>
        [FieldOffset(1200)]
        public DWORD64 LastBranchFromRip;

        /// <summary>
        /// LastExceptionToRip
        /// </summary>
        [FieldOffset(1208)]
        public DWORD64 LastExceptionToRip;

        /// <summary>
        /// LastExceptionFromRip
        /// </summary>
        [FieldOffset(1216)]
        public DWORD64 LastExceptionFromRip;
    }
}
