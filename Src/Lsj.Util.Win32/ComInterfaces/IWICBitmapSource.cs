using Lsj.Util.Win32.Attributes;
using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that refers to a source from which pixels are retrieved, but cannot be written back to.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapsource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface provides a common way of accessing and linking together bitmaps, decoders, format converters, and scalers.
    /// Components that implement this interface can be connected together in a graph to pull imaging data through.
    /// </para>
    /// <para>
    /// This interface defines only the notion of readability or being able to produce pixels.
    /// Modifying or writing to a bitmap is considered to be a specialization specific to bitmaps
    /// which have storage and is defined in the descendant interface <see cref="IWICBitmap"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
    [ComInterface(IID = "00000120-a8f2-4877-ba0a-fd2b6645fb94", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 7, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IWICBitmapSource
    {
        IntPtr* _vTable;
    }
}
