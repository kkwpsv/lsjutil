using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Hid.dll
    /// </summary>
    public static class Hid
    {
        /// <summary>
        /// <para>
        /// The <see cref="HidD_GetHidGuid"/> routine returns the device interface GUID for HIDClass devices.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_gethidguid"/>
        /// </para>
        /// </summary>
        /// <param name="HidGuid">
        /// Pointer to a caller-allocated GUID buffer that the routine uses to return the device interface GUID for HIDClass devices.
        /// </param>
        /// <remarks>
        /// Only user-mode applications can call <see cref="HidD_GetHidGuid"/>.
        /// For more information, see HID Collections.
        /// </remarks>
        [DllImport("Hid.dll", CharSet = CharSet.Unicode, EntryPoint = "HidD_GetHidGuid", ExactSpelling = true, SetLastError = true)]
        public static extern void HidD_GetHidGuid([Out] out GUID HidGuid);
    }
}
