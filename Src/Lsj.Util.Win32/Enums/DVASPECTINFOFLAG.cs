using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates whether an object can support optimized drawing of itself.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/ocidl/ne-ocidl-dvaspectinfoflag"/>
    /// </para>
    /// </summary>
    public enum DVASPECTINFOFLAG
    {
        /// <summary>
        /// Indicates that the object can support optimized rendering of itself.
        /// Because most objects on a form share the same font, background color, and border types,
        /// leaving these values in the device context allows the next object to use them without having to re-select them.
        /// Specifically, the object can leave the font, brush, and pen selected on return
        /// from the <see cref="IViewObject.Draw"/> method instead of deselecting these from the device context.
        /// The container then must deselect these values at the end of the overall drawing process.
        /// The object can also leave other drawing state changes in the device context, such as the background color, the text color,
        /// raster operation code, the current point, the line drawing, and the poly fill mode.
        /// The object cannot change state values unless other objects are capable of restoring them.
        /// For example, the object cannot leave a changed mode, transformation value, selected bitmap, clip region, or metafile.
        /// </summary>
        DVASPECTINFOFLAG_CANOPTIMIZE = 1,
    }
}
