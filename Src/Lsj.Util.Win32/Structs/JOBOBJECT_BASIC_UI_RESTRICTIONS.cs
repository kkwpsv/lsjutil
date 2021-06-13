using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_UILIMIT;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic user-interface restrictions for a job object.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_ui_restrictions"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_UI_RESTRICTIONS
    {
        /// <summary>
        /// The restriction class for the user interface. This member can be one or more of the following values.
        /// <see cref="JOB_OBJECT_UILIMIT_DESKTOP"/>, <see cref="JOB_OBJECT_UILIMIT_DISPLAYSETTINGS"/>, <see cref="JOB_OBJECT_UILIMIT_EXITWINDOWS"/>,
        /// <see cref="JOB_OBJECT_UILIMIT_GLOBALATOMS"/>, <see cref="JOB_OBJECT_UILIMIT_HANDLES"/>, <see cref="JOB_OBJECT_UILIMIT_READCLIPBOARD"/>,
        /// <see cref="JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS"/>, <see cref="JOB_OBJECT_UILIMIT_WRITECLIPBOARD"/>
        /// </summary>
        public JOB_OBJECT_UILIMIT UIRestrictionsClass;
    }
}
