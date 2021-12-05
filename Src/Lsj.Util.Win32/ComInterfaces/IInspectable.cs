using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides functionality required for all Windows Runtime classes.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/inspectable/nn-inspectable-iinspectable"/>
    /// </para>
    /// <remark>
    /// <see cref="IInspectable"/> methods have no effect on COM apartments and are safe to call from user interface threads.
    /// </remark>
    /// </summary>
    public unsafe struct IInspectable
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the interfaces that are implemented by the current Windows Runtime class.
        /// </summary>
        /// <param name="iidCount">
        /// The number of interfaces that are implemented by the current Windows Runtime object,
        /// excluding the <see cref="IUnknown"/> and <see cref="IInspectable"/> implementations.
        /// </param>
        /// <param name="iids">
        /// A pointer to an array that contains an IID for each interface implemented by the current Windows Runtime object.
        /// The <see cref="IUnknown"/> and <see cref="IInspectable"/> interfaces are excluded.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: The <see cref="HSTRING"/> was created successfully.
        /// <see cref="E_OUTOFMEMORY"/>: Failed to allocate iids.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="GetIids"/> method to discover the interfaces that are implemented by a Windows Runtime object.
        /// A <see cref="IUnknown.QueryInterface"/> call on any <see cref="IID"/> in the <paramref name="iids"/> array must succeed.
        /// The caller is responsible for freeing the <see cref="IID"/> array by using the <see cref="CoTaskMemFree"/> function.
        /// </remarks>
        public HRESULT GetIids([Out] out ULONG iidCount, [Out] out LP<IID> iids)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out ULONG, out LP<IID>, HRESULT>)_vTable[3])(thisPtr, out iidCount, out iids);
            }
        }

        /// <summary>
        /// Gets the fully qualified name of the current Windows Runtime object.
        /// </summary>
        /// <param name="className">
        /// The fully qualified name of the current Windows Runtime object.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: The <paramref name="className"/> string was created successfully.
        /// <see cref="E_OUTOFMEMORY"/>: Failed to allocate <paramref name="className"/> string.
        /// <see cref="E_ILLEGAL_METHOD_CALL"/>: <paramref name="className"/> refers to a class factory or a static interface.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="GetRuntimeClassName"/> method to retrieve the namespace-qualified name of a Windows Runtime object.
        /// The caller is responsible for freeing the className string by using the <see cref="WindowsDeleteString"/> function.
        /// The following table shows example class name strings that could be returned by the <see cref="GetRuntimeClassName"/> method.
        /// Fabrikam.Kitchen.IToaster
        /// An interface in the Fabrikam.Kitchen namespace.
        /// Fabrikam.Kitchen.Chef
        /// An class in the Fabrikam.Kitchen namespace.
        /// Windows.Foundation.Collections.IVector`1&lt;TailspinToys.IStore&gt;
        /// A vector of TailspinToys.IStore interfaces.
        /// Windows.Foundation.Collections.IVector`1&lt;Windows.Foundation.Collections.IMap`2&lt;String, TailspinToys.IStore&gt;&gt;
        /// A vector of maps of strings to TailspinToys.IStore interfaces.
        /// The <see cref="GetRuntimeClassName"/> method provides the most specific type information that the server object guarantees that it implements.
        /// The type name may be a runtime class name, interface group name, interface name, or parameterized interface name.
        /// The <see cref="GetRuntimeClassName"/> method returns <see cref="E_ILLEGAL_METHOD_CALL"/> if the class name refers to a class factory or a static interface.
        /// </remarks>
        public HRESULT GetRuntimeClassName([Out] out HSTRING className)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HSTRING, HRESULT>)_vTable[4])(thisPtr, out className);
            }
        }

        /// <summary>
        /// <para>
        /// Gets the trust level of the current Windows Runtime object.
        /// </para>
        /// </summary>
        /// <param name="trustLevel">
        /// The trust level of the current Windows Runtime object.
        /// The default is BaseLevel.
        /// </param>
        /// <returns>
        /// This method always returns <see cref="S_OK"/>.
        /// </returns>
        public HRESULT GetTrustLevel([Out] out TrustLevel trustLevel)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out TrustLevel, HRESULT>)_vTable[5])(thisPtr, out trustLevel);
            }
        }
    }
}
