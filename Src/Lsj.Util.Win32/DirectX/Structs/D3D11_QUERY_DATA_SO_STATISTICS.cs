using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
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
    /// Query information about the amount of data streamed out to the stream-output buffers
    /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_data_so_statistics"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_QUERY_DATA_SO_STATISTICS
    {
        /// <summary>
        /// Number of primitives (that is, points, lines, and triangles) written to the stream-output buffers.
        /// </summary>
        public UINT64 NumPrimitivesWritten;

        /// <summary>
        /// Number of primitives that would have been written to the stream-output buffers if there had been enough space for them all.
        /// </summary>
        public UINT64 PrimitivesStorageNeeded;
    }
}
