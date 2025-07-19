using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains processor-specific register data.
    /// The system uses <see cref="CONTEXT"/> structures to perform various internal operations.
    /// The structure definition varies for different processor architectures.
    /// This page applies to the 64-bit x86 architecture.
    /// The following table links to the structures for other architectures.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-context"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CONTEXT
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public DWORD64 P1Home;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public DWORD64 P2Home;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(16)]
        public DWORD64 P3Home;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(24)]
        public DWORD64 P4Home;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(32)]
        public DWORD64 P5Home;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(40)]
        public DWORD64 P6Home;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(48)]
        public DWORD ContextFlags;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(52)]
        public DWORD MxCsr;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(56)]
        public WORD SegCs;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(58)]
        public WORD SegDs;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(60)]
        public WORD SegEs;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(62)]
        public WORD SegFs;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(64)]
        public WORD SegGs;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(66)]
        public WORD SegSs;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(68)]
        public DWORD EFlags;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(72)]
        public DWORD64 Dr0;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(80)]
        public DWORD64 Dr1;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(88)]
        public DWORD64 Dr2;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(96)]
        public DWORD64 Dr3;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(104)]
        public DWORD64 Dr6;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(112)]
        public DWORD64 Dr7;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(120)]
        public DWORD64 Rax;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(128)]
        public DWORD64 Rcx;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(132)]
        public DWORD64 Rdx;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(140)]
        public DWORD64 Rbx;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(148)]
        public DWORD64 Rsp;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(156)]
        public DWORD64 Rbp;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(164)]
        public DWORD64 Rsi;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(172)]
        public DWORD64 Rdi;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(180)]
        public DWORD64 R8;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(188)]
        public DWORD64 R9;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(196)]
        public DWORD64 R10;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(204)]
        public DWORD64 R11;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(212)]
        public DWORD64 R12;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(220)]
        public DWORD64 R13;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(228)]
        public DWORD64 R14;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(232)]
        public DWORD64 R15;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(240)]
        public DWORD64 Rip;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(248)]
        public XMM_SAVE_AREA32 FltSave;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(248)]
        public ByValNEON128ArrayStructForSize16 Q;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(248)]
        public ByValULONGLONGArrayStructForSize32 D;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(248)]
        public ByValM128AArrayStructForSize2 Header;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(280)]

        public ByValM128AArrayStructForSize8 Legacy;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(408)]
        public M128A Xmm0;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(424)]
        public M128A Xmm1;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(440)]
        public M128A Xmm2;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(456)]
        public M128A Xmm3;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(472)]
        public M128A Xmm4;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(488)]
        public M128A Xmm5;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(504)]
        public M128A Xmm6;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(520)]
        public M128A Xmm7;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(536)]
        public M128A Xmm8;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(552)]
        public M128A Xmm9;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(568)]
        public M128A Xmm10;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(584)]
        public M128A Xmm11;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(600)]
        public M128A Xmm12;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(616)]
        public M128A Xmm13;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(632)]
        public M128A Xmm14;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(648)]
        public M128A Xmm15;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(248)]
        public ByValDWORDArrayStructForSize32 S;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(760)]
        public ByValM128AArrayStructForSize26 VectorRegister;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1176)]
        public DWORD64 VectorControl;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1184)]
        public DWORD64 DebugControl;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1192)]
        public DWORD64 LastBranchToRip;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1200)]
        public DWORD64 LastBranchFromRip;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1208)]
        public DWORD64 LastExceptionToRip;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1216)]
        public DWORD64 LastExceptionFromRip;
    }
}
