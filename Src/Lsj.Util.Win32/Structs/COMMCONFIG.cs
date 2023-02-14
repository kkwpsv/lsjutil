using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PST;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the configuration state of a communications device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-commconfig"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the provider subtype is <see cref="PST_RS232"/> or <see cref="PST_PARALLELPORT"/>, the <see cref="wcProviderData"/> member is omitted.
    /// If the provider subtype is <see cref="PST_MODEM"/>, the <see cref="wcProviderData"/> member contains a <see cref="MODEMSETTINGS"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMMCONFIG
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this member to <code>sizeof(COMMCONFIG)</code>.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// The version number of the structure.
        /// This parameter can be 1.
        /// The version of the provider-specific structure should be included in the <see cref="wcProviderData"/> member.
        /// </summary>
        public WORD wVersion;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public WORD wReserved;

        /// <summary>
        /// The device-control block (<see cref="DCB"/>) structure for RS-232 serial devices.
        /// A <see cref="DCB"/> structure is always present regardless of the port driver subtype specified in the device's <see cref="COMMPROP"/> structure.
        /// </summary>
        public DCB dcb;

        /// <summary>
        /// The type of communications provider, and thus the format of the provider-specific data.
        /// For a list of communications provider types, see the description of the <see cref="COMMPROP"/> structure.
        /// </summary>
        public DWORD dwProviderSubType;

        /// <summary>
        /// The offset of the provider-specific data relative to the beginning of the structure, in bytes.
        /// This member is zero if there is no provider-specific data.
        /// </summary>
        public DWORD dwProviderOffset;

        /// <summary>
        /// The size of the provider-specific data, in bytes.
        /// </summary>
        public DWORD dwProviderSize;

        /// <summary>
        /// Optional provider-specific data.
        /// This member can be of any size or can be omitted.
        /// Because the <see cref="COMMCONFIG"/> structure may be expanded in the future,
        /// applications should use the <see cref="dwProviderOffset"/> member to determine the location of this member.
        /// </summary>
        public WCHAR wcProviderData;
    }
}
