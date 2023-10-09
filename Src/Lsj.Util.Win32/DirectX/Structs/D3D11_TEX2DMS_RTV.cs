using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresource from a multisampled 2D texture to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_rtv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Since a multisampled 2D texture contains a single subresource, there is actually nothing to specify in <see cref="D3D11_TEX2DMS_RTV"/>.
    /// Consequently, <see cref="UnusedField_NothingToDefine"/> is included so that this structure will compile in C.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2DMS_RTV
    {
        /// <summary>
        /// Integer of any value. See remarks.
        /// </summary>
        public UINT UnusedField_NothingToDefine;
    }
}
