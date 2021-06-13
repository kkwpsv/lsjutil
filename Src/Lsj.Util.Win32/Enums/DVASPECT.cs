using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the desired data or view aspect of the object when drawing or getting data.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wtypes/ne-wtypes-dvaspect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Values of this enumeration are used to define the <see cref="FORMATETC.dwAspect"/> member of the <see cref="FORMATETC"/> structure.
    /// Only one <see cref="DVASPECT"/> value can be used to specify a single presentation aspect in a <see cref="FORMATETC"/> structure.
    /// The <see cref="FORMATETC"/> structure is used in many OLE functions and interface methods that require information on data presentation.
    /// The default value of MiscStatus is used if a subkey corresponding to the specified <see cref="DVASPECT"/> is not found.
    /// To set an OLE control, specify DVASPECT==1. This will cause the following to occur in the registry:
    /// <code>
    /// HKEY_CLASSES_ROOT\CLSID\ . . .
    /// MiscStatus = 1
    /// </code>
    /// </remarks>
    public enum DVASPECT
    {
        /// <summary>
        /// Provides a representation of an object so it can be displayed as an embedded object inside of a container.
        /// This value is typically specified for compound document objects.
        /// The presentation can be provided for the screen or printer.
        /// </summary>
        DVASPECT_CONTENT = 1,

        /// <summary>
        /// Provides a thumbnail representation of an object so it can be displayed in a browsing tool.
        /// The thumbnail is approximately a 120 by 120 pixel, 16-color (recommended) device-independent bitmap potentially wrapped in a metafile.
        /// </summary>
        DVASPECT_THUMBNAIL = 2,

        /// <summary>
        /// Provides an iconic representation of an object.
        /// </summary>
        DVASPECT_ICON = 4,

        /// <summary>
        /// Provides a representation of the object on the screen as though it were printed to a printer using the Print command from the File menu.
        /// The described data may represent a sequence of pages.
        /// </summary>
        DVASPECT_DOCPRINT = 8
    }
}
