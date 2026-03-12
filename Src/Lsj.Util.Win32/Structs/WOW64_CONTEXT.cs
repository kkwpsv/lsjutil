using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a context frame on WOW64.
    /// Refer to the header file WinNT.h for the definition of this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-wow64_context"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// In the following versions of Windows, Slot 1 of Thread Local Storage (TLS) holds a pointer to a structure
    /// that contains a <see cref="WOW64_CONTEXT"/> structure starting at offset 4.
    /// This might change in later versions of Windows.
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Windows Vista
    /// </term>
    /// <term>
    /// Windows Server 2008
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Windows 7
    /// </term>
    /// <term>
    /// Windows Server 2008 R2
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows 8
    /// </term>
    /// <term>
    /// Windows Server 2012
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Windows 8.1
    /// </term>
    /// <term>
    /// Windows Server 2012 R2
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WOW64_CONTEXT
    {
        /// <summary>
        /// 
        /// </summary>
        public DWORD ContextFlags;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Dr0;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Dr1;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Dr2;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Dr3;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Dr6;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Dr7;

        /// <summary>
        /// 
        /// </summary>
        public WOW64_FLOATING_SAVE_AREA FloatSave;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SegGs;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SegFs;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SegEs;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SegDs;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Edi;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Esi;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Ebx;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Edx;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Ecx;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Eax;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Ebp;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Eip;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SegCs;

        /// <summary>
        /// 
        /// </summary>
        public DWORD EFlags;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Esp;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SegSs;

        /// <summary>
        /// 
        /// </summary>
        public ByValBYTEArrayStructForSize512 ExtendedRegisters;
    }
}
