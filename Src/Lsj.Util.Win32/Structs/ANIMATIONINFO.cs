﻿using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the animation effects associated with user actions.
    /// This structure is used with the <see cref="SystemParametersInfo"/> function
    /// when the <see cref="SPI_GETANIMATION"/>
    /// or <see cref="SPI_SETANIMATION"/> action value is specified.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-animationinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ANIMATIONINFO
    {
        /// <summary>
        /// The size of the structure, in bytes. The caller must set this to <code>sizeof(ANIMATIONINFO)</code>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// If this member is nonzero, minimize and restore animation is enabled; otherwise it is disabled.
        /// </summary>
        public int iMinAnimate;
    }
}
