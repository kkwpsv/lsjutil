using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DebuggingEvents;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a debugging event.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-debug_event
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the <see cref="WaitForDebugEvent"/> function succeeds, it fills in the members of a <see cref="DEBUG_EVENT"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DEBUG_EVENT
    {
        /// <summary>
        /// The code that identifies the type of debugging event. This member can be one of the following values.
        /// <see cref="CREATE_PROCESS_DEBUG_EVENT"/>:
        /// Reports a create-process debugging event.
        /// The value of <see cref="CreateProcessInfo"/> specifies a <see cref="CREATE_PROCESS_DEBUG_INFO"/> structure.
        /// <see cref="CREATE_THREAD_DEBUG_EVENT"/>:
        /// Reports a create-thread debugging event.
        /// The value of <see cref="CreateThread"/> specifies a <see cref="CREATE_THREAD_DEBUG_INFO"/> structure.
        /// <see cref="EXCEPTION_DEBUG_EVENT"/>:
        /// Reports an exception debugging event.
        /// The value of <see cref="Exception"/> specifies an <see cref="EXCEPTION_DEBUG_INFO"/> structure.
        /// <see cref="EXIT_PROCESS_DEBUG_EVENT"/>:
        /// Reports an exit-process debugging event.
        /// The value of <see cref="ExitProcess"/> specifies an <see cref="EXIT_PROCESS_DEBUG_INFO"/> structure.
        /// <see cref="EXIT_THREAD_DEBUG_EVENT"/>:
        /// Reports an exit-thread debugging event.
        /// The value of <see cref="ExitThread"/> specifies an <see cref="EXIT_THREAD_DEBUG_INFO"/> structure.
        /// <see cref="LOAD_DLL_DEBUG_EVENT"/>:
        /// Reports a load-dynamic-link-library (DLL) debugging event.
        /// The value of <see cref="LoadDll"/> specifies a <see cref="LOAD_DLL_DEBUG_INFO"/> structure.
        /// <see cref="OUTPUT_DEBUG_STRING_EVENT"/>:
        /// Reports an output-debugging-string debugging event.
        /// The value of <see cref="DebugString"/> specifies an <see cref="OUTPUT_DEBUG_STRING_INFO"/> structure.
        /// <see cref="RIP_EVENT"/>:
        /// Reports a RIP-debugging event (system debugging error).
        /// The value of <see cref="RipInfo"/>RipInfo specifies a <see cref="RIP_INFO"/> structure.
        /// <see cref="UNLOAD_DLL_DEBUG_EVENT"/>:
        /// Reports an unload-DLL debugging event.
        /// The value of <see cref="UnloadDll"/> specifies an <see cref="UNLOAD_DLL_DEBUG_INFO"/> structure.
        /// </summary>
        public DebuggingEvents dwDebugEventCode;

        /// <summary>
        /// The identifier of the process in which the debugging event occurred.
        /// A debugger uses this value to locate the debugger's per-process structure.
        /// These values are not necessarily small integers that can be used as table indices.
        /// </summary>
        public DWORD dwProcessId;

        /// <summary>
        /// The identifier of the thread in which the debugging event occurred.
        /// A debugger uses this value to locate the debugger's per-thread structure.
        /// These values are not necessarily small integers that can be used as table indices.
        /// </summary>
        public DWORD dwThreadId;

        /// <summary>
        /// Any additional information relating to the debugging event.
        /// This union takes on the type and value appropriate to the type of debugging event,
        /// as described in the <see cref="dwDebugEventCode"/> member.
        /// </summary>
        private UnionStruct<EXCEPTION_DEBUG_INFO, CREATE_THREAD_DEBUG_INFO, CREATE_PROCESS_DEBUG_INFO,
                            EXIT_THREAD_DEBUG_INFO, EXIT_PROCESS_DEBUG_INFO, LOAD_DLL_DEBUG_INFO,
                            UNLOAD_DLL_DEBUG_INFO, OUTPUT_DEBUG_STRING_INFO, RIP_INFO> u;

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="EXCEPTION_DEBUG_EVENT"/> (1),
        /// <see cref="Exception"/> specifies an <see cref="EXCEPTION_DEBUG_INFO"/> structure.
        /// </summary>
        public EXCEPTION_DEBUG_INFO Exception
        {
            get => u.Struct1;
            set => u.Struct1 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="CREATE_THREAD_DEBUG_EVENT"/> (2),
        /// <see cref="CreateThread"/> specifies an <see cref="CREATE_THREAD_DEBUG_INFO"/> structure.
        /// </summary>
        public CREATE_THREAD_DEBUG_INFO CreateThread
        {
            get => u.Struct2;
            set => u.Struct2 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="CREATE_PROCESS_DEBUG_EVENT"/> (3),
        /// <see cref="CreateProcessInfo"/> specifies an <see cref="CREATE_PROCESS_DEBUG_INFO"/> structure.
        /// </summary>
        public CREATE_PROCESS_DEBUG_INFO CreateProcessInfo
        {
            get => u.Struct3;
            set => u.Struct3 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="EXIT_THREAD_DEBUG_EVENT"/> (4),
        /// <see cref="ExitThread"/> specifies an <see cref="EXIT_THREAD_DEBUG_INFO"/> structure.
        /// </summary>
        public EXIT_THREAD_DEBUG_INFO ExitThread
        {
            get => u.Struct4;
            set => u.Struct4 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="EXIT_PROCESS_DEBUG_EVENT"/> (5),
        /// <see cref="ExitProcess"/> specifies an <see cref="EXIT_PROCESS_DEBUG_INFO"/> structure.
        /// </summary>
        public EXIT_PROCESS_DEBUG_INFO ExitProcess
        {
            get => u.Struct5;
            set => u.Struct5 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="LOAD_DLL_DEBUG_EVENT"/> (6),
        /// <see cref="LoadDll"/> specifies an <see cref="LOAD_DLL_DEBUG_INFO"/> structure.
        /// </summary>
        public LOAD_DLL_DEBUG_INFO LoadDll
        {
            get => u.Struct6;
            set => u.Struct6 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="UNLOAD_DLL_DEBUG_EVENT"/> (7),
        /// <see cref="UnloadDll"/> specifies an <see cref="UNLOAD_DLL_DEBUG_INFO"/> structure.
        /// </summary>
        public UNLOAD_DLL_DEBUG_INFO UnloadDll
        {
            get => u.Struct7;
            set => u.Struct7 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="OUTPUT_DEBUG_STRING_EVENT"/> (8),
        /// <see cref="DebugString"/> specifies an <see cref="OUTPUT_DEBUG_STRING_INFO"/> structure.
        /// </summary>
        public OUTPUT_DEBUG_STRING_INFO DebugString
        {
            get => u.Struct8;
            set => u.Struct8 = value;
        }

        /// <summary>
        /// If the <see cref="dwDebugEventCode"/> is <see cref="RIP_EVENT"/> (9),
        /// <see cref="RipInfo"/> specifies an <see cref="RIP_INFO"/> structure.
        /// </summary>
        public RIP_INFO RipInfo
        {
            get => u.Struct9;
            set => u.Struct9 = value;
        }
    }
}
