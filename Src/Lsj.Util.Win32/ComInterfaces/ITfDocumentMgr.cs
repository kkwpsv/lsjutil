using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="ITfDocumentMgr"/> interface is implemented by the TSF manager
    /// and used by an application or text service to create and manage text contexts.
    /// To obtain an instance of this interface call <see cref="ITfThreadMgr.CreateDocumentMgr"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfdocumentmgr"/>
    /// </para>
    /// </summary>
    public unsafe struct ITfDocumentMgr
    {
        IntPtr* _vTable;
    }
}
