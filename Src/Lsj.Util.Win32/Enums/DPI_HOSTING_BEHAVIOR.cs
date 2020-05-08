using Lsj.Util.Win32.BaseTypes;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the DPI hosting behavior for a window.
    /// This behavior allows windows created in the thread to host child windows with a different <see cref="DPI_AWARENESS_CONTEXT"/>
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/windef/ne-windef-dpi_hosting_behavior
    /// </para>
    /// </summary>
    /// <remarks>
    /// DPI_HOSTING_BEHAVIOR enables a mixed content hosting behavior, which allows parent windows created in the thread
    /// to host child windows with a different <see cref="DPI_AWARENESS_CONTEXT"/> value.
    /// This property only effects new windows created within this thread while the mixed hosting behavior is active.
    /// A parent window with this hosting behavior is able to host child windows with different <see cref="DPI_AWARENESS_CONTEXT"/> values,
    /// regardless of whether the child windows have mixed hosting behavior enabled.
    /// This hosting behavior does not allow for windows with per-monitor <see cref="DPI_AWARENESS_CONTEXT"/> values to be hosted
    /// until windows with <see cref="DPI_AWARENESS_CONTEXT"/> values of system or unaware.
    /// To avoid unexpected outcomes, a thread's <see cref="DPI_HOSTING_BEHAVIOR"/> should be changed to support mixed hosting behaviors
    /// only when creating a new window which needs to support those behaviors.
    /// Once that window is created, the hosting behavior should be switched back to its default value.
    /// Enabling mixed hosting behavior will not automatically adjust the thread's <see cref="DPI_AWARENESS_CONTEXT"/> to be compatible with legacy content.
    /// The thread's awareness context must still be manually changed before new windows are created to host such content.
    /// </remarks>
    public enum DPI_HOSTING_BEHAVIOR
    {
        /// <summary>
        /// Invalid DPI hosting behavior.
        /// This usually occurs if the previous <see cref="SetThreadDpiHostingBehavior"/> call used an invalid parameter.
        /// </summary>
        DPI_HOSTING_BEHAVIOR_INVALID = -1,

        /// <summary>
        /// Default DPI hosting behavior.
        /// The associated window behaves as normal, and cannot create or re-parent child windows with a different <see cref="DPI_AWARENESS_CONTEXT"/>.
        /// </summary>
        DPI_HOSTING_BEHAVIOR_DEFAULT = 0,

        /// <summary>
        /// Mixed DPI hosting behavior.
        /// This enables the creation and re-parenting of child windows with different <see cref="DPI_AWARENESS_CONTEXT"/>.
        /// These child windows will be independently scaled by the OS.
        /// </summary>
        DPI_HOSTING_BEHAVIOR_MIXED = 1
    }
}
