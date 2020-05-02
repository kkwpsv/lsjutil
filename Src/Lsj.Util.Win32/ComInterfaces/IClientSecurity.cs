using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EOLE_AUTHENTICATION_CAPABILITIES;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Gives the client control over the security settings for each individual interface proxy of an object.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-iclientsecurity
    /// </para>
    /// </summary>
    /// <remarks>
    /// Every object has one proxy manager, and every proxy manager exposes the <see cref="IClientSecurity"/> interface automatically.
    /// Therefore, the client can query the proxy manager of an object for <see cref="IClientSecurity"/>, using any interface pointer on the object.
    /// If the QueryInterface call succeeds, the <see cref="IClientSecurity"/> pointer can be used to call an <see cref="IClientSecurity"/> method,
    /// passing a pointer to the interface proxy that the client is interested in.
    /// If a call to QueryInterface for <see cref="IClientSecurity"/> fails, either the object is implemented in-process
    /// or it is remoted by a custom marshaler that does not support security.
    /// (A custom marshaler can support security by offering the <see cref="IClientSecurity"/> interface to the client.)
    /// The interface proxies passed as parameters to <see cref="IClientSecurity"/> methods must be
    /// from the same object as the <see cref="IClientSecurity"/> interface.
    /// That is, each object has a distinct <see cref="IClientSecurity"/> interface; calling <see cref="IClientSecurity"/> on one object
    /// and passing a proxy to another object will not work.
    /// Also, you cannot pass an interface to an <see cref="IClientSecurity"/> method if the interface does not use a proxy.
    /// This means that interfaces implemented locally by the proxy manager cannot be passed to <see cref="IClientSecurity"/> methods,
    /// except for <see cref="IUnknown"/>, which is the exception to this rule.
    /// </remarks>
    [ComImport]
    [Guid(IID_IClientSecurity)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClientSecurity
    {
        /// <summary>
        /// Retrieves authentication information the client uses to make calls on the specified proxy.
        /// </summary>
        /// <param name="pProxy">
        /// A pointer to the proxy. This parameter cannot be <see langword="null"/>.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="pAuthnSvc">
        /// The current authentication service.
        /// This will be a single value taken from the list of authentication service constants.
        /// This parameter cannot be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="pAuthzSvc">
        /// The current authorization service.
        /// This will be a single value taken from the list of authorization constants.
        /// This parameter cannot be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="pServerPrincName">
        /// The current principal name.
        /// The string will be allocated by the callee using the <see cref="CoTaskMemAlloc"/> function
        /// and must be freed by the caller using the <see cref="CoTaskMemFree"/> function.
        /// Note that the actual principal name is returned.
        /// The <see cref="EOAC_MAKE_FULLSIC"/> flag is not accepted to convert the prinicpal name.
        /// If the caller specifies <see cref="NullRef{String}"/>, the current principal name is not retrieved.
        /// </param>
        /// <param name="pAuthnLevel">
        /// The current authentication level.
        /// This will be a single value taken from the list of authentication level constants.
        /// If this parameter is <see cref="NullRef{DWORD}"/>, the current authentication level is not retrieved.
        /// </param>
        /// <param name="pImpLevel">
        /// The current impersonation level.
        /// This will be a single value taken from the list of impersonation level constants.
        /// If this parameter is <see cref="NullRef{DWORD}"/>, the current impersonation level is not retrieved.
        /// </param>
        /// <param name="pAuthInfo">
        /// A pointer to a handle indicating the identity of the client that was passed to the last <see cref="SetBlanket"/> call (or the default value).
        /// Default values are only valid until the proxy is released.
        /// If the caller specifies <see cref="NullRef{IntPtr}"/>, the client identity is not retrieved.
        /// The format of the structure that the returned handle refers to depends on the authentication service.
        /// For NTLMSSP and Kerberos, if the client specified a structure in the <paramref name="pAuthInfo"/> parameter
        /// to <see cref="CoInitializeSecurity"/>, that value is returned.
        /// For Schannel, if a certificate for the client could be retrieved from the certificate manager, that value is returned here.
        /// Otherwise, <see cref="NULL"/> is returned. Because this points to the value itself and is not a copy, it should not be manipulated or freed.
        /// </param>
        /// <param name="pCapabilites">
        /// The capabilities of the proxy.
        /// These flags are defined in the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// If this parameter is <see cref="NullRef{DWORD}"/>, the current capability flags are not retrieved.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="E_INVALIDARG"/>: One or more arguments are not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory to create the <paramref name="pServerPrincName"/> buffer.
        /// </returns>
        /// <remarks>
        /// <see cref="QueryBlanket"/> is called by the client to retrieve the authentication information
        /// COM will use on calls made from the specified interface proxy.
        /// With a pointer to an interface on the proxy, the client would first call QueryInterface for a pointer to <see cref="IClientSecurity"/>;
        /// then, with this pointer, the client would call <see cref="QueryBlanket"/>, followed by releasing the pointer.
        /// This sequence of calls is encapsulated in the helper function <see cref="CoQueryProxyBlanket"/>.
        /// In <paramref name="pProxy"/>, you pass an interface pointer.
        /// However, you cannot pass a pointer to an interface that does not use a proxy.
        /// Thus you cannot pass a pointer to an interface that has the local keyword in its interface definition
        /// since no proxy is created for such an interface.
        /// <see cref="IUnknown"/> is the exception to this rule.
        /// </remarks>
        [PreserveSig]
        HRESULT QueryBlanket([In]IUnknown pProxy, [In]in DWORD pAuthnSvc, [In]in DWORD pAuthzSvc,
            [MarshalAs(UnmanagedType.LPWStr)][Out]out string pServerPrincName, [In]in DWORD pAuthnLevel, [In]in DWORD pImpLevel,
            [In]ref IntPtr pAuthInfo, [In]in EOLE_AUTHENTICATION_CAPABILITIES pCapabilites);

        /// <summary>
        /// Sets the authentication information (the security blanket) that will be used to make calls on the specified proxy.
        /// This setting overrides the process default settings for the specified proxy.
        /// Calling this method changes the security values for all other users of the specified proxy.
        /// </summary>
        /// <param name="pProxy">
        /// A pointer to the proxy.
        /// </param>
        /// <param name="pAuthnSvc">
        /// The authentication service.
        /// This will be a single value taken from the list of authentication service constants.
        /// If no authentication is required, use <see cref="RPC_C_AUTHN_NONE"/>.
        /// If <see cref="RPC_C_AUTHN_DEFAULT"/> is specified, COM will pick an authentication service
        /// following its normal security blanket negotiation algorithm.
        /// </param>
        /// <param name="pAuthzSvc">
        /// The authorization service.
        /// This will be a single value taken from the list of authorization constants.
        /// If <see cref="RPC_C_AUTHZ_DEFAULT"/> is specified, COM will pick an authorization service
        /// following its normal security blanket negotiation algorithm.
        /// If NTLMSSP, Kerberos, or Schannel is used as the authentication service,
        /// <see cref="RPC_C_AUTHZ_NONE"/> should be used as the authorization service.
        /// </param>
        /// <param name="pServerPrincName">
        /// The server principal name.
        /// If <see cref="COLE_DEFAULT_PRINCIPAL"/> is specified, DCOM will pick a principal name using its security blanket negotiation algorithm.
        /// If Kerberos is used as the authentication service, this parameter must be the correct principal name of the server or the call will fail.
        /// If Schannel is used as the authentication service, this value must be one of the msstd or fullsic forms described in Principal Names,
        /// or <see langword="null"/> if you do not want mutual authentication.
        /// Generally, specifying <see langword="null"/> will not reset server principal name on the proxy, rather, the previous setting will be retained.
        /// You must exercise care when using <see langword="null"/> as <paramref name="pServerPrincName"/>
        /// when selecting a different authentication service for the proxy, because there is no guarantee
        /// that the previously set principal name would be valid for the newly selected authentication service.
        /// </param>
        /// <param name="dwAuthnLevel">
        /// The authentication level.
        /// This will be a single value taken from the list of authentication level constants.
        /// If <see cref="RPC_C_AUTHN_LEVEL_DEFAULT"/> is specified, COM will pick an authentication level
        /// following its normal security blanket negotiation algorithm.
        /// If this value is set to <see cref="RPC_C_AUTHN_LEVEL_NONE"/>, the authentication service must be <see cref="RPC_C_AUTHN_NONE"/>.
        /// Each authentication service may choose to use a higher security authentication level than the one specified.
        /// </param>
        /// <param name="dwImpLevel">
        /// The impersonation level.
        /// This will be a single value taken from the list of impersonation level constants.
        /// If <see cref="RPC_C_IMP_LEVEL_DEFAULT"/> is specified, COM will pick an impersonation level
        /// following its normal security blanket negotiation algorithm.
        /// If you are using NTLMSSP remotely, this value must be <see cref="RPC_C_IMP_LEVEL_IMPERSONATE"/> or <see cref="RPC_C_IMP_LEVEL_IDENTIFY"/>.
        /// When using NTLMSSP on the same computer, <see cref="RPC_C_IMP_LEVEL_DELEGATE"/> is also supported.
        /// For Kerberos, this value can be <see cref="RPC_C_IMP_LEVEL_IDENTIFY"/>, <see cref="RPC_C_IMP_LEVEL_IMPERSONATE"/>,
        /// or <see cref="RPC_C_IMP_LEVEL_DELEGATE"/>.
        /// For Schannel, this value must be <see cref="RPC_C_IMP_LEVEL_IMPERSONATE"/>.
        /// </param>
        /// <param name="pAuthInfo">
        /// An <see cref="RPC_AUTH_IDENTITY_HANDLE"/> value that indicates the identity of the client.
        /// This parameter is not used for calls on the same computer.
        /// If <paramref name="pAuthInfo"/> is <see cref="NULL"/>, COM uses the current proxy identity, which is either the process token,
        /// the impersonation token, or the authentication identity from the <see cref="CoInitializeSecurity"/> function.
        /// If the handle is not <see cref="NULL"/>, that identity is used.
        /// The format of the structure referred to by the handle depends on the provider of the authentication service.
        /// For NTLMSSP or Kerberos, the structure is a <see cref="SEC_WINNT_AUTH_IDENTITY"/> or <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure.
        /// If the client obtains the credentials set on the proxy by calling <see cref="CoQueryProxyBlanket"/>,
        /// it must ensure that the memory remains valid and unchanged until a different identity is set on the proxy
        /// or all proxies on the object are released.
        /// If this parameter is <see cref="NULL"/>, COM uses the current proxy identity (which is either the process token or the impersonation token).
        /// If the handle refers to a structure, that identity is used.
        /// For Schannel, this parameter must either be a pointer to a <see cref="CERT_CONTEXT"/> structure
        /// that contains the client's X.509 certificate, or <see cref="NULL"/> if the client wishes to make an anonymous connection to the server.
        /// If a certificate is specified, the caller must not free it as long as any proxy to the object exists in the current apartment.
        /// For Snego, this member is either <see cref="NULL"/>, points to a <see cref="SEC_WINNT_AUTH_IDENTITY"/> structure,
        /// or points to a <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure.
        /// If it is <see cref="NULL"/>, Snego will pick a list of authentication services based on those available on the client computer.
        /// If it points to a <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure,
        /// the structure's <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> member must point to a string containing
        /// a comma-separated list of authentication service names and the <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> member
        /// must give the number of bytes in the <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> string.
        /// If <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> is <see cref="NULL"/>, all calls using Snego will fail.
        /// If <see cref="COLE_DEFAULT_AUTHINFO"/> is specified, COM will pick the authentication information
        /// following its normal security blanket negotiation algorithm.
        /// <see cref="SetBlanket"/> will return an error if both <paramref name="pAuthInfo"/> is set
        /// and one of the cloaking flags is set in <paramref name="dwCapabilities"/>.
        /// </param>
        /// <param name="dwCapabilities">
        /// The capabilities of this proxy.
        /// Capability flags are defined in the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// The only flags that can be set through this method are <see cref="EOAC_MUTUAL_AUTH"/>, <see cref="EOAC_STATIC_CLOAKING"/>,
        /// <see cref="EOAC_DYNAMIC_CLOAKING"/>, <see cref="EOAC_ANY_AUTHORITY"/> (this flag is deprecated),
        /// <see cref="EOAC_MAKE_FULLSIC"/>, and <see cref="EOAC_DEFAULT"/>.
        /// Either <see cref="EOAC_STATIC_CLOAKING"/> or <see cref="EOAC_DYNAMIC_CLOAKING"/> can be set
        /// if <paramref name="pAuthInfo"/> is not set and Schannel is not the authentication service. (See Cloaking for more information.)
        /// If any capability flags other than those mentioned here are indicated, <see cref="SetBlanket"/> will return an error.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="E_INVALIDARG"/>: One or more arguments are not valid.
        /// </returns>
        /// <remarks>
        /// SetBlanket sets the authentication information that will be used to make calls on the specified interface proxy.
        /// The values specified here override the values chosen by automatic security.
        /// Calling this method changes the security values for all other users of the specified proxy.
        /// If you want the changes to apply only to a particular instance of a proxy,
        /// call <see cref="CopyProxy"/> to make a private copy of the proxy and then call <see cref="SetBlanket"/> on the copy.
        /// Whenever this method is called, DCOM will set the identity on the proxy, and future calls made using this proxy will use this identity.
        /// Calls in progress when <see cref="SetBlanket"/> is called will use the authentication information on the proxy at the time the call was started.
        /// If <paramref name="pAuthInfo"/> is <see cref="NULL"/>, the proxy identity defaults to the current process token
        /// (unless an authentication identity was specified on a call to <see cref="CoInitializeSecurity"/>).
        /// See Cloaking to learn how the cloaking flags affect the proxy when <paramref name="pAuthInfo"/> is <see cref="NULL"/>.
        /// By default, COM will choose the first available authentication service and authorization service available
        /// on both the client and server computers and the principal name that the server registered for that authentication service.
        /// Currently, COM will not try another authentication service if the first fails.
        /// When the default constant for <paramref name="dwImpLevel"/> is specified in <see cref="SetBlanket"/>,
        /// the parameter defaults to the value specified to <see cref="CoInitializeSecurity"/>.
        /// If <see cref="CoInitializeSecurity"/> is not called, it defaults to <see cref="RPC_C_IMP_LEVEL_IDENTIFY"/>.
        /// The initial value for <paramref name="dwAuthnLevel"/> on a proxy will be the higher of the value set
        /// on the client's call to <see cref="CoInitializeSecurity"/> and the server's call to <see cref="CoInitializeSecurity"/>.
        /// For any process that did not call <see cref="CoInitializeSecurity"/>, the default authentication level is <see cref="RPC_C_AUTHN_CONNECT"/>.
        /// The default authentication and impersonation level for processes that do not call <see cref="CoInitializeSecurity"/> can be set with DCOMCNFG.
        /// If <see cref="EOAC_DEFAULT"/> is specified for <paramref name="dwCapabilities"/>,
        /// the valid capabilities from <see cref="CoInitializeSecurity"/> will be used.
        /// If <see cref="CoInitializeSecurity"/> was not called, <see cref="EOAC_NONE"/> will be used for the capabilities flag.
        /// If <see cref="SetBlanket"/> is called simultaneously on two threads on the same proxy, only one set of changes will be applied.
        /// If <see cref="SetBlanket"/> and CRpcOptions::Set are called simultaneously on two threads on the same proxy,
        /// both changes may be applied or only one may be applied.
        /// Security information cannot be set on local interfaces such as the <see cref="IClientSecurity"/> interface.
        /// However, since that interface is only supported locally, there is no need for security.
        /// <see cref="IUnknown"/> and <see cref="IMultiQI"/> are special cases.
        /// The location implementation makes remote calls to support these interfaces.
        /// <see cref="SetBlanket"/> can be used for <see cref="IUnknown"/>.
        /// <see cref="IMultiQI"/> will use the security settings on <see cref="IUnknown"/>.
        /// To change one <see cref="SetBlanket"/> parameter without having to deal with the others,
        /// one can specify the default constants for the other parameters.
        /// Applications can change a parameter (such as the authentication level) and ignore the other parameters,
        /// including the authentication service, by setting all other parameters to the default constants.
        /// Note that it is important to set all unused parameters to the default constants because the default value is often not obvious.
        /// In particular, if you set the authentication service to the default,
        /// you should set the authentication information and principal name to the default.
        /// The reasons for this are twofold: First, the type of the authentication information depends on the authentication service DCOM chooses.
        /// Second, because DCOM needs to pass some complex authentication information for certain authentication services,
        /// if you set the authentication service to default and the authentication information to <see cref="NULL"/>,
        /// you might get a security setting that will not work.
        /// </remarks>
        [PreserveSig]
        HRESULT SetBlanket([In]IUnknown pProxy, [In]DWORD pAuthnSvc, [In]DWORD pAuthzSvc, [MarshalAs(UnmanagedType.LPWStr)][In]string pServerPrincName,
            [In]DWORD dwAuthnLevel, [In]DWORD dwImpLevel, [In]IntPtr pAuthInfo, [In]EOLE_AUTHENTICATION_CAPABILITIES dwCapabilities);

        /// <summary>
        /// <para>
        /// Makes a private copy of the proxy for the specified interface.
        /// </para>
        /// </summary>
        /// <param name="pProxy">
        /// A pointer to the interface whose proxy is to be copied.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="ppCopy">
        /// A pointer to the <see cref="IUnknown"/> interface pointer that receives the copy of the proxy.
        /// This parameter cannot be <see cref="NullRef{IUnknown}"/>.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="E_INVALIDARG"/>: One or more arguments are not valid.
        /// </returns>
        /// <remarks>
        /// <see cref="CopyProxy"/> is called by the client to make a private copy of the proxy for the specified interface.
        /// The proxy copy has default values for the authentication information.
        /// Its authentication information can be changed through a call to <see cref="SetBlanket"/>
        /// without affecting any other clients of the original proxy.
        /// The copy has one reference, and the caller of <see cref="CopyProxy"/> must ensure that the proxy copy gets freed.
        /// Local interfaces, such as <see cref="IUnknown"/> and <see cref="IClientSecurity"/>, cannot be copied.
        /// You cannot duplicate a proxy manager using <see cref="CopyProxy"/>.
        /// Copies of the same proxy have a special relationship with respect to QueryInterface.
        /// Given a proxy, a, of the IA interface of a remote object, suppose a copy of a is created, called b.
        /// In this case, calling QueryInterface from the b proxy for IID_IA will not retrieve the IA interface on b, but the one on a, the original proxy.
        /// Notice that anyone can query for a proxy and change security on it using <see cref="SetBlanket"/>.
        /// However, when you have made a copy of a proxy, no one can get the copy unless you give it to them.
        /// Only people who have the copy can set security on it.
        /// The helper function <see cref="CoCopyProxy"/> encapsulates a QueryInterface call for a pointer to <see cref="IClientSecurity"/>,
        /// a call to <see cref="CopyProxy"/> with the <see cref="IClientSecurity"/> pointer, and the release of the <see cref="IClientSecurity"/> pointer.
        /// </remarks>
        [PreserveSig]
        HRESULT CopyProxy([In]IUnknown pProxy, [Out]out IUnknown ppCopy);
    }
}
