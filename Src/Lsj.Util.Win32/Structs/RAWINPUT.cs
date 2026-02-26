using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the raw input from a device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The handle to this structure is passed in the <c>lParam</c> parameter of <see cref="WM_INPUT"/>.
    /// </para>
    /// <para>
    /// To get detailed information -- such as the header and the content of the raw input -- call <see cref="GetRawInputData"/>.
    /// </para>
    /// <para>
    /// To read the <see cref="RAWINPUT"/> in the message loop as a buffered read, call <see cref="GetRawInputBuffer"/>.
    /// </para>
    /// <para>
    /// To get device specific information, call <see cref="GetRawInputDeviceInfo"/>
    /// with the <c>hDevice</c> from <see cref="RAWINPUTHEADER"/>.
    /// </para>
    /// <para>
    /// Raw input is available only when the application calls <see cref="RegisterRawInputDevices"/> with valid device specifications.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RAWINPUT
    {
        /// <summary>
        /// The raw input data.
        /// </summary>
        public RAWINPUTHEADER header;

        /// <summary>
        /// 
        /// </summary>
        public RAWINPUT_data data;

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct RAWINPUT_data
        {
            /// <summary>
            /// If the data comes from a mouse, this is the raw input data.
            /// </summary>
            [FieldOffset(0)]
            public RAWMOUSE mouse;

            /// <summary>
            /// If the data comes from a keyboard, this is the raw input data.
            /// </summary>
            [FieldOffset(0)]
            public RAWKEYBOARD keyboard;

            /// <summary>
            /// If the data comes from an HID, this is the raw input data.
            /// </summary>
            [FieldOffset(0)]
            public RAWHID hid;
        }
    }
}
