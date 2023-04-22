using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DPixelShader9"/> interface to encapsulate the functionality of a pixel shader.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dpixelshader9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The LPDIRECT3DPIXELSHADER9 and PDIRECT3DPIXELSHADER9 types are defined as pointers to the <see cref="IDirect3DPixelShader9"/> interface.
    /// <code>
    /// typedef struct IDirect3DPixelShader9 *LPDIRECT3DPIXELSHADER9, *PDIRECT3DPIXELSHADER9;
    /// </code>
    /// </remarks>
    public unsafe struct IDirect3DPixelShader9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <param name="ppDevice">
        /// Pointer to the <see cref="IDirect3DDevice9"/> interface that is returned.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDevice([Out] out P<IDirect3DDevice9> ppDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DDevice9>, HRESULT>)_vTable[3])(thisPtr, out ppDevice);
            }
        }

        /// <summary>
        /// Gets a pointer to the shader data.
        /// </summary>
        /// <param name="pData">
        /// Pointer to a buffer that contains the shader data.
        /// The application needs to allocate enough room for this.
        /// </param>
        /// <param name="pSizeOfData">
        /// Size of the data, in bytes.
        /// To get the buffer size that is needed to retrieve the data, set <paramref name="pData"/> = <see cref="NULL"/> when calling <see cref="GetFunction"/>.
        /// Then call <see cref="GetFunction"/> with the returned size, to get the buffer data.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetFunction([In] IntPtr pData, [In][Out] ref UINT pSizeOfData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ref UINT, HRESULT>)_vTable[4])(thisPtr, pData, ref pSizeOfData);
            }
        }
    }
}
