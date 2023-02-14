using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Specifies a method that retrieves a class object
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iclassactivator"/>
    /// </para>
    /// </summary>
    public unsafe struct IClassActivator
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves a class object.
        /// </summary>
        /// <param name="rclsid">
        /// The <see cref="CLSID"/> that identifies the class whose class object is to be retrieved.
        /// </param>
        /// <param name="dwClassContext">
        /// The context in which the class is expected to run.
        /// For a list of values, see the <see cref="CLSCTX"/> enumeration.
        /// </param>
        /// <param name="locale">
        /// An <see cref="LCID"/> constant as defined in WinNls.h.
        /// </param>
        /// <param name="riid">
        /// The <see cref="IID"/> of the interface on the object to which a pointer is desired.
        /// </param>
        /// <param name="ppv">
        /// The address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, <paramref name="ppv"/> contains the requested interface pointer.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="S_OK"/>.
        /// Otherwise, it is <see cref="E_FAIL"/>.
        /// </returns>
        public HRESULT GetClassObject([In] in CLSID rclsid, [In] CLSCTX dwClassContext, [In] LCID locale, [In] in IID riid, [Out] out IntPtr ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in CLSID, CLSCTX, LCID, in IID, out IntPtr, HRESULT>)_vTable[3])(thisPtr, rclsid, dwClassContext, locale, riid, out ppv);
            }
        }
    }
}
