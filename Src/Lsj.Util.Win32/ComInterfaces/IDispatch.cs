using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes objects, methods and properties to programming tools and other applications that support Automation.
    /// COM components implement the <see cref="IDispatch"/> interface to enable access by Automation clients, such as Visual Basic.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oaidl/nn-oaidl-idispatch
    /// </para>
    /// </summary>
    public unsafe struct IDispatch
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the number of type information interfaces that an object provides (either 0 or 1).
        /// </summary>
        /// <param name="pctinfo">
        /// The number of type information interfaces provided by the object.
        /// If the object provides type information, this number is 1; otherwise the number is 0.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_NOTIMPL"/>: Failure.
        /// </returns>
        /// <remarks>
        /// The method may return zero, which indicates that the object does not provide any type information.
        /// In this case, the object may still be programmable through <see cref="IDispatch"/> or a VTBL,
        /// but does not provide run-time type information for browsers, compilers,
        /// or other programming tools that access type information.
        /// This can be useful for hiding an object from browsers.
        /// </remarks>
        public HRESULT GetTypeInfoCount([Out] out UINT pctinfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[3])(thisPtr, out pctinfo);
            }
        }

        /// <summary>
        /// Retrieves the type information for an object, which can then be used to get the type information for an interface.
        /// </summary>
        /// <param name="iTInfo">
        /// The type information to return.
        /// Pass 0 to retrieve type information for the <see cref="IDispatch"/> implementation.
        /// </param>
        /// <param name="lcid">
        /// The locale identifier for the type information.
        /// An object may be able to return different type information for different languages.
        /// This is important for classes that support localized member names.
        /// For classes that do not support localized member names, this parameter can be ignored.
        /// </param>
        /// <param name="ppTInfo">
        /// The requested type information object.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="DISP_E_BADINDEX"/>: The <paramref name="iTInfo"/> parameter was not 0.
        /// </returns>
        public HRESULT GetTypeInfo([In] UINT iTInfo, [In] LCID lcid, [Out] out IntPtr ppTInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, LCID, out IntPtr, HRESULT>)_vTable[4])(thisPtr, iTInfo, lcid, out ppTInfo);
            }
        }
    }
}
