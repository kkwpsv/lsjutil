using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the drawing state of a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_drawing_state_description"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_DRAWING_STATE_DESCRIPTION
    {
        /// <summary>
        /// The antialiasing mode for subsequent nontext drawing operations.
        /// </summary>
        public D2D1_ANTIALIAS_MODE antialiasMode;

        /// <summary>
        /// The antialiasing mode for subsequent text and glyph drawing operations.
        /// </summary>
        public D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode;

        /// <summary>
        /// A label for subsequent drawing operations.
        /// </summary>
        public D2D1_TAG tag1;

        /// <summary>
        /// A label for subsequent drawing operations.
        /// </summary>
        public D2D1_TAG tag2;

        /// <summary>
        /// The transformation to apply to subsequent drawing operations.
        /// </summary>
        public D2D1_MATRIX_3X2_F transform;
    }
}
