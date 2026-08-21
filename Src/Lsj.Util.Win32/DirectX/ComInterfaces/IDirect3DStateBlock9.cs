using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DStateBlock9"/> interface to encapsulate render states.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dstateblock9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface can be used to save and restore pipeline state.
    /// It can also be used to capture the current state.
    /// </para>
    /// <para>
    /// The LPDIRECT3DSTATEBLOCK9 and PDIRECT3DSTATEBLOCK9 types are defined 
    /// as pointers to the <see cref="IDirect3DStateBlock9"/> interface.
    /// </para>
    /// <code>
    /// typedef struct IDirect3DStateBlock9 *LPDIRECT3DSTATEBLOCK9, *PDIRECT3DSTATEBLOCK9;
    /// </code>
    /// </remarks>
    [ComInterface(IID = "B07C4FE5-310D-4ba8-A23C-4F0F206F218B", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 5, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DStateBlock9
    {
        nint* _vTable;

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
        /// Capture the current value of states that are included in a stateblock.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails because capture cannot be done while in record mode, the return value is <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="Capture"/> method captures current values for states within an existing state block.
        /// It does not capture the entire state of the device.
        /// For example:
        /// </para>
        /// <code>
        /// IDirect3DStateBlock9* pStateBlock = NULL;
        /// 
        /// pd3dDevice->BeginStateBlock();
        /// // Add the ZENABLE state to the stateblock
        /// pd3dDevice->SetRenderState ( D3DRS_ZENABLE, D3DZB_TRUE );
        /// pd3dDevice->EndStateBlock ( &amp;pStateBlock );
        /// 
        /// // Change the current value that is stored in the state block
        /// pd3dDevice->SetRenderState ( D3DRS_ZENABLE, D3DZB_FALSE );
        /// pStateBlock->Capture();
        /// 
        /// pStateBlock->Release();
        /// </code>
        /// <para>
        /// Creating an empty stateblock and calling the Capture method does nothing if no states have been set.
        /// </para>
        /// <para>
        /// The Capture method will not capture information for lights
        /// that are explicitly or implicitly created after the stateblock is created.
        /// </para>
        /// </remarks>
        public HRESULT Capture()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Apply the state block to the current device state.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails while in record mode, the return value is <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT Apply()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }
    }
}
