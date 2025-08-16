using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EOLE_AUTHENTICATION_CAPABILITIES;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values that are used in activation calls to indicate the execution contexts in which an object is to be run.
    /// These values are also used in calls to <see cref="CoRegisterClassObject"/> to indicate the set of execution contexts
    /// in which a class object is to be made available for requests to construct instances.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ne-wtypesbase-clsctx"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Values from the <see cref="CLSCTX"/> enumeration are used in activation calls
    /// (<see cref="CoCreateInstance"/>, <see cref="CoCreateInstanceEx"/>, <see cref="CoGetClassObject"/>, and so on)
    /// to indicate the preferred execution contexts (in-process, local, or remote) in which an object is to be run.
    /// They are also used in calls to <see cref="CoRegisterClassObject"/> to indicate the set of execution contexts
    /// in which a class object is to be made available for requests to construct instances (<see cref="IClassFactory.CreateInstance"/>).
    /// </para>
    /// <para>
    /// To indicate that more than one context is acceptable, you can combine multiple values with Boolean ORs.
    /// The contexts are tried in the order in which they are listed.
    /// </para>
    /// <para>
    /// Given a set of <see cref="CLSCTX"/> flags, the execution context to be used
    /// depends on the availability of registered class codes and other parameters according to the following algorithm.
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// <para>
    /// If the call specifies one of the following, <see cref="CLSCTX_REMOTE_SERVER"/> is implied and is added to the list of flags:
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// An explicit <see cref="COSERVERINFO"/> structure indicating a machine different from the current computer.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// No explicit <see cref="COSERVERINFO"/> structure specified but the specified class is registered
    /// with either the RemoteServerName or ActivateAtStorage registry value.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// The second case allows applications written prior to the release of distributed COM to be the configuration of classes for remote activation
    /// to be used by client applications available prior to DCOM and the <see cref="CLSCTX_REMOTE_SERVER"/> flag.
    /// The cases in which there would be no explicit <see cref="COSERVERINFO"/> structure are when the value
    /// is specified as <see cref="NULL"/> or when it is not one of the function parameters
    /// (as in calls to <see cref="CoCreateInstance"/> and <see cref="CoGetClassObject"/>).
    /// </para>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the explicit <see cref="COSERVERINFO"/> parameter indicates the current computer, <see cref="CLSCTX_REMOTE_SERVER"/> is removed if present.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// The rest of the processing proceeds by looking at the value(s) in the following sequence:
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// If the flags include <see cref="CLSCTX_REMOTE_SERVER"/> and no <see cref="COSERVERINFO"/> parameter is specified
    /// and if the activation request indicates a persistent state from which to initialize the object
    /// (with <see cref="CoGetInstanceFromFile"/>, <see cref="CoGetInstanceFromIStorage"/>, or, for a file moniker,
    /// in a call to <see cref="IMoniker.BindToObject"/>) and the class has an ActivateAtStorage subkey or no class registry information whatsoever,
    /// the request to activate and initialize is forwarded to the computer where the persistent state resides.
    /// (Refer to the remote activation functions listed in the See Also section for details.)
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the flags include <see cref="CLSCTX_INPROC_SERVER"/>,
    /// the class code in the DLL found under the class's InprocServer32 key is used if this key exists.
    /// The class code will run within the same process as the caller.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the flags include <see cref="CLSCTX_INPROC_HANDLER"/>,
    /// the class code in the DLL found under the class's InprocHandler32 key is used if this key exists
    /// . The class code will run within the same process as the caller.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the flags include <see cref="CLSCTX_LOCAL_SERVER"/>,
    /// the class code in the service found under the class's LocalService key is used if this key exists.
    /// If no service is specified but an EXE is specified under that same key,
    /// the class code associated with that EXE is used.
    /// The class code (in either case) will be run in a separate service process on the same computer as the caller.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the flag is set to <see cref="CLSCTX_REMOTE_SERVER"/> and an additional <see cref="COSERVERINFO"/> parameter
    /// to the function specifies a particular remote computer,
    /// a request to activate is forwarded to this remote computer with flags modified to set to <see cref="CLSCTX_LOCAL_SERVER"/>.
    /// The class code will run in its own process on this specific computer, which must be different from that of the caller.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Finally, if the flags include <see cref="CLSCTX_REMOTE_SERVER"/> and no <see cref="COSERVERINFO"/> parameter is specified
    /// and if a computer name is given under the class's RemoteServerName named-value,
    /// the request to activate is forwarded to this remote computer with the flags modified to be set to <see cref="CLSCTX_LOCAL_SERVER"/>.
    /// The class code will run in its own process on this specific computer, which must be different from that of the caller.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// <see cref="CLSCTX_ACTIVATE_32_BIT_SERVER"/> and <see cref="CLSCTX_ACTIVATE_64_BIT_SERVER"/>
    /// </para>
    /// <para>
    /// The 64-bit versions of Windows introduce two new flags: <see cref="CLSCTX_ACTIVATE_32_BIT_SERVER"/> and <see cref="CLSCTX_ACTIVATE_64_BIT_SERVER"/>.
    /// On a 64-bit computer, a 32-bit and 64-bit version of the same COM server may coexist.
    /// When a client requests an activation of an out-of-process server,
    /// these <see cref="CLSCTX"/> flags allow the client to specify a 32-bit or a 64-bit version of the server.
    /// </para>
    /// <para>
    /// Usually, a client will not care whether it uses a 32-bit or a 64-bit version of the server.
    /// However, if the server itself loads an additional in-process server, then it and the in-process server must both be either 32-bit or 64-bit.
    /// For example, suppose that the client wants to use a server "A", which in turn loads an in-process server "B".
    /// If only a 32-bit version of server "B" is available, then the client must specify the 32-bit version of server "A".
    /// If only a 64-bit version of server "B" is available, then the client must specify the 64-bit version of server "A".
    /// </para>
    /// <para>
    /// A server can specify its own architecture preference via the PreferredServerBitness registry key, but the client's preference,
    /// specified via a <see cref="CLSCTX_ACTIVATE_32_BIT_SERVER"/> or <see cref="CLSCTX_ACTIVATE_64_BIT_SERVER"/> flag, will override the server's preference.
    /// If the client does not specify a preference, then the server's preference will be used.
    /// </para>
    /// <para>
    /// If neither the client nor the server specifies a preference, then:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// If the computer that hosts the server is running Windows Server 2003 with Service Pack 1 (SP1) or a later system,
    /// then COM will try to match the server architecture to the client architecture.
    /// In other words, for a 32-bit client, COM will activate a 32-bit server if available; otherwise it will activate a 64-bit version of the server.
    /// For a 64-bit client, COM will activate a 64-bit server if available; otherwise it will activate a 32-bit server.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the computer that hosts the server is running Windows XP or Windows Server 2003 without SP1 or later installed,
    /// then COM will prefer a 64-bit version of the server if available; otherwise it will activate a 32-bit version of the server.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// If a <see cref="CLSCTX"/> enumeration has both the <see cref="CLSCTX_ACTIVATE_32_BIT_SERVER"/> and <see cref="CLSCTX_ACTIVATE_64_BIT_SERVER"/> flags set,
    /// then it is invalid and the activation will return <see cref="E_INVALIDARG"/>.
    /// </para>
    /// <para>
    /// The following table shows the results of the various combinations of client architectures and client settings and server architectures and server settings.
    /// </para>
    /// <para>
    /// The flags <see cref="CLSCTX_ACTIVATE_32_BIT_SERVER"/> and <see cref="CLSCTX_ACTIVATE_64_BIT_SERVER"/> flow across computer boundaries.
    /// If the computer that hosts the server is running the 64-bit Windows, then it will honor these flags; otherwise it will ignore them.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// 32-bit client, no flag
    /// </term>
    /// <term>
    /// 64-bit client, no flag
    /// </term>
    /// <term>
    /// 32-bit client, 32-bit flag¹
    /// </term>
    /// <term>
    /// 32-bit client, 64-bit flag²
    /// </term>
    /// <term>
    /// 64-bit client, 32-bit flag¹
    /// </term>
    /// <term>
    /// 64-bit client, 64-bit flag²
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// 32-bit server, match client registry value³
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 32-bit server, 32-bit registry value⁴
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 32-bit server, 64-bit registry value⁵
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 32-bit server, no registry value⁶
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// 64/32⁹
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 32-bit server, no registry value (before Windows Server 2003 with SP1)⁷
    /// </term>
    /// <term>
    /// 64/32⁹
    /// </term>
    /// <term>
    /// 64/32⁹
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 32-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 64-bit server, match client registry value³
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 64-bit server, 32-bit registry value⁴
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 64-bit server, 64-bit registry value⁵
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 64-bit server, no registry value⁶
    /// </term>
    /// <term>
    /// 32/64¹⁰
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 64-bit server, no registry value (before Windows Server 2003 with SP1)⁷
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// <term>
    /// See ⁸
    /// </term>
    /// <term>
    /// 64-bit server
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
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
        /// <para>
        /// The <see cref="CLSCTX_NO_FAILURE_LOG"/> can be used to override the logging of failures in <see cref="CoCreateInstanceEx"/>.
        /// </para>
        /// <para>
        /// If the ActivationFailureLoggingLevel is created, the following values can determine the status of event logging:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// 0 = Discretionary logging.
        /// Log by default, but clients can override by specifying <see cref="CLSCTX_NO_FAILURE_LOG"/> in <see cref="CoCreateInstanceEx"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 1 = Always log all failures no matter what the client specified.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 2 = Never log any failures no matter what client specified. 
        /// If the registry entry is missing, the default is 0.
        /// If you need to control customer applications, it is recommended that you set this value to 0 and write the client code to override failures.
        /// It is strongly recommended that you do not set the value to 2.
        /// If event logging is disabled, it is more difficult to diagnose problems.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        CLSCTX_NO_FAILURE_LOG = 0x4000,

        /// <summary>
        /// <para>
        /// Disables activate-as-activator (AAA) activations for this activation only.
        /// This flag overrides the setting of the <see cref="EOAC_DISABLE_AAA"/> flag from the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// This flag cannot be set at the same time as <see cref="CLSCTX_ENABLE_AAA"/>.
        /// Any activation where a server process would be launched under the caller's identity is known as an activate-as-activator (AAA) activation.
        /// Disabling AAA activations allows an application that runs under a privileged account (such as LocalSystem)
        /// to help prevent its identity from being used to launch untrusted components.
        /// Library applications that use activation calls should always set this flag during those calls.
        /// This helps prevent the library application from being used in an escalation-of-privilege security attack.
        /// This is the only way to disable AAA activations in a library application
        /// because the <see cref="EOAC_DISABLE_AAA"/> flag from the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration
        /// is applied only to the server process and not to the library application.
        /// </para>
        /// <para>
        /// Windows 2000: This flag is not supported.
        /// </para>
        /// </summary>
        CLSCTX_DISABLE_AAA = 0x8000,

        /// <summary>
        /// <para>
        /// Enables activate-as-activator (AAA) activations for this activation only.
        /// This flag overrides the setting of the <see cref="EOAC_DISABLE_AAA"/> flag from the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// This flag cannot be set at the same time as <see cref="CLSCTX_DISABLE_AAA"/>.
        /// Any activation where a server process would be launched under the caller's identity is known as an activate-as-activator (AAA) activation.
        /// Enabling this flag allows an application to transfer its identity to an activated component.
        /// Windows 2000:  This flag is not supported.
        /// </para>
        /// <para>
        /// Windows 2000: This flag is not supported.
        /// </para>
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
        /// <para>
        /// When this flag is specified, COM uses the impersonation token of the thread,
        /// if one is present, for the activation request made by the thread.
        /// When this flag is not specified or if the thread does not have an impersonation token,
        /// COM uses the process token of the thread's process for the activation request made by the thread.
        /// </para>
        /// <para>
        /// Windows Vista or later: This flag is supported.
        /// </para>
        /// </summary>
        CLSCTX_ENABLE_CLOAKING = 0x100000,

        /// <summary>
        /// <para>
        /// Indicates activation is for an app container.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This flag is reserved for internal use and is not intended to be used directly from your code.
        /// </para>
        /// </summary>
        CLSCTX_APPCONTAINER = 0x400000,

        /// <summary>
        /// <para>
        /// Specify this flag for Interactive User activation behavior for As-Activator servers.
        /// A strongly named Medium IL Windows Store app can use this flag to launch an "As Activator" COM server without a strong name.
        /// Also, you can use this flag to bind to a running instance of the COM server that's launched by a desktop application.
        /// </para>
        /// <para>
        /// The client must be Medium IL, it must be strongly named, which means that it has a SysAppID in the client token,
        /// it can't be in session 0, and it must have the same user as the session ID's user in the client token.
        /// </para>
        /// <para>
        /// If the server is out-of-process and "As Activator", it launches the server with the token of the client token's session user.
        /// This token won't be strongly named.
        /// </para>
        /// <para>
        /// If the server is out-of-process and RunAs "Interactive User", this flag has no effect.
        /// </para>
        /// <para>
        /// If the server is out-of-process and is any other RunAs type, the activation fails.
        /// </para>
        /// <para>
        /// This flag has no effect for in-process servers.
        /// </para>
        /// <para>
        /// Off-machine activations fail when they use this flag.
        /// </para>
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
        /// <para>
        /// Used for loading Proxy/Stub DLLs.
        /// </para>
        /// <para>
        /// Note        
        /// </para>
        /// <para>
        /// This flag is reserved for internal use and is not intended to be used directly from your code.
        /// </para>
        /// </summary>
        CLSCTX_PS_DLL = 0x80000000,

        /// <summary>
        /// CLSCTX_ALL
        /// </summary>
        CLSCTX_ALL = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,
    }
}
