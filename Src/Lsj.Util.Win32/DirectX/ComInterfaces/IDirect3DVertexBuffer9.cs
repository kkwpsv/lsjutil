using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DLOCK;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DVertexBuffer9"/> interface to manipulate vertex buffer resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dvertexbuffer9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDirect3DVertexBuffer9"/> interface is obtained by calling the <see cref="IDirect3DDevice9.CreateVertexBuffer"/> method.
    /// This interface inherits additional functionality from the <see cref="IDirect3DResource9"/> interface.
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// The LPDIRECT3DVERTEXBUFFER9 and PDIRECT3DVERTEXBUFFER9 types are defined as pointers to the <see cref="IDirect3DVertexBuffer9"/> interface.
    /// <code>
    /// typedef struct IDirect3DVertexBuffer9 *LPDIRECT3DVERTEXBUFFER9, *PDIRECT3DVERTEXBUFFER9;
    /// </code>
    /// </remarks>
    public unsafe struct IDirect3DVertexBuffer9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Locks a range of vertex data and obtains a pointer to the vertex buffer memory.
        /// </summary>
        /// <param name="OffsetToLock">
        /// Offset into the vertex data to lock, in bytes.
        /// To lock the entire vertex buffer, specify 0 for both parameters, <paramref name="SizeToLock"/> and <paramref name="OffsetToLock"/>.
        /// </param>
        /// <param name="SizeToLock">
        /// Size of the vertex data to lock, in bytes.
        /// To lock the entire vertex buffer, specify 0 for both parameters, <paramref name="SizeToLock"/> and <paramref name="OffsetToLock"/>.
        /// </param>
        /// <param name="ppbData">
        /// VOID* pointer to a memory buffer containing the returned vertex data.
        /// </param>
        /// <param name="Flags">
        /// Combination of zero or more locking flags that describe the type of lock to perform.
        /// For this method, the valid flags are:
        /// <see cref="D3DLOCK_DISCARD"/>, <see cref="D3DLOCK_NO_DIRTY_UPDATE"/>, <see cref="D3DLOCK_NOSYSLOCK"/>,
        /// <see cref="D3DLOCK_READONLY"/>, <see cref="D3DLOCK_NOOVERWRITE"/>
        /// For a description of the flags, see D3DLOCK.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// As a general rule, do not hold a lock across more than one frame.
        /// When working with vertex buffers, you are allowed to make multiple lock calls;
        /// however, you must ensure that the number of lock calls match the number of unlock calls.
        /// DrawPrimitive calls will not succeed with any outstanding lock count on any currently set vertex buffer.
        /// The <see cref="D3DLOCK_DISCARD"/> and <see cref="D3DLOCK_NOOVERWRITE"/> flags are valid only on buffers created with <see cref="D3DUSAGE_DYNAMIC"/>.
        /// For information about using <see cref="D3DLOCK_DISCARD"/> or <see cref="D3DLOCK_NOOVERWRITE"/> with <see cref="Lock"/>, see Using Dynamic Vertex and Index Buffers.
        /// </remarks>
        public HRESULT Lock([In] UINT OffsetToLock, [In] UINT SizeToLock, [Out] out IntPtr ppbData, [In] D3DLOCK Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, out IntPtr, D3DLOCK, HRESULT>)_vTable[11])(thisPtr, OffsetToLock, SizeToLock, out ppbData, Flags);

            }
        }

        /// <summary>
        /// Unlocks vertex data.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT Unlock()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[12])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves a description of the vertex buffer resource.
        /// </summary>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DVERTEXBUFFER_DESC"/> structure, describing the returned vertex buffer.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        public HRESULT GetDesc([Out] out D3DVERTEXBUFFER_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DVERTEXBUFFER_DESC, HRESULT>)_vTable[13])(thisPtr, out pDesc);
            }
        }
    }
}
