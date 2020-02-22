using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="PAINTSTRUCT"/> structure contains information for an application.
    /// This information can be used to paint the client area of a window owned by that application.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-paintstruct
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PAINTSTRUCT
    {
        /// <summary>
        /// A handle to the display DC to be used for painting.
        /// </summary>
        public IntPtr hdc;

        /// <summary>
        /// Indicates whether the background must be erased.
        /// This value is nonzero if the application should erase the background.
        /// The application is responsible for erasing the background if a window class is created without a background brush.
        /// For more information, see the description of the <see cref="WNDCLASS.hbrBackground"/> member of the <see cref="WNDCLASS"/> structure.
        /// </summary>
        public bool fErase;

        /// <summary>
        /// A <see cref="RECT"/> structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested,
        /// in device units relative to the upper-left corner of the client area.
        /// </summary>
        public RECT rcPaint;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        public bool fRestore;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        public bool fIncUpdate;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U1)]
        public byte[] rgbReserved;
    }
}
