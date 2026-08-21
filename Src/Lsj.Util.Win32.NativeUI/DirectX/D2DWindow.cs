using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Extensions.COM;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.D2d1;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_FACTORY_TYPE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI.DirectX
{
    /// <summary>
    /// Direct2D window
    /// </summary>
    public class D2DWindow : Win32Window
    {
        public P<ID2D1Factory> Factory { get; private set; }

        public P<ID2D1RenderTarget> RenderTarget => HwndRenderTarget.AsP<ID2D1RenderTarget>();

        public P<ID2D1HwndRenderTarget> HwndRenderTarget { get; private set; }

        /// <summary>
        /// Is Initiated
        /// </summary>
        public bool IsInitiated { get; private set; }

        public bool InitD2D()
        {
            if (IsInitiated)
            {
                return false;
            }

            if (Factory != NULL)
            {
                Factory.AsIUnknown().Value.Release();
            }

            Factory = CreateD2D1Factory();

            if (!CreateRenderTarget())
            {
                return false;
            }

            if (!OnAfterInitD2D(Handle))
            {
                return false;
            }

            IsInitiated = true;
            return true;
        }

        /// <summary>
        /// On after init D2D
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnAfterInitD2D(HWND hWnd)
        {
            return true;
        }

        private bool CreateRenderTarget()
        {
            GetClientRect(Handle, out var rect);
            var properties = new D2D1_RENDER_TARGET_PROPERTIES();
            var hwndProperties = new D2D1_HWND_RENDER_TARGET_PROPERTIES
            {
                hwnd = Handle,
                pixelSize = new D2D1_SIZE_U
                {
                    height = (uint)(rect.right - rect.left),
                    width = (uint)(rect.bottom - rect.top),
                },
            };
            var hr = Factory.Value.CreateHwndRenderTarget(properties, hwndProperties, out var renderTarget);
            if (!hr)
            {
                return false;
            }

            HwndRenderTarget = renderTarget;
            return true;
        }

        /// <summary>
        /// Create D2D1 Factory
        /// </summary>
        /// <returns></returns>
        protected virtual P<ID2D1Factory> CreateD2D1Factory()
        {
            var hr = D2D1CreateFactory(D2D1_FACTORY_TYPE_MULTI_THREADED, IID_ID2D1Factory, NullRef<D2D1_FACTORY_OPTIONS>(), out var factory);
            hr.ThrowExceptionIfNotSucceed();
            return factory;
        }
    }
}
