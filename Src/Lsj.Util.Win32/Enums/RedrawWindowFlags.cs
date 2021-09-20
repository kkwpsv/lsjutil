using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="RedrawWindow"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-redrawwindow"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum RedrawWindowFlags : uint
    {
        /// <summary>
        /// Causes the window to receive a <see cref="WM_ERASEBKGND"/> message when the window is repainted.
        /// The <see cref="RDW_INVALIDATE"/> flag must also be specified; otherwise, <see cref="RDW_ERASE"/> has no effect.
        /// </summary>
        RDW_ERASE = 0x0004,

        /// <summary>
        /// Causes any part of the nonclient area of the window that intersects the update region to receive a <see cref="WM_NCPAINT"/> message.
        /// The <see cref="RDW_INVALIDATE"/> flag must also be specified; otherwise, <see cref="RDW_FRAME"/> has no effect.
        /// The <see cref="WM_NCPAINT"/> message is typically not sent during the execution of <see cref="RedrawWindow"/>
        /// unless either <see cref="RDW_UPDATENOW"/> or <see cref="RDW_ERASENOW"/> is specified.
        /// </summary>
        RDW_FRAME = 0x0400,

        /// <summary>
        /// Causes a <see cref="WM_PAINT"/> message to be posted to the window regardless of whether any portion of the window is invalid.
        /// </summary>
        RDW_INTERNALPAINT = 0x0002,

        /// <summary>
        /// Invalidates lprcUpdate or hrgnUpdate (only one may be non-NULL).
        /// If both are <see cref="NULL"/>, the entire window is invalidated.
        /// </summary>
        RDW_INVALIDATE = 0x0001,

        /// <summary>
        /// Suppresses any pending <see cref="WM_ERASEBKGND"/> messages.
        /// </summary>
        RDW_NOERASE = 0x0020,

        /// <summary>
        /// Suppresses any pending <see cref="WM_NCPAINT"/> messages.
        /// This flag must be used with <see cref="RDW_VALIDATE"/> and is typically used with <see cref="RDW_NOCHILDREN"/>.
        /// <see cref="RDW_NOFRAME"/> should be used with care, as it could cause parts of a window to be painted improperly.
        /// </summary>
        RDW_NOFRAME = 0x0800,

        /// <summary>
        /// Suppresses any pending internal <see cref="WM_PAINT"/> messages.
        /// This flag does not affect <see cref="WM_PAINT"/> messages resulting from a non-NULL update area.
        /// </summary>
        RDW_NOINTERNALPAINT = 0x0010,

        /// <summary>
        /// Validates lprcUpdate or hrgnUpdate (only one may be non-NULL).
        /// If both are <see cref="NULL"/>, the entire window is validated. This flag does not affect internal <see cref="WM_PAINT"/> messages.
        /// </summary>
        RDW_VALIDATE = 0x0008,

        /// <summary>
        /// Causes the affected windows (as specified by the <see cref="RDW_ALLCHILDREN"/> and <see cref="RDW_NOCHILDREN"/> flags)
        /// to receive <see cref="WM_NCPAINT"/> and <see cref="WM_ERASEBKGND"/> messages, if necessary, before the function returns.
        /// <see cref="WM_PAINT"/> messages are received at the ordinary time.
        /// </summary>
        RDW_ERASENOW = 0x0200,

        /// <summary>
        /// Causes the affected windows (as specified by the <see cref="RDW_ALLCHILDREN"/> and <see cref="RDW_NOCHILDREN"/> flags)
        /// to receive <see cref="WM_NCPAINT"/>, <see cref="WM_ERASEBKGND"/>, and <see cref="WM_PAINT"/> messages, if necessary, before the function returns.
        /// </summary>
        RDW_UPDATENOW = 0x0100,

        /// <summary>
        /// Includes child windows, if any, in the repainting operation.
        /// </summary>
        RDW_ALLCHILDREN = 0x0080,

        /// <summary>
        /// Excludes child windows, if any, from the repainting operation.
        /// </summary>
        RDW_NOCHILDREN = 0x0040,
    }
}
