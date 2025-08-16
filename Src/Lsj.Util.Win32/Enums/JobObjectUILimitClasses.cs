using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Job object UI limit classes
    /// </summary>
    [Flags]
    public enum JobObjectUILimitClasses : uint
    {
        /// <summary>
        /// JOB_OBJECT_UILIMIT_DESKTOP
        /// </summary>
        JOB_OBJECT_UILIMIT_DESKTOP = 0x00000040,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_DISPLAYSETTINGS
        /// </summary>
        JOB_OBJECT_UILIMIT_DISPLAYSETTINGS = 0x00000010,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_EXITWINDOWS
        /// </summary>
        JOB_OBJECT_UILIMIT_EXITWINDOWS = 0x00000080,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_GLOBALATOMS
        /// </summary>
        JOB_OBJECT_UILIMIT_GLOBALATOMS = 0x00000020,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_HANDLES
        /// </summary>
        JOB_OBJECT_UILIMIT_HANDLES = 0x00000001,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_READCLIPBOARD
        /// </summary>
        JOB_OBJECT_UILIMIT_READCLIPBOARD = 0x00000002,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS
        /// </summary>
        JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS = 0x00000008,

        /// <summary>
        /// JOB_OBJECT_UILIMIT_WRITECLIPBOARD
        /// </summary>
        JOB_OBJECT_UILIMIT_WRITECLIPBOARD = 0x00000004,
    }
}
