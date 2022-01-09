﻿using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val <see cref="DWORD"/> Array Struct For Size 2
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 2 * 4)]
    public unsafe struct ByValDWORDArrayStructForSize2
    {
    }
}
