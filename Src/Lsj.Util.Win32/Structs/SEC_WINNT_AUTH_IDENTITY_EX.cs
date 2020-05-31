using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SEC_WINNT_AUTH_IDENTITY_EX
    {
        /// <summary>
        /// 
        /// </summary>
        public uint Version;

        /// <summary>
        /// 
        /// </summary>
        public uint Length;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr User;

        /// <summary>
        /// 
        /// </summary>
        public uint UserLength;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Domain;

        /// <summary>
        /// 
        /// </summary>
        public uint DomainLength;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Password;

        /// <summary>
        /// 
        /// </summary>
        public uint PasswordLength;

        /// <summary>
        /// 
        /// </summary>
        public uint Flags;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr PackageList;

        /// <summary>
        /// 
        /// </summary>
        public uint PackageListLength;
    }
}
