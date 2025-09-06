using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an adapter output (such as a monitor).
    /// The <see cref="IDXGIOutput3"/> interface exposes a method to check for overlay support.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgioutput3"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "8a6bb301-7e7e-41F4-a8e0-5b32f7f99b18", BeginVTableSlotIndex = 24, EndVTableSlotIndex = 24,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIOutput), typeof(IDXGIOutput1), typeof(IDXGIOutput2)])]
    public unsafe struct IDXGIOutput3
    {
        IntPtr* _vTable;

        /// <summary>
        /// Checks for overlay support.
        /// </summary>
        /// <param name="EnumFormat">
        /// A <see cref="DXGI_FORMAT"/>-typed value for the color format.
        /// </param>
        /// <param name="pConcernedDevice">
        /// A pointer to the Direct3D device interface.
        /// <see cref="CheckOverlaySupport"/> returns only support info about this scan-out device.
        /// </param>
        /// <param name="pFlags"></param>
        /// <returns>
        /// A pointer to a variable that receives a combination of <see cref="DXGI_OVERLAY_SUPPORT_FLAG"/>-typed values
        /// that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for overlay support.
        /// </returns>
        /// <remarks>
        /// Returns one of the error codes described in the <see cref="DXGI_ERROR"/> topic.
        /// </remarks>
        public HRESULT CheckOverlaySupport([In] DXGI_FORMAT EnumFormat, [In] P<IUnknown> pConcernedDevice, [Out] out DXGI_OVERLAY_SUPPORT_FLAG pFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, P<IUnknown>, out DXGI_OVERLAY_SUPPORT_FLAG, HRESULT>)_vTable[24])
                    (thisPtr, EnumFormat, pConcernedDevice, out pFlags);
            }
        }
    }
}
