using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// TP_CALLBACK_ENVIRON
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TP_CALLBACK_ENVIRON
    {
        /// <summary>
        /// Version
        /// </summary>
        public TP_VERSION Version;

        /// <summary>
        /// Pool
        /// </summary>
        public PTP_POOL Pool;

        /// <summary>
        /// CleanupGroup
        /// </summary>
        public PTP_CLEANUP_GROUP CleanupGroup;

        /// <summary>
        /// CleanupGroupCancelCallback
        /// </summary>
        public PTP_CLEANUP_GROUP_CANCEL_CALLBACK CleanupGroupCancelCallback;

        /// <summary>
        /// RaceDll
        /// </summary>
        public PVOID RaceDll;

        /// <summary>
        /// ActivationContext
        /// </summary>
        public IntPtr ActivationContext;

        /// <summary>
        /// FinalizationCallback
        /// </summary>
        public PTP_SIMPLE_CALLBACK FinalizationCallback;

        /// <summary>
        /// Flags
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// CallbackPriority
        /// </summary>
        public TP_CALLBACK_PRIORITY CallbackPriority;

        /// <summary>
        /// Size
        /// </summary>
        public DWORD Size;
    }
}
