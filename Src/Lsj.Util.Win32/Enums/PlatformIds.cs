using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// PlatformIds
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/metadata/osinfo-structure"/>
    /// </para>
    /// </summary>
    public enum PlatformIds : uint
    {
        /// <summary>
        /// Microsoft Windows 3.1
        /// </summary>
        VER_PLATFORM_WIN32s = 0,

        /// <summary>
        /// Windows 95, Windows 98, or operating systems descended from them
        /// </summary>
        VER_PLATFORM_WIN32_WINDOWS = 1,

        /// <summary>
        /// Windows NT or operating systems descended from it
        /// </summary>
        VER_PLATFORM_WIN32_NT = 2,
    }
}
