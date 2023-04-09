using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREFILTERTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;


namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DBaseTexture9"/> interface to manipulate texture resources including cube and volume textures.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dbasetexture9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDirect3DBaseTexture9"/> interface assigned to a particular stage for a device
    /// is obtained by calling the <see cref="IDirect3DDevice9.GetTexture"/> method.
    /// The LPDIRECT3DBASETEXTURE9 and PDIRECT3DBASETEXTURE9 types are defined as pointers to the IDirect3DBaseTexture9 interface.
    /// <code>
    /// typedef struct IDirect3DBaseTexture9 *LPDIRECT3DBASETEXTURE9, *PDIRECT3DBASETEXTURE9;
    /// </code>
    /// </remarks>
    public unsafe struct IDirect3DBaseTexture9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Sets the most detailed level-of-detail for a managed texture.
        /// </summary>
        /// <param name="LODNew">
        /// Most detailed level-of-detail value to set for the mipmap chain.
        /// </param>
        /// <returns>
        /// A DWORD value, clamped to the maximum level-of-detail value (one less than the total number of levels).
        /// Subsequent calls to this method will return the clamped value, not the level-of-detail value that was previously set.
        /// </returns>
        /// <remarks>
        /// This method applies to the following interfaces, which inherit from <see cref="IDirect3DBaseTexture9"/>.
        /// <see cref="IDirect3DCubeTexture9"/>, <see cref="IDirect3DTexture9"/>,
        /// <see cref="IDirect3DVolumeTexture9"/>, <see cref="IDirect3DResource9"/>
        /// <see cref="SetLOD"/> is used for level-of-detail control of managed textures. This method returns 0 on nonmanaged textures.
        /// <see cref="SetLOD"/> communicates to the Direct3D texture manager the most detailed mipmap in the chain that should be loaded into local video memory.
        /// For example, in a five-level mipmap chain, setting <paramref name="LODNew"/> to 2 indicates that
        /// the texture manager should load only mipmap levels 2 through 4 into local video memory at any given time.
        /// More specifically, if the texture was created with the dimensions of 256x256,
        /// setting the most detailed level to 0 indicates that 256 x 256 is the largest mipmap available,
        /// setting the most detailed level to 1 indicates that 128 x 128 is the largest mipmap available,
        /// and so on, up to the most detailed mip level (the smallest texture size) for the chain.
        /// </remarks>
        public DWORD SetLOD([In] DWORD LODNew)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, DWORD>)_vTable[11])(thisPtr, LODNew);
            }
        }

        /// <summary>
        /// Returns a value clamped to the maximum level-of-detail set for a managed texture (this method is not supported for an unmanaged texture).
        /// </summary>
        /// <returns>
        /// A <see cref="DWORD"/> value, clamped to the maximum level-of-detail value (one less than the total number of levels).
        /// Calling <see cref="GetLOD"/> on an unmanaged texture is not supported and will result in a D3DERR error code being returned.
        /// </returns>
        public DWORD GetLOD()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD>)_vTable[12])(thisPtr);
            }
        }

        /// <summary>
        /// Returns the number of texture levels in a multilevel texture.
        /// </summary>
        /// <returns>
        /// A <see cref="DWORD"/> value that indicates the number of texture levels in a multilevel texture.
        /// </returns>
        /// <remarks>
        /// Warning
        /// If you create a texture with <see cref="D3DUSAGE_AUTOGENMIPMAP"/> to make that texture automatically generate sublevels,
        /// <see cref="GetLevelCount"/> always returns 1 for the number of levels.
        /// This method applies to the following interfaces, which inherit from <see cref="IDirect3DBaseTexture9"/>.
        /// <see cref="IDirect3DCubeTexture9"/>, <see cref="IDirect3DTexture9"/>, <see cref="IDirect3DVolumeTexture9"/>
        /// </remarks>
        public DWORD GetLevelCount()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD>)_vTable[13])(thisPtr);
            }
        }

        /// <summary>
        /// Set the filter type that is used for automatically generated mipmap sublevels.
        /// </summary>
        /// <param name="FilterType">
        /// Filter type.
        /// See <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// This method will fail if the filter type is invalid or not supported.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Changing the filter type "dirties" the mipmap sublevels and causes them to be regenerated.
        /// The (default) filter type set at texture creation time is <see cref="D3DTEXF_LINEAR"/>.
        /// If the driver does not support a linear filter, the filter type will be set to <see cref="D3DTEXF_POINT"/>.
        /// All filter types supported by the driver for regular texture filtering are supported for autogeneration except <see cref="D3DTEXF_NONE"/>.
        /// SetAutoGenFilterType will fail unless the driver sets the appropriate D3DPTFILTERCAPS_MINFxxx caps.
        /// These values are specified in the <see cref="D3DCAPS9.TextureFilterCaps"/> and/or <see cref="D3DCAPS9.CubeTextureFilterCaps"/> members of <see cref="D3DCAPS9"/>.
        /// For more information about texture filter types, see <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// This method has no effect if the texture is not created with <see cref="D3DUSAGE_AUTOGENMIPMAP"/>.
        /// In this case, no failure is returned.
        /// For more information about usage constants, see <see cref="D3DUSAGE"/>.
        /// </remarks>
        public DWORD SetAutoGenFilterType([In] D3DTEXTUREFILTERTYPE FilterType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTEXTUREFILTERTYPE, DWORD>)_vTable[14])(thisPtr, FilterType);
            }
        }

        /// <summary>
        /// Get the filter type that is used for automatically generated mipmap sublevels.
        /// </summary>
        /// <returns>
        /// Filter type.
        /// See <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// A texture must be created with <see cref="D3DUSAGE_AUTOGENMIPMAP"/> to use this method.
        /// Any other usage value will cause this method to return <see cref="D3DTEXF_NONE"/>.
        /// </returns>
        /// <remarks>
        /// Changing the filter type "dirties" the mipmap sublevels and causes them to be regenerated.
        /// The (default) filter type set at texture creation time is <see cref="D3DTEXF_LINEAR"/>.
        /// If the driver doesn't support a linear filter, the filter type will be set to <see cref="D3DTEXF_POINT"/>.
        /// All filter types supported by the driver for regular texture filtering are supported for autogeneration except <see cref="D3DTEXF_NONE"/>.
        /// For each resource type, drivers should support all the filter types reported in the corresponding texture, CubeTexture, and volumetexture filter caps.
        /// For more information about texture types, see <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// This method has no effect if the texture is not created with <see cref="D3DUSAGE_AUTOGENMIPMAP"/>.
        /// </remarks>
        public D3DTEXTUREFILTERTYPE GetAutoGenFilterType()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTEXTUREFILTERTYPE>)_vTable[15])(thisPtr);
            }
        }

        /// <summary>
        /// Generate mipmap sublevels.
        /// </summary>
        /// <remarks>
        /// An application can generate mipmap sublevels at any time by calling <see cref="GenerateMipSubLevels"/>.
        /// To have mipmap sublevels generated automatically at texture creation time (see Automatic Generation of Mipmaps (Direct3D 9)),
        /// specify <see cref="D3DUSAGE_AUTOGENMIPMAP"/> during <see cref="IDirect3DDevice9.CreateTexture"/>,
        /// <see cref="IDirect3DDevice9.CreateCubeTexture"/>, and <see cref="IDirect3DDevice9.CreateVolumeTexture"/>.
        /// For more information about usage constants, see <see cref="D3DUSAGE"/>.
        /// </remarks>
        public void GenerateMipSubLevels()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[16])(thisPtr);
            }
        }
    }
}
