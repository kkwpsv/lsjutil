using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Determines the types of items included in an enumeration.
    /// These values are used with the <see cref="IShellFolder.EnumObjects"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-_shcontf"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// By setting the <see cref="SHCONTF_INIT_ON_FIRST_NEXT"/> flag, the calling application suggests 
    /// that the <see cref="IShellFolder.EnumObjects"/> method can expedite the enumeration process by returning an uninitialized enumeration object.
    /// Initialization can be deferred until the enumeration process starts.
    /// If initializing the enumeration object is a lengthy process, the method implementation should immediately return an uninitialized object.
    /// Defer initialization until the first time the <see cref="IEnumIDList.Next"/> method is called.
    /// If initialization requires user input, the method implementation should use hwnd as the parent window for the user interface.
    /// For an explanation of what to do when hwnd is set to <see cref="IntPtr.Zero"/>, see the <see cref="IShellFolder.EnumObjects"/> reference.
    /// The name of this enumeration was changed to <see cref="SHCONTF"/> in Windows Vista.
    /// Earlier, it was named <see cref="SHCONTF"/>.
    /// The name <see cref="SHCONTF"/> is still defined through a typedef statement, however, so it can continue to be used by legacy code.
    /// </remarks>
    [Flags]
    public enum SHCONTF
    {
        /// <summary>
        /// Windows 7 and later.
        /// The calling application is checking for the existence of child items in the folder.
        /// </summary>
        SHCONTF_CHECKING_FOR_CHILDREN = 0x10,

        /// <summary>
        /// Include items that are folders in the enumeration.
        /// </summary>
        SHCONTF_FOLDERS = 0x20,

        /// <summary>
        /// Include items that are not folders in the enumeration.
        /// </summary>
        SHCONTF_NONFOLDERS = 0x40,

        /// <summary>
        /// Include hidden items in the enumeration.
        /// This does not include hidden system items.
        /// (To include hidden system items, use <see cref="SHCONTF_INCLUDESUPERHIDDEN"/>.)
        /// </summary>
        SHCONTF_INCLUDEHIDDEN = 0x80,

        /// <summary>
        /// No longer used; always assumed.
        /// <see cref="IShellFolder.EnumObjects"/> can return without validating the enumeration object.
        /// Validation can be postponed until the first call to <see cref="IEnumIDList.Next"/>.
        /// Use this flag when a user interface might be displayed prior to the first <see cref="IEnumIDList.Next"/> call.
        /// For a user interface to be presented, hwnd must be set to a valid window handle.
        /// </summary>
        [Obsolete]
        SHCONTF_INIT_ON_FIRST_NEXT = 0x100,

        /// <summary>
        /// The calling application is looking for printer objects.
        /// </summary>
        SHCONTF_NETPRINTERSRCH = 0x200,

        /// <summary>
        /// The calling application is looking for resources that can be shared.
        /// </summary>
        SHCONTF_SHAREABLE = 0x400,

        /// <summary>
        /// Include items with accessible storage and their ancestors, including hidden items.
        /// </summary>
        SHCONTF_STORAGE = 0x800,

        /// <summary>
        /// Windows 7 and later.
        /// Child folders should provide a navigation enumeration.
        /// </summary>
        SHCONTF_NAVIGATION_ENUM = 0x1000,

        /// <summary>
        /// Windows Vista and later.
        /// The calling application is looking for resources that can be enumerated quickly.
        /// </summary>
        SHCONTF_FASTITEMS = 0x2000,

        /// <summary>
        /// Windows Vista and later.
        /// Enumerate items as a simple list even if the folder itself is not structured in that way.
        /// </summary>
        SHCONTF_FLATLIST = 0x4000,

        /// <summary>
        /// Windows Vista and later.
        /// The calling application is monitoring for change notifications.
        /// This means that the enumerator does not have to return all results.
        /// Items can be reported through change notifications.
        /// </summary>
        SHCONTF_ENABLE_ASYNC = 0x8000,

        /// <summary>
        /// Windows 7 and later.
        /// Include hidden system items in the enumeration.
        /// This value does not include hidden non-system items.
        /// (To include hidden non-system items, use <see cref="SHCONTF_INCLUDEHIDDEN"/>.)
        /// </summary>
        SHCONTF_INCLUDESUPERHIDDEN = 0x10000
    }
}
