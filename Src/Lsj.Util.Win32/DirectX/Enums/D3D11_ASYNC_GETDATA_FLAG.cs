using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Optional flags that control the behavior of <see cref="ID3D11DeviceContext.GetData"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_async_getdata_flag"/>
    /// </para>
    /// </summary>
    public enum D3D11_ASYNC_GETDATA_FLAG
    {
        /// <summary>
        /// Do not flush the command buffer.
        /// This can potentially cause an infinite loop if <see cref="ID3D11DeviceContext.GetData"/> is continually called
        /// until it returns <see cref="S_OK"/> as there may still be commands in the command buffer
        /// that need to be processed in order for <see cref="ID3D11DeviceContext.GetData"/> to return <see cref="S_OK"/>.
        /// Since the commands in the command buffer are not flushed they will not be processed
        /// and therefore <see cref="ID3D11DeviceContext.GetData"/> will never return <see cref="S_OK"/>.
        /// </summary>
        D3D11_ASYNC_GETDATA_DONOTFLUSH = 0x1,
    }
}
