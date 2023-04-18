using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains a handle and text description corresponding to a physical monitor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/ns-physicalmonitorenumerationapi-physical_monitor"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A physical monitor description is always an array of 128 characters.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PHYSICAL_MONITOR
    {
        /// <summary>
        /// Handle to the physical monitor.
        /// </summary>
        public HANDLE hPhysicalMonitor;

        /// <summary>
        /// Text description of the physical monitor.
        /// </summary>
        public ByValStringStructForSize128 szPhysicalMonitorDescription;
    }
}
