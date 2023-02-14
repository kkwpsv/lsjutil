using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="STGMOVE"/> enumeration values indicate whether a storage element is to be moved or copied.
    /// They are used in the <see cref="IStorage.MoveElementTo"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypes/ne-wtypes-stgmove"/>
    /// </para>
    /// </summary>
    public enum STGMOVE
    {
        /// <summary>
        /// Indicates that the method should move the data from the source to the destination.
        /// </summary>
        STGMOVE_MOVE = 0,

        /// <summary>
        /// Indicates that the method should copy the data from the source to the destination.
        /// A copy is the same as a move except that the source element is not removed after copying the element to the destination.
        /// Copying an element on top of itself is undefined.
        /// </summary>
        STGMOVE_COPY = 1,

        /// <summary>
        /// Not implemented.
        /// </summary>
        STGMOVE_SHALLOWCOPY = 2
    }
}
