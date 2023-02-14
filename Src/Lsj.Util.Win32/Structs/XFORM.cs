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
    /// The following list describes how the members are used for each operation.
    /// Operation   eM11                            eM12                                eM21                                eM22
    /// Rotation    Cosine                          Sine                                Negative sine                       Cosine
    /// Scaling     Horizontal scaling component    Not used                            Not used                            Vertical Scaling Component
    /// Shear       Not used                        Horizontal Proportionality Constant Vertical Proportionality Constant   Not used
    /// Reflection  Horizontal Reflection Component Not used                            Not used                            Vertical Reflection Component
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct XFORM
    {
        /// <summary>
        /// Scaling     Horizontal scaling component
        /// Rotation    Cosine of rotation angle
        /// Reflection  Horizontal component
        /// </summary>
        public FLOAT eM11;

        /// <summary>
        /// Shear       Horizontal proportionality constant
        /// Rotation    Sine of the rotation angle
        /// </summary>
        public FLOAT eM12;

        /// <summary>
        /// Shear       Vertical proportionality constant
        /// Rotation    Negative sine of the rotation angle
        /// </summary>
        public FLOAT eM21;

        /// <summary>
        /// Scaling     Vertical scaling component
        /// Rotation    Cosine of rotation angle
        /// Reflection  Vertical reflection component
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
