using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// A 2D texture interface manages texel data, which is structured memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11texture2d"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To create an empty Texture2D resource, call <see cref="ID3D11Device.CreateTexture2D"/>.
    /// For info about how to create a 2D texture, see How to: Create a Texture.
    /// </para>
    /// <para>
    /// Textures cannot be bound directly to the pipeline; instead, a view must be created and bound.
    /// Using a view, texture data can be interpreted at run time within certain restrictions.
    /// To use the texture as a render target or depth-stencil resource,
    /// call <see cref="ID3D11Device.CreateRenderTargetView"/>, and <see cref="ID3D11Device.CreateDepthStencilView"/>, respectively.
    /// To use the texture as an input to a shader, create a by calling <see cref="ID3D11Device.CreateShaderResourceView"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "6f15aaf2-d208-4e89-9ab4-489535d34f9c", BeginVTableSlotIndex = 10, EndVTableSlotIndex = 10,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D11DeviceChild), typeof(ID3D11Resource)])]
    public unsafe struct ID3D11Texture2D
    {
        nint* _vTable;

        /// <summary>
        /// Get the properties of the texture resource.
        /// </summary>
        /// <param name="pDesc">
        /// Pointer to a resource description (see <see cref="D3D11_TEXTURE2D_DESC"/>).
        /// </param>
        /// <returns></returns>
        public void GetDesc([Out] out D3D11_TEXTURE2D_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out D3D11_TEXTURE2D_DESC, void>)_vTable[10])(thisPtr, out pDesc);
            }
        }
    }
}
