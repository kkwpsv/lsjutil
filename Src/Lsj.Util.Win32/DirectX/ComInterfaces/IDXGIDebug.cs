using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Dxgidebug;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface controls debug settings, and can only be used if the debug layer is turned on.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nn-dxgidebug-idxgidebug"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is obtained by calling the <see cref="DXGIGetDebugInterface"/> function.
    /// </para>
    /// <para>
    /// For more info about the debug layer, see Debug Layer.
    /// </para>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "119E7452-DE9E-40fe-8806-88F90C12B441", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDXGIDebug
    {
        IntPtr* _vTable;

        /// <summary>
        /// <para>
        /// Reports info about the lifetime of an object or objects.
        /// </para>
        /// <para>
        /// See the Memory management sample.
        /// </para>
        /// </summary>
        /// <param name="apiid">
        /// The globally unique identifier (GUID) of the object or objects to get info about.
        /// Use one of the <see cref="DXGI_DEBUG_ID"/> GUIDs.
        /// </param>
        /// <param name="flags">
        /// A <see cref="DXGI_DEBUG_RLO_FLAGS"/>-typed value that specifies the amount of info to report.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT ReportLiveObjects([In] GUID apiid, [In] DXGI_DEBUG_RLO_FLAGS flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, GUID, DXGI_DEBUG_RLO_FLAGS, HRESULT>)_vTable[3])(thisPtr, apiid, flags);
            }
        }
    }
}
