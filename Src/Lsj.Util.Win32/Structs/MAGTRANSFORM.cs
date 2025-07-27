using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a transformation matrix that a magnifier control uses to magnify screen content.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/magnification/ns-magnification-magtransform"/>
    /// </para>
    /// <remark>
    /// <para>
    /// The transformation matrix is
    /// </para>
    /// <code>
    /// (n, 0.0, 0.0)
    /// (0.0, n, 0.0)
    /// (0.0, 0.0, 1.0)
    /// </code>
    /// <para>
    /// where n is the magnification factor.
    /// </para>
    /// </remark>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MAGTRANSFORM
    {
        private float _transform00;
        private float _transform01;
        private float _transform02;
        private float _transform10;
        private float _transform11;
        private float _transform12;
        private float _transform20;
        private float _transform21;
        private float _transform22;
    }
}
