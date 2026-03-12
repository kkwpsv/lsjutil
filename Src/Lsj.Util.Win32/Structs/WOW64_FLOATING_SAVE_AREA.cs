using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents the 80387 save area on WOW64. Refer to the header file WinNT.h for the definition of this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-wow64_floating_save_area"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WOW64_FLOATING_SAVE_AREA
    {
        /// <summary>
        /// 
        /// </summary>
       public DWORD ControlWord;

        /// <summary>
        /// 
        /// </summary>
        public DWORD StatusWord;

        /// <summary>
        /// 
        /// </summary>
        public DWORD TagWord;

        /// <summary>
        /// 
        /// </summary>
        public DWORD ErrorOffset;

        /// <summary>
        /// 
        /// </summary>
        public DWORD ErrorSelector;

        /// <summary>
        /// 
        /// </summary>
        public DWORD DataOffset;

        /// <summary>
        /// 
        /// </summary>
        public DWORD DataSelector;

        /// <summary>
        /// 
        /// </summary>
        public ByValBYTEArrayStructForSize80 RegisterArea;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Cr0NpxState;
    }
}
