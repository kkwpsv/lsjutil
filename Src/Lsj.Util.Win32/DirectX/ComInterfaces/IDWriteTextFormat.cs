using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDWriteTextFormat"/> interface describes the font and paragraph properties used to format text, and it describes locale information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextformat"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To get a reference to the <see cref="IDWriteTextFormat"/> interface,
    /// the application must call the <see cref="IDWriteFactory.CreateTextFormat"/> method as shown in the following code.
    /// </para>
    /// <code>
    /// if (SUCCEEDED(hr))
    /// {
    ///     hr = pDWriteFactory_-&gt;CreateTextFormat(
    ///         L"Gabriola",
    ///         NULL,
    ///         DWRITE_FONT_WEIGHT_REGULAR,
    ///         DWRITE_FONT_STYLE_NORMAL,
    ///         DWRITE_FONT_STRETCH_NORMAL,
    ///         72.0f,
    ///         L"en-us",
    ///         &amp;pTextFormat_
    ///         );
    /// }
    /// </code>
    /// <para>
    /// When creating an <see cref="IDWriteTextFormat"/> object using the <see cref="IDWriteFactory.CreateTextFormat"/> function, 
    /// the application specifies the font family, font collection, font weight, font size, and locale name for the text format.
    /// </para>
    /// <para>
    /// These properties cannot be changed after the <see cref="IDWriteTextFormat"/> object is created.
    /// To change these properties, a new <see cref="IDWriteTextFormat"/> object must be created with the desired properties.
    /// </para>
    /// <para>
    /// The <see cref="IDWriteTextFormat"/> interface is used to draw text with a single format
    /// </para>
    /// <para>
    /// To draw text with multiple formats, or to use a custom text renderer, use the <see cref="IDWriteTextLayout"/> interface.
    /// <see cref="IDWriteTextLayout"/> enables the application to change the format for ranges of text within the string.
    /// The <see cref="IDWriteFactory.CreateTextLayout"/> takes an <see cref="IDWriteTextFormat"/> object as a parameter
    /// and initially applies the format information to the entire string.
    /// </para>
    /// <para>
    /// This object may not be thread-safe, and it may carry the state of text format change.
    /// </para>
    /// <para>
    /// DirectWrite and Direct2D
    /// </para>
    /// <para>
    /// To draw simple text with a single format, Direct2D provides the <see cref="ID2D1RenderTarget.DrawText"/> method,
    /// which draws a string using the format information provided by an <see cref="IDWriteTextFormat"/> object.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "9c906818-31d7-4fd3-a151-7c5e225db55a", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 27, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDWriteTextFormat
    {
        nint* _vTable;
    }
}
