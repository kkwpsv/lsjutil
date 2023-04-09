using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a volume.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvolume-desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DVOLUME_DESC
    {
        /// <summary>
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the surface format of the volume.
        /// </summary>
        public D3DFORMAT Format;

        /// <summary>
        /// Member of the <see cref="D3DRESOURCETYPE"/> enumerated type, identifying this resource as a volume.
        /// </summary>
        public D3DRESOURCETYPE Type;

        /// <summary>
        /// Currently not used.
        /// Always returned as 0.
        /// </summary>
        public DWORD Usage;

        /// <summary>
        /// Member of the <see cref="D3DPOOL"/> enumerated type, specifying the class of memory allocated for this volume.
        /// </summary>
        public D3DPOOL Pool;

        /// <summary>
        /// Width of the volume, in pixels.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Height of the volume, in pixels.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Depth of the volume, in pixels.
        /// </summary>
        public UINT Depth;
    }
}
