using System;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides methods that enable an application to receive notifications and messages
    /// from the <see cref="PrintDlgEx"/> function while the Print Property Sheet is displayed.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nn-commdlg-iprintdialogcallback"/>
    /// </para>
    /// </summary>
    public unsafe struct IPrintDialogCallback
    {
        IntPtr* _vTable;
    }
}
