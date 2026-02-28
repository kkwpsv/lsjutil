using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="AllocateAndInitializeSid"/> function allocates and initializes a security identifier (SID) with up to eight subauthorities.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-allocateandinitializesid"/>
        /// </para>
        /// </summary>
        /// <param name="pIdentifierAuthority">
        /// A pointer to a <see cref="SID_IDENTIFIER_AUTHORITY"/> structure.
        /// This structure provides the top-level identifier authority value to set in the SID.
        /// </param>
        /// <param name="nSubAuthorityCount">
        /// <para>
        /// Specifies the number of subauthorities to place in the SID.
        /// This parameter also identifies how many of the subauthority parameters have meaningful values.
        /// This parameter must contain a value from 1 to 8.
        /// </para>
        /// <para>
        /// For example, a value of 3 indicates that the subauthority values specified by the <paramref name="nSubAuthority0"/>,
        /// <paramref name="nSubAuthority1"/>, and <paramref name="nSubAuthority2"/> parameters
        /// have meaningful values and to ignore the remainder.
        /// </para>
        /// </param>
        /// <param name="nSubAuthority0">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority1">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority2">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority3">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority4">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority5">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority6">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="nSubAuthority7">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="pSid">
        /// A pointer to a variable that receives the pointer to the allocated and initialized <see cref="SID"/> structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A SID allocated with the <see cref="AllocateAndInitializeSid"/> function must be freed
        /// by using the <see cref="FreeSid"/> function.
        /// </para>
        /// <para>
        /// This function creates a SID with a 32-bit RID value.
        /// For applications that require longer RID values, use <see cref="CreateWellKnownSid"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllocateAndInitializeSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AllocateAndInitializeSid([In] in SID_IDENTIFIER_AUTHORITY pIdentifierAuthority, [In] BYTE nSubAuthorityCount,
            [In] DWORD nSubAuthority0, [In] DWORD nSubAuthority1, [In] DWORD nSubAuthority2, [In] DWORD nSubAuthority3,
            [In] DWORD nSubAuthority4, [In] DWORD nSubAuthority5, [In] DWORD nSubAuthority6, [In] DWORD nSubAuthority7,
            [Out] out PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="CopySid"/> function copies a security identifier (SID) to a buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-copysid"/>
        /// </para>
        /// </summary>
        /// <param name="nDestinationSidLength">
        /// Specifies the length, in bytes, of the buffer receiving the copy of the SID.
        /// </param>
        /// <param name="pDestinationSid">
        /// A pointer to a buffer that receives a copy of the source SID structure.
        /// </param>
        /// <param name="pSourceSid">
        /// A pointer to a <see cref="SID"/> structure that the function copies to the buffer
        /// pointed to by the <paramref name="pDestinationSid"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application can use the <see cref="CopySid"/> function to make a copy of a SID in an access token
        /// (for example, in a <see cref="TOKEN_GROUPS"/> structure) to use in an access control entry (<see cref="ACE"/>).
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopySid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CopySid([In] DWORD nDestinationSidLength, [In] PSID pDestinationSid, [In] PSID pSourceSid);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertSidToStringSid"/> function converts a security identifier (SID)
        /// to a string format suitable for display, storage, or transmission.
        /// </para>
        /// <para>
        /// To convert the string-format SID back to a valid, functional SID, call the <see cref="ConvertStringSidToSid"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sddl/nf-sddl-convertsidtostringsidw"/>
        /// </para>
        /// </summary>
        /// <param name="Sid">
        /// A pointer to the <see cref="SID"/> structure to be converted.
        /// </param>
        /// <param name="StringSid">
        /// A pointer to a variable that receives a pointer to a null-terminated SID string.
        /// To free the returned buffer, call the <see cref="LocalFree"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The <see cref="GetLastError"/> function may return one of the following error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The SID is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One of the parameters contains a value that is not valid.
        /// This is most often a pointer that is not valid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="ConvertSidToStringSid"/> function uses the standard <c>S-R-I-S-S…</c> format for SID strings.
        /// For more information about SID string notation, see SID Components.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertSidToStringSidW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertSidToStringSid([In] PSID Sid, [Out] out LPWSTR StringSid);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertStringSidToSid"/> function converts a string-format security identifier (SID) into a valid, functional SID.
        /// You can use this function to retrieve a SID that the <see cref="ConvertSidToStringSid"/> function converted to string format.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sddl/nf-sddl-convertstringsidtosidw"/>
        /// </para>
        /// </summary>
        /// <param name="StringSid">
        /// <para>
        /// A pointer to a null-terminated string containing the string-format SID to convert.
        /// </para>
        /// <para>
        /// The SID string can use either the standard <c>S-R-I-S-S…</c> format for SID strings,
        /// or the SID string constant format, such as "BA" for built-in administrators.
        /// For more information about SID string notation, see SID Components.
        /// </para>
        /// </param>
        /// <param name="Sid">
        /// A pointer to a variable that receives a pointer to the converted SID.
        /// To free the returned buffer, call the <see cref="LocalFree"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The <see cref="GetLastError"/> function may return one of the following error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// Invalid parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// Invalid SID.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertStringSidToSidW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertStringSidToSid([In] LPCWSTR StringSid, [Out] PSID Sid);

        /// <summary>
        /// <para>
        /// The <see cref="CreateWellKnownSid"/> function creates a SID for predefined aliases.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-createwellknownsid"/>
        /// </para>
        /// </summary>
        /// <param name="WellKnownSidType">
        /// Member of the <see cref="WELL_KNOWN_SID_TYPE"/> enumeration that specifies what the SID will identify.
        /// </param>
        /// <param name="DomainSid">
        /// A pointer to a SID that identifies the domain to use when creating the SID.
        /// Pass <see cref="NULL"/> to use the local computer.
        /// </param>
        /// <param name="pSid">
        /// A pointer to memory where <see cref="CreateWellKnownSid"/> will store the new SID.
        /// </param>
        /// <param name="cbSid">
        /// A pointer to a <see cref="DWORD"/> that contains the number of bytes available at <paramref name="pSid"/>.
        /// The <see cref="CreateWellKnownSid"/> function stores the number of bytes actually used at this location.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// For extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWellKnownSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateWellKnownSid([In] WELL_KNOWN_SID_TYPE WellKnownSidType, [In] PSID DomainSid,
            [In] PSID pSid, [Out] out DWORD cbSid);

        /// <summary>
        /// <para>
        /// The <see cref="EqualPrefixSid"/> function tests two security-identifier (SID) prefix values for equality.
        /// A SID prefix is the entire SID except for the last subauthority value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-equalprefixsid"/>
        /// </para>
        /// </summary>
        /// <param name="pSid1">
        /// A pointer to the first <see cref="SID"/> structure to compare.
        /// This structure is assumed to be valid.
        /// </param>
        /// <param name="pSid2">
        /// A pointer to the second <see cref="SID"/> structure to compare.
        /// This structure is assumed to be valid.
        /// </param>
        /// <returns>
        /// <para>
        /// If the SID prefixes are equal, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the SID prefixes are not equal, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="EqualPrefixSid"/> function enables a server application in one domain
        /// to verify an attempt by a user to log on to another domain.
        /// For example, if a user attempts to log on to RemoteDomain from a workstation in LocalDomain,
        /// the server for LocalDomain can request the SIDs for the user and the user's groups from RemoteDomain.
        /// The domain controller for RemoteDomain responds with the relevant SIDs.
        /// </para>
        /// <para>
        /// All SIDs for a specified domain have the same prefix.
        /// When the server receives the user's SIDs, the server can call the <see cref="EqualPrefixSid"/> function for each SID,
        /// comparing the user or group SID against the SID for RemoteDomain.
        /// If any of the SID prefixes are not equal, the server refuses the logon attempt.
        /// </para>
        /// <para>
        /// It is advisable to modify the SID for a domain before comparing it with a group or user SID.
        /// If the SID for RemoteDomain is S-1–1234–8, each group or user SID for that domain has S-1–1234–8 as its prefix.
        /// To compare the SIDs by using the <see cref="EqualPrefixSid"/> function,
        /// an application copies the domain SID and adds any subauthority (<see cref="RID"/>) value to the copy,
        /// thereby creating a SID in the form S-1–1234–8–0.
        /// The application then uses the modified domain SID as a template against which the group and user SIDs are compared.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EqualPrefixSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EqualPrefixSid([In] PSID pSid1, [In] PSID pSid2);

        /// <summary>
        /// <para>
        /// The <see cref="EqualSid"/> function tests two security identifier (SID) values for equality.
        /// Two SIDs must match exactly to be considered equal.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-equalsid"/>
        /// </para>
        /// </summary>
        /// <param name="pSid1">
        /// A pointer to the first <see cref="SID"/> structure to compare.
        /// This structure is assumed to be valid.
        /// </param>
        /// <param name="pSid2">
        /// A pointer to the second <see cref="SID"/> structure to compare.
        /// This structure is assumed to be valid.
        /// </param>
        /// <returns>
        /// <para>
        /// If the <see cref="SID"/> structures are equal, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the <see cref="SID"/> structures are not equal, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If either <see cref="SID"/> structure is not valid, the return value is undefined.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EqualSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EqualSid([In] PSID pSid1, [In] PSID pSid2);

        /// <summary>
        /// <para>
        /// The <see cref="FreeSid"/> function frees a security identifier (SID)
        /// previously allocated by using the <see cref="AllocateAndInitializeSid"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-freesid"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// A pointer to the <see cref="SID"/> structure to free.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns a pointer to the <see cref="SID"/> structure
        /// represented by the <paramref name="pSid"/> parameter.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeSid", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID FreeSid([In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="GetLengthSid"/> function returns the length, in bytes, of a valid security identifier (SID).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getlengthsid"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// A pointer to the <see cref="SID"/> structure whose length is returned.
        /// The structure is assumed to be valid.
        /// </param>
        /// <returns>
        /// <para>
        /// If the <see cref="SID"/> structure is valid, the return value is the length, in bytes, of the <see cref="SID"/> structure.
        /// </para>
        /// <para>
        /// If the <see cref="SID"/> structure is not valid, the return value is undefined.
        /// Before calling <see cref="GetLengthSid"/>, pass the SID to the <see cref="IsValidSid"/> function to verify that the SID is valid.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLengthSid", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetLengthSid([In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="GetSidIdentifierAuthority"/> function returns a pointer
        /// to the <see cref="SID_IDENTIFIER_AUTHORITY"/> structure in a specified security identifier (SID).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getsididentifierauthority"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// <para>
        /// A pointer to the <see cref="SID"/> structure for which a pointer
        /// to the <see cref="SID_IDENTIFIER_AUTHORITY"/> structure is returned.
        /// </para>
        /// <para>
        /// This function does not handle <see cref="SID"/> structures that are not valid.
        /// Call the <see cref="IsValidSid"/> function to verify
        /// that the <see cref="SID"/> structure is valid before you call this function.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a pointer
        /// to the <see cref="SID_IDENTIFIER_AUTHORITY"/> structure for the specified <see cref="SID"/> structure.
        /// </para>
        /// <para>
        /// If the function fails, the return value is undefined.
        /// The function fails if the <see cref="SID"/> structure pointed to by the <paramref name="pSid"/> parameter is not valid.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function uses a 32-bit RID value.
        /// For applications that require a larger RID value, use <see cref="CreateWellKnownSid"/> and related functions.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSidIdentifierAuthority", ExactSpelling = true)]
        public static extern P<SID_IDENTIFIER_AUTHORITY> GetSidIdentifierAuthority([In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="GetSidLengthRequired"/> function returns the length, in bytes,
        /// of the buffer required to store a SID with a specified number of subauthorities.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getsidlengthrequired"/>
        /// </para>
        /// </summary>
        /// <param name="nSubAuthorityCount">
        /// Specifies the number of subauthorities to be stored in the SID structure.
        /// </param>
        /// <returns>
        /// The return value is the length, in bytes, of the buffer required to store the <see cref="SID"/> structure.
        /// This function cannot fail.
        /// </returns>
        /// <remarks>
        /// The <see cref="SID"/> structure specified in <paramref name="nSubAuthorityCount"/> uses a 32-bit RID value.
        /// For applications that require longer RID values, use <see cref="CreateWellKnownSid"/> and related functions.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSidLengthRequired", ExactSpelling = true)]
        public static extern DWORD GetSidLengthRequired([In] UCHAR nSubAuthorityCount);

        /// <summary>
        /// <para>
        /// The <see cref="GetSidSubAuthority"/> function returns a pointer to a specified subauthority in a security identifier (SID).
        /// The subauthority value is a relative identifier (RID).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getsidsubauthority"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// <para>
        /// A pointer to the <see cref="SID"/> structure from which a pointer to a subauthority is to be returned.
        /// </para>
        /// <para>
        /// This function does not handle <see cref="SID"/> structures that are not valid.
        /// Call the <see cref="IsValidSid"/> function to verify
        /// that the <see cref="SID"/> structure is valid before you call this function.
        /// </para>
        /// </param>
        /// <param name="nSubAuthority">
        /// Specifies an index value identifying the subauthority array element whose address the function will return.
        /// The function performs no validation tests on this value.
        /// An application can call the <see cref="GetSidSubAuthorityCount"/> function to discover the range of acceptable values.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a pointer to the specified <see cref="SID"/> subauthority.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is undefined.
        /// The function fails if the specified <see cref="SID"/> structure is not valid
        /// or if the index value specified by the <paramref name="nSubAuthority"/> parameter is out of bounds.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="SID"/> structure specified in <paramref name="pSid"/> uses a 32-bit RID value.
        /// For applications that require longer RID values, use <see cref="CreateWellKnownSid"/> and related functions.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSidSubAuthority", ExactSpelling = true, SetLastError = true)]
        public static extern P<DWORD> GetSidSubAuthority([In] PSID pSid, DWORD nSubAuthority);

        /// <summary>
        /// <para>
        /// The <see cref="GetSidSubAuthorityCount"/> function returns a pointer
        /// to the member in a security identifier (SID) structure that contains the subauthority count.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getsidsubauthoritycount"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// <para>
        /// A pointer to the <see cref="SID"/> structure from which a pointer to the subauthority count is returned.
        /// </para>
        /// <para>
        /// This function does not handle <see cref="SID"/> structures that are not valid.
        /// Call the <see cref="IsValidSid"/> function to verify that the <see cref="SID"/> structure is valid before you call this function.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a pointer to the subauthority count for the specified <see cref="SID"/> structure.
        /// </para>
        /// <para>
        /// If the function fails, the return value is undefined.
        /// The function fails if the specified <see cref="SID"/> structure is not valid.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The SID structure specified in <paramref name="pSid"/> uses a 32-bit value.
        /// For applications that require longer RID values, use <see cref="CreateWellKnownSid"/> and related functions.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSidSubAuthorityCount", ExactSpelling = true, SetLastError = true)]
        public static extern P<UCHAR> GetSidSubAuthorityCount([In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="InitializeSid"/> function initializes a security identifier (SID).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-initializesid"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// A pointer to a <see cref="SID"/> structure to be initialized.
        /// </param>
        /// <param name="pIdentifierAuthority">
        /// A pointer to a <see cref="SID_IDENTIFIER_AUTHORITY"/> structure to set in the <see cref="SID"/> structure.
        /// </param>
        /// <param name="nSubAuthorityCount">
        /// Specifies the number of subauthorities to set in the <see cref="SID"/>.
        /// Values of the subauthority must be set separately, as described in the following Remarks section.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Although the <see cref="InitializeSid"/> function sets the number of subauthorities for the SID,
        /// it does not set the subauthority values.
        /// This must be done separately, using functions such as <see cref="GetSidSubAuthority"/>.
        /// </para>
        /// <para>
        /// An application can use the <see cref="AllocateAndInitializeSid"/> function
        /// to initialize a SID and set its subauthority values.
        /// </para>
        /// <para>
        /// This function uses a 32-bit RID value.
        /// For applications that require a larger RID value, use <see cref="CreateWellKnownSid"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeSid([In] PSID pSid,
#if NETFRAMEWORK
            [In] nint pIdentifierAuthority,
#else
            [In] P<SID_IDENTIFIER_AUTHORITY> pIdentifierAuthority,
#endif
            [In] BYTE nSubAuthorityCount);

        /// <summary>
        /// <para>
        /// The <see cref="IsValidSid"/> function validates a security identifier (SID) by verifying
        /// that the revision number is within a known range, and that the number of subauthorities is less than the maximum.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-isvalidsid"/>
        /// </para>
        /// </summary>
        /// <param name="pSid">
        /// A pointer to the <see cref="SID"/> structure to validate.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the <see cref="SID"/> structure is valid, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the <see cref="SID"/> structure is not valid, the return value is zero.
        /// There is no extended error information for this function; do not call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If <paramref name="pSid"/> is <see cref="NULL"/>, the application will fail with an access violation.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidSid([In] PSID pSid);
    }
}
