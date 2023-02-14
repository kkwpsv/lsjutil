using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.HeaderControlMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used to set the size and position of a header control.
    /// <see cref="HDLAYOUT"/> is used with the <see cref="HDM_LAYOUT"/> message.
    /// This structure supersedes the HD_LAYOUT structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-hdlayout"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HDLAYOUT
    {
        /// <summary>
        /// Structure that contains the coordinates of a rectangle that the header control will occupy.
        /// </summary>
        public P<RECT> prc;

        /// <summary>
        /// Structure that receives information about the appropriate size and position of the header control.
        /// </summary>
        public P<WINDOWPOS> pwpos;
    }
}
