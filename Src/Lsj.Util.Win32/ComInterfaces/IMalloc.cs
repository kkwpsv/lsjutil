using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Allocates, frees, and manages memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-imalloc"/>
    /// </para>
    /// </summary>
    public unsafe struct IMalloc
    {
        IntPtr* _vTable;

        /// <summary>
        /// Allocates a block of memory.
        /// </summary>
        /// <param name="cb">
        /// The size of the memory block to be allocated, in bytes.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is a pointer to the allocated block of memory. Otherwise, it is <see cref="IntPtr.Zero"/>.
        /// Applications should always check the return value from this method, even when requesting small amounts of memory,
        /// because there is no guarantee the memory will be allocated.
        /// </returns>
        /// <remarks>
        /// The initial contents of the returned memory block are undefined there is no guarantee that the block has been initialized,
        /// so you should initialize it in your code.
        /// The allocated block may be larger than cb bytes because of the space required for alignment and for maintenance information.
        /// If <paramref name="cb"/> is zero, <see cref="Alloc"/> allocates a zero-length item and returns a valid pointer to that item.
        /// If there is insufficient memory available, <see cref="Alloc"/> returns <see cref="IntPtr.Zero"/>.
        /// </remarks>
        public IntPtr Alloc([In] SIZE_T cb)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, SIZE_T, IntPtr>)_vTable[3])(thisPtr, cb);
            }
        }

        /// <summary>
        /// Changes the size of a previously allocated block of memory.
        /// </summary>
        /// <param name="pv">
        /// A pointer to the block of memory to be reallocated.
        /// This parameter can be <see cref="IntPtr.Zero"/>, as discussed in the Remarks section below.
        /// </param>
        /// <param name="cb">
        /// The size of the memory block to be reallocated, in bytes.
        /// This parameter can be <see cref="IntPtr.Zero"/>, as discussed in the Remarks section below.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is a pointer to the reallocated block of memory.
        /// Otherwise, it is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// This method reallocates a block of memory, but does not guarantee that its contents are initialized.
        /// Therefore, the caller is responsible for subsequently initializing the memory.
        /// The allocated block may be larger than cb bytes because of the space required for alignment and for maintenance information.
        /// The <paramref name="pv"/> argument points to the beginning of the block.
        /// If <paramref name="pv"/> is <see cref="IntPtr.Zero"/>, <see cref="Realloc"/> allocates a new memory block
        /// in the same way that <see cref="Alloc"/> does.
        /// If <paramref name="pv"/> is not <see cref="IntPtr.Zero"/>, it should be a pointer returned by a prior call to <see cref="Alloc"/>.
        /// The <paramref name="cb"/> argument specifies the size of the new block, in bytes.
        /// The contents of the block are unchanged up to the shorter of the new and old sizes, although the new block can be in a different location.
        /// Because the new block can be in a different memory location, the pointer returned by <see cref="Realloc"/> is not guaranteed
        /// to be the pointer passed through the pv argument.
        /// If <paramref name="pv"/> is not <see cref="IntPtr.Zero"/> and <paramref name="cb"/> is <see cref="IntPtr.Zero"/>,
        /// the memory pointed to by <paramref name="pv"/> is freed.
        /// <see cref="Realloc"/> returns a void pointer to the reallocated (and possibly moved) block of memory.
        /// The return value is <see cref="IntPtr.Zero"/> if the size is zero and the buffer argument is not <see cref="IntPtr.Zero"/>,
        /// or if there is not enough memory available to expand the block to the specified size.
        /// In the first case, the original block is freed; in the second, the original block is unchanged.
        /// The storage space pointed to by the return value is guaranteed to be suitably aligned for storage of any type of object.
        /// To get a pointer to a type other than void, use a type cast on the return value.
        /// </remarks>
        public IntPtr Realloc([In] IntPtr pv, [In] SIZE_T cb)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, IntPtr>)_vTable[4])(thisPtr, pv, cb);
            }
        }

        /// <summary>
        /// Frees a previously allocated block of memory.
        /// </summary>
        /// <param name="pv">
        /// A pointer to the memory block to be freed. If this parameter is <see cref="IntPtr.Zero"/>, this method has no effect.
        /// </param>
        /// <remarks>
        /// This method frees a block of memory previously allocated through a call to <see cref="Alloc"/> or <see cref="Realloc"/>.
        /// The number of bytes freed equals the number of bytes that were allocated.
        /// After the call, the block of memory pointed to by <paramref name="pv"/> is invalid and can no longer be used.
        /// </remarks>
        public void Free([In] IntPtr pv)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, IntPtr, void>)_vTable[5])(thisPtr, pv);
            }
        }

        /// <summary>
        /// Retrieves the size of a previously allocated block of memory.
        /// </summary>
        /// <param name="pv">
        /// A pointer to the block of memory.
        /// </param>
        /// <returns>
        /// The size of the allocated memory block in bytes or, if <paramref name="pv"/> is a <see cref="IntPtr.Zero"/> pointer, -1.
        /// </returns>
        /// <remarks>
        /// To get the size in bytes of a memory block, the block must have been previously allocated with <see cref="Alloc"/> or <see cref="Realloc"/>.
        /// The size returned is the actual size of the allocation, which may be greater than the size requested when the allocation was made.
        /// </remarks>
        public SIZE_T GetSize([In] IntPtr pv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T>)_vTable[6])(thisPtr, pv);
            }
        }

        /// <summary>
        /// Determines whether this allocator was used to allocate the specified block of memory.
        /// </summary>
        /// <param name="pv">
        /// A pointer to the block of memory. If this parameter is a <see cref="IntPtr.Zero"/> pointer, -1 is returned.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// 1   The block of memory was allocated by this allocator.
        /// 0   The block of memory was not allocated by this allocator.
        /// -1  This method cannot determine whether this allocator allocated the block of memory.
        /// </returns>
        public int DidAlloc([In] IntPtr pv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, int>)_vTable[7])(thisPtr, pv);
            }
        }

        /// <summary>
        /// Minimizes the heap as much as possible by releasing unused memory to the operating system,
        /// coalescing adjacent free blocks, and committing free pages.
        /// </summary>
        public void HeapMinimize()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[8])(thisPtr);
            }
        }
    }
}
