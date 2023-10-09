using Lsj.Util.Win32.BaseTypes;
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
    /// Specifies the subresources from a multisampled 2D texture to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_srv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Since a multisampled 2D texture contains a single subresource, there is actually nothing to specify in <see cref="D3D11_TEX2DMS_SRV"/>.
    /// Consequently, <see cref="UnusedField_NothingToDefine"/> is included so that this structure will compile in C.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2DMS_SRV
    {
        /// <summary>
        /// Integer of any value. See remarks.
        /// </summary>
        public UINT UnusedField_NothingToDefine;
    }
}
