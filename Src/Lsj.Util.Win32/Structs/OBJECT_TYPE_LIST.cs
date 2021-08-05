using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.OBJECT_TYPE_LISTLevels;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="OBJECT_TYPE_LIST"/> structure identifies an object type element in a hierarchy of object types.
    /// The <see cref="AccessCheckByType"/> functions use an array of <see cref="OBJECT_TYPE_LIST"/> structures
    /// to define a hierarchy of an object and its subobjects, such as property sets and properties.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-object_type_list"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OBJECT_TYPE_LIST
    {
        /// <summary>
        /// Specifies the level of the object type in the hierarchy of an object and its subobjects.
        /// Level zero indicates the object itself.
        /// Level one indicates a subobject of the object, such as a property set. Level two indicates a subobject of the level one subobject, such as a property.
        /// There can be a maximum of five levels numbered zero through four.
        /// Directory service objects use the following level values.
        /// <see cref="ACCESS_OBJECT_GUID"/>, <see cref="ACCESS_PROPERTY_SET_GUID"/>, <see cref="ACCESS_PROPERTY_GUID"/>
        /// </summary>
        public OBJECT_TYPE_LISTLevels Level;

        /// <summary>
        /// Should be zero. Reserved for future use.
        /// </summary>
        public WORD Sbz;

        /// <summary>
        /// A pointer to the GUID for the object or subobject.
        /// </summary>
        public IntPtr ObjectType;
    }
}
