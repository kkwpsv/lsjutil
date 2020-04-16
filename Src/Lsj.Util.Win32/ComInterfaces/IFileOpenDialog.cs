using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ComImport]
    [Guid(IID_IFileOpenDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOpenDialog : IFileDialog
    {
    }
}
