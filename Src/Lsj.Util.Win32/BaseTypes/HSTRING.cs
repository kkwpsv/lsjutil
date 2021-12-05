using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to a Windows Runtime string.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winrt/hstring"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use <see cref="HSTRING"/> to represent immutable strings in the Windows Runtime.
    /// JavaScript and other languages, such as C#, and Microsoft Visual Basic, can use strings that are represented by using <see cref="HSTRING"/>.
    /// The following table shows how an <see cref="HSTRING"/> is represented in other languages.
    /// C++/WinRT	winrt::hstring class
    /// Visual C++ component extensions (C++/CX)	Platform::String class
    /// JavaScript	String object
    /// .NET Framework	System.String class
    /// The <see cref="HSTRING"/> handle is a standard handle type.
    /// Semantically, an <see cref="HSTRING"/> containing the value <see cref="NULL"/> represents the empty string,
    /// which consists of zero content characters and a terminating <see cref="NULL"/> character.
    /// Creating a string via <see cref="WindowsCreateString"/> with zero characters will produce the handle value <see cref="NULL"/>.
    /// When calling <see cref="WindowsGetStringRawBuffer"/> with the value <see cref="NULL"/>,
    /// a pointer to an empty string followed only by the <see cref="NUL"/> terminating character will be returned.
    /// No distinct value exists to represent an <see cref="HSTRING"/> that is uninitialized.
    /// Call the <see cref="WindowsCreateString"/> function to create a new <see cref="HSTRING"/>,
    /// and call the <see cref="WindowsDeleteString"/> function to release the reference to the backing string memory.
    /// Call the <see cref="WindowsCreateStringReference"/> function to create a string reference, which is also called a fast-pass string.
    /// Copy an <see cref="HSTRING"/> by calling the <see cref="WindowsDuplicateString"/> function.
    /// Concatenate two strings by calling the <see cref="WindowsConcatString"/> function.
    /// Access the backing string memory by calling the <see cref="WindowsGetStringRawBuffer"/> function.
    /// <see cref="HSTRING"/> can store and use embedded <see cref="NUL"/> characters.
    /// Use the <see cref="WindowsStringHasEmbeddedNull"/> function to check for embedded NUL characters
    /// before using any functions which may produce unexpected results.
    /// For example, most of the Windows functions use <see cref="LPCWSTR"/> as an input parameter,
    /// and they compute the length of the string only until the first NUL is encountered.
    /// The backing string must remain immutable and null-terminated.
    /// When calling code creates a string reference by using the <see cref="WindowsCreateStringReference"/> function,
    /// the memory containing the backing string representation is owned by the caller.
    /// The Windows Runtime relies on the contents of the original string to remain unchanged.
    /// When passing a string reference into the Windows Runtime, it is the caller’s responsibility
    /// to ensure that the string’s contents are unchanging and NUL terminated for the duration of the call.
    /// The Windows Runtime releases all references to the string reference when the call returns.
    /// When you receive an <see cref="HSTRING"/> as an out parameter, it is good practice to set the handle to <see cref="NULL"/> when you are finished with it.
    /// Call the <see cref="WindowsPreallocateStringBuffer"/> function to allocate a mutable string buffer that you can use to create an immutable <see cref="HSTRING"/>.
    /// When you have finished populating the buffer, you call the <see cref="WindowsPromoteStringBuffer"/> function to create the <see cref="HSTRING"/>.
    /// This two-phase construction pattern enables functionality that is similar to a "string builder."
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct HSTRING : IPointer
    {
        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HSTRING val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HSTRING(IntPtr val) => new HSTRING { _value = val };
    }
}
