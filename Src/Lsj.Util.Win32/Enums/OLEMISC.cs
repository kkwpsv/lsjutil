﻿using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Describes miscellaneous characteristics of an object or class of objects.
    /// A container can call the <see cref="IOleObject.GetMiscStatus"/> method to determine the <see cref="OLEMISC"/> bits set for an object.
    /// The values specified in an object server's CLSID\MiscStatus entry in the registration database are based on the <see cref="OLEMISC"/> enumeration.
    /// These constants are also used in the <see cref="OBJECTDESCRIPTOR.dwStatus"/> member of the <see cref="OBJECTDESCRIPTOR"/> structure.
    /// </para>
    /// </summary>
    public enum OLEMISC : uint
    {
        /// <summary>
        /// When the container resizes the space allocated to displaying one of the object's presentations, the object wants to recompose the presentation.
        /// This means that on resize, the object wants to do more than scale its picture.
        /// If this bit is set, the container should force the object to the running state and call <see cref="IOleObject.SetExtent"/> with the new size.
        /// </summary>
        OLEMISC_RECOMPOSEONRESIZE = 0x1,

        /// <summary>
        /// The object has no useful content view other than its icon. From the user's perspective,
        /// the Display As Icon check box (in the Paste Special dialog box) for this object should always be checked,
        /// and should not be uncheckable. Note that such an object should still have a drawable content aspect; it will look the same as its icon view.
        /// </summary>
        OLEMISC_ONLYICONIC = 0x2,

        /// <summary>
        /// The object has initialized itself from the data in the container's current selection.
        /// Containers should examine this bit after calling <see cref="IOleObject.InitFromData"/> to initialize an object from the current selection.
        /// If set, the container should insert the object beside the current selection rather than replacing the current selection.
        /// If this bit is not set, the object being inserted replaces the current selection.
        /// </summary>
        OLEMISC_INSERTNOTREPLACE = 0x4,

        /// <summary>
        /// This object is a static object, which is an object that contains only a presentation;
        /// it contains no native data. See <see cref="OleCreateStaticFromData"/>.
        /// </summary>
        OLEMISC_STATIC = 0x8,

        /// <summary>
        /// This object cannot be the link source that when bound to activates (runs) the object.
        /// If the object is selected and copied to the clipboard, the object's container can offer a link in a clipboard data transfer that,
        /// when bound, must connect to the outside of the object.
        /// The user would see the object selected in its container, not open for editing.
        /// Rather than doing this, the container can simply refuse to offer a link source when transferring objects with this bit set.
        /// Examples of objects that have this bit set include OLE1 objects, static objects, and links.
        /// </summary>
        OLEMISC_CANTLINKINSIDE = 0x10,

        /// <summary>
        /// This object can be linked to by OLE 1 containers.
        /// This bit is used in the <see cref="OBJECTDESCRIPTOR.dwStatus"/> member of the <see cref="OBJECTDESCRIPTOR"/> structure
        /// transferred with the Object and Link Source Descriptor formats.
        /// An object can be linked to by OLE 1 containers if it is an untitled document, a file, or a selection of data within a file.
        /// Embedded objects or pseudo-objects that are contained within an embedded object cannot be linked to by OLE 1 containers
        /// (i.e., OLE 1 containers cannot link to link sources that, when bound, require more than one object server to be run.
        /// </summary>
        OLEMISC_CANLINKBYOLE1 = 0x20,

        /// <summary>
        /// This object is a link object.
        /// This bit is significant to OLE 1 and is set by the OLE 2 link object; object applications have no need to set this bit.
        /// </summary>
        OLEMISC_ISLINKOBJECT = 0x40,

        /// <summary>
        /// This object is capable of activating in-place, without requiring installation of menus and toolbars to run.
        /// Several such objects can be active concurrently. Some containers, such as forms, may choose to activate such objects automatically.
        /// </summary>
        OLEMISC_INSIDEOUT = 0x80,

        /// <summary>
        /// This bit is set only when <see cref="OLEMISC_INSIDEOUT"/> is set,
        /// and indicates that this object prefers to be activated whenever it is visible.
        /// Some containers may always ignore this hint.
        /// </summary>
        OLEMISC_ACTIVATEWHENVISIBLE = 0x100,

        /// <summary>
        /// This object does not pay any attention to target devices. Its presention data will be the same in all cases.
        /// </summary>
        OLEMISC_RENDERINGISDEVICEINDEPENDENT = 0x200,

        /// <summary>
        /// This value is used with controls.
        /// It indicates that the control has no run-time user interface, but that it should be visible at design time.
        /// For example, a timer control that fires a specific event periodically would not show itself at run time,
        /// but it needs a design-time user interface so a form designer can set the event period and other properties.
        /// </summary>
        OLEMISC_INVISIBLEATRUNTIME = 0x400,

        /// <summary>
        /// This value is used with controls. It tells the container that this control always wants to be running.
        /// As a result, the container should call OleRun when loading or creating the object.
        /// </summary>
        OLEMISC_ALWAYSRUN = 0x800,

        /// <summary>
        /// This value is used with controls.
        /// It indicates that the control is buttonlike in that it understands and obeys the container's DisplayAsDefault ambient property.
        /// </summary>
        OLEMISC_ACTSLIKEBUTTON = 0x1000,

        /// <summary>
        /// This value is used with controls.
        /// It marks the control as a label for whatever control comes after it in the form's ordering.
        /// Pressing a mnemonic key for a label control activates the control after it.
        /// </summary>
        OLEMISC_ACTSLIKELABEL = 0x2000,

        /// <summary>
        /// This value is used with controls.
        /// It indicates that the control has no UI active state, meaning that it requires no in-place tools, no shared menu,
        /// and no accelerators. It also means that the control never needs the focus.
        /// </summary>
        OLEMISC_NOUIACTIVATE = 0x4000,

        /// <summary>
        /// This value is used with controls.
        /// It indicates that the control understands how to align itself within its display rectangle,
        /// according to alignment properties such as left, center, and right.
        /// </summary>
        OLEMISC_ALIGNABLE = 0x8000,

        /// <summary>
        /// This value is used with controls.
        /// It indicates that the control is a simple grouping of other controls and does little more than pass Windows messages
        /// to the control container managing the form.
        /// Controls of this sort require the implementation of <see cref="ISimpleFrameSite"/> on the container's site.
        /// </summary>
        OLEMISC_SIMPLEFRAME = 0x10000,

        /// <summary>
        /// This value is used with controls.
        /// It indicates that the control wants to use <see cref="IOleObject.SetClientSite"/> as its initialization function,
        /// even before a call such as <see cref="IPersistStreamInit.InitNew"/> or <see cref="IPersistStorage.InitNew"/>.
        /// This allows the control to access a container's ambient properties before loading information from persistent storage.
        /// Note that the current implementations of <see cref="OleCreate"/>, <see cref="OleCreateFromData"/>,
        /// <see cref="OleCreateFromFile"/>, <see cref="OleLoad"/>, and the default handler do not understand this value.
        /// Control containers that wish to honor this value must currently implement their own versions of these functions
        /// in order to establish the correct initialization sequence for the control.
        /// </summary>
        OLEMISC_SETCLIENTSITEFIRST = 0x20000,

        /// <summary>
        /// Obsolete.
        /// A control that works with an Input Method Editor (IME) system component can control the state of the IME
        /// through the IMEMode property rather than using this value in the <see cref="OLEMISC"/> enumeration.
        /// You can use an IME component to enter information in Asian character sets with a regular keyboard.
        /// A Japanese IME, for example, allows you to type a word such as "sushi," on a regular keyboard and when you hit the spacebar,
        /// the IME component converts that word to appropriate kanji or proposes possible choices.
        /// The <see cref="OLEMISC_IMEMODE"/> value was previously used to mark a control as capable of controlling an IME mode system component.
        /// </summary>
        [Obsolete]
        OLEMISC_IMEMODE = 0x40000,

        /// <summary>
        /// For new ActiveX controls to work in an older container, the control may need to have the <see cref="OLEMISC_ACTIVATEWHENVISIBLE"/> value set.
        /// However, in a newer container that understands and uses <see cref="IPointerInactive"/>,
        /// the control does not wish to be in-place activated when it becomes visible.
        /// To allow the control to work in both kinds of containers, the control can set this value.
        /// Then, the container ignores <see cref="OLEMISC_ACTIVATEWHENVISIBLE"/> and does not in-place activate the control when it becomes visible.
        /// </summary>
        OLEMISC_IGNOREACTIVATEWHENVISIBLE = 0x80000,

        /// <summary>
        /// A control that can merge its menu with its container sets this value.
        /// </summary>
        OLEMISC_WANTSTOMENUMERGE = 0x100000,

        /// <summary>
        /// A control that supports multi-level undo sets this value.
        /// </summary>
        OLEMISC_SUPPORTSMULTILEVELUNDO = 0x200000
    }
}
