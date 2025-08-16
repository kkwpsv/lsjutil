using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.RawInputDeviceFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines information for the raw input devices.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If <see cref="RIDEV_NOLEGACY"/> is set for a mouse or a keyboard, the system does not generate any legacy message for that device for the application.
    /// For example, if the mouse TLC is set with <see cref="RIDEV_NOLEGACY"/>, <see cref="WM_LBUTTONDOWN"/> and related legacy mouse messages are not generated.
    /// Likewise, if the keyboard TLC is set with <see cref="RIDEV_NOLEGACY"/>, <see cref="WM_KEYDOWN"/> and related legacy keyboard messages are not generated.
    /// </para>
    /// <para>
    /// If <see cref="RIDEV_REMOVE"/> is set and the <see cref="hwndTarget"/> member is not set to <see cref="NULL"/>,
    /// then <see cref="RegisterRawInputDevices"/> function will fail.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RAWINPUTDEVICE
    {
        /// <summary>
        /// Top level collection Usage page for the raw input device.
        /// See HID Clients Supported in Windows for details on possible values.
        /// </summary>
        public USHORT usUsagePage;

        /// <summary>
        /// Top level collection Usage ID for the raw input device.
        /// See HID Clients Supported in Windows for details on possible values.
        /// </summary>
        public USHORT usUsage;

        /// <summary>
        /// <para>
        /// Mode flag that specifies how to interpret the information provided by <see cref="usUsagePage"/> and <see cref="usUsage"/>.
        /// It can be zero (the default) or one of the following values.
        /// By default, the operating system sends raw input from devices with the specified top level collection (TLC)
        /// to the registered application as long as it has the window focus.
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
        /// <see cref="RIDEV_REMOVE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If set, this removes the top level collection from the inclusion list.
        /// This tells the operating system to stop reading from a device which matches the top level collection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_EXCLUDE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// If set, this specifies the top level collections to exclude when reading a complete usage page.
        /// This flag only affects a TLC whose usage page is already specified with <see cref="RIDEV_PAGEONLY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_PAGEONLY"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// If set, this specifies all devices whose top level collection is from the specified <see cref="usUsagePage"/>.
        /// Note that <see cref="usUsage"/> must be zero.
        /// To exclude a particular top level collection, use <see cref="RIDEV_EXCLUDE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_NOLEGACY"/>
        /// </para>
        /// <para>
        /// 0x00000030
        /// </para>
        /// </term>
        /// <term>
        /// If set, this prevents any devices specified by <see cref="usUsagePage"/> or <see cref="usUsage"/> from generating legacy messages.
        /// This is only for the mouse and keyboard.
        /// See Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_INPUTSINK"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// If set, this enables the caller to receive the input even when the caller is not in the foreground.
        /// Note that <see cref="hwndTarget"/> must be specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_CAPTUREMOUSE"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// If set, the mouse button click does not activate the other window.
        /// <see cref="RIDEV_CAPTUREMOUSE"/> can be specified only if <see cref="RIDEV_NOLEGACY"/> is specified for a mouse device.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_NOHOTKEYS"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// If set, the application-defined keyboard device hotkeys are not handled.
        /// However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled.
        /// By default, all keyboard hotkeys are handled.
        /// <see cref="RIDEV_NOHOTKEYS"/> can be specified even if <see cref="RIDEV_NOLEGACY"/> is not specified
        /// and <see cref="hwndTarget"/> is <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_APPKEYS"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// If set, the application command keys are handled.
        /// <see cref="RIDEV_APPKEYS"/> can be specified only if <see cref="RIDEV_NOLEGACY"/> is specified for a keyboard device.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_EXINPUTSINK"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// If set, this enables the caller to receive input in the background only if the foreground application does not process it.
        /// In other words, if the foreground application is not registered for raw input, then the background application that is registered will receive the input.
        /// Windows XP: This flag is not supported until Windows Vista
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIDEV_DEVNOTIFY"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// If set, this enables the caller to receive <see cref="WM_INPUT_DEVICE_CHANGE"/> notifications for device arrival and device removal.
        /// Windows XP: This flag is not supported until Windows Vista
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// A handle to the target window.
        /// If <see cref="NULL"/>, raw input events follow the keyboard focus to ensure only the focused application window receives the events.
        /// </summary>
        public HWND hwndTarget;
    }

}
