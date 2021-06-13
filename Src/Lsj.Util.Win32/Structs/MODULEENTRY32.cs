using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an entry from a list of the modules belonging to the specified process.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/ns-tlhelp32-moduleentry32w"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="modBaseAddr"/> and <see cref="hModule"/> members are valid only
    /// in the context of the process specified by <see cref="th32ProcessID"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MODULEENTRY32
    {
        /// <summary>
        /// MAX_MODULE_NAME32
        /// </summary>
        public const int MAX_MODULE_NAME32 = 255;

        /// <summary>
        /// The size of the structure, in bytes.
        /// Before calling the <see cref="Module32First"/> function, set this member to <code>sizeof(MODULEENTRY32)</code>.
        /// If you do not initialize <see cref="dwSize"/>, <see cref="Module32First"/> fails.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// This member is no longer used, and is always set to one.
        /// </summary>
        public DWORD th32ModuleID;

        /// <summary>
        /// The identifier of the process whose modules are to be examined.
        /// </summary>
        public DWORD th32ProcessID;

        /// <summary>
        /// The load count of the module, which is not generally meaningful, and usually equal to 0xFFFF.
        /// </summary>
        public DWORD GlblcntUsage;

        /// <summary>
        /// The load count of the module (same as GlblcntUsage), which is not generally meaningful, and usually equal to 0xFFFF.
        /// </summary>
        public DWORD ProccntUsage;

        /// <summary>
        /// The base address of the module in the context of the owning process.
        /// </summary>
        public IntPtr modBaseAddr;

        /// <summary>
        /// The size of the module, in bytes.
        /// </summary>
        public DWORD modBaseSize;

        /// <summary>
        /// A handle to the module in the context of the owning process.
        /// </summary>
        public HMODULE hModule;

        /// <summary>
        /// The module name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_MODULE_NAME32 + 1)]
        public string szModule;

        /// <summary>
        /// The module path.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExePath;
    }
}
