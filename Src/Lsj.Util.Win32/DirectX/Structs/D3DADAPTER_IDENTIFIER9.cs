using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains information identifying the adapter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dadapter-identifier9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The following pseudocode example illustrates the version format
    /// encoded in the DriverVersion, DriverVersionLowPart, and DriverVersionHighPart members.
    /// </para>
    /// <code>
    /// Product = HIWORD(DriverVersion.HighPart)
    /// Version = LOWORD(DriverVersion.HighPart)
    /// SubVersion = HIWORD(DriverVersion.LowPart)
    /// Build = LOWORD(DriverVersion.LowPart)
    /// </code>
    /// <para>
    /// See the Platform SDK for more information about the <see cref="HIWORD"/> macro,
    /// the <see cref="LOWORD"/> macro, and the <see cref="LARGE_INTEGER"/> structure.
    /// </para>
    /// <para>
    /// <see cref="MAX_DEVICE_IDENTIFIER_STRING"/> is a constant with the following definition.
    /// </para>
    /// <code>
    /// #define MAX_DEVICE_IDENTIFIER_STRING        512
    /// </code>
    /// <para>
    /// The VendorId, DeviceId, SubSysId, and Revision members can be used in tandem to identify particular chip sets.
    /// However, use these members with caution.
    /// </para>
    /// </remarks>
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
        /// <para>
        /// Used to determine the Windows Hardware Quality Labs (WHQL) validation level for this driver and device pair.
        /// The <see cref="DWORD"/> is a packed date structure
        /// defining the date of the release of the most recent WHQL test passed by the driver.
        /// It is legal to perform &lt; and &gt; operations on this value.
        /// The following illustrates the date format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 31-16
        /// </term>
        /// <term>
        /// The year, a decimal number from 1999 upwards.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 15-8
        /// </term>
        /// <term>
        /// The month, a decimal number from 1 to 12.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 7-0
        /// </term>
        /// <term>
        /// The day, a decimal number from 1 to 31.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following values are also used.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Not certified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// WHQL validated, but no date information is available.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// </para>
        /// <para>
        /// For Direct3D9Ex running on Windows Vista, Windows Server 2008,
        /// Windows 7, and Windows Server 2008 R2 (or more current operating system),
        /// <see cref="IDirect3D9.GetAdapterIdentifier"/> returns 1 for the WHQL level without checking the status of the driver.
        /// </para>
        /// </summary>
        public DWORD WHQLLevel;
    }
}
