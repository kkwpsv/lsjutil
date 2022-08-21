using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for Address Space Randomization Layout (ASLR).
    /// The <see cref="GetProcessMitigationPolicy"/> and <see cref="SetProcessMitigationPolicy"/> functions use this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-process_mitigation_aslr_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_ASLR_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// 
        /// </summary>
        public DWORD EnableBottomUpRandomization
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD EnableForceRelocateImages
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD EnableHighEntropy
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD DisallowStrippedImages
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 4;
            set => Flags |= (value << 4);
        }
    }
}
