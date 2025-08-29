using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DVertexDeclaration9"/> interface to encapsulate the vertex shader declaration.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dvertexdeclaration9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A vertex shader declaration is made up of an array of vertex elements.
    /// </para>
    /// <para>
    /// The LPDIRECT3DVERTEXDECLARATION9 and PDIRECT3DVERTEXDECLARATION9 types are defined
    /// as pointers to the <see cref="IDirect3DVertexDeclaration9"/> interface.
    /// </para>
    /// <code>
    /// typedef struct IDirect3DVertexDeclaration9 *LPDIRECT3DVERTEXDECLARATION9, *PDIRECT3DVERTEXDECLARATION9;
    /// </code>
    /// </remarks>
    [ComInterface(IID = "DD13C59C-36FA-4098-A8FB-C7ED39DC8546", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 4, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DVertexDeclaration9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the current device.
        /// </summary>
        /// <param name="ppDevice">
        /// Pointer to the <see cref="IDirect3DDevice9"/> interface that is returned.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDevice([Out] out P<IDirect3DDevice9> ppDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DDevice9>, HRESULT>)_vTable[3])(thisPtr, out ppDevice);
            }
        }

        /// <summary>
        /// Gets the vertex shader declaration.
        /// </summary>
        /// <param name="pDeclto"></param>
        /// <param name="pNumElements">
        /// Number of elements in the array. 
        /// The application needs to allocate enough room for this.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The number of elements, <paramref name="pNumElements"/>,
        /// includes the <see cref="D3DDECL_END"/> macro, which ends the declaration.
        /// So the element count is actually one higher than the number of valid vertex elements.
        /// </para>
        /// <para>
        /// Here's an example that will return the vertex declaration array of up to 256 elements:C++
        /// </para>
        /// <code>
        /// D3DVERTEXELEMENT9 decl[MAXD3DDECLLENGTH];
        /// UINT numElements;
        /// HRESULT hr = m_pVertexDeclaration->GetDeclaration( decl, &amp;numElements);
        /// </code>
        /// <para>
        /// Specify <see langword="null"/> for <paramref name="pDeclto"/> get the number of elements in the declaration.
        /// </para>
        /// </remarks>
        public HRESULT GetDeclaration([Out] D3DVERTEXELEMENT9[] pDeclto, [Out] out UINT pNumElements)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DVERTEXELEMENT9[], out UINT, HRESULT>)_vTable[4])(thisPtr, pDeclto, out pNumElements);
            }
        }
    }
}
