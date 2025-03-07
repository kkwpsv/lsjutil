using System;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides methods that enable an application using the <see cref="PrintDlgEx"/> function
    /// to retrieve information about the currently selected printer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nn-commdlg-iprintdialogservices"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This printer is indicated on the list of installed printers on the General page of the Print Property Sheet.
    /// </remarks>
    public unsafe struct IPrintDialogServices
    {
        IntPtr* _vTable;
    }
}
