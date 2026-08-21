using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides the Media Engine with a list of media resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/nn-mfmediaengine-imfmediaenginesrcelements"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="IMFMediaEngineSrcElements"/> interface represents an ordered list of media resources.
    /// </para>
    /// <para>
    /// This interface enables the application to provide the same audio/video content
    /// in several different encoding formats, such as H.264 and Windows Media Video.
    /// If a particular codec is not present on the user's computer, the Media Engine will try the next URL in the list.
    /// To use this interface, do the following:
    /// </para>
    /// <para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Create an implementation of this interface.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Initialize your implementation with a list of URLs.
    /// Optionally, provide MIME types and media query strings for each URL.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call the <see cref="IMFMediaEngine.SetSourceElements"/> method.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "7a5e5354-b114-4c72-b991-3131d75032ea", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 8, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaEngineSrcElements
    {
        nint* _vTable;
    }
}
