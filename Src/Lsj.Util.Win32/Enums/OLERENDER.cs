using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DVASPECT;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the type of caching requested for newly created objects.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/ne-oleidl-olerender
    /// </para>
    /// </summary>
    public enum OLERENDER
    {
        /// <summary>
        /// The client is not requesting any locally cached drawing or data retrieval capabilities in the object.
        /// The pFormatEtc parameter of the calls is ignored when this value is specified for the renderopts parameter.
        /// </summary>
        OLERENDER_NONE = 0,

        /// <summary>
        /// The client will draw the content of the object on the screen (a NULL target device) using <see cref="IViewObject.Draw"/>.
        /// The object itself determines the data formats that need to be cached.
        /// With this render option, only the ptd and dwAspect members of pFormatEtc are significant,
        /// since the object may cache things differently depending on the parameter values.
        /// However, pFormatEtc can legally be NULL here, in which case the object is
        /// to assume the display target device and the <see cref="DVASPECT_CONTENT"/> aspect.
        /// </summary>
        OLERENDER_DRAW = 1,

        /// <summary>
        /// The client will pull one format from the object using <see cref="IDataObject.GetData"/>.
        /// The format of the data to be cached is passed in pFormatEtc, which may not in this case be <see cref="NULL"/>.
        /// </summary>
        OLERENDER_FORMAT = 2,

        /// <summary>
        /// The client is not requesting any locally cached drawing or data retrieval capabilities in the object.
        /// pFormatEtc is ignored for this option.
        /// The difference between this and the <see cref="OLERENDER_FORMAT"/> value is important
        /// in such functions as <see cref="OleCreateFromData"/> and <see cref="OleCreateLinkFromData"/>.
        /// </summary>
        OLERENDER_ASIS = 3
    }
}
