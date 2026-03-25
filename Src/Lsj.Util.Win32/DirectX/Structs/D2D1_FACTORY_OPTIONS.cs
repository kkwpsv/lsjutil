using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the debugging level of an <see cref="ID2D1Factory"/> object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_factory_options"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To enable debugging, you must install the Direct2D Debug Layer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_FACTORY_OPTIONS
    {
        /// <summary>
        /// The debugging level of the <see cref="ID2D1Factory"/> object.
        /// </summary>
        public D2D1_DEBUG_LEVEL debugLevel;
    }
}
