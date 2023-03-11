using Lsj.Util.Win32.BaseTypes;
using System;
using static Lsj.Util.Win32.DirectX.Constants;

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
    public unsafe struct IDirect3DStateBlock9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Capture the current value of states that are included in a stateblock.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails because capture cannot be done while in record mode, the return value is <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="Capture"/> method captures current values for states within an existing state block.
        /// It does not capture the entire state of the device. For example:
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
        /// Creating an empty stateblock and calling the <see cref="Capture"/> method does nothing if no states have been set.
        /// The <see cref="Capture"/> method will not capture information for lights
        /// that are explicitly or implicitly created after the stateblock is created.
        /// </remarks>
        public HRESULT Capture()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }
    }
}
