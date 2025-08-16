using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JobObjectUILimitClasses;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic user-interface restrictions for a job object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_basic_ui_restrictions"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If you specify the <see cref="JOB_OBJECT_UILIMIT_HANDLES"/> flag, when a process associated with the job broadcasts messages,
    /// they are only sent to top-level windows owned by processes associated with the same job.
    /// In addition, hooks can be installed only on threads belonging to processes associated with the job.
    /// </para>
    /// <para>
    /// To grant access to a User handle to a job that has a user-interface restriction, use the <see cref="UserHandleGrantAccess"/> function.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_UI_RESTRICTIONS
    {
        /// <summary>
        /// <para>
        /// The restriction class for the user interface. This member can be one or more of the following values.
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
        /// <see cref="JOB_OBJECT_UILIMIT_DESKTOP"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from creating desktops and switching desktops
        /// using the <see cref="CreateDesktop"/> and <see cref="SwitchDesktop"/> functions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_DISPLAYSETTINGS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from calling the <see cref="ChangeDisplaySettings"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_EXITWINDOWS"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from calling the <see cref="ExitWindows"/> or <see cref="ExitWindowsEx"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_GLOBALATOMS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from accessing global atoms.
        /// When this flag is used, each job has its own atom table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_HANDLES"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from using USER handles owned by processes not associated with the same job.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_READCLIPBOARD"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from reading data from the clipboard.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from changing system parameters by using the <see cref="SystemParametersInfo"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_UILIMIT_WRITECLIPBOARD"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Prevents processes associated with the job from writing data to the clipboard.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JobObjectUILimitClasses UIRestrictionsClass;
    }
}
