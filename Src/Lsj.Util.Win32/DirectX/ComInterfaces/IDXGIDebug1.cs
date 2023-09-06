using Lsj.Util.Win32.BaseTypes;
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
    /// Call the <see cref="DXGIGetDebugInterface1"/> function to obtain the <see cref="IDXGIDebug1"/> interface.
    /// The <see cref="IDXGIDebug1"/> interface can be used only if the debug layer is turned on.
    /// For more info, see Debug Layer.
    /// </remarks>
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
        /// <see cref="TRUE"/> if leak tracking is turned on for the current thread; otherwise, <see cref="FALSE"/>.
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
