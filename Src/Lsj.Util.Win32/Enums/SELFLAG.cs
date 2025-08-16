using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.Enums.ObjectStateConstants;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// This topic describes the constant values used to specify how an accessible object becomes selected or takes the focus.
    /// The constants are defined in oleacc.h and are used with the <see cref="IAccessible.accSelect"/> method.
    /// </para>
    /// <para>
    /// The following combinations are not allowed:
    /// </para>
    /// <para>
    /// Note to clients : Microsoft Active Accessibility does not support the selection of the text contained in edit and rich edit controls
    /// because the text is exposed as a string in the object's Value property.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <c>SELFLAG_ADDSELECTION | SELFLAG_REMOVESELECTION</c>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <c>SELFLAG_ADDSELECTION | SELFLAG_TAKESELECTION</c>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <c>SELFLAG_REMOVESELECTION | SELFLAG_TAKESELECTION</c>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <c>SELFLAG_EXTENDSELECTION | SELFLAG_TAKESELECTION</c>
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// For information on how to perform complex selection operations, see Selecting Child Objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winauto/selflag"/>
    /// </para>
    /// </summary>
    public enum SELFLAG
    {
        /// <summary>
        /// Performs no action.
        /// Microsoft Active Accessibility does not change the selection or focus.
        /// </summary>
        SELFLAG_NONE = 0,

        /// <summary>
        /// <para>
        /// Sets the focus to the object and makes it the selection anchor.
        /// Used by itself, this flag does not alter the selection.
        /// The effect is similar to moving the focus manually by pressing an ARROW key
        /// while holding down the CTRL key in Windows Explorer or in any multiple-selection list box.
        /// </para>
        /// <para>
        /// With objects that have the <see cref="STATE_SYSTEM_MULTISELECTABLE"/>, <see cref="SELFLAG_TAKEFOCUS"/> is combined with the following values:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_TAKESELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_EXTENDSELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_ADDSELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_REMOVESELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_ADDSELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_EXTENDSELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_REMOVESELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_EXTENDSELECTION"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If you call <see cref="IAccessible.accSelect"/> with the <see cref="SELFLAG_TAKEFOCUS"/> flag on an object that has an <see cref="HWND"/>,
        /// the flag will take effect only if the object's parent already has the focus.
        /// </para>
        /// </summary>
        SELFLAG_TAKEFOCUS = 0x1,


        /// <summary>
        /// <para>
        /// Selects the object and removes the selection from all other objects in the container.
        /// </para>
        /// <para>
        /// Unless it is combined with <see cref="SELFLAG_TAKEFOCUS"/>, this flag does not change the focus or the selection anchor.
        /// The <see cref="SELFLAG_TAKESELECTION"/> / <see cref="SELFLAG_TAKEFOCUS"/> combination
        /// is equivalent to single-clicking an item in Windows Explorer.
        /// </para>
        /// <para>
        /// This flag must not be combined with the following flags:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_ADDSELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_REMOVESELECTION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SELFLAG_EXTENDSELECTION"/>
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        SELFLAG_TAKESELECTION = 0x2,

        /// <summary>
        /// <para>
        /// Alters the selection so that all objects between the selection anchor and this object take on the anchor object's selection state.
        /// If the anchor object is not selected, the objects are removed from the selection.
        /// If the anchor object is selected, the selection is extended to include this object and all the objects in between.
        /// Set the selection state by combining this flag with <see cref="SELFLAG_ADDSELECTION"/> or <see cref="SELFLAG_REMOVESELECTION"/>.
        /// </para>
        /// <para>
        /// Unless it is combined with <see cref="SELFLAG_TAKEFOCUS"/>, this flag does not change the focus or the selection anchor.
        /// The <see cref="SELFLAG_EXTENDSELECTION"/> / <see cref="SELFLAG_TAKEFOCUS"/> combination is equivalent to adding an item to a selection
        /// manually by holding down the SHIFT key and clicking an unselected object in Windows Explorer.
        /// </para>
        /// <para>
        /// This flag is not combined with <see cref="SELFLAG_TAKESELECTION"/>.
        /// </para>
        /// </summary>
        SELFLAG_EXTENDSELECTION = 0x4,

        /// <summary>
        /// <para>
        /// Adds the object to the current selection; possible result is a noncontiguous selection.
        /// </para>
        /// <para>
        /// Unless it is combined with <see cref="SELFLAG_TAKEFOCUS"/>, this flag does not change the focus or the selection anchor.
        /// The <see cref="SELFLAG_ADDSELECTION"/> / <see cref="SELFLAG_TAKEFOCUS"/> combination is equivalent
        /// to adding an item to a selection manually by holding down the CTRL key and clicking an unselected object in Windows Explorer.
        /// </para>
        /// <para>
        /// This flag is not combined with <see cref="SELFLAG_REMOVESELECTION"/> or <see cref="SELFLAG_TAKESELECTION"/>.
        /// </para>
        /// </summary>
        SELFLAG_ADDSELECTION = 0x8,

        /// <summary>
        /// <para>
        /// Removes the object from the current selection; possible result is a noncontiguous selection.
        /// </para>
        /// <para>
        /// Unless it is combined with <see cref="SELFLAG_TAKEFOCUS"/>, this flag does not change the focus or the selection anchor.
        /// The <see cref="SELFLAG_REMOVESELECTION"/> / <see cref="SELFLAG_TAKEFOCUS"/> combination is equivalent to removing an item from a selection manually,
        /// by holding down the CTRL key while clicking a selected object in Windows Explorer.
        /// </para>
        /// <para>
        /// This flag is not combined with <see cref="SELFLAG_ADDSELECTION"/> or <see cref="SELFLAG_TAKESELECTION"/>.
        /// </para>
        /// </summary>
        SELFLAG_REMOVESELECTION = 0x10,

        /// <summary>
        /// SELFLAG_VALID
        /// </summary>
        SELFLAG_VALID = 0x1f,
    }
}
