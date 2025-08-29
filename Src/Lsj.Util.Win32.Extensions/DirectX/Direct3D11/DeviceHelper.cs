using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Extensions.COM;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.Enums.D3D_DRIVER_TYPE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Extensions.DirectX.Direct3D11
{
    /// <summary>
    /// Device helper
    /// </summary>
    public static class DeviceHelper
    {
        /// <summary>
        /// Create D3D11 device
        /// </summary>
        /// <param name="device"></param>
        /// <param name="deviceContext"></param>
        /// <param name="createDeviceFlag"></param>
        public static void CreateDevice(out P<ID3D11Device> device, out P<ID3D11DeviceContext> deviceContext,
            D3D11_CREATE_DEVICE_FLAG createDeviceFlag = 0)
        {
            var result = D3D11CreateDevice(NullRef<IDXGIAdapter>(), D3D_DRIVER_TYPE_HARDWARE, NULL, createDeviceFlag,
                null, 0, D3D11_SDK_VERSION, out device, out var featureLevel, out deviceContext);
            result.ThrowExceptionIfNotSucceed();
        }
    }
}
