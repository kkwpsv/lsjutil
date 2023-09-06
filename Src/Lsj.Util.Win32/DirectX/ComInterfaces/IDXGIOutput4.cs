using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an adapter output (such as a monitor).
    /// The <see cref="IDXGIOutput4"/> interface exposes a method to check for overlay color space support.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgioutput4"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIOutput4
    {
        IntPtr* _vTable;

        /// <summary>
        /// Checks for overlay color space support.
        /// </summary>
        /// <param name="Format">
        /// A <see cref="DXGI_FORMAT"/>-typed value for the color format.
        /// </param>
        /// <param name="ColorSpace">
        /// A <see cref="DXGI_COLOR_SPACE_TYPE"/>-typed value that specifies color space type to check overlay support for.
        /// </param>
        /// <param name="pConcernedDevice">
        /// A pointer to the Direct3D device interface.
        /// <see cref="CheckOverlayColorSpaceSupport"/> returns only support info about this scan-out device.
        /// </param>
        /// <param name="pFlags">
        /// A pointer to a variable that receives a combination of <see cref="DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG"/>-typed values
        /// that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for overlay color space support.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT CheckOverlayColorSpaceSupport([In] DXGI_FORMAT Format, [In] DXGI_COLOR_SPACE_TYPE ColorSpace,
            [In] in IUnknown pConcernedDevice, [Out] out DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG pFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, DXGI_COLOR_SPACE_TYPE, in IUnknown, out DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG, HRESULT>)_vTable[24])
                    (thisPtr, Format, ColorSpace, pConcernedDevice, out pFlags);
            }
        }
    }
}
