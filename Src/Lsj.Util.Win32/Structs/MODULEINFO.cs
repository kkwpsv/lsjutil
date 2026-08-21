using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the module load address, size, and entry point.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-moduleinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The load address of a module is the same as the <see cref="HMODULE"/> value.
    /// The information returned in the <see cref="SizeOfImage"/> and <see cref="EntryPoint"/> members comes from the module's Portable Executable (PE) header.
    /// The module entry point is the location called during process startup, thread startup, process shutdown, and thread shutdown.
    /// While this is not the address of the <c>DllMain</c> function, it should be close enough for most purposes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MODULEINFO
    {
        /// <summary>
        /// The load address of the module.
        /// </summary>
        public LPVOID lpBaseOfDll;

        /// <summary>
        /// The size of the linear space that the module occupies, in bytes.
        /// </summary>
        public DWORD SizeOfImage;

        /// <summary>
        /// The entry point of the module.
        /// </summary>
        public LPVOID EntryPoint;
    }
}
