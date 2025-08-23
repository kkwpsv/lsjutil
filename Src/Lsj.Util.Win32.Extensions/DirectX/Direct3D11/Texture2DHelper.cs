using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Extensions.COM;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Extensions.Direct3D11.D3D11
{
    /// <summary>
    /// Texture2D Helper
    /// </summary>
    public static class Texture2DHelper
    {
        /// <summary>
        /// Map a texture
        /// </summary>
        /// <param name="device"></param>
        /// <param name="deviceContext"></param>
        /// <param name="texture"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static D3D11_MAPPED_SUBRESOURCE MapTexture(P<ID3D11Device> device, P<ID3D11DeviceContext> deviceContext,
            P<ID3D11Texture2D> texture, out D3D11_TEXTURE2D_DESC desc)
        {
            texture.Value.GetDesc(out desc);
            desc.Usage = D3D11_USAGE.D3D11_USAGE_STAGING;
            desc.CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_READ;
            desc.BindFlags = 0;
            desc.MiscFlags = 0;

            var result = device.Value.CreateTexture2D(desc, null, out var cpuTexture);
            result.ThrowExceptionIfNotSucceed();

            try
            {
                deviceContext.Value.CopyResource(cpuTexture.As<ID3D11Resource>(), texture.As<ID3D11Resource>());
                result = deviceContext.Value.Map(cpuTexture.As<ID3D11Resource>(), 0, D3D11_MAP.D3D11_MAP_READ, 0, out var mappedResource);
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
