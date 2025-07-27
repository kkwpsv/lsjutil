using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the FilterKeys accessibility feature, which enables a user with disabilities
    /// to set the keyboard repeat rate (RepeatKeys), acceptance delay (SlowKeys), and bounce rate (BounceKeys).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-filterkeys"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use a <see cref="FILTERKEYS"/> structure when calling the <see cref="SystemParametersInfo"/> function
    /// with the uiAction parameter set to the <see cref="SPI_GETFILTERKEYS"/> or <see cref="SPI_SETFILTERKEYS"/> value.
    /// When using <see cref="SPI_GETFILTERKEYS"/>, you must specify the <see cref="cbSize"/> member of the <see cref="FILTERKEYS"/> structure;
    /// the <see cref="SystemParametersInfo"/> function fills the remaining members.
    /// Specify all structure members when using the <see cref="SPI_SETFILTERKEYS"/> value.
    /// </para>
    /// <para>
    /// The <see cref="iBounceMSec"/> member controls the BounceKeys feature, and the <see cref="iWaitMSec"/>,
    /// <see cref="iDelayMSec"/>, and <see cref="iRepeatMSec"/> members work together to control the RepeatKeys and SlowKeys features.
    /// If BounceKeys is on (that is, <see cref="iBounceMSec"/> is nonzero),
    /// the RepeatKeys and SlowKeys features are off (that is, the <see cref="iWaitMSec"/>,
    /// <see cref="iDelayMSec"/>, and <see cref="iRepeatMSec"/> members must all be zero).
    /// Similarly, if BounceKeys is off (<see cref="iBounceMSec"/> is zero),
    /// the <see cref="iWaitMSec"/>, <see cref="iDelayMSec"/>, and <see cref="iRepeatMSec"/> must all be nonzero.
    /// </para>
    /// <para>
    /// The maximum value of the <see cref="iBounceMSec"/>, <see cref="iWaitMSec"/>,
    /// <see cref="iDelayMSec"/>, and <see cref="iRepeatMSec"/> members is 20,000 milliseconds.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILTERKEYS
    {
        /// <summary>
        /// Specifies the structure size, in bytes.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// <para>
        /// A set of bit flags that specify properties of the FilterKeys feature. The following bit-flag values are defined:
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
        /// <see cref="FKF_AVAILABLE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The FilterKeys features are available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FKF_CLICKON"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// The computer makes a click sound when a key is pressed or accepted.
        /// If SlowKeys is on, a click is generated when the key is pressed and again when the keystroke is accepted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FKF_CONFIRMHOTKEY"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Windows 95/98, Windows 2000: A confirmation dialog box appears when the FilterKeys features are activated by using the hot key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FKF_FILTERKEYSON"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The FilterKeys features are on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FKF_HOTKEYACTIVE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The user can turn the FilterKeys feature on and off by holding down the RIGHT SHIFT key for eight seconds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FKF_HOTKEYSOUND"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the computer plays a siren sound when the user turns the FilterKeys feature on or off by using the hot key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FKF_INDICATOR"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Windows 95, Windows 2000: A visual indicator is displayed when the FilterKeys features are on.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// Specifies the length of time, in milliseconds, that the user must hold down a key before it is accepted by the computer.
        /// </summary>
        public DWORD iWaitMSec;

        /// <summary>
        /// Specifies the length of time, in milliseconds, that the user must hold down a key before it begins to repeat.
        /// </summary>
        public DWORD iDelayMSec;

        /// <summary>
        /// Specifies the length of time, in milliseconds, between each repetition of the keystroke.
        /// </summary>
        public DWORD iRepeatMSec;

        /// <summary>
        /// Specifies the length of time, in milliseconds, that must elapse after releasing a key
        /// before the computer will accept a subsequent press of the same key.
        /// </summary>
        public DWORD iBounceMSec;
    }
}
