using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D2d1.dll
    /// </summary>
    public static class D2d1
    {
        /// <summary>
        /// <para>
        /// Creates a factory object that can be used to create Direct2D resources.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1createfactory"/>
        /// </para>
        /// </summary>
        /// <param name="factoryType">
        /// The threading model of the factory and the resources it creates.
        /// </param>
        /// <param name="riid">
        /// A reference to the <see cref="IID"/> of <see cref="ID2D1Factory"/> that is obtained by using <c>__uuidof(ID2D1Factory)</c>.
        /// </param>
        /// <param name="pFactoryOptions">
        /// The level of detail provided to the debugging layer.
        /// </param>
        /// <param name="ppIFactory">
        /// When this method returns, contains the address to a pointer to the new factory.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The <see cref="ID2D1Factory"/> interface provides the starting point for Direct2D.
        /// In general, an object created from a single instance of a factory object can be used with other resources created from that instance,
        /// but not with resources created by other factory instances.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP2, Note = "Platform Update Supplement")]
        [DllImport("D2d1.dll", CharSet = CharSet.Unicode, EntryPoint = "D2D1CreateFactory", ExactSpelling = true)]
        public static extern HRESULT D2D1CreateFactory([In] D2D1_FACTORY_TYPE factoryType, [In] in IID riid,
            [In] in D2D1_FACTORY_OPTIONS pFactoryOptions, [Out] out IntPtr ppIFactory);
    }
}
