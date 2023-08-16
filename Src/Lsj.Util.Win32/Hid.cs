using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOLEAN;
using static Lsj.Util.Win32.Kernel32;

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

        /// <summary>
        /// <para>
        /// The <see cref="HidD_FreePreparsedData"/> routine releases the resources that the HID class driver allocated to hold a top-level collection's preparsed data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_freepreparseddata"/>
        /// </para>
        /// </summary>
        /// <param name="PreparsedData">
        /// Pointer to the buffer, returned by <see cref="HidD_GetPreparsedData"/>, that is freed.
        /// </param>
        /// <returns>
        /// <see cref="HidD_FreePreparsedData"/> returns <see cref="TRUE"/> if it succeeds.
        /// Otherwise, it returns <see cref="FALSE"/> if the buffer was not a preparsed data buffer.
        /// Use <see cref="GetLastError"/> to get extended error information.
        /// </returns>
        /// <remarks>
        /// Only user-mode applications can call <see cref="HidD_FreePreparsedData"/>.
        /// To obtain a collection's preparsed data, use <see cref="HidD_GetPreparsedData"/>.
        /// For more information, see HID Collections.
        /// </remarks>
        [DllImport("Hid.dll", CharSet = CharSet.Unicode, EntryPoint = "HidD_FreePreparsedData", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN HidD_FreePreparsedData([In] PHIDP_PREPARSED_DATA PreparsedData);

        /// <summary>
        /// <para>
        /// The <see cref="HidP_GetCaps"/> routine returns a top-level collection's <see cref="HIDP_CAPS"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getcaps"/>
        /// </para>
        /// </summary>
        /// <param name="PreparsedData">
        /// Pointer to a top-level collection's preparsed data.
        /// </param>
        /// <param name="Capabilities">
        /// Pointer to a caller-allocated buffer that the routine uses to return a collection's <see cref="HIDP_CAPS"/> structure.
        /// </param>
        /// <returns>
        /// <see cref="HidP_GetCaps"/> returns one of the following status values:
        /// <see cref="HIDP_STATUS_SUCCESS"/>: The routine successfully returned the collection capability information.
        /// <see cref="HIDP_STATUS_INVALID_PREPARSED_DATA"/>: The specified preparsed data is invalid.
        /// </returns>
        /// <remarks>
        /// For more information about a collection's capability, see Obtaining Collection Information.
        /// See also HID Collections.
        /// </remarks>
        [DllImport("Hid.dll", CharSet = CharSet.Unicode, EntryPoint = "HidP_GetCaps", ExactSpelling = true, SetLastError = true)]
        public static extern NTSTATUS HidP_GetCaps([In] PHIDP_PREPARSED_DATA PreparsedData, [Out] out HIDP_CAPS Capabilities);

        /// <summary>
        /// <para>
        /// The <see cref="HidD_GetPreparsedData"/> routine returns a top-level collection's preparsed data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getpreparseddata"/>
        /// </para>
        /// </summary>
        /// <param name="HidDeviceObject">
        /// Specifies an open handle to a top-level collection.
        /// </param>
        /// <param name="PreparsedData">
        /// Pointer to the address of a routine-allocated buffer that contains a collection's preparsed data in a _HIDP_PREPARSED_DATA structure.
        /// </param>
        /// <returns>
        /// <see cref="HidD_GetPreparsedData"/> returns <see cref="TRUE"/> if it succeeds; otherwise, it returns <see cref="FALSE"/>.
        /// Use <see cref="GetLastError"/> to get extended error information.
        /// </returns>
        /// <remarks>
        /// Only user-mode applications can call <see cref="HidD_GetPreparsedData"/>.
        /// Kernel-mode drivers can use an <see cref="IOCTL_HID_GET_COLLECTION_DESCRIPTOR"/> request.
        /// When an application no longer requires the preparsed data, it should call <see cref="HidD_FreePreparsedData"/> to free the preparsed data buffer.
        /// For more information, see HID Collections.
        /// </remarks>
        [DllImport("Hid.dll", CharSet = CharSet.Unicode, EntryPoint = "HidD_GetPreparsedData", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN HidD_GetPreparsedData([In] HANDLE HidDeviceObject, [Out] out PHIDP_PREPARSED_DATA PreparsedData);
    }
}
