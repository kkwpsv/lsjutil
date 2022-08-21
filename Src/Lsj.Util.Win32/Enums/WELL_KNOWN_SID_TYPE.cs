using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.LogonTypes;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="WELL_KNOWN_SID_TYPE"/> enumeration is a list of commonly used security identifiers (SIDs).
    /// Programs can pass these values to the <see cref="CreateWellKnownSid"/> function to create a SID from this list.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ne-winnt-well_known_sid_type"/>
    /// </para>
    /// </summary>
    public enum WELL_KNOWN_SID_TYPE
    {
        /// <summary>
        /// Indicates a null SID.
        /// </summary>
        WinNullSid,

        /// <summary>
        /// Indicates a SID that matches everyone.
        /// </summary>
        WinWorldSid,

        /// <summary>
        /// Indicates a local SID.
        /// </summary>
        WinLocalSid,

        /// <summary>
        /// Indicates a SID that matches the owner or creator of an object.
        /// </summary>
        WinCreatorOwnerSid,

        /// <summary>
        /// 	Indicates a SID that matches the creator group of an object.
        /// </summary>
        WinCreatorGroupSid,

        /// <summary>
        /// Indicates a creator owner server SID.
        /// </summary>
        WinCreatorOwnerServerSid,

        /// <summary>
        /// Indicates a creator group server SID.
        /// </summary>
        WinCreatorGroupServerSid,

        /// <summary>
        /// Indicates a SID for the Windows NT authority account.
        /// </summary>
        WinNtAuthoritySid,

        /// <summary>
        /// Indicates a SID for a dial-up account.
        /// </summary>
        WinDialupSid,

        /// <summary>
        /// Indicates a SID for a network account.
        /// This SID is added to the process of a token when it logs on across a network.
        /// The corresponding logon type is <see cref="LOGON32_LOGON_NETWORK"/>.
        /// </summary>
        WinNetworkSid,

        /// <summary>
        /// Indicates a SID for a batch process.
        /// This SID is added to the process of a token when it logs on as a batch job.
        /// The corresponding logon type is <see cref="LOGON32_LOGON_BATCH"/>.
        /// </summary>
        WinBatchSid,

        /// <summary>
        /// Indicates a SID for an interactive account.
        /// This SID is added to the process of a token when it logs on interactively.
        /// The corresponding logon type is <see cref="LOGON32_LOGON_INTERACTIVE"/>.
        /// </summary>
        WinInteractiveSid,

        /// <summary>
        /// Indicates a SID for a service.
        /// This SID is added to the process of a token when it logs on as a service.
        /// The corresponding logon type is <see cref="LOGON32_LOGON_SERVICE"/>.
        /// </summary>
        WinServiceSid,

        /// <summary>
        /// Indicates a SID for the anonymous account.
        /// </summary>
        WinAnonymousSid,

        /// <summary>
        /// Indicates a proxy SID.
        /// </summary>
        WinProxySid,

        /// <summary>
        /// Indicates a SID for an enterprise controller.
        /// </summary>
        WinEnterpriseControllersSid,

        /// <summary>
        /// Indicates a SID for self.
        /// </summary>
        WinSelfSid,

        /// <summary>
        /// Indicates a SID that matches any authenticated user.
        /// </summary>
        WinAuthenticatedUserSid,

        /// <summary>
        /// Indicates a SID for restricted code.
        /// </summary>
        WinRestrictedCodeSid,

        /// <summary>
        /// Indicates a SID that matches a terminal server account.
        /// </summary>
        WinTerminalServerSid,

        /// <summary>
        /// Indicates a SID that matches remote logons.
        /// </summary>
        WinRemoteLogonIdSid,

        /// <summary>
        /// Indicates a SID that matches logon IDs.
        /// </summary>
        WinLogonIdsSid,

        /// <summary>
        /// Indicates a SID that matches the local system.
        /// </summary>
        WinLocalSystemSid,

        /// <summary>
        /// Indicates a SID that matches a local service.
        /// </summary>
        WinLocalServiceSid,

        /// <summary>
        /// Indicates a SID that matches a network service.
        /// </summary>
        WinNetworkServiceSid,

        /// <summary>
        /// Indicates a SID that matches the domain account.
        /// </summary>
        WinBuiltinDomainSid,

        /// <summary>
        /// Indicates a SID that matches the administrator group.
        /// </summary>
        WinBuiltinAdministratorsSid,

        /// <summary>
        /// Indicates a SID that matches built-in user accounts.
        /// </summary>
        WinBuiltinUsersSid,

        /// <summary>
        /// Indicates a SID that matches the guest account.
        /// </summary>
        WinBuiltinGuestsSid,

        /// <summary>
        /// Indicates a SID that matches the power users group.
        /// </summary>
        WinBuiltinPowerUsersSid,

        /// <summary>
        /// Indicates a SID that matches the account operators account.
        /// </summary>
        WinBuiltinAccountOperatorsSid,

        /// <summary>
        /// Indicates a SID that matches the system operators group.
        /// </summary>
        WinBuiltinSystemOperatorsSid,

        /// <summary>
        /// Indicates a SID that matches the print operators group.
        /// </summary>
        WinBuiltinPrintOperatorsSid,

        /// <summary>
        /// Indicates a SID that matches the backup operators group.
        /// </summary>
        WinBuiltinBackupOperatorsSid,

        /// <summary>
        /// 	Indicates a SID that matches the replicator account.
        /// </summary>
        WinBuiltinReplicatorSid,

        /// <summary>
        /// Indicates a SID that matches pre-Windows 2000 compatible accounts.
        /// </summary>
        WinBuiltinPreWindows2000CompatibleAccessSid,

        /// <summary>
        /// Indicates a SID that matches remote desktop users.
        /// </summary>
        WinBuiltinRemoteDesktopUsersSid,

        /// <summary>
        /// Indicates a SID that matches the network operators group.
        /// </summary>
        WinBuiltinNetworkConfigurationOperatorsSid,

        /// <summary>
        /// Indicates a SID that matches the account administrator's account.
        /// </summary>
        WinAccountAdministratorSid,

        /// <summary>
        /// Indicates a SID that matches the account guest group.
        /// </summary>
        WinAccountGuestSid,

        /// <summary>
        /// Indicates a SID that matches account Kerberos target group.
        /// </summary>
        WinAccountKrbtgtSid,

        /// <summary>
        /// Indicates a SID that matches the account domain administrator group.
        /// </summary>
        WinAccountDomainAdminsSid,

        /// <summary>
        /// Indicates a SID that matches the account domain users group.
        /// </summary>
        WinAccountDomainUsersSid,

        /// <summary>
        /// Indicates a SID that matches the account domain guests group.
        /// </summary>
        WinAccountDomainGuestsSid,

        /// <summary>
        /// Indicates a SID that matches the account computer group.
        /// </summary>
        WinAccountComputersSid,

        /// <summary>
        /// Indicates a SID that matches the account controller group.
        /// </summary>
        WinAccountControllersSid,

        /// <summary>
        /// Indicates a SID that matches the certificate administrators group.
        /// </summary>
        WinAccountCertAdminsSid,

        /// <summary>
        /// Indicates a SID that matches the schema administrators group.
        /// </summary>
        WinAccountSchemaAdminsSid,

        /// <summary>
        /// Indicates a SID that matches the enterprise administrators group.
        /// </summary>
        WinAccountEnterpriseAdminsSid,

        /// <summary>
        /// Indicates a SID that matches the policy administrators group.
        /// </summary>
        WinAccountPolicyAdminsSid,

        /// <summary>
        /// Indicates a SID that matches the RAS and IAS server account.
        /// </summary>
        WinAccountRasAndIasServersSid,

        /// <summary>
        /// Indicates a SID present when the Microsoft NTLM authentication package authenticated the client.
        /// </summary>
        WinNTLMAuthenticationSid,

        /// <summary>
        /// Indicates a SID present when the Microsoft Digest authentication package authenticated the client.
        /// </summary>
        WinDigestAuthenticationSid,

        /// <summary>
        /// Indicates a SID present when the Secure Channel (SSL/TLS) authentication package authenticated the client.
        /// </summary>
        WinSChannelAuthenticationSid,

        /// <summary>
        /// Indicates a SID present when the user authenticated from within the forest or across a trust
        /// that does not have the selective authentication option enabled.
        /// If this SID is present, then <see cref="WinOtherOrganizationSid"/> cannot be present.
        /// </summary>
        WinThisOrganizationSid,

        /// <summary>
        /// Indicates a SID present when the user authenticated across a forest with the selective authentication option enabled.
        /// If this SID is present, then <see cref="WinThisOrganizationSid"/> cannot be present.
        /// </summary>
        WinOtherOrganizationSid,

        /// <summary>
        /// Indicates a SID that allows a user to create incoming forest trusts.
        /// It is added to the token of users who are a member of the Incoming Forest Trust Builders built-in group in the root domain of the forest.
        /// </summary>
        WinBuiltinIncomingForestTrustBuildersSid,

        /// <summary>
        /// Indicates a SID that matches the performance monitor user group.
        /// </summary>
        WinBuiltinPerfMonitoringUsersSid,

        /// <summary>
        /// Indicates a SID that matches the performance log user group.
        /// </summary>
        WinBuiltinPerfLoggingUsersSid,

        /// <summary>
        /// Indicates a SID that matches the Windows Authorization Access group.
        /// </summary>
        WinBuiltinAuthorizationAccessSid,

        /// <summary>
        /// Indicates a SID is present in a server that can issue terminal server licenses.
        /// </summary>
        WinBuiltinTerminalServerLicenseServersSid,

        /// <summary>
        /// Indicates a SID that matches the distributed COM user group.
        /// </summary>
        WinBuiltinDCOMUsersSid,

        /// <summary>
        /// Indicates a SID that matches the Internet built-in user group.
        /// </summary>
        WinBuiltinIUsersSid,

        /// <summary>
        /// Indicates a SID that matches the Internet user group.
        /// </summary>
        WinIUserSid,

        /// <summary>
        /// Indicates a SID that allows a user to use cryptographic operations.
        /// It is added to the token of users who are a member of the CryptoOperators built-in group.
        /// </summary>
        WinBuiltinCryptoOperatorsSid,

        /// <summary>
        /// Indicates a SID that matches an untrusted label.
        /// </summary>
        WinUntrustedLabelSid,

        /// <summary>
        /// Indicates a SID that matches an low level of trust label.
        /// </summary>
        WinLowLabelSid,

        /// <summary>
        /// Indicates a SID that matches an medium level of trust label.
        /// </summary>
        WinMediumLabelSid,

        /// <summary>
        /// Indicates a SID that matches a high level of trust label.
        /// </summary>
        WinHighLabelSid,

        /// <summary>
        /// Indicates a SID that matches a system label.
        /// </summary>
        WinSystemLabelSid,

        /// <summary>
        /// Indicates a SID that matches a write restricted code group.
        /// </summary>
        WinWriteRestrictedCodeSid,

        /// <summary>
        /// Indicates a SID that matches a creator and owner rights group.
        /// </summary>
        WinCreatorOwnerRightsSid,

        /// <summary>
        /// Indicates a SID that matches a cacheable principals group.
        /// </summary>
        WinCacheablePrincipalsGroupSid,

        /// <summary>
        /// Indicates a SID that matches a non-cacheable principals group.
        /// </summary>
        WinNonCacheablePrincipalsGroupSid,

        /// <summary>
        /// Indicates a SID that matches an enterprise wide read-only controllers group.
        /// </summary>
        WinEnterpriseReadonlyControllersSid,

        /// <summary>
        /// Indicates a SID that matches an account read-only controllers group.
        /// </summary>
        WinAccountReadonlyControllersSid,

        /// <summary>
        /// Indicates a SID that matches an event log readers group.
        /// </summary>
        WinBuiltinEventLogReadersGroup,

        /// <summary>
        /// Indicates a SID that matches a read-only enterprise domain controller.
        /// </summary>
        WinNewEnterpriseReadonlyControllersSid,

        /// <summary>
        /// Indicates a SID that matches the built-in DCOM certification services access group.
        /// </summary>
        WinBuiltinCertSvcDComAccessGroup,

        /// <summary>
        /// Indicates a SID that matches the medium plus integrity label.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinMediumPlusLabelSid,

        /// <summary>
        /// Indicates a SID that matches a local logon group.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinLocalLogonSid,

        /// <summary>
        /// Indicates a SID that matches a console logon group.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinConsoleLogonSid,

        /// <summary>
        /// Indicates a SID that matches a certificate for the given organization.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinThisOrganizationCertificateSid,

        /// <summary>
        /// Indicates a SID that matches the application package authority.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinApplicationPackageAuthoritySid,

        /// <summary>
        /// Indicates a SID that applies to all app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinBuiltinAnyPackageSid,

        /// <summary>
        /// Indicates a SID of Internet client capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityInternetClientSid,

        /// <summary>
        /// Indicates a SID of Internet client and server capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityInternetClientServerSid,

        /// <summary>
        /// Indicates a SID of private network client and server capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityPrivateNetworkClientServerSid,

        /// <summary>
        /// Indicates a SID for pictures library capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityPicturesLibrarySid,

        /// <summary>
        /// Indicates a SID for videos library capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityVideosLibrarySid,

        /// <summary>
        /// Indicates a SID for music library capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityMusicLibrarySid,

        /// <summary>
        /// Indicates a SID for documents library capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityDocumentsLibrarySid,

        /// <summary>
        /// Indicates a SID for shared user certificates capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilitySharedUserCertificatesSid,

        /// <summary>
        /// Indicates a SID for Windows credentials capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityEnterpriseAuthenticationSid,

        /// <summary>
        /// Indicates a SID for removable storage capability for app containers.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
        /// </summary>
        WinCapabilityRemovableStorageSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinRDSRemoteAccessServersSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinRDSEndpointServersSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinRDSManagementServersSid,

        /// <summary>
        /// 
        /// </summary>
        WinUserModeDriversSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinHyperVAdminsSid,

        /// <summary>
        /// 
        /// </summary>
        WinAccountCloneableControllersSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinAccessControlAssistanceOperatorsSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinRemoteManagementUsersSid,

        /// <summary>
        /// 
        /// </summary>
        WinAuthenticationAuthorityAssertedSid,

        /// <summary>
        /// 
        /// </summary>
        WinAuthenticationServiceAssertedSid,

        /// <summary>
        /// 
        /// </summary>
        WinLocalAccountSid,

        /// <summary>
        /// 
        /// </summary>
        WinLocalAccountAndAdministratorSid,

        /// <summary>
        /// 
        /// </summary>
        WinAccountProtectedUsersSid,

        /// <summary>
        /// 
        /// </summary>
        WinCapabilityAppointmentsSid,

        /// <summary>
        /// 
        /// </summary>
        WinCapabilityContactsSid,

        /// <summary>
        /// 
        /// </summary>
        WinAccountDefaultSystemManagedSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinDefaultSystemManagedGroupSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinStorageReplicaAdminsSid,

        /// <summary>
        /// 
        /// </summary>
        WinAccountKeyAdminsSid,

        /// <summary>
        /// 
        /// </summary>
        WinAccountEnterpriseKeyAdminsSid,

        /// <summary>
        /// 
        /// </summary>
        WinAuthenticationKeyTrustSid,

        /// <summary>
        /// 
        /// </summary>
        WinAuthenticationKeyPropertyMFASid,

        /// <summary>
        /// 
        /// </summary>
        WinAuthenticationKeyPropertyAttestationSid,

        /// <summary>
        /// 
        /// </summary>
        WinAuthenticationFreshKeyAuthSid,

        /// <summary>
        /// 
        /// </summary>
        WinBuiltinDeviceOwnersSid
    }
}
