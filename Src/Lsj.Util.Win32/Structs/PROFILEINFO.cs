using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Enums.RegistryKeyAccessRights;
using static Lsj.Util.Win32.Userenv;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used when loading or unloading a user profile.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/profinfo/ns-profinfo-profileinfow
    /// </para>
    /// </summary>
    /// <remarks>
    /// Do not use environment variables when specifying a path.
    /// The <see cref="LoadUserProfile"/> function does not expand environment variables, such as %username%, in a path.
    /// When the <see cref="LoadUserProfile"/> call returns successfully, the <see cref="hProfile"/> member receives a registry key handle
    /// opened to the root of the user's subtree, opened with full access (<see cref="KEY_ALL_ACCESS"/>).
    /// For more information see the Remarks sections in <see cref="LoadUserProfile"/>, Registry Key Security and Access Rights, and Registry Hives.
    /// Services and applications that call <see cref="LoadUserProfile"/> should check to see if the user has a roaming profile.
    /// If the user has a roaming profile, specify its path as the <see cref="lpProfilePath"/> member of this structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROFILEINFO
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// This member can be one of the following flags:
        /// <see cref="PI_NOUI"/>: Prevents the display of profile error messages.
        /// <see cref="PI_APPLYPOLICY"/>: Not supported.
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// A pointer to the name of the user.
        /// This member is used as the base name of the directory in which to store a new profile.
        /// </summary>
        public string lpUserName;

        /// <summary>
        /// A pointer to the roaming user profile path.
        /// If the user does not have a roaming profile, this member can be <see langword="null"/>.
        /// To retrieve the user's roaming profile path, call the <see cref="NetUserGetInfo"/> function, specifying information level 3 or 4.
        /// For more information, see Remarks.
        /// </summary>
        public string lpProfilePath;

        /// <summary>
        /// A pointer to the default user profile path. This member can be <see langword="null"/>.
        /// </summary>
        public string lpDefaultPath;

        /// <summary>
        /// A pointer to the name of the validating domain controller, in NetBIOS format.
        /// </summary>
        public string lpServerName;

        /// <summary>
        /// Not used, set to <see langword="null"/>.
        /// </summary>
        public string lpPolicyPath;

        /// <summary>
        /// A handle to the <see cref="HKEY_CURRENT_USER"/> registry subtree.
        /// For more information, see Remarks.
        /// </summary>
        public HANDLE hProfile;
    }
}
