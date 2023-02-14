using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a focus event in a console <see cref="INPUT_RECORD"/> structure.
    /// These events are used internally and should be ignored.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/focus-event-record-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FOCUS_EVENT_RECORD
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        public BOOL bSetFocus;
    }
}
