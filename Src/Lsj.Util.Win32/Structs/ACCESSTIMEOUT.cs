using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the time-out period associated with the Microsoft Win32 accessibility features.
    /// The accessibility time-out period is the length of time that must pass without keyboard and mouse input
    /// before the operating system automatically turns off accessibility features.
    /// The accessibility time-out is designed for computers that are shared by several users
    /// so that options selected by one user do not inconvenience a subsequent user.
    /// The accessibility features affected by the time-out are the FilterKeys features (SlowKeys, BounceKeys, and RepeatKeys),
    /// MouseKeys, ToggleKeys, and StickyKeys.
    /// The accessibility time-out also affects the high contrast mode setting.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-accesstimeout
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
        public uint cbSize;

        /// <summary>
        /// A set of bit flags that specify properties of the time-out behavior for accessibility features.
        /// </summary>
        public ACCESSTIMEOUTFlags dwFlags;

        /// <summary>
        /// Specifies the time-out period, in milliseconds.
        /// </summary>
        public uint iTimeOutMSec;
    }
}
