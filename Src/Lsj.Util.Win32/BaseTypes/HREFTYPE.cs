using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="HREFTYPE"/> is a 32-bit value that an automation type library server uses as a handle
    /// to associate a type that is defined or referenced in its automation scope with an instance of an automation type description server.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-oaut/ed6620b1-6b23-4fa1-99e6-781832999f93"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct HREFTYPE
    {
        [FieldOffset(0)]
        private uint _value;
    }
}
