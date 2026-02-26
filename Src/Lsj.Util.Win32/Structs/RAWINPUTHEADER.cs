using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the header information that is part of the raw input data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To get more information on the device, use <see cref="hDevice"/> in a call to <see cref="GetRawInputDeviceInfo"/>.
    /// <see cref="hDevice"/> can be zero if an input is received from a precision touchpad.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RAWINPUTHEADER
    {
        /// <summary>
        /// <para>
        /// The type of raw input.
        /// It can be one of the following values:
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
        /// <see cref="RIM_TYPEMOUSE"/> 0
        /// </term>
        /// <term>
        /// Raw input comes from the mouse.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIM_TYPEKEYBOARD"/> 1
        /// </term>
        /// <term>
        /// Raw input comes from the keyboard.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIM_TYPEHID"/> 2
        /// </term>
        /// <term>
        /// Raw input comes from some device that is not a keyboard or a mouse.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwType;

        /// <summary>
        /// The size, in bytes, of the entire input packet of data.
        /// This includes <see cref="RAWINPUT"/> plus possible extra input reports in the <see cref="RAWHID"/> variable length array.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// A handle to the device generating the raw input data.
        /// </summary>
        public HANDLE hDevice;

        /// <summary>
        /// The value passed in the <c>wParam</c> parameter of the <see cref="WM_INPUT"/> message.
        /// </summary>
        public WPARAM wParam;
    }
}
