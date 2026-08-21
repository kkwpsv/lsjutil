using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a registry value.
    /// The <see cref="RegQueryMultipleValues"/> function uses this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/ns-winreg-valentw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct VALENT
    {
        /// <summary>
        /// The name of the value to be retrieved.
        /// Be sure to set this member before calling <see cref="RegQueryMultipleValues"/>.
        /// </summary>
        public nint ve_valuename;

        /// <summary>
        /// The size of the data pointed to by <see cref="ve_valueptr"/>, in bytes.
        /// </summary>
        public DWORD ve_valuelen;

        /// <summary>
        /// A pointer to the data for the value entry.
        /// This is a pointer to the value's data returned in the <c>lpValueBuf</c> buffer filled in by <see cref="RegQueryMultipleValues"/>.
        /// </summary>
        public DWORD_PTR ve_valueptr;

        /// <summary>
        /// The type of data pointed to by <see cref="ve_valueptr"/>.
        /// For a list of the possible types, see Registry Value Types.
        /// </summary>
        public RegistryValueTypes ve_type;
    }
}
