using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines the values used with the <see cref="IShellFolder.GetDisplayNameOf"/> and <see cref="IShellFolder.SetNameOf"/> methods
    /// to specify the type of file or folder names used by those methods.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ne-shobjidl_core-_shgdnf
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="SHGDNF"/> type is defined in Shobjidl.h as shown here.
    /// <code>
    /// typedef DWORD SHGDNF;
    /// </code>
    /// This enumeration consists of two groups of values.
    /// The first group—SHGDN_NORMAL and SHGDN_INFOLDER—specifies the name's type.
    /// The second group—SHGDN_FOREDITING, SHGDN_FORADDRESSBAR, and SHGDN_FORPARSING—consists of modifiers to the first group
    /// that specify name retrieval options.
    /// If <see cref="SHGDN_FORPARSING"/> is set and <see cref="SHGDN_INFOLDER"/> is not set,
    /// <see cref="IShellFolder.GetDisplayNameOf"/> can accept a PIDL that contains more than an <see cref="SHITEMID"/> structure.
    /// Otherwise, only a single-level PIDL can be passed.
    /// Note While the parsing name returned by file system objects is the object's fully qualified path,
    /// virtual folders might use something quite different.
    /// For example, some virtual folders use a GUID as the parsing name and return a string of the form "::{GUID}".
    /// To check whether the object is part of the file system, call <see cref="IShellFolder.GetAttributesOf"/>
    /// and see if the <see cref="SFGAO_FILESYSTEM"/> flag is set.
    /// Developers who implement <see cref="IShellFolder.GetDisplayNameOf"/> are encouraged to return parse names
    /// that are as close to the display names as possible, because the end user often needs to type or edit these names.
    /// The numeric value of <see cref="SHGDN_NORMAL"/> is zero, so you cannot test for the presence of this bit.
    /// Consider <see cref="SHGDN_NORMAL"/> a default setting that is used if no other flag in that group is set.
    /// </remarks>
    [Flags]
    public enum SHGDNF
    {
        /// <summary>
        /// When not combined with another flag, return the parent-relative name that identifies the item, suitable for displaying to the user.
        /// This name often does not include extra information such as the file name extension and does not need to be unique.
        /// This name might include information that identifies the folder that contains the item.
        /// For instance, this flag could cause <see cref="GetDisplayNameOf"/> to return the string "username (on Machine)" for a particular user's folder.
        /// </summary>
        SHGDN_NORMAL = 0,

        /// <summary>
        /// The name is relative to the folder from which the request was made.
        /// This is the name display to the user when used in the context of the folder.
        /// For example, it is used in the view and in the address bar path segment for the folder.
        /// This name should not include disambiguation information—for instance "username" instead of "username (on Machine)"
        /// for a particular user's folder.
        /// Use this flag in combinations with <see cref="SHGDN_FORPARSING"/> and <see cref="SHGDN_FOREDITING"/>.
        /// </summary>
        SHGDN_INFOLDER = 0x1,

        /// <summary>
        /// The name is used for in-place editing when the user renames the item.
        /// </summary>
        SHGDN_FOREDITING = 0x1000,

        /// <summary>
        /// The name is displayed in an address bar combo box.
        /// </summary>
        SHGDN_FORADDRESSBAR = 0x4000,

        /// <summary>
        /// The name is used for parsing.
        /// That is, it can be passed to <see cref="IShellFolder.ParseDisplayName"/> to recover the object's PIDL.
        /// The form this name takes depends on the particular object.
        /// When <see cref="SHGDN_FORPARSING"/> is used alone, the name is relative to the desktop.
        /// When combined with <see cref="SHGDN_INFOLDER"/>, the name is relative to the folder from which the request was made.
        /// </summary>
        SHGDN_FORPARSING = 0x8000,
    }
}
