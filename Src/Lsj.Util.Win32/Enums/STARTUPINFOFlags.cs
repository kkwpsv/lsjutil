using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="STARTUPINFO"/> flags
    /// </summary>
    [Flags]
    public enum StartupInfoFlags : uint
    {
        /// <summary>
        /// STARTF_FORCEONFEEDBACK
        /// </summary>
        STARTF_FORCEONFEEDBACK = 0x00000040,

        /// <summary>
        /// STARTF_FORCEOFFFEEDBACK
        /// </summary>
        STARTF_FORCEOFFFEEDBACK = 0x00000080,

        /// <summary>
        /// STARTF_PREVENTPINNING
        /// </summary>
        STARTF_PREVENTPINNING = 0x00002000,

        /// <summary>
        /// STARTF_RUNFULLSCREEN
        /// </summary>
        STARTF_RUNFULLSCREEN = 0x00000020,

        /// <summary>
        /// STARTF_TITLEISAPPID
        /// </summary>
        STARTF_TITLEISAPPID = 0x00001000,

        /// <summary>
        /// STARTF_TITLEISLINKNAME
        /// </summary>
        STARTF_TITLEISLINKNAME = 0x00000800,

        /// <summary>
        /// STARTF_UNTRUSTEDSOURCE
        /// </summary>
        STARTF_UNTRUSTEDSOURCE = 0x00008000,

        /// <summary>
        /// STARTF_USECOUNTCHARS
        /// </summary>
        STARTF_USECOUNTCHARS = 0x00000008,

        /// <summary>
        /// STARTF_USEFILLATTRIBUTE
        /// </summary>
        STARTF_USEFILLATTRIBUTE = 0x00000010,

        /// <summary>
        /// STARTF_USEHOTKEY
        /// </summary>
        STARTF_USEHOTKEY = 0x00000200,

        /// <summary>
        /// STARTF_USEPOSITION
        /// </summary>
        STARTF_USEPOSITION = 0x00000004,

        /// <summary>
        /// STARTF_USESHOWWINDOW
        /// </summary>
        STARTF_USESHOWWINDOW = 0x00000001,

        /// <summary>
        /// STARTF_USESIZE
        /// </summary>
        STARTF_USESIZE = 0x00000002,

        /// <summary>
        /// STARTF_USESTDHANDLES
        /// </summary>
        STARTF_USESTDHANDLES = 0x00000100,
    }
}
