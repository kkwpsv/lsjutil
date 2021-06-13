using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// JOB_OBJECT_UILIMIT
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_ui_restrictions"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If you specify the <see cref="JOB_OBJECT_UILIMIT_HANDLES"/> flag, when a process associated with the job broadcasts messages,
    /// they are only sent to top-level windows owned by processes associated with the same job.
    /// In addition, hooks can be installed only on threads belonging to processes associated with the job.
    /// To grant access to a User handle to a job that has a user-interface restriction, use the UserHandleGrantAccess function.
    /// </remarks>
    public enum JOB_OBJECT_UILIMIT : uint
    {
        /// <summary>
        /// Prevents processes associated with the job from creating desktops and switching desktops
        /// using the <see cref="CreateDesktop"/> and <see cref="SwitchDesktop"/> functions.
        /// </summary>
        JOB_OBJECT_UILIMIT_DESKTOP = 0x00000040,

        /// <summary>
        /// Prevents processes associated with the job from calling the <see cref="ChangeDisplaySettings"/> function.
        /// </summary>
        JOB_OBJECT_UILIMIT_DISPLAYSETTINGS = 0x00000010,

        /// <summary>
        /// Prevents processes associated with the job from calling the <see cref="ExitWindows"/> or <see cref="ExitWindowsEx"/> function.
        /// </summary>
        JOB_OBJECT_UILIMIT_EXITWINDOWS = 0x00000080,

        /// <summary>
        /// Prevents processes associated with the job from accessing global atoms. When this flag is used, each job has its own atom table.
        /// </summary>
        JOB_OBJECT_UILIMIT_GLOBALATOMS = 0x00000020,

        /// <summary>
        /// Prevents processes associated with the job from using USER handles owned by processes not associated with the same job.
        /// </summary>
        JOB_OBJECT_UILIMIT_HANDLES = 0x00000001,

        /// <summary>
        /// Prevents processes associated with the job from reading data from the clipboard.
        /// </summary>
        JOB_OBJECT_UILIMIT_READCLIPBOARD = 0x00000002,

        /// <summary>
        /// Prevents processes associated with the job from changing system parameters by using the <see cref="SystemParametersInfo"/> function.
        /// </summary>
        JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS = 0x00000008,

        /// <summary>
        /// Prevents processes associated with the job from writing data to the clipboard.
        /// </summary>
        JOB_OBJECT_UILIMIT_WRITECLIPBOARD = 0x00000004,
    }
}
