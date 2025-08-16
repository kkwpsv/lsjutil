using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ATF;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the time-out period associated with the Microsoft Win32 accessibility features.
    /// </para>
    /// <para>
    /// The accessibility time-out period is the length of time that must pass without keyboard and mouse input
    /// before the operating system automatically turns off accessibility features.
    /// The accessibility time-out is designed for computers that are shared by several users so that options selected by one user do not inconvenience a subsequent user.
    /// </para>
    /// <para>
    /// The accessibility features affected by the time-out are the FilterKeys features (SlowKeys, BounceKeys, and RepeatKeys), MouseKeys, ToggleKeys, and StickyKeys.
    /// The accessibility time-out also affects the high contrast mode setting.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-accesstimeout"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use an <see cref="ACCESSTIMEOUT"/> structure when calling the <see cref="SystemParametersInfo"/> function
    /// with the uiAction parameter set to the <see cref="SystemParametersInfoParameters.SPI_GETACCESSTIMEOUT"/>
    /// or <see cref="SystemParametersInfoParameters.SPI_SETACCESSTIMEOUT"/> value.
    /// When using <see cref="SystemParametersInfoParameters.SPI_GETACCESSTIMEOUT"/>,
    /// you must specify the <see cref="cbSize"/> member of the <see cref="ACCESSTIMEOUT"/> structure;
    /// the <see cref="SystemParametersInfo"/> function fills in the remaining members.
    /// Specify all structure members when using the <see cref="SystemParametersInfoParameters.SPI_SETACCESSTIMEOUT"/> value.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCESSTIMEOUT
    {
        /// <summary>
        /// Specifies the size, in bytes, of this structure.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// <para>
        /// A set of bit flags that specify properties of the time-out behavior for accessibility features.
        /// </para>
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
        /// <see cref="ATF_ONOFFFEEDBACK"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the operating system plays a descending siren sound when the time-out period elapses and the accessibility features are turned off.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ATF_TIMEOUTON"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, a time-out period has been set for accessibility features.
        /// If this flag is not set, the features will not time out even though a time-out period is specified.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ATF dwFlags;

        /// <summary>
        /// Specifies the time-out period, in milliseconds.
        /// </summary>
        public DWORD iTimeOutMSec;
    }
}
