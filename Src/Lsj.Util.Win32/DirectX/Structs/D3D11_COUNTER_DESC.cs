using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a counter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_counter_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="ID3D11Counter.GetDesc"/>, <see cref="ID3D11Device.CheckCounter"/> and <see cref="ID3D11Device.CreateCounter"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_COUNTER_DESC
    {
        /// <summary>
        /// Type of counter (see <see cref="D3D11_COUNTER"/>).
        /// </summary>
        public D3D11_COUNTER Counter;

        /// <summary>
        /// Reserved.
        /// </summary>
        public UINT MiscFlags;
    }
}
