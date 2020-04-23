using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a menu event in a console <see cref="INPUT_RECORD"/> structure.
    /// These events are used internally and should be ignored.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENU_EVENT_RECORD
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        public UINT dwCommandId;
    }
}
