using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdiplus;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GdiplusStartup"/> function uses the <see cref="GdiplusStartupOutput"/> structure
    /// to return (in its output parameter) a pointer to a hook function and a pointer to an unhook function.
    /// If you set the <see cref="GdiplusStartupInput.SuppressBackgroundThread"/> member of the input parameter to <see langword="true"/>,
    /// then you are responsible for calling those functions to replace the Windows GDI+ background thread.
    /// Call the hook and unhook functions before and after the application's main message loop;
    /// that is, a message loop that is active for the lifetime of GDI+.
    /// Call the hook function before the loop starts, and call the unhook function after the loop ends.
    /// The token parameter of the hook function receives an identifier that you should later pass to the unhook function.
    /// If you do not pass the proper identifier (the one returned by the hook function) to the unhook function,
    /// there will be resource leaks that won't be cleaned up until the process exits.
    /// If you do not want to be responsible for calling the hook and unhook functions,
    /// set the <see cref="GdiplusStartupInput.SuppressBackgroundThread"/> member
    /// of the input parameter (passed to <see cref="GdiplusStartup"/>) to <see langword="false"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/gdiplusinit/ns-gdiplusinit-gdiplusstartupoutput"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GdiplusStartupOutput
    {
        /// <summary>
        /// Receives a pointer to a hook function.
        /// </summary>
        public IntPtr NotificationHook;

        /// <summary>
        /// Receives a pointer to an unhook function.
        /// </summary>
        public IntPtr NotificationUnhook;
    }
}
