using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="XFORM"/> structure specifies a world-space to page-space transformation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-xform"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The following list describes how the members are used for each operation.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Operation
    /// </term>
    /// <term>
    /// <see cref="eM11"/>
    /// </term>
    /// <term>
    /// <see cref="eM12"/>
    /// </term>
    /// <term>
    /// <see cref="eM21"/>
    /// </term>
    /// <term>
    /// <see cref="eM22"/>
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Rotation
    /// </term>
    /// <term>
    /// Cosine
    /// </term>
    /// <term>
    /// Sine
    /// </term>
    /// <term>
    /// Negative sine
    /// </term>
    /// <term>
    /// Cosine
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Scaling
    /// </term>
    /// <term>
    /// Horizontal scaling component
    /// </term>
    /// <term>
    /// Not used
    /// </term>
    /// <term>
    /// Not used
    /// </term>
    /// <term>
    /// Vertical Scaling Component
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Shear
    /// </term>
    /// <term>
    /// Not used
    /// </term>
    /// <term>
    /// Horizontal Proportionality Constant
    /// </term>
    /// <term>
    /// Vertical Proportionality Constant
    /// </term>
    /// <term>
    /// Not used
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Reflection
    /// </term>
    /// <term>
    /// Horizontal Reflection Component
    /// </term>
    /// <term>
    /// Not used
    /// </term>
    /// <term>
    /// Not used
    /// </term>
    /// <term>
    /// Vertical Reflection Component
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct XFORM
    {
        /// <summary>
        /// <para>
        /// The following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Operation
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Scaling
        /// </term>
        /// <term>
        /// Horizontal scaling component
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Rotation
        /// </term>
        /// <term>
        /// Cosine of rotation angle
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Reflection
        /// </term>
        /// <term>
        /// Horizontal component
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FLOAT eM11;

        /// <summary>
        /// <para>
        /// The following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Operation
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Shear
        /// </term>
        /// <term>
        /// Horizontal proportionality constant
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Rotation
        /// </term>
        /// <term>
        /// Sine of the rotation angle
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FLOAT eM12;

        /// <summary>
        /// <para>
        /// The following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Operation
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Shear
        /// </term>
        /// <term>
        /// Vertical proportionality constant
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Rotation
        /// </term>
        /// <term>
        /// Negative sine of the rotation angle
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FLOAT eM21;

        /// <summary>
        /// <para>
        /// The following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Operation
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Scaling
        /// </term>
        /// <term>
        /// Vertical scaling component
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Rotation
        /// </term>
        /// <term>
        /// Cosine of rotation angle
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Reflection
        /// </term>
        /// <term>
        /// Vertical reflection component
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FLOAT eM22;

        /// <summary>
        /// The horizontal translation component, in logical units.
        /// </summary>
        public FLOAT eDx;

        /// <summary>
        /// The vertical translation component, in logical units.
        /// </summary>
        public FLOAT eDy;
    }
}
