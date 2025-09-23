using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions.COM;
using Lsj.Util.Win32.Extensions.DirectX.Direct3D11;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_USAGE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI.DirectX
{
    /// <summary>
    /// Direct3D11 window
    /// </summary>
    public class D3D11Window : Win32Window
    {
        /// <summary>
        /// The D3D11 device
        /// </summary>
        public P<ID3D11Device> Device { get; private set; }

        /// <summary>
        /// The immediate context
        /// </summary>
        public P<ID3D11DeviceContext> DeviceContext { get; private set; }

        /// <summary>
        /// The render target view
        /// </summary>
        public P<ID3D11RenderTargetView> RenderTargetView { get; private set; }

        /// <summary>
        /// The swap chain
        /// </summary>
        public P<IDXGISwapChain> SwapChain { get; private set; }

        /// <inheritdoc/>
        protected override LRESULT OnCreate(HWND hWnd, WPARAM wParam, LPARAM lParam, ref CREATESTRUCT createStruct)
        {
            try
            {
                var device = CreateD3D11Device();
                if (device == NULL)
                {
                    return -1;
                }

                Device = device;

                Device.Value.GetImmediateContext(out var deviceContext);
                DeviceContext = deviceContext;

                var dxgiDevice = device.AsIUnknown().ToInterface<IDXGIDevice>(IIDs.IID_IDXGIDevice, false, true);
                var result = dxgiDevice.As<IDXGIObject>().GetParent(IIDs.IID_IDXGIAdapter, out var pAdapter);
                dxgiDevice.AsIUnknown().Value.Release();
                if (!result)
                {
                    return -1;
                }

                P<IDXGIAdapter> adapter = (P<IDXGIAdapter>)pAdapter;
                result = adapter.As<IDXGIObject>().GetParent(IIDs.IID_IDXGIFactory2, out var pFactory);
                adapter.AsIUnknown().Value.Release();
                if (!result)
                {
                    return -1;
                }

                P<IDXGIFactory2> factory = (P<IDXGIFactory2>)pFactory;
                var desc = new DXGI_SWAP_CHAIN_DESC1
                {
                    BufferCount = 1,
                    BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT,
                    Format = DXGI_FORMAT_R8G8B8A8_UNORM,
                    SampleDesc = new DXGI_SAMPLE_DESC
                    {
                        Count = 1,
                    }
                };
                result = factory.Value.CreateSwapChainForHwnd(device.AsIUnknown(), hWnd, desc, NullRef<DXGI_SWAP_CHAIN_FULLSCREEN_DESC>(), NULL, out var swapChain);
                factory.AsIUnknown().Value.Release();
                if (!result)
                {
                    return -1;
                }

                SwapChain = swapChain.AsIUnknown().ToInterface<IDXGISwapChain>(IIDs.IID_IDXGISwapChain1, true, true);

                if (!CreateRenderTarget())
                {
                    return -1;
                }

                if (!OnAfterInitD3D11(hWnd))
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }

            return base.OnCreate(hWnd, wParam, lParam, ref createStruct);
        }

        /// <summary>
        /// On after init D3D11
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnAfterInitD3D11(HWND hWnd)
        {
            return true;
        }

        /// <inheritdoc/>
        protected override LRESULT OnDestroy(HWND hWnd, WPARAM wParam, LPARAM lParam)
        {
            if (Device != NULL)
            {
                Device.AsIUnknown().Value.Release();
            }
            if (DeviceContext != NULL)
            {
                DeviceContext.AsIUnknown().Value.Release();
            }
            if (RenderTargetView != NULL)
            {
                RenderTargetView.AsIUnknown().Value.Release();
            }
            if (SwapChain != NULL)
            {
                SwapChain.AsIUnknown().Value.Release();
            }

            return base.OnDestroy(hWnd, wParam, lParam);
        }

        /// <inheritdoc/>
        protected override LRESULT OnResize(HWND hWnd, WPARAM wParam, LPARAM lParam, WindowSizingTypes sizingType, int width, int height)
        {
            if (sizingType == WindowSizingTypes.SIZE_MINIMIZED)
            {
                return 0;
            }
            if (SwapChain != NULL && DeviceContext != NULL)
            {
                DeviceContext.Value.OMSetRenderTargets(0, null, NULL);
                if (RenderTargetView != NULL)
                {
                    RenderTargetView.AsIUnknown().Value.Release();
                }
                RenderTargetView = NULL;
                SwapChain.Value.ResizeBuffers(0, width, height, DXGI_FORMAT_UNKNOWN, 0);
                CreateRenderTarget();
            }
            return 0;
        }

        private bool CreateRenderTarget()
        {
            var result = SwapChain.Value.GetBuffer(0, IIDs.IID_ID3D11Texture2D, out var pTexture);
            if (!result)
            {
                return false;
            }
            P<ID3D11Texture2D> texture = pTexture;

            texture.Value.GetDesc(out var textureDesc);

            result = Device.Value.CreateRenderTargetView(texture.AsP<ID3D11Resource>(), NullRef<D3D11_RENDER_TARGET_VIEW_DESC>(), out var renderTargetView);
            texture.AsIUnknown().Value.Release();
            if (!result)
            {
                return false;
            }

            RenderTargetView = renderTargetView;
            DeviceContext.Value.OMSetRenderTargets(1, [renderTargetView], NULL);

            var viewport = new D3D11_VIEWPORT
            {
                Width = (uint)textureDesc.Width,
                Height = (uint)textureDesc.Height,
                MinDepth = 0,
                MaxDepth = 0,
                TopLeftX = 0,
                TopLeftY = 0,
            };
            DeviceContext.Value.RSSetViewports(1, [viewport]);
            return true;
        }

        /// <summary>
        /// Create D3D11 Device
        /// </summary>
        /// <returns></returns>
        protected virtual P<ID3D11Device> CreateD3D11Device()
        {
            DeviceHelper.CreateDevice(out var device, out NullRef<P<ID3D11DeviceContext>>());
            return device;
        }
    }
}
