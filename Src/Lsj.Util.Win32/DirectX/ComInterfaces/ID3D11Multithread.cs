using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides threading protection for critical sections of a multi-threaded application.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11multithread"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is obtained by querying it from an immediate device context
    /// created with the <see cref="ID3D11DeviceContext"/> (or later versions of this) interface using <see cref="IUnknown.QueryInterface"/>.
    /// </para>
    /// <para>
    /// Unlike D3D10, there is no multithreaded layer in D3D11.
    /// By default, multithread protection is turned off.
    /// Use <see cref="SetMultithreadProtected"/> to turn it on,
    /// then <see cref="Enter"/> and <see cref="Leave"/> to encapsulate graphics commands that must be executed in a specific order.
    /// </para>
    /// <para>
    /// By default in D3D11, applications can only use one thread with the immediate context at a time.
    /// But, applications can use this interface to change that restriction.
    /// The interface can turn on threading protection for the immediate context,
    /// which will increase the overhead of each immediate context call in order to share one context with multiple threads.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "9B7E4E00-342C-4106-A19F-4F2704F689F0", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID3D11Multithread
    {
        nint* _vTable;

        /// <summary>
        /// Enter a device's critical section.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <see cref="SetMultithreadProtected"/> is set to true, then entering a device's critical section
        /// prevents other threads from simultaneously calling that device's methods, calling DXGI methods,
        /// and calling the methods of all resource, view, shader, state, and asynchronous interfaces.
        /// </para>
        /// <para>
        /// This function should be used in multithreaded applications when there is a series of graphics commands that must happen in order.
        /// This function is typically called at the beginning of the series of graphics commands,
        /// and <see cref="Leave"/> is typically called after those graphics commands.
        /// </para>
        /// </remarks>
        public void Enter()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// Leave a device's critical section.
        /// </summary>
        /// <remarks>
        /// This function is typically used in multithreaded applications when there is a series of graphics commands that must happen in order.
        /// <see cref="Enter"/> is typically called at the beginning of a series of graphics commands,
        /// and this function is typically called after those graphics commands.
        /// </remarks>
        public void Leave()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Turns multithread protection on or off.
        /// </summary>
        /// <param name="bMTProtect">
        /// Set to true to turn multithread protection on, false to turn it off.
        /// </param>
        /// <returns>
        /// True if multithread protection was already turned on prior to calling this method, false otherwise.
        /// </returns>
        public BOOL SetMultithreadProtected([In] BOOL bMTProtect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, BOOL>)_vTable[5])(thisPtr, bMTProtect);
            }
        }

        /// <summary>
        /// Find out if multithread protection is turned on or not.
        /// </summary>
        /// <returns>
        /// Returns true if multithread protection is turned on, false otherwise.
        /// </returns>
        public BOOL SetMultithreadProtected()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[6])(thisPtr);
            }
        }
    }
}
