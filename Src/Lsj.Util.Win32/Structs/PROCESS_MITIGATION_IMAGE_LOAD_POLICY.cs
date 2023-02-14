using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for the loading of images from a remote device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-process_mitigation_image_load_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_IMAGE_LOAD_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// Set (0x1) to prevent the process from loading images from a remote device, such as a UNC share; otherwise leave unset (0x0).
        /// </summary>
        public DWORD NoRemoteImages
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// Set (0x1) to prevent the process from loading images that have a Low mandatory label, as written by low IL; otherwise leave unset (0x0).
        /// </summary>
        public DWORD NoLowMandatoryLabelImages
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// Set (0x1) to search for images to load in the System32 subfolder of the folder in which Windows is installed first,
        /// then in the application directory in the standard DLL search order; otherwise leave unset (0x0).
        /// </summary>
        public DWORD PreferSystem32Images
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditNoRemoteImages
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditNoLowMandatoryLabelImages
        {
            get => (Flags & 0x0000000c) >> 4;
            set => Flags |= ((value & 0x00000001) << 4);
        }

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 5;
            set => Flags |= (value << 5);
        }
    }
}
