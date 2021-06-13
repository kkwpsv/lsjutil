namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Resource Types
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/menurc/resource-types"/>
    /// </para>
    /// </summary>
    public enum ResourceTypes : uint
    {
        /// <summary>
        /// Accelerator table.
        /// </summary>
        RT_ACCELERATOR = 9,

        /// <summary>
        /// Animated cursor.
        /// </summary>
        RT_ANICURSOR = 21,

        /// <summary>
        /// Animated icon.
        /// </summary>
        RT_ANIICON = 22,

        /// <summary>
        /// Bitmap resource.
        /// </summary>
        RT_BITMAP = 2,

        /// <summary>
        /// Hardware-dependent cursor resource.
        /// </summary>
        RT_CURSOR = 1,

        /// <summary>
        /// Dialog box.
        /// </summary>
        RT_DIALOG = 5,

        /// <summary>
        /// Allows a resource editing tool to associate a string with an .rc file.
        /// Typically, the string is the name of the header file that provides symbolic names.
        /// The resource compiler parses the string but otherwise ignores the value.
        /// For example,
        /// 1 DLGINCLUDE "MyFile.h"
        /// </summary>
        RT_DLGINCLUDE = 17,

        /// <summary>
        /// Font resource.
        /// </summary>
        RT_FONT = 8,

        /// <summary>
        /// Font directory resource.
        /// </summary>
        RT_FONTDIR = 7,

        /// <summary>
        /// Hardware-independent cursor resource.
        /// </summary>
        RT_GROUP_CURSOR = RT_CURSOR + 11,

        /// <summary>
        /// Hardware-independent icon resource.
        /// </summary>
        RT_GROUP_ICON = RT_ICON + 11,

        /// <summary>
        /// HTML resource.
        /// </summary>
        RT_HTML = 23,

        /// <summary>
        /// Hardware-dependent icon resource.
        /// </summary>
        RT_ICON = 3,

        /// <summary>
        /// Side-by-Side Assembly Manifest.
        /// </summary>
        RT_MANIFEST = 24,

        /// <summary>
        /// Menu resource.
        /// </summary>
        RT_MENU = 4,

        /// <summary>
        /// Message-table entry.
        /// </summary>
        RT_MESSAGETABLE = 11,

        /// <summary>
        /// Plug and Play resource.
        /// </summary>
        RT_PLUGPLAY = 19,

        /// <summary>
        /// Application-defined resource (raw data).
        /// </summary>
        RT_RCDATA = 10,

        /// <summary>
        /// String-table entry.
        /// </summary>
        RT_STRING = 6,

        /// <summary>
        /// Version resource.
        /// </summary>
        RT_VERSION = 16,

        /// <summary>
        /// VXD.
        /// </summary>
        RT_VXD = 20,
    }
}
