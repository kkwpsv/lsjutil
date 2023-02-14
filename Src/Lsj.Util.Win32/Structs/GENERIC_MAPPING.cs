using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GENERIC_MAPPING"/> structure defines the mapping of generic access rights to specific and standard access rights for an object.
    /// When a client application requests generic access to an object, that request is mapped to the access rights defined in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-generic_mapping"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GENERIC_MAPPING
    {
        /// <summary>
        /// Specifies an access mask defining read access to an object.
        /// </summary>
        public ACCESS_MASK GenericRead;

        /// <summary>
        /// Specifies an access mask defining write access to an object.
        /// </summary>
        public ACCESS_MASK GenericWrite;

        /// <summary>
        /// Specifies an access mask defining execute access to an object.
        /// </summary>
        public ACCESS_MASK GenericExecute;

        /// <summary>
        /// Specifies an access mask defining all possible types of access to an object.
        /// </summary>
        public ACCESS_MASK GenericAll;
    }
}
