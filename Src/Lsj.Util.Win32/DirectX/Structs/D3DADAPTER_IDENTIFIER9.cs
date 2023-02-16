using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains information identifying the adapter.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dadapter-identifier9
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DADAPTER_IDENTIFIER9
    {
        /// <summary>
        /// Used for presentation to the user.
        /// This should not be used to identify particular drivers,
        /// because many different strings might be associated with the same device and driver from different vendors.
        /// </summary>
        public ByValBYTEArrayStructForSize512 Driver;

        /// <summary>
        /// Used for presentation to the user.
        /// </summary>
        public ByValBYTEArrayStructForSize512 Description;

        /// <summary>
        /// Device name for GDI.
        /// </summary>
        public ByValBYTEArrayStructForSize32 DeviceName;

        /// <summary>
        /// Identify the version of the Direct3D driver.
        /// It is legal to do less than and greater than comparisons on the 64-bit signed integer value.
        /// However, exercise caution if you use this element to identify problematic drivers.
        /// Instead, you should use <see cref="DeviceIdentifier"/>.
        /// See Remarks.
        /// </summary>
        public LARGE_INTEGER DriverVersion;

        /// <summary>
        /// Can be used to help identify a particular chip set.
        /// Query this member to identify the manufacturer.
        /// The value can be zero if unknown.
        /// </summary>
        public DWORD VendorId;

        /// <summary>
        /// Can be used to help identify a particular chip set.
        /// Query this member to identify the type of chip set.
        /// The value can be zero if unknown.
        /// </summary>
        public DWORD DeviceId;

        /// <summary>
        /// Can be used to help identify a particular chip set.
        /// Query this member to identify the subsystem, typically the particular board.
        /// The value can be zero if unknown.
        /// </summary>
        public DWORD SubSysId;

        /// <summary>
        /// Can be used to help identify a particular chip set.
        /// Query this member to identify the revision level of the chip set.
        /// The value can be zero if unknown.
        /// </summary>
        public DWORD Revision;

        /// <summary>
        /// Can be queried to check changes in the driver and chip set.
        /// This GUID is a unique identifier for the driver and chip set pair.
        /// Query this member to track changes to the driver and chip set in order to generate a new profile for the graphics subsystem.
        /// <see cref="DeviceIdentifier"/> can also be used to identify particular problematic drivers.
        /// </summary>
        public GUID DeviceIdentifier;

        /// <summary>
        /// Used to determine the Windows Hardware Quality Labs (WHQL) validation level for this driver and device pair.
        /// The DWORD is a packed date structure defining the date of the release of the most recent WHQL test passed by the driver.
        /// It is legal to perform &lt; and &gt; operations on this value.
        /// The following illustrates the date format.
        /// Bits    Description
        /// 31-16   The year, a decimal number from 1999 upwards.
        /// 15-8    The month, a decimal number from 1 to 12.
        /// 7-0     The day, a decimal number from 1 to 31.
        /// The following values are also used.
        /// Value   Description
        /// 0       Not certified.
        /// 1       WHQL validated, but no date information is available.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// For Direct3D9Ex running on Windows Vista, Windows Server 2008, Windows 7, and Windows Server 2008 R2 (or more current operating system),
        /// <see cref="IDirect3D9.GetAdapterIdentifier"/> returns 1 for the WHQL level without checking the status of the driver.
        /// </summary>
        public DWORD WHQLLevel;
    }
}
