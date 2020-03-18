using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a generalized clipboard format.
    /// It is enhanced to encompass a target device, the aspect or view of the data, and a storage medium indicator.
    /// Where one might expect to find a clipboard format, OLE uses a <see cref="FORMATETC"/> data structure instead.
    /// This structure is used as a parameter in OLE functions and methods that require data format information.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-formatetc
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="FORMATETC"/> structure is used by methods in the data transfer and presentation interfaces
    /// as a parameter specifying the data being transferred.
    /// For example, the <see cref="IDataObject.GetData"/> method uses the <see cref="FORMATETC"/> structure to
    /// indicate exactly what kind of data the caller is requesting.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FORMATETC
    {
        /// <summary>
        /// The clipboard format of interest. There are three types of formats recognized by OLE:
        /// Standard interchange formats, such as CF_TEXT.
        /// Private application formats understood only by the application offering the format, or by other applications offering similar features.
        /// OLE formats, which are used to create linked or embedded objects.
        /// </summary>
        public CLIPFORMAT cfFormat;

        /// <summary>
        /// A pointer to a <see cref="DVTARGETDEVICE"/> structure containing information about the target device for which the data is being composed.
        /// A <see cref="IntPtr.Zero"/> value is used whenever the specified data format is independent of the target device or
        /// when the caller doesn't care what device is used.
        /// In the latter case, if the data requires a target device, the object should pick an appropriate default device
        /// (often the display for visual components).
        /// Data obtained from an object with a <see cref="IntPtr.Zero"/> target device, such as most metafiles,
        /// is independent of the target device.
        /// The resulting data is usually the same as it would be if the user chose the Save As command from the File menu
        /// and selected an interchange format.
        /// </summary>
        public IntPtr ptd;

        /// <summary>
        /// Indicates how much detail should be contained in the rendering.
        /// This parameter should be one of the <see cref="DVASPECT"/> enumeration values.
        /// A single clipboard format can support multiple aspects or views of the object.
        /// Most data and presentation transfer and caching methods pass aspect information.
        /// For example, a caller might request an object's iconic picture, using the metafile clipboard format to retrieve it.
        /// Note that only one <see cref="DVASPECT"/> value can be used in <see cref="dwAspect"/>.
        /// That is, <see cref="dwAspect"/> cannot be the result of a Boolean OR operation on several <see cref="DVASPECT"/> values.
        /// </summary>
        public DVASPECT dwAspect;

        /// <summary>
        /// Part of the aspect when the data must be split across page boundaries.
        /// The most common value is -1, which identifies all of the data.
        /// For the aspects <see cref="DVASPECT_THUMBNAIL"/> and <see cref="DVASPECT_ICON"/>, lindex is ignored.
        /// </summary>
        public int lindex;

        /// <summary>
        /// One of the <see cref="TYMED"/> enumeration constants which indicate the type of storage medium used to transfer the object's data.
        /// Data can be transferred using whatever medium makes sense for the object.
        /// For example, data can be passed using global memory, a disk file, or structured storage objects.
        /// For more information, see the <see cref="TYMED"/> enumeration.
        /// </summary>
        public TYMED tymed;
    }
}
