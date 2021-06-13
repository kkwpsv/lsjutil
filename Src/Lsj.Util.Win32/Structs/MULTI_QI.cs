using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents an interface in a query for multiple interfaces.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-multi_qi"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To optimize network performance, most remote activation functions take an array of <see cref="MULTI_QI"/> structures rather than
    /// just a single IID as input and a single pointer to the requested interface on the object as output, as do local activation functions.
    /// This allows a set of pointers to interfaces to be returned from the same object in a single round-trip to the server.
    /// In network scenarios, requesting multiple interfaces at the time of object construction can save considerable time over
    /// using a number of calls to QueryInterface for unique interfaces, each of which would require a round-trip to the server.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MULTI_QI
    {
        /// <summary>
        /// A pointer to an interface identifier.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStruct)]
        public Guid pIID;

        /// <summary>
        /// A pointer to the interface requested in <see cref="pIID"/>.
        /// This member must be <see langword="null"/> on input.
        /// </summary>
        [MarshalAs(UnmanagedType.IUnknown)]
        public object pItf;

        /// <summary>
        /// The return value of the QueryInterface call to locate the requested interface.
        /// Common return values include <see cref="S_OK"/> and <see cref="E_NOINTERFACE"/>. This member must be 0 on input.
        /// </summary>
        public HRESULT hr;
    }
}
