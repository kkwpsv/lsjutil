using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IGraphicsCaptureItem
    /// </para>
    /// <para>
    /// Interface of GraphicsCaptureItem, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.graphicscaptureitem"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, 17763)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 9, IID = "79c3f95b-31f7-4ec2-a464-632ef5d30760",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IGraphicsCaptureItem
    {
#pragma warning disable IDE1006
        IntPtr* _vTable;

        /// <summary>
        /// get_Size
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public HRESULT get_Size(out SizeInt32 value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out SizeInt32, HRESULT>)_vTable[7])(thisPtr, out value);
            }
        }
#pragma warning restore IDE1006
    }
}
