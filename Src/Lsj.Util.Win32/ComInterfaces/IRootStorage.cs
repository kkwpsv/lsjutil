using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IRootStorage"/> interface contains a single method that switches a storage object
    /// to a different underlying file and saves the storage object to that file.
    /// The save operation occurs even with low-memory conditions and uncommitted changes to the storage object.
    /// A subsequent call to <see cref="IStorage.Commit"/> is guaranteed to not consume additional memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irootstorage"/>
    /// </para>
    /// </summary>
    public unsafe struct IRootStorage
    {
        nint* _vTable;
    }
}
