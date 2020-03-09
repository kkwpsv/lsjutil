using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values that are used in activation calls to indicate the execution contexts in which an object is to be run.
    /// These values are also used in calls to <see cref="CoRegisterClassObject"/> to indicate the set of execution contexts
    /// in which a class object is to be made available for requests to construct instances.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wtypesbase/ne-wtypesbase-clsctx
    /// </para>
    /// </summary>
    [Flags]
    public enum CLSCTX : uint
    {
        /// <summary>
        /// The code that creates and manages objects of this class is a DLL that runs in the same process
        /// as the caller of the function specifying the class context.
        /// </summary>
        CLSCTX_INPROC_SERVER = 0x1,

        /// <summary>
        /// The code that manages objects of this class is an in-process handler.
        /// This is a DLL that runs in the client process and implements client-side structures of this class
        /// when instances of the class are accessed remotely.
        /// </summary>
        CLSCTX_INPROC_HANDLER = 0x2,

        /// <summary>
        /// The EXE code that creates and manages objects of this class runs on same machine but is loaded in a separate process space.
        /// </summary>
        CLSCTX_LOCAL_SERVER = 0x4,

        /// <summary>
        /// Obsolete.
        /// </summary>
        [Obsolete]
        CLSCTX_INPROC_SERVER16 = 0x8,

        /// <summary>
        /// A remote context.
        /// The LocalServer32 or LocalService code that creates and manages objects of this class is run on a different computer.
        /// </summary>
        CLSCTX_REMOTE_SERVER = 0x10,

        /// <summary>
        /// Obsolete.
        /// </summary>
        [Obsolete]
        CLSCTX_INPROC_HANDLER16 = 0x20,

        /// <summary>
        /// Reserved.
        /// </summary>
        CLSCTX_RESERVED1 = 0x40,

        /// <summary>
        /// Reserved.
        /// </summary>
        CLSCTX_RESERVED2 = 0x80,

        /// <summary>
        /// Reserved.
        /// </summary>
        CLSCTX_RESERVED3 = 0x100,

        /// <summary>
        /// Reserved.
        /// </summary>
        CLSCTX_RESERVED4 = 0x200,

        /// <summary>
        /// Disaables the downloading of code from the directory service or the Internet.
        /// This flag cannot be set at the same time as <see cref="CLSCTX_ENABLE_CODE_DOWNLOAD"/>.
        /// </summary>
        CLSCTX_NO_CODE_DOWNLOAD = 0x400,

        /// <summary>
        /// Reserved.
        /// </summary>
        CLSCTX_RESERVED5 = 0x800,

        /// <summary>
        /// Specify if you want the activation to fail if it uses custom marshalling.
        /// </summary>
        CLSCTX_NO_CUSTOM_MARSHAL = 0x1000,

        /// <summary>
        /// Enables the downloading of code from the directory service or the Internet.
        /// This flag cannot be set at the same time as <see cref="CLSCTX_NO_CODE_DOWNLOAD"/>.
        /// </summary>
        CLSCTX_ENABLE_CODE_DOWNLOAD = 0x2000,

        /// <summary>
        /// The <see cref="CLSCTX_NO_FAILURE_LOG"/> can be used to override the logging of failures in <see cref="CoCreateInstanceEx"/>.
        /// If the ActivationFailureLoggingLevel is created, the following values can determine the status of event logging:
        /// 0 = Discretionary logging.
        /// Log by default, but clients can override by specifying <see cref="CLSCTX_NO_FAILURE_LOG"/> in <see cref="CoCreateInstanceEx"/>.
        /// 1 = Always log all failures no matter what the client specified.
        /// 2 = Never log any failures no matter what client specified. If the registry entry is missing, the default is 0.
        /// If you need to control customer applications, it is recommended that you set this value to 0 and write the client code to override failures.
        /// It is strongly recommended that you do not set the value to 2.
        /// If event logging is disabled, it is more difficult to diagnose problems.
        /// </summary>
        CLSCTX_NO_FAILURE_LOG = 0x4000,

        /// <summary>
        /// Disables activate-as-activator (AAA) activations for this activation only.
        /// This flag overrides the setting of the <see cref="EOAC_DISABLE_AAA"/> flag from the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// This flag cannot be set at the same time as <see cref="CLSCTX_ENABLE_AAA"/>.
        /// Any activation where a server process would be launched under the caller's identity is known as an activate-as-activator (AAA) activation.
        /// Disabling AAA activations allows an application that runs under a privileged account (such as LocalSystem) to help
        /// prevent its identity from being used to launch untrusted components.
        /// Library applications that use activation calls should always set this flag during those calls.
        /// This helps prevent the library application from being used in an escalation-of-privilege security attack.
        /// This is the only way to disable AAA activations in a library application
        /// because the <see cref="EOAC_DISABLE_AAA"/> flag from the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration is applied
        /// only to the server process and not to the library application.
        /// Windows 2000:  This flag is not supported.
        /// </summary>
        CLSCTX_DISABLE_AAA = 0x8000,

        /// <summary>
        /// Enables activate-as-activator (AAA) activations for this activation only.
        /// This flag overrides the setting of the <see cref="EOAC_DISABLE_AAA"/> flag from the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// This flag cannot be set at the same time as <see cref="CLSCTX_DISABLE_AAA"/>.
        /// Any activation where a server process would be launched under the caller's identity is known as an activate-as-activator (AAA) activation.
        /// Enabling this flag allows an application to transfer its identity to an activated component.
        /// Windows 2000:  This flag is not supported.
        /// </summary>
        CLSCTX_ENABLE_AAA = 0x10000,

        /// <summary>
        /// Begin this activation from the default context of the current apartment.
        /// </summary>
        CLSCTX_FROM_DEFAULT_CONTEXT = 0x20000,

        /// <summary>
        /// 
        /// </summary>
        CLSCTX_ACTIVATE_X86_SERVER = 0x40000,

        /// <summary>
        /// Activate or connect to a 32-bit version of the server; fail if one is not registered.
        /// </summary>
        CLSCTX_ACTIVATE_32_BIT_SERVER = CLSCTX_ACTIVATE_X86_SERVER,

        /// <summary>
        /// Activate or connect to a 64 bit version of the server; fail if one is not registered.
        /// </summary>
        CLSCTX_ACTIVATE_64_BIT_SERVER = 0x80000,

        /// <summary>
        /// When this flag is specified, COM uses the impersonation token of the thread, if one is present, for the activation request made by the thread.
        /// When this flag is not specified or if the thread does not have an impersonation token,
        /// COM uses the process token of the thread's process for the activation request made by the thread.
        /// Windows Vista or later:  This flag is supported.
        /// </summary>
        CLSCTX_ENABLE_CLOAKING = 0x100000,

        /// <summary>
        /// Indicates activation is for an app container.
        /// This flag is reserved for internal use and is not intended to be used directly from your code.
        /// </summary>
        CLSCTX_APPCONTAINER = 0x400000,

        /// <summary>
        /// Specify this flag for Interactive User activation behavior for As-Activator servers.
        /// A strongly named Medium IL Windows Store app can use this flag to launch an "As Activator" COM server without a strong name.
        /// Also, you can use this flag to bind to a running instance of the COM server that's launched by a desktop application.
        /// The client must be Medium IL, it must be strongly named, which means that it has a SysAppID in the client token,
        /// it can't be in session 0, and it must have the same user as the session ID's user in the client token.
        /// If the server is out-of-process and "As Activator", it launches the server with the token of the client token's session user.
        /// This token won't be strongly named.
        /// If the server is out-of-process and RunAs "Interactive User", this flag has no effect.
        /// If the server is out-of-process and is any other RunAs type, the activation fails.
        /// This flag has no effect for in-process servers.
        /// Off-machine activations fail when they use this flag.
        /// </summary>
        CLSCTX_ACTIVATE_AAA_AS_IU = 0x800000,

        /// <summary>
        /// 
        /// </summary>
        CLSCTX_RESERVED6 = 0x1000000,

        /// <summary>
        /// 
        /// </summary>
        CLSCTX_ACTIVATE_ARM32_SERVER = 0x2000000,

        /// <summary>
        /// Used for loading Proxy/Stub DLLs.
        /// This flag is reserved for internal use and is not intended to be used directly from your code.
        /// </summary>
        CLSCTX_PS_DLL = 0x80000000,
    }
}
