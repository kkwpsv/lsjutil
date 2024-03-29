﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.STGM;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains parameters used during a moniker-binding operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/ns-objidl-bind_opts3-r1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A <see cref="BIND_OPTS3"/> structure is stored in a bind context;
    /// the same bind context is used by each component of a composite moniker during binding,
    /// allowing the same parameters to be passed to all components of a composite moniker.
    /// See <see cref="IBindCtx"/> for more information about bind contexts.
    /// Moniker clients (use a moniker to acquire an interface pointer to an object) typically do not need to specify values
    /// for the members of this structure.
    /// The <see cref="CreateBindCtx"/> function creates a bind context with the bind options set to default values that are suitable for most situations;
    /// the BindMoniker function does the same thing when creating a bind context for use in binding a moniker.
    /// If you want to modify the values of these bind options, you can do so by passing a <see cref="BIND_OPTS3"/> structure
    /// to the <see cref="IBindCtx.SetBindOptions"/> method.
    /// Moniker implementers can pass a <see cref="BIND_OPTS2"/> structure to the <see cref="IBindCtx.GetBindOptions"/> method
    /// to retrieve the values of these bind options.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BIND_OPTS3
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cbStruct;

        /// <summary>
        /// Flags that control aspects of moniker binding operations.
        /// This value is any combination of the bit flags in the <see cref="BIND_FLAGS"/> enumeration.
        /// The <see cref="CreateBindCtx"/> function initializes this member to zero.
        /// </summary>
        public BIND_FLAGS grfFlags;

        /// <summary>
        /// Flags that should be used when opening the file that contains the object identified by the moniker.
        /// Possible values are the <see cref="STGM"/> constants.
        /// The binding operation uses these flags in the call to <see cref="IPersistFile.Load"/> when loading the file.
        /// If the object is already running, these flags are ignored by the binding operation.
        /// The <see cref="CreateBindCtx"/> function initializes this field to <see cref="STGM_READWRITE"/>.
        /// </summary>
        public STGM grfMode;

        /// <summary>
        /// The clock time by which the caller would like the binding operation to be completed, in milliseconds.
        /// This member lets the caller limit the execution time of an operation when speed is of primary importance.
        /// A value of zero indicates that there is no deadline.
        /// Callers most often use this capability when calling the <see cref="IMoniker.GetTimeOfLastChange"/> method,
        /// though it can be usefully applied to other operations as well.
        /// The <see cref="CreateBindCtx"/> function initializes this field to zero.
        /// Typical deadlines allow for a few hundred milliseconds of execution.
        /// This deadline is a recommendation, not a requirement; however, operations that exceed their deadline by a large amount
        /// may cause delays for the end user.
        /// Each moniker implementation should try to complete its operation by the deadline, or fail with the error <see cref="MK_E_EXCEEDEDDEADLINE"/>.
        /// If a binding operation exceeds its deadline because one or more objects that it needs are not running,
        /// the moniker implementation should register the objects responsible in the bind context using the <see cref="IBindCtx.RegisterObjectParam"/>.
        /// The objects should be registered under the parameter names "ExceededDeadline", "ExceededDeadline1", "ExceededDeadline2", and so on.
        /// If the caller later finds the object in the running object table, the caller can retry the binding operation.
        /// The <see cref="GetTickCount"/> function indicates the number of milliseconds since system startup,
        /// and wraps back to zero after 2^31 milliseconds.
        /// Consequently, callers should be careful not to inadvertently pass a zero value (which indicates no deadline),
        /// and moniker implementations should be aware of clock wrapping problems.
        /// </summary>
        public DWORD dwTickCountDeadline;

        /// <summary>
        /// A moniker can use this value during link tracking.
        /// If the original persisted data that the moniker is referencing has been moved, the moniker can attempt to reestablish the link
        /// by searching for the original data though some adequate mechanism.
        /// This member provides additional information on how the link should be resolved.
        /// See the documentation of the fFlags parameter in <see cref="IShellLink.Resolve"/>.
        /// COM's file moniker implementation uses the shell link mechanism to reestablish links and passes these flags to <see cref="IShellLink.Resolve"/>.
        /// </summary>
        public DWORD dwTrackFlags;

        /// <summary>
        /// The class context, taken from the <see cref="CLSCTX"/> enumeration, that is to be used for instantiating the object.
        /// Monikers typically pass this value to the dwClsContext parameter of <see cref="CoCreateInstance"/>.
        /// </summary>
        public CLSCTX dwClassContext;

        /// <summary>
        /// The LCID value indicating the client's preference for the locale to be used by the object to which they are binding.
        /// A moniker passes this value to <see cref="IClassActivator.GetClassObject"/>.
        /// </summary>
        public LCID locale;

        /// <summary>
        /// A pointer to a <see cref="COSERVERINFO"/> structure.
        /// This member allows clients calling <see cref="IMoniker.BindToObject"/> to specify server information.
        /// Clients may pass a <see cref="BIND_OPTS2"/> structure to the <see cref="IBindCtx.SetBindOptions"/> method.
        /// If a server name is specified in the <see cref="COSERVERINFO"/> structure, the moniker bind will be forwarded to the specified computer.
        /// <see cref="IBindCtx.SetBindOptions"/> only copies the struct members of <see cref="BIND_OPTS2"/>,
        /// not the <see cref="COSERVERINFO"/> structure and the pointers it contains.
        /// Callers may not free any of these pointers until the bind context is released.
        /// COM's new class moniker does not currently honor the <see cref="pServerInfo"/> flag.
        /// </summary>
        public IntPtr pServerInfo;

        /// <summary>
        /// A handle to the window that becomes the owner of the elevation UI, if applicable.
        /// If hwnd is <see cref="NULL"/>, COM will call the <see cref="GetActiveWindow"/> function to find a window handle
        /// associated with the current thread. This case might occur if the client is a script,
        /// which cannot fill in a <see cref="BIND_OPTS3"/> structure.
        /// In this case, COM will try to use the window associated with the script thread.
        /// </summary>
        public HWND hwnd;
    }
}
