using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IGraphicsCaptureSession2
    /// </para>
    /// <para>
    /// Interface of GraphicsCaptureSession, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.graphicscapturesession"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_2004)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 7, IID = "2c39ae40-7d2e-5044-804e-8b6799d4cf9e",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IGraphicsCaptureSession2
    {
#pragma warning disable IDE1006
        IntPtr* _vTable;

        /// <summary>
        /// get_IsCursorCaptureEnabled
        /// </summary>
        /// <returns></returns>
        public HRESULT get_IsCursorCaptureEnabled(out BOOLEAN value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOLEAN, HRESULT>)_vTable[6])(thisPtr, out value);
            }
        }

        /// <summary>
        /// put_IsCursorCaptureEnabled
        /// </summary>
        /// <returns></returns>
        public HRESULT put_IsCursorCaptureEnabled(BOOLEAN value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOLEAN, HRESULT>)_vTable[7])(thisPtr, value);
            }
        }
    }
#pragma warning restore IDE1006 // 命名样式
}
