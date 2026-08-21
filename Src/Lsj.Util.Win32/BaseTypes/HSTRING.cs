using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Combase;
using Lsj.Util.Win32.Marshals;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to a Windows Runtime string.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winrt/hstring"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="HSTRING"/> to represent immutable strings in the Windows Runtime.
    /// </para>
    /// <para>
    /// JavaScript and other languages, such as C#, and Microsoft Visual Basic, can use strings that are represented by using <see cref="HSTRING"/>.
    /// The following table shows how an <see cref="HSTRING"/> is represented in other languages.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Programming Language
    /// </term>
    /// <term>
    /// String Representation
    /// </term>
    /// </listheader>
    /// <term>
    /// C++/WinRT
    /// </term>
    /// <term>
    /// winrt::hstring class
    /// </term>
    /// <item>
    /// <term>
    /// Visual C++ component extensions (C++/CX)
    /// </term>
    /// <term>
    /// Platform::String class
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// JavaScript
    /// </term>
    /// <term>
    /// String object
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// .NET Framework
    /// </term>
    /// <term>
    /// System.String class
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The <see cref="HSTRING"/> handle is a standard handle type.
    /// Semantically, an <see cref="HSTRING"/> containing the value <see cref="NULL"/> represents the empty string,
    /// which consists of zero content characters and a terminating <see cref="NULL"/> character.
    /// Creating a string via <see cref="WindowsCreateString"/> with zero characters will produce the handle value <see cref="NULL"/>.
    /// When calling <see cref="WindowsGetStringRawBuffer"/> with the value <see cref="NULL"/>,
    /// a pointer to an empty string followed only by the NUL terminating character will be returned.
    /// No distinct value exists to represent an <see cref="HSTRING"/> that is uninitialized.
    /// </para>
    /// <para>
    /// Call the <see cref="WindowsCreateString"/> function to create a new <see cref="HSTRING"/>,
    /// and call the <see cref="WindowsDeleteString"/> function to release the reference to the backing string memory.
    /// Call the <see cref="WindowsCreateStringReference"/> function to create a string reference, which is also called a fast-pass string.
    /// </para>
    /// <para>
    /// Copy an <see cref="HSTRING"/> by calling the <see cref="WindowsDuplicateString"/> function.
    /// </para>
    /// <para>
    /// Concatenate two strings by calling the <see cref="WindowsConcatString"/> function.
    /// </para>
    /// <para>
    /// Access the backing string memory by calling the <see cref="WindowsGetStringRawBuffer"/> function.
    /// </para>
    /// <para>
    /// <see cref="HSTRING"/> can store and use embedded NUL characters.
    /// Use the <see cref="WindowsStringHasEmbeddedNull"/> function to check for embedded NUL characters
    /// before using any functions which may produce unexpected results.
    /// For example, most of the Windows functions use <see cref="LPCWSTR"/> as an input parameter,
    /// and they compute the length of the string only until the first NUL is encountered.
    /// </para>
    /// <para>
    /// The backing string must remain immutable and null-terminated.
    /// When calling code creates a string reference by using the <see cref="WindowsCreateStringReference"/> function,
    /// the memory containing the backing string representation is owned by the caller.
    /// The Windows Runtime relies on the contents of the original string to remain unchanged.
    /// When passing a string reference into the Windows Runtime,
    /// it is the caller’s responsibility to ensure that the string’s contents are unchanging and NUL terminated for the duration of the call.
    /// The Windows Runtime releases all references to the string reference when the call returns.
    /// </para>
    /// <para>
    /// When you receive an <see cref="HSTRING"/> as an out parameter,
    /// it is good practice to set the handle to <see cref="NULL"/> when you are finished with it.
    /// </para>
    /// <para>
    /// Call the <see cref="WindowsPreallocateStringBuffer"/> function to allocate a mutable string buffer that you can use to create an immutable <see cref="HSTRING"/>.
    /// When you have finished populating the buffer, you call the <see cref="WindowsPromoteStringBuffer"/> function to create the <see cref="HSTRING"/>.
    /// This two-phase construction pattern enables functionality that is similar to a "string builder."
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct HSTRING : IPointer
    {
        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <inheritdoc/>
        public nint ToNint() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(HSTRING val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HSTRING(nint val) => new HSTRING { _value = val };
    }
}
