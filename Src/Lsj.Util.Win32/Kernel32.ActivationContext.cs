using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ResourceTypes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// The <see cref="ActivateActCtx"/> function activates the specified activation context.
        /// It does this by pushing the specified activation context to the top of the activation stack.
        /// The specified activation context is thus associated with the current thread and any appropriate side-by-side API functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-activateactctx"/>
        /// </para>
        /// </summary>
        /// <param name="hActCtx">
        /// Handle to an <see cref="ACTCTX"/> structure that contains information on the activation context that is to be made active.
        /// </param>
        /// <param name="lpCookie">
        /// Pointer to a <see cref="ULONG_PTR"/> that functions as a cookie, uniquely identifying a specific, activated activation context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>. Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <paramref name="lpCookie"/> parameter is later passed to <see cref="DeactivateActCtx"/>,
        /// which verifies the pairing of calls to <see cref="ActivateActCtx"/> and <see cref="DeactivateActCtx"/>
        /// and ensures that the appropriate activation context is being deactivated.
        /// This is done because the deactivation of activation contexts must occur in the reverse order of activation.
        /// </para>
        /// <para>
        /// The activation of activation contexts can be understood as pushing an activation context onto a stack of activation contexts.
        /// The activation context you activate through this function redirects any binding to DLLs,
        /// window classes, COM servers, type libraries, and mutexes for any side-by-side APIs you call.
        /// </para>
        /// <para>
        /// The top item of an activation context stack is the active, default-activation context of the current thread.
        /// If a null activation context handle is pushed onto the stack, thereby activating it,
        /// the default settings in the original manifest override all activation contexts that are lower on the stack.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ActivateActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ActivateActCtx([In] HANDLE hActCtx, [Out] out ULONG_PTR lpCookie);

        /// <summary>
        /// <para>
        /// The <see cref="AddRefActCtx"/> function increments the reference count of the specified activation context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-addrefactctx"/>
        /// </para>
        /// </summary>
        /// <param name="hActCtx">
        /// Handle to an <see cref="ACTCTX"/> structure that contains information on the activation context
        /// for which the reference count is to be incremented.
        /// </param>
        /// <remarks>
        /// This function is provided so that multiple clients can access a single activation context.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddRefActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern void AddRefActCtx(HANDLE hActCtx);

        /// <summary>
        /// <para>
        /// The <see cref="CreateActCtx"/> function creates an activation context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createactctxw"/>
        /// </para>
        /// </summary>
        /// <param name="pActCtx">
        /// Pointer to an <see cref="ACTCTX"/> structure that contains information about the activation context to be created.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a handle to the returned activation context.
        /// Otherwise, it returns <see cref="INVALID_HANDLE_VALUE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code. For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Set any undefined bits in <see cref="ACTCTX.dwFlags"/> of <see cref="ACTCTX"/> to 0.
        /// If any undefined bits are not set to 0, the call to <see cref="CreateActCtx"/> that creates the activation context fails and returns an invalid parameter error code.
        /// The handle returned from <see cref="CreateActCtx"/> is passed in a call to <see cref="ActivateActCtx"/> to activate the context for the current thread.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateActCtxW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateActCtx([In][Out] ref ACTCTX pActCtx);

        /// <summary>
        /// <para>
        /// The <see cref="DeactivateActCtx"/> function deactivates the activation context corresponding to the specified cookie.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-deactivateactctx"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// Flags that indicate how the deactivation is to occur.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// <para>
        /// If this value is set and the cookie specified in the <paramref name="ulCookie"/> parameter is in the top frame of the activation stack,
        /// the activation context is popped from the stack and thereby deactivated.
        /// </para>
        /// <para>
        /// If this value is set and the cookie specified in the <paramref name="ulCookie"/> parameter is not in the top frame of the activation stack,
        /// this function searches down the stack for the cookie.
        /// </para>
        /// <para>
        /// If the cookie is found, a <see cref="STATUS_SXS_EARLY_DEACTIVATION"/> exception is thrown.
        /// </para>
        /// <para>
        /// If the cookie is not found, a <see cref="STATUS_SXS_INVALID_DEACTIVATION"/> exception is thrown.
        /// </para>
        /// <para>
        /// This value should be specified in most cases.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION"/>
        /// </term>
        /// <term>
        /// <para>
        /// If this value is set and the cookie specified in the <paramref name="ulCookie"/> parameter is in the top frame of the activation stack,
        /// the function returns an <see cref="ERROR_INVALID_PARAMETER"/> error code.
        /// Call <see cref="GetLastError"/> to obtain this code.
        /// </para>
        /// <para>
        /// If this value is set and the cookie is not on the activation stack, a <see cref="STATUS_SXS_INVALID_DEACTIVATION"/> exception will be thrown.
        /// </para>
        /// <para>
        /// If this value is set and the cookie is in a lower frame of the activation stack,
        /// all of the frames down to and including the frame the cookie is in is popped from the stack.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ulCookie">
        /// The <see cref="ULONG_PTR"/> that was passed into the call to <see cref="ActivateActCtx"/>.
        /// This value is used as a cookie to identify a specific activated activation context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>. Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The deactivation of activation contexts must occur in the reverse order of activation.
        /// It can be understood as popping an activation context from a stack.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeactivateActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeactivateActCtx([In] DWORD dwFlags, [In] ULONG_PTR ulCookie);

        /// <summary>
        /// <para>
        /// The <see cref="FindActCtxSectionGuid"/> function retrieves information on a specific <see cref="GUID"/>
        /// in the current activation context and returns a <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-findactctxsectionguid"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// Flags that determine how this function is to operate. Only the following flag is currently defined.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX"/>
        /// </term>
        /// <term>
        /// This function returns the activation context handle where the redirection data was found
        /// in the <see cref="ACTCTX_SECTION_KEYED_DATA.hActCtx"/> member of the <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure.
        /// The caller must use <see cref="ReleaseActCtx"/> to release this activation context.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpExtensionGuid">
        /// Reserved; must be <see cref="NullRef{GUID}"/>.
        /// </param>
        /// <param name="ulSectionId">
        /// <para>
        /// Identifier of the section of the activation context in which to search for the specified <see cref="GUID"/>.
        /// </para>
        /// <para>
        /// The following are valid <see cref="GUID"/> section identifiers:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_COM_SERVER_REDIRECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_COM_INTERFACE_REDIRECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_COM_TYPE_LIBRARY_REDIRECTION"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following is a valid <see cref="GUID"/> section identifier beginning with Windows Server 2003 and Windows XP with SP1:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_CLR_SURROGATES"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpGuidToFind">
        /// Pointer to a <see cref="GUID"/> to be used as the search criteria.
        /// </param>
        /// <param name="ReturnedData">
        /// Pointer to an <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure to be filled out with the requested <see cref="GUID"/> information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function should only be called by the Side-by-side API functions or COM methods.
        /// Applications should not directly call this function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindActCtxSectionGuid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindActCtxSectionGuid([In] DWORD dwFlags, [In] in GUID lpExtensionGuid, [In] ULONG ulSectionId,
            [In] in GUID lpGuidToFind, [Out] out ACTCTX_SECTION_KEYED_DATA ReturnedData);

        /// <summary>
        /// <para>
        /// The <see cref="FindActCtxSectionString"/> function retrieves information on a specific string
        /// in the current activation context and returns a <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-findactctxsectionstringw"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// Flags that determine how this function is to operate.
        /// Only the following flag is currently defined.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX"/>
        /// </term>
        /// <term>
        /// This function returns the activation context handle where the redirection data was found
        /// in the <see cref="ACTCTX_SECTION_KEYED_DATA.hActCtx"/> member of the <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure.
        /// The caller must use <see cref="ReleaseActCtx"/> to release this activation context.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpExtensionGuid">
        /// Reserved; must be <see cref="NullRef{GUID}"/>.
        /// </param>
        /// <param name="ulSectionId">
        /// <para>
        /// Identifier of the string section of the activation context in which to search for the specific string.
        /// </para>
        /// <para>
        /// The following are valid string section identifiers:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_ASSEMBLY_INFORMATION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_DLL_REDIRECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_WINDOW_CLASS_REDIRECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ACTIVATION_CONTEXT_SECTION_COM_PROGID_REDIRECTION"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpStringToFind">
        /// Pointer to a null-terminated string to be used as the search criteria.
        /// </param>
        /// <param name="ReturnedData">
        /// Pointer to an <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure to be filled out with the requested string information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function should only be called by the Side-by-side API functions or COM methods.
        /// Applications should not directly call this function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindActCtxSectionStringW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindActCtxSectionString([In] DWORD dwFlags, [In] in GUID lpExtensionGuid, [In] ULONG ulSectionId,
            [In] LPCWSTR lpStringToFind, [Out] out ACTCTX_SECTION_KEYED_DATA ReturnedData);

        /// <summary>
        /// <para>
        /// The <see cref="GetCurrentActCtx"/> function returns the handle to the active activation context of the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcurrentactctx"/>
        /// </para>
        /// </summary>
        /// <param name="hActCtx">
        /// Pointer to the returned <see cref="ACTCTX"/> structure that contains information on the active activation context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The calling thread is responsible for releasing the handle of the returned activation context.
        /// This function can return a null handle if no activation contexts have been activated by this thread.
        /// This is not an error.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCurrentActCtx([Out] out HANDLE hActCtx);

        /// <summary>
        /// <para>
        /// The <see cref="QueryActCtxW"/> function queries the activation context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-queryactctxw"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter should be set to one of the following flag bits.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX"/>
        /// </term>
        /// <term>
        /// <see cref="QueryActCtxW"/> queries the activation context active on the thread
        /// instead of the context specified by <paramref name="hActCtx"/>.
        /// This is usually the last activation context passed to <see cref="ActivateActCtx"/>.
        /// If <see cref="ActivateActCtx"/> has not been called, the active activation context can be the activation context
        /// used by the executable of the current process.
        /// In other cases, the operating system determines the active activation context.
        /// For example, when the callback function to a new thread is called,
        /// the active activation context may be the context that was active
        /// when you created the thread by calling <see cref="CreateThread"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE"/>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="QueryActCtxW"/> interprets <paramref name="hActCtx"/> as an <see cref="HMODULE"/> data type
        /// and queries an activation context that is associated with a DLL or EXE.
        /// </para>
        /// <para>
        /// When a DLL or EXE is loaded, the loader checks for a manifest stored in a resource.
        /// If the loader finds an <see cref="RT_MANIFEST"/> resource
        /// with a resource identifier set to <see cref="ISOLATIONAWARE_MANIFEST_RESOURCE_ID"/>,
        /// the loader associates the resulting activation context with the DLL or EXE.
        /// This is the activation context that <see cref="QueryActCtxW"/> queries
        /// when the <see cref="QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE"/> flag has been set.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="QUERY_ACTCTX_FLAG_ACTCTX_IS_ADDRESS"/>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="QueryActCtxW"/> interprets <paramref name="hActCtx"/> as an address
        /// within a DLL or EXE and queries an activation context that has been associated with the DLL or EXE.
        /// This can be any address within the DLL or EXE.
        /// For example, the address of any function within a DLL or EXE or the address of any static data, such as a constant string.
        /// </para>
        /// <para>
        /// When a DLL or EXE is loaded, the loader checks for a manifest stored in a resource
        /// in the same way as <see cref="QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="hActCtx">
        /// Handle to the activation context that is being queried.
        /// </param>
        /// <param name="pvSubInstance">
        /// <para>
        /// Index of the assembly, or assembly and file combination, in the activation context.
        /// The meaning of the <paramref name="pvSubInstance"/> depends on the option
        /// specified by the value of the <paramref name="ulInfoClass"/> parameter.
        /// </para>
        /// <para>
        /// This parameter may be null.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// ulInfoClass Option
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="AssemblyDetailedInformationInActivationContext"/>
        /// </term>
        /// <term>
        /// Pointer to a <see cref="DWORD"/> that specifies the index of the assembly within the activation context.
        /// This is the activation context that <see cref="QueryActCtxW"/> queries.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FileInformationInAssemblyOfAssemblyInActivationContext"/>
        /// </term>
        /// <term>
        /// Pointer to an <see cref="ACTIVATION_CONTEXT_QUERY_INDEX"/> structure.
        /// If <see cref="QueryActCtxW"/> is called with this option and the function succeeds,
        /// the returned buffer contains information for a file in the assembly.
        /// This information is in the form of the <see cref="ASSEMBLY_FILE_DETAILED_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ulInfoClass">
        /// <para>
        /// This parameter can have only the values shown in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Option
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ActivationContextBasicInformation"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Not available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ActivationContextDetailedInformation"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// If <see cref="QueryActCtxW"/> is called with this option and the function succeeds,
        /// the returned buffer contains detailed information about the activation context.
        /// This information is in the form of the <see cref="ACTIVATION_CONTEXT_DETAILED_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AssemblyDetailedInformationInActivationContext"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// If <see cref="QueryActCtxW"/> is called with this option and the function succeeds,
        /// the buffer contains information about the assembly that has the index specified in <paramref name="pvSubInstance"/>.
        /// This information is in the form of the <see cref="ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FileInformationInAssemblyOfAssemblyInActivationContext"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Information about a file in one of the assemblies in Activation Context.
        /// The <paramref name="pvSubInstance"/> parameter must point to an <see cref="ACTIVATION_CONTEXT_QUERY_INDEX"/> structure.
        /// If <see cref="QueryActCtxW"/> is called with this option and the function succeeds,
        /// the returned buffer contains information for a file in the assembly.
        /// This information is in the form of the <see cref="ASSEMBLY_FILE_DETAILED_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RunlevelInformationInActivationContext"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If <see cref="QueryActCtxW"/> is called with this option and the function succeeds,
        /// the buffer contains information about requested run level of the activation context.
        /// This information is in the form of the <see cref="ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This value is not available.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CompatibilityInformationInActivationContext"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If <see cref="QueryActCtxW"/> is called with this option and the function succeeds,
        /// the buffer contains information about requested compatibility context.
        /// This information is in the form of the <see cref="ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows Server 2008 and earlier, and Windows Vista and earlier:
        /// This value is not available.
        /// This option is available beginning with Windows Server 2008 R2 and Windows 7.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pvBuffer">
        /// Pointer to a buffer that holds the returned information.
        /// This parameter is optional.
        /// If <paramref name="pvBuffer"/> is <see cref="NULL"/>, then <paramref name="cbBuffer"/> must be zero.
        /// If the size of the buffer pointed to by <paramref name="pvBuffer"/> is too small,
        /// <see cref="QueryActCtxW"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/> and no data is written into the buffer.
        /// See the Remarks section for the method you can use to determine the required size of the buffer.
        /// </param>
        /// <param name="cbBuffer">
        /// Size of the buffer in bytes pointed to by <paramref name="pvBuffer"/>.
        /// This parameter is optional.
        /// </param>
        /// <param name="pcbWrittenOrRequired">
        /// Number of bytes written or required.
        /// The parameter <paramref name="pcbWrittenOrRequired"/> can only be <see cref="NullRef{SIZE_T}"/>
        /// when <paramref name="pvBuffer"/> is <see cref="NULL"/>.
        /// If <paramref name="pcbWrittenOrRequired"/> is non-<see cref="NullRef{SIZE_T}"/>,
        /// it is filled with the number of bytes required to store the returned buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The parameter <paramref name="cbBuffer"/> specifies the size in bytes of the buffer pointed to by <paramref name="pvBuffer"/>.
        /// If <paramref name="pvBuffer"/> is <see cref="NULL"/>, then <paramref name="cbBuffer"/> must be 0.
        /// The parameter <paramref name="pcbWrittenOrRequired"/> can only be <see cref="NullRef{SIZE_T}"/>
        /// if <paramref name="pvBuffer"/> is <see cref="NULL"/>.
        /// If <paramref name="pcbWrittenOrRequired"/> is non-<see cref="NULL"/> on return,
        /// it is filled with the number of bytes required to store the returned information.
        /// When the information data returned is larger than the provided buffer,
        /// <see cref="QueryActCtxW"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// and no data is written to the buffer pointed to by <paramref name="pvBuffer"/>.
        /// </para>
        /// <para>
        /// The following example shows the method of calling first with a small buffer and then recalling if the buffer is too small.
        /// </para>
        /// <code>
        /// SIZE_T cbRequired;
        /// PVOID pvData = NULL;
        /// SIZE_T cbAvailable = 0;
        /// 
        /// if (!QueryActCtxW(..., pvData, cbAvailable, &amp;cbRequired) &amp;&amp; (GetLastError()== ERROR_INSUFFICIENT_BUFFER))
        /// {
        ///     // Allocate enough space to store the returned buffer, fail if too small
        ///     if (NULL == (pvData = HeapAlloc(GetProcessHeap(), 0, cbRequired)))
        ///     {
        ///         SetLastError(ERROR_NOT_ENOUGH_MEMORY);
        ///         return FALSE;
        ///     }
        ///     cbAvailable = cbRequired;
        ///     // Try again, this should succeed.
        ///     if (QueryActCtxW(..., pvData, cbAvailable, &amp;cbRequired))
        ///     {
        ///         // Use the returned data in pvData
        ///     }
        ///     HeapFree(GetProcessHeap(), 0, pvData);
        ///     pvData = NULL;
        /// }
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryActCtxW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryActCtxW([In] DWORD dwFlags, [In] HANDLE hActCtx, [In] PVOID pvSubInstance, [In] ULONG ulInfoClass,
            [In] PVOID pvBuffer, [In] SIZE_T cbBuffer, [Out] out SIZE_T pcbWrittenOrRequired);

        /// <summary>
        /// <para>
        /// The <see cref="QueryActCtxSettingsW"/> function specifies the activation context,
        /// and the namespace and name of the attribute that is to be queried.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-queryactctxsettingsw"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// This value must be 0.
        /// </param>
        /// <param name="hActCtx">
        /// A handle to the activation context that is being queried.
        /// </param>
        /// <param name="settingsNameSpace">
        /// <para>
        /// A pointer to a string that contains the value <c>"http://schemas.microsoft.com/SMI/2005/WindowsSettings"</c> or <see cref="NULL"/>.
        /// These values are equivalent.
        /// </para>
        /// <para>
        /// Windows 8 and Windows Server 2012:
        /// A pointer to a string that contains the value <c>"http://schemas.microsoft.com/SMI/2011/WindowsSettings"</c> is also a valid parameter.
        /// A <see cref="NULL"/> is still equivalent to the previous value.
        /// </para>
        /// </param>
        /// <param name="settingName">
        /// The name of the attribute to be queried.
        /// </param>
        /// <param name="pvBuffer">
        /// A pointer to the buffer that receives the query result.
        /// </param>
        /// <param name="dwBuffer">
        /// The size of the buffer in characters that receives the query result.
        /// </param>
        /// <param name="pdwWrittenOrRequired">
        /// A pointer to a value which is the number of characters written to the buffer
        /// specified by <paramref name="pvBuffer"/> or that is required to hold the query result.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryActCtxSettingsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryActCtxSettingsW([In] DWORD dwFlags, [In] HANDLE hActCtx, [In] LPCWSTR settingsNameSpace,
            [In] LPCWSTR settingName, [In] LPWSTR pvBuffer, [In] SIZE_T dwBuffer, [Out] out SIZE_T pdwWrittenOrRequired);

        /// <summary>
        /// <para>
        /// The <see cref="ReleaseActCtx"/> function decrements the reference count of the specified activation context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-releaseactctx"/>
        /// </para>
        /// </summary>
        /// <param name="hActCtx">
        /// Handle to the <see cref="ACTCTX"/> structure that contains information
        /// on the activation context for which the reference count is to be decremented.
        /// </param>
        /// <returns>
        /// This function does not return a value.
        /// On successful completion, the activation context reference count is decremented.
        /// The recipient of the reference-counted object must decrement the reference count when the object is no longer required.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When the reference count of an activation context becomes zero, the activation context structure is deallocated.
        /// Activation contexts have not been implemented as kernel objects,
        /// therefore, kernel handler functions cannot be used for activation contexts.
        /// </para>
        /// <para>
        /// If the value of the <paramref name="hActCtx"/> parameter is a null handle,
        /// this function does nothing and no error condition occurs.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern void ReleaseActCtx(HANDLE hActCtx);

        /// <summary>
        /// <para>
        /// The <see cref="ZombifyActCtx"/> function deactivates the specified activation context, but does not deallocate it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-zombifyactctx"/>
        /// </para>
        /// </summary>
        /// <param name="hActCtx">
        /// Handle to the activation context that is to be deactivated.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If a null handle is passed in the <paramref name="hActCtx"/> parameter, <see cref="ERROR_INVALID_PARAMETER"/> will be returned.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function sets errors that can be retrieved by calling <see cref="GetLastError"/>.
        /// For an example, see Retrieving the Last-Error Code.
        /// For a complete list of error codes, see System Error Codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function is intended for use in debugging threads using activation contexts.
        /// If the activation context deactivated by this function is subsequently accessed,
        /// the access fails and an assertion failure is shown in the debugger.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ZombifyActCtx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ZombifyActCtx(HANDLE hActCtx);
    }
}
