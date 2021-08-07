using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.SELFLAG;
using static Lsj.Util.Win32.Oleacc;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods and properties that make a user interface element and its children accessible to client applications.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleacc/nn-oleacc-iaccessible"/>
    /// </para>
    /// </summary>
    public unsafe struct IAccessible
    {
        IntPtr* _vTable;

#pragma warning disable IDE1006 // 命名样式

        /// <summary>
        /// The <see cref="accSelect"/> method modifies the selection or moves the keyboard focus of the specified object.
        /// All objects that support selection or receive the keyboard focus must support this method.
        /// </summary>
        /// <param name="flagsSelect">
        /// Specifies which selection or focus operations are to be performed.
        /// This parameter must have a combination of the <see cref="SELFLAG"/> Constants.
        /// </param>
        /// <param name="varChild">
        /// Specifies the selected object.
        /// If the value is <see cref="CHILDID_SELF"/>, the object itself is selected; if a child ID, one of the object's child elements is selected.
        /// For more information about initializing the <see cref="VARIANT"/> structure, see How Child IDs Are Used in Parameters.
        /// </param>
        /// <returns>
        /// If successful, returns <see cref="S_OK"/>.
        /// If not successful, returns one of the values in the table that follows, or another standard COM error code.
        /// <see cref="S_FALSE"/>: The specified object is not selected.
        /// <see cref="E_INVALIDARG"/>:
        /// An argument is not valid.
        /// This return value means that the specified <see cref="SELFLAG"/> combination is not valid,
        /// or that the <see cref="SELFLAG"/> value does not make sense for the specified object.
        /// For example, the following flags are not allowed on a single-selection list box:
        /// <see cref="SELFLAG_EXTENDSELECTION"/>, <see cref="SELFLAG_ADDSELECTION"/>, and <see cref="SELFLAG_REMOVESELECTION"/>.
        /// <see cref="DISP_E_MEMBERNOTFOUND"/>:
        /// The object does not support this method.
        /// </returns>
        /// <remarks>
        /// Client applications use this method to perform complex selection operations.
        /// For more information, see Selecting Child Objects.
        /// This method provides the simplest way to programmatically switch the input focus between applications.
        /// This applies to applications running on Windows 2000.
        /// Note: This method is for the selection of items, not text.
        /// </remarks>
        public HRESULT accSelect([In] SELFLAG flagsSelect, [In] VARIANT varChild)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, SELFLAG, VARIANT, HRESULT>)_vTable[21])(thisPtr, flagsSelect, varChild);
            }
        }

        /// <summary>
        /// The <see cref="accLocation"/> method retrieves the specified object's current screen location.
        /// All visual objects must support this method. Sound objects do not support this method.
        /// </summary>
        /// <param name="pxLeft">
        /// Address, in physical screen coordinates, of the variable that receives the x-coordinate of the upper-left boundary of the object's location.
        /// </param>
        /// <param name="pyTop">
        /// Address, in physical screen coordinates, of the variable that receives the y-coordinate of the upper-left boundary of the object's location.
        /// </param>
        /// <param name="pcxWidth">
        /// Address, in pixels, of the variable that receives the object's width.
        /// </param>
        /// <param name="pcyHeight">
        /// Address, in pixels, of the variable that receives the object's height.
        /// </param>
        /// <param name="varChild">
        /// Specifies whether the location that the server returns should be that of the object or that of one of the object's child elements.
        /// This parameter is either <see cref="CHILDID_SELF"/> (to obtain information about the object)
        /// or a child ID (to obtain information about the object's child element).
        /// For more information about initializing the <see cref="VARIANT"/> structure, see How Child IDs Are Used in Parameters.
        /// </param>
        /// <returns>
        /// If successful, returns <see cref="S_OK"/>. Clients must always check that output parameters contain valid values.
        /// If not successful, returns one of the values in the table that follows, or another standard COM error code.
        /// For more information, see Checking IAccessible Return Values.
        /// <see cref="DISP_E_MEMBERNOTFOUND"/>: The object does not support this method.
        /// <see cref="E_INVALIDARG"/>: An argument is not valid.
        /// </returns>
        /// <remarks>
        /// This method retrieves the object's bounding rectangle.
        /// If the object has a non-rectangular shape, then this method returns the smallest rectangle
        /// that completely encompasses the entire object region.
        /// For non-rectangular objects, the coordinates of the object's bounding rectangle could fail if tested with <see cref="accHitTest"/>.
        /// Examples of such non-rectangular objects are list view items in large-icon mode
        /// where a single item has a rectangle for the icon and another rectangle for the text of the icon.
        /// Because accLocation returns a bounding rectangle, not all points in that rectangle will be within the actual bounds of the object.
        /// Some points within the bounding rectangle may not be on the object.
        /// For more information, see Navigation Through Hit Testing and Screen Location.
        /// Note:
        /// This method returns width and height.
        /// If you want the right and bottom coordinates, calculate them using right = left + width, and bottom = top + height.
        /// </remarks>
        public HRESULT accLocation([Out] out long pxLeft, [Out] out long pyTop, [Out] out long pcxWidth, [Out] out long pcyHeight, [In] VARIANT varChild)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out long, out long, out long, out long, VARIANT, HRESULT>)_vTable[22])
                    (thisPtr, out pxLeft, out pyTop, out pcxWidth, out pcyHeight, varChild);
            }
        }

        /// <summary>
        /// <para>
        /// The <see cref="accHitTest"/> method retrieves the child element or child object that is displayed at a specific point on the screen.
        /// All visual objects support this method, but sound objects do not.
        /// Client applications rarely call this method directly; to get the accessible object that is displayed at a point,
        /// use the <see cref="AccessibleObjectFromPoint"/> function, which calls this method internally.
        /// </para>
        /// </summary>
        /// <param name="xLeft">
        /// Specifies the screen coordinates of the point that is hit tested.
        /// The x-coordinates increase from left to right.
        /// Note that when screen coordinates are used, the origin is the upper-left corner of the screen.
        /// </param>
        /// <param name="yTop">
        /// Specifies the screen coordinates of the point that is hit tested.
        /// The y-coordinates increase from top to bottom.
        /// Note that when screen coordinates are used, the origin is the upper-left corner of the screen.
        /// </param>
        /// <param name="pvarChild">
        /// Address of a <see cref="VARIANT"/> that identifies the object displayed at the point
        /// specified by <paramref name="xLeft"/> and <paramref name="yTop"/>.
        /// The information returned in <paramref name="pvarChild"/> depends on the location of the specified point
        /// in relation to the object whose <see cref="accHitTest"/> method is being called.
        /// Point location
        /// vt member
        /// Value member
        /// Outside of the object's boundaries, and either inside or outside of the object's bounding rectangle.
        /// <see cref="VT_EMPTY"/>
        /// None.
        /// Within the object but not within a child element or a child object.
        /// <see cref="VT_I4"/>
        /// <see cref="VARIANT.lVal"/> is <see cref="CHILDID_SELF"/>.
        /// Within a child element.
        /// <see cref="VT_I4"/>
        /// <see cref="VARIANT.lVal"/> contains the child ID.
        /// Within a child object.
        /// <see cref="VT_DISPATCH"/>
        /// <see cref="VARIANT.pdispVal"/> is set to the child object's <see cref="IDispatch"/> interface pointer
        /// </param>
        /// <returns>
        /// If successful, returns <see cref="S_OK"/>.
        /// If not successful, returns one of the values in the table that follows, or another standard COM error code.
        /// Servers return these values, but clients must always check output parameters to ensure that they contain valid values.
        /// For more information, see Checking IAccessible Return Values.
        /// <see cref="S_FALSE"/>
        /// The point is outside of the object's boundaries. The <see cref="VARIANT.vt"/> member of <paramref name="pvarChild"/> is <see cref="VT_EMPTY"/>.
        /// <see cref="DISP_E_MEMBERNOTFOUND"/>
        /// The object does not support this method.
        /// <see cref="E_INVALIDARG"/>
        /// An argument is not valid.
        /// Note to client developers: 
        /// Although servers return <see cref="S_FALSE"/> if the <see cref="VARIANT.vt"/> member of <paramref name="pvarChild"/> is <see cref="VT_EMPTY"/>,
        /// clients must also handle the case where <see cref="VARIANT.vt"/> is <see cref="VT_EMPTY"/> and the return value is <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// If the tested point is on one of the object's children, and this child supports the <see cref="IAccessible"/> interface itself,
        /// this method should return an <see cref="IAccessible"/> interface pointer.
        /// However, clients should be prepared to handle an <see cref="IAccessible"/> interface pointer or a child ID.
        /// For more information, see How Child IDs Are Used in Parameters.
        /// Because <see cref="accLocation"/> returns a bounding rectangle, not all points in that rectangle will be within the actual bounds of the object.
        /// Some points within the bounding rectangle may not be on the object. For non-rectangular objects,
        /// such as list view items in large-icon mode where a single item has a rectangle for the icon and another rectangle for the text of the icon,
        /// the coordinates of the object's bounding rectangle retrieved by <see cref="accLocation"/> could fail if tested with <see cref="accHitTest"/>.
        /// As with other IAccessible methods and functions, clients might receive errors for <see cref="IAccessible"/> interface pointers because of a user action.
        /// For more information, see Receiving Errors for IAccessible Interface Pointers.
        /// When this method is used in certain situations, additional usage notes apply.
        /// For more information, see Navigation Through Hit Testing and Screen Location.
        /// </remarks>
        public HRESULT accHitTest([In] long xLeft, [In] long yTop, [Out] out VARIANT pvarChild)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, long, long, out VARIANT, HRESULT>)_vTable[24])(thisPtr, xLeft, yTop, out pvarChild);
            }
        }

#pragma warning restore IDE1006 // 命名样式
    }
}
