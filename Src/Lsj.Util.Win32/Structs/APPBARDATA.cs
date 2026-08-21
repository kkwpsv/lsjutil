using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a system appbar message.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/ns-shellapi-appbardata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct APPBARDATA
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The handle to the appbar window.
        /// Not all messages use this member.
        /// See the individual message page to see if you need to provide an <see cref="hWnd"/> value.
        /// </summary>
        public HWND hWnd;

        /// <summary>
        /// An application-defined message identifier.
        /// The application uses the specified identifier for notification messages
        /// that it sends to the appbar identified by the <see cref="hWnd"/> member.
        /// This member is used when sending the <see cref="ABM_NEW"/> message.
        /// </summary>
        public UINT uCallbackMessage;

        /// <summary>
        /// <para>
        /// A value that specifies an edge of the screen.
        /// This member is used when sending one of these messages:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ABM_GETAUTOHIDEBAR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_SETAUTOHIDEBAR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_GETAUTOHIDEBAREX"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_SETAUTOHIDEBAREX"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_QUERYPOS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_SETPOS"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This member can be one of the following values.
        /// </para>
        /// <para>
        /// <see cref="ABE_BOTTOM"/>
        /// </para>
        /// <para>
        /// Bottom edge.
        /// </para>
        /// <para>
        /// <see cref="ABE_LEFT"/>
        /// </para>
        /// <para>
        /// Left edge.
        /// </para>
        /// <para>
        /// <see cref="ABE_RIGHT"/>
        /// </para>
        /// <para>
        /// Right edge.
        /// </para>
        /// <para>
        /// <see cref="ABE_TOP"/>
        /// </para>
        /// <para>
        /// Top edge.
        /// </para>
        /// </summary>
        public UINT uEdge;

        /// <summary>
        /// <para>
        /// A <see cref="RECT"/> structure whose use varies depending on the message:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ABM_GETTASKBARPOS"/>, <see cref="ABM_QUERYPOS"/>, <see cref="ABM_SETPOS"/>:
        /// The bounding rectangle, in screen coordinates, of an appbar or the Windows taskbar.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_GETAUTOHIDEBAREX"/>, <see cref="ABM_SETAUTOHIDEBAREX"/>:
        /// The monitor on which the operation is being performed.
        /// This information can be retrieved through the <see cref="GetMonitorInfo"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public RECT rc;

        /// <summary>
        /// <para>
        /// A message-dependent value.
        /// This member is used with these messages:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ABM_SETAUTOHIDEBAR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_SETAUTOHIDEBAREX"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ABM_SETSTATE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// See the individual message pages for details.
        /// </para>
        /// </summary>
        public LPARAM lParam;
    }
}
