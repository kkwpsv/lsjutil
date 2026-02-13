using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a hardware profile.
    /// The <see cref="GetCurrentHwProfile"/> function uses this structure to retrieve the current hardware profile for the local computer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-hw_profile_infow"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HW_PROFILE_INFO
    {
        /// <summary>
        /// <para>
        /// The reported docking state of the computer.
        /// This member can be a combination of the following bit values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DOCKINFO_DOCKED"/>
        /// </para>
        /// <para>
        /// 0x2
        /// </para>
        /// </term>
        /// <term>
        /// The computer is docked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DOCKINFO_UNDOCKED"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// The computer is undocked.
        /// This flag is always set for desktop systems that cannot be undocked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DOCKINFO_USER_SUPPLIED"/>
        /// </para>
        /// <para>
        /// 0x4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If this flag is set, <see cref="GetCurrentHwProfile"/> retrieved the current docking state
        /// from information provided by the user in the Hardware Profiles page of the <see cref="System"/> control panel application.
        /// </para>
        /// <para>
        /// If there is no such value or the value is set to 0, this flag is set.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DOCKINFO_USER_DOCKED"/>
        /// </para>
        /// <para>
        /// 0x5
        /// </para>
        /// </term>
        /// <term>
        /// The computer is docked, according to information provided by the user.
        /// This value is a combination of the <see cref="DOCKINFO_USER_SUPPLIED"/> and <see cref="DOCKINFO_DOCKED"/> flags.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DOCKINFO_USER_UNDOCKED"/>
        /// </para>
        /// <para>
        /// 0x6
        /// </para>
        /// </term>
        /// <term>
        /// The computer is undocked, according to information provided by the user.
        /// This value is a combination of the <see cref="DOCKINFO_USER_SUPPLIED"/> and <see cref="DOCKINFO_UNDOCKED"/> flags.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwDockInfo;

        /// <summary>
        /// <para>
        /// The globally unique identifier (GUID) string for the current hardware profile.
        /// The string returned by <see cref="GetCurrentHwProfile"/> encloses the GUID in curly braces, {}; for example:
        /// </para>
        /// <para>
        /// {12340001-4980-1920-6788-123456789012}
        /// </para>
        /// <para>
        /// You can use this string as a registry subkey under your application's configuration settings key in <see cref="HKEY_CURRENT_USER"/>.
        /// This enables you to store settings for each hardware profile.
        /// </para>
        /// </summary>
        public ByValStringStructForSize39 szHwProfileGuid;

        /// <summary>
        /// The display name for the current hardware profile.
        /// </summary>
        public ByValStringStructForSize80 szHwProfileName;
    }
}
