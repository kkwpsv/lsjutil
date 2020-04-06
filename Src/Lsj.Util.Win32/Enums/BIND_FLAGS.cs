using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Controls aspects of moniker binding operations.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ne-objidl-bind_flags
    /// </para>
    /// </summary>
    public enum BIND_FLAGS : uint
    {
        /// <summary>
        /// If this flag is specified, the moniker implementation can interact with the end user.
        /// Otherwise, the moniker implementation should not interact with the user in any way,
        /// such as by asking for a password for a network volume that needs mounting.
        /// If prohibited from interacting with the user when it otherwise would, a moniker implementation can use a different algorithm
        /// that does not require user interaction, or it can fail with the error <see cref="MK_E_MUSTBOTHERUSER"/>.
        /// </summary>
        BIND_MAYBOTHERUSER = 1,

        /// <summary>
        /// If this flag is specified, the caller is not interested in having the operation carried out,
        /// but only in learning whether the operation could have been carried out had this flag not been specified.
        /// For example, this flag lets the caller indicate only an interest in finding out whether an object actually exists
        /// by using this flag in a <see cref="IMoniker.BindToObject"/> call.
        /// Moniker implementations can, however, ignore this possible optimization and carry out the operation in full.
        /// Callers must be able to deal with both cases.
        /// </summary>
        BIND_JUSTTESTEXISTENCE = 2
    }
}
