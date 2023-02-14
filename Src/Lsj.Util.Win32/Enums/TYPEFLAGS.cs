using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.Enums.TYPEKIND;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The type flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-typeflags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="TYPEFLAG_FAPPOBJECT"/> can be used on type descriptions with TypeKind = <see cref="TKIND_COCLASS"/>,
    /// and indicates that the type description specifies an Application object.
    /// Members of the Application object are globally accessible.
    /// The <see cref="ITypeComp.Bind"/> method of the <see cref="ITypeComp"/> instance associated with the library binds to the members of an Application object,
    /// just as it does for type descriptions that have TypeKind = <see cref="TKIND_MODULE"/>.
    /// The type description implicitly defines a global variable with the same name and type described by the type description.
    /// This variable is also globally accessible.
    /// When Bind is passed the name of an Application object, a <see cref="VARDESC"/> is returned, which describes the implicit variable.
    /// The ID of the implicitly created variable is always <see cref="ID_DEFAULTINST"/>.
    /// The <see cref="ITypeInfo.CreateInstance"/> function of an Application object type description is called,
    /// and then it uses <see cref="GetActiveObject"/> to retrieve the Application object.
    /// If <see cref="GetActiveObject"/> fails because the application is not running,
    /// then <see cref="ITypeInfo.CreateInstance"/> calls <see cref="CoCreateInstance"/>, which should start the application.
    /// When <see cref="TYPEFLAG_FCANCREATE"/> is set, <see cref="ITypeInfo.CreateInstance"/> can create an instance of this type.
    /// This is true only for component object classes for which a globally unique identifier (GUID) has been specified.
    /// </remarks>
    [Flags]
    public enum TYPEFLAGS
    {
        /// <summary>
        /// A type description that describes an Application object.
        /// </summary>
        TYPEFLAG_FAPPOBJECT = 0x1,

        /// <summary>
        /// Instances of the type can be created by <see cref="ITypeInfo.CreateInstance"/>.
        /// </summary>
        TYPEFLAG_FCANCREATE = 0x2,

        /// <summary>
        /// The type is licensed.
        /// </summary>
        TYPEFLAG_FLICENSED = 0x4,

        /// <summary>
        /// The type is predefined.
        /// The client application should automatically create a single instance of the object that has this attribute.
        /// The name of the variable that points to the object is the same as the class name of the object.
        /// </summary>
        TYPEFLAG_FPREDECLID = 0x8,

        /// <summary>
        /// The type should not be displayed to browsers.
        /// </summary>
        TYPEFLAG_FHIDDEN = 0x10,

        /// <summary>
        /// The type is a control from which other types will be derived, and should not be displayed to users.
        /// </summary>
        TYPEFLAG_FCONTROL = 0x20,

        /// <summary>
        /// The interface supplies both <see cref="IDispatch"/> and VTBL binding.
        /// </summary>
        TYPEFLAG_FDUAL = 0x40,

        /// <summary>
        /// The interface cannot add members at run time.
        /// </summary>
        TYPEFLAG_FNONEXTENSIBLE = 0x80,

        /// <summary>
        /// The types used in the interface are fully compatible with Automation, including VTBL binding support.
        /// Setting dual on an interface sets this flag in addition to <see cref="TYPEFLAG_FDUAL"/>.
        /// Not allowed on dispinterfaces.
        /// </summary>
        TYPEFLAG_FOLEAUTOMATION = 0x100,

        /// <summary>
        /// Should not be accessible from macro languages.
        /// This flag is intended for system-level types or types that type browsers should not display.
        /// </summary>
        TYPEFLAG_FRESTRICTED = 0x200,

        /// <summary>
        /// The class supports aggregation.
        /// </summary>
        TYPEFLAG_FAGGREGATABLE = 0x400,

        /// <summary>
        /// The type is replaceable.
        /// </summary>
        TYPEFLAG_FREPLACEABLE = 0x800,

        /// <summary>
        /// Indicates that the interface derives from <see cref="IDispatch"/>, either directly or indirectly.
        /// This flag is computed.
        /// There is no Object Description Language for the flag.
        /// </summary>
        TYPEFLAG_FDISPATCHABLE = 0x1000,

        /// <summary>
        /// The type has reverse binding.
        /// </summary>
        TYPEFLAG_FREVERSEBIND = 0x2000,

        /// <summary>
        /// Interfaces can be marked with this flag to indicate that they will be using a proxy/stub dynamic link library.
        /// This flag specifies that the typelib proxy should not be unregistered when the typelib is unregistered.
        /// </summary>
        TYPEFLAG_FPROXY = 0x4000
    }
}
