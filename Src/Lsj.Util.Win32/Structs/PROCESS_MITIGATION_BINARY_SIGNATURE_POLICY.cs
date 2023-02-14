using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for the loading of images depending on the signatures for the image.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-process_mitigation_binary_signature_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// Set (0x1) to prevent the process from loading images that are not signed by Microsoft; otherwise leave unset (0x0).
        /// </summary>
        public DWORD MicrosoftSignedOnly
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// Set (0x1) to prevent the process from loading images that are not signed by the Windows Store; otherwise leave unset (0x0).
        /// </summary>
        public DWORD StoreSignedOnly
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// Set (0x1) to prevent the process from loading images that are not signed by Microsoft,
        /// the Windows Store and the Windows Hardware Quality Labs (WHQL); otherwise leave unset (0x0).
        /// </summary>
        public DWORD MitigationOptIn
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditMicrosoftSignedOnly
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditStoreSignedOnly
        {
            get => (Flags & 0x0000000c) >> 4;
            set => Flags |= ((value & 0x00000001) << 4);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 5;
            set => Flags |= (value << 5);
        }
    }
}
