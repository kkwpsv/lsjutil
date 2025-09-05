using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.DXGI;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Controls debug settings for Microsoft DirectX Graphics Infrastructure (DXGI).
    /// You can use the <see cref="IDXGIDebug1"/> interface in Windows Store apps.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nn-dxgidebug-idxgidebug1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Call the <see cref="DXGIGetDebugInterface1"/> function to obtain the <see cref="IDXGIDebug1"/> interface.
    /// </para>
    /// <para>
    /// The <see cref="IDXGIDebug1"/> interface can be used only if the debug layer is turned on.
    /// For more info, see Debug Layer.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "c5a05f0c-16f2-4adf-9f4d-a8c4d58ac550", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 6,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIDebug)])]
    public unsafe struct IDXGIDebug1
    {
        IntPtr* _vTable;

        /// <summary>
        /// Starts tracking leaks for the current thread.
        /// </summary>
        public void EnableLeakTrackingForThread()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Stops tracking leaks for the current thread.
        /// </summary>
        public void DisableLeakTrackingForThread()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// Gets a value indicating whether leak tracking is turned on for the current thread.
        /// </summary>
        /// <returns>
        /// <see cref="TRUE"/> if leak tracking is turned on for the current thread;
        /// otherwise, <see cref="FALSE"/>.
        /// </returns>
        public BOOL IsLeakTrackingEnabledForThread()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[6])(thisPtr);
            }
        }
    }
}
