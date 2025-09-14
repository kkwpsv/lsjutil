using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IDirect3D11CaptureFramePool
    /// </para>
    /// <para>
    /// Interface of Direct3D11CaptureFramePool, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.direct3d11captureframepool"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1809)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 11, IID = "24eb6d22-1975-422e-82e7-780dbd8ddf24",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IDirect3D11CaptureFramePool
    {
#pragma warning disable IDE1006
        IntPtr* _vTable;

        /// <summary>
        /// TryGetNextFrame
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>

        public HRESULT TryGetNextFrame(out P<IDirect3D11CaptureFrame> result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3D11CaptureFrame>, HRESULT>)_vTable[7])(thisPtr, out result);
            }
        }

        /// <summary>
        /// CreateCaptureSession
        /// </summary>
        /// <param name="item"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public HRESULT CreateCaptureSession(in IGraphicsCaptureItem item, out P<IGraphicsCaptureSession> result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IGraphicsCaptureItem, out P<IGraphicsCaptureSession>, HRESULT>)_vTable[10])(thisPtr, item, out result);
            }
        }
#pragma warning restore IDE1006
    }
}
