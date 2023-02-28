using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DDevice9"/> interface to perform DrawPrimitive-based rendering,
    /// create resources, work with system-level variables, adjust gamma ramp levels, work with palettes, and create shaders.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3ddevice9"/>
    /// </para>
    /// </summary>
    public unsafe struct IDirect3DDevice9
    {
        IntPtr* _vTable;

        public HRESULT TestCooperativeLevel()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[3])(thisPtr);
            }
        }

        public UINT GetAvailableTextureMem()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[4])(thisPtr);
            }
        }

        public HRESULT EvictManagedResources()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }

        public HRESULT GetDirect3D([Out] out P<IDirect3D9> ppD3D9)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3D9>, HRESULT>)_vTable[6])(thisPtr, out ppD3D9);
            }
        }

        public HRESULT GetDeviceCaps([Out] out D3DCAPS9 pCaps)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DCAPS9, HRESULT>)_vTable[7])(thisPtr, out pCaps);
            }
        }

        public HRESULT GetDisplayMode([In] UINT iSwapChain, [Out] out D3DDISPLAYMODE pMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DDISPLAYMODE, HRESULT>)_vTable[8])(thisPtr, iSwapChain, out pMode);
            }
        }

        public HRESULT GetCreationParameters([Out] out D3DDEVICE_CREATION_PARAMETERS pParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DDEVICE_CREATION_PARAMETERS, HRESULT>)_vTable[9])(thisPtr, out pParameters);
            }
        }

        public HRESULT SetCursorProperties([In] UINT XHotSpot, [In] UINT YHotSpot, [In] in IDirect3DSurface9 pCursorBitmap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, in IDirect3DSurface9, HRESULT>)_vTable[10])(thisPtr, XHotSpot, YHotSpot, pCursorBitmap);
            }
        }

        public void SetCursorPosition([In] int X, [In] int Y, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, int, int, DWORD, void>)_vTable[11])(thisPtr, X, Y, Flags);
            }
        }

        public BOOL ShowCursor([In] BOOL bShow)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, BOOL>)_vTable[12])(thisPtr, bShow);
            }
        }

        public HRESULT CreateAdditionalSwapChain([In] in D3DPRESENT_PARAMETERS pPresentationParameters, [Out] out P<IDirect3DSwapChain9> pSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DPRESENT_PARAMETERS, out P<IDirect3DSwapChain9>, HRESULT>)_vTable[13])
                    (thisPtr, in pPresentationParameters, out pSwapChain);
            }
        }

        public HRESULT GetSwapChain([In] UINT iSwapChain, [Out] out P<IDirect3DSwapChain9> pSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDirect3DSwapChain9>, HRESULT>)_vTable[14])(thisPtr, iSwapChain, out pSwapChain);
            }
        }

        public UINT GetNumberOfSwapChains()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[15])(thisPtr);
            }
        }

        public HRESULT Reset([In] in D3DPRESENT_PARAMETERS pPresentationParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DPRESENT_PARAMETERS, HRESULT>)_vTable[16])(thisPtr, pPresentationParameters);
            }
        }

        public HRESULT Present([In] in RECT pSourceRect, [In] in RECT pDestRect, [In] HWND hDestWindowOverride, [In] in RGNDATA pDirtyRegion)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, in RECT, HWND, in RGNDATA, HRESULT>)_vTable[17])
                    (thisPtr, in pSourceRect, in pDestRect, hDestWindowOverride, in pDirtyRegion);
            }
        }

        public HRESULT GetBackBuffer([In] UINT iSwapChain, [In] UINT iBackBuffer, [In] D3DBACKBUFFER_TYPE Type, [Out] out P<IDirect3DSurface9> ppBackBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DBACKBUFFER_TYPE, out P<IDirect3DSurface9>, HRESULT>)_vTable[18])
                    (thisPtr, iSwapChain, iBackBuffer, Type, out ppBackBuffer);
            }
        }

        public HRESULT GetRasterStatus([In] UINT iSwapChain, [Out] out D3DRASTER_STATUS pRasterStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DRASTER_STATUS, HRESULT>)_vTable[19])(thisPtr, iSwapChain, out pRasterStatus);
            }
        }

        public HRESULT SetDialogBoxMode([In] BOOL bEnableDialogs)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[20])(thisPtr, bEnableDialogs);
            }
        }

        public void SetGammaRamp([In] UINT iSwapChain, [In] DWORD Flags, [In] in D3DGAMMARAMP pRamp)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, in D3DGAMMARAMP, HRESULT>)_vTable[21])(thisPtr, iSwapChain, Flags, pRamp);
            }
        }

        public void GetGammaRamp([In] UINT iSwapChain, [Out] out D3DGAMMARAMP pRamp)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DGAMMARAMP, HRESULT>)_vTable[22])(thisPtr, iSwapChain, out pRamp);
            }
        }

        public HRESULT CreateTexture([In] UINT Width, [In] UINT Height, [In] UINT Levels, [In] DWORD Usage,
            [In] D3DFORMAT Format, [In] D3DPOOL Pool, [Out] out P<IDirect3DTexture9> ppTexture, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DTexture9>, ref HANDLE, HRESULT>)_vTable[23])
                    (thisPtr, Width, Height, Levels, Usage, Format, Pool, out ppTexture, ref pSharedHandle);
            }
        }

        public HRESULT CreateVolumeTexture([In] UINT Width, [In] UINT Height, [In] UINT Depth, [In] UINT Levels, [In] DWORD Usage,
            [In] D3DFORMAT Format, [In] D3DPOOL Pool, [Out] out P<IDirect3DVolumeTexture9> ppVolumeTexture, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DVolumeTexture9>, ref HANDLE, HRESULT>)_vTable[24])
                    (thisPtr, Width, Height, Depth, Levels, Usage, Format, Pool, out ppVolumeTexture, ref pSharedHandle);
            }
        }

        public HRESULT CreateCubeTexture([In] UINT EdgeLength, [In] UINT Levels, [In] DWORD Usage, [In] D3DFORMAT Format,
            [In] D3DPOOL Pool, [Out] out P<IDirect3DCubeTexture9> ppCubeTexture, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DCubeTexture9>, ref HANDLE, HRESULT>)_vTable[25])
                    (thisPtr, EdgeLength, Levels, Usage, Format, Pool, out ppCubeTexture, ref pSharedHandle);
            }
        }

        public HRESULT CreateVertexBuffer([In] UINT Length, [In] DWORD Usage, [In] DWORD FVF, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DVertexBuffer9> ppVertexBuffer, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, DWORD, D3DPOOL, out P<IDirect3DVertexBuffer9>, ref HANDLE, HRESULT>)_vTable[26])
                    (thisPtr, Length, Usage, FVF, Pool, out ppVertexBuffer, ref pSharedHandle);
            }
        }

        public HRESULT CreateIndexBuffer([In] UINT Length, [In] DWORD Usage, [In] D3DFORMAT Format, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DIndexBuffer9> ppIndexBuffer, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DIndexBuffer9>, ref HANDLE, HRESULT>)_vTable[27])
                    (thisPtr, Length, Usage, Format, Pool, out ppIndexBuffer, ref pSharedHandle);
            }
        }

        public HRESULT CreateRenderTarget([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format, [In] D3DMULTISAMPLE_TYPE MultiSample,
            [In] DWORD MultisampleQuality, [In] BOOL Discard, [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DMULTISAMPLE_TYPE, DWORD, BOOL, out P<IDirect3DSurface9>, ref HANDLE, HRESULT>)_vTable[28])
                    (thisPtr, Width, Height, Format, MultiSample, MultisampleQuality, Discard, out ppSurface, ref pSharedHandle);
            }
        }

        public HRESULT UpdateSurface([In] in IDirect3DSurface9 pSourceSurface, [In] in RECT pSourceRect,
            [In] in IDirect3DSurface9 pDestinationSurface, [In] in POINT pDestPoint)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in RECT, in IDirect3DSurface9, in POINT, HRESULT>)_vTable[29])
                    (thisPtr, pSourceSurface, pSourceRect, pDestinationSurface, pDestPoint);
            }
        }

        public HRESULT UpdateTexture([In] in IDirect3DBaseTexture9 pSourceTexture, [In] in IDirect3DBaseTexture9 pDestinationTexture)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DBaseTexture9, in IDirect3DBaseTexture9, HRESULT>)_vTable[30])(thisPtr, pSourceTexture, pDestinationTexture);
            }
        }

        public HRESULT GetRenderTargetData([In] in IDirect3DSurface9 pRenderTarget, [In] in IDirect3DSurface9 pDestSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in IDirect3DSurface9, HRESULT>)_vTable[31])(thisPtr, pRenderTarget, pDestSurface);
            }
        }

        public HRESULT GetFrontBufferData([In] UINT iSwapChain, [In] in IDirect3DSurface9 pDestSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in IDirect3DSurface9, HRESULT>)_vTable[32])(thisPtr, iSwapChain, pDestSurface);
            }
        }

        public HRESULT StretchRect([In] in IDirect3DSurface9 pSourceSurface, [In] in RECT pSourceRect,
            [In] in IDirect3DSurface9 pDestinationSurface, [In] in RECT pDestRect, [In] D3DTEXTUREFILTERTYPE Filter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in RECT, in IDirect3DSurface9, in RECT, D3DTEXTUREFILTERTYPE, HRESULT>)_vTable[33])
                    (thisPtr, pSourceSurface, pSourceRect, pDestinationSurface, pDestRect, Filter);
            }
        }

        public HRESULT ColorFill([In] in IDirect3DSurface9 pSurface, [In] in RECT pRect, [In] D3DCOLOR color)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in RECT, D3DCOLOR, HRESULT>)_vTable[34])(thisPtr, pSurface, pRect, color);
            }
        }

        public HRESULT CreateOffscreenPlainSurface([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DPOOL, out P<IDirect3DSurface9>, ref HANDLE, HRESULT>)_vTable[35])
                    (thisPtr, Width, Height, Format, Pool, out ppSurface, ref pSharedHandle);
            }
        }

        public HRESULT SetRenderTarget([In] DWORD RenderTargetIndex, [In] in IDirect3DSurface9 pRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in IDirect3DSurface9, HRESULT>)_vTable[36])(thisPtr, RenderTargetIndex, pRenderTarget);
            }
        }

        public HRESULT GetRenderTarget([In] DWORD RenderTargetIndex, [Out] out P<IDirect3DSurface9> ppRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IDirect3DSurface9>, HRESULT>)_vTable[37])(thisPtr, RenderTargetIndex, out ppRenderTarget);
            }
        }

        public HRESULT SetDepthStencilSurface([In] in IDirect3DSurface9 pNewZStencil)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, HRESULT>)_vTable[38])(thisPtr, pNewZStencil);
            }
        }

        public HRESULT GetDepthStencilSurface([Out] out P<IDirect3DSurface9> ppZStencilSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DSurface9>, HRESULT>)_vTable[39])(thisPtr, out ppZStencilSurface);
            }
        }

        public HRESULT BeginScene()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[40])(thisPtr);
            }
        }

        public HRESULT EndScene()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[41])(thisPtr);
            }
        }

        public HRESULT Clear([In] DWORD Count, [In] D3DRECT[] pRects, [In] DWORD Flags, [In] D3DCOLOR Color, [In] float Z, [In] DWORD Stencil)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DRECT[], DWORD, D3DCOLOR, float, DWORD, HRESULT>)_vTable[42])
                    (thisPtr, Count, pRects, Flags, Color, Z, Stencil);
            }
        }

        public HRESULT SetTransform([In] D3DTRANSFORMSTATETYPE State, [In] in D3DMATRIX pMatrix)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTRANSFORMSTATETYPE, in D3DMATRIX, HRESULT>)_vTable[43])(thisPtr, State, pMatrix);
            }
        }

        public HRESULT GetTransform([In] D3DTRANSFORMSTATETYPE State, [Out] out D3DMATRIX pMatrix)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTRANSFORMSTATETYPE, out D3DMATRIX, HRESULT>)_vTable[44])(thisPtr, State, out pMatrix);
            }
        }

        public HRESULT MultiplyTransform([In] D3DTRANSFORMSTATETYPE unnamedParam1, [In] in D3DMATRIX unnamedParam2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTRANSFORMSTATETYPE, in D3DMATRIX, HRESULT>)_vTable[45])(thisPtr, unnamedParam1, unnamedParam2);
            }
        }

        public HRESULT SetViewport([In] in D3DVIEWPORT9 pViewport)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DVIEWPORT9, HRESULT>)_vTable[46])(thisPtr, pViewport);
            }
        }

        public HRESULT GetViewport([Out] out D3DVIEWPORT9 pViewport)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DVIEWPORT9, HRESULT>)_vTable[47])(thisPtr, out pViewport);
            }
        }

        public HRESULT SetMaterial([In] in D3DMATERIAL9 pMaterial)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DMATERIAL9, HRESULT>)_vTable[48])(thisPtr, pMaterial);
            }
        }

        public HRESULT GetMaterial([Out] out D3DMATERIAL9 pMaterial)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DMATERIAL9, HRESULT>)_vTable[49])(thisPtr, out pMaterial);
            }
        }

        public HRESULT SetLight([In] DWORD Index, [In] in D3DLIGHT9 unnamedParam2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in D3DLIGHT9, HRESULT>)_vTable[50])(thisPtr, Index, unnamedParam2);
            }
        }

        public HRESULT GetLight([In] DWORD Index, [Out] out D3DLIGHT9 unnamedParam2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out D3DLIGHT9, HRESULT>)_vTable[51])(thisPtr, Index, out unnamedParam2);
            }
        }

        public HRESULT LightEnable([In] DWORD Index, [In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, BOOL, HRESULT>)_vTable[52])(thisPtr, Index, Enable);
            }
        }

        public HRESULT GetLightEnable([In] DWORD Index, [Out] out BOOL pEnable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out BOOL, HRESULT>)_vTable[53])(thisPtr, Index, out pEnable);
            }
        }

        public HRESULT SetClipPlane([In] DWORD Index, [In] float[] pPlane)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, float[], HRESULT>)_vTable[54])(thisPtr, Index, pPlane);
            }
        }

        public HRESULT GetClipPlane([In] DWORD Index, [Out] float[] pPlane)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, float[], HRESULT>)_vTable[55])(thisPtr, Index, pPlane);
            }
        }

        public HRESULT SetRenderState([In] D3DRENDERSTATETYPE State, [In] DWORD Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DRENDERSTATETYPE, DWORD, HRESULT>)_vTable[56])(thisPtr, State, Value);
            }
        }

        public HRESULT GetRenderState([In] D3DRENDERSTATETYPE State, [Out] out DWORD pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DRENDERSTATETYPE, out DWORD, HRESULT>)_vTable[57])(thisPtr, State, out pValue);
            }
        }

        public HRESULT CreateStateBlock([In] D3DSTATEBLOCKTYPE Type, [Out] out P<IDirect3DStateBlock9> ppSB)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DSTATEBLOCKTYPE, out P<IDirect3DStateBlock9>, HRESULT>)_vTable[58])(thisPtr, Type, out ppSB);
            }
        }

        public HRESULT BeginStateBlock()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[59])(thisPtr);
            }
        }

        public HRESULT EndStateBlock([Out] out P<IDirect3DStateBlock9> ppSB)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DStateBlock9>, HRESULT>)_vTable[60])(thisPtr, out ppSB);
            }
        }

        public HRESULT SetClipStatus([In] in D3DCLIPSTATUS9 pClipStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DCLIPSTATUS9, HRESULT>)_vTable[61])(thisPtr, pClipStatus);
            }
        }

        public HRESULT GetClipStatus([Out] out D3DCLIPSTATUS9 pClipStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DCLIPSTATUS9, HRESULT>)_vTable[62])(thisPtr, out pClipStatus);
            }
        }

        public HRESULT GetTexture([In] DWORD Stage, [Out] out P<IDirect3DBaseTexture9> ppTexture)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IDirect3DBaseTexture9>, HRESULT>)_vTable[63])(thisPtr, Stage, out ppTexture);
            }
        }

        public HRESULT SetTexture([In] DWORD Stage, [In] in IDirect3DBaseTexture9 pTexture)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in IDirect3DBaseTexture9, HRESULT>)_vTable[64])(thisPtr, Stage, pTexture);
            }
        }

        public HRESULT GetTextureStageState([In] DWORD Stage, [In] D3DTEXTURESTAGESTATETYPE Type, [Out] out DWORD pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DTEXTURESTAGESTATETYPE, out DWORD, HRESULT>)_vTable[65])(thisPtr, Stage, Type, out pValue);
            }
        }

        public HRESULT SetTextureStageState([In] DWORD Stage, [In] D3DTEXTURESTAGESTATETYPE Type, [In] DWORD Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DTEXTURESTAGESTATETYPE, DWORD, HRESULT>)_vTable[66])(thisPtr, Stage, Type, Value);
            }
        }

        public HRESULT GetSamplerState([In] DWORD Sampler, [In] D3DSAMPLERSTATETYPE Type, [Out] out DWORD pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DSAMPLERSTATETYPE, out DWORD, HRESULT>)_vTable[67])(thisPtr, Sampler, Type, out pValue);
            }
        }

        public HRESULT SetSamplerState([In] DWORD Sampler, [In] D3DSAMPLERSTATETYPE Type, [In] DWORD Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DSAMPLERSTATETYPE, DWORD, HRESULT>)_vTable[68])(thisPtr, Sampler, Type, Value);
            }
        }

        public HRESULT ValidateDevice()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[69])(thisPtr);
            }
        }

        public HRESULT SetPaletteEntries([In] UINT PaletteNumber, [In] PALETTEENTRY[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, PALETTEENTRY[], HRESULT>)_vTable[70])(thisPtr, PaletteNumber, pEntries);
            }
        }

        public HRESULT GetPaletteEntries([In] UINT PaletteNumber, [Out] PALETTEENTRY[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, PALETTEENTRY[], HRESULT>)_vTable[71])(thisPtr, PaletteNumber, pEntries);
            }
        }

        public HRESULT SetCurrentTexturePalette([In] UINT PaletteNumber)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[72])(thisPtr, PaletteNumber);
            }
        }

        public HRESULT GetCurrentTexturePalette([Out] out UINT PaletteNumber)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[73])(thisPtr, out PaletteNumber);
            }
        }

        public HRESULT SetScissorRect([In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, HRESULT>)_vTable[74])(thisPtr, pRect);
            }
        }

        public void GetScissorRect([Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out RECT, HRESULT>)_vTable[75])(thisPtr, out pRect);
            }
        }

        public HRESULT SetSoftwareVertexProcessing([In] BOOL bSoftware)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[76])(thisPtr, bSoftware);
            }
        }

        public BOOL GetSoftwareVertexProcessing()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[77])(thisPtr);
            }
        }

        public HRESULT SetNPatchMode([In] float nSegments)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, float, HRESULT>)_vTable[78])(thisPtr, nSegments);
            }
        }

        public float GetNPatchMode()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, float>)_vTable[79])(thisPtr);
            }
        }

        public HRESULT DrawPrimitive([In] D3DPRIMITIVETYPE PrimitiveType, [In] UINT StartVertex, [In] UINT PrimitiveCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, UINT, UINT, HRESULT>)_vTable[80])(thisPtr, PrimitiveType, StartVertex, PrimitiveCount);
            }
        }

        public HRESULT DrawIndexedPrimitive([In] D3DPRIMITIVETYPE unnamedParam1, [In] INT BaseVertexIndex, [In] UINT MinVertexIndex,
            [In] UINT NumVertices, [In] UINT startIndex, [In] UINT primCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, INT, UINT, UINT, UINT, UINT, HRESULT>)_vTable[81])
                    (thisPtr, unnamedParam1, BaseVertexIndex, MinVertexIndex, NumVertices, startIndex, primCount);
            }
        }

        public HRESULT DrawPrimitiveUP([In] D3DPRIMITIVETYPE PrimitiveType, [In] UINT PrimitiveCount, [In] IntPtr pVertexStreamZeroData, [In] UINT VertexStreamZeroStride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, UINT, IntPtr, UINT, HRESULT>)_vTable[82])
                    (thisPtr, PrimitiveType, PrimitiveCount, pVertexStreamZeroData, VertexStreamZeroStride);
            }
        }

        public HRESULT DrawIndexedPrimitiveUP([In] D3DPRIMITIVETYPE PrimitiveType, [In] UINT MinVertexIndex, [In] UINT NumVertices,
            [In] UINT PrimitiveCount, [In] IntPtr pIndexData, [In] D3DFORMAT IndexDataFormat, [In] IntPtr pVertexStreamZeroData, [In] UINT VertexStreamZeroStride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, UINT, UINT, UINT, IntPtr, D3DFORMAT, IntPtr, UINT, HRESULT>)_vTable[83])
                    (thisPtr, PrimitiveType, MinVertexIndex, NumVertices, PrimitiveCount, pIndexData, IndexDataFormat, pVertexStreamZeroData, VertexStreamZeroStride);
            }
        }

        public HRESULT ProcessVertices([In] UINT SrcStartIndex, [In] UINT DestIndex, [In] UINT VertexCount,
            [In] in IDirect3DVertexBuffer9 pDestBuffer, [In] in IDirect3DVertexDeclaration9 pVertexDecl, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, in IDirect3DVertexBuffer9, in IDirect3DVertexDeclaration9, DWORD, HRESULT>)_vTable[84])
                    (thisPtr, SrcStartIndex, DestIndex, VertexCount, pDestBuffer, pVertexDecl, Flags);
            }
        }

        public HRESULT CreateVertexDeclaration([In] D3DVERTEXELEMENT9[] pVertexElements, [Out] out P<IDirect3DVertexDeclaration9> ppDecl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DVERTEXELEMENT9[], out P<IDirect3DVertexDeclaration9>, HRESULT>)_vTable[85])(thisPtr, pVertexElements, out ppDecl);
            }
        }

        public HRESULT SetVertexDeclaration([In] in IDirect3DVertexDeclaration9 pDecl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DVertexDeclaration9, HRESULT>)_vTable[86])(thisPtr, pDecl);
            }
        }

        public HRESULT GetVertexDeclaration([Out] out P<IDirect3DVertexDeclaration9> ppDecl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DVertexDeclaration9>, HRESULT>)_vTable[87])(thisPtr, out ppDecl);
            }
        }

        public HRESULT SetFVF([In] DWORD FVF)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[88])(thisPtr, FVF);
            }
        }

        public void GetFVF([Out] out DWORD pFVF)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[89])(thisPtr, out pFVF);
            }
        }

        public HRESULT CreateVertexShader([In] IntPtr pFunction, [Out] out P<IDirect3DVertexShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, out P<IDirect3DVertexShader9>, HRESULT>)_vTable[90])(thisPtr, pFunction, out ppShader);
            }
        }

        public HRESULT SetVertexShader([In] in IDirect3DVertexShader9 pShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DVertexShader9, HRESULT>)_vTable[91])(thisPtr, pShader);
            }
        }

        public HRESULT GetVertexShader([Out] out P<IDirect3DVertexShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DVertexShader9>, HRESULT>)_vTable[92])(thisPtr, out ppShader);
            }
        }

        public HRESULT SetVertexShaderConstantF([In] UINT StartRegister, [In] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[93])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        public HRESULT GetVertexShaderConstantF([In] UINT StartRegister, [Out] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[94])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        public HRESULT SetVertexShaderConstantI([In] UINT StartRegister, [In] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[95])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        public HRESULT GetVertexShaderConstantI([In] UINT StartRegister, [Out] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[96])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        public HRESULT SetVertexShaderConstantB([In] UINT StartRegister, [In] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[97])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        public HRESULT GetVertexShaderConstantB([In] UINT StartRegister, [Out] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[98])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        public HRESULT SetStreamSource([In] UINT StreamNumber, [In] in IDirect3DVertexBuffer9 pStreamData, [In] UINT OffsetInBytes, [In] UINT Stride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in IDirect3DVertexBuffer9, UINT, UINT, HRESULT>)_vTable[99])
                    (thisPtr, StreamNumber, pStreamData, OffsetInBytes, Stride);
            }
        }

        public HRESULT GetStreamSource([In] UINT StreamNumber, [Out] out P<IDirect3DVertexBuffer9> ppStreamData, [Out] out UINT pOffsetInBytes, [Out] out UINT pStride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDirect3DVertexBuffer9>, out UINT, out UINT, HRESULT>)_vTable[100])
                    (thisPtr, StreamNumber, out ppStreamData, out pOffsetInBytes, out pStride);
            }
        }

        public HRESULT SetStreamSourceFreq([In] UINT StreamNumber, [In] UINT Setting)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, HRESULT>)_vTable[101])(thisPtr, StreamNumber, Setting);
            }
        }

        public HRESULT GetStreamSourceFreq([In] UINT StreamNumber, [Out] out UINT pSetting)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out UINT, HRESULT>)_vTable[102])(thisPtr, StreamNumber, out pSetting);
            }
        }

        public HRESULT SetIndices([In] in IDirect3DIndexBuffer9 pIndexData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DIndexBuffer9, HRESULT>)_vTable[103])(thisPtr, pIndexData);
            }
        }

        public HRESULT GetIndices([Out] out P<IDirect3DIndexBuffer9> ppIndexData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DIndexBuffer9>, HRESULT>)_vTable[104])(thisPtr, out ppIndexData);
            }
        }

        public HRESULT CreatePixelShader([In] IntPtr pFunction, [Out] out P<IDirect3DPixelShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, out P<IDirect3DPixelShader9>, HRESULT>)_vTable[105])(thisPtr, pFunction, out ppShader);
            }
        }

        public HRESULT SetPixelShader([In] in IDirect3DPixelShader9 pShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DPixelShader9, HRESULT>)_vTable[106])(thisPtr, pShader);
            }
        }

        public HRESULT GetPixelShader([Out] out P<IDirect3DPixelShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DPixelShader9>, HRESULT>)_vTable[107])(thisPtr, out ppShader);
            }
        }

        public HRESULT SetPixelShaderConstantF([In] UINT StartRegister, [In] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[108])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        public HRESULT GetPixelShaderConstantF([In] UINT StartRegister, [Out] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[109])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        public HRESULT SetPixelShaderConstantI([In] UINT StartRegister, [In] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[110])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        public HRESULT GetPixelShaderConstantI([In] UINT StartRegister, [Out] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[111])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        public HRESULT SetPixelShaderConstantB([In] UINT StartRegister, [In] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[112])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        public HRESULT GetPixelShaderConstantB([In] UINT StartRegister, [Out] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[113])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        public HRESULT DrawRectPatch([In] UINT Handle, [In] float[] pNumSegs, [In] in D3DRECTPATCH_INFO pRectPatchInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], in D3DRECTPATCH_INFO, HRESULT>)_vTable[114])(thisPtr, Handle, pNumSegs, pRectPatchInfo);
            }
        }

        public HRESULT DrawTriPatch([In] UINT Handle, [In] float[] pNumSegs, [In] in D3DTRIPATCH_INFO pTriPatchInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], in D3DTRIPATCH_INFO, HRESULT>)_vTable[115])(thisPtr, Handle, pNumSegs, pTriPatchInfo);
            }
        }

        public HRESULT DeletePatch([In] UINT Handle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[116])(thisPtr, Handle);
            }
        }

        public HRESULT CreateQuery([In] D3DQUERYTYPE Type, [Out] out P<IDirect3DQuery9> ppQuery)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DQUERYTYPE, out P<IDirect3DQuery9>, HRESULT>)_vTable[117])(thisPtr, Type, out ppQuery);
            }
        }
    }
}
