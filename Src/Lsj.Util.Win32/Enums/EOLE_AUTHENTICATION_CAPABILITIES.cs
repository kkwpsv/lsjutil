using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies various capabilities in <see cref="CoInitializeSecurity"/> and <see cref="IClientSecurity.SetBlanket"/>
    /// (or its helper function <see cref="CoSetProxyBlanket"/>).
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ne-objidl-eole_authentication_capabilities
    /// </para>
    /// </summary>
    /// <remarks>
    /// When the <see cref="EOAC_APPID"/> flag is set, <see cref="CoInitializeSecurity"/> looks for the authentication level under the AppID.
    /// If the authentication level is not found, it looks for the default authentication level.
    /// If the default authentication level is not found, it generates a default authentication level of connect.
    /// If the authentication level is not <see cref="RPC_C_AUTHN_LEVEL_NONE"/>,
    /// <see cref="CoInitializeSecurity"/> looks for the access permission value under the AppID.
    /// If not found, it looks for the default access permission value.
    /// If not found, it generates a default access permission.
    /// All the other security settings are determined the same way as for a legacy application.
    /// If the AppID is <see cref="NULL"/>, CoInitializeSecurity looks up the application .exe name in the registry and uses the AppID stored there.
    /// If the AppID does not exist, the machine defaults are used.
    /// The <see cref="IClientSecurity.SetBlanket"/> method and <see cref="CoSetProxyBlanket"/> function return an error
    /// if any of the following flags are set in the capabilities parameter: <see cref="EOAC_SECURE_REFS"/>, <see cref="EOAC_ACCESS_CONTROL"/>,
    /// <see cref="EOAC_APPID"/>, <see cref="EOAC_DYNAMIC"/>, <see cref="EOAC_REQUIRE_FULLSIC"/>,
    /// <see cref="EOAC_DISABLE_AAA"/>, or <see cref="EOAC_NO_CUSTOM_MARSHAL"/>.
    /// </remarks>
    public enum EOLE_AUTHENTICATION_CAPABILITIES
    {
        /// <summary>
        /// Indicates that no capability flags are set.
        /// </summary>
        EOAC_NONE = 0,

        /// <summary>
        /// If this flag is specified, it will be ignored.
        /// Support for mutual authentication is automatically provided by some authentication services.
        /// See COM and Security Packages for more information.
        /// </summary>
        EOAC_MUTUAL_AUTH = 0x1,

        /// <summary>
        /// Sets static cloaking.
        /// When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
        /// However, the client's identity is determined on the first call on each proxy (if <see cref="SetBlanket"/> is not called)
        /// and each time <see cref="CoSetProxyBlanket"/> is called on the proxy.
        /// For more information about static cloaking, see Cloaking.
        /// <see cref="CoInitializeSecurity"/> and <see cref="IClientSecurity.SetBlanket"/> return errors if both cloaking flags are set
        /// or if either flag is set when Schannel is the authentication service.
        /// </summary>
        EOAC_STATIC_CLOAKING = 0x20,

        /// <summary>
        /// Sets dynamic cloaking.
        /// When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
        /// On each call to a proxy, the current thread token is examined to determine whether the client's identity has changed
        /// (incurring an additional performance cost) and the client is authenticated again only if necessary.
        /// Dynamic cloaking can be set by clients only.
        /// For more information about dynamic cloaking, see Cloaking.
        /// <see cref="CoInitializeSecurity"/> and <see cref="IClientSecurity.SetBlanket"/> return errors if both cloaking flags are set
        /// or if either flag is set when Schannel is the authentication service.
        /// </summary>
        EOAC_DYNAMIC_CLOAKING = 0x40,

        /// <summary>
        /// This flag is obsolete.
        /// </summary>
        [Obsolete]
        EOAC_ANY_AUTHORITY = 0x80,

        /// <summary>
        /// Causes DCOM to send Schannel server principal names in fullsic format to clients as part of the default security negotiation.
        /// The name is extracted from the server certificate. For more information about the fullsic form, see Principal Names.
        /// </summary>
        EOAC_MAKE_FULLSIC = 0x100,

        /// <summary>
        /// Tells DCOM to use the valid capabilities from the call to <see cref="CoInitializeSecurity"/>.
        /// If <see cref="CoInitializeSecurity"/> was not called, <see cref="EOAC_NONE"/> will be used for the capabilities flag.
        /// This flag can be set only by clients in a call to <see cref="IClientSecurity.SetBlanket"/> or <see cref="CoSetProxyBlanket"/>.
        /// </summary>
        EOAC_DEFAULT = 0x800,

        /// <summary>
        /// Authenticates distributed reference count calls to prevent malicious users from releasing objects that are still being used.
        /// If this flag is set, which can be done only in a call to <see cref="CoInitializeSecurity"/> by the client,
        /// the authentication level (in dwAuthnLevel) cannot be set to none.
        /// The server always authenticates Release calls.
        /// Setting this flag prevents an authenticated client from releasing the objects of another authenticated client.
        /// It is recommended that clients always set this flag,
        /// although performance is affected because of the overhead associated with the extra security.
        /// </summary>
        EOAC_SECURE_REFS = 0x2,

        /// <summary>
        /// Indicates that the pSecDesc parameter to <see cref="CoInitializeSecurity"/> is a pointer to
        /// an <see cref="IAccessControl"/> interface on an access control object.
        /// When DCOM makes security checks, it calls <see cref="IAccessControl.IsAccessAllowed"/>. This flag is set only by the server.
        /// <see cref="CoInitializeSecurity"/> returns an error if both the <see cref="EOAC_APPID"/> and <see cref="EOAC_ACCESS_CONTROL"/> flags are set.
        /// </summary>
        EOAC_ACCESS_CONTROL = 0x4,

        /// <summary>
        /// Indicates that the pSecDesc parameter to <see cref="CoInitializeSecurity"/> is a pointer to a GUID that is an AppID.
        /// The <see cref="CoInitializeSecurity"/> function looks up the AppID in the registry and reads the security settings from there.
        /// If this flag is set, all other parameters to <see cref="CoInitializeSecurity"/> are ignored and must be zero.
        /// Only the server can set this flag.
        /// For more information about this capability flag, see the Remarks section below.
        /// <see cref="CoInitializeSecurity"/> returns an error if both the <see cref="EOAC_APPID"/> and <see cref="EOAC_ACCESS_CONTROL"/> flags are set.
        /// </summary>
        EOAC_APPID = 0x8,

        /// <summary>
        /// Reserved.
        /// </summary>
        EOAC_DYNAMIC = 0x10,

        /// <summary>
        /// Causes DCOM to fail <see cref="CoSetProxyBlanket"/> calls where an Schannel principal name is specified in any format other than fullsic.
        /// This flag is currently for clients only.
        /// For more information about the fullsic form, see Principal Names.
        /// </summary>
        EOAC_REQUIRE_FULLSIC = 0x200,

        /// <summary>
        /// Reserved.
        /// </summary>
        EOAC_AUTO_IMPERSONATE = 0x400,

        /// <summary>
        /// Causes any activation where a server process would be launched
        /// under the caller's identity (activate-as-activator) to fail with <see cref="E_ACCESSDENIED"/>.
        /// This value, which can be specified only in a call to <see cref="CoInitializeSecurity"/> by the client,
        /// allows an application that runs under a privileged account (such as LocalSystem)
        /// to help prevent its identity from being used to launch untrusted components.
        /// An activation call that uses <see cref="CLSCTX_ENABLE_AAA"/> of the <see cref="CLSCTX"/> enumeration
        /// will allow activate-as-activator activations for that call.
        /// </summary>
        EOAC_DISABLE_AAA = 0x1000,

        /// <summary>
        /// Specifying this flag helps protect server security when using DCOM or COM+.
        /// It reduces the chances of executing arbitrary DLLs because it allows the marshaling of only CLSIDs that are implemented in Ole32.dll,
        /// ComAdmin.dll, ComSvcs.dll, or Es.dll, or that implement the CATID_MARSHALER category ID.
        /// Any service that is critical to system operation should set this flag.
        /// </summary>
        EOAC_NO_CUSTOM_MARSHAL = 0x2000,

        /// <summary>
        /// 
        /// </summary>
        EOAC_RESERVED1 = 0x4000
    }
}
