using Lsj.Util.Win32.Attributes;
using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Defines methods that add the concept of writeability and static in-memory representations of bitmaps to <see cref="IWICBitmapSource"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmap"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="IWICBitmap"/> inherits from <see cref="IWICBitmapSource"/>
    /// and therefore also inherits the <see cref="CopyPixels"/> method.
    /// When pixels need to be moved to a new memory location, <see cref="CopyPixels"/> is often the most efficient.
    /// </para>
    /// <para>
    /// Because of the internal memory representation implied by the <see cref="IWICBitmap"/>,
    /// in-place modification and processing using the <see cref="Lock"/> is more efficient than <see cref="CopyPixels"/>,
    /// usually reducing to a simple pointer access directly into the memory owned by the bitmap rather than a copy.
    /// This is contrasted to procedural bitmaps which implement only <see cref="CopyPixels"/>
    /// because there is no internal memory representation
    /// and one would need to be created on demand to satisfy a call to <see cref="Lock"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP2")]
    [ComInterface(IID = "00000120-a8f2-4877-ba0a-fd2b6645fb94", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 10,
        InheritedFromTypes = [typeof(IUnknown), typeof(IWICBitmapSource)])]
    public unsafe struct IWICBitmap
    {
        IntPtr* _vTable;
    }
}
