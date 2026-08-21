using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IDirect3D11CaptureFrame
    /// </para>
    /// <para>
    /// Interface of Direct3D11CaptureFrame, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.direct3d11captureframe"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1809)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 8, IID = "fa50c623-38da-4b32-acf3-fa9734ad800e",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IDirect3D11CaptureFrame
    {
#pragma warning disable IDE1006
        nint* _vTable;

        /// <summary>
        /// get_Surface
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public HRESULT get_Surface(out P<IDirect3DSurface> value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DSurface>, HRESULT>)_vTable[6])(thisPtr, out value);
            }
        }
#pragma warning restore IDE1006
    }
}
