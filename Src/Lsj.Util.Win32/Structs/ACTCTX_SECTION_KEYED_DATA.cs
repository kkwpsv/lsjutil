using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure is used by the <see cref="FindActCtxSectionString"/>
    /// and <see cref="FindActCtxSectionGuid"/> functions to return the activation context information
    /// along with either the GUID or 32-bit integer-tagged activation context section.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-actctx_section_keyed_data"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Callers should initialize the <see cref="ACTCTX_SECTION_KEYED_DATA"/> structure as such:
    /// </para>
    /// <c>
    /// ACTCTX_SECTION_KEYED_DATA askd = { sizeof(askd) };
    /// </c>
    /// <para>
    /// which initializes all members to zero/null except the size field which is set correctly.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACTCTX_SECTION_KEYED_DATA
    {
        /// <summary>
        /// The size, in bytes, of the activation context keyed data structure.
        /// </summary>
        public ULONG cbSize;

        /// <summary>
        /// Number that indicates the format of the data in the section where the key was found.
        /// Clients should verify that the data format version is as expected
        /// rather than trying to interpret the values of unfamiliar data formats.
        /// This number is only changed when major non-backward-compatible changes to the section data formats need to be made.
        /// The current format version is 1.
        /// </summary>
        public ULONG ulDataFormatVersion;

        /// <summary>
        /// Pointer to the redirection data found associated with the section identifier and key.
        /// </summary>
        public PVOID lpData;

        /// <summary>
        /// Number of bytes in the structure referred to by <see cref="lpData"/>.
        /// Note that the data structures grow over time;
        /// do not access members in the instance data that extend beyond <see cref="ulLength"/>.
        /// </summary>
        public ULONG ulLength;

        /// <summary>
        /// Returned pointer to a section-specific data structure which is global to the activation context section where the key was found.
        /// Its interpretation depends on the section identifier requested.
        /// </summary>
        public PVOID lpSectionGlobalData;

        /// <summary>
        /// <para>
        /// Number of bytes in the section global data block referred to by <see cref="lpSectionGlobalData"/>.
        /// </para>
        /// <para>
        /// Note that the data structures grow over time and you may receive an old format activation context data block;
        /// do not access members in the section global data that extend beyond <see cref="ulSectionGlobalDataLength"/>.
        /// </para>
        /// </summary>
        public ULONG ulSectionGlobalDataLength;

        /// <summary>
        /// Pointer to the base of the section where the key was found.
        /// Some instance data contains offsets relative to the section base address, in which case this pointer value is used.
        /// </summary>
        public PVOID lpSectionBase;

        /// <summary>
        /// Number of bytes for the entire section starting at <see cref="lpSectionBase"/>.
        /// May be used to verify that offset/length pairs,
        /// which are specified as relative to the section base are wholly contained in the section.
        /// </summary>
        public ULONG ulSectionTotalLength;

        /// <summary>
        /// <para>
        /// Handle to the activation context where the key was found.
        /// First, the active activation context for the thread is searched,
        /// followed by the process-default activation context and then the system-compatible-default-activation context.
        /// This member indicates which activation context contained the section and key requested.
        /// This is only returned if the <see cref="FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX"/> flag is passed.
        /// </para>
        /// <para>
        /// Note that when this is returned, the caller must call <see cref="ReleaseActCtx"/> on the activation context handle
        /// returned to release system resources when all other references to the activation context have been released.
        /// </para>
        /// </summary>
        public HANDLE hActCtx;

        /// <summary>
        /// Cardinal number of the assembly in the activation context that provided the redirection information found.
        /// This value can be presented to <see cref="QueryActCtxW"/> for more information about the contributing assembly.
        /// </summary>
        public ULONG ulAssemblyRosterIndex;

        /// <summary>
        /// 
        /// </summary>
        public ULONG ulFlags;

        /// <summary>
        /// 
        /// </summary>
        public ACTCTX_SECTION_KEYED_DATA_ASSEMBLY_METADATA AssemblyMetadata;
    }
}
