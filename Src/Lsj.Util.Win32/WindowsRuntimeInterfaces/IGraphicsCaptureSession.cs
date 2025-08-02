using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IGraphicsCaptureSession
    /// </para>
    /// <para>
    /// Interface of GraphicsCaptureSession, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.graphicscapturesession"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, 17763)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 6, IID = "814e42a9-f70f-4ad7-939b-fddcc6eb880d",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IGraphicsCaptureSession
    {
        IntPtr* _vTable;

        /// <summary>
        /// StartCapture
        /// </summary>
        /// <returns></returns>
        public HRESULT StartCapture()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[6])(thisPtr);
            }
        }
    }
}
