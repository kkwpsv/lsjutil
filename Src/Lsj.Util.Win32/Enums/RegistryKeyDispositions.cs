using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Registry Key Dispositions
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcreatekeyexw"/>
    /// </para>
    /// </summary>
    public enum RegistryKeyDispositions : uint
    {
        /// <summary>
        /// The key did not exist and was created. 
        /// </summary>
        REG_CREATED_NEW_KEY = 0x00000001,

        /// <summary>
        /// The key existed and was simply opened without being changed. 
        /// </summary>
        REG_OPENED_EXISTING_KEY = 0x00000002,
    }
}
