using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a query.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_query_desc1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_QUERY_DESC1
    {
        /// <summary>
        /// A <see cref="D3D11_QUERY"/>-typed value that specifies the type of query.
        /// </summary>
        public D3D11_QUERY Query;

        /// <summary>
        /// A combination of <see cref="D3D11_QUERY_MISC_FLAG"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies query behavior.
        /// </summary>
        public D3D11_QUERY_MISC_FLAG MiscFlags;

        /// <summary>
        /// A <see cref="D3D11_CONTEXT_TYPE"/>-typed value that specifies the context for the query.
        /// </summary>
        public D3D11_CONTEXT_TYPE ContextType;
    }
}
