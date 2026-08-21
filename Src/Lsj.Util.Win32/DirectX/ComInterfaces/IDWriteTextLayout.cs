using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDWriteTextLayout"/> interface represents a block of text after it has been fully analyzed and formatted.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextlayout"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To get a reference to the <see cref="IDWriteTextLayout"/> interface,
    /// the application must call the <see cref="IDWriteFactory.CreateTextLayout"/> method, as shown in the following code.
    /// </para>
    /// <code>
    /// // Create a text layout using the text format.
    /// if (SUCCEEDED(hr))
    /// {
    ///     RECT rect;
    ///     GetClientRect(hwnd_, &amp;rect); 
    ///     float width  = rect.right  / dpiScaleX_;
    ///     float height = rect.bottom / dpiScaleY_;
    /// 
    ///     hr = pDWriteFactory_-&gt;CreateTextLayout(
    ///         wszText_,      // The string to be laid out and formatted.
    ///         cTextLength_,  // The length of the string.
    ///         pTextFormat_,  // The text format to apply to the string (contains font information, etc).
    ///         width,         // The width of the layout box.
    ///         height,        // The height of the layout box.
    ///         &amp;pTextLayout_  // The IDWriteTextLayout interface pointer.
    ///         );
    /// }
    /// </code>
    /// <para>
    /// The <see cref="IDWriteTextLayout"/> interface allows the application to change the format
    /// for ranges of the text it represents, specified by a <see cref="DWRITE_TEXT_RANGE"/> structure.
    /// The following example shows how to set the font weight for a text range.
    /// </para>
    /// <code>
    /// // Set the font weight to bold for the first 5 letters.
    /// DWRITE_TEXT_RANGE textRange = {0, 4};
    /// 
    /// if (SUCCEEDED(hr))
    /// {
    ///     hr = pTextLayout_-&gt;SetFontWeight(DWRITE_FONT_WEIGHT_BOLD, textRange);
    /// }
    /// </code>
    /// <para>
    /// <see cref="IDWriteTextLayout"/> also provides methods for adding strikethrough, underline, and inline objects to the text.
    /// </para>
    /// <para>
    /// To draw the block of text represented by an <see cref="IDWriteTextLayout"/> object,
    /// Direct2D provides the <see cref="ID2D1RenderTarget.DrawTextLayout"/> method.
    /// To draw using a custom renderer implement an <see cref="IDWriteTextRenderer"/> interface
    /// and call the <see cref="IDWriteTextLayout.Draw"/> method
    /// </para>
    /// <para>
    /// DirectWrite and Direct2D
    /// </para>
    /// <para>
    /// To draw a formatted string represented by an <see cref="IDWriteTextLayout"/> object,
    /// Direct2D provides the <see cref="ID2D1RenderTarget.DrawTextLayout"/> method.
    /// </para>
    /// <para>
    /// Other Rendering Options
    /// </para>
    /// <para>
    /// To render using a custom renderer, use the <see cref="IDWriteTextLayout.Draw"/> method,
    /// which takes a callback interface derived from <see cref="IDWriteTextRenderer"/> as an argument, as shown in the following code.
    /// </para>
    /// <code>
    /// // Draw the text layout using DirectWrite and the CustomTextRenderer class.
    /// hr = pTextLayout_-&gt;Draw(
    ///         NULL,
    ///         pTextRenderer_,  // Custom text renderer.
    ///         origin.x,
    ///         origin.y
    ///         );
    /// </code>
    /// <para>
    /// <see cref="IDWriteTextRenderer"/> declares methods for drawing a glyph run, underline, strikethrough and inline objects.
    /// It is up to the application to implement these methods.
    /// Creating a custom text renderer allows the application to apply additional effects
    /// when rendering text, such as a custom fill or outline.
    /// </para>
    /// <para>
    /// Using a custom text renderer also enables you to render using another technology, such as GDI.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "53737037-6d14-410b-9bfe-0b182bb70961", BeginVTableSlotIndex = 28, EndVTableSlotIndex = 66,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDWriteTextFormat)])]
    public unsafe struct IDWriteTextLayout
    {
        nint* _vTable;
    }
}
