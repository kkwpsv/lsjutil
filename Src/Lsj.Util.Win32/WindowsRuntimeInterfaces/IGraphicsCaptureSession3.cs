using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IGraphicsCaptureSession3
    /// </para>
    /// <para>
    /// Interface of GraphicsCaptureSession, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.graphicscapturesession"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, 20348)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 7, IID = "f2cdd966-22ae-5ea1-9596-3a289344c3be",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IGraphicsCaptureSession3
    {
#pragma warning disable IDE1006
        nint* _vTable;

        /// <summary>
        /// get_IsBorderRequired
        /// </summary>
        /// <returns></returns>
        public HRESULT get_IsBorderRequired(out BOOLEAN value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOLEAN, HRESULT>)_vTable[6])(thisPtr, out value);
            }
        }

        /// <summary>
        /// put_IsBorderRequired
        /// </summary>
        /// <returns></returns>
        public HRESULT put_IsBorderRequired(BOOLEAN value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOLEAN, HRESULT>)_vTable[7])(thisPtr, value);
            }
        }
    }
#pragma warning restore IDE1006 // 命名样式
}
