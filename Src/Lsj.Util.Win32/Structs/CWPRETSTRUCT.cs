using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.WindowHookTypes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the message parameters passed to a <see cref="WH_CALLWNDPROCRET"/> hook procedure, CallWndRetProc.
    /// </para>
    /// <para>
    /// From: 
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CWPRETSTRUCT
    {
        /// <summary>
        /// The return value of the window procedure that processed the message specified by the <see cref="message"/> value.
        /// </summary>
        public LRESULT lResult;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the <see cref="message"/> value.
        /// </summary>
        public LPARAM lParam;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the <see cref="message"/> value.
        /// </summary>
        public WPARAM wParam;

        /// <summary>
        /// The message.
        /// </summary>
        public WindowMessages message;

        /// <summary>
        /// A handle to the window that processed the message specified by the <see cref="message"/> value.
        /// </summary>
        public HWND hwnd;
    }
}
