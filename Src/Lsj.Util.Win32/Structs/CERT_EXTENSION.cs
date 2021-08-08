using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CERT_EXTENSION"/> structure contains the extension information for a certificate,
    /// Certificate Revocation List (CRL) or Certificate Trust List (CTL).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wincrypt/ns-wincrypt-cert_extension"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CERT_EXTENSION
    {
        /// <summary>
        /// Object identifier (OID) that specifies the structure of the extension data contained in the <see cref="Value"/> member.
        /// For specifics on extension OIDs and their related structures, see X.509 Certificate Extension Structures.
        /// </summary>
        public IntPtr pszObjId;

        /// <summary>
        /// If <see cref="TRUE"/>, any limitations specified by the extension in the Value member of this structure are imperative.
        /// If <see cref="FALSE"/>, limitations set by this extension can be ignored.
        /// </summary>
        public BOOL fCritical;

        /// <summary>
        /// A <see cref="CRYPT_OBJID_BLOB"/> structure that contains the encoded extension data.
        /// The <see cref="CRYPT_OBJID_BLOB.cbData"/> member of Value indicates the length in bytes of the <see cref="CRYPT_OBJID_BLOB.pbData"/> member.
        /// The <see cref="CRYPT_OBJID_BLOB.pbData"/> member byte string is the encoded extension.
        /// </summary>
        public CRYPT_OBJID_BLOB Value;
    }
}
