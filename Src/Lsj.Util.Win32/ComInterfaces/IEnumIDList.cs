using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a standard set of methods used to enumerate the pointers to item identifier lists (PIDLs) of the items in a Shell folder.
    /// When a folder's <see cref="IShellFolder.EnumObjects"/> method is called,
    /// it creates an enumeration object and passes a pointer to the object's <see cref="IEnumIDList"/> interface back to the calling application.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumidlist"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// All Shell folder objects must be able to respond to a call to their <see cref="IShellFolder.EnumObjects"/> method 
    /// by creating an enumeration object that exports <see cref="IEnumIDList"/>.
    /// The Shell, in particular, uses these objects to enumerate the items in a folder.
    /// Use this interface to enumerate the contents of a Shell folder object. Call the folder's <see cref="IShellFolder.EnumObjects"/> method
    /// and use the returned <see cref="IEnumIDList"/> pointer to enumerate the PIDLs of the items in the folder.
    /// </remarks>
    public unsafe struct IEnumIDList
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the number of items retrieved.
        /// </summary>
        /// <param name="celt">
        /// The number of elements in the array referenced by the <paramref name="rgelt"/> parameter.
        /// </param>
        /// <param name="rgelt">
        /// The address of a pointer to an array of <see cref="ITEMIDLIST"/> pointers that receive the item identifiers.
        /// The implementation must allocate these item identifiers using <see cref="CoTaskMemAlloc"/>.
        /// The calling application is responsible for freeing the item identifiers using <see cref="CoTaskMemFree"/>.
        /// The <see cref="ITEMIDLIST"/> structures returned in the array are relative to the <see cref="IShellFolder"/> being enumerated.
        /// </param>
        /// <param name="pceltFetched">
        /// A pointer to a value that receives a count of the item identifiers actually returned in <paramref name="rgelt"/>.
        /// The count can be smaller than the value specified in the <paramref name="celt"/> parameter.
        /// This parameter can be <see cref="NULL"/> on entry only if <paramref name="celt"/> = 1,
        /// because in that case the method can only retrieve one (<see cref="S_OK"/>) or zero (<see cref="S_FALSE"/>) items.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method successfully retrieved the requested <paramref name="celt"/> elements.
        /// This method only returns <see cref="S_OK"/> if the full count of requested items are successfully retrieved.
        /// <see cref="S_FALSE"/> indicates that more items were requested than remained in the enumeration.
        /// The value pointed to by the <paramref name="pceltFetched"/> parameter specifies the actual number of items retrieved.
        /// Note that the value will be 0 if there are no more items to retrieve.
        /// Returns a COM-defined error value otherwise.
        /// </returns>
        /// <remarks>
        /// If this method returns a Component Object Model (COM) error code (as determined by the <see cref="FAILED"/> macro),
        /// then no entries in the <paramref name="rgelt"/> array are valid on exit.
        /// If this method returns a success code (such as <see cref="S_OK"/> or <see cref="S_FALSE"/>),
        /// then the <see cref="ULONG"/> pointed to by the <paramref name="pceltFetched"/> parameter
        /// determines how many entries in the rgelt array are valid on exit.
        /// The distinction is important in the case where <paramref name="celt"/> > 1.
        /// For example, if you pass <paramref name="celt"/>=10 and there are only 3 elements left,
        /// *<paramref name="pceltFetched"/> will be 3 and the method will return <see cref="S_FALSE"/> meaning that you reached the end of the file.
        /// The three fetched elements will be stored into rgelt and are valid.
        /// </remarks>
        public HRESULT Next([In] ULONG celt, [In] in LPITEMIDLIST rgelt, [Out] out ULONG pceltFetched)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULONG, in LPITEMIDLIST, out ULONG, HRESULT>)_vTable[3])(thisPtr, celt, rgelt, out pceltFetched);
            }
        }

        /// <summary>
        /// Skips the specified number of elements in the enumeration sequence.
        /// </summary>
        /// <param name="celt">
        /// The number of item identifiers to skip.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or a COM-defined error value otherwise.
        /// </returns>
        public HRESULT Skip([In] ULONG celt)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULONG, HRESULT>)_vTable[4])(thisPtr, celt);
            }
        }

        /// <summary>
        /// Returns to the beginning of the enumeration sequence.
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or a COM-defined error value otherwise.
        /// </returns>
        public HRESULT Reset()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// Creates a new item enumeration object with the same contents and state as the current one.
        /// </summary>
        /// <param name="ppenum">
        /// The address of a pointer to the new enumeration object.
        /// The calling application must eventually free the new object by calling its Release member function.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or a COM-defined error value otherwise.
        /// </returns>
        /// <remarks>
        /// This method makes it possible to record a particular point in the enumeration sequence and then return to that point at a later time.
        /// </remarks>
        public HRESULT Clone([Out] out IntPtr ppenum)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[6])(thisPtr, out ppenum);
            }
        }
    }
}
