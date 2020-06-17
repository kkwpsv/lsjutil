using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IEnumSTATSTG"/> interface enumerates an array of <see cref="STATSTG"/> structures.
    /// These structures contain statistical data about open storage, stream, or byte array objects.
    /// <see cref="IEnumSTATSTG"/> has the same methods as all enumerator interfaces
    /// : <see cref="Next"/>, <see cref="Skip"/>, <see cref="Reset"/>, and <see cref="Clone"/>.
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IEnumSTATSTG)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumSTATSTG
    {
        /// <summary>
        /// The <see cref="Next"/> method retrieves a specified number of <see cref="STATSTG"/> structures, that follow in the enumeration sequence.
        /// If there are fewer than the requested number of <see cref="STATSTG"/> structures that remain in the enumeration sequence,
        /// it retrieves the remaining <see cref="STATSTG"/> structures.
        /// </summary>
        /// <param name="celt">
        /// The number of <see cref="STATSTG"/> structures requested.
        /// </param>
        /// <param name="rgelt">
        /// An array of <see cref="STATSTG"/> structures returned.
        /// </param>
        /// <param name="pceltFetched">
        /// The number of <see cref="STATSTG"/> structures retrieved in the <paramref name="rgelt"/> parameter.
        /// </param>
        /// <returns>
        /// This method supports the following return values:
        /// <see cref="S_OK"/>:
        /// The number of <see cref="STATSTG"/> structures returned is equal to the number specified in the <paramref name="celt"/> parameter. 
        /// <see cref="S_FALSE"/>:
        /// The number of <see cref="STATSTG"/> structures returned is less than the number specified in the <paramref name="celt"/> parameter. 
        /// </returns>
        [PreserveSig]
        HRESULT Next([In] ULONG celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)][Out] STATSTG[] rgelt, [Out] out ULONG pceltFetched);

        /// <summary>
        /// The <see cref="Skip"/> method skips a specified number of <see cref="STATSTG"/> structures in the enumeration sequence.
        /// </summary>
        /// <param name="celt">
        /// The number of <see cref="STATSTG"/> structures to skip.
        /// </param>
        /// <returns>
        /// This method supports the following return values:
        /// </returns>
        [PreserveSig]
        HRESULT Skip([In] ULONG celt);

        /// <summary>
        /// The <see cref="Reset"/> method resets the enumeration sequence to the beginning of the <see cref="STATSTG"/> structure array.
        /// </summary>
        /// <returns>
        /// This method supports the <see cref="S_OK"/> return value.
        /// <see cref="S_OK"/>: The enumeration sequence was successfully reset to the beginning of the enumeration.
        /// </returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// The <see cref="Clone"/> method creates a new enumerator that
        /// contains the same enumeration state as the current <see cref="STATSTG"/> structure enumerator.
        /// Using this method, a client can record a particular point in the enumeration sequence and then return to that point at a later time.
        /// The new enumerator supports the same <see cref="IEnumSTATSTG"/> interface.
        /// </summary>
        /// <param name="ppenum">
        /// A pointer to the variable that receives the <see cref="IEnumSTATSTG"/> interface pointer.
        /// If the method is unsuccessful, the value of the <paramref name="ppenum"/> parameter is undefined.
        /// </param>
        /// <returns>
        /// This method supports the following return values.
        /// <see cref="E_INVALIDARG"/>: The <paramref name="ppenum"/> parameter is NULL.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory.
        /// <see cref="E_UNEXPECTED"/>: An unexpected exception occurred.
        /// </returns>
        [PreserveSig]
        HRESULT Clone([Out] out IEnumSTATSTG ppenum);
    }
}
