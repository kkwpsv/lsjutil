using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enumerates the different verbs available for an object in order of ascending verb number.
    /// An enumerator that implements the <see cref="IEnumOLEVERB"/> interface is returned by <see cref="IOleObject.EnumVerbs"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ienumoleverb"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumOLEVERB
    {
        IntPtr* _vTable;
    }
}
