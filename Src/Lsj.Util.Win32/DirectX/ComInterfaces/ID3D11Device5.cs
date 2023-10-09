using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// <see cref="ID3D11Device5"/> adds new methods to those in <see cref="ID3D11Device4"/>.
    /// Note
    /// This interface, introduced in the Windows 10 Creators Update, is the latest version of the <see cref="ID3D11Device"/> interface.
    /// Applications targetting Windows 10 Creators Update should use this interface instead of earlier versions.
    /// </para>
    /// </summary>
    public unsafe struct ID3D11Device5
    {
        IntPtr* _vTable;

        /// <summary>
        /// Opens a handle for a shared fence by using <see cref="HANDLE"/> and <see cref="REFIID"/>.
        /// This member function is a limited version of the Direct3D 12 <see cref="ID3D12Device.OpenSharedHandle"/> member function,
        /// and applies between Direct3D 11 and Direct3D 12 in interop scenarios.
        /// Unlike <see cref="ID3D12Device.OpenSharedHandle"/> which operates on resources, heaps, and fences,
        /// the <see cref="OpenSharedFence"/> function only operates on fences;
        /// in Direct3D 11, shared resources are opened with the <see cref="ID3D11Device1.OpenSharedResource1"/> member function.
        /// </summary>
        /// <param name="hFence">
        /// The handle that was returned by a call to <see cref="ID3D11Fence.CreateSharedHandle"/> or <see cref="ID3D12Device.CreateSharedHandle"/>.
        /// </param>
        /// <param name="ReturnedInterface">
        /// The globally unique identifier (GUID) for the ID3D11Fence interface.
        /// The REFIID, or GUID, of the interface can be obtained by using the __uuidof() macro.
        /// For example, __uuidof(ID3D11Fence) will get the GUID of the interface to the fence.
        /// </param>
        /// <param name="ppFence">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D11Fence"/> interface.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        public HRESULT OpenSharedFence([In] HANDLE hFence, [In] in IID ReturnedInterface, [Out] out IntPtr ppFence)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, HRESULT>)_vTable[65])
                    (thisPtr, hFence, ReturnedInterface, out ppFence);
            }
        }

        /// <summary>
        /// Creates a fence object.
        /// This member function is equivalent to the Direct3D 12 <see cref="ID3D12Device.CreateFence"/> member function,
        /// and applies between Direct3D 11 and Direct3D 12 in interop scenarios.
        /// </summary>
        /// <param name="InitialValue">
        /// The initial value for the fence.
        /// </param>
        /// <param name="Flags">
        /// A combination of <see cref="D3D11_FENCE_FLAG"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for the fence.
        /// </param>
        /// <param name="ReturnedInterface">
        /// The globally unique identifier (GUID) for the fence interface (<see cref="ID3D11Fence"/>).
        /// The REFIID, or GUID, of the interface to the fence can be obtained by using the __uuidof() macro.
        /// For example, <code>__uuidof(ID3D11Fence)</code> will get the GUID of the interface to a fence.
        /// </param>
        /// <param name="ppFence">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D11Fence"/> interface that is used to access the fence.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the Direct3D 11 Return Codes.
        /// </returns>
        public HRESULT CreateFence([In] UINT64 InitialValue, [In] D3D11_FENCE_FLAG Flags, [In] in IID ReturnedInterface, [Out] out IntPtr ppFence)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64, D3D11_FENCE_FLAG, in IID, out IntPtr, HRESULT>)_vTable[66])
                    (thisPtr, InitialValue, Flags, ReturnedInterface, out ppFence);
            }
        }
    }
}
