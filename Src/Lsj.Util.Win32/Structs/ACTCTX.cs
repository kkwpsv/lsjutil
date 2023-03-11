using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ACTCTX_FLAG;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACTCTX"/> structure is used by the <see cref="CreateActCtx"/> function to create the activation context.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-actctxw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the file identified by the value of the lpSource member is a PE image file,
    /// <see cref="CreateActCtx"/> searches for the manifest in the .manifest file located in the same directory
    /// and in the first RT_MANIFEST resource located in the PE image file.
    /// To find a specific named resource from the image, set the <see cref="lpResourceName"/> to the name of the resource,
    /// and add the <see cref="ACTCTX_FLAG_RESOURCE_NAME_VALID"/> to the <see cref="dwFlags"/> member.
    /// Refer to <see cref="FindResource"/> for more information on specifying resource names.
    /// In most cases, the caller should not set the <see cref="ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID"/>
    /// and <see cref="ACTCTX_FLAG_LANGID_VALID"/> flags of the <see cref="dwFlags"/> member.
    /// Also, in most cases, the value of the <see cref="lpResourceName"/> member should be set to <see cref="NULL"/>.
    /// The values of <see cref="lpApplicationName"/> and <see cref="lpAssemblyDirectory"/> are not set to <see cref="NULL"/>
    /// when the executable creating the activation context is a host for the application.
    /// In this case, the host can set a different name for the application to find configuration files, report errors, and so forth.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACTCTX
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// This is used to determine the version of this structure.
        /// </summary>
        public ULONG cbSize;

        /// <summary>
        /// Flags that indicate how the values included in this structure are to be used.
        /// Set any undefined bits in <see cref="dwFlags"/> to 0.
        /// If any undefined bits are not set to 0, the call to <see cref="CreateActCtx"/>
        /// that creates the activation context fails and returns an invalid parameter error code.
        /// </summary>
        public ACTCTX_FLAG dwFlags;

        /// <summary>
        /// Null-terminated string specifying the path of the manifest file or PE image to be used to create the activation context.
        /// If this path refers to an EXE or DLL file, the <see cref="lpResourceName"/> member is required.
        /// </summary>
        public IntPtr lpSource;

        /// <summary>
        /// Identifies the type of processor used. Specifies the system's processor architecture.
        /// </summary>
        public USHORT wProcessorArchitecture;

        /// <summary>
        /// Specifies the language manifest that should be used. The default is the current user's current UI language.
        /// If the requested language cannot be found, an approximation is searched for using the following order:
        /// The current user's specific language. For example, for US English (1033).
        /// The current user's primary language. For example, for English (9).
        /// The current system's specific language.
        /// The current system's primary language.
        /// A nonspecific worldwide language. Language neutral (0).
        /// </summary>
        public LANGID wLangId;

        /// <summary>
        /// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the system-wide store.
        /// </summary>
        public IntPtr lpAssemblyDirectory;

        /// <summary>
        /// Pointer to a null-terminated string that contains the resource name to be loaded from the PE specified in <see cref="hModule"/> or <see cref="lpSource"/>.
        /// If the resource name is an integer, set this member using <see cref="MAKEINTRESOURCE"/>.
        /// This member is required if <see cref="lpSource"/> refers to an EXE or DLL.
        /// </summary>
        public IntPtr lpResourceName;

        /// <summary>
        /// The name of the current application.
        /// If the value of this member is set to null, the name of the executable that launched the current process is used.
        /// </summary>
        public IntPtr lpApplicationName;

        /// <summary>
        /// Use this member rather than <see cref="lpSource"/> if you have already loaded a DLL
        /// and wish to use it to create activation contexts rather than using a path in <see cref="lpSource"/>.
        /// See <see cref="lpResourceName"/> for the rules of looking up resources in this module.
        /// </summary>
        public HMODULE hModule;
    }
}
