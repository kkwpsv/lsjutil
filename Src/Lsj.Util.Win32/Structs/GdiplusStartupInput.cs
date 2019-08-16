using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Gdiplus;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GdiplusStartupInput"/> structure holds a block of arguments that are required by the <see cref="GdiplusStartup"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/gdiplusinit/ns-gdiplusinit-gdiplusstartupinput
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GdiplusStartupInput
    {
        /// <summary>
        /// Specifies the version of GDI+. Must be 1.
        /// </summary>
        public uint GdiplusVersion;

        /// <summary>
        /// Pointer to a callback function that GDI+ can call, on debug builds, for assertions and warnings. The default value is NULL.
        /// </summary>
        public IntPtr DebugEventCallback;

        /// <summary>
        /// Boolean value that specifies whether to suppress the GDI+ background thread. 
        /// If you set this member to TRUE, <see cref="GdiplusStartup"/> returns (in its output parameter) a pointer to a hook function and a pointer to an unhook function.
        /// You must call those functions appropriately to replace the background thread.
        /// If you do not want to be responsible for calling the hook and unhook functions, set this member to FALSE. The default value is FALSE.
        /// </summary>
        public bool SuppressBackgroundThread;

        /// <summary>
        /// Boolean value that specifies whether you want GDI+ to suppress external image codecs.
        /// GDI+ version 1.0 does not support external image codecs, so this parameter is ignored.
        /// </summary>
        public bool SuppressExternalCodecs;
    }
}
