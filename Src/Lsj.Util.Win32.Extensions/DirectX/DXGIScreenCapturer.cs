using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Extensions.COM;
using Lsj.Util.Win32.Extensions.Direct3D11.D3D11;
using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Extensions.Direct3D11
{
    /// <summary>
    /// DXGI screen capturer
    /// </summary>
    public class DXGIScreenCapturer : IDisposable
    {
        private P<ID3D11Device> _d3d11Device;
        private P<ID3D11DeviceContext> _d3d11DeviceContext;


        /// <summary>
        /// The timeout of <see cref="IDXGIOutputDuplication.AcquireNextFrame"/> 
        /// </summary>
        public TimeSpan AcquireFrameTimeout { get; set; } = TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// 
        /// </summary>
        public DXGIScreenCapturer()
        {
            var result = DirectX.D3D11.D3D11CreateDevice(NullRef<IDXGIAdapter>(), D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE, NULL, 0, null, 0, (uint)DirectX.D3D11.D3D11_SDK_VERSION, out _d3d11Device, out var featureLevel, out _d3d11DeviceContext);
            result.ThrowExceptionIfNotSucceed();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_d3d11Device != NULL)
            {
                _d3d11Device.AsIUnknown().Value.Release();
            }
            if (_d3d11DeviceContext != NULL)
            {
                _d3d11DeviceContext.AsIUnknown().Value.Release();
            }
        }

        /// <summary>
        /// Capture a texture of monitor
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns></returns>
        public P<ID3D11Texture2D> CaptureMonitor(HMONITOR monitor)
        {
            var dxgiDevice = _d3d11Device.AsIUnknown().ToInterface<IDXGIDevice>(IIDs.IID_IDXGIDevice);

            var result = dxgiDevice.Value.GetAdapter(out var adapter);
            result.ThrowExceptionIfNotSucceed();

            P<IDXGIOutput> output = NULL;

            int i = 0;
            while (true)
            {
                result = adapter.Value.EnumOutputs(i, out var tempOutput);
                if (!result)
                {
                    break;
                }
                if (tempOutput.Value.GetDesc(out var outputDesc))
                {
                    if (outputDesc.Monitor.ToIntPtr() == monitor.ToIntPtr())
                    {
                        output = tempOutput;
                        break;
                    }
                    else
                    {
                        tempOutput.AsIUnknown().Value.Release();
                    }
                }
            }

            if (output == NULL)
            {
                throw new ArgumentException("Invalid monitor");
            }

            var output1 = output.AsIUnknown().ToInterface<IDXGIOutput1>(IIDs.IID_IDXGIOutput1, true, true);
            result = output1.Value.DuplicateOutput(_d3d11Device.AsIUnknown().Value, out var outputDuplication);
            result.ThrowExceptionIfNotSucceed();

            P<IDXGIResource> desktopResource;
            try
            {
                while (true)
                {
                    result = outputDuplication.Value.AcquireNextFrame(AcquireFrameTimeout.Milliseconds, out var frameInfo, out desktopResource);

                    result.ThrowExceptionIfNotSucceed();

                    // If only the pointer was updated (that is, the desktop image was not updated),
                    // the AccumulatedFrames, TotalMetadataBufferSize, and LastPresentTime members are set to zero.
                    if (frameInfo.AccumulatedFrames > 0)
                    {
                        break;
                    }
                    else
                    {
                        outputDuplication.Value.ReleaseFrame();
                    }
                }
            }
            finally
            {
                outputDuplication.AsIUnknown().Value.Release();
            }

            var texture = desktopResource.AsIUnknown().ToInterface<ID3D11Texture2D>(IIDs.IID_ID3D11Texture2D, true, true);

            return texture;
        }

        /// <summary>
        /// Map a captured texture
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public D3D11_MAPPED_SUBRESOURCE MapCaptureTexture(P<ID3D11Texture2D> texture, out D3D11_TEXTURE2D_DESC desc)
            => Texture2DHelper.MapTexture(_d3d11Device, _d3d11DeviceContext, texture, out desc);
    }
}
