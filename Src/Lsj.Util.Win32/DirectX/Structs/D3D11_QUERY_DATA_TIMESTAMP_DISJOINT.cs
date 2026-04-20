using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Query information about the reliability of a timestamp query.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_data_timestamp_disjoint"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_QUERY_DATA_TIMESTAMP_DISJOINT
    {
        /// <summary>
        /// How frequently the GPU counter increments in Hz.
        /// </summary>
        public UINT64 Frequency;

        /// <summary>
        /// If this is <see cref="TRUE"/>, something occurred in between the query's
        /// <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/> calls
        /// that caused the timestamp counter to become discontinuous or disjoint,
        /// such as unplugging the AC cord on a laptop, overheating, or throttling up/down due to laptop savings events.
        /// The timestamp returned by <see cref="ID3D11DeviceContext.GetData"/> for a timestamp query
        /// is only reliable if <see cref="Disjoint"/> is <see cref="FALSE"/>.
        /// </summary>
        public BOOL Disjoint;
    }
}
