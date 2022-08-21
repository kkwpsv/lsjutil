using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for the loading of non-system fonts.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-process_mitigation_font_disable_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_FONT_DISABLE_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// Set (0x1) to prevent the process from loading non-system fonts; otherwise leave unset (0x0).
        /// </summary>
        public DWORD DisableNonSystemFonts
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// Set (0x1) to indicate that an Event Tracing for Windows (ETW) event should be logged
        /// when the process attempts to load a non-system font;
        /// leave unset (0x0) to indicate that an ETW event should not be logged.
        /// </summary>
        public DWORD AuditNonSystemFontLoading
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 2;
            set => Flags |= (value << 2);
        }
    }
}
