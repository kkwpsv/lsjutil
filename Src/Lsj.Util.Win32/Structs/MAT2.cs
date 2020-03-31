using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="MAT2"/> structure contains the values for a transformation matrix used by the <see cref="GetGlyphOutline"/> function.
    /// </para>
    /// </summary>
    /// <remarks>
    /// The identity matrix produces a transformation in which the transformed graphical object is identical to the source object.
    /// In the identity matrix, the value of <see cref="eM11"/> is 1, the value of <see cref="eM12"/> is zero,
    /// the value of <see cref="eM21"/> is zero, and the value of <see cref="eM22"/> is 1.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MAT2
    {
        /// <summary>
        /// A fixed-point value for the M11 component of a 3 by 3 transformation matrix.
        /// </summary>
        public FIXED eM11;

        /// <summary>
        /// A fixed-point value for the M12 component of a 3 by 3 transformation matrix.
        /// </summary>
        public FIXED eM12;

        /// <summary>
        /// A fixed-point value for the M21 component of a 3 by 3 transformation matrix.
        /// </summary>
        public FIXED eM21;

        /// <summary>
        /// A fixed-point value for the M22 component of a 3 by 3 transformation matrix.
        /// </summary>
        public FIXED eM22;
    }
}
