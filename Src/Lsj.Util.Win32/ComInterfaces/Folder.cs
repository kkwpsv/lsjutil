using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a Shell folder. This object contains properties and methods that allow you to retrieve information about the folder.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/folder"/>
    /// </para>
    /// </summary>

    public unsafe struct Folder
    {
        IntPtr* _vTable;
    }
}