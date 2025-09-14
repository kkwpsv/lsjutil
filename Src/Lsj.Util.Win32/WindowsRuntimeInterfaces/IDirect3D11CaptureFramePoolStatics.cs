using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IDirect3D11CaptureFramePoolStatics
    /// </para>
    /// <para>
    /// Interface of Direct3D11CaptureFramePool, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.direct3d11captureframepool"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1809)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 6, IID = "7784056a-67aa-4d53-ae54-1088d5a8ca21",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IDirect3D11CaptureFramePoolStatics
    {
        IntPtr* _vTable;

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="device"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="numberOfBuffers"></param>
        /// <param name="size"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public HRESULT Create(in IDirect3DDevice device, DirectXPixelFormat pixelFormat, int numberOfBuffers, SizeInt32 size, out P<IDirect3D11CaptureFramePool> result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DDevice, DirectXPixelFormat, int, SizeInt32, out P<IDirect3D11CaptureFramePool>, HRESULT>)_vTable[6])
                    (thisPtr, device, pixelFormat, numberOfBuffers, size, out result);
            }
        }
    }
}