using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CREATE_DEVICE_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// <see cref="ID3D11Device2"/> adds new methods to those in <see cref="ID3D11Device1"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nn-d3d11_2-id3d11device2"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "9d06dffa-d1e5-4d07-83a8-1bb123f2f841", BeginVTableSlotIndex = 49, EndVTableSlotIndex = 52,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D11Device), typeof(ID3D11Device1)])]
    public unsafe struct ID3D11Device2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets an immediate context, which can play back command lists.
        /// </summary>
        /// <param name="ppImmediateContext">
        /// Upon completion of the method,
        /// the passed pointer to an <see cref="ID3D11DeviceContext2"/> interface pointer is initialized.
        /// </param>
        /// <remarks>
        /// <para>
        /// The <see cref="GetImmediateContext2"/> method returns an <see cref="ID3D11DeviceContext2"/> object
        /// that represents an immediate context, which is used to perform rendering that you want immediately submitted to a device.
        /// For most apps, an immediate context is the primary object that is used to draw your scene.
        /// </para>
        /// <para>
        /// The <see cref="GetImmediateContext2"/> method increments the reference count of the immediate context by one.
        /// Therefore, you must call <see cref="IUnknown.Release"/> on the returned interface pointer
        /// when you are done with it to avoid a memory leak.
        /// </para>
        /// </remarks>
        public void GetImmediateContext2([Out] out P<ID3D11DeviceContext2> ppImmediateContext)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11DeviceContext2>, HRESULT>)_vTable[49])(thisPtr, out ppImmediateContext);
            }
        }

        /// <summary>
        /// Creates a deferred context, which can record command lists.
        /// </summary>
        /// <param name="ContextFlags">
        /// Reserved for future use.
        /// Pass 0.
        /// </param>
        /// <param name="ppDeferredContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext2"/> interface pointer is initialized.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/>
        /// if the video card has been physically removed from the system,
        /// or a driver upgrade for the video card has occurred.
        /// If this error occurs, you should destroy and recreate the device.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Returns <see cref="DXGI_ERROR_INVALID_CALL"/>
        /// if the <see cref="CreateDeferredContext2"/> method can't be called from the current context.
        /// For example, if the device was created with the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value,
        /// <see cref="CreateDeferredContext2"/> returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Returns <see cref="E_INVALIDARG"/>
        /// if the <paramref name="ContextFlags"/> parameter is invalid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Returns <see cref="E_OUTOFMEMORY"/> if the app has exhausted available memory.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A deferred context is a thread-safe context
        /// that you can use to record graphics commands on a thread other than the main rendering thread.
        /// By using a deferred context, you can record graphics commands into a command list
        /// that is encapsulated by the <see cref="ID3D11CommandList"/> interface.
        /// After you record all scene items, you can then submit them to the main render thread for final rendering.
        /// In this manner, you can perform rendering tasks concurrently
        /// across multiple threads and potentially improve performance in multi-core CPU scenarios.
        /// </para>
        /// <para>
        /// You can create multiple deferred contexts.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you use the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value to create the device,
        /// <see cref="CreateDeferredContext2"/> fails with <see cref="DXGI_ERROR_INVALID_CALL"/>,
        /// and you can't create a deferred context.
        /// For more information about deferred contexts, see Immediate and Deferred Rendering.
        /// </para>
        /// </remarks>
        public HRESULT CreateDeferredContext2([In] UINT ContextFlags, [Out] out P<ID3D11DeviceContext2> ppDeferredContext)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<ID3D11DeviceContext2>, HRESULT>)_vTable[50])
                    (thisPtr, ContextFlags, out ppDeferredContext);
            }
        }

        /// <summary>
        /// Gets info about how a tiled resource is broken into tiles.
        /// </summary>
        /// <param name="pTiledResource">
        /// A pointer to the tiled resource to get info about.
        /// </param>
        /// <param name="pNumTilesForEntireResource">
        /// A pointer to a variable that receives the number of tiles needed to store the entire tiled resource.
        /// </param>
        /// <param name="pPackedMipDesc">
        /// A pointer to a <see cref="D3D11_PACKED_MIP_DESC"/> structure that <see cref="GetResourceTiling"/>
        /// fills with info about how the tiled resource's mipmaps are packed.
        /// </param>
        /// <param name="pStandardTileShapeForNonPackedMips">
        /// A pointer to a <see cref="D3D11_TILE_SHAPE"/> structure
        /// that <see cref="GetResourceTiling"/> fills with info about the tile shape.
        /// This is info about how pixels fit in the tiles,
        /// independent of tiled resource's dimensions, not including packed mipmaps.
        /// If the entire tiled resource is packed,
        /// this parameter is meaningless because the tiled resource has no defined layout for packed mipmaps.
        /// In this situation, <see cref="GetResourceTiling"/> sets the members of <see cref="D3D11_TILE_SHAPE"/> to zeros.
        /// </param>
        /// <param name="pNumSubresourceTilings">
        /// A pointer to a variable that contains the number of tiles in the subresource.
        /// On input, this is the number of subresources to query tilings for;
        /// on output, this is the number that was actually retrieved
        /// at <paramref name="pSubresourceTilingsForNonPackedMips"/> (clamped to what's available).
        /// </param>
        /// <param name="FirstSubresourceTilingToGet">
        /// The number of the first subresource tile to get.
        /// <see cref="GetResourceTiling"/> ignores this parameter if the number that <paramref name="pNumSubresourceTilings"/> points to is 0.
        /// </param>
        /// <param name="pSubresourceTilingsForNonPackedMips">
        /// <para>
        /// A pointer to a <see cref="D3D11_SUBRESOURCE_TILING"/> structure
        /// that <see cref="GetResourceTiling"/> fills with info about subresource tiles.
        /// </para>
        /// <para>
        /// If subresource tiles are part of packed mipmaps,
        /// <see cref="GetResourceTiling"/> sets the members of <see cref="D3D11_SUBRESOURCE_TILING"/> to zeros,
        /// except the <see cref="D3D11_SUBRESOURCE_TILING.StartTileIndexInOverallResource"/> member,
        /// which <see cref="GetResourceTiling"/> sets to <see cref="D3D11_PACKED_TILE"/> (0xffffffff).
        /// The <see cref="D3D11_PACKED_TILE"/> constant indicates
        /// that the whole <see cref="D3D11_SUBRESOURCE_TILING"/> structure is meaningless for this situation,
        /// and the info that the <paramref name="pPackedMipDesc"/> parameter points to applies.
        /// </para>
        /// </param>
        /// <remarks>
        /// For more info about tiled resources, see Tiled resources.
        /// </remarks>
        public void GetResourceTiling([In] P<ID3D11Resource> pTiledResource, [Out] out UINT pNumTilesForEntireResource,
            [Out] out D3D11_PACKED_MIP_DESC pPackedMipDesc, [Out] out D3D11_TILE_SHAPE pStandardTileShapeForNonPackedMips,
            [In][Out] ref UINT pNumSubresourceTilings, [In] UINT FirstSubresourceTilingToGet, [Out] out D3D11_SUBRESOURCE_TILING pSubresourceTilingsForNonPackedMips)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, out UINT, out D3D11_PACKED_MIP_DESC, out D3D11_TILE_SHAPE,
                    ref UINT, UINT, out D3D11_SUBRESOURCE_TILING, HRESULT>)_vTable[51])
                    (thisPtr, pTiledResource, out pNumTilesForEntireResource, out pPackedMipDesc, out pStandardTileShapeForNonPackedMips,
                    ref pNumSubresourceTilings, FirstSubresourceTilingToGet, out pSubresourceTilingsForNonPackedMips);
            }
        }

        /// <summary>
        /// Get the number of quality levels available during multisampling.
        /// </summary>
        /// <param name="Format">
        /// The texture format during multisampling.
        /// </param>
        /// <param name="SampleCount">
        /// The number of samples during multisampling.
        /// </param>
        /// <param name="Flags">
        /// A combination of <see cref="D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG"/> values
        /// that are combined by using a bitwise OR operation.
        /// Currently, only <see cref="D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_TILED_RESOURCE"/> is supported.
        /// </param>
        /// <param name="pNumQualityLevels">
        /// A pointer to a variable the receives the number of quality levels supported by the adapter.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you multisample a texture, the number of quality levels available for an adapter
        /// is dependent on the texture format that you use and the number of samples that you request.
        /// The maximum number of quality levels is defined by <see cref="D3D11_MAX_MULTISAMPLE_SAMPLE_COUNT"/> in D3D11.h.
        /// If this method returns 0, the format and sample count combination is not supported for the installed adapter.
        /// </para>
        /// <para>
        /// Furthermore, the definition of a quality level is up to each hardware vendor to define,
        /// however no facility is provided by Direct3D to help discover this information.
        /// </para>
        /// <para>
        /// Note that FEATURE_LEVEL_10_1 devices are required to support 4x MSAA
        /// for all render targets except R32G32B32A32 and R32G32B32.
        /// FEATURE_LEVEL_11_0 devices are required to support 4x MSAA for all render target formats,
        /// and 8x MSAA for all render target formats except R32G32B32A32 formats.
        /// </para>
        /// </remarks>
        public HRESULT CheckMultisampleQualityLevels1([In] DXGI_FORMAT Format, [In] UINT SampleCount,
            [In] D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG Flags, [Out] out UINT pNumQualityLevels)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG, UINT, out UINT, HRESULT>)_vTable[52])
                    (thisPtr, Format, Flags, SampleCount, out pNumQualityLevels);
            }
        }
    }
}
