using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an exception that occurred during <see cref="IDispatch.Invoke"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-excepinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use the <see cref="pfnDeferredFillIn"/> field to enable an object to defer filling in the <see cref="bstrDescription"/>,
    /// <see cref="bstrHelpFile"/>, and <see cref="dwHelpContext"/> fields until they are needed.
    /// This field might be used, for example, if loading the string for the error is a time-consuming operation.
    /// To use deferred fill-in, the object puts a function pointer in this slot
    /// and does not fill any of the other fields except <see cref="wCode"/>, which is required.
    /// To get additional information, the caller passes the <see cref="EXCEPINFO"/> structure back to the pexcepinfo callback function,
    /// which fills in the additional information.
    /// When the ActiveX object and the ActiveX client are in different processes,
    /// the ActiveX object calls <see cref="pfnDeferredFillIn"/> before returning to the controller.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXCEPINFO
    {
        /// <summary>
        /// The error code.
        /// Error codes should be greater than 1000.
        /// Either this field or the <see cref="scode"/> field must be filled in; the other must be set to 0.
        /// </summary>
        public WORD wCode;

        /// <summary>
        /// Reserved. Should be 0.
        /// </summary>
        public WORD wReserved;

        /// <summary>
        /// The name of the exception source.
        /// Typically, this is an application name.
        /// This field should be filled in by the implementer of <see cref="IDispatch"/>.
        /// </summary>
        public IntPtr bstrSource;

        /// <summary>
        /// The exception description to display.
        /// If no description is available, use <see cref="NULL"/>.
        /// </summary>
        public IntPtr bstrDescription;

        /// <summary>
        /// The fully qualified help file path.
        /// If no Help is available, use <see cref="NULL"/>.
        /// </summary>
        public IntPtr bstrHelpFile;

        /// <summary>
        /// The help context ID.
        /// </summary>
        public DWORD dwHelpContext;

        /// <summary>
        /// Reserved.
        /// Must be <see cref="NULL"/>.
        /// </summary>
        public ULONG_PTR pvReserved;

        /// <summary>
        /// Provides deferred fill-in.
        /// If deferred fill-in is not desired, this field should be set to <see cref="NULL"/>.
        /// </summary>
        public ULONG_PTR pfnDeferredFillIn;

        /// <summary>
        /// A return value that describes the error.
        /// Either this field or <see cref="wCode"/> (but not both) must be filled in; the other must be set to 0.
        /// (16-bit Windows versions only.)
        /// </summary>
        public SCODE scode;
    }
}
