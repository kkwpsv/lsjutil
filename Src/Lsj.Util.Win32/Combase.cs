using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.RO_INIT_TYPE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Constants;
using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Combase.dll
    /// </summary>
    public static class Combase
    {
        /// <summary>
        /// <para>
        /// Activates the specified Windows Runtime class.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/roapi/nf-roapi-roactivateinstance"/>
        /// </para>
        /// </summary>
        /// <param name="activatableClassId">
        /// The class identifier that is associated with the activatable runtime class.
        /// </param>
        /// <param name="instance">
        /// A pointer to the activated instance of the runtime class.
        /// </param>
        /// <returns>
        /// This function can return one of these values.
        /// <see cref="S_OK"/>: The class was activated successfully.
        /// <see cref="E_POINTER"/>: <paramref name="instance"/> is NULL/>.
        /// <see cref="CO_E_NOTINITIALIZED"/>: The thread has not been initialized in the Windows Runtime by calling the <see cref="RoInitialize"/> function.
        /// <see cref="E_ACCESSDENIED"/>: The TrustLevel for the class requires a full-trust process.
        /// <see cref="E_NOINTERFACE"/>: The <see cref="IInspectable"/> interface is not implemented by the specified class.
        /// <see cref="E_OUTOFMEMORY"/>: Failed to create an instance of the class.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="RoActivateInstance"/> function to activate a Windows Runtime class.
        /// The <see cref="RoActivateInstance"/> function connects to the activation factory that is associated with the specified activatable class identifier,
        /// creates an instance by calling the zero-argument constructor on the class, and releases the activation factory.
        /// </remarks>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "RoActivateInstance", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT RoActivateInstance([In] HSTRING activatableClassId, [Out] out LP<IInspectable> instance);

        /// <summary>
        /// <para>
        /// Gets the activation factory for the specified runtime class.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/roapi/nf-roapi-rogetactivationfactory"/>
        /// </para>
        /// </summary>
        /// <param name="activatableClassId">
        /// The ID of the activatable class.
        /// </param>
        /// <param name="iid">
        /// The reference ID of the interface.
        /// </param>
        /// <param name="factory">
        /// The activation factory.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "RoGetActivationFactory", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT RoGetActivationFactory([In] HSTRING activatableClassId, [In] in IID iid, [Out] out IntPtr factory);

        /// <summary>
        /// <para>
        /// Initializes the Windows Runtime on the current thread with the specified concurrency model.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/roapi/nf-roapi-roinitialize"/>
        /// </para>
        /// </summary>
        /// <param name="initType">
        /// The concurrency model for the thread.
        /// The default is <see cref="RO_INIT_MULTITHREADED"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The Windows Runtime was initialized successfully on this thread.
        /// <see cref="S_FALSE"/>: The Windows Runtime is already initialized on this thread.
        /// <see cref="RPC_E_CHANGED_MODE"/>:
        /// A previous call to RoInitialize specified the concurrency model for this thread as multithread apartment(MTA).
        /// This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="RoInitialize"/> function to initialize a thread in the Windows Runtime.
        /// All threads that activate and interact with Windows Runtime objects must be initialized prior to calling into the Windows Runtime.
        /// Call the <see cref="RoUninitialize"/> function to close the Windows Runtime on the current thread.
        /// Each successful call to <see cref="RoInitialize"/>, including those that return <see cref="S_FALSE"/>,
        /// must be balanced by a corresponding call to <see cref="RoUninitialize"/>.
        /// </remarks>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "RoInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT RoInitialize([In] RO_INIT_TYPE initType);

        /// <summary>
        /// <para>
        /// Closes the Windows Runtime on the current thread.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/roapi/nf-roapi-rouninitialize"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Call the <see cref="RoUninitialize"/> function to close the Windows Runtime on the current thread.
        /// This unloads all DLLs loaded by the thread, frees any other resources that the thread maintains, and forces all RPC connections on the thread to close.
        /// Use the <see cref="RoInitialize"/> function to initialize a thread in the Windows Runtime.
        /// </remarks>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "RoUninitialize", ExactSpelling = true, SetLastError = true)]
        public static extern void RoUninitialize();

        /// <summary>
        /// <para>
        /// Creates a new <see cref="HSTRING"/> based on the specified source string.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winstring/nf-winstring-windowscreatestring"/>
        /// </para>
        /// </summary>
        /// <param name="sourceString">
        /// A null-terminated string to use as the source for the new <see cref="HSTRING"/>.
        /// To create a new, empty, or NULL string, pass <see cref="NULL"/> for <paramref name="sourceString"/> and 0 for <paramref name="length"/>.
        /// </param>
        /// <param name="length">
        /// The length of <paramref name="sourceString"/>, in Unicode characters.
        /// Must be 0 if <paramref name="sourceString"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="string">
        /// A pointer to the newly created <see cref="HSTRING"/>, or <see cref="NULL"/> if an error occurs. 
        /// Any existing content in string is overwritten.
        /// The <see cref="HSTRING"/> is a standard handle type.
        /// </param>
        /// <returns>
        /// This function can return one of these values.
        /// <see cref="S_OK"/>: The <see cref="HSTRING"/> was created successfully.
        /// <see cref="E_INVALIDARG"/>: <paramref name="string"/> is <see cref="NullRef{HSTRING}"/>.
        /// <see cref="E_OUTOFMEMORY"/>: Failed to allocate the new <see cref="HSTRING"/>.
        /// <see cref="E_POINTER"/>: <paramref name="sourceString"/> is <see cref="NULL"/> and <paramref name="length"/> is non-zero.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="WindowsCreateString"/> function to allocate a new <see cref="HSTRING"/>.
        /// The Windows Runtime copies string to the backing buffer of the new <see cref="HSTRING"/> and manages the buffer lifetime by using a reference count.
        /// Call the <see cref="WindowsCreateStringReference"/> function to create a fast-pass string, which uses an existing string without copying it.
        /// Call the <see cref="WindowsDeleteString"/> function to de-allocate the <see cref="HSTRING"/>.
        /// Each call to the <see cref="WindowsCreateString"/> function must be matched by a call to <see cref="WindowsDeleteString"/>.
        /// To create a new, empty, or NULL string, pass <see cref="NULL"/> for <paramref name="sourceString"/> and 0 for <paramref name="length"/>.
        /// If <paramref name="sourceString"/> has embedded null characters,
        /// the <see cref="WindowsCreateString"/> function copies all characters to the terminating null character.
        /// </remarks>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "WindowsCreateString", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT WindowsCreateString([In] LPCWSTR sourceString, [In] UINT32 length, [Out] out HSTRING @string);

        /// <summary>
        /// <para>
        /// Creates a new string reference based on the specified string.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winstring/nf-winstring-windowscreatestringreference"/>
        /// </para>
        /// </summary>
        /// <param name="sourceString">
        /// A null-terminated string to use as the source for the new <see cref="HSTRING"/>.
        /// A value of <see cref="NULL"/> represents the empty string, if the value of <paramref name="length"/> is 0.
        /// Should be allocated on the stack frame.
        /// </param>
        /// <param name="length">
        /// The length of <paramref name="sourceString"/>, in Unicode characters.
        /// Must be 0 if <paramref name="sourceString"/> is <see cref="NULL"/>.
        /// If greater than 0, <paramref name="sourceString"/> must have a terminating null character.
        /// </param>
        /// <param name="hstringHeader">
        /// A pointer to a structure that the Windows Runtime uses to identify string as a string reference, or fast-pass string.
        /// </param>
        /// <param name="string">
        /// A pointer to the newly created string, or <see cref="NULL"/> if an error occurs.
        /// Any existing content in string is overwritten.
        /// The <see cref="HSTRING"/> is a standard handle type.
        /// </param>
        /// <returns>
        /// This function can return one of these values.
        /// <see cref="S_OK"/>: The <see cref="HSTRING"/> was created successfully.
        /// <see cref="E_INVALIDARG"/>: <paramref name="string"/> or <paramref name="hstringHeader"/> is NULL, or <paramref name="string"/> is not null-terminated.
        /// <see cref="E_OUTOFMEMORY"/>: Failed to allocate the new <see cref="HSTRING"/>.
        /// <see cref="E_POINTER"/>: <paramref name="sourceString"/> is <see cref="NULL"/> and <paramref name="length"/> is non-zero.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="WindowsCreateStringReference"/> function to create an <see cref="HSTRING"/> from an existing string.
        /// This kind of <see cref="HSTRING"/> is named a fast-pass string.
        /// Unlike an <see cref="HSTRING"/> created by the <see cref="WindowsCreateString"/> function,
        /// the lifetime of the backing buffer in the new <see cref="HSTRING"/> is not managed by the Windows Runtime.
        /// The caller allocates <paramref name="sourceString"/> on the stack frame, together with an uninitialized <see cref="HSTRING_HEADER"/>,
        /// to avoid a heap allocation and eliminate the risk of a memory leak.
        /// The caller must ensure that <paramref name="sourceString"/> and the contents of <paramref name="hstringHeader"/>
        /// remain unchanged during the lifetime of the attached <see cref="HSTRING"/>.
        /// You don't need to call the <see cref="WindowsDeleteString"/> function
        /// to de-allocate a fast-pass <see cref="HSTRING"/> created by the <see cref="WindowsCreateStringReference"/> function.
        /// To create an empty <see cref="HSTRING"/>, pass <see cref="NULL"/> for <paramref name="sourceString"/> and 0 for <paramref name="length"/>.
        /// The Windows Runtime tracks a fast-pass string by using an <see cref="HSTRING_HEADER"/> structure,
        /// which is returned in the <paramref name="hstringHeader"/> out parameter.
        /// Do not change the contents of the <see cref="HSTRING_HEADER"/>.
        /// </remarks>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "WindowsCreateStringReference", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT WindowsCreateStringReference([In] LPCWSTR sourceString, [In] UINT32 length,
            [Out] out HSTRING_HEADER hstringHeader, [Out] out HSTRING @string);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a string buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winstring/nf-winstring-windowsdeletestring"/>
        /// </para>
        /// </summary>
        /// <param name="string">
        /// The string to be deleted.
        /// If string is a fast-pass string created by <see cref="WindowsCreateStringReference"/>,
        /// or if <paramref name="string"/> is <see cref="NULL"/> or empty, no action is taken and <see cref="S_OK"/> is returned.
        /// </param>
        /// <returns>
        /// This function always returns <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="WindowsDeleteString"/> function to de-allocate an <see cref="HSTRING"/>.
        /// Calling <see cref="WindowsDeleteString"/> decrements the reference count of the backing buffer,
        /// and if the reference count reaches 0, the Windows Runtime de-allocates the buffer.
        /// </remarks>
        [DllImport("Combase.dll", CharSet = CharSet.Unicode, EntryPoint = "WindowsDeleteString", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT WindowsDeleteString([In] HSTRING @string);
    }
}
