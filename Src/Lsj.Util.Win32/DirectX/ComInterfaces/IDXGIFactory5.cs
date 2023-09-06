using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface enables a single method to support variable refresh rate displays.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nn-dxgi1_5-idxgifactory5"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIFactory5
    {
        IntPtr* _vTable;

        /// <summary>
        /// Used to check for hardware feature support.
        /// </summary>
        /// <param name="Feature">
        /// Specifies one member of <see cref="DXGI_FEATURE"/> to query support for.
        /// </param>
        /// <param name="pFeatureSupportData">
        /// Specifies a pointer to a buffer that will be filled with data that describes the feature support.
        /// </param>
        /// <param name="FeatureSupportDataSize">
        /// The size, in bytes, of <paramref name="pFeatureSupportData"/>.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code.
        /// </returns>
        /// <remarks>
        /// Refer to the description of <see cref="DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING"/>.
        /// </remarks>
        public HRESULT CheckFeatureSupport([In] DXGI_FEATURE Feature, [In] IntPtr pFeatureSupportData, [In] UINT FeatureSupportDataSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FEATURE, IntPtr, UINT, HRESULT>)_vTable[28])(thisPtr, Feature, pFeatureSupportData, FeatureSupportDataSize);
            }
        }
    }
}
