using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Parses a displayable name string to convert it into a moniker for custom moniker implementations.
    /// </para>
    /// <para>
    /// Display name parsing is necessary when the end user inputs a string to identify a component, as in the following situations:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// A compound document application that supports linked components typically supports the Edit:Links dialog box.
    /// Through this dialog box, the end user can enter a display name to specify a new link source for a specified linked component.
    /// The compound document needs to have this input string converted into a moniker.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A script language such as the macro language of a spreadsheet can allow textual references to a component.
    /// The language's interpreter needs to have such a reference converted into a moniker in order to execute the macro.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// This interface is not supported for use across machine boundaries.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-iparsedisplayname"/>
    /// </para>
    /// </summary>
    public unsafe struct IParseDisplayName
    {
        nint* _vTable;
    }
}
