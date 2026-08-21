using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that request a thumbnail image from a Shell folder.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iextractimage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// There are two steps in the process:
    /// First, use <see cref="GetLocation"/> to request the path description of an image and specify how the image should be rendered.
    /// Then, call <see cref="Extract"/> to extract the image.
    /// </para>
    /// <para>
    /// If the object is free-threaded it must also expose an <see cref="IRunnableTask"/> interface so it can be stopped and started as needed.
    /// This feature can be particularly useful when extraction may be slow.
    /// </para>
    /// <para>
    /// Implement <see cref="IExtractImage"/> if your namespace extension needs to provide thumbnail images to be displayed in a Shellview.
    /// </para>
    /// <para>
    /// Use <see cref="IExtractImage"/> if you are implementing a view of namespace objects, and want to display thumbnail images.
    /// You can use a Shell folder's <see cref="IShellFolder.GetUIObjectOf"/> method to bind to its <see cref="IExtractImage"/> interface.
    /// </para>
    /// </remarks>
    public unsafe struct IExtractImage
    {
        nint* _vTable;
    }
}
