using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions.COM;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.D3d9;
using static Lsj.Util.Win32.DirectX.Enums.D3DBACKBUFFER_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DDEVTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENT;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI.DirectX
{
    /// <summary>
    /// Direct3D9Ex window
    /// </summary>
    public class D3D9ExWindow : Win32Window
    {
        /// <summary>
        /// The device
        /// </summary>
        public P<IDirect3DDevice9Ex> DeviceEx { get; private set; }

        /// <summary>
        /// The device as <see cref="IDirect3DDevice9"/>
        /// </summary>
        public P<IDirect3DDevice9> Device => DeviceEx.AsP<IDirect3DDevice9>();

        /// <summary>
        /// The swapchain
        /// </summary>
        public P<IDirect3DSwapChain9Ex> SwapChainEx { get; private set; }

        /// <summary>
        /// The device as <see cref="IDirect3DSwapChain9"/>
        /// </summary>
        public P<IDirect3DSwapChain9> SwapChain => SwapChainEx.AsP<IDirect3DSwapChain9>();

        /// <summary>
        /// Is Initiated
        /// </summary>
        public bool IsInitiated { get; private set; }

        /// <summary>
        /// Init D3D9Ex
        /// </summary>
        /// <returns></returns>
        public bool InitD3D9Ex()
        {
            if (!Direct3DCreate9Ex(D3D_SDK_VERSION, out var iDirect3D9Ex))
            {
                return false;
            }

            var presentParameters = new D3DPRESENT_PARAMETERS
            {
                Windowed = true,
                SwapEffect = D3DSWAPEFFECT_FLIPEX,
                BackBufferFormat = D3DFMT_A8R8G8B8,
                BackBufferWidth = 0,
                BackBufferHeight = 0,
                BackBufferCount = 2,
                PresentationInterval = D3DPRESENT_INTERVAL_IMMEDIATE,
            };

            var result = iDirect3D9Ex.Value.CreateDeviceEx(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, Handle, D3DCREATE_HARDWARE_VERTEXPROCESSING | D3DCREATE_MULTITHREADED,
                ref presentParameters, ref NullRef<D3DDISPLAYMODEEX>(), out var device);
            iDirect3D9Ex.AsIUnknown().Value.Release();
            if (!result)
            {
                return false;
            }

            if (DeviceEx != NULL)
            {
                DeviceEx.AsIUnknown().Value.Release();
            }
            DeviceEx = device;

            if (!device.As<IDirect3DDevice9>().GetSwapChain(0, out var swapChain))
            {
                return false;
            }

            var swapChainEx = swapChain.AsIUnknown().ToInterface<IDirect3DSwapChain9Ex>(IIDs.IID_IDirect3DSwapChain9Ex, true, true);
            if (SwapChainEx != NULL)
            {
                SwapChainEx.AsIUnknown().Value.Release();
            }
            SwapChainEx = swapChainEx;

            if (!swapChainEx.AsP<IDirect3DSwapChain9>().Value.GetBackBuffer(0, D3DBACKBUFFER_TYPE_MONO, out var backBuffer))
            {
                return false;
            }

            result = DeviceEx.AsP<IDirect3DDevice9>().Value.SetRenderTarget(0, backBuffer);

            backBuffer.AsIUnknown().Value.Release();

            if (!result)
            {
                return false;
            }

            if (!OnAfterInitD3D9Ex(Handle))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Called after D3D9Ex has been fully initialized. Override to create app-specific resources.
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnAfterInitD3D9Ex(HWND hWnd)
        {
            return true;
        }

        /// <inheritdoc/>
        protected override LRESULT OnDestroy(HWND hWnd, WPARAM wParam, LPARAM lParam)
        {
            if (DeviceEx != NULL)
            {
                DeviceEx.AsIUnknown().Value.Release();
            }
            if (SwapChainEx != NULL)
            {
                SwapChainEx.AsIUnknown().Value.Release();
            }
            return base.OnDestroy(hWnd, wParam, lParam);
        }

        /// <inheritdoc/>
        protected override LRESULT OnSize(HWND hWnd, WPARAM wParam, LPARAM lParam, WindowSizingTypes sizingType, int width, int height)
        {
            if (sizingType == WindowSizingTypes.SIZE_MINIMIZED)
            {
                return 0;
            }
            if (DeviceEx != NULL)
            {
                var presentParameters = new D3DPRESENT_PARAMETERS
                {
                    Windowed = true,
                    SwapEffect = D3DSWAPEFFECT_FLIPEX,
                    BackBufferFormat = D3DFMT_A8R8G8B8,
                    BackBufferWidth = 0,
                    BackBufferHeight = 0,
                    BackBufferCount = 2,
                    PresentationInterval = D3DPRESENT_INTERVAL_IMMEDIATE,
                };
                DeviceEx.Value.ResetEx(ref presentParameters, ref NullRef<D3DDISPLAYMODEEX>());
            }
            return 0;
        }
    }
}
