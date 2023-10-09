using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a query.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_QUERY_DESC
    {
        /// <summary>
        /// Type of query (see <see cref="D3D11_QUERY"/>).
        /// </summary>
        public D3D11_QUERY Query;

        /// <summary>
        /// Miscellaneous flags (see <see cref="D3D11_QUERY_MISC_FLAG"/>).
        /// </summary>
        public D3D11_QUERY_MISC_FLAG MiscFlags;
    }
}
