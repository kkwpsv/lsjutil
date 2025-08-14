using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions.COM;
using Lsj.Util.Win32.WindowsRuntimeInterfaces;
using System;
using System.Threading.Tasks;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Extensions.WindowsRuntime
{
    /// <summary>
    /// WGC screen capturer
    /// </summary>
    public class WGCScreenCapturer : IDisposable
    {
        private P<IGraphicsCaptureItemInterop> _captureItemInterop;
        private P<ID3D11Device> _d3d11Device;
        private P<ID3D11DeviceContext> _d3d11DeviceContext;
        private P<IDirect3D11CaptureFramePoolStatics> _framePoolStatics;
        private P<IDirect3DDevice> _d3dDevice;

        /// <summary>
        /// The retry interval of <see cref="IDirect3D11CaptureFramePool.TryGetNextFrame"/> 
        /// </summary>
        public TimeSpan GetFrameRetryInterval { get; set; } = TimeSpan.FromMilliseconds(100);

        /// <summary>
        /// The max retry count of <see cref="IDirect3D11CaptureFramePool.TryGetNextFrame"/> 
        /// </summary>
        public int GetFrameMaxRetryCount { get; set; } = 10;

        /// <summary>
        /// 
        /// </summary>
        public WGCScreenCapturer()
        {
            _captureItemInterop = P<IGraphicsCaptureItemInterop>.FromPtr(WindowsRuntimeExtensions.GetActivationFactory("Windows.Graphics.Capture.GraphicsCaptureItem", IIDs.IID_IGraphicsCaptureItemInterop));

            var result = D3D11.D3D11CreateDevice(NullRef<IDXGIAdapter>(), D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE, NULL, 0, null, 0, (uint)D3D11.D3D11_SDK_VERSION, out _d3d11Device, out var featureLevel, out _d3d11DeviceContext);
            result.ThrowExceptionIfNotSucceed();

            var dxgiDevice = _d3d11Device.AsIUnknown().ToInterface<IDXGIDevice>(IIDs.IID_IDXGIDevice);

            try
            {
                result = D3D11.CreateDirect3D11DeviceFromDXGIDevice(dxgiDevice.Value, out var d3dDevice);
                result.ThrowExceptionIfNotSucceed();

                _d3dDevice = d3dDevice.AsIUnknown().ToInterface<IDirect3DDevice>(IIDs.IID_IDirect3DDevice, release: true, releaseOnFailed: true);

                _framePoolStatics = P<IDirect3D11CaptureFramePoolStatics>.FromPtr(WindowsRuntimeExtensions.GetActivationFactory("Windows.Graphics.Capture.Direct3D11CaptureFramePool", IIDs.IID_IDirect3D11CaptureFramePoolStatics));
            }
            finally
            {
                if (dxgiDevice != NULL)
                {
                    dxgiDevice.AsIUnknown().Value.Release();
                }
            }

        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_captureItemInterop != NULL)
            {
                _captureItemInterop.AsIUnknown().Value.Release();
            }
            if (_d3d11Device != NULL)
            {
                _d3d11Device.AsIUnknown().Value.Release();
            }
            if (_d3d11DeviceContext != NULL)
            {
                _d3d11DeviceContext.AsIUnknown().Value.Release();
            }
            if (_framePoolStatics != NULL)
            {
                _framePoolStatics.AsIUnknown().Value.Release();
            }
            if (_d3dDevice != NULL)
            {
                _d3dDevice.AsIUnknown().Value.Release();
            }
        }

        /// <summary>
        /// Capture a texture of monitor
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns></returns>
        public Task<P<ID3D11Texture2D>> CaptureMonitor(HMONITOR monitor)
        {
            var result = _captureItemInterop.Value.CreateForMonitor(monitor, IIDs.IID_IGraphicsCaptureItem, out var itemPtr);
            result.ThrowExceptionIfNotSucceed();

            return Capture(P<IGraphicsCaptureItem>.FromPtr(itemPtr));
        }

        /// <summary>
        /// Capture a texture of window
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public Task<P<ID3D11Texture2D>> CaptureWindow(HWND hWnd)
        {
            var result = _captureItemInterop.Value.CreateForWindow(hWnd, IIDs.IID_IGraphicsCaptureItem, out var itemPtr);
            result.ThrowExceptionIfNotSucceed();

            return Capture(P<IGraphicsCaptureItem>.FromPtr(itemPtr));
        }

        private async Task<P<ID3D11Texture2D>> Capture(P<IGraphicsCaptureItem> item)
        {
            var framePool = P<IDirect3D11CaptureFramePool>.FromPtr(NULL);
            var session = P<IGraphicsCaptureSession>.FromPtr(NULL);
            var frame = P<IDirect3D11CaptureFrame>.FromPtr(NULL);

            try
            {
                var result = item.Value.get_Size(out var size);
                result.ThrowExceptionIfNotSucceed();

                result = _framePoolStatics.Value.Create(_d3dDevice.Value, DirectXPixelFormat.DirectXPixelFormat_B8G8R8A8UIntNormalized, 1, size, out framePool);
                result.ThrowExceptionIfNotSucceed();

                result = framePool.Value.CreateCaptureSession(item.Value, out session);
                result.ThrowExceptionIfNotSucceed();

                // Ignore fail for IsBorderRequired
                var session3 = session.AsIUnknown().ToInterfaceOrNull<IGraphicsCaptureSession3>(IIDs.IID_IGraphicsCaptureSession3);
                if (session3 != null)
                {
                    session3.Value.Value.put_IsBorderRequired(false);
                    session3.Value.AsIUnknown().Value.Release();
                }

                result = session.Value.StartCapture();
                result.ThrowExceptionIfNotSucceed();

                int count = 0;
                framePool.Value.TryGetNextFrame(out frame);
                while (frame == NULL)
                {
                    if (count > GetFrameMaxRetryCount)
                    {
                        throw new Exception("Failed to get frame. Max retry count exceeds.");
                    }
                    await Task.Delay(GetFrameRetryInterval);
                    count++;
                    result = framePool.Value.TryGetNextFrame(out frame);
                }

                result = frame.Value.get_Surface(out var surface);
                result.ThrowExceptionIfNotSucceed();

                result = surface.AsIUnknown().ToInterface<IDirect3DDxgiInterfaceAccess>(IIDs.IID_IDirect3DDxgiInterfaceAccess, release: true, releaseOnFailed: true).Value.GetInterface(IIDs.IID_ID3D11Texture2D, out var texturePtr);
                result.ThrowExceptionIfNotSucceed();

                return P<ID3D11Texture2D>.FromPtr(texturePtr);
            }
            finally
            {
                if (item != NULL)
                {
                    item.AsIUnknown().Value.Release();
                }
                if (framePool != NULL)
                {
                    framePool.AsIUnknown().Value.Release();
                }
                if (session != NULL)
                {
                    session.AsIUnknown().Value.Release();
                }
                if (frame != NULL)
                {
                    frame.AsIUnknown().Value.Release();
                }
            }
        }

        /// <summary>
        /// Map a captured texture
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public D3D11_MAPPED_SUBRESOURCE MapCaptureTexture(P<ID3D11Texture2D> texture, out D3D11_TEXTURE2D_DESC desc)
        {
            texture.Value.GetDesc(out desc);
            desc.Usage = D3D11_USAGE.D3D11_USAGE_STAGING;
            desc.CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_READ;
            desc.BindFlags = 0;
            desc.MiscFlags = 0;

            var result = _d3d11Device.Value.CreateTexture2D(desc, null, out var cpuTexture);
            result.ThrowExceptionIfNotSucceed();

            try
            {
                _d3d11DeviceContext.Value.CopyResource(cpuTexture.As<ID3D11Resource>(), texture.As<ID3D11Resource>());
                result = _d3d11DeviceContext.Value.Map(cpuTexture.As<ID3D11Resource>(), 0, D3D11_MAP.D3D11_MAP_READ, 0, out var mappedResource);
                result.ThrowExceptionIfNotSucceed();

                return mappedResource;
            }
            finally
            {
                if (cpuTexture != NULL)
                {
                    cpuTexture.AsIUnknown().Value.Release();
                }
            }
        }
    }
}
