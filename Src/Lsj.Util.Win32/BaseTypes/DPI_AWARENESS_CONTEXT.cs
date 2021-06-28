using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// Identifies the awareness context for a window.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/hidpi/dpi-awareness-context"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DPI_AWARENESS_CONTEXT : IPointer
    {
        /// <summary>
        /// DPI unaware. This window does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI).
        /// It will be automatically scaled by the system on any other DPI setting.
        /// </summary>
        public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE = new DPI_AWARENESS_CONTEXT { _value = (IntPtr)(-1) };

        /// <summary>
        /// System DPI aware. This window does not scale for DPI changes.
        /// It will query for the DPI once and use that value for the lifetime of the process.
        /// If the DPI changes, the process will not adjust to the new DPI value.
        /// It will be automatically scaled up or down by the system when the DPI changes from the system value.
        /// </summary>
        public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new DPI_AWARENESS_CONTEXT { _value = (IntPtr)(-2) };

        /// <summary>
        /// Per monitor DPI aware. This window checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes.
        /// These processes are not automatically scaled by the system.
        /// </summary>
        public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new DPI_AWARENESS_CONTEXT { _value = (IntPtr)(-3) };

        /// <summary>
        /// Also known as Per Monitor v2.
        /// An advancement over the original per-monitor DPI awareness mode, 
        /// which enables applications to access new DPI-related scaling behaviors on a per top-level window basis.
        /// Per Monitor v2 was made available in the Creators Update of Windows 10, and is not available on earlier versions of the operating system.
        /// The additional behaviors introduced are as follows:
        /// Child window DPI change notifications - In Per Monitor v2 contexts, the entire window tree is notified of any DPI changes that occur.
        /// Scaling of non-client area - All windows will automatically have their non-client area drawn in a DPI sensitive fashion.
        /// Calls to <see cref="EnableNonClientDpiScaling"/> are unnecessary.
        /// Scaling of Win32 menus - All NTUSER menus created in Per Monitor v2 contexts will be scaling in a per-monitor fashion.
        /// Dialog Scaling - Win32 dialogs created in Per Monitor v2 contexts will automatically respond to DPI changes.
        /// Improved scaling of comctl32 controls - Various comctl32 controls have improved DPI scaling behavior in Per Monitor v2 contexts.
        /// Improved theming behavior - UxTheme handles opened in the context of a Per Monitor v2 window will operate
        /// in terms of the DPI associated with that window.
        /// </summary>
        public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new DPI_AWARENESS_CONTEXT { _value = (IntPtr)(-4) };

        /// <summary>
        /// DPI unaware with improved quality of GDI-based content.
        /// This mode behaves similarly to <see cref="DPI_AWARENESS_CONTEXT_UNAWARE"/>, but also enables the system to
        /// automatically improve the rendering quality of text and other GDI-based primitives when the window is displayed on a high-DPI monitor.
        /// For more details, see Improving the high-DPI experience in GDI-based Desktop apps.
        /// <see cref="DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED"/> was introduced in the October 2018 update of Windows 10 (also known as version 1809).
        /// </summary>
        public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = new DPI_AWARENESS_CONTEXT { _value = (IntPtr)(-5) };

        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this == DPI_AWARENESS_CONTEXT_UNAWARE)
            {
                return nameof(DPI_AWARENESS_CONTEXT_UNAWARE);
            }
            else if (this == DPI_AWARENESS_CONTEXT_SYSTEM_AWARE)
            {
                return nameof(DPI_AWARENESS_CONTEXT_SYSTEM_AWARE);
            }
            else if (this == DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE)
            {
                return nameof(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE);
            }
            else if (this == DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2)
            {
                return nameof(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            }
            else if (this == DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED)
            {
                return nameof(DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED);
            }
            else
            {
                return _value.ToString();
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DPI_AWARENESS_CONTEXT x && this == x;

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(DPI_AWARENESS_CONTEXT a, IntPtr b) => a._value == b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(DPI_AWARENESS_CONTEXT a, IntPtr b) => a._value != b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HANDLE(DPI_AWARENESS_CONTEXT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DPI_AWARENESS_CONTEXT(HANDLE val) => new DPI_AWARENESS_CONTEXT { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(DPI_AWARENESS_CONTEXT val) => val._value;
    }
}
